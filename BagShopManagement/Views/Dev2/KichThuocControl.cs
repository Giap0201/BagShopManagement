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
                dgvKichThuoc.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mã",
                    DataPropertyName = "MaKichThuoc",
                    Name = "MaKichThuoc",
                    ReadOnly = true,
                    Width = 100
                });
                dgvKichThuoc.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Tên",
                    DataPropertyName = "TenKichThuoc",
                    Name = "TenKichThuoc",
                    Width = 180
                });
                dgvKichThuoc.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Dài",
                    DataPropertyName = "ChieuDai",
                    Name = "ChieuDai",
                    Width = 80
                });
                dgvKichThuoc.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Rộng",
                    DataPropertyName = "ChieuRong",
                    Name = "ChieuRong",
                    Width = 80
                });
                dgvKichThuoc.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Cao",
                    DataPropertyName = "ChieuCao",
                    Name = "ChieuCao",
                    Width = 80
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

        // ===== Import =====
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Chọn file Excel để import (TenKichThuoc, ChieuDai, ChieuRong, ChieuCao)"
                };

                if (ofd.ShowDialog() != DialogResult.OK) return;

                if (MessageBox.Show("Bạn có chắc chắn muốn import file này không?\nDữ liệu sẽ được cập nhật.",
                    "Xác nhận Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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

                int colTen = -1, colDai = -1, colRong = -1, colCao = -1;
                int lastCol = ws.Dimension.End.Column;
                for (int c = 1; c <= lastCol; c++)
                {
                    var h = ws.Cells[1, c].Text?.Trim();
                    if (string.Equals(h, "TenKichThuoc", StringComparison.OrdinalIgnoreCase)) colTen = c;
                    if (string.Equals(h, "ChieuDai", StringComparison.OrdinalIgnoreCase)) colDai = c;
                    if (string.Equals(h, "ChieuRong", StringComparison.OrdinalIgnoreCase)) colRong = c;
                    if (string.Equals(h, "ChieuCao", StringComparison.OrdinalIgnoreCase)) colCao = c;
                }

                if (colTen == -1 || colDai == -1 || colRong == -1 || colCao == -1)
                {
                    MessageBox.Show("Template sai. Yêu cầu header: TenKichThuoc, ChieuDai, ChieuRong, ChieuCao",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existingList = _controller.GetAll() ?? new List<KichThuoc>();
                int lastRow = ws.Dimension.End.Row;

                for (int r = 2; r <= lastRow; r++)
                {
                    var ten = ws.Cells[r, colTen].Text?.Trim();
                    if (string.IsNullOrEmpty(ten))
                    {
                        skipped++;
                        continue;
                    }

                    string daiTxt = (ws.Cells[r, colDai].Text ?? "").Trim().Replace(',', '.');
                    string rongTxt = (ws.Cells[r, colRong].Text ?? "").Trim().Replace(',', '.');
                    string caoTxt = (ws.Cells[r, colCao].Text ?? "").Trim().Replace(',', '.');

                    if (!decimal.TryParse(daiTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal dai) ||
                        !decimal.TryParse(rongTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal rong) ||
                        !decimal.TryParse(caoTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cao))
                    {
                        skipped++;
                        continue;
                    }

                    var existing = existingList.FirstOrDefault(x =>
                        string.Equals(x.TenKichThuoc?.Trim(), ten, StringComparison.OrdinalIgnoreCase));

                    if (existing != null)
                    {
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

        // ===== Export =====
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
                var ws = p.Workbook.Worksheets.Add("KichThuoc");

                ws.Cells["A1"].Value = "MaKichThuoc";
                ws.Cells["B1"].Value = "TenKichThuoc";
                ws.Cells["C1"].Value = "ChieuDai";
                ws.Cells["D1"].Value = "ChieuRong";
                ws.Cells["E1"].Value = "ChieuCao";

                using (var r = ws.Cells["A1:E1"])
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
                    ws.Cells[row, 1].Value = x.MaKichThuoc;
                    ws.Cells[row, 2].Value = x.TenKichThuoc;
                    ws.Cells[row, 3].Value = x.ChieuDai;
                    ws.Cells[row, 4].Value = x.ChieuRong;
                    ws.Cells[row, 5].Value = x.ChieuCao;
                    row++;
                }

                ws.Cells.AutoFitColumns();
                p.SaveAs(new FileInfo(sfd.FileName));

                MessageBox.Show("Xuất file thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
