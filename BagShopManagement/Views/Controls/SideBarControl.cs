using Microsoft.Identity.Client;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Controls
{

    
    public partial class SideBarControl : UserControl
    {
        // === Events của Dev4, Dev6, Dev2, Dev3 (Từ file cơ sở) ===
        public event EventHandler ShowHoaDonNhapClicked;
        public event EventHandler ShowBanHangClicked;
        public event EventHandler ShowBaoCaoThongKeClicked; // (Dùng cho btnBCTK_Click)
        public event EventHandler SanPhamClicked;
        public event EventHandler DanhMucClicked;
        public event EventHandler ShowQuanLyHoaDonClicked;
        public event EventHandler KhachHangClicked;
        public event EventHandler NhaCungCapClicked;

        // === Events của Dev1 (Bổ sung) ===
        public event EventHandler ShowEmployeeManagementClicked;
        public event EventHandler ShowProfileClicked;

        // (Sự kiện 'ShowTestClicked' từ snippet 2 bị trùng lặp
        // với 'ShowBaoCaoThongKeClicked' vì cùng dùng 'btnBCTK_Click',
        // nên tôi giữ lại 'ShowBaoCaoThongKeClicked' theo file cơ sở)

        public SideBarControl()
        {
            InitializeComponent();

            // Gắn sự kiện (Bạn nên làm việc này trong Designer)
            // btnSanPham.Click += btnSanPham_Click;
            // btnDanhMuc.Click += btnDanhMuc_Click;

            // (Bạn CẦN làm tương tự cho btnNhanVien và btnTaiKhoan)
            // btnNhanVien.Click += btnNhanVien_Click;
            // btnTaiKhoan.Click += btnTaiKhoan_Click;
        }

        // --- Các hàm _Click của nhóm bạn ---
        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            ShowHoaDonNhapClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            ShowBanHangClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            ShowQuanLyHoaDonClicked?.Invoke(this, EventArgs.Empty);
        }

        // Nút Báo cáo Thống kê
        private void btnBCTK_Click(object sender, EventArgs e)
        {
            ShowBaoCaoThongKeClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            SanPhamClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            DanhMucClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            KhachHangClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            NhaCungCapClicked?.Invoke(this, EventArgs.Empty);
        }

        // --- Các hàm _Click của Dev1 (Bổ sung) ---

        // (Giả sử nút "Nhân viên" của bạn tên là btnNhanVien)
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện 'ShowEmployeeManagementClicked'
            ShowEmployeeManagementClicked?.Invoke(this, EventArgs.Empty);
        }

        // (Giả sử nút "Tài khoản" của bạn tên là btnTaiKhoan)
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện 'ShowProfileClicked'
            ShowProfileClicked?.Invoke(this, EventArgs.Empty);
        }

        private void SideBarControl_Load(object sender, EventArgs e)
        {
            // (Giữ trống)
        }
    }
}