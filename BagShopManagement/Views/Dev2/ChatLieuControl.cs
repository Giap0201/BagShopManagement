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
    public partial class ChatLieuControl : UserControl
    {
        private readonly ChatLieuController _controller;
        private readonly IChatLieuService _service;

        public ChatLieuControl()
        {
            InitializeComponent();

            _service = new ChatLieuService(new ChatLieuRepository());
            _controller = new ChatLieuController(_service);

            // wire events safe
            this.Load += ChatLieuControl_Load;
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
            dgvChatLieu.CellDoubleClick -= dgvChatLieu_CellDoubleClick;
            dgvChatLieu.CellDoubleClick += dgvChatLieu_CellDoubleClick;
        }

        private void ChatLieuControl_Load(object sender, EventArgs e)
        {
            if (dgvChatLieu.Columns.Count == 0)
            {
                dgvChatLieu.AutoGenerateColumns = false;
                dgvChatLieu.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mã",
                    DataPropertyName = "MaChatLieu",
                    Name = "MaChatLieu",
                    ReadOnly = true,
                    Width = 120
                });
                dgvChatLieu.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Tên",
                    DataPropertyName = "TenChatLieu",
                    Name = "TenChatLieu",
                    Width = 250
                });
                dgvChatLieu.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mô tả",
                    DataPropertyName = "MoTa",
                    Name = "MoTa",
                    Width = 300
                });
            }

            LoadData();
            // placeholder (if .NET supports)
            try { txtSearch.PlaceholderText = "Tìm kiếm"; } catch { }
        }

        private void LoadData()
        {
            try
            {
                dgvChatLieu.DataSource = _controller.GetAll();
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
                    dgvChatLieu.DataSource = _controller.Search(kw);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // create controller from existing service and open form
            var ctrl = new ChatLieuController(_service);
            using (var f = new ChatLieuEditForm(ctrl))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvChatLieu.CurrentRow == null) return;
            var model = dgvChatLieu.CurrentRow.DataBoundItem as ChatLieu;
            if (model == null) return;

            var ctrl = new ChatLieuController(_service);
            using (var f = new ChatLieuEditForm(ctrl, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvChatLieu.CurrentRow == null) return;
            var model = dgvChatLieu.CurrentRow.DataBoundItem as ChatLieu;
            if (model == null) return;

            if (MessageBox.Show($"Xóa chất liệu '{model.TenChatLieu}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var ok = _controller.Delete(model.MaChatLieu);
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

        private void dgvChatLieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var model = dgvChatLieu.Rows[e.RowIndex].DataBoundItem as ChatLieu;
            if (model == null) return;

            var ctrl = new ChatLieuController(_service);
            using (var f = new ChatLieuEditForm(ctrl, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        // --------- Import using EPPlus (template B: TenChatLieu, MoTa; duplicate by TenChatLieu; update MoTa only if provided)
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Excel files (*.xlsx)|*.xlsx";
                    ofd.Title = "Chọn file Excel để import (TenChatLieu, MoTa)";
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

                        int colTen = -1, colMoTa = -1;
                        for (int c = 1; c <= lastCol; c++)
                        {
                            var h = (ws.Cells[startRow, c].Text ?? "").Trim();
                            if (string.Equals(h, "TenChatLieu", StringComparison.OrdinalIgnoreCase)) colTen = c;
                            if (string.Equals(h, "MoTa", StringComparison.OrdinalIgnoreCase)) colMoTa = c;
                        }

                        if (colTen == -1)
                        {
                            MessageBox.Show("Không tìm thấy cột 'TenChatLieu' trong header (dòng 1).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var existingList = _controller.GetAll() ?? new List<ChatLieu>();

                        for (int r = startRow + 1; r <= lastRow; r++)
                        {
                            var ten = (ws.Cells[r, colTen].Text ?? "").Trim();
                            if (string.IsNullOrEmpty(ten))
                            {
                                skipped++;
                                continue;
                            }

                            var motaCell = colMoTa != -1 ? (ws.Cells[r, colMoTa].Text ?? "").Trim() : null;

                            var existing = existingList.Find(x => string.Equals(x.TenChatLieu?.Trim(), ten, StringComparison.OrdinalIgnoreCase));

                            if (existing != null)
                            {
                                // update MoTa only if excel provided (rule C)
                                if (!string.IsNullOrWhiteSpace(motaCell))
                                    existing.MoTa = motaCell;

                                bool ok = _controller.Update(existing);
                                if (ok) updated++; else skipped++;
                            }
                            else
                            {
                                string nextCode = _controller.GenerateNextCode();
                                var newItem = new ChatLieu
                                {
                                    MaChatLieu = nextCode,
                                    TenChatLieu = ten,
                                    MoTa = string.IsNullOrWhiteSpace(motaCell) ? null : motaCell
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

        // --------- Export with styling (EPPlus)
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog s = new SaveFileDialog())
                {
                    s.Filter = "Excel File|*.xlsx";
                    s.FileName = $"ChatLieu_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                    if (s.ShowDialog() != DialogResult.OK) return;

                    var list = (dgvChatLieu.DataSource as List<ChatLieu>) ?? _controller.GetAll();
                    if (list == null || list.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để xuất.");
                        return;
                    }

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var p = new ExcelPackage())
                    {
                        var ws = p.Workbook.Worksheets.Add("ChatLieu");

                        ws.Cells["A1"].Value = "MaChatLieu";
                        ws.Cells["B1"].Value = "TenChatLieu";
                        ws.Cells["C1"].Value = "MoTa";

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
                            ws.Cells[row, 1].Value = x.MaChatLieu;
                            ws.Cells[row, 2].Value = x.TenChatLieu;
                            ws.Cells[row, 3].Value = x.MoTa;
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
