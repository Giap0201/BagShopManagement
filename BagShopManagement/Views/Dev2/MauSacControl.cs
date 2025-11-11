using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
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
        private readonly IMauSacService _service;

        public MauSacControl()
        {
            InitializeComponent();

            _service = new MauSacService(new MauSacRepository());
            _controller = new MauSacController(_service);

            this.Load += MauSacControl_Load;
            txtSearch.TextChanged -= txtSearch_TextChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click -= btnEdit_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;
            //btnRefresh.Click -= btnRefresh_Click;
            //btnRefresh.Click += btnRefresh_Click;
            btnImport.Click -= BtnImport_Click;
            btnImport.Click += BtnImport_Click;
            btnExport.Click -= BtnExport_Click;
            btnExport.Click += BtnExport_Click;
            dgvMauSac.CellDoubleClick -= dgvMauSac_CellDoubleClick;
            dgvMauSac.CellDoubleClick += dgvMauSac_CellDoubleClick;
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
            if (string.IsNullOrEmpty(kw))
                LoadData();
            else
            {
                try
                {
                    dgvMauSac.DataSource = _controller.Search(kw);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var ctrl = new MauSacController(_service);
            using (var f = new MauSacEditForm(ctrl))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMauSac.CurrentRow == null) return;
            var model = dgvMauSac.CurrentRow.DataBoundItem as MauSac;
            if (model == null) return;

            var ctrl = new MauSacController(_service);
            using (var f = new MauSacEditForm(ctrl, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMauSac.CurrentRow == null) return;
            var model = dgvMauSac.CurrentRow.DataBoundItem as MauSac;
            if (model == null) return;

            if (MessageBox.Show($"Xóa màu '{model.TenMau}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var ok = _controller.Delete(model.MaMau);
                    if (ok) LoadData();
                    else MessageBox.Show("Xóa thất bại. Có thể bản ghi đang được tham chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void dgvMauSac_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var model = dgvMauSac.Rows[e.RowIndex].DataBoundItem as MauSac;
            if (model == null) return;

            var ctrl = new MauSacController(_service);
            using (var f = new MauSacEditForm(ctrl, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        // Import using EPPlus (template: TenMau header)
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Excel files (*.xlsx)|*.xlsx";
                    ofd.Title = "Chọn file Excel để import (TenMau)";
                    if (ofd.ShowDialog() != DialogResult.OK) return;

                    if (MessageBox.Show("Bạn có chắc chắn muốn import file này không?\nSau khi import sẽ thêm màu mới (bỏ qua trùng).", "Xác nhận Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    var file = ofd.FileName;
                    if (!File.Exists(file))
                    {
                        MessageBox.Show("File không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int inserted = 0, skipped = 0;
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var package = new ExcelPackage(stream))
                    {
                        var ws = package.Workbook.Worksheets.FirstOrDefault();
                        if (ws == null)
                        {
                            MessageBox.Show("File Excel không có sheet.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int startRow = 1;
                        int lastCol = ws.Dimension.End.Column;
                        int lastRow = ws.Dimension.End.Row;

                        int colTen = -1;
                        for (int c = 1; c <= lastCol; c++)
                        {
                            var h = (ws.Cells[startRow, c].Text ?? "").Trim();
                            if (string.Equals(h, "TenMau", StringComparison.OrdinalIgnoreCase)) colTen = c;
                        }

                        if (colTen == -1)
                        {
                            MessageBox.Show("Không tìm thấy cột 'TenMau' trong header (dòng 1).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var existingList = _controller.GetAll() ?? new List<MauSac>();

                        for (int r = startRow + 1; r <= lastRow; r++)
                        {
                            var ten = (ws.Cells[r, colTen].Text ?? "").Trim();
                            if (string.IsNullOrEmpty(ten))
                            {
                                skipped++;
                                continue;
                            }

                            var exists = existingList.Find(x => string.Equals(x.TenMau?.Trim(), ten, StringComparison.OrdinalIgnoreCase));
                            if (exists != null)
                            {
                                skipped++;
                                continue;
                            }

                            string nextCode = _controller.GenerateNextCode();
                            var newItem = new MauSac
                            {
                                MaMau = nextCode,
                                TenMau = ten
                            };

                            bool ok = _controller.Add(newItem);
                            if (ok)
                            {
                                inserted++;
                                existingList.Add(newItem);
                            }
                            else skipped++;
                        } // rows
                    } // package

                    LoadData();
                    MessageBox.Show($"Import hoàn tất. Thêm: {inserted}, Bỏ qua (trùng/empty): {skipped}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Export with EPPlus
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog s = new SaveFileDialog())
                {
                    s.Filter = "Excel File|*.xlsx";
                    s.FileName = $"MauSac_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                    if (s.ShowDialog() != DialogResult.OK) return;

                    var list = (dgvMauSac.DataSource as List<MauSac>) ?? _controller.GetAll();
                    if (list == null || list.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để xuất.");
                        return;
                    }

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var p = new ExcelPackage())
                    {
                        var ws = p.Workbook.Worksheets.Add("MauSac");

                        ws.Cells["A1"].Value = "MaMau";
                        ws.Cells["B1"].Value = "TenMau";

                        using (var r = ws.Cells["A1:B1"])
                        {
                            r.Style.Font.Bold = true;
                            r.Style.WrapText = true;
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
                    }

                    MessageBox.Show("Xuất file thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
