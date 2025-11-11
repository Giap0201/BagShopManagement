using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BagShopManagement.Repositories.Implementations
{
    /// <summary>
    /// Repository xử lý truy cập dữ liệu cho bảng SanPham
    /// Kế thừa từ BaseRepository để sử dụng các methods chung
    /// </summary>
    public class SanPhamRepository : BaseRepository_2, ISanPhamRepository
    {
        /// <summary>
        /// Lấy tất cả sản phẩm trong database
        /// </summary>
        public List<SanPham> GetAll()
        {
            string query = "SELECT * FROM SanPham";
            return ExecuteQuery(query, null, MapFromReader);
        }

        /// <summary>
        /// Lấy sản phẩm theo mã sản phẩm
        /// </summary>
        /// <param name="maSP">Mã sản phẩm cần tìm</param>
        /// <returns>SanPham nếu tìm thấy, null nếu không tồn tại</returns>
        public SanPham? GetByMaSP(string maSP)
        {
            string query = "SELECT * FROM SanPham WHERE MaSP = @MaSP";
            var parameters = new[] { CreateParameter("@MaSP", maSP) };
            var results = ExecuteQuery(query, parameters, MapFromReader);
            return results.Count > 0 ? results[0] : null;
        }

        /// <summary>
        /// Cập nhật thông tin sản phẩm
        /// </summary>
        /// <param name="sp">Đối tượng SanPham chứa thông tin mới</param>
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

        /// <summary>
        /// Map từ SqlDataReader sang đối tượng SanPham
        /// Sử dụng helper methods từ BaseRepository (GetString, GetInt, GetDecimal...)
        /// </summary>
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
    }
}
