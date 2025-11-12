using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class LoginController
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Constructor: Service sẽ được inject (tiêm) vào đây.
        /// </summary>
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Phương thức chính được gọi bởi LoginForm.
        /// </summary>
        /// <param name="request">DTO chứa TenDangNhap và MatKhau thô.</param>
        /// <returns>LoginResponse nếu thành công.</returns>
        /// <exception cref="Exception">Ném (throw) lỗi nghiệp vụ (ví dụ: "Sai mật khẩu") 
        /// để LoginForm bắt và hiển thị cho người dùng.</exception>
        public LoginResponse HandleLogin(LoginRequest request)
        {
            try
            {
                // 1. Gọi service. AuthService sẽ xử lý tất cả logic
                // (kiểm tra, băm, xác thực, lấy quyền)
                LoginResponse response = _authService.Login(request);

                // 2. Trả về thông tin cho LoginForm
                return response;
            }
            catch (Exception ex)
            {
                // 3. Nếu AuthService ném lỗi (ví dụ: sai mật khẩu, tài khoản khóa)
                // Ném lỗi đó trở lại LoginForm để hiển thị
                throw;
            }
        }
    }
}
