// Repositories/Implementations/SanPhamRepository.cs
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BagShopManagement.Repositories.Implementations
{
    public class SanPhamRepository : ISanPhamRepository
    {
        public List<SanPham> GetAll()
        {
            var list = new List<SanPham>();
            var dt = DataAccess.DataAccessBase.ExecuteQuery("SELECT * FROM SanPham");
            foreach (DataRow r in dt.Rows) list.Add(Map(r));
            return list;
        }

        public SanPham? GetByMaSP(string maSP)
        {
            var dt = DataAccess.DataAccessBase.ExecuteQuery(
                "SELECT * FROM SanPham WHERE MaSP = @MaSP",
                new SqlParameter("@MaSP", maSP));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public void Update(SanPham sp)
        {
            DataAccess.DataAccessBase.ExecuteNonQuery(
                @"UPDATE SanPham SET TenSP=@TenSP, GiaNhap=@GiaNhap, GiaBan=@GiaBan, SoLuongTon=@SoLuongTon,
                  MoTa=@MoTa, AnhChinh=@AnhChinh, MaLoaiTui=@MaLoaiTui, MaThuongHieu=@MaThuongHieu, MaChatLieu=@MaChatLieu,
                  MaMau=@MaMau, MaKichThuoc=@MaKichThuoc, MaNCC=@MaNCC, TrangThai=@TrangThai, NgayTao=@NgayTao
                  WHERE MaSP=@MaSP",
                new SqlParameter("@TenSP", sp.TenSP ?? ""),
                new SqlParameter("@GiaNhap", sp.GiaNhap),
                new SqlParameter("@GiaBan", sp.GiaBan),
                new SqlParameter("@SoLuongTon", sp.SoLuongTon),
                new SqlParameter("@MoTa", (object?)sp.MoTa ?? DBNull.Value),
                new SqlParameter("@AnhChinh", (object?)sp.AnhChinh ?? DBNull.Value),
                new SqlParameter("@MaLoaiTui", (object?)sp.MaLoaiTui ?? DBNull.Value),
                new SqlParameter("@MaThuongHieu", (object?)sp.MaThuongHieu ?? DBNull.Value),
                new SqlParameter("@MaChatLieu", (object?)sp.MaChatLieu ?? DBNull.Value),
                new SqlParameter("@MaMau", (object?)sp.MaMau ?? DBNull.Value),
                new SqlParameter("@MaKichThuoc", (object?)sp.MaKichThuoc ?? DBNull.Value),
                new SqlParameter("@MaNCC", (object?)sp.MaNCC ?? DBNull.Value),
                new SqlParameter("@TrangThai", sp.TrangThai),
                new SqlParameter("@NgayTao", sp.NgayTao),
                new SqlParameter("@MaSP", sp.MaSP)
            );
        }

        private SanPham Map(DataRow r)
        {
            return new SanPham
            {
                MaSP = r["MaSP"]?.ToString() ?? string.Empty,
                TenSP = r["TenSP"]?.ToString() ?? string.Empty,
                GiaNhap = r.Field<decimal?>("GiaNhap") ?? 0m,
                GiaBan = r.Field<decimal?>("GiaBan") ?? 0m,
                SoLuongTon = r.Field<int?>("SoLuongTon") ?? 0,
                MoTa = r["MoTa"]?.ToString(),
                AnhChinh = r["AnhChinh"]?.ToString(),
                MaLoaiTui = r["MaLoaiTui"]?.ToString(),
                MaThuongHieu = r["MaThuongHieu"]?.ToString(),
                MaChatLieu = r["MaChatLieu"]?.ToString(),
                MaMau = r["MaMau"]?.ToString(),
                MaKichThuoc = r["MaKichThuoc"]?.ToString(),
                MaNCC = r["MaNCC"]?.ToString(),
                TrangThai = r.Field<bool?>("TrangThai") ?? true,
                NgayTao = r.Field<DateTime?>("NgayTao") ?? DateTime.Now
            };
        }
    }
}
