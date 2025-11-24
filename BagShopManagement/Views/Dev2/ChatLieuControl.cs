using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class ChatLieuControl : UserControl
    {
        private readonly IChatLieuService _service;

        public ChatLieuControl(IChatLieuService service)
        {
            InitializeComponent();
            _service = service ?? throw new ArgumentNullException(nameof(service));

            // Wire sự kiện an toàn
            this.Load += ChatLieuControl_Load;
        }

        // ====== Load dữ liệu & giao diện ======
        private void ChatLieuControl_Load(object sender, EventArgs e)
        {
            if (dgvChatLieu.Columns.Count == 0)
            {
                dgvChatLieu.AutoGenerateColumns = false;
                // Cho toàn bộ DataGridView fill chiều ngang
                dgvChatLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvChatLieu.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mã chất liệu",
                    DataPropertyName = "MaChatLieu",
                    Name = "MaChatLieu",
                    ReadOnly = true,
                    FillWeight = 20   // 20%
                });
                dgvChatLieu.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Tên chất liệu",
                    DataPropertyName = "TenChatLieu",
                    Name = "TenChatLieu",
                    FillWeight = 40   // 40%
                });
                dgvChatLieu.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mô tả",
                    DataPropertyName = "MoTa",
                    Name = "MoTa",
                    FillWeight = 40   // 40%
                });
            }

            LoadData();
            try { txtSearch.PlaceholderText = "Tìm kiếm..."; } catch { }
        }

        private void LoadData()
        {
            try
            {
                dgvChatLieu.DataSource = _service.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== Tìm kiếm ======
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text?.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            try
            {
                dgvChatLieu.DataSource = _service.Search(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====== CRUD ======
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new ChatLieuEditForm(_service))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvChatLieu.CurrentRow == null) return;
            if (dgvChatLieu.CurrentRow.DataBoundItem is not ChatLieu model) return;

            using (var f = new ChatLieuEditForm(_service, model))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvChatLieu.CurrentRow == null) return;
            if (dgvChatLieu.CurrentRow.DataBoundItem is not ChatLieu model) return;

            if (MessageBox.Show($"Xóa chất liệu '{model.TenChatLieu}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_service.Delete(model.MaChatLieu))
                        LoadData();
                    else
                        MessageBox.Show("Xóa thất bại. Có thể bản ghi đang được tham chiếu.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvChatLieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvChatLieu.Rows[e.RowIndex].DataBoundItem is not ChatLieu model) return;

            using (var f = new ChatLieuEditForm(_service, model))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        // ====== Import từ Excel ======
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Chọn file Excel để import"
                };

                if (ofd.ShowDialog() != DialogResult.OK) return;

                if (MessageBox.Show(
                        "Bạn có chắc chắn muốn import file này không?\nDữ liệu sẽ được cập nhật.",
                        "Xác nhận Import",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                int inserted = 0, updated = 0, skipped = 0;

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage(new FileInfo(ofd.FileName));
                var ws = package.Workbook.Worksheets.FirstOrDefault();
                if (ws == null)
                {
                    MessageBox.Show("File Excel không có sheet.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nếu tiêu đề lớn ở dòng 1 → bỏ qua
                int headerRow = 1;
                if (ws.Cells[1, 1].Text.Trim().ToLower().Contains("danh mục"))
                    headerRow = 2;

                // =======================
                // Tìm vị trí các cột header
                // =======================
                int colMa = -1, colTen = -1, colMoTa = -1;
                int lastCol = ws.Dimension.End.Column;

                for (int c = 1; c <= lastCol; c++)
                {
                    var h = ws.Cells[headerRow, c].Text?.Trim().ToLower();

                    switch (h)
                    {
                        case "mã chất liệu":
                        case "machatlieu":
                            colMa = c;
                            break;

                        case "tên chất liệu":
                        case "tenchatlieu":
                            colTen = c;
                            break;

                        case "mô tả":
                        case "mota":
                            colMoTa = c;
                            break;
                    }
                }

                if (colTen == -1)
                {
                    MessageBox.Show("Không tìm thấy cột 'Tên chất liệu' trong file.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existingList = _service.GetAll() ?? new List<ChatLieu>();
                int lastRow = ws.Dimension.End.Row;

                // =======================
                // Đọc dữ liệu từ dòng kế tiếp header
                // =======================
                for (int r = headerRow + 1; r <= lastRow; r++)
                {
                    var ten = ws.Cells[r, colTen].Text?.Trim();
                    if (string.IsNullOrEmpty(ten)) { skipped++; continue; }

                    var mota = colMoTa != -1 ? ws.Cells[r, colMoTa].Text?.Trim() : null;

                    ChatLieu existing = null;

                    // Có cột mã → ưu tiên cập nhật theo mã
                    if (colMa != -1)
                    {
                        var ma = ws.Cells[r, colMa].Text?.Trim();
                        if (!string.IsNullOrEmpty(ma))
                            existing = existingList.FirstOrDefault(x =>
                                string.Equals(x.MaChatLieu, ma, StringComparison.OrdinalIgnoreCase));
                    }

                    // Không tìm thấy theo mã → tìm theo tên
                    if (existing == null)
                    {
                        existing = existingList.FirstOrDefault(x =>
                            string.Equals(x.TenChatLieu?.Trim(), ten, StringComparison.OrdinalIgnoreCase));
                    }

                    // Cập nhật
                    if (existing != null)
                    {
                        existing.TenChatLieu = ten;
                        existing.MoTa = mota;

                        if (_service.Update(existing)) updated++;
                        else skipped++;
                    }
                    else
                    {
                        // Thêm mới
                        var newItem = new ChatLieu
                        {
                            MaChatLieu = _service.GenerateNextCode(),
                            TenChatLieu = ten,
                            MoTa = mota
                        };

                        if (_service.Add(newItem))
                        {
                            inserted++;
                            existingList.Add(newItem);
                        }
                        else skipped++;
                    }
                }

                LoadData();

                MessageBox.Show(
                    $"Import hoàn tất.\n\nThêm mới: {inserted}\nCập nhật: {updated}\nBỏ qua: {skipped}",
                    "Kết quả",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ====== Export ra Excel ======
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using var sfd = new SaveFileDialog
                {
                    Filter = "Excel File|*.xlsx",
                    FileName = $"ChatLieu_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                };
                if (sfd.ShowDialog() != DialogResult.OK) return;

                var list = (dgvChatLieu.DataSource as List<ChatLieu>) ?? _service.GetAll();
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var p = new ExcelPackage();
                var ws = p.Workbook.Worksheets.Add("ChatLieu");

                // ===========================
                // 1️⃣ TIÊU ĐỀ LỚN
                // ===========================
                ws.Cells["A1"].Value = "DANH MỤC CHẤT LIỆU";
                ws.Cells["A1:C1"].Merge = true;
                ws.Cells["A1"].Style.Font.Size = 18;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // ===========================
                // 2️⃣ TIÊU ĐỀ CỘT (tiếng Việt)
                // ===========================
                ws.Cells["A2"].Value = "Mã chất liệu";
                ws.Cells["B2"].Value = "Tên chất liệu";
                ws.Cells["C2"].Value = "Mô tả";

                using (var r = ws.Cells["A2:C2"])
                {
                    r.Style.Font.Bold = true;
                    r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    r.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                }

                // ===========================
                // 3️⃣ GHI DỮ LIỆU
                // ===========================
                int row = 3;
                foreach (var x in list)
                {
                    ws.Cells[row, 1].Value = x.MaChatLieu;
                    ws.Cells[row, 2].Value = x.TenChatLieu;
                    ws.Cells[row, 3].Value = x.MoTa;
                    row++;
                }

                ws.Cells.AutoFitColumns();
                p.SaveAs(new FileInfo(sfd.FileName));

                MessageBox.Show("Xuất file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
