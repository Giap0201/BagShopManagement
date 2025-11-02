using BagShopManagement.Controllers;
using BagShopManagement.DTOs;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Controls
{
    public partial class frmApDungChiTiet : Form
    {
        private readonly string _maCTGG; // Mã chương trình khuyến mãi đang làm việc (kiểu string)
        private readonly ChiTietGiamGiaController _controller;
        private List<SanPham> _toanBoKhoSanPham;
        private List<ChiTietGiamGiaDto> _toanBoSanPhamApDung;

        public frmApDungChiTiet(string maCTGG, string tenChuongTrinh)
        {
            InitializeComponent();
            _maCTGG = maCTGG;
            _controller = new ChiTietGiamGiaController();
            lblTenChuongTrinh.Text = $"Áp dụng sản phẩm cho chương trình: '{tenChuongTrinh}'";

            AssignEvents();
        }

        private void AssignEvents()
        {
            this.Load += FrmApDungChiTiet_Load;

            // Nút chức năng chính
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnHuỵChonKM.Click += (s, e) => { this.Close(); };

            // Nút tìm kiếm
            btnTimKiemKho.Click += BtnTimKiemKho_Click;
            btnTimKiemApDung.Click += BtnTimKiemApDung_Click;

            // Nâng cao: Cho phép nhấn Enter để tìm kiếm
            txtTimKiemKho.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnTimKiemKho.PerformClick(); };
            txtTimKiemApDung.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnTimKiemApDung.PerformClick(); };
        }

        private void FrmApDungChiTiet_Load(object sender, EventArgs e)
        {
            // Khi form được tải, thực hiện tải dữ liệu cho cả hai bảng
            LoadKhoSanPham();
            LoadSanPhamApDung();
        }

        private void LoadKhoSanPham()
        {
            try
            {
                // Gọi controller để lấy danh sách sản phẩm chưa được áp dụng cho CTGG này
                _toanBoKhoSanPham = _controller.GetAvailableProductsForPromotion(_maCTGG);

                // Gán dữ liệu vào DataGridView
                dgvKhoSanPham.DataSource = null; // Luôn xóa datasource cũ trước khi gán mới
                dgvKhoSanPham.DataSource = _toanBoKhoSanPham;
                CustomizeKhoGridView(); // Tùy chỉnh hiển thị cho đẹp
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
                // Gọi controller để lấy danh sách sản phẩm đã được áp dụng cho CTGG này
                _toanBoSanPhamApDung = _controller.GetAppliedProductsForPromotion(_maCTGG);

                // Gán dữ liệu vào DataGridView
                dgvSanPhamApDung.DataSource = null;
                dgvSanPhamApDung.DataSource = _toanBoSanPhamApDung;
                CustomizeApDungGridView(); // Tùy chỉnh hiển thị
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm đã áp dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== CORE ACTION EVENT HANDLERS ==================
        private void BtnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn sản phẩm bên trái chưa
            if (dgvKhoSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách bên trái để thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Kiểm tra giá trị % giảm giá
            if (nudPhanTramGiam.Value <= 0)
            {
                MessageBox.Show("Phần trăm giảm giá phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Lấy thông tin cần thiết từ form
            string maSP = dgvKhoSanPham.CurrentRow.Cells["MaSP"].Value.ToString();
            int phanTramGiam = (int)nudPhanTramGiam.Value;

            // 4. Gọi controller để thực hiện logic thêm
            try
            {
                _controller.AddProductToPromotion(_maCTGG, maSP, phanTramGiam);
                // 5. Tải lại cả hai bảng để cập nhật giao diện
                LoadKhoSanPham();
                LoadSanPhamApDung();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm sản phẩm thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn sản phẩm bên phải chưa
            if (dgvSanPhamApDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách bên phải để gỡ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Xác nhận lại với người dùng
            if (MessageBox.Show("Bạn có chắc chắn muốn gỡ sản phẩm này khỏi chương trình khuyến mãi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // 3. Lấy thông tin cần thiết
            string maSP = dgvSanPhamApDung.CurrentRow.Cells["MaSP"].Value.ToString();

            // 4. Gọi controller để thực hiện logic xóa
            try
            {
                _controller.RemoveProductFromPromotion(_maCTGG, maSP);
                // 5. Tải lại cả hai bảng
                LoadKhoSanPham();
                LoadSanPhamApDung();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gỡ sản phẩm thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== SEARCH EVENT HANDLERS ==================
        private void BtnTimKiemKho_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemKho.Text.Trim().ToLower();

            // Nếu không có dữ liệu gốc thì không làm gì cả
            if (_toanBoKhoSanPham == null) return;

            // Nếu ô tìm kiếm trống, hiển thị lại toàn bộ danh sách gốc
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvKhoSanPham.DataSource = _toanBoKhoSanPham;
                return;
            }

            // Dùng LINQ để lọc trên danh sách gốc dựa theo Tên Sản Phẩm
            var ketQuaLoc = _toanBoKhoSanPham
                .Where(sp => sp.TenSP.ToLower().Contains(tuKhoa))
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
                .Where(sp => sp.TenSP.ToLower().Contains(tuKhoa))
                .ToList();

            dgvSanPhamApDung.DataSource = ketQuaLoc;
        }

        // ================== UI CUSTOMIZATION METHODS ==================
        private void CustomizeKhoGridView()
        {
            if (dgvKhoSanPham.Columns["MaSP"] != null)
            {
                dgvKhoSanPham.Columns["MaSP"].HeaderText = "Mã SP";
                dgvKhoSanPham.Columns["MaSP"].Width = 80;
            }
            if (dgvKhoSanPham.Columns["TenSP"] != null)
            {
                dgvKhoSanPham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dgvKhoSanPham.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvKhoSanPham.Columns["SoLuongTon"] != null)
            {
                dgvKhoSanPham.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
                dgvKhoSanPham.Columns["SoLuongTon"].Width = 70;
            }
        }

        private void CustomizeApDungGridView()
        {
            if (dgvSanPhamApDung.Columns["MaSP"] != null)
            {
                dgvSanPhamApDung.Columns["MaSP"].HeaderText = "Mã SP";
                dgvSanPhamApDung.Columns["MaSP"].Width = 80;
            }
            if (dgvSanPhamApDung.Columns["TenSP"] != null)
            {
                dgvSanPhamApDung.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dgvSanPhamApDung.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvSanPhamApDung.Columns["PhanTramGiam"] != null)
            {
                dgvSanPhamApDung.Columns["PhanTramGiam"].HeaderText = "% Giảm";
                dgvSanPhamApDung.Columns["PhanTramGiam"].Width = 70;
            }
        }


    }
}
