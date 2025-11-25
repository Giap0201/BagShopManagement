using BagShopManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface ITaiKhoanRepository
    {
        TaiKhoan GetByTenDangNhap(string tenDangNhap);
        TaiKhoan GetByMaNV(string maNV);

        /// <summary>
        /// Đổi mật khẩu.
        /// </summary>
        bool UpdatePassword(string tenDangNhap, string newHashedPassword);

        /// <summary>
        /// Kiểm tra tồn tại.
        /// </summary>
        bool ExistsByTenDangNhap(string tenDangNhap);

        /// <summary>
        /// Thêm tài khoản mới.
        /// </summary>
        void Add(TaiKhoan taiKhoan);

        /// <summary>
        /// Cập nhật thông tin tài khoản.
        /// </summary>
        void Update(TaiKhoan taiKhoan);
    }
}
