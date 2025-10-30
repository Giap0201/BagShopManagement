using BagShopManagement.DataAccess;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Implementations
{
    internal class KhachHangRepository : BaseRepository, IKhachHangRepository
    {
         public List<KhachHang> GetAll()
        {
            string query = "SELECT * FROM KhachHang";
            DataTable dt = ExecuteQuery(query);

            List<KhachHang> list = new List<KhachHang>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapKhachHang(row));
            }
            return list;
        }

        public KhachHang? GetById(string maKH)
        {
            string query = "SELECT * FROM KhachHang WHERE MaKH = @MaKH";
            SqlParameter p = new SqlParameter("@MaKH", maKH);
            DataTable dt = ExecuteQuery(query, p);

            if (dt.Rows.Count == 0) return null;
            return MapKhachHang(dt.Rows[0]);
        }

        public int Add(KhachHang kh)
        {
            string query = @"INSERT INTO KhachHang (MaKH, HoTen, SoDienThoai, Email, DiaChi, DiemTichLuy)
                             VALUES (@MaKH, @HoTen, @SoDienThoai, @Email, @DiaChi, @DiemTichLuy)";
            return ExecuteNonQuery(query,
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@HoTen", kh.HoTen),
                new SqlParameter("@SoDienThoai", kh.SoDienThoai ?? (object)DBNull.Value),
                new SqlParameter("@Email", kh.Email ?? (object)DBNull.Value),
                new SqlParameter("@DiaChi", kh.DiaChi ?? (object)DBNull.Value),
                new SqlParameter("@DiemTichLuy", kh.DiemTichLuy)
            );
        }

        public int Update(KhachHang kh)
        {
            string query = @"UPDATE KhachHang 
                             SET HoTen=@HoTen, SoDienThoai=@SoDienThoai, Email=@Email, 
                                 DiaChi=@DiaChi, DiemTichLuy=@DiemTichLuy
                             WHERE MaKH=@MaKH";
            return ExecuteNonQuery(query,
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@HoTen", kh.HoTen),
                new SqlParameter("@SoDienThoai", kh.SoDienThoai ?? (object)DBNull.Value),
                new SqlParameter("@Email", kh.Email ?? (object)DBNull.Value),
                new SqlParameter("@DiaChi", kh.DiaChi ?? (object)DBNull.Value),
                new SqlParameter("@DiemTichLuy", kh.DiemTichLuy)
            );
        }

        public int Delete(string maKH)
        {
            string query = "DELETE FROM KhachHang WHERE MaKH=@MaKH";
            return ExecuteNonQuery(query, new SqlParameter("@MaKH", maKH));
        }

        public List<KhachHang> Search(string ten, string sdt, string email)
        {
            string query = @"SELECT * FROM KhachHang 
                             WHERE (@HoTen IS NULL OR HoTen LIKE '%' + @HoTen + '%')
                               AND (@SoDienThoai IS NULL OR SoDienThoai LIKE '%' + @SoDienThoai + '%')
                               AND (@Email IS NULL OR Email LIKE '%' + @Email + '%')";

            DataTable dt = ExecuteQuery(query,
                new SqlParameter("@HoTen", string.IsNullOrEmpty(ten) ? (object)DBNull.Value : ten),
                new SqlParameter("@SoDienThoai", string.IsNullOrEmpty(sdt) ? (object)DBNull.Value : sdt),
                new SqlParameter("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email)
            );

            List<KhachHang> list = new List<KhachHang>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapKhachHang(row));

            return list;
        }

        private KhachHang MapKhachHang(DataRow row)
        {
            return new KhachHang
            {
                MaKH = row["MaKH"].ToString(),
                HoTen = row["HoTen"].ToString(),
                SoDienThoai = row["SoDienThoai"]?.ToString(),
                Email = row["Email"]?.ToString(),
                DiaChi = row["DiaChi"]?.ToString(),
                DiemTichLuy = row["DiemTichLuy"] == DBNull.Value ? 0 : Convert.ToInt32(row["DiemTichLuy"])
            };
        }
    }
}

