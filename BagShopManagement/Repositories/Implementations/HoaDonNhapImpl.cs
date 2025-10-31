using BagShopManagement.DataAccess;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Implementations
{
    public class HoaDonNhapImpl : BaseRepository, IHoaDonNhapRepository
    {
        public void Add(HoaDonNhap hoaDonNhap)
        {
            string query = "INSERT INTO HoaDonNhap (MaHDN, MaNCC, MaNV, NgayNhap, TongTien, GhiChu) " +
                           "VALUES (@MaHDN, @MaNCC, @MaNV, @NgayNhap, @TongTien, @GhiChu)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDN", hoaDonNhap.MaHDN),
                new SqlParameter("@MaNCC", hoaDonNhap.MaNCC),
                new SqlParameter("@MaNV", hoaDonNhap.MaNV),
                new SqlParameter("@NgayNhap", hoaDonNhap.NgayNhap),
                new SqlParameter("@TongTien", hoaDonNhap.TongTien),
                new SqlParameter("@GhiChu", (object?)hoaDonNhap.GhiChu ?? DBNull.Value)
            };

            base.ExecuteNonQuery(query, parameters);
        }

        public void Delete(string maHDN)
        {
            string query = "DELETE FROM HoaDonNhap WHERE MaHDN = @MaHDN";
            var param = new SqlParameter("@MaHDN", maHDN);
            base.ExecuteNonQuery(query, param);
        }

        public bool Exists(string maHDN)
        {
            string query = "SELECT COUNT(1) FROM HoaDonNhap WHERE MaHDN = @MaHDN";
            var param = new SqlParameter("@MaHDN", maHDN);
            Object result = base.ExecuteScalar(query, param);
            return Convert.ToInt32(result) > 0;
        }

        public HoaDonNhap GetById(string maHDN)
        {
            string query = "SELECT * FROM HoaDonNhap WHERE MaHDN = @MaHDN";
            var param = new SqlParameter("@MaHDN", maHDN);
            DataTable dt = base.ExecuteQuery(query, param);
            if (dt.Rows.Count == 0)
                return null;
            DataRow row = dt.Rows[0];
            return new HoaDonNhap
            {
                MaHDN = row["MaHDN"].ToString(),
                MaNCC = row["MaNCC"].ToString(),
                MaNV = row["MaNV"].ToString(),
                NgayNhap = (DateTime)row["NgayNhap"],
                TongTien = (decimal)row["TongTien"],
                GhiChu = row["GhiChu"]?.ToString()
            };
        }

        public List<HoaDonNhapResponse> Search(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV)
        {
            // 1. Query join các bảng để lấy tên, thay vì chỉ lấy ID
            var queryBuilder = new StringBuilder(@"
                SELECT hdn.MaHDN, ncc.TenNCC, nv.HoTen AS TenNV, hdn.NgayNhap, hdn.TongTien, hdn.GhiChu
                FROM HoaDonNhap hdn
                LEFT JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON hdn.MaNV = nv.MaNV
                WHERE 1=1
            ");

            var parameters = new List<SqlParameter>();

            // 2. Thêm điều kiện lọc động (để tránh SQL Injection)
            if (!string.IsNullOrWhiteSpace(maHDN))
            {
                queryBuilder.Append(" AND hdn.MaHDN LIKE @MaHDN");
                parameters.Add(new SqlParameter("@MaHDN", "%" + maHDN + "%"));
            }

            if (tuNgay.HasValue)
            {
                queryBuilder.Append(" AND hdn.NgayNhap >= @TuNgay");
                parameters.Add(new SqlParameter("@TuNgay", tuNgay.Value.Date)); // Lấy 00:00:00
            }

            if (denNgay.HasValue)
            {
                queryBuilder.Append(" AND hdn.NgayNhap <= @DenNgay");
                // Lấy 23:59:59 của ngày kết thúc
                parameters.Add(new SqlParameter("@DenNgay", denNgay.Value.Date.AddDays(1).AddTicks(-1)));
            }

            if (!string.IsNullOrWhiteSpace(maNCC))
            {
                queryBuilder.Append(" AND hdn.MaNCC = @MaNCC");
                parameters.Add(new SqlParameter("@MaNCC", maNCC));
            }

            if (!string.IsNullOrWhiteSpace(maNV))
            {
                queryBuilder.Append(" AND hdn.MaNV = @MaNV");
                parameters.Add(new SqlParameter("@MaNV", maNV));
            }

            queryBuilder.Append(" ORDER BY hdn.NgayNhap DESC");

            // 3. Thực thi query
            DataTable dt = base.ExecuteQuery(queryBuilder.ToString(), parameters.ToArray());

            // 4. Map kết quả sang DTO
            var list = new List<HoaDonNhapResponse>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new HoaDonNhapResponse
                {
                    MaHDN = row["MaHDN"].ToString(),
                    TenNCC = row["TenNCC"]?.ToString(),
                    TenNV = row["TenNV"]?.ToString(),
                    NgayNhap = (DateTime)row["NgayNhap"],
                    TongTien = (decimal)row["TongTien"],
                    GhiChu = row["GhiChu"]?.ToString()
                });
            }
            return list;
        }

        public void Update(HoaDonNhap hoaDonNhap)
        {
            string query = "UPDATE HoaDonNhap SET MaNCC = @MaNCC, MaNV = @MaNV, NgayNhap = @NgayNhap, " +
                           "TongTien = @TongTien, GhiChu = @GhiChu WHERE MaHDN = @MaHDN";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", hoaDonNhap.MaNCC),
                new SqlParameter("@MaNV", hoaDonNhap.MaNV),
                new SqlParameter("@NgayNhap", hoaDonNhap.NgayNhap),
                new SqlParameter("@TongTien", hoaDonNhap.TongTien),
                new SqlParameter("@GhiChu", (object?)hoaDonNhap.GhiChu ?? DBNull.Value),
                new SqlParameter("@MaHDN", hoaDonNhap.MaHDN)
            };
            base.ExecuteNonQuery(query, parameters);
        }
    }
}