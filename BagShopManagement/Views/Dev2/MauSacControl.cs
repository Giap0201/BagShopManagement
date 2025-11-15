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
        public MauSacControl(MauSacController controller)
        {
            InitializeComponent();
            _controller = controller;

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

        // ===== Import từ Excel =====
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Chọn file Excel để import màu sắc"
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
                if (ws.Cells[1, 1].Text.Trim().ToLower().Contains("màu"))
                    headerRow = 2;

                int lastCol = ws.Dimension.End.Column;
                int lastRow = ws.Dimension.End.Row;

                int colMa = -1, colTen = -1;
                for (int c = 1; c <= lastCol; c++)
                {
                    var h = ws.Cells[headerRow, c].Text?.Trim().ToLower();
                    switch (h)
                    {
                        case "mã màu":
                        case "mamau":
                            colMa = c;
                            break;
                        case "tên màu":
                        case "tenmau":
                            colTen = c;
                            break;
                    }
                }

                if (colTen == -1)
                {
                    MessageBox.Show("Không tìm thấy cột 'Tên màu'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existingList = _controller.GetAll() ?? new List<MauSac>();
                int inserted = 0, skipped = 0;

                for (int r = headerRow + 1; r <= lastRow; r++)
                {
                    string ten = ws.Cells[r, colTen].Text?.Trim();
                    if (string.IsNullOrEmpty(ten)) { skipped++; continue; }

                    MauSac existing = null;

                    // Ưu tiên tìm theo mã
                    if (colMa != -1)
                    {
                        string ma = ws.Cells[r, colMa].Text?.Trim();
                        if (!string.IsNullOrEmpty(ma))
                            existing = existingList.FirstOrDefault(x => string.Equals(x.MaMau, ma, StringComparison.OrdinalIgnoreCase));
                    }

                    // Nếu không có mã → tìm theo tên
                    if (existing == null)
                        existing = existingList.FirstOrDefault(x => string.Equals(x.TenMau?.Trim(), ten, StringComparison.OrdinalIgnoreCase));

                    if (existing != null)
                    {
                        existing.TenMau = ten;
                        if (_controller.Update(existing)) { inserted++; } else { skipped++; }
                    }
                    else
                    {
                        var newItem = new MauSac
                        {
                            MaMau = _controller.GenerateNextCode(),
                            TenMau = ten
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
                MessageBox.Show($"Import hoàn tất.\nThêm mới: {inserted}\nBỏ qua: {skipped}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    FileName = $"MauSac_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
                };
                if (sfd.ShowDialog() != DialogResult.OK) return;

                var list = (dgvMauSac.DataSource as List<MauSac>) ?? _controller.GetAll();
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var p = new ExcelPackage();
                var ws = p.Workbook.Worksheets.Add("Màu sắc");

                // ====== TIÊU ĐỀ LỚN ======
                ws.Cells["A1"].Value = "DANH MỤC MÀU SẮC";
                ws.Cells["A1"].Style.Font.Size = 18;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // ====== HEADER ======
                ws.Cells["A2"].Value = "Mã màu";
                ws.Cells["B2"].Value = "Tên màu";

                using (var r = ws.Cells["A2:B2"])
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
                    ws.Cells[row, 1].Value = x.MaMau;
                    ws.Cells[row, 2].Value = x.TenMau;
                    row++;
                }

                
                ws.Cells[1, 1, row - 1, 2].AutoFitColumns();
                ws.Cells["A1:B1"].Merge = true;
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
