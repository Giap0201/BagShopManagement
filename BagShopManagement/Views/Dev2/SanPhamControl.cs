using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class SanPhamControl : UserControl
    {
        private readonly SanPhamController _controller;
        private readonly IDanhMucService _danhMucService;
        private List<SanPham> _list;

        // ✅ Inject controller & service qua constructor (phù hợp DI)
        public SanPhamControl(SanPhamController controller, IDanhMucService danhMucService)
        {
            InitializeComponent();
            _controller = controller;
            _danhMucService = danhMucService;

            this.Load += SanPhamControl_Load;
            dgvSanPham.SelectionChanged += dgvSanPham_SelectionChanged;

            btnLoc.Click += BtnLoc_Click;
            btnRefresh.Click += BtnRefresh_Click;
        }

        private void SanPhamControl_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadAllDanhMucForFilter();
            picAnhChinh.SizeMode = PictureBoxSizeMode.Zoom;

            // Thiết lập combo Giá bán
            cboGiaBan.Items.Clear();
            cboGiaBan.Items.Add("<500k");
            cboGiaBan.Items.Add("500k–1000k");
            cboGiaBan.Items.Add(">1000k");
            cboGiaBan.SelectedIndex = -1;

            // Combo trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Đang kinh doanh");
            cboTrangThai.Items.Add("Ngừng kinh doanh");
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadAllDanhMucForFilter()
        {
            LoadDanhMuc(cboLoaiTui, "DanhMucLoaiTui", "MaLoaiTui", "TenLoaiTui");
            LoadDanhMuc(cboThuongHieu, "ThuongHieu", "MaThuongHieu", "TenThuongHieu");
            LoadDanhMuc(cboChatLieu, "ChatLieu", "MaChatLieu", "TenChatLieu");
            LoadDanhMuc(cboMau, "MauSac", "MaMau", "TenMau");
            LoadDanhMuc(cboKichThuoc, "KichThuoc", "MaKichThuoc", "TenKichThuoc");
            LoadDanhMuc(cboNCC, "NhaCungCap", "MaNCC", "TenNCC");
        }

        private void LoadDanhMuc(ComboBox cbo, string table, string valueField, string displayField)
        {
            try
            {
                var dt = _danhMucService.GetAll(table);
                cbo.DataSource = dt;
                cbo.ValueMember = valueField;
                cbo.DisplayMember = displayField;
                cbo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải {table}: {ex.Message}");
            }
        }

        private void LoadData()
        {
            _list = _controller.GetAll();

            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.Columns.Clear();

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSP",
                HeaderText = "Mã sản phẩm",
                Name = "MaSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSP",
                HeaderText = "Tên sản phẩm",
                Name = "TenSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GiaNhap",
                HeaderText = "Giá nhập",
                Name = "GiaNhap",
                DefaultCellStyle = { Format = "N0" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GiaBan",
                HeaderText = "Giá bán",
                Name = "GiaBan",
                DefaultCellStyle = { Format = "N0" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongTon",
                HeaderText = "Số lượng tồn",
                Name = "SoLuongTon",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MoTa",
                HeaderText = "Mô tả",
                Name = "MoTa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AnhChinh",
                HeaderText = "Ảnh chính",
                Name = "AnhChinh",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvSanPham.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Đang kinh doanh",
                Name = "TrangThai",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvSanPham.DataSource = _list;
        }

        // ================= LỌC NÂNG CAO =================
        private void BtnLoc_Click(object sender, EventArgs e)
        {
            if (_list == null) return;

            var filtered = _list.AsEnumerable();

            if (cboGiaBan.SelectedIndex >= 0)
            {
                switch (cboGiaBan.SelectedItem.ToString())
                {
                    case "<500k": filtered = filtered.Where(x => x.GiaBan < 500000); break;
                    case "500k–1000k": filtered = filtered.Where(x => x.GiaBan >= 500000 && x.GiaBan <= 1000000); break;
                    case ">1000k": filtered = filtered.Where(x => x.GiaBan > 1000000); break;
                }
            }

            if (cboLoaiTui.SelectedIndex >= 0)
                filtered = filtered.Where(x => x.MaLoaiTui == cboLoaiTui.SelectedValue?.ToString());
            if (cboThuongHieu.SelectedIndex >= 0)
                filtered = filtered.Where(x => x.MaThuongHieu == cboThuongHieu.SelectedValue?.ToString());
            if (cboChatLieu.SelectedIndex >= 0)
                filtered = filtered.Where(x => x.MaChatLieu == cboChatLieu.SelectedValue?.ToString());
            if (cboMau.SelectedIndex >= 0)
                filtered = filtered.Where(x => x.MaMau == cboMau.SelectedValue?.ToString());
            if (cboKichThuoc.SelectedIndex >= 0)
                filtered = filtered.Where(x => x.MaKichThuoc == cboKichThuoc.SelectedValue?.ToString());
            if (cboNCC.SelectedIndex >= 0)
                filtered = filtered.Where(x => x.MaNCC == cboNCC.SelectedValue?.ToString());
            if (cboTrangThai.SelectedIndex > 0)
            {
                bool trangThai = cboTrangThai.SelectedIndex == 1;
                filtered = filtered.Where(x => x.TrangThai == trangThai);
            }

            dgvSanPham.DataSource = filtered.ToList();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            cboGiaBan.SelectedIndex = -1;
            cboLoaiTui.SelectedIndex = -1;
            cboThuongHieu.SelectedIndex = -1;
            cboChatLieu.SelectedIndex = -1;
            cboMau.SelectedIndex = -1;
            cboKichThuoc.SelectedIndex = -1;
            cboNCC.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0;
            txtSearch.Clear();
            dgvSanPham.DataSource = _list;
        }

        // ================= CRUD & IMPORT/EXPORT giữ nguyên =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new SanPhamEditForm(_controller))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            var ma = dgvSanPham.CurrentRow.Cells["MaSP"].Value?.ToString();
            var sp = _controller.GetAll().Find(x => x.MaSP == ma);
            if (sp == null) return;

            using (var f = new SanPhamEditForm(_controller, sp))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            var ma = dgvSanPham.CurrentRow.Cells["MaSP"].Value?.ToString();
            if (string.IsNullOrEmpty(ma)) return;

            if (MessageBox.Show($"Xóa sản phẩm {ma}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _controller.Delete(ma);
                LoadData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            dgvSanPham.DataSource = string.IsNullOrEmpty(kw) ? _list : _controller.Search(kw);
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var sp = dgvSanPham.Rows[e.RowIndex].DataBoundItem as SanPham;
            if (sp == null) return;

            using (var f = new SanPhamDetailForm(sp))
                f.ShowDialog();
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                picAnhChinh.Image = Properties.Resources.no_image;
                picAnhChinh.SizeMode = PictureBoxSizeMode.Zoom;
                return;
            }

            try
            {
                var anhChinh = dgvSanPham.CurrentRow.Cells["AnhChinh"].Value?.ToString();
                if (string.IsNullOrEmpty(anhChinh))
                {
                    picAnhChinh.Image = Properties.Resources.no_image;
                    picAnhChinh.SizeMode = PictureBoxSizeMode.Zoom;
                    return;
                }

                string path = Path.Combine(Application.StartupPath, "Resources", "AnhSanPham", anhChinh);
                if (!File.Exists(path))
                {
                    picAnhChinh.Image = Properties.Resources.no_image;
                    picAnhChinh.SizeMode = PictureBoxSizeMode.Zoom;
                    return;
                }

                picAnhChinh?.Image?.Dispose();
                using (var bmpTemp = new Bitmap(path))
                    picAnhChinh.Image = new Bitmap(bmpTemp);

                picAnhChinh.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                picAnhChinh.Image = Properties.Resources.no_image;
                picAnhChinh.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // ================= IMPORT =================
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Excel files (*.xlsx)|*.xlsx";
                    ofd.Title = "Chọn file Excel để import sản phẩm";
                    if (ofd.ShowDialog() != DialogResult.OK) return;

                    if (MessageBox.Show("Bạn có chắc chắn muốn import danh sách sản phẩm từ file này không?",
                        "Xác nhận Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                    string file = ofd.FileName;
                    if (!File.Exists(file))
                    {
                        MessageBox.Show("File không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    int inserted = 0, updated = 0, skipped = 0;

                    using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var package = new ExcelPackage(stream))
                    {
                        var ws = package.Workbook.Worksheets.FirstOrDefault();
                        if (ws == null)
                        {
                            MessageBox.Show("Không tìm thấy sheet trong file Excel.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int startRow = 1;
                        int lastRow = ws.Dimension.End.Row;

                        var headers = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                        for (int c = 1; c <= ws.Dimension.End.Column; c++)
                        {
                            var h = (ws.Cells[startRow, c].Text ?? "").Trim();
                            if (!string.IsNullOrEmpty(h)) headers[h] = c;
                        }

                        if (!headers.ContainsKey("TenSP"))
                        {
                            MessageBox.Show("Thiếu cột 'TenSP' trong file.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var existingList = _controller.GetAll();

                        for (int r = startRow + 1; r <= lastRow; r++)
                        {
                            string tenSP = ws.Cells[r, headers["TenSP"]].Text?.Trim();
                            if (string.IsNullOrEmpty(tenSP)) { skipped++; continue; }

                            string maSP = headers.ContainsKey("MaSP") ? ws.Cells[r, headers["MaSP"]].Text?.Trim() : null;
                            var existing = existingList?.FirstOrDefault(x => x.MaSP == maSP);

                            if (existing != null)
                            {
                                existing.GiaNhap = decimal.TryParse(ws.Cells[r, headers.GetValueOrDefault("GiaNhap", -1)]?.Text, out var gn) ? gn : existing.GiaNhap;
                                existing.GiaBan = decimal.TryParse(ws.Cells[r, headers.GetValueOrDefault("GiaBan", -1)]?.Text, out var gb) ? gb : existing.GiaBan;
                                existing.SoLuongTon = int.TryParse(ws.Cells[r, headers.GetValueOrDefault("SoLuongTon", -1)]?.Text, out var sl) ? sl : existing.SoLuongTon;
                                existing.MoTa = ws.Cells[r, headers.GetValueOrDefault("MoTa", -1)]?.Text ?? existing.MoTa;

                                if (_controller.Update(existing)) updated++; else skipped++;
                            }
                            else
                            {
                                string newCode = _controller.GenerateNextCode();

                                var sp = new SanPham
                                {
                                    MaSP = newCode,
                                    TenSP = tenSP,
                                    GiaNhap = decimal.TryParse(ws.Cells[r, headers.GetValueOrDefault("GiaNhap", -1)]?.Text, out var gn) ? gn : 0,
                                    GiaBan = decimal.TryParse(ws.Cells[r, headers.GetValueOrDefault("GiaBan", -1)]?.Text, out var gb) ? gb : 0,
                                    SoLuongTon = int.TryParse(ws.Cells[r, headers.GetValueOrDefault("SoLuongTon", -1)]?.Text, out var sl) ? sl : 0,
                                    MoTa = ws.Cells[r, headers.GetValueOrDefault("MoTa", -1)]?.Text,
                                    AnhChinh = ws.Cells[r, headers.GetValueOrDefault("AnhChinh", -1)]?.Text,
                                    MaLoaiTui = ws.Cells[r, headers.GetValueOrDefault("MaLoaiTui", -1)]?.Text,
                                    MaThuongHieu = ws.Cells[r, headers.GetValueOrDefault("MaThuongHieu", -1)]?.Text,
                                    MaChatLieu = ws.Cells[r, headers.GetValueOrDefault("MaChatLieu", -1)]?.Text,
                                    MaMau = ws.Cells[r, headers.GetValueOrDefault("MaMau", -1)]?.Text,
                                    MaKichThuoc = ws.Cells[r, headers.GetValueOrDefault("MaKichThuoc", -1)]?.Text,
                                    MaNCC = ws.Cells[r, headers.GetValueOrDefault("MaNCC", -1)]?.Text,
                                    TrangThai = true,
                                    NgayTao = DateTime.Now
                                };

                                if (_controller.Add(sp)) { inserted++; existingList.Add(sp); } else skipped++;
                            }
                        }
                    }

                    LoadData();
                    MessageBox.Show($"Import hoàn tất.\nThêm: {inserted}, Cập nhật: {updated}, Bỏ qua: {skipped}",
                        "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= EXPORT =================
        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel File|*.xlsx";
                sfd.FileName = $"SanPham_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                var list = dgvSanPham.DataSource as List<SanPham>;
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var p = new ExcelPackage())
                {
                    var ws = p.Workbook.Worksheets.Add("SanPham");
                    string[] headers = { "MaSP", "TenSP", "GiaNhap", "GiaBan", "SoLuongTon", "MoTa", "AnhChinh", "MaLoaiTui", "MaThuongHieu", "MaChatLieu", "MaMau", "MaKichThuoc", "MaNCC", "TrangThai", "NgayTao" };

                    for (int i = 0; i < headers.Length; i++)
                        ws.Cells[1, i + 1].Value = headers[i];

                    int row = 2;
                    foreach (var x in list)
                    {
                        ws.Cells[row, 1].Value = x.MaSP;
                        ws.Cells[row, 2].Value = x.TenSP;
                        ws.Cells[row, 3].Value = x.GiaNhap;
                        ws.Cells[row, 4].Value = x.GiaBan;
                        ws.Cells[row, 5].Value = x.SoLuongTon;
                        ws.Cells[row, 6].Value = x.MoTa;
                        ws.Cells[row, 7].Value = x.AnhChinh;
                        ws.Cells[row, 8].Value = x.MaLoaiTui;
                        ws.Cells[row, 9].Value = x.MaThuongHieu;
                        ws.Cells[row, 10].Value = x.MaChatLieu;
                        ws.Cells[row, 11].Value = x.MaMau;
                        ws.Cells[row, 12].Value = x.MaKichThuoc;
                        ws.Cells[row, 13].Value = x.MaNCC;
                        ws.Cells[row, 14].Value = x.TrangThai;
                        ws.Cells[row, 15].Value = x.NgayTao;
                        row++;
                    }

                    ws.Cells.AutoFitColumns();
                    p.SaveAs(new FileInfo(sfd.FileName));
                }

                MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}
