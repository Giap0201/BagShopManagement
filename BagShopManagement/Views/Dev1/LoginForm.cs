using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Requests;
using BagShopManagement.Utils;
using BagShopManagement.Views.Common;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class LoginForm : Form
    {
        private readonly LoginController _loginController;
        private readonly Func<QuanLiBanHang> _mainFormFactory;
        private readonly IServiceProvider _serviceProvider;

        public LoginForm(
            LoginController loginController,
            Func<QuanLiBanHang> mainFormFactory,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _loginController = loginController;
            _mainFormFactory = mainFormFactory;
            _serviceProvider = serviceProvider;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var request = new LoginRequest
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim()
            };

            if (string.IsNullOrEmpty(request.TenDangNhap) || string.IsNullOrEmpty(request.MatKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var loginResponse = _loginController.HandleLogin(request);
                UserContext.SetCurrentUser(loginResponse);

                MessageBox.Show($"Đăng nhập thành công! Xin chào, {loginResponse.HoTen}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // === [SỬA LẠI LOGIC MỞ FORM ĐỂ HỖ TRỢ ĐĂNG XUẤT] ===

                // 1. Ẩn form đăng nhập trước
                this.Hide();

                // 2. Tạo và mở MainForm dưới dạng MODAL (ShowDialog)
                // Code sẽ "dừng" ở dòng này cho đến khi MainForm bị đóng (do bấm X hoặc bấm Đăng xuất)
                using (var mainForm = _mainFormFactory())
                {
                    mainForm.ShowDialog();
                }

                // 3. Khi MainForm đóng lại, dòng code này sẽ chạy tiếp
                // Hiện lại form đăng nhập để người khác đăng nhập
                this.Show();

                // 4. Xóa mật khẩu cũ để bảo mật
                txtMatKhau.Clear();
                txtTenDangNhap.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void llblQuenMatKhau_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var forgotPasswordForm = _serviceProvider.GetRequiredService<ForgotPasswordForm>())
            {
                forgotPasswordForm.ShowDialog(this);
            }
        }
    }
}