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
        // Controller sẽ được "tiêm" vào qua constructor
        private readonly LoginController _loginController;
        private readonly Func<QuanLiBanHang> _mainFormFactory; // Factory để tạo MainForm
        private readonly IServiceProvider _serviceProvider; // <== THÊM BIẾN NÀY

        // Constructor được cập nhật để nhận Controller và Factory
        public LoginForm(
            LoginController loginController,
            Func<QuanLiBanHang> mainFormFactory,
            IServiceProvider serviceProvider) // <== THÊM THAM SỐ NÀY
        {
            InitializeComponent();
            _loginController = loginController;
            _mainFormFactory = mainFormFactory;
            _serviceProvider = serviceProvider; // <== THÊM DÒNG NÀY
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ TextBox và tạo Request DTO  <== ĐÃ XÓA [cite...]
            var request = new LoginRequest
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(), // <== Lỗi sẽ hết nếu Bước 2 làm đúng
                MatKhau = txtMatKhau.Text.Trim()     // <== Lỗi sẽ hết nếu Bước 2 làm đúng
            };

            // Kiểm tra đầu vào cơ bản
            if (string.IsNullOrEmpty(request.TenDangNhap) || string.IsNullOrEmpty(request.MatKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Gọi Controller.HandleLogin (đặt trong try-catch)
                var loginResponse = _loginController.HandleLogin(request);

                // 3. Nếu thành công (không có ngoại lệ ném ra)
                // Lưu thông tin vào UserContext
                UserContext.SetCurrentUser(loginResponse);

                // 4. Mở MainForm và ẩn LoginForm
                MessageBox.Show($"Đăng nhập thành công! Xin chào, {loginResponse.HoTen}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sử dụng factory để tạo MainForm MỚI (đã được inject dependencies)
                var mainForm = _mainFormFactory();

                mainForm.FormClosed += (s, args) => this.Close(); // Đóng LoginForm khi MainForm đóng
                mainForm.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
            catch (Exception ex)
            {
                // 5. Nếu Controller ném lỗi (sai mật khẩu, tài khoản khóa, v.v.)
                // Hiển thị lỗi cho người dùng
                MessageBox.Show(ex.Message, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear(); // Xóa mật khẩu để nhập lại
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void llblQuenMatKhau_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Thay vì MessageBox, chúng ta mở Form
            // Chúng ta dùng _serviceProvider để lấy Form (giống như trong Program.cs)
            using (var forgotPasswordForm = _serviceProvider.GetRequiredService<ForgotPasswordForm>())
            {
                forgotPasswordForm.ShowDialog(this); // Hiển thị form popup
            }
        }
    }
}
