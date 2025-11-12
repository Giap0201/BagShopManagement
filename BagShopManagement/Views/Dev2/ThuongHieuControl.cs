using BagShopManagement.Controllers;
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
        private readonly ThuongHieuController _controller;

        public ThuongHieuControl(IThuongHieuService service)
        {
            InitializeComponent();
            _controller = new ThuongHieuController(service);

            // Wire events
            this.Load += ThuongHieuControl_Load;
        }

        private void ThuongHieuControl_Load(object sender, EventArgs e)
        {
            if (dgvThuongHieu.Columns.Count == 0)
            {
                dgvThuongHieu.AutoGenerateColumns = false;
                dgvThuongHieu.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Mã", DataPropertyName = "MaThuongHieu", Name = "MaThuongHieu", ReadOnly = true, Width = 120 });
                dgvThuongHieu.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tên", DataPropertyName = "TenThuongHieu", Name = "TenThuongHieu", Width = 250 });
                dgvThuongHieu.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Quốc gia", DataPropertyName = "QuocGia", Name = "QuocGia", Width = 200 });
            }

            LoadData();
            try { txtSearch.PlaceholderText = "Tìm kiếm"; } catch { }
        }

        private void LoadData()
        {
            try { dgvThuongHieu.DataSource = _controller.GetAll(); }
            catch (Exception ex) { MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var kw = txtSearch.Text?.Trim();
            dgvThuongHieu.DataSource = string.IsNullOrEmpty(kw) ? _controller.GetAll() : _controller.Search(kw);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var f = new ThuongHieuEditForm(_controller);
            if (f.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvThuongHieu.CurrentRow?.DataBoundItem is not ThuongHieu model) return;

            using var f = new ThuongHieuEditForm(_controller, model);
            if (f.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvThuongHieu.CurrentRow?.DataBoundItem is not ThuongHieu model) return;
            if (MessageBox.Show($"Xóa thương hiệu '{model.TenThuongHieu}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                if (_controller.Delete(model.MaThuongHieu)) LoadData();
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

            using var f = new ThuongHieuEditForm(_controller, model);
            if (f.ShowDialog() == DialogResult.OK) LoadData();
        }

        // ================= IMPORT =================
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog { Filter = "Excel files (*.xlsx)|*.xlsx", Title = "Chọn file Excel để import (TenThuongHieu, QuocGia)" };
                if (ofd.ShowDialog() != DialogResult.OK) return;
                if (MessageBox.Show("Bạn có chắc chắn muốn import file này không?\nSau khi import sẽ cập nhật dữ liệu danh mục.", "Xác nhận Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                var file = ofd.FileName;
                if (!File.Exists(file)) { MessageBox.Show("File không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                int inserted = 0, updated = 0, skipped = 0;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var package = new ExcelPackage(stream);
                var ws = package.Workbook.Worksheets.FirstOrDefault();
                if (ws == null) { MessageBox.Show("File Excel không có sheet.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                int startRow = 1, colTen = -1, colQuocGia = -1;
                for (int c = 1; c <= ws.Dimension.End.Column; c++)
                {
                    var h = (ws.Cells[startRow, c].Text ?? "").Trim();
                    if (string.Equals(h, "TenThuongHieu", StringComparison.OrdinalIgnoreCase)) colTen = c;
                    if (string.Equals(h, "QuocGia", StringComparison.OrdinalIgnoreCase)) colQuocGia = c;
                }
                if (colTen == -1) { MessageBox.Show("Không tìm thấy cột 'TenThuongHieu'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                var existingList = _controller.GetAll() ?? new List<ThuongHieu>();
                for (int r = startRow + 1; r <= ws.Dimension.End.Row; r++)
                {
                    var ten = (ws.Cells[r, colTen].Text ?? "").Trim();
                    if (string.IsNullOrEmpty(ten)) { skipped++; continue; }

                    var qgCell = colQuocGia != -1 ? (ws.Cells[r, colQuocGia].Text ?? "").Trim() : null;
                    string quocGiaValue = string.IsNullOrWhiteSpace(qgCell) ? null : qgCell;

                    var existing = existingList.Find(x => string.Equals(x.TenThuongHieu?.Trim(), ten, StringComparison.OrdinalIgnoreCase));
                    if (existing != null)
                    {
                        if (!string.IsNullOrWhiteSpace(qgCell)) existing.QuocGia = quocGiaValue;
                        if (_controller.Update(existing)) updated++; else skipped++;
                    }
                    else
                    {
                        var newItem = new ThuongHieu { MaThuongHieu = _controller.GenerateNextCode(), TenThuongHieu = ten, QuocGia = quocGiaValue };
                        if (_controller.Add(newItem)) { inserted++; existingList.Add(newItem); } else skipped++;
                    }
                }

                LoadData();
                MessageBox.Show($"Import hoàn tất. Thêm: {inserted}, Cập nhật: {updated}, Bỏ qua: {skipped}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // ================= EXPORT =================
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using var s = new SaveFileDialog { Filter = "Excel File|*.xlsx", FileName = $"ThuongHieu_{DateTime.Now:yyyyMMdd_HHmm}.xlsx" };
                if (s.ShowDialog() != DialogResult.OK) return;

                var list = (dgvThuongHieu.DataSource as List<ThuongHieu>) ?? _controller.GetAll();
                if (list == null || list.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất."); return; }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var p = new ExcelPackage();
                var ws = p.Workbook.Worksheets.Add("ThuongHieu");

                ws.Cells["A1"].Value = "MaThuongHieu";
                ws.Cells["B1"].Value = "TenThuongHieu";
                ws.Cells["C1"].Value = "QuocGia";

                using (var r = ws.Cells["A1:C1"])
                {
                    r.Style.Font.Bold = true;
                    r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    r.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                }

                int row = 2;
                foreach (var x in list)
                {
                    ws.Cells[row, 1].Value = x.MaThuongHieu;
                    ws.Cells[row, 2].Value = x.TenThuongHieu;
                    ws.Cells[row, 3].Value = x.QuocGia;
                    row++;
                }

                using (var r = ws.Cells[1, 1, row - 1, 3])
                {
                    r.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    r.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    r.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    r.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                }

                ws.Cells.AutoFitColumns();
                p.SaveAs(new FileInfo(s.FileName));
                MessageBox.Show("Xuất file thành công");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
