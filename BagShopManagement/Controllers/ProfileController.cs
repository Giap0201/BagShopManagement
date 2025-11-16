using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class ProfileController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor: Service sẽ được inject (tiêm) vào đây.
        /// </summary>
        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Lấy thông tin chi tiết của người dùng đang đăng nhập.
        /// Được gọi bởi: ucProfile.
        /// </summary>
        /// <param name="maNV">Mã NV (lấy từ UserContext.MaNV).</param>
        public ProfileResponse HandleGetProfile(string maNV)
        {
            try
            {
                // Gọi thẳng service
                return _userService.GetProfile(maNV);
            }
            catch (Exception ex)
            {
                // Ném lỗi ra cho View (ucProfile) xử lý
                // (ví dụ: lỗi dữ liệu không tìm thấy nhân viên/tài khoản)
                throw; // Re-throw lỗi gốc
            }
        }

        /// <summary>
        /// Xử lý yêu cầu đổi mật khẩu cá nhân.
        /// Được gọi bởi: ucProfile.
        /// </summary>
        public bool HandleChangePassword(ChangePasswordRequest request)
        {
            try
            {
                // UserService sẽ xử lý logic (check mật khẩu cũ, hash mật khẩu mới, update)
                return _userService.ChangePassword(request);
            }
            catch (Exception ex)
            {
                // Ném lỗi nghiệp vụ (ví dụ: "Mật khẩu cũ không chính xác")
                // ra cho View (ucProfile) xử lý
                throw; // Re-throw lỗi gốc
            }
        }

        public string HandleResetPassword(string tenDangNhap)
        {
            try
            {
                // Gọi service. Service sẽ xử lý mọi logic
                return _userService.ResetPassword(tenDangNhap);
            }
            catch (Exception ex)
            {
                // Ném lỗi nghiệp vụ (ví dụ: "Không tìm thấy tài khoản") ra cho Form
                throw;
            }
        }
    }
}
