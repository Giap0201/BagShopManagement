using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models.Enums;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace BagShopManagement.Views.Dev6
{
    public partial class ucThemHDN : UserControl
    {
        private MaHoaDonGenerator _maHoaDonGenerator;
        private INhaCungCapRepository _nhaCungCapRepo;
        private INhanVienRepository _nhanVienRepo;
        private ISanPhamRepository _sanPhamRepo;
        private List<ChiTietHDNResponse> _listChiTiets;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHoaDonNhapService _service;

        public ucThemHDN(IHoaDonNhapService service, INhaCungCapRepository nhaCungCapRepo,
            INhanVienRepository nhanVienRepo, ISanPhamRepository sanPhamRepo, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _maHoaDonGenerator = new MaHoaDonGenerator("HDN", 3);
            _service = service;
            _nhaCungCapRepo = nhaCungCapRepo;
            _nhanVienRepo = nhanVienRepo;
            _sanPhamRepo = sanPhamRepo;
            _serviceProvider = serviceProvider;
        }

        private void ucChiTietHDN_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                InitializationHandle();
                LoadComboBoxes();
            }
        }

        private void InitializationHandle()
        {
            _listChiTiets = new List<ChiTietHDNResponse>();
            ConfigDataGridView();
            txtThanhTien.ReadOnly = true;
            txtMaHDN.ReadOnly = true;
            cboTrangThai.Enabled = false;
        }

        // Cau hinh hien thi bang du lieu chi tiet
        private void ConfigDataGridView()
        {
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();

            dgvChiTiet.Columns.Add("MaSP", "Mã sản phẩm");
            dgvChiTiet.Columns.Add("TenSP", "Tên sản phẩm");
            dgvChiTiet.Columns.Add("SoLuong", "Số lượng");
            dgvChiTiet.Columns.Add("DonGia", "Đơn giá");
            dgvChiTiet.Columns.Add("ThanhTien", "Thành tiền");

            dgvChiTiet.Columns["MaSP"].DataPropertyName = "MaSP";
            dgvChiTiet.Columns["TenSP"].DataPropertyName = "TenSP";
            dgvChiTiet.Columns["SoLuong"].DataPropertyName = "SoLuong";
            dgvChiTiet.Columns["DonGia"].DataPropertyName = "DonGia";
            dgvChiTiet.Columns["ThanhTien"].DataPropertyName = "ThanhTien";

            //dgvChiTiet.DataSource = new BindingList<ChiTietHDNResponse>(_listChiTiets);
            var source = new BindingSource();
            source.DataSource = new BindingList<ChiTietHDNResponse>(_listChiTiets);
            dgvChiTiet.DataSource = source;
        }

        // load du lieu cho cac combobox
        private void LoadComboBoxes()
        {
            LoadTrangThaiComboBox();
            LoadComboBoxNhaCungCap();
            LoadComboBoxNhanVien();
            LoadComboBoxSanPham();
        }

        // load cac trang thai hoa don nhap vao combobox
        private void LoadTrangThaiComboBox()
        {
            var dataSource = new List<object>
            {
                new { Value = (byte?)TrangThaiHoaDonNhap.TamLuu, Display = "Tạm lưu" },
                new { Value = (byte?)TrangThaiHoaDonNhap.HoatDong, Display = "Hoạt động" },
                new { Value = (byte?)TrangThaiHoaDonNhap.DaHuy, Display = "Đã hủy" }
            };

            cboTrangThai.DataSource = dataSource;
            cboTrangThai.DisplayMember = "Display";
            cboTrangThai.ValueMember = "Value";
            cboTrangThai.SelectedIndex = 0;
        }

        // Tim kiem trong combobox
        private void EnableSearchableComboBox(ComboBox comboBox, List<string> items)
        {
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(items.ToArray());
            comboBox.AutoCompleteCustomSource = autoSource;
        }

        // load nha cung cap vao combobox
        private void LoadComboBoxNhaCungCap()
        {
            try
            {
                var list = _nhaCungCapRepo.GetAll();
                cboNhaCungCap.DataSource = list;
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "MaNCC";
                EnableSearchableComboBox(cboNhaCungCap, list.Select(x => x.TenNCC).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách NCC: {ex.Message}");
            }
        }

        // load nhan vien vao combobox
        private void LoadComboBoxNhanVien()
        {
            try
            {
                var list = _nhanVienRepo.GetAll();
                cboNhanVien.DataSource = list;
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "MaNV";
                EnableSearchableComboBox(cboNhanVien, list.Select(x => x.HoTen).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách NV: {ex.Message}");
            }
        }

        // load san pham vao combobox
        private void LoadComboBoxSanPham()
        {
            try
            {
                var list = _sanPhamRepo.GetAll();
                cboSanPham.DataSource = list;
                cboSanPham.DisplayMember = "TenSP";
                cboSanPham.ValueMember = "MaSP";
                EnableSearchableComboBox(cboSanPham, list.Select(x => x.TenSP).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sản phẩm: {ex.Message}");
            }
        }

        private void ClearFieldThongTinChung()
        {
            dtpNgayNhap.Value = DateTime.Now;
            cboNhaCungCap.SelectedIndex = -1;
            cboNhanVien.SelectedIndex = -1;
            txtGhiChu.Clear();
            cboTrangThai.SelectedIndex = 0;
            lblTongTien.Text = "0";
        }

        private void ClearFieldThongTinSanPham()
        {
            cboSanPham.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
        }

        //private void NgayDuyet_NgayHuy()
        //{
        //    dtpNgayDuyet.Visible = false;
        //    dtpNgayHuy.Visible = false;
        //    lblNgayDuyet.Visible = false;
        //    lblNgayHuy.Visible = false;
        //}

        // Validate input chi tiet
        private bool ValidateChiTietInput()
        {
            errorProvider1.Clear();

            if (cboSanPham.SelectedValue == null)
            {
                errorProvider1.SetError(cboSanPham, "Vui lòng chọn sản phẩm");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                !int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                errorProvider1.SetError(txtSoLuong, "Số lượng phải là số nguyên dương");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDonGia.Text) ||
                !decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
            {
                errorProvider1.SetError(txtDonGia, "Đơn giá phải là số dương");
                return false;
            }

            return true;
        }

        // cap nhat lai bang du lieu chi tiet
        private void RefreshGrid()
        {
            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = new BindingList<ChiTietHDNResponse>(_listChiTiets);
            UpdateTongTien();
        }

        // cap nhat tong tien
        private void UpdateTongTien()
        {
            decimal tongTien = _listChiTiets.Sum(ct => ct.ThanhTien);
            lblTongTien.Text = tongTien.ToString("N0");
        }

        // Click vao 1 dong de hien thi chi tiet len textbox
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChiTiet.Rows.Count)
            {
                var row = dgvChiTiet.Rows[e.RowIndex];
                cboSanPham.Text = row.Cells["TenSP"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                txtThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
            }
        }

        // Su kien them chi tiet hoa don
        private void btnThemChiTietHDN_Click(object sender, EventArgs e)
        {
            ClearFieldThongTinSanPham();
            btnLuuChiTietHDN.Enabled = true;
            //btnSuaChiTietHDN.Enabled = false;
            //btnXoaChiTietHDN.Enabled = false;
        }

        // Su kien xoa chi tiet hoa don khi chua luu vao db
        private void btnXoaChiTietHDN_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maSP = dgvChiTiet.SelectedRows[0].Cells["MaSP"].Value.ToString();
            var item = _listChiTiets.FirstOrDefault(ct => ct.MaSP == maSP);
            if (item != null)
            {
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xoá sản phẩm [{item.TenSP}] khỏi danh sách?",
                    "Xác nhận xoá",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _listChiTiets.Remove(item);
                    RefreshGrid();
                    ClearFieldThongTinSanPham();
                }
                else return;
            }
            MessageBox.Show("Đã xoá thông tin sản phẩm thành công!",
               "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSuaChiTietHDN_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateChiTietInput()) return;
            string maSP = dgvChiTiet.SelectedRows[0].Cells["MaSP"].Value.ToString();
            var existingItem = _listChiTiets.FirstOrDefault(x => x.MaSP == maSP);
            if (existingItem == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm cần sửa trong danh sách!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn sửa thông tin sản phẩm [{existingItem.TenSP}] không?",
                "Xác nhận sửa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            int soLuong = int.Parse(txtSoLuong.Text);
            decimal donGia = decimal.Parse(txtDonGia.Text);
            decimal thanhTien = soLuong * donGia;

            existingItem.SoLuong = soLuong;
            existingItem.DonGia = donGia;
            existingItem.ThanhTien = thanhTien;

            RefreshGrid();
            ClearFieldThongTinSanPham();

            MessageBox.Show("Đã cập nhật thông tin sản phẩm thành công!",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuuChiTietHDN_Click(object sender, EventArgs e)
        {
            if (!ValidateChiTietInput()) return;

            string maSP = cboSanPham.SelectedValue.ToString();
            string tenSP = cboSanPham.Text;
            int soLuong = int.Parse(txtSoLuong.Text);
            decimal donGia = decimal.Parse(txtDonGia.Text);
            decimal thanhTien = soLuong * donGia;

            var existingItem = _listChiTiets.FirstOrDefault(p => p.MaSP == maSP);

            if (existingItem == null)
            {
                _listChiTiets.Add(new ChiTietHDNResponse
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThanhTien = thanhTien
                });
            }
            else
            {
                errorProvider1.SetError(cboSanPham, "Sản phẩm đã tồn tại trong danh sách");
            }

            RefreshGrid();
            ClearFieldThongTinSanPham();
            btnSuaChiTietHDN.Enabled = true;
            btnXoaChiTietHDN.Enabled = true;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            changeThanhTien();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            changeThanhTien();
        }

        // tu dong tinh thanh tien khi so luong hoac don gia thay doi
        private void changeThanhTien()
        {
            if (int.TryParse(txtSoLuong.Text, out int soLuong) &&
                decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                txtThanhTien.Text = (soLuong * donGia).ToString("N0");
            }
            else
            {
                txtThanhTien.Text = "0";
            }
        }

        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            if (cboTrangThai.Text == "Tạm lưu" || cboTrangThai.SelectedIndex == -1)
            {
                DateTime ngayLapMoi = dtpNgayNhap.Value;
                txtMaHDN.Text = _maHoaDonGenerator.GenerateNewMaHDN(ngayLapMoi);
            }
        }

        // validate thong tin chung
        private bool ValidateThongTinChung()
        {
            errorProvider1.Clear();
            if (cboNhaCungCap.SelectedValue == null)
            {
                errorProvider1.SetError(cboNhaCungCap, "Vui lòng chọn nhà cung cấp");
                return false;
            }
            if (cboNhanVien.SelectedValue == null)
            {
                errorProvider1.SetError(cboNhanVien, "Vui lòng chọn nhân viên");
                return false;
            }
            return true;
        }

        private void btnTaoMoiHDN_Click(object sender, EventArgs e)
        {
            ClearFieldThongTinChung();
            ClearFieldThongTinSanPham();
            //NgayDuyet_NgayHuy();
            _listChiTiets.Clear();
            RefreshGrid();
            txtMaHDN.Text = _maHoaDonGenerator.GenerateNewMaHDN(dtpNgayNhap.Value);
            HelperHoaDonTaoMoi();
        }

        private void HelperHoaDonDaDuyet()
        {
            //dtpNgayDuyet.Visible = true;
            //lblNgayDuyet.Visible = true;
            btnTamLuuHDN.Enabled = false;
            btnDuyetHDN.Enabled = false;
            btnThemChiTietHDN.Enabled = false;
            btnLuuChiTietHDN.Enabled = false;
            btnSuaChiTietHDN.Enabled = false;
            btnXoaChiTietHDN.Enabled = false;
        }

        private void HelperHoaDonTaoMoi()
        {
            btnTamLuuHDN.Enabled = true;
            btnDuyetHDN.Enabled = true;
            btnThemChiTietHDN.Enabled = true;
            btnLuuChiTietHDN.Enabled = true;
            btnSuaChiTietHDN.Enabled = true;
            btnXoaChiTietHDN.Enabled = true;
            //dtpNgayDuyet.Visible = false;
            //lblNgayDuyet.Visible = false;
            //dtpNgayHuy.Visible = false;
            //lblNgayHuy.Visible = false;
            //SetHoaDonStatus(TrangThaiHoaDonNhap.TamLuu);
        }

        //private void SetHoaDonStatus(TrangThaiHoaDonNhap status)
        //{
        //    cboTrangThai.SelectedValue = (byte)status;

        //    lblNgayDuyet.Visible = (status == TrangThaiHoaDonNhap.HoatDong);
        //    dtpNgayDuyet.Visible = (status == TrangThaiHoaDonNhap.HoatDong);

        //    lblNgayHuy.Visible = (status == TrangThaiHoaDonNhap.DaHuy);
        //    dtpNgayHuy.Visible = (status == TrangThaiHoaDonNhap.DaHuy);
        //}

        private void btnTamLuuHDN_Click(object sender, EventArgs e)
        {
            if (!ValidateThongTinChung()) return;
            try
            {
                var request = GetHoaDonNhapRequest();
                string result = _service.CreateDraftHoaDonNhap(request);
                MessageBox.Show($"Tạo hóa đơn nháp thành công!\nMã: {result}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private HoaDonNhapRequest GetHoaDonNhapRequest()
        {
            return new HoaDonNhapRequest
            {
                MaHDN = txtMaHDN.Text.Trim(),
                NgayNhap = dtpNgayNhap.Value,
                MaNCC = cboNhaCungCap.SelectedValue?.ToString(),
                MaNV = cboNhanVien.SelectedValue?.ToString(),
                TrangThai = TrangThaiHoaDonNhap.TamLuu,
                GhiChu = txtGhiChu.Text.Trim(),
                ChiTiet = _listChiTiets.Select(ct => new ChiTietHDNRequest
                {
                    MaSP = ct.MaSP,
                    SoLuong = ct.SoLuong,
                    DonGia = ct.DonGia
                }).ToList()
            };
        }

        private void btnDuyetHDN_Click(object sender, EventArgs e)
        {
            string maHDN = txtMaHDN.Text.Trim();
            if (string.IsNullOrEmpty(maHDN))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn để duyệt.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((byte?)cboTrangThai.SelectedValue != (byte)TrangThaiHoaDonNhap.TamLuu)
            {
                MessageBox.Show("Chỉ có hóa đơn ở trạng thái 'Tạm lưu' mới có thể duyệt.",
                    "Không thể duyệt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn duyệt hóa đơn [{maHDN}] không?",
                "Xác nhận duyệt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No) return;

            try
            {
                _service.ApproveHoaDonNhap(maHDN);
                //SetHoaDonStatus(TrangThaiHoaDonNhap.HoatDong);
                //dtpNgayDuyet.Value = DateTime.Now;
                HelperHoaDonDaDuyet();
                MessageBox.Show("Duyệt hóa đơn nhập thành công!",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi duyệt hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInHDN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDN.Text))
            {
                MessageBox.Show("Vui lòng tạo hoặc chọn hóa đơn trước khi xuất!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_listChiTiets == null || !_listChiTiets.Any())
            {
                MessageBox.Show("Chưa có chi tiết sản phẩm để xuất!",
                    "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = $"PhieuNhap_{txtMaHDN.Text}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                sfd.Title = "Xuất phiếu nhập hàng";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var hoaDon = new HoaDonNhapResponse
                        {
                            MaHDN = txtMaHDN.Text.Trim(),
                            NgayNhap = dtpNgayNhap.Value,
                            TenNCC = cboNhaCungCap.Text,
                            TenNV = cboNhanVien.Text,
                            GhiChu = txtGhiChu.Text.Trim(),
                            ChiTiet = _listChiTiets
                        };

                        ExcelHelper.XuatPhieuNhapHang(sfd.FileName, hoaDon);
                        MessageBox.Show($"Xuất phiếu nhập hàng thành công!\nĐã lưu tại:\n{sfd.FileName}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất Excel:\n{ex.Message}",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                var parent = this.Parent;
                var listUC = _serviceProvider.GetRequiredService<ucHoaDonNhapList>();
                listUC.LoadData();
                parent.Controls.Clear();
                listUC.Dock = DockStyle.Fill;
                parent.Controls.Add(listUC);
                listUC.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi quay lại danh sách hóa đơn: " + ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //private void btnInHDN_Click(object sender, EventArgs e)
        //{
        //    QuestPDF.Settings.License = LicenseType.Community;

        //    if (string.IsNullOrWhiteSpace(txtMaHDN.Text))
        //    {
        //        MessageBox.Show("Vui lòng chọn hoặc tạo hoá đơn trước khi xuất.",
        //            "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (_listChiTiets == null || !_listChiTiets.Any())
        //    {
        //        MessageBox.Show("Hóa đơn chưa có chi tiết để xuất.",
        //            "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    using var sfd = new SaveFileDialog
        //    {
        //        Title = "Lưu hóa đơn nhập",
        //        Filter = "PDF file (*.pdf)|*.pdf",
        //        FileName = $"HoaDonNhap_{txtMaHDN.Text}.pdf"
        //    };

        //    if (sfd.ShowDialog() != DialogResult.OK)
        //        return;

        //    string filePath = sfd.FileName;

        //    try
        //    {
        //        // Dữ liệu cơ bản
        //        string maHDN = txtMaHDN.Text.Trim();
        //        string ncc = cboNhaCungCap.Text;
        //        string nv = cboNhanVien.Text;
        //        string ngay = dtpNgayNhap.Value.ToString("dd/MM/yyyy");
        //        string ghiChu = txtGhiChu.Text.Trim();
        //        decimal tongTien = _listChiTiets.Sum(ct => ct.ThanhTien);

        //        // 1️⃣ Tạo tài liệu PDF
        //        var doc = QDoc.Create(container =>
        //        {
        //            container.Page(page =>
        //            {
        //                page.Size(PageSizes.A4);
        //                page.Margin(30);

        //                page.Content().Column(col =>
        //                {
        //                    col.Item().Text($"PHIẾU NHẬP HÀNG").FontSize(18).Bold();
        //                    col.Item().Text($"Mã hóa đơn: {maHDN}");
        //                    col.Item().Text($"Nhà cung cấp: {ncc}");
        //                    col.Item().Text($"Nhân viên lập: {nv}");
        //                    col.Item().Text($"Ngày nhập: {ngay}");
        //                    if (!string.IsNullOrEmpty(ghiChu))
        //                        col.Item().Text($"Ghi chú: {ghiChu}");

        //                    col.Item().Text("");
        //                    col.Item().Text("Chi tiết hóa đơn:");

        //                    // Bảng chi tiết (dạng text đơn giản)
        //                    foreach (var item in _listChiTiets)
        //                    {
        //                        col.Item().Text($"- {item.TenSP} | SL: {item.SoLuong} | Đơn giá: {item.DonGia:N0} | Thành tiền: {item.ThanhTien:N0}");
        //                    }

        //                    col.Item().Text("");
        //                    col.Item().Text($"Tổng cộng: {tongTien:N0} VNĐ").Bold();
        //                });
        //            });
        //        });

        //        // 2️⃣ Ghi file PDF ra đĩa
        //        doc.GeneratePdf(filePath);

        //        MessageBox.Show($"Xuất hoá đơn thành công!\nĐã lưu tại: {filePath}",
        //            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        // 3️⃣ Mở file PDF sau khi lưu
        //        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
        //        {
        //            FileName = filePath,
        //            UseShellExecute = true
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}",
        //            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}