// Repositories/Implementations/SanPhamRepository.cs
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BagShopManagement.Repositories.Implementations
{
    public class SanPhamRepository : BaseRepository, ISanPhamRepository
    {
        public List<SanPham> GetAll()
        {
            string query = "SELECT * FROM SanPham";
            return ExecuteQuery(query, null, MapFromReader);
        }

        public SanPham? GetByMaSP(string maSP)
        {
            string query = "SELECT * FROM SanPham WHERE MaSP = @MaSP";
            var parameters = new[] { CreateParameter("@MaSP", maSP) };
            var results = ExecuteQuery(query, parameters, MapFromReader);
            return results.Count > 0 ? results[0] : null;
        }

        public void Update(SanPham sp)
        {
            string query = @"UPDATE SanPham SET TenSP=@TenSP, GiaNhap=@GiaNhap, GiaBan=@GiaBan, SoLuongTon=@SoLuongTon,
                  MoTa=@MoTa, AnhChinh=@AnhChinh, MaLoaiTui=@MaLoaiTui, MaThuongHieu=@MaThuongHieu, MaChatLieu=@MaChatLieu,
                  MaMau=@MaMau, MaKichThuoc=@MaKichThuoc, MaNCC=@MaNCC, TrangThai=@TrangThai, NgayTao=@NgayTao
                  WHERE MaSP=@MaSP";

            var parameters = new[]
            {
                CreateParameter("@TenSP", sp.TenSP ?? ""),
                CreateParameter("@GiaNhap", sp.GiaNhap),
                CreateParameter("@GiaBan", sp.GiaBan),
                CreateParameter("@SoLuongTon", sp.SoLuongTon),
                CreateParameter("@MoTa", sp.MoTa),
                CreateParameter("@AnhChinh", sp.AnhChinh),
                CreateParameter("@MaLoaiTui", sp.MaLoaiTui),
                CreateParameter("@MaThuongHieu", sp.MaThuongHieu),
                CreateParameter("@MaChatLieu", sp.MaChatLieu),
                CreateParameter("@MaMau", sp.MaMau),
                CreateParameter("@MaKichThuoc", sp.MaKichThuoc),
                CreateParameter("@MaNCC", sp.MaNCC),
                CreateParameter("@TrangThai", sp.TrangThai),
                CreateParameter("@NgayTao", sp.NgayTao),
                CreateParameter("@MaSP", sp.MaSP)
            };

            ExecuteNonQuery(query, parameters);
        }

        // Map từ SqlDataReader thay vì DataRow
        private SanPham MapFromReader(SqlDataReader reader)
        {
            return new SanPham
            {
                MaSP = GetString(reader, "MaSP"),
                TenSP = GetString(reader, "TenSP"),
                GiaNhap = GetDecimal(reader, "GiaNhap"),
                GiaBan = GetDecimal(reader, "GiaBan"),
                SoLuongTon = GetInt(reader, "SoLuongTon"),
                MoTa = GetValue<string>(reader, "MoTa"),
                AnhChinh = GetValue<string>(reader, "AnhChinh"),
                MaLoaiTui = GetValue<string>(reader, "MaLoaiTui"),
                MaThuongHieu = GetValue<string>(reader, "MaThuongHieu"),
                MaChatLieu = GetValue<string>(reader, "MaChatLieu"),
                MaMau = GetValue<string>(reader, "MaMau"),
                MaKichThuoc = GetValue<string>(reader, "MaKichThuoc"),
                MaNCC = GetValue<string>(reader, "MaNCC"),
                TrangThai = GetBool(reader, "TrangThai"),
                NgayTao = GetDateTime(reader, "NgayTao") ?? DateTime.Now
            };
        }

        // Giữ lại Map cũ cho backward compatibility (nếu cần)
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
