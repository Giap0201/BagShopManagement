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
    /// <summary>
    /// Triển khai IKhachHangRepository, sử dụng BaseRepository (DataTable)
    /// </summary>
    public class KhachHangRepository : BaseRepository, IKhachHangRepository
    {
        /// <summary>
        /// Helper tạo SqlParameter, xử lý giá trị null
        /// </summary>
        private SqlParameter CreateParameter(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        /// <summary>
        /// Kiểm tra xem một Mã Khách Hàng có tồn tại trong CSDL hay không
        /// </summary>
        public bool Exists(string maKH)
        {
            string query = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH";
            var parameters = new[] { CreateParameter("@MaKH", maKH) };

            try
            {
                // Sử dụng phương thức ExecuteScalar từ BaseRepository
                object result = base.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result) > 0;
                }
                return false;
            }
            catch (Exception)
            {
                // Nếu có lỗi (ví dụ: mất kết nối), coi như là false
                return false;
            }
        }

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

        public string? GetKhachHang(string? maKH)
        {
            if (string.IsNullOrEmpty(maKH))
            {
                return null;
            }
            string query = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH";
            SqlParameter p = new SqlParameter("@MaKH", maKH);
            DataTable dt = ExecuteQuery(query, p);
            if (dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0][0]);
                if (count > 0)
                {
                    return maKH.Trim();
                }
            }
            return null;
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

        /// <summary>
        /// Tìm khách hàng theo số điện thoại
        /// </summary>
        public KhachHang? GetBySDT(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt))
                return null;

            string query = "SELECT * FROM KhachHang WHERE SoDienThoai = @SoDienThoai";
            DataTable dt = ExecuteQuery(query, new SqlParameter("@SoDienThoai", sdt));

            if (dt.Rows.Count > 0)
                return MapKhachHang(dt.Rows[0]);

            return null;
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

        public string GetMaxCode()
        {
            var dt = ExecuteQuery("SELECT MAX(MaKH) AS MaxCode FROM KhachHang");
            if (dt.Rows.Count == 0) return null;

            var obj = dt.Rows[0]["MaxCode"];
            return obj == DBNull.Value ? null : obj.ToString();
        }
        public List<KhachHang> Search(string keyword)
        {
            string q = "SELECT * FROM KhachHang " +
                       "WHERE MaKH LIKE @kw OR HoTen LIKE @kw OR SoDienThoai LIKE @kw " +
                       "ORDER BY MaKH";

            var dt = ExecuteQuery(q, new SqlParameter("@kw", $"%{keyword}%"));

            return dt.AsEnumerable().Select(MapKhachHang).ToList();
        }

    }
}