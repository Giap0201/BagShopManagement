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
    public class AuthService : IAuthService
    {
        // AuthService cần nói chuyện với nhiều repository để hoàn thành 1 nghiệp vụ
        private readonly ITaiKhoanRepository _taiKhoanRepo;
        private readonly INhanVienRepository _nhanVienRepo;
        private readonly IQuyenRepository _quyenRepo;

        /// <summary>
        /// Constructor (sử dụng Dependency Injection).
        /// </summary>
        public AuthService(
            ITaiKhoanRepository taiKhoanRepo,
            INhanVienRepository nhanVienRepo,
            IQuyenRepository quyenRepo)
        {
            _taiKhoanRepo = taiKhoanRepo;
            _nhanVienRepo = nhanVienRepo;
            _quyenRepo = quyenRepo;
        }

        /// <summary>
        /// Xử lý logic đăng nhập theo các bước:
        /// 1. Tìm tài khoản.
        /// 2. Kiểm tra trạng thái.
        /// 3. Xác thực mật khẩu đã băm.
        /// 4. Lấy thông tin nhân viên (Họ tên).
        /// 5. Lấy danh sách quyền.
        /// </summary>
        public LoginResponse Login(LoginRequest request)
        {
            // 1. Gọi ITaiKhoanRepository.GetByTenDangNhap
            var taiKhoan = _taiKhoanRepo.GetByTenDangNhap(request.TenDangNhap);

            if (taiKhoan == null)
            {
                // Ném lỗi. Controller sẽ bắt và hiển thị cho View
                throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }

            // 2. Kiểm tra tài khoản có bị khóa không
            if (!taiKhoan.TrangThai)
            {
                throw new Exception("Tài khoản này hiện đã bị khóa. Vui lòng liên hệ quản trị viên.");
            }

            // 3. Gọi PasswordHasher.Verify
            // So sánh mật khẩu thô (request.MatKhau) với mật khẩu đã băm (taiKhoan.MatKhau)
            bool isPasswordValid = PasswordHasher.Verify(request.MatKhau, taiKhoan.MatKhau);

            if (!isPasswordValid)
            {
                throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }

            // 4. Lấy thông tin NhanVien (để lấy Họ Tên)
            var nhanVien = _nhanVienRepo.GetById(taiKhoan.MaNV);
            if (nhanVien == null)
            {
                // Trường hợp lỗi dữ liệu: Có tài khoản nhưng không có nhân viên
                throw new Exception($"Lỗi dữ liệu: Không tìm thấy nhân viên (MaNV: {taiKhoan.MaNV}) liên kết với tài khoản này.");
            }

            // 5. Gọi IQuyenRepository.GetQuyenByMaVaiTro
            var quyenList = _quyenRepo.GetQuyenByMaVaiTro(taiKhoan.MaVaiTro);

            // Chuyển danh sách đối tượng Quyen thành danh sách string (MaQuyen)
            var maQuyenList = quyenList.Select(q => q.MaQuyen).ToList();

            // 6. Tạo LoginResponse và trả về
            // Đăng nhập thành công
            return new LoginResponse
            {
                MaNV = nhanVien.MaNV,
                HoTen = nhanVien.HoTen,
                MaVaiTro = taiKhoan.MaVaiTro,
                MaQuyenList = maQuyenList
            };
        }
    }
}
