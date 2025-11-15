using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Lấy thông tin chi tiết cho màn hình Profile.
        /// </summary>
        /// <param name="maNV">Mã nhân viên (lấy từ UserContext).</param>
        /// <returns>DTO chứa thông tin tổng hợp.</returns>
        ProfileResponse GetProfile(string maNV);

        /// <summary>
        /// Xử lý logic đổi mật khẩu cá nhân.
        /// </summary>
        /// <param name="request">Thông tin mật khẩu cũ và mới.</param>
        /// <returns>True nếu đổi thành công.</returns>
        /// <exception cref="System.Exception">Ném lỗi nếu mật khẩu cũ sai.</exception>
        bool ChangePassword(ChangePasswordRequest request);

        string ResetPassword(string tenDangNhap);
    }
}
