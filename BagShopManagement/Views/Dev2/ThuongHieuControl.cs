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
    public partial class ThuongHieuControl : UserControl
    {
        private readonly IThuongHieuService _service;

        public ThuongHieuControl(IThuongHieuService service)
        {
            InitializeComponent();
            _service = service;

            // Wire events
            this.Load += ThuongHieuControl_Load;
        }

        private void ThuongHieuControl_Load(object sender, EventArgs e)
        {
            if (dgvThuongHieu.Columns.Count == 0)
            {
                dgvThuongHieu.AutoGenerateColumns = false;
                // Cho toàn bộ DataGridView fill chiều ngang
                dgvThuongHieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvThuongHieu.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Mã thương hiệu", DataPropertyName = "MaThuongHieu", Name = "MaThuongHieu", ReadOnly = true, FillWeight = 20 });
                dgvThuongHieu.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên thương hiệu", DataPropertyName = "TenThuongHieu", Name = "TenThuongHieu", FillWeight = 40 });
                dgvThuongHieu.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Quốc gia", DataPropertyName = "QuocGia", Name = "QuocGia", FillWeight = 40 });
            }

            LoadData();
            try { txtSearch.PlaceholderText = "Tìm kiếm"; } catch { }
        }

        private void LoadData()
        {
            try { dgvThuongHieu.DataSource = _service.GetAll(); }
            catch (Exception ex) { MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var kw = txtSearch.Text?.Trim();
            dgvThuongHieu.DataSource = string.IsNullOrEmpty(kw) ? _service.GetAll() : _service.Search(kw);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var f = new ThuongHieuEditForm(_service);
            if (f.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvThuongHieu.CurrentRow?.DataBoundItem is not ThuongHieu model) return;

            using var f = new ThuongHieuEditForm(_service, model);
            if (f.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvThuongHieu.CurrentRow?.DataBoundItem is not ThuongHieu model) return;
            if (MessageBox.Show($"Xóa thương hiệu '{model.TenThuongHieu}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                if (_service.Delete(model.MaThuongHieu)) LoadData();
                else MessageBox.Show("Xóa thất bại. Có thể bản ghi đang được tham chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvThuongHieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvThuongHieu.Rows[e.RowIndex].DataBoundItem is not ThuongHieu model) return;

            using var f = new ThuongHieuEditForm(_service, model);
            if (f.ShowDialog() == DialogResult.OK) LoadData();
        }

        // ================= IMPORT =================
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Chọn file Excel để import thương hiệu"
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
                if (ws.Cells[1, 1].Text.Trim().ToLower().Contains("thương"))
                    headerRow = 2;

                int lastCol = ws.Dimension.End.Column;
                int lastRow = ws.Dimension.End.Row;

                int colMa = -1, colTen = -1, colQuocGia = -1;

                for (int c = 1; c <= lastCol; c++)
                {
                    var h = ws.Cells[headerRow, c].Text?.Trim().ToLower();
                    switch (h)
                    {
                        case "mã thương hiệu":
                        case "mathuonghieu":
                            colMa = c;
                            break;

                        case "tên thương hiệu":
                        case "tenthương hiệu":
                        case "tenthuonghieu":
                            colTen = c;
                            break;

                        case "quốc gia":
                        case "quocgia":
                            colQuocGia = c;
                            break;
                    }
                }

                if (colTen == -1)
                {
                    MessageBox.Show("Không tìm thấy cột 'Tên thương hiệu'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existingList = _service.GetAll() ?? new List<ThuongHieu>();
                int inserted = 0, updated = 0, skipped = 0;

                for (int r = headerRow + 1; r <= lastRow; r++)
                {
                    string ten = ws.Cells[r, colTen].Text?.Trim();
                    if (string.IsNullOrEmpty(ten)) { skipped++; continue; }

                    string qg = colQuocGia != -1 ? ws.Cells[r, colQuocGia].Text?.Trim() : null;
                    if (string.IsNullOrWhiteSpace(qg)) qg = null;

                    ThuongHieu existing = null;

                    // Tìm theo mã trước
                    if (colMa != -1)
                    {
                        var ma = ws.Cells[r, colMa].Text?.Trim();
                        if (!string.IsNullOrEmpty(ma))
                            existing = existingList.FirstOrDefault(x => x.MaThuongHieu == ma);
                    }

                    // Nếu không có mã → tìm theo tên
                    if (existing == null)
                        existing = existingList.FirstOrDefault(x =>
                            string.Equals(x.TenThuongHieu?.Trim(), ten, StringComparison.OrdinalIgnoreCase));

                    if (existing != null)
                    {
                        existing.TenThuongHieu = ten;
                        existing.QuocGia = qg;
                        if (_service.Update(existing))
                            updated++;
                        else skipped++;
                    }
                    else
                    {
                        var newItem = new ThuongHieu
                        {
                            MaThuongHieu = _service.GenerateNextCode(),
                            TenThuongHieu = ten,
                            QuocGia = qg
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


        // ================= EXPORT =================
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using var sfd = new SaveFileDialog
                {
                    Filter = "Excel File|*.xlsx",
                    FileName = $"ThuongHieu_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                };
                if (sfd.ShowDialog() != DialogResult.OK) return;

                var list = (dgvThuongHieu.DataSource as List<ThuongHieu>) ?? _service.GetAll();
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var p = new ExcelPackage();
                var ws = p.Workbook.Worksheets.Add("Thương hiệu");

                // ====== TIÊU ĐỀ LỚN ======
                ws.Cells["A1"].Value = "DANH MỤC THƯƠNG HIỆU";
                ws.Cells["A1:C1"].Merge = true;
                ws.Cells["A1"].Style.Font.Size = 18;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // ====== HEADER ======
                ws.Cells["A2"].Value = "Mã thương hiệu";
                ws.Cells["B2"].Value = "Tên thương hiệu";
                ws.Cells["C2"].Value = "Quốc gia";

                using (var r = ws.Cells["A2:C2"])
                {
                    r.Style.Font.Bold = true;
                    r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    r.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                }

                // ====== DATA ======
                int row = 3;
                foreach (var x in list)
                {
                    ws.Cells[row, 1].Value = x.MaThuongHieu;
                    ws.Cells[row, 2].Value = x.TenThuongHieu;
                    ws.Cells[row, 3].Value = x.QuocGia;
                    row++;
                }

                // ====== WIDTH ======
                ws.Cells[2, 1, row - 1, 3].AutoFitColumns();

                ws.View.FreezePanes(3, 1);

                p.SaveAs(new FileInfo(sfd.FileName));
                MessageBox.Show("Xuất file thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
