using BagShopManagement.Controllers;
using BagShopManagement.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class KichThuocControl : UserControl
    {
        private readonly KichThuocController _controller;

        public KichThuocControl(KichThuocController controller)
        {
            InitializeComponent();
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

            this.Load += KichThuocControl_Load;
        }

        private void KichThuocControl_Load(object sender, EventArgs e)
        {
            if (dgvKichThuoc.Columns.Count == 0)
            {
                dgvKichThuoc.AutoGenerateColumns = false;
                // Cho toàn bộ DataGridView fill chiều ngang
                dgvKichThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvKichThuoc.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mã KT",
                    DataPropertyName = "MaKichThuoc",
                    Name = "MaKichThuoc",
                    ReadOnly = true,
                    FillWeight = 15
                });
                dgvKichThuoc.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Tên kích thước",
                    DataPropertyName = "TenKichThuoc",
                    Name = "TenKichThuoc",
                    FillWeight = 25
                });
                dgvKichThuoc.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Chiều dài",
                    DataPropertyName = "ChieuDai",
                    Name = "ChieuDai",
                    FillWeight = 20
                });
                dgvKichThuoc.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Chiều rộng",
                    DataPropertyName = "ChieuRong",
                    Name = "ChieuRong",
                    FillWeight = 20
                });
                dgvKichThuoc.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Chiều cao",
                    DataPropertyName = "ChieuCao",
                    Name = "ChieuCao",
                    FillWeight = 20
                });
            }

            LoadData();
            try { txtSearch.PlaceholderText = "Tìm kiếm..."; } catch { }
        }

        private void LoadData()
        {
            try
            {
                dgvKichThuoc.DataSource = _controller.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dgvKichThuoc.DataSource = _controller.Search(kw);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new KichThuocEditForm(_controller))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvKichThuoc.CurrentRow == null) return;
            if (dgvKichThuoc.CurrentRow.DataBoundItem is not KichThuoc model) return;

            using (var f = new KichThuocEditForm(_controller, model))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvKichThuoc.CurrentRow == null) return;
            if (dgvKichThuoc.CurrentRow.DataBoundItem is not KichThuoc model) return;

            if (MessageBox.Show($"Xóa kích thước '{model.TenKichThuoc}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var ok = _controller.Delete(model.MaKichThuoc);
                    if (ok) LoadData();
                    else MessageBox.Show("Xóa thất bại. Có thể bản ghi đang được tham chiếu.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvKichThuoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvKichThuoc.Rows[e.RowIndex].DataBoundItem is not KichThuoc model) return;

            using (var f = new KichThuocEditForm(_controller, model))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
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
                    Title = "Chọn file Excel để import kích thước"
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
                if (ws.Cells[1, 1].Text.ToLower().Contains("kích thước"))
                    headerRow = 2;

                var headers = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                int lastCol = ws.Dimension.End.Column;

                for (int c = 1; c <= lastCol; c++)
                {
                    string name = ws.Cells[headerRow, c].Text.Trim();
                    switch (name.ToLower())
                    {
                        case "mã kích thước":
                        case "makichthuoc": headers["MaKichThuoc"] = c; break;
                        case "tên kích thước":
                        case "tenkichthuoc": headers["TenKichThuoc"] = c; break;
                        case "chiều dài":
                        case "chieudai": headers["ChieuDai"] = c; break;
                        case "chiều rộng":
                        case "chieurong": headers["ChieuRong"] = c; break;
                        case "chiều cao":
                        case "chieucao": headers["ChieuCao"] = c; break;
                    }
                }

                if (!headers.ContainsKey("TenKichThuoc"))
                {
                    MessageBox.Show("Không tìm thấy cột 'Tên kích thước'.", "Lỗi");
                    return;
                }

                var existingList = _controller.GetAll() ?? new List<KichThuoc>();
                int lastRow = ws.Dimension.End.Row;
                int inserted = 0, updated = 0, skipped = 0;

                for (int r = headerRow + 1; r <= lastRow; r++)
                {
                    string ten = ws.Cells[r, headers["TenKichThuoc"]].Text?.Trim();
                    if (string.IsNullOrEmpty(ten)) { skipped++; continue; }

                    string daiTxt = ws.Cells[r, headers["ChieuDai"]].Text?.Trim().Replace(',', '.') ?? "0";
                    string rongTxt = ws.Cells[r, headers["ChieuRong"]].Text?.Trim().Replace(',', '.') ?? "0";
                    string caoTxt = ws.Cells[r, headers["ChieuCao"]].Text?.Trim().Replace(',', '.') ?? "0";

                    if (!decimal.TryParse(daiTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal dai) ||
                        !decimal.TryParse(rongTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal rong) ||
                        !decimal.TryParse(caoTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cao))
                    {
                        skipped++;
                        continue;
                    }

                    KichThuoc existing = null;

                    // Nếu có mã → ưu tiên tìm theo mã
                    if (headers.ContainsKey("MaKichThuoc"))
                    {
                        var ma = ws.Cells[r, headers["MaKichThuoc"]].Text?.Trim();
                        if (!string.IsNullOrEmpty(ma))
                            existing = existingList.FirstOrDefault(x =>
                                string.Equals(x.MaKichThuoc, ma, StringComparison.OrdinalIgnoreCase));
                    }

                    // Nếu không tìm theo mã → tìm theo tên
                    if (existing == null)
                    {
                        existing = existingList.FirstOrDefault(x =>
                            string.Equals(x.TenKichThuoc?.Trim(), ten, StringComparison.OrdinalIgnoreCase));
                    }

                    if (existing != null)
                    {
                        existing.TenKichThuoc = ten;
                        existing.ChieuDai = dai;
                        existing.ChieuRong = rong;
                        existing.ChieuCao = cao;
                        if (_controller.Update(existing)) updated++; else skipped++;
                    }
                    else
                    {
                        var newItem = new KichThuoc
                        {
                            MaKichThuoc = _controller.GenerateNextCode(),
                            TenKichThuoc = ten,
                            ChieuDai = dai,
                            ChieuRong = rong,
                            ChieuCao = cao
                        };
                        if (_controller.Add(newItem))
                        {
                            inserted++;
                            existingList.Add(newItem);
                        }
                        else skipped++;
                    }
                }

                LoadData();
                MessageBox.Show($"Import hoàn tất.\nThêm: {inserted}\nCập nhật: {updated}\nBỏ qua: {skipped}",
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
                    FileName = $"KichThuoc_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                };
                if (sfd.ShowDialog() != DialogResult.OK) return;

                var list = (dgvKichThuoc.DataSource as List<KichThuoc>) ?? _controller.GetAll();
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var p = new ExcelPackage();
                var ws = p.Workbook.Worksheets.Add("Kích thước");

                // ====== TIÊU ĐỀ LỚN ======
                ws.Cells["A1"].Value = "DANH MỤC KÍCH THƯỚC";
                ws.Cells["A1:E1"].Merge = true;
                ws.Cells["A1"].Style.Font.Size = 18;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                // ====== HEADER ======
                string[] headers = { "Mã kích thước", "Tên kích thước", "Chiều dài", "Chiều rộng", "Chiều cao" };
                for (int i = 0; i < headers.Length; i++)
                    ws.Cells[2, i + 1].Value = headers[i];

                using (var range = ws.Cells["A2:E2"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 12;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                }

                // ====== GHI DỮ LIỆU ======
                int row = 3;
                foreach (var x in list)
                {
                    ws.Cells[row, 1].Value = x.MaKichThuoc;
                    ws.Cells[row, 2].Value = x.TenKichThuoc;
                    ws.Cells[row, 3].Value = x.ChieuDai;
                    ws.Cells[row, 4].Value = x.ChieuRong;
                    ws.Cells[row, 5].Value = x.ChieuCao;
                    row++;
                }

                ws.Cells[2, 1, row - 1, headers.Length].AutoFitColumns();
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
