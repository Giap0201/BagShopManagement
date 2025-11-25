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
    public partial class LoaiTuiControl : UserControl
    {
        private readonly ILoaiTuiService _service;

        // Inject Controller (đã có sẵn Service bên trong)
        public LoaiTuiControl(ILoaiTuiService service)
        {
            InitializeComponent();

            _service = service;

            // Wire events an toàn
            this.Load += LoaiTuiControl_Load;
        }

        private void LoaiTuiControl_Load(object sender, EventArgs e)
        {
            if (dgvLoaiTui.Columns.Count == 0)
            {
                dgvLoaiTui.AutoGenerateColumns = false;
                // Cho toàn bộ DataGridView fill chiều ngang
                dgvLoaiTui.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLoaiTui.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mã loại túi",
                    DataPropertyName = "MaLoaiTui",
                    Name = "MaLoaiTui",
                    ReadOnly = true,
                    FillWeight = 20   // 20%
                });
                dgvLoaiTui.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Tên loại túi",
                    DataPropertyName = "TenLoaiTui",
                    Name = "TenLoaiTui",
                    FillWeight = 40   // 40%
                });
                dgvLoaiTui.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mô tả",
                    DataPropertyName = "MoTa",
                    Name = "MoTa",
                    FillWeight = 40   // 40%
                });
            }

            LoadData();
            try { txtSearch.PlaceholderText = "Tìm kiếm"; } catch { }
        }

        private void LoadData()
        {
            try
            {
                dgvLoaiTui.DataSource = _service.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var kw = txtSearch.Text?.Trim();
            if (string.IsNullOrEmpty(kw))
                LoadData();
            else
            {
                try
                {
                    dgvLoaiTui.DataSource = _service.Search(kw);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new LoaiTuiEditForm(_service))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLoaiTui.CurrentRow == null) return;
            var model = dgvLoaiTui.CurrentRow.DataBoundItem as DanhMucLoaiTui;
            if (model == null) return;

            using (var f = new LoaiTuiEditForm(_service, model))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLoaiTui.CurrentRow == null) return;
            var model = dgvLoaiTui.CurrentRow.DataBoundItem as DanhMucLoaiTui;
            if (model == null) return;

            if (MessageBox.Show($"Xóa loại túi '{model.TenLoaiTui}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var ok = _service.Delete(model.MaLoaiTui);
                    if (ok) LoadData();
                    else MessageBox.Show("Xóa thất bại. Bản ghi có thể đang được tham chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvLoaiTui_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var model = dgvLoaiTui.Rows[e.RowIndex].DataBoundItem as DanhMucLoaiTui;
            if (model == null) return;

            using (var f = new LoaiTuiEditForm(_service, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        // ===== Import từ Excel =====
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Chọn file Excel để import Loại túi"
                };
                if (ofd.ShowDialog() != DialogResult.OK) return;

                if (MessageBox.Show("Bạn có chắc chắn muốn import file này không?\nDữ liệu sẽ được cập nhật.",
                    "Xác nhận Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage(new FileInfo(ofd.FileName));
                var ws = package.Workbook.Worksheets.FirstOrDefault();
                if (ws == null)
                {
                    MessageBox.Show("File Excel không có sheet.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ===== XÁC ĐỊNH DÒNG HEADER =====
                int headerRow = 1;
                if (ws.Cells[1, 1].Text.Trim().ToLower().Contains("loại túi"))
                    headerRow = 2;

                int lastCol = ws.Dimension.End.Column;
                int lastRow = ws.Dimension.End.Row;

                int colMa = -1, colTen = -1, colMoTa = -1;
                for (int c = 1; c <= lastCol; c++)
                {
                    var h = ws.Cells[headerRow, c].Text?.Trim().ToLower();
                    switch (h)
                    {
                        case "mã loại túi": case "maloaitui": colMa = c; break;
                        case "tên loại túi": case "tenloaitui": colTen = c; break;
                        case "mô tả": case "mota": colMoTa = c; break;
                    }
                }

                if (colTen == -1)
                {
                    MessageBox.Show("Không tìm thấy cột 'Tên loại túi'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existingList = _service.GetAll() ?? new List<DanhMucLoaiTui>();
                int inserted = 0, updated = 0, skipped = 0;

                for (int r = headerRow + 1; r <= lastRow; r++)
                {
                    string ten = ws.Cells[r, colTen].Text?.Trim();
                    if (string.IsNullOrEmpty(ten)) { skipped++; continue; }

                    string mota = colMoTa != -1 ? ws.Cells[r, colMoTa].Text?.Trim() : null;

                    DanhMucLoaiTui existing = null;

                    // Ưu tiên tìm theo mã
                    if (colMa != -1)
                    {
                        var ma = ws.Cells[r, colMa].Text?.Trim();
                        if (!string.IsNullOrEmpty(ma))
                            existing = existingList.FirstOrDefault(x =>
                                string.Equals(x.MaLoaiTui, ma, StringComparison.OrdinalIgnoreCase));
                    }

                    // Nếu không có mã → tìm theo tên
                    if (existing == null)
                    {
                        existing = existingList.FirstOrDefault(x =>
                            string.Equals(x.TenLoaiTui?.Trim(), ten, StringComparison.OrdinalIgnoreCase));
                    }

                    // Cập nhật
                    if (existing != null)
                    {
                        existing.TenLoaiTui = ten;
                        existing.MoTa = mota;
                        if (_service.Update(existing)) updated++; else skipped++;
                    }
                    else
                    {
                        // Thêm mới
                        var newItem = new DanhMucLoaiTui
                        {
                            MaLoaiTui = _service.GenerateNextCode(),
                            TenLoaiTui = ten,
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
                MessageBox.Show($"Import hoàn tất.\nThêm mới: {inserted}\nCập nhật: {updated}\nBỏ qua: {skipped}",
                    "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== Export ra Excel =====
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using var sfd = new SaveFileDialog
                {
                    Filter = "Excel File|*.xlsx",
                    FileName = $"LoaiTui_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                };
                if (sfd.ShowDialog() != DialogResult.OK) return;

                var list = (dgvLoaiTui.DataSource as List<DanhMucLoaiTui>) ?? _service.GetAll();
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var p = new ExcelPackage();
                var ws = p.Workbook.Worksheets.Add("Loại túi");

                // ====== TIÊU ĐỀ LỚN ======
                ws.Cells["A1"].Value = "DANH MỤC LOẠI TÚI";
                ws.Cells["A1:C1"].Merge = true;
                ws.Cells["A1"].Style.Font.Size = 18;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                // ====== HEADER ======
                ws.Cells["A2"].Value = "Mã loại túi";
                ws.Cells["B2"].Value = "Tên loại túi";
                ws.Cells["C2"].Value = "Mô tả";

                using (var r = ws.Cells["A2:C2"])
                {
                    r.Style.Font.Bold = true;
                    r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    r.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                }

                // ====== GHI DỮ LIỆU ======
                int row = 3;
                foreach (var x in list)
                {
                    ws.Cells[row, 1].Value = x.MaLoaiTui;
                    ws.Cells[row, 2].Value = x.TenLoaiTui;
                    ws.Cells[row, 3].Value = x.MoTa;
                    row++;
                }

                ws.Cells[2, 1, row - 1, 3].AutoFitColumns();
                ws.View.FreezePanes(3, 1);

                p.SaveAs(new FileInfo(sfd.FileName));
                MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
