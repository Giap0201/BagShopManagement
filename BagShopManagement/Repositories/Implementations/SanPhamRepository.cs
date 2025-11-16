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
            string query = "SELECT * FROM SanPham ORDER BY MaSP";
            var dt = ExecuteQuery(query);
            var list = new List<SanPham>();
            foreach (DataRow row in dt.Rows)
                list.Add(Map(row));
            return list;
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

        public int GetTonKho(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                return 0;

            try
            {
                string query = "select SoLuongTon from SanPham where MaSP = @MaSP";
                var dt = ExecuteQuery(query, new SqlParameter("@MaSP", maSP));
                if (dt.Rows.Count == 0) return 0;
                object value = dt.Rows[0]["SoLuongTon"];
                if (value == null || value == DBNull.Value) return 0;
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        public List<SanPham> GetAvailableProducts(string maCTGG)
        {
            var list = new List<SanPham>();
            string query = @"SELECT s.MaSP, s.TenSP, s.SoLuongTon 
                             FROM SanPham s
                             WHERE s.MaSP NOT IN (SELECT ct.MaSP FROM ChiTietGiamGia ct WHERE ct.MaCTGG = @MaCTGG)";

            var parameter = new SqlParameter("@MaCTGG", maCTGG);

            // Sử dụng phương thức ExecuteQuery từ lớp cha BaseRepository
            DataTable data = ExecuteQuery(query, parameter);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new SanPham
                {
                    MaSP = row["MaSP"].ToString(),
                    TenSP = row["TenSP"].ToString(),
                    SoLuongTon = Convert.ToInt32(row["SoLuongTon"])
                });
            }
            return list;
        }

        //public SanPham GetById(string maSP)
        //{
        //    string query = "SELECT MaSP, TenSP, SoLuongTon FROM SanPham WHERE MaSP = @MaSP";
        //    var dt = ExecuteQuery(query, new SqlParameter("@MaSP", maSP));
        //    if (dt.Rows.Count == 0) return null;

        //    var row = dt.Rows[0];
        //    return new SanPham
        //    {
        //        MaSP = row["MaSP"].ToString(),
        //        TenSP = row["TenSP"].ToString(),
        //        SoLuongTon = Convert.ToInt32(row["SoLuongTon"])
        //    };
        //}

        public void UpdateSoLuong(string maSP, int soLuongMoi)
        {
            string query = "UPDATE SanPham SET SoLuongTon = @SoLuongMoi WHERE MaSP = @MaSP";
            ExecuteNonQuery(query,
                new SqlParameter("@SoLuongMoi", soLuongMoi),
                new SqlParameter("@MaSP", maSP)
            );
        }


    }
}