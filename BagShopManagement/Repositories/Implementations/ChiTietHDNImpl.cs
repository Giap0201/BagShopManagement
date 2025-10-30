using BagShopManagement.DataAccess;
using BagShopManagement.DTOs.Responses;
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
    public class ChiTietHDNImpl : BaseRepository, IChiTietHDNRepository
    {
        public void Add(ChiTietHoaDonNhap chiTiet)
        {
            string query = "INSERT INTO ChiTietHoaDonNhap (MaHDN, MaSP, SoLuong, DonGia) " +
                           "VALUES (@MaHDN, @MaSP, @SoLuong, @DonGia)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDN", chiTiet.MaHDN),
                new SqlParameter("@MaSP", chiTiet.MaSP),
                new SqlParameter("@SoLuong", chiTiet.SoLuong),
                new SqlParameter("@DonGia", chiTiet.DonGia)
            };
            base.ExecuteNonQuery(query, parameters);
        }

        public void Delete(string maHDN, string maSP)
        {
            string query = "DELETE FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN AND MaSP = @MaSP";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDN", maHDN),
                new SqlParameter("@MaSP", maSP)
            };
            base.ExecuteNonQuery(query, parameters);
        }

        public void DeleteByMaHDN(string maHDN)
        {
            string query = "DELETE FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN";
            var param = new SqlParameter("@MaHDN", maHDN);
            base.ExecuteNonQuery(query, param);
        }

        public List<ChiTietHoaDonNhap> GetByMaHDN(string maHDN)
        {
            string query = "SELECT MaHDN, MaSP, SoLuong, DonGia FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN";
            var param = new SqlParameter("@MaHDN", maHDN);
            DataTable dt = base.ExecuteQuery(query, param);
            var list = new List<ChiTietHoaDonNhap>();
            foreach (DataRow row in dt.Rows)
            {
                var chiTiet = new ChiTietHoaDonNhap
                {
                    MaHDN = row["MaHDN"].ToString(),
                    MaSP = row["MaSP"].ToString(),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"])
                };
                list.Add(chiTiet);
            }
            return list;
        }

        public List<ChiTietHDNResponse> GetDetailsByMaHDN(string maHDN)
        {
            string query = @"
                SELECT cthdn.MaHDN, cthdn.MaSP, sp.TenSP, cthdn.SoLuong, cthdn.DonGia
                FROM ChiTietHoaDonNhap cthdn
                LEFT JOIN SanPham sp ON cthdn.MaSP = sp.MaSP
                WHERE cthdn.MaHDN = @MaHDN";
            var param = new SqlParameter("@MaHDN", maHDN);
            DataTable dt = base.ExecuteQuery(query, param);
            var list = new List<ChiTietHDNResponse>();
            foreach (DataRow row in dt.Rows)
            {
                var chiTiet = new ChiTietHDNResponse
                {
                    MaHDN = row["MaHDN"].ToString(),
                    MaSP = row["MaSP"].ToString(),
                    TenSP = row["TenSP"].ToString(),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"]),
                    ThanhTien = Convert.ToInt32(row["SoLuong"]) * Convert.ToDecimal(row["DonGia"])
                };
                list.Add(chiTiet);
            }
            return list;
        }

        public void Update(ChiTietHoaDonNhap chiTiet)
        {
            throw new NotImplementedException();
        }
    }
}