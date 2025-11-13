using Microsoft.Identity.Client;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Controls
{
    public partial class SideBarControl : UserControl
    {
        public event EventHandler ShowTestClicked;

        public event EventHandler ShowHoaDonNhapClicked;

        public event EventHandler ShowBanHangClicked;

        public event EventHandler ShowEmployeeManagementClicked;

        public event EventHandler ShowProfileClicked;

        public SideBarControl()
        {
            InitializeComponent();
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            ShowHoaDonNhapClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            ShowBanHangClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            ShowTestClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện 'ShowEmployeeManagementClicked'
            // '?' để kiểm tra xem có ai (MainForm) đang lắng nghe không
            ShowEmployeeManagementClicked?.Invoke(this, EventArgs.Empty);
        }

        // (Giả sử nút "Tài khoản" của bạn tên là btnTaiKhoan)
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện 'ShowProfileClicked'
            ShowProfileClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}