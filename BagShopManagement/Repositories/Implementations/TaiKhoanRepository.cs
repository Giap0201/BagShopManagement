using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Implementations
{
    public class TaiKhoanRepository : BaseRepository, ITaiKhoanRepository
    {
        // Helper map dữ liệu
        private TaiKhoan MapToTaiKhoan(DataRow row)
        {
            return new TaiKhoan
            {
                TenDangNhap = row["TenDangNhap"].ToString(),
                MatKhau = row["MatKhau"].ToString(),
                // Kiểm tra DBNull
                MaNV = row["MaNV"] != DBNull.Value ? row["MaNV"].ToString() : null,

                // SỬA LỖI TẠI ĐÂY: Chuyển sang ToString() thay vì Convert.ToInt32()
                // Vì Model TaiKhoan đang định nghĩa MaVaiTro là string
                MaVaiTro = row["MaVaiTro"] != DBNull.Value ? row["MaVaiTro"].ToString() : null,

                TrangThai = Convert.ToBoolean(row["TrangThai"])
            };
        }

        public TaiKhoan GetByTenDangNhap(string tenDangNhap)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] p = { new SqlParameter("@TenDangNhap", tenDangNhap) };

            DataTable dt = ExecuteQuery(query, p);
            return dt.Rows.Count > 0 ? MapToTaiKhoan(dt.Rows[0]) : null;
        }

        public TaiKhoan GetByMaNV(string maNV)
        {
            string query = "SELECT * FROM TaiKhoan WHERE MaNV = @MaNV";
            SqlParameter[] p = { new SqlParameter("@MaNV", maNV) };

            DataTable dt = ExecuteQuery(query, p);
            return dt.Rows.Count > 0 ? MapToTaiKhoan(dt.Rows[0]) : null;
        }

        public bool UpdatePassword(string tenDangNhap, string newHashedPassword)
        {
            string query = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE TenDangNhap = @TenDangNhap";
            int rows = ExecuteNonQuery(query,
                new SqlParameter("@MatKhau", newHashedPassword),
                new SqlParameter("@TenDangNhap", tenDangNhap));
            return rows > 0;
        }

        public bool ExistsByTenDangNhap(string tenDangNhap)
        {
            string query = "SELECT COUNT(1) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            object result = ExecuteScalar(query, new SqlParameter("@TenDangNhap", tenDangNhap));
            return result != null && Convert.ToInt32(result) > 0;
        }

        public void Add(TaiKhoan taiKhoan)
        {
            string query = @"INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNV, MaVaiTro, TrangThai) 
                             VALUES (@User, @Pass, @MaNV, @Role, @Status)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@User", taiKhoan.TenDangNhap),
                new SqlParameter("@Pass", taiKhoan.MatKhau),
                new SqlParameter("@MaNV", (object)taiKhoan.MaNV ?? DBNull.Value),
                // MaVaiTro giờ là string, nên truyền trực tiếp hoặc DBNull nếu null
                new SqlParameter("@Role", (object)taiKhoan.MaVaiTro ?? DBNull.Value),
                new SqlParameter("@Status", taiKhoan.TrangThai)
            };

            ExecuteNonQuery(query, parameters);
        }

        public void Update(TaiKhoan taiKhoan)
        {
            string query = @"UPDATE TaiKhoan 
                             SET MaVaiTro = @Role, TrangThai = @Status, MaNV = @MaNV
                             WHERE TenDangNhap = @User";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Role", (object)taiKhoan.MaVaiTro ?? DBNull.Value),
                new SqlParameter("@Status", taiKhoan.TrangThai),
                new SqlParameter("@MaNV", (object)taiKhoan.MaNV ?? DBNull.Value),
                new SqlParameter("@User", taiKhoan.TenDangNhap)
            };

            ExecuteNonQuery(query, parameters);
        }
    }
}
