using BagShopManagement.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev1
{
    public partial class ForgotPasswordForm : Form
    {
        private readonly ProfileController _profileController;

        // Constructor nhận Controller từ DI
        public ForgotPasswordForm(ProfileController profileController)
        {
            InitializeComponent();
            _profileController = profileController;
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Gọi Controller
                string successMessage = _profileController.HandleResetPassword(tenDangNhap);

                // 2. Hiển thị thông báo thành công (từ Service)
                MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi thành công
            }
            catch (Exception ex)
            {
                // 3. Hiển thị lỗi (ví dụ: "Không tìm thấy tài khoản")
                MessageBox.Show(ex.Message, "Yêu cầu thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
