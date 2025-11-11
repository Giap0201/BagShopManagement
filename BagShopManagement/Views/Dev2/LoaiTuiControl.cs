using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using System;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;

namespace BagShopManagement.Views.Dev2
{
    public partial class LoaiTuiControl : UserControl
    {
        private readonly LoaiTuiController _controller;
        private readonly ILoaiTuiService _service;

        public LoaiTuiControl()
        {
            InitializeComponent();

            _service = new LoaiTuiService(new LoaiTuiRepository());
            _controller = new LoaiTuiController(_service);

            // wire events (safe even if designer wired them)
            this.Load += LoaiTuiControl_Load;
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
            dgvLoaiTui.CellDoubleClick -= dgvLoaiTui_CellDoubleClick;
            dgvLoaiTui.CellDoubleClick += dgvLoaiTui_CellDoubleClick;
            btnImport.Click -= BtnImport_Click;
            btnImport.Click += BtnImport_Click;
            btnExport.Click -= btnExport_Click;
            btnExport.Click += btnExport_Click;
        }

        private void LoaiTuiControl_Load(object sender, EventArgs e)
        {
            // ensure columns if not created in designer
            if (dgvLoaiTui.Columns.Count == 0)
            {
                dgvLoaiTui.AutoGenerateColumns = false;
                dgvLoaiTui.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mã",
                    DataPropertyName = "MaLoaiTui",
                    Name = "MaLoaiTui",
                    ReadOnly = true,
                    Width = 120
                });
                dgvLoaiTui.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Tên",
                    DataPropertyName = "TenLoaiTui",
                    Name = "TenLoaiTui",
                    Width = 250
                });
                dgvLoaiTui.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mô tả",
                    DataPropertyName = "MoTa",
                    Name = "MoTa",
                    Width = 300
                });
            }

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvLoaiTui.DataSource = _controller.GetAll();
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
                    dgvLoaiTui.DataSource = _controller.Search(kw);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // open edit form in Add mode — use controller to get next code
            //var model = new DanhMucLoaiTui
            //{
            //    MaLoaiTui = _controller.GenerateNextCode()
            //};

            using (var f = new LoaiTuiEditForm(_controller))
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

            using (var f = new LoaiTuiEditForm(_controller, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
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
                    var ok = _controller.Delete(model.MaLoaiTui);
                    if (ok) LoadData();
                    else MessageBox.Show("Xóa thất bại. Bản ghi có thể đang được tham chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    LoadData();
        //}

        private void dgvLoaiTui_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var model = dgvLoaiTui.Rows[e.RowIndex].DataBoundItem as DanhMucLoaiTui;
            if (model == null) return;

            using (var f = new LoaiTuiEditForm(_controller, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        // === handler ===
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Excel files (*.xlsx)|*.xlsx";
                    ofd.Title = "Chọn file Excel để import (TenLoaiTui, MoTa)";
                    if (ofd.ShowDialog() != DialogResult.OK) return;

                    if (MessageBox.Show("Bạn có chắc chắn muốn import file này không?\nSau khi import sẽ cập nhật dữ liệu danh mục.",
                    "Xác nhận Import",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;

                    var file = ofd.FileName;
                    if (!File.Exists(file))
                    {
                        MessageBox.Show("File không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int inserted = 0, updated = 0, skipped = 0;
                    // ensure license context in Program.cs (ExcelPackage.LicenseContext = ...)

                    using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var package = new ExcelPackage(stream))
                    {
                        var ws = package.Workbook.Worksheets.FirstOrDefault();
                        if (ws == null)
                        {
                            MessageBox.Show("File Excel không có sheet.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // find header positions (case-insensitive)
                        int startRow = 1;
                        int lastCol = ws.Dimension.End.Column;
                        int lastRow = ws.Dimension.End.Row;

                        // map header names to columns
                        int colTen = -1, colMoTa = -1;
                        for (int c = 1; c <= lastCol; c++)
                        {
                            var h = (ws.Cells[startRow, c].Text ?? "").Trim();
                            if (string.Equals(h, "TenLoaiTui", StringComparison.OrdinalIgnoreCase)) colTen = c;
                            if (string.Equals(h, "MoTa", StringComparison.OrdinalIgnoreCase)) colMoTa = c;
                        }

                        if (colTen == -1)
                        {
                            MessageBox.Show("Không tìm thấy cột 'TenLoaiTui' trong header (dòng 1).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // load existing items once for duplicate detection
                        var existingList = _controller.GetAll() ?? new System.Collections.Generic.List<DanhMucLoaiTui>();

                        for (int r = startRow + 1; r <= lastRow; r++)
                        {
                            var ten = (ws.Cells[r, colTen].Text ?? "").Trim();
                            // skip empty row (no Ten)
                            if (string.IsNullOrEmpty(ten))
                            {
                                skipped++;
                                continue;
                            }

                            var motaCell = colMoTa != -1 ? (ws.Cells[r, colMoTa].Text ?? "").Trim() : null;

                            // find existing by Ten (case-insensitive exact)
                            var existing = existingList.Find(x => string.Equals(x.TenLoaiTui?.Trim(), ten, StringComparison.OrdinalIgnoreCase));

                            if (existing != null)
                            {
                                // update: update Ten (though same) and update MoTa only if excel provided (rule C)
                                if (!string.IsNullOrWhiteSpace(motaCell))
                                {
                                    existing.MoTa = motaCell;
                                }
                                // else keep existing.MoTa as is
                                // call controller.Update
                                bool ok = _controller.Update(existing);
                                if (ok) updated++;
                                else skipped++;
                            }
                            else
                            {
                                // insert new: generate next code from controller
                                string nextCode = _controller.GenerateNextCode();

                                var newItem = new DanhMucLoaiTui
                                {
                                    MaLoaiTui = nextCode,
                                    TenLoaiTui = ten,
                                    MoTa = string.IsNullOrWhiteSpace(motaCell) ? null : motaCell
                                };

                                bool ok = _controller.Add(newItem);
                                if (ok)
                                {
                                    inserted++;
                                    // update local cache so subsequent rows see newly added names
                                    existingList.Add(newItem);
                                }
                                else skipped++;
                            }
                        } // end rows
                    } // end package

                    // reload grid
                    LoadData();

                    MessageBox.Show($"Import hoàn tất. Thêm: {inserted}, Cập nhật: {updated}, Bỏ qua: {skipped}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog s = new SaveFileDialog())
            {
                s.Filter = "Excel File|*.xlsx";
                s.FileName = $"LoaiTui_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

                if (s.ShowDialog() != DialogResult.OK) return;

                var list = dgvLoaiTui.DataSource as List<DanhMucLoaiTui>;
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage p = new ExcelPackage())
                {
                    var ws = p.Workbook.Worksheets.Add("LoaiTui");

                    // header
                    ws.Cells["A1"].Value = "Mã Loại Túi";
                    ws.Cells["B1"].Value = "Tên Loại Túi";
                    ws.Cells["C1"].Value = "Mô Tả";

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
                        ws.Cells[row, 1].Value = x.MaLoaiTui;
                        ws.Cells[row, 2].Value = x.TenLoaiTui;
                        ws.Cells[row, 3].Value = x.MoTa;
                        row++;
                    }

                    // border all
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

    }
}
