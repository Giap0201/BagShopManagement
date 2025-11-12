using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Xử lý logic đăng nhập, xác thực tài khoản và lấy quyền.
        /// </summary>
        /// <param name="request">Thông tin đăng nhập (Tên, mật khẩu thô).</param>
        /// <returns>Thông tin người dùng đã được xác thực (LoginResponse).</returns>
        /// <exception cref="System.Exception">Ném lỗi nếu tên đăng nhập, mật khẩu sai, hoặc tài khoản bị khóa.</exception>
        LoginResponse Login(LoginRequest request);
    }
}
