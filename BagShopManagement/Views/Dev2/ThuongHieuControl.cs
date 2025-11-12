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
    public partial class ThuongHieuControl : UserControl
    {
        private readonly ThuongHieuController _controller;
        private readonly IThuongHieuService _service;

        public ThuongHieuControl()
        {
            InitializeComponent();

            _service = new ThuongHieuService(new ThuongHieuRepository());
            _controller = new ThuongHieuController(_service);

            // wire events
            this.Load += ThuongHieuControl_Load;
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
            dgvThuongHieu.CellDoubleClick -= dgvThuongHieu_CellDoubleClick;
            dgvThuongHieu.CellDoubleClick += dgvThuongHieu_CellDoubleClick;
        }

        private void ThuongHieuControl_Load(object sender, EventArgs e)
        {
            if (dgvThuongHieu.Columns.Count == 0)
            {
                dgvThuongHieu.AutoGenerateColumns = false;
                dgvThuongHieu.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mã",
                    DataPropertyName = "MaThuongHieu",
                    Name = "MaThuongHieu",
                    ReadOnly = true,
                    Width = 120
                });
                dgvThuongHieu.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Tên",
                    DataPropertyName = "TenThuongHieu",
                    Name = "TenThuongHieu",
                    Width = 250
                });
                dgvThuongHieu.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Quốc gia",
                    DataPropertyName = "QuocGia",
                    Name = "QuocGia",
                    Width = 200
                });
            }

            LoadData();
            try { txtSearch.PlaceholderText = "Tìm kiếm"; } catch { }
        }

        private void LoadData()
        {
            try
            {
                dgvThuongHieu.DataSource = _controller.GetAll();
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
                    dgvThuongHieu.DataSource = _controller.Search(kw);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var ctrl = new ThuongHieuController(_service);
            using (var f = new ThuongHieuEditForm(ctrl))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvThuongHieu.CurrentRow == null) return;
            var model = dgvThuongHieu.CurrentRow.DataBoundItem as ThuongHieu;
            if (model == null) return;

            var ctrl = new ThuongHieuController(_service);
            using (var f = new ThuongHieuEditForm(ctrl, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvThuongHieu.CurrentRow == null) return;
            var model = dgvThuongHieu.CurrentRow.DataBoundItem as ThuongHieu;
            if (model == null) return;

            if (MessageBox.Show($"Xóa thương hiệu '{model.TenThuongHieu}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var ok = _controller.Delete(model.MaThuongHieu);
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

        private void dgvThuongHieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var model = dgvThuongHieu.Rows[e.RowIndex].DataBoundItem as ThuongHieu;
            if (model == null) return;

            var ctrl = new ThuongHieuController(_service);
            using (var f = new ThuongHieuEditForm(ctrl, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        // Import using EPPlus (template B: TenThuongHieu, QuocGia; duplicate by TenThuongHieu)
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Excel files (*.xlsx)|*.xlsx";
                    ofd.Title = "Chọn file Excel để import (TenThuongHieu, QuocGia)";
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

                        int colTen = -1, colQuocGia = -1;
                        for (int c = 1; c <= lastCol; c++)
                        {
                            var h = (ws.Cells[startRow, c].Text ?? "").Trim();
                            if (string.Equals(h, "TenThuongHieu", StringComparison.OrdinalIgnoreCase)) colTen = c;
                            if (string.Equals(h, "QuocGia", StringComparison.OrdinalIgnoreCase)) colQuocGia = c;
                        }

                        if (colTen == -1)
                        {
                            MessageBox.Show("Không tìm thấy cột 'TenThuongHieu' trong header (dòng 1).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var existingList = _controller.GetAll() ?? new List<ThuongHieu>();

                        for (int r = startRow + 1; r <= lastRow; r++)
                        {
                            var ten = (ws.Cells[r, colTen].Text ?? "").Trim();
                            if (string.IsNullOrEmpty(ten))
                            {
                                skipped++;
                                continue;
                            }

                            var qgCell = colQuocGia != -1 ? (ws.Cells[r, colQuocGia].Text ?? "").Trim() : null;
                            string quocGiaValue = string.IsNullOrWhiteSpace(qgCell) ? null : qgCell;

                            var existing = existingList.Find(x => string.Equals(x.TenThuongHieu?.Trim(), ten, StringComparison.OrdinalIgnoreCase));

                            if (existing != null)
                            {
                                // update QuocGia only if excel provided
                                if (!string.IsNullOrWhiteSpace(qgCell))
                                    existing.QuocGia = quocGiaValue;

                                bool ok = _controller.Update(existing);
                                if (ok) updated++; else skipped++;
                            }
                            else
                            {
                                string nextCode = _controller.GenerateNextCode();
                                var newItem = new ThuongHieu
                                {
                                    MaThuongHieu = nextCode,
                                    TenThuongHieu = ten,
                                    QuocGia = quocGiaValue
                                };

                                bool ok = _controller.Add(newItem);
                                if (ok)
                                {
                                    inserted++;
                                    existingList.Add(newItem);
                                }
                                else skipped++;
                            }
                        }
                    }

                    LoadData();
                    MessageBox.Show($"Import hoàn tất. Thêm: {inserted}, Cập nhật: {updated}, Bỏ qua: {skipped}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Export with EPPlus styled
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog s = new SaveFileDialog())
                {
                    s.Filter = "Excel File|*.xlsx";
                    s.FileName = $"ThuongHieu_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                    if (s.ShowDialog() != DialogResult.OK) return;

                    var list = (dgvThuongHieu.DataSource as List<ThuongHieu>) ?? _controller.GetAll();
                    if (list == null || list.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để xuất.");
                        return;
                    }

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var p = new ExcelPackage())
                    {
                        var ws = p.Workbook.Worksheets.Add("ThuongHieu");

                        ws.Cells["A1"].Value = "MaThuongHieu";
                        ws.Cells["B1"].Value = "TenThuongHieu";
                        ws.Cells["C1"].Value = "QuocGia";

                        using (var r = ws.Cells["A1:C1"])
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
