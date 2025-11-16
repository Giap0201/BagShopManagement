using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Requests;
using BagShopManagement.Utils;
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
    public partial class ucProfile : UserControl
    {
        private readonly ProfileController _profileController;

        // Constructor này sẽ nhận Controller từ DI (do Program.cs đăng ký)
        // Lưu ý: Nếu bạn kéo thả UC này vào Form bằng tay,
        // constructor này sẽ lỗi. Bạn PHẢI thêm UC này bằng code trong MainForm.
        public ucProfile(ProfileController profileController)
        {
            InitializeComponent();
            _profileController = profileController;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        // Tải dữ liệu khi User Control được hiển thị
        private void ucProfile_Load(object sender, EventArgs e)
        {
            LoadProfileData();
        }

        // Nút làm mới (tải lại thông tin)
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadProfileData();
            ClearPasswordFields();
        }

        // Nút đổi mật khẩu
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu
            string oldPass = txtMatKhauCu.Text.Trim();
            string newPass = txtMatKhauMoi.Text.Trim();
            string confirmPass = txtXacNhanMoi.Text.Trim();

            // 2. Kiểm tra
            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đổi mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 3. Tạo Request DTO
                var request = new ChangePasswordRequest
                {
                    TenDangNhap = txtTenDangNhap.Text, // Lấy từ ô Tên Đăng Nhập (read-only)
                    OldPassword = oldPass,
                    NewPassword = newPass
                };

                // 4. Gọi Controller
                bool success = _profileController.HandleChangePassword(request);

                // 5. Xử lý kết quả
                if (success)
                {
                    MessageBox.Show("Đổi mật khẩu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearPasswordFields();
                }
                else
                {
                    // Trường hợp này hiếm khi xảy ra nếu Controller ném Exception
                    MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng thử lại.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi nghiệp vụ (ví dụ: "Mật khẩu cũ không chính xác")
                MessageBox.Show(ex.Message, "Đổi mật khẩu thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- HÀM HỖ TRỢ ---

        // Hàm tải thông tin profile
        private void LoadProfileData()
        {
            try
            {
                // Lấy MaNV từ UserContext
                string maNV = UserContext.MaNV;
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Lỗi: Không tìm thấy thông tin người dùng. Vui lòng đăng nhập lại.", "Lỗi phiên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gọi Controller
                var profile = _profileController.HandleGetProfile(maNV);

                // Đổ dữ liệu lên các ô text (read-only)
                txtHoTen.Text = profile.HoTen;
                txtChucVu.Text = profile.ChucVu;
                txtEmail.Text = profile.Email;
                txtSoDienThoai.Text = profile.SoDienThoai;
                txtTenDangNhap.Text = profile.TenDangNhap;
                txtVaiTro.Text = profile.TenVaiTro;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin cá nhân: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xóa các ô mật khẩu
        private void ClearPasswordFields()
        {
            txtMatKhauCu.Text = "";
            txtMatKhauMoi.Text = "";
            txtXacNhanMoi.Text = "";
        }
    }
}
