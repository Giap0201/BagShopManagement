using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
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
        private readonly IKichThuocService _service;

        public KichThuocControl()
        {
            InitializeComponent();

            _service = new KichThuocService(new KichThuocRepository());
            _controller = new KichThuocController(_service);

            this.Load += KichThuocControl_Load;
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
            dgvKichThuoc.CellDoubleClick -= dgvKichThuoc_CellDoubleClick;
            dgvKichThuoc.CellDoubleClick += dgvKichThuoc_CellDoubleClick;
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
            try { txtSearch.PlaceholderText = "Tìm kiếm"; } catch { }
        }

        private void LoadData()
        {
            try
            {
                dgvKichThuoc.DataSource = _controller.GetAll();
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
                    dgvKichThuoc.DataSource = _controller.Search(kw);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var ctrl = new KichThuocController(_service);
            using (var f = new KichThuocEditForm(ctrl))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvKichThuoc.CurrentRow == null) return;
            var model = dgvKichThuoc.CurrentRow.DataBoundItem as KichThuoc;
            if (model == null) return;

            var ctrl = new KichThuocController(_service);
            using (var f = new KichThuocEditForm(ctrl, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvKichThuoc.CurrentRow == null) return;
            var model = dgvKichThuoc.CurrentRow.DataBoundItem as KichThuoc;
            if (model == null) return;

            if (MessageBox.Show($"Xóa kích thước '{model.TenKichThuoc}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var ok = _controller.Delete(model.MaKichThuoc);
                    if (ok) LoadData();
                    else MessageBox.Show("Xóa thất bại. Có thể bản ghi đang được tham chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void dgvKichThuoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var model = dgvKichThuoc.Rows[e.RowIndex].DataBoundItem as KichThuoc;
            if (model == null) return;

            var ctrl = new KichThuocController(_service);
            using (var f = new KichThuocEditForm(ctrl, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        // Import using EPPlus (template A: TenKichThuoc, ChieuDai, ChieuRong, ChieuCao)
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Excel files (*.xlsx)|*.xlsx";
                    ofd.Title = "Chọn file Excel để import (TenKichThuoc, ChieuDai, ChieuRong, ChieuCao)";
                    if (ofd.ShowDialog() != DialogResult.OK) return;

                    if (MessageBox.Show("Bạn có chắc chắn muốn import file này không?\nSau khi import sẽ cập nhật dữ liệu danh mục.", "Xác nhận Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    var file = ofd.FileName;
                    if (!File.Exists(file))
                    {
                        MessageBox.Show("File không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int inserted = 0, updated = 0, skipped = 0;
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

                        int colTen = -1, colDai = -1, colRong = -1, colCao = -1;
                        for (int c = 1; c <= lastCol; c++)
                        {
                            var h = (ws.Cells[startRow, c].Text ?? "").Trim();
                            if (string.Equals(h, "TenKichThuoc", StringComparison.OrdinalIgnoreCase)) colTen = c;
                            if (string.Equals(h, "ChieuDai", StringComparison.OrdinalIgnoreCase)) colDai = c;
                            if (string.Equals(h, "ChieuRong", StringComparison.OrdinalIgnoreCase)) colRong = c;
                            if (string.Equals(h, "ChieuCao", StringComparison.OrdinalIgnoreCase)) colCao = c;
                        }

                        if (colTen == -1 || colDai == -1 || colRong == -1 || colCao == -1)
                        {
                            MessageBox.Show("Template sai. Yêu cầu header: TenKichThuoc, ChieuDai, ChieuRong, ChieuCao", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var existingList = _controller.GetAll() ?? new List<KichThuoc>();

                        for (int r = startRow + 1; r <= lastRow; r++)
                        {
                            var ten = (ws.Cells[r, colTen].Text ?? "").Trim();
                            if (string.IsNullOrEmpty(ten))
                            {
                                skipped++;
                                continue;
                            }

                            string daiTxt = (ws.Cells[r, colDai].Text ?? "").Trim();
                            string rongTxt = (ws.Cells[r, colRong].Text ?? "").Trim();
                            string caoTxt = (ws.Cells[r, colCao].Text ?? "").Trim();

                            // normalize decimal: accept both comma and dot
                            daiTxt = daiTxt.Replace(',', '.');
                            rongTxt = rongTxt.Replace(',', '.');
                            caoTxt = caoTxt.Replace(',', '.');

                            if (!decimal.TryParse(daiTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal dai) ||
                                !decimal.TryParse(rongTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal rong) ||
                                !decimal.TryParse(caoTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cao))
                            {
                                skipped++;
                                continue;
                            }

                            var existing = existingList.Find(x => string.Equals(x.TenKichThuoc?.Trim(), ten, StringComparison.OrdinalIgnoreCase));

                            if (existing != null)
                            {
                                existing.ChieuDai = dai;
                                existing.ChieuRong = rong;
                                existing.ChieuCao = cao;

                                bool ok = _controller.Update(existing);
                                if (ok) updated++; else skipped++;
                            }
                            else
                            {
                                string nextCode = _controller.GenerateNextCode();
                                var newItem = new KichThuoc
                                {
                                    MaKichThuoc = nextCode,
                                    TenKichThuoc = ten,
                                    ChieuDai = dai,
                                    ChieuRong = rong,
                                    ChieuCao = cao
                                };

                                bool ok = _controller.Add(newItem);
                                if (ok)
                                {
                                    inserted++;
                                    existingList.Add(newItem);
                                }
                                else skipped++;
                            }
                        } // rows
                    } // package

                    LoadData();
                    MessageBox.Show($"Import hoàn tất. Thêm: {inserted}, Cập nhật: {updated}, Bỏ qua: {skipped}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Export with style
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog s = new SaveFileDialog())
                {
                    s.Filter = "Excel File|*.xlsx";
                    s.FileName = $"KichThuoc_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                    if (s.ShowDialog() != DialogResult.OK) return;

                    var list = (dgvKichThuoc.DataSource as List<KichThuoc>) ?? _controller.GetAll();
                    if (list == null || list.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để xuất.");
                        return;
                    }

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var p = new ExcelPackage())
                    {
                        var ws = p.Workbook.Worksheets.Add("KichThuoc");

                        ws.Cells["A1"].Value = "MaKichThuoc";
                        ws.Cells["B1"].Value = "TenKichThuoc";
                        ws.Cells["C1"].Value = "ChieuDai";
                        ws.Cells["D1"].Value = "ChieuRong";
                        ws.Cells["E1"].Value = "ChieuCao";

                        using (var r = ws.Cells["A1:E1"])
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
                            ws.Cells[row, 1].Value = x.MaKichThuoc;
                            ws.Cells[row, 2].Value = x.TenKichThuoc;
                            ws.Cells[row, 3].Value = x.ChieuDai;
                            ws.Cells[row, 4].Value = x.ChieuRong;
                            ws.Cells[row, 5].Value = x.ChieuCao;
                            row++;
                        }

                        using (var r = ws.Cells[1, 1, row - 1, 5])
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
