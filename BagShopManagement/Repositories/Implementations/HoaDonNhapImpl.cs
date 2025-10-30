using BagShopManagement.DataAccess;
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

        public List<HoaDonNhap> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<HoaDonNhap> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
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