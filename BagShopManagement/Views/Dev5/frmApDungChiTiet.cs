using BagShopManagement.Controllers;
using BagShopManagement.DTOs;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Controls
{
    public partial class frmApDungChiTiet : Form
    {
        private readonly string _maCTGG;
        private readonly ChiTietGiamGiaController _controller; // Đã sửa: Controller sẽ được truyền vào
        private List<SanPham> _toanBoKhoSanPham;
        private List<ChiTietGiamGiaDto> _toanBoSanPhamApDung;

        // SỬA LỖI LOGIC: Hàm khởi tạo giờ đây nhận vào một ChiTietGiamGiaController
        public frmApDungChiTiet(string maCTGG, string tenChuongTrinh, ChiTietGiamGiaController chiTietGiamGiaController)
        {
            InitializeComponent();
            _maCTGG = maCTGG;
            _controller = chiTietGiamGiaController; // Gán controller được truyền vào

            // Kiểm tra null để tránh lỗi nghiêm trọng
            if (_controller == null)
            {
                throw new ArgumentNullException(nameof(chiTietGiamGiaController), "Controller không được là null.");
            }

            lblTenChuongTrinh.Text = $"Áp dụng sản phẩm cho chương trình: '{tenChuongTrinh}'";
            AssignEvents();
        }

        private void AssignEvents()
        {
            this.Load += FrmApDungChiTiet_Load;
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnHuỵChonKM.Click += (s, e) => { this.Close(); };
            btnTimKiemKho.Click += BtnTimKiemKho_Click;
            btnTimKiemApDung.Click += BtnTimKiemApDung_Click;
            txtTimKiemKho.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnTimKiemKho.PerformClick(); };
            txtTimKiemApDung.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnTimKiemApDung.PerformClick(); };
        }

        private void FrmApDungChiTiet_Load(object sender, EventArgs e)
        {
            ReloadAllData();
        }

        private void ReloadAllData()
        {
            LoadKhoSanPham();
            LoadSanPhamApDung();
        }

        private void LoadKhoSanPham()
        {
            try
            {
                _toanBoKhoSanPham = _controller.GetAvailableProductsForPromotion(_maCTGG);
                dgvKhoSanPham.DataSource = null;
                dgvKhoSanPham.DataSource = _toanBoKhoSanPham;
                CustomizeKhoGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm trong kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSanPhamApDung()
        {
            try
            {
                _toanBoSanPhamApDung = _controller.GetAppliedProductsForPromotion(_maCTGG);
                dgvSanPhamApDung.DataSource = null;
                dgvSanPhamApDung.DataSource = _toanBoSanPhamApDung;
                CustomizeApDungGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm đã áp dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (dgvKhoSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách bên trái để thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (nudPhanTramGiam.Value <= 0 || nudPhanTramGiam.Value > 100)
            {
                MessageBox.Show("Phần trăm giảm giá phải lớn hơn 0 và nhỏ hơn hoặc bằng 100.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSP = dgvKhoSanPham.CurrentRow.Cells["MaSP"].Value.ToString();
            int phanTramGiam = (int)nudPhanTramGiam.Value;

            try
            {
                _controller.AddProductToPromotion(_maCTGG, maSP, phanTramGiam);
                ReloadAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm sản phẩm thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPhamApDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách bên phải để gỡ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn gỡ sản phẩm này khỏi chương trình khuyến mãi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string maSP = dgvSanPhamApDung.CurrentRow.Cells["MaSP"].Value.ToString();

            try
            {
                _controller.RemoveProductFromPromotion(_maCTGG, maSP);
                ReloadAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gỡ sản phẩm thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Các hàm tìm kiếm và tùy chỉnh giao diện không thay đổi...
        private void BtnTimKiemKho_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemKho.Text.Trim().ToLower();
            if (_toanBoKhoSanPham == null) return;
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvKhoSanPham.DataSource = _toanBoKhoSanPham;
                return;
            }
            var ketQuaLoc = _toanBoKhoSanPham
                .Where(sp => sp.TenSP.ToLower().Contains(tuKhoa) || sp.MaSP.ToLower().Contains(tuKhoa))
                .ToList();
            dgvKhoSanPham.DataSource = ketQuaLoc;
        }

        private void BtnTimKiemApDung_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemApDung.Text.Trim().ToLower();
            if (_toanBoSanPhamApDung == null) return;
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvSanPhamApDung.DataSource = _toanBoSanPhamApDung;
                return;
            }
            var ketQuaLoc = _toanBoSanPhamApDung
                .Where(sp => sp.TenSP.ToLower().Contains(tuKhoa) || sp.MaSP.ToLower().Contains(tuKhoa))
                .ToList();
            dgvSanPhamApDung.DataSource = ketQuaLoc;
        }

        private void CustomizeKhoGridView()
        {
            dgvKhoSanPham.Columns["MaSP"].HeaderText = "Mã SP";
            dgvKhoSanPham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvKhoSanPham.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
            //dgvKhoSanPham.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CustomizeApDungGridView()
        {
            dgvSanPhamApDung.Columns["MaSP"].HeaderText = "Mã SP";
            dgvSanPhamApDung.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvSanPhamApDung.Columns["PhanTramGiam"].HeaderText = "% Giảm";
            dgvSanPhamApDung.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // Ẩn các cột không cần thiết nếu có
            if (dgvSanPhamApDung.Columns.Contains("MaCTGG"))
            {
                dgvSanPhamApDung.Columns["MaCTGG"].Visible = false;
            }
        }

        private void dgvKhoSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXacNhanKM_Click(object sender, EventArgs e)
        {

        }
    }
}