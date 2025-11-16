using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly INhanVienRepository _nhanVienRepo;
        private readonly ITaiKhoanRepository _taiKhoanRepo;
        private readonly IVaiTroRepository _vaiTroRepo;
        private readonly IEmailService _emailService; // <== THÊM DỊCH VỤ EMAIL

        // Cập nhật Constructor để nhận IEmailService
        public UserService(
            INhanVienRepository nhanVienRepo,
            ITaiKhoanRepository taiKhoanRepo,
            IVaiTroRepository vaiTroRepo,
            IEmailService emailService) // <== THÊM VÀO CONSTRUCTOR
        {
            _nhanVienRepo = nhanVienRepo;
            _taiKhoanRepo = taiKhoanRepo;
            _vaiTroRepo = vaiTroRepo;
            _emailService = emailService; // <== THÊM VÀO CONSTRUCTOR
        }

        /// <summary>
        /// Lấy thông tin tổng hợp từ 3 bảng: NhanVien, TaiKhoan, VaiTro.
        /// </summary>
        public ProfileResponse GetProfile(string maNV)
        {
            // 1. Lấy thông tin nhân viên
            var nhanVien = _nhanVienRepo.GetById(maNV);
            if (nhanVien == null)
                throw new Exception($"Lỗi dữ liệu: Không tìm thấy nhân viên {maNV}.");

            // 2. Lấy thông tin tài khoản
            var taiKhoan = _taiKhoanRepo.GetByMaNV(maNV);
            if (taiKhoan == null)
                throw new Exception($"Lỗi dữ liệu: Không tìm thấy tài khoản cho nhân viên {maNV}.");

            // 3. Lấy thông tin vai trò
            var vaiTro = _vaiTroRepo.GetById(taiKhoan.MaVaiTro);
            if (vaiTro == null)
                throw new Exception($"Lỗi dữ liệu: Không tìm thấy vai trò {taiKhoan.MaVaiTro}.");

            // 4. Ánh xạ (Map) sang DTO
            return new ProfileResponse
            {
                HoTen = nhanVien.HoTen,
                ChucVu = nhanVien.ChucVu,
                SoDienThoai = nhanVien.SoDienThoai,
                Email = nhanVien.Email,
                TenDangNhap = taiKhoan.TenDangNhap,
                TenVaiTro = vaiTro.TenVaiTro
            };
        }

        /// <summary>
        /// Xử lý logic đổi mật khẩu.
        /// </summary>
        public bool ChangePassword(ChangePasswordRequest request)
        {
            // 1. Lấy tài khoản
            var taiKhoan = _taiKhoanRepo.GetByTenDangNhap(request.TenDangNhap);
            if (taiKhoan == null)
            {
                // Về mặt lý thuyết, người dùng đã đăng nhập nên không thể xảy ra lỗi này
                throw new Exception("Lỗi: Không tìm thấy tài khoản để đổi mật khẩu.");
            }

            // 2. Xác thực mật khẩu cũ
            bool isOldPasswordValid = PasswordHasher.Verify(request.OldPassword, taiKhoan.MatKhau);
            if (!isOldPasswordValid)
            {
                throw new Exception("Mật khẩu cũ không chính xác. Vui lòng thử lại.");
            }

            // 3. Băm mật khẩu mới
            string newHashedPassword = PasswordHasher.Hash(request.NewPassword);

            // 4. Cập nhật mật khẩu mới vào DB
            return _taiKhoanRepo.UpdatePassword(request.TenDangNhap, newHashedPassword);
        }

        public string ResetPassword(string tenDangNhap)
        {
            // 1. Tìm tài khoản
            var taiKhoan = _taiKhoanRepo.GetByTenDangNhap(tenDangNhap);
            if (taiKhoan == null)
            {
                throw new Exception("Không tìm thấy tài khoản với tên đăng nhập này.");
            }

            // 2. Lấy Email từ NhanVien
            var nhanVien = _nhanVienRepo.GetById(taiKhoan.MaNV);
            if (nhanVien == null || string.IsNullOrEmpty(nhanVien.Email))
            {
                throw new Exception("Tài khoản này không liên kết với nhân viên hoặc nhân viên không có Email.");
            }

            // 3. TẠO MẬT KHẨU NGẪU NHIÊN (dạng văn bản thuần)
            string newTempPassword = GenerateRandomPassword(8);

            // 4. BĂM MẬT KHẨU NGẪU NHIÊN đó
            string newHashedPassword = PasswordHasher.Hash(newTempPassword);

            // 5. Cập nhật mật khẩu ĐÃ BĂM vào CSDL
            bool updated = _taiKhoanRepo.UpdatePassword(tenDangNhap, newHashedPassword);
            if (!updated)
            {
                throw new Exception("Lỗi hệ thống: Không thể cập nhật mật khẩu mới.");
            }

            // 6. Gửi email chứa mật khẩu NGẪU NHIÊN (dạng văn bản thuần)
            string subject = "Yêu cầu khôi phục mật khẩu BagShop";
            string body = $"Xin chào {nhanVien.HoTen},\n\n" +
                          $"Mật khẩu mới của bạn cho tài khoản '{tenDangNhap}' là:\n\n" +
                          $"{newTempPassword}\n\n" + // <== Gửi mật khẩu thuần
                          $"Vui lòng đăng nhập và đổi mật khẩu này ngay lập tức.";

            _emailService.SendEmail(nhanVien.Email, subject, body);

            return $"Một mật khẩu tạm thời đã được gửi tới email: {nhanVien.Email}.";
        }

        // Hàm helper tạo mật khẩu ngẫu nhiên
        private string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghkmnpqrstuvwxyz23456789";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[rnd.Next(chars.Length)]);
            }
            return sb.ToString();
        }
    }
}
