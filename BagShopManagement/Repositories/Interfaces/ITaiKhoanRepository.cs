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
        bool UpdatePassword(string tenDangNhap, string newHashedPassword);

        /// <summary>
        /// Thêm tài khoản mới (không transaction).
        /// </summary>
        void Add(TaiKhoan taiKhoan);

        /// <summary>
        /// Cập nhật tài khoản (không transaction).
        /// </summary>
        void Update(TaiKhoan taiKhoan);

        // --- PHIÊN BẢN TRANSACTION ---

        /// <summary>
        /// Thêm tài khoản mới như một phần của Transaction.
        /// </summary>
        void Add(TaiKhoan taiKhoan, SqlConnection conn, SqlTransaction tran);

        /// <summary>
        /// Cập nhật tài khoản như một phần của Transaction.
        /// </summary>
        void Update(TaiKhoan taiKhoan, SqlConnection conn, SqlTransaction tran);

        /// <summary>
        /// Kiểm tra Tên đăng nhập đã tồn tại chưa.
        /// </summary>
        bool ExistsByTenDangNhap(string tenDangNhap);
    }
}
