using BagShopManagement.DataAccess;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BagShopManagement.Repositories.Implementations
{
    public class SanPhamImpl : BaseRepository, ISanPhamRepository
    {
        private SanPham MapToSanPham(DataRow row)
        {
            return new SanPham
            {
                MaSP = row["MaSP"].ToString(),
                TenSP = row["TenSP"].ToString(),
                GiaNhap = row.Field<decimal>("GiaNhap"),
                GiaBan = row.Field<decimal>("GiaBan"),
                SoLuongTon = row.Field<int>("SoLuongTon"),
                MoTa = row["MoTa"]?.ToString(),
                AnhChinh = row["AnhChinh"]?.ToString(),
                MaLoaiTui = row["MaLoaiTui"]?.ToString(),
                MaThuongHieu = row["MaThuongHieu"]?.ToString(),
                MaChatLieu = row["MaChatLieu"]?.ToString(),
                MaMau = row["MaMau"]?.ToString(),
                MaKichThuoc = row["MaKichThuoc"]?.ToString(),
                MaNCC = row["MaNCC"]?.ToString(),
                TrangThai = row.Field<bool>("TrangThai"),
                NgayTao = row.Field<DateTime>("NgayTao")
            };
        }

        public List<SanPham> GetAll()
        {
            string query = "SELECT * FROM SanPham";
            var dt = ExecuteQuery(query);
            var list = new List<SanPham>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToSanPham(row));
            return list;
        }

        public SanPham GetById(string maSP)
        {
            string query = "SELECT * FROM SanPham WHERE MaSP = @MaSP";
            var dt = ExecuteQuery(query, new SqlParameter("@MaSP", maSP));
            if (dt.Rows.Count == 0) return null;
            return MapToSanPham(dt.Rows[0]);
        }

        public bool Add(SanPham sp)
        {
            string query = @"INSERT INTO SanPham (MaSP, TenSP, GiaNhap, GiaBan, SoLuongTon, MoTa, AnhChinh,
                               MaLoaiTui, MaThuongHieu, MaChatLieu, MaMau, MaKichThuoc, MaNCC, TrangThai, NgayTao)
                             VALUES (@MaSP, @TenSP, @GiaNhap, @GiaBan, @SoLuongTon, @MoTa, @AnhChinh,
                               @MaLoaiTui, @MaThuongHieu, @MaChatLieu, @MaMau, @MaKichThuoc, @MaNCC, @TrangThai, @NgayTao)";

            var param = new[]
            {
                new SqlParameter("@MaSP", sp.MaSP),
                new SqlParameter("@TenSP", sp.TenSP),
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
                new SqlParameter("@NgayTao", sp.NgayTao)
            };

            return ExecuteNonQuery(query, param) > 0;
        }

        public bool Update(SanPham sp)
        {
            string query = @"UPDATE SanPham SET TenSP=@TenSP, GiaNhap=@GiaNhap, GiaBan=@GiaBan, SoLuongTon=@SoLuongTon,
                             MoTa=@MoTa, AnhChinh=@AnhChinh, MaLoaiTui=@MaLoaiTui, MaThuongHieu=@MaThuongHieu,
                             MaChatLieu=@MaChatLieu, MaMau=@MaMau, MaKichThuoc=@MaKichThuoc, MaNCC=@MaNCC, TrangThai=@TrangThai
                             WHERE MaSP=@MaSP";

            var param = new[]
            {
                new SqlParameter("@MaSP", sp.MaSP),
                new SqlParameter("@TenSP", sp.TenSP),
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
                new SqlParameter("@TrangThai", sp.TrangThai)
            };

            return ExecuteNonQuery(query, param) > 0;
        }

        public bool Delete(string maSP)
        {
            string query = "DELETE FROM SanPham WHERE MaSP=@MaSP";
            return ExecuteNonQuery(query, new SqlParameter("@MaSP", maSP)) > 0;
        }

        public List<SanPham> Search(string keyword)
        {
            string query = "SELECT * FROM SanPham WHERE TenSP LIKE @kw";
            var dt = ExecuteQuery(query, new SqlParameter("@kw", $"%{keyword}%"));
            var list = new List<SanPham>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToSanPham(row));
            return list;
        }
    }
}