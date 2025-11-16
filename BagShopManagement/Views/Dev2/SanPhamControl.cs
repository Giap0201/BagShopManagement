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
            // Áp dụng theme GenZ Vibrant
            ApplyTheme();

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

        // ====== IMPORT ======
        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Chọn file Excel để import sản phẩm"
                };

                if (ofd.ShowDialog() != DialogResult.OK) return;

                if (MessageBox.Show("Bạn có chắc chắn muốn import danh sách sản phẩm?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using var package = new ExcelPackage(new FileInfo(ofd.FileName));
                var ws = package.Workbook.Worksheets.FirstOrDefault();
                if (ws == null)
                {
                    MessageBox.Show("Không tìm thấy sheet.", "Lỗi");
                    return;
                }

                // ====== XÁC ĐỊNH HEADER ======
                int headerRow = 1;
                if (ws.Cells[1, 1].Text.ToLower().Contains("danh sách sản phẩm"))
                    headerRow = 3;

                var headers = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                int lastCol = ws.Dimension.End.Column;

                for (int c = 1; c <= lastCol; c++)
                {
                    var name = ws.Cells[headerRow, c].Text.Trim();

                    switch (name.ToLower())
                    {
                        case "mã sp": case "masp": headers["MaSP"] = c; break;
                        case "tên sản phẩm": case "tensp": headers["TenSP"] = c; break;
                        case "giá nhập": case "gianhap": headers["GiaNhap"] = c; break;
                        case "giá bán": case "giaban": headers["GiaBan"] = c; break;
                        case "số lượng tồn": case "soluongton": headers["SoLuongTon"] = c; break;
                        case "mô tả": case "mota": headers["MoTa"] = c; break;
                        case "ảnh chính": case "anhchinh": headers["AnhChinh"] = c; break;
                        case "loại túi": case "maloaitui": headers["MaLoaiTui"] = c; break;
                        case "thương hiệu": case "mathuonghieu": headers["MaThuongHieu"] = c; break;
                        case "chất liệu": case "machatlieu": headers["MaChatLieu"] = c; break;
                        case "màu sắc": case "mamau": headers["MaMau"] = c; break;
                        case "kích thước": case "makichthuoc": headers["MaKichThuoc"] = c; break;
                        case "nhà cung cấp": case "mancc": headers["MaNCC"] = c; break;
                        case "trạng thái": case "trangthai": headers["TrangThai"] = c; break;
                        case "ngày tạo": case "ngaytao": headers["NgayTao"] = c; break;
                    }
                }

                if (!headers.ContainsKey("TenSP"))
                {
                    MessageBox.Show("Không tìm thấy cột Tên sản phẩm.", "Lỗi");
                    return;
                }

                var list = _controller.GetAll();
                int lastRow = ws.Dimension.End.Row;
                int inserted = 0, updated = 0, skipped = 0;

                // ====== ĐỌC DỮ LIỆU ======
                for (int r = headerRow + 1; r <= lastRow; r++)
                {
                    var ten = ws.Cells[r, headers["TenSP"]].Text?.Trim();
                    if (string.IsNullOrEmpty(ten)) { skipped++; continue; }

                    string maSP = headers.ContainsKey("MaSP") ? ws.Cells[r, headers["MaSP"]].Text?.Trim() : null;
                    var existing = list.FirstOrDefault(x => x.MaSP == maSP);

                    // ===== UPDATE =====
                    if (existing != null)
                    {
                        if (headers.ContainsKey("GiaNhap"))
                            existing.GiaNhap = decimal.TryParse(ws.Cells[r, headers["GiaNhap"]].Text, out var gn) ? gn : existing.GiaNhap;

                        if (headers.ContainsKey("GiaBan"))
                            existing.GiaBan = decimal.TryParse(ws.Cells[r, headers["GiaBan"]].Text, out var gb) ? gb : existing.GiaBan;

                        if (headers.ContainsKey("SoLuongTon"))
                            existing.SoLuongTon = int.TryParse(ws.Cells[r, headers["SoLuongTon"]].Text, out var sl) ? sl : existing.SoLuongTon;

                        if (headers.ContainsKey("MoTa"))
                            existing.MoTa = ws.Cells[r, headers["MoTa"]].Text;

                        _controller.Update(existing);
                        updated++;
                        continue;
                    }

                    // ===== INSERT =====
                    string newCode = _controller.GenerateNextCode();

                    var sp = new SanPham
                    {
                        MaSP = newCode,
                        TenSP = ten,
                        GiaNhap = headers.ContainsKey("GiaNhap") &&
                                  decimal.TryParse(ws.Cells[r, headers["GiaNhap"]].Text, out var gn2) ? gn2 : 0,

                        GiaBan = headers.ContainsKey("GiaBan") &&
                                 decimal.TryParse(ws.Cells[r, headers["GiaBan"]].Text, out var gb2) ? gb2 : 0,

                        SoLuongTon = headers.ContainsKey("SoLuongTon") &&
                                     int.TryParse(ws.Cells[r, headers["SoLuongTon"]].Text, out var sl2) ? sl2 : 0,

                        MoTa = headers.ContainsKey("MoTa") ? ws.Cells[r, headers["MoTa"]].Text : null,
                        AnhChinh = headers.ContainsKey("AnhChinh") ? ws.Cells[r, headers["AnhChinh"]].Text : null,
                        MaLoaiTui = headers.ContainsKey("MaLoaiTui") ? ws.Cells[r, headers["MaLoaiTui"]].Text : null,
                        MaThuongHieu = headers.ContainsKey("MaThuongHieu") ? ws.Cells[r, headers["MaThuongHieu"]].Text : null,
                        MaChatLieu = headers.ContainsKey("MaChatLieu") ? ws.Cells[r, headers["MaChatLieu"]].Text : null,
                        MaMau = headers.ContainsKey("MaMau") ? ws.Cells[r, headers["MaMau"]].Text : null,
                        MaKichThuoc = headers.ContainsKey("MaKichThuoc") ? ws.Cells[r, headers["MaKichThuoc"]].Text : null,
                        MaNCC = headers.ContainsKey("MaNCC") ? ws.Cells[r, headers["MaNCC"]].Text : null,
                        TrangThai = true,
                        NgayTao = DateTime.Now
                    };

                    if (_controller.Add(sp))
                    {
                        inserted++;
                        list.Add(sp);
                    }
                    else skipped++;
                }

                LoadData();

                MessageBox.Show(
                    $"Import hoàn tất.\nThêm mới: {inserted}\nCập nhật: {updated}\nBỏ qua: {skipped}",
                    "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi import: " + ex.Message);
            }
        }


        // ====== EXPORT ======
        private void BtnExport_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "Excel File|*.xlsx",
                FileName = $"DanhSachSanPham_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            var list = dgvSanPham.DataSource as List<SanPham>;
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            // ====== LOAD DANH MỤC ======
            var svc = _danhMucService; // dùng service có sẵn

            Dictionary<string, string> mapLoaiTui = svc.GetAll("DanhMucLoaiTui")
                .AsEnumerable()
                .ToDictionary(r => r["MaLoaiTui"].ToString(), r => r["TenLoaiTui"].ToString());

            Dictionary<string, string> mapThuongHieu = svc.GetAll("ThuongHieu")
                .AsEnumerable()
                .ToDictionary(r => r["MaThuongHieu"].ToString(), r => r["TenThuongHieu"].ToString());

            Dictionary<string, string> mapChatLieu = svc.GetAll("ChatLieu")
                .AsEnumerable()
                .ToDictionary(r => r["MaChatLieu"].ToString(), r => r["TenChatLieu"].ToString());

            Dictionary<string, string> mapMau = svc.GetAll("MauSac")
                .AsEnumerable()
                .ToDictionary(r => r["MaMau"].ToString(), r => r["TenMau"].ToString());

            Dictionary<string, string> mapKichThuoc = svc.GetAll("KichThuoc")
                .AsEnumerable()
                .ToDictionary(r => r["MaKichThuoc"].ToString(), r => r["TenKichThuoc"].ToString());

            Dictionary<string, string> mapNCC = svc.GetAll("NhaCungCap")
                .AsEnumerable()
                .ToDictionary(r => r["MaNCC"].ToString(), r => r["TenNCC"].ToString());

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Sản phẩm");

            // ===== TIÊU ĐỀ =====
            ws.Cells["A1"].Value = "DANH SÁCH SẢN PHẨM";
            ws.Cells["A1:O1"].Merge = true;
            ws.Cells["A1"].Style.Font.Size = 18;
            ws.Cells["A1"].Style.Font.Bold = true;
            ws.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            ws.Row(2).Height = 5;

            string[] headers =
            {
        "Mã SP", "Tên sản phẩm", "Giá nhập", "Giá bán", "Số lượng tồn",
        "Mô tả", "Ảnh chính", "Loại túi", "Thương hiệu", "Chất liệu",
        "Màu sắc", "Kích thước", "Nhà cung cấp", "Trạng thái", "Ngày tạo"
    };

            for (int i = 0; i < headers.Length; i++)
                ws.Cells[3, i + 1].Value = headers[i];

            using (var range = ws.Cells[3, 1, 3, headers.Length])
            {
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 12;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(220, 230, 241));
                range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            }

            // ===== DỮ LIỆU =====
            int row = 4;
            foreach (var x in list)
            {
                ws.Cells[row, 1].Value = x.MaSP;
                ws.Cells[row, 2].Value = x.TenSP;
                ws.Cells[row, 3].Value = x.GiaNhap;
                ws.Cells[row, 4].Value = x.GiaBan;
                ws.Cells[row, 5].Value = x.SoLuongTon;
                ws.Cells[row, 6].Value = x.MoTa;
                ws.Cells[row, 7].Value = x.AnhChinh;

                // ===== ÁNH XẠ DANH MỤC → TÊN =====
                ws.Cells[row, 8].Value = mapLoaiTui.TryGetValue(x.MaLoaiTui, out var tenLT) ? tenLT : x.MaLoaiTui;
                ws.Cells[row, 9].Value = mapThuongHieu.TryGetValue(x.MaThuongHieu, out var tenTH) ? tenTH : x.MaThuongHieu;
                ws.Cells[row, 10].Value = mapChatLieu.TryGetValue(x.MaChatLieu, out var tenCL) ? tenCL : x.MaChatLieu;
                ws.Cells[row, 11].Value = mapMau.TryGetValue(x.MaMau, out var tenM) ? tenM : x.MaMau;
                ws.Cells[row, 12].Value = mapKichThuoc.TryGetValue(x.MaKichThuoc, out var tenKT) ? tenKT : x.MaKichThuoc;
                ws.Cells[row, 13].Value = mapNCC.TryGetValue(x.MaNCC, out var tenNCC) ? tenNCC : x.MaNCC;

                ws.Cells[row, 14].Value = x.TrangThai ? "Đang bán" : "Ngừng bán";

                ws.Cells[row, 15].Value = x.NgayTao;
                ws.Cells[row, 15].Style.Numberformat.Format = "dd/MM/yyyy HH:mm";

                row++;
            }

            ws.Cells[3, 1, row - 1, headers.Length].AutoFitColumns();
            ws.View.FreezePanes(4, 1);

            p.SaveAs(new FileInfo(sfd.FileName));

            MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Áp dụng theme GenZ Vibrant cho UserControl
        /// </summary>
        private void ApplyTheme()
        {
            // Áp dụng màu nền
            this.BackColor = Utils.ThemeColors.Background;

            // Áp dụng theme cho DataGridView
            if (dgvSanPham != null)
            {
                Utils.ThemeHelper.ApplyThemeToDataGridView(dgvSanPham);
            }

            // Tìm và áp dụng theme cho các button
            ApplyThemeToButtons(this);

            // Áp dụng theme cho các GroupBox, Panel, TextBox, ComboBox
            ApplyThemeToControls(this);
        }

        private void ApplyThemeToButtons(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Button btn)
                {
                    // Phân loại button theo tên hoặc text
                    if (btn.Text.Contains("Thêm") || btn.Text.Contains("Lưu") || btn.Name.Contains("Add") || btn.Name.Contains("Save"))
                    {
                        Utils.ThemeHelper.ApplyPrimaryButtonStyle(btn);
                    }
                    else if (btn.Text.Contains("Sửa") || btn.Text.Contains("Cập nhật") || btn.Name.Contains("Edit") || btn.Name.Contains("Update"))
                    {
                        Utils.ThemeHelper.ApplySecondaryButtonStyle(btn);
                    }
                    else if (btn.Text.Contains("Xóa") || btn.Name.Contains("Delete") || btn.Name.Contains("Remove"))
                    {
                        Utils.ThemeHelper.ApplyErrorButtonStyle(btn);
                    }
                    else if (btn.Text.Contains("Xuất") || btn.Text.Contains("Export"))
                    {
                        Utils.ThemeHelper.ApplySuccessButtonStyle(btn);
                    }
                    else if (btn.Text.Contains("Làm mới") || btn.Text.Contains("Refresh") || btn.Text.Contains("Lọc"))
                    {
                        Utils.ThemeHelper.ApplyAccentButtonStyle(btn);
                    }
                    else
                    {
                        Utils.ThemeHelper.ApplySecondaryButtonStyle(btn);
                    }
                }
                else if (ctrl.HasChildren)
                {
                    ApplyThemeToButtons(ctrl);
                }
            }
        }

        private void ApplyThemeToControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is GroupBox gb)
                {
                    Utils.ThemeHelper.ApplyGroupBoxStyle(gb);
                }
                else if (ctrl is Panel panel && !(ctrl is DataGridView))
                {
                    panel.BackColor = Utils.ThemeColors.Card;
                }
                else if (ctrl is TextBox tb)
                {
                    Utils.ThemeHelper.ApplyTextBoxStyle(tb);
                }
                else if (ctrl is ComboBox cb)
                {
                    Utils.ThemeHelper.ApplyComboBoxStyle(cb);
                }
                else if (ctrl is Label lbl && lbl.Font.Size >= 12)
                {
                    lbl.ForeColor = Utils.ThemeColors.Primary;
                    lbl.Font = new Font("Segoe UI", lbl.Font.Size, FontStyle.Bold);
                }

                if (ctrl.HasChildren)
                {
                    ApplyThemeToControls(ctrl);
                }
            }
        }
    }
}
