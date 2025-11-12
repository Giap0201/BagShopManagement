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
    public partial class MauSacControl : UserControl
    {
        private readonly MauSacController _controller;

        // Inject service từ bên ngoài
        public MauSacControl(IMauSacService service)
        {
            InitializeComponent();
            _controller = new MauSacController(service);

            // Wire events an toàn
            this.Load += MauSacControl_Load;
        }

        private void MauSacControl_Load(object sender, EventArgs e)
        {
            if (dgvMauSac.Columns.Count == 0)
            {
                dgvMauSac.AutoGenerateColumns = false;
                dgvMauSac.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mã",
                    DataPropertyName = "MaMau",
                    Name = "MaMau",
                    ReadOnly = true,
                    Width = 120
                });
                dgvMauSac.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Tên màu",
                    DataPropertyName = "TenMau",
                    Name = "TenMau",
                    Width = 300
                });
            }

            LoadData();
            try { txtSearch.PlaceholderText = "Tìm kiếm"; } catch { }
        }

        private void LoadData()
        {
            try
            {
                dgvMauSac.DataSource = _controller.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var kw = txtSearch.Text?.Trim();
            dgvMauSac.DataSource = string.IsNullOrEmpty(kw) ? _controller.GetAll() : _controller.Search(kw);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new MauSacEditForm(_controller))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMauSac.CurrentRow?.DataBoundItem is not MauSac model) return;

            using (var f = new MauSacEditForm(_controller, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMauSac.CurrentRow?.DataBoundItem is not MauSac model) return;

            if (MessageBox.Show($"Xóa màu '{model.TenMau}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (_controller.Delete(model.MaMau))
                    LoadData();
                else
                    MessageBox.Show("Xóa thất bại. Có thể bản ghi đang được tham chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMauSac_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvMauSac.Rows[e.RowIndex].DataBoundItem is not MauSac model) return;

            using (var f = new MauSacEditForm(_controller, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        // ========== IMPORT ==========
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Chọn file Excel để import (TenMau)"
                };
                if (ofd.ShowDialog() != DialogResult.OK) return;

                if (MessageBox.Show("Bạn có chắc chắn muốn import file này không?\nSau khi import sẽ thêm màu mới (bỏ qua trùng).",
                    "Xác nhận Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                var file = ofd.FileName;
                if (!File.Exists(file))
                {
                    MessageBox.Show("File không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int inserted = 0, skipped = 0;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var package = new ExcelPackage(stream);
                var ws = package.Workbook.Worksheets.FirstOrDefault();
                if (ws == null) { MessageBox.Show("File Excel không có sheet.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                int colTen = -1, startRow = 1;
                for (int c = 1; c <= ws.Dimension.End.Column; c++)
                {
                    if (string.Equals((ws.Cells[startRow, c].Text ?? "").Trim(), "TenMau", StringComparison.OrdinalIgnoreCase))
                        colTen = c;
                }
                if (colTen == -1) { MessageBox.Show("Không tìm thấy cột 'TenMau'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                var existingList = _controller.GetAll() ?? new List<MauSac>();
                for (int r = startRow + 1; r <= ws.Dimension.End.Row; r++)
                {
                    var ten = (ws.Cells[r, colTen].Text ?? "").Trim();
                    if (string.IsNullOrEmpty(ten)) { skipped++; continue; }

                    if (existingList.Any(x => string.Equals(x.TenMau?.Trim(), ten, StringComparison.OrdinalIgnoreCase))) { skipped++; continue; }

                    var newItem = new MauSac { MaMau = _controller.GenerateNextCode(), TenMau = ten };
                    if (_controller.Add(newItem))
                    {
                        inserted++;
                        existingList.Add(newItem);
                    }
                    else skipped++;
                }

                LoadData();
                MessageBox.Show($"Import hoàn tất. Thêm: {inserted}, Bỏ qua: {skipped}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== EXPORT ==========
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using var s = new SaveFileDialog { Filter = "Excel File|*.xlsx", FileName = $"MauSac_{DateTime.Now:yyyyMMdd_HHmm}.xlsx" };
                if (s.ShowDialog() != DialogResult.OK) return;

                var list = (dgvMauSac.DataSource as List<MauSac>) ?? _controller.GetAll();
                if (list == null || list.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất."); return; }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var p = new ExcelPackage();
                var ws = p.Workbook.Worksheets.Add("MauSac");

                ws.Cells["A1"].Value = "MaMau";
                ws.Cells["B1"].Value = "TenMau";

                using (var r = ws.Cells["A1:B1"])
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
                    ws.Cells[row, 1].Value = x.MaMau;
                    ws.Cells[row, 2].Value = x.TenMau;
                    row++;
                }

                using (var r = ws.Cells[1, 1, row - 1, 2])
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
