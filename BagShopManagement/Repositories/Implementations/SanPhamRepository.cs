using BagShopManagement.DataAccess;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace BagShopManagement.Repositories.Implementations
{
    public class SanPhamRepository : BaseRepository, ISanPhamRepository
    {
        private SanPham Map(DataRow r) => new SanPham
        {
            MaSP = r["MaSP"]?.ToString(),
            TenSP = r["TenSP"]?.ToString(),
            GiaNhap = r["GiaNhap"] != DBNull.Value ? Convert.ToDecimal(r["GiaNhap"], CultureInfo.InvariantCulture) : 0,
            GiaBan = r["GiaBan"] != DBNull.Value ? Convert.ToDecimal(r["GiaBan"], CultureInfo.InvariantCulture) : 0,
            SoLuongTon = r["SoLuongTon"] != DBNull.Value ? Convert.ToInt32(r["SoLuongTon"]) : 0,
            MoTa = r["MoTa"]?.ToString(),
            AnhChinh = r["AnhChinh"]?.ToString(),
            MaLoaiTui = r["MaLoaiTui"]?.ToString(),
            MaThuongHieu = r["MaThuongHieu"]?.ToString(),
            MaChatLieu = r["MaChatLieu"]?.ToString(),
            MaMau = r["MaMau"]?.ToString(),
            MaKichThuoc = r["MaKichThuoc"]?.ToString(),
            MaNCC = r["MaNCC"]?.ToString(),
            TrangThai = r["TrangThai"] != DBNull.Value && (bool)r["TrangThai"],
            NgayTao = r["NgayTao"] != DBNull.Value ? Convert.ToDateTime(r["NgayTao"]) : DateTime.Now
        };

        public List<SanPham> GetAll()
        {
            var dt = ExecuteQuery("SELECT * FROM SanPham ORDER BY MaSP");
            return dt.AsEnumerable().Select(Map).ToList();
        }

        public SanPham GetById(string maSP)
        {
            var dt = ExecuteQuery("SELECT * FROM SanPham WHERE MaSP=@ma",
                new SqlParameter("@ma", maSP));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public bool Add(SanPham sp)
        {
            string q = @"INSERT INTO SanPham 
(MaSP, TenSP, GiaNhap, GiaBan, SoLuongTon, MoTa, AnhChinh, MaLoaiTui, MaThuongHieu, MaChatLieu, MaMau, MaKichThuoc, MaNCC, TrangThai, NgayTao)
VALUES (@MaSP, @TenSP, @GiaNhap, @GiaBan, @SoLuongTon, @MoTa, @AnhChinh, @MaLoaiTui, @MaThuongHieu, @MaChatLieu, @MaMau, @MaKichThuoc, @MaNCC, @TrangThai, @NgayTao)";
            var p = new[]
            {
                new SqlParameter("@MaSP", sp.MaSP),
                new SqlParameter("@TenSP", sp.TenSP),
                new SqlParameter("@GiaNhap", sp.GiaNhap),
                new SqlParameter("@GiaBan", sp.GiaBan),
                new SqlParameter("@SoLuongTon", sp.SoLuongTon),
                new SqlParameter("@MoTa", sp.MoTa ?? (object)DBNull.Value),
                new SqlParameter("@AnhChinh", sp.AnhChinh ?? (object)DBNull.Value),
                new SqlParameter("@MaLoaiTui", sp.MaLoaiTui ?? (object)DBNull.Value),
                new SqlParameter("@MaThuongHieu", sp.MaThuongHieu ?? (object)DBNull.Value),
                new SqlParameter("@MaChatLieu", sp.MaChatLieu ?? (object)DBNull.Value),
                new SqlParameter("@MaMau", sp.MaMau ?? (object)DBNull.Value),
                new SqlParameter("@MaKichThuoc", sp.MaKichThuoc ?? (object)DBNull.Value),
                new SqlParameter("@MaNCC", sp.MaNCC ?? (object)DBNull.Value),
                new SqlParameter("@TrangThai", sp.TrangThai),
                new SqlParameter("@NgayTao", sp.NgayTao)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Update(SanPham sp)
        {
            string q = @"UPDATE SanPham SET 
TenSP=@TenSP, GiaNhap=@GiaNhap, GiaBan=@GiaBan, SoLuongTon=@SoLuongTon,
MoTa=@MoTa, AnhChinh=@AnhChinh, MaLoaiTui=@MaLoaiTui, MaThuongHieu=@MaThuongHieu, 
MaChatLieu=@MaChatLieu, MaMau=@MaMau, MaKichThuoc=@MaKichThuoc, MaNCC=@MaNCC, 
TrangThai=@TrangThai, NgayTao=@NgayTao WHERE MaSP=@MaSP";
            var p = new[]
            {
                new SqlParameter("@TenSP", sp.TenSP),
                new SqlParameter("@GiaNhap", sp.GiaNhap),
                new SqlParameter("@GiaBan", sp.GiaBan),
                new SqlParameter("@SoLuongTon", sp.SoLuongTon),
                new SqlParameter("@MoTa", sp.MoTa ?? (object)DBNull.Value),
                new SqlParameter("@AnhChinh", sp.AnhChinh ?? (object)DBNull.Value),
                new SqlParameter("@MaLoaiTui", sp.MaLoaiTui ?? (object)DBNull.Value),
                new SqlParameter("@MaThuongHieu", sp.MaThuongHieu ?? (object)DBNull.Value),
                new SqlParameter("@MaChatLieu", sp.MaChatLieu ?? (object)DBNull.Value),
                new SqlParameter("@MaMau", sp.MaMau ?? (object)DBNull.Value),
                new SqlParameter("@MaKichThuoc", sp.MaKichThuoc ?? (object)DBNull.Value),
                new SqlParameter("@MaNCC", sp.MaNCC ?? (object)DBNull.Value),
                new SqlParameter("@TrangThai", sp.TrangThai),
                new SqlParameter("@NgayTao", sp.NgayTao),
                new SqlParameter("@MaSP", sp.MaSP)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Delete(string maSP)
        {
            string q = "DELETE FROM SanPham WHERE MaSP=@MaSP";
            return ExecuteNonQuery(q, new SqlParameter("@MaSP", maSP)) > 0;
        }

        public List<SanPham> Search(string keyword)
        {
            string q = "SELECT * FROM SanPham WHERE MaSP LIKE @kw OR TenSP LIKE @kw ORDER BY MaSP";
            var dt = ExecuteQuery(q, new SqlParameter("@kw", $"%{keyword}%"));
            return dt.AsEnumerable().Select(Map).ToList();
        }

        public string GetMaxCode()
        {
            var dt = ExecuteQuery("SELECT MAX(MaSP) AS MaxCode FROM SanPham");
            if (dt.Rows.Count == 0 || dt.Rows[0]["MaxCode"] == DBNull.Value)
                return null;
            return dt.Rows[0]["MaxCode"].ToString();
        }
    }
}
