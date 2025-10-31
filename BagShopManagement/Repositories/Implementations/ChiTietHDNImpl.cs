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
        public List<ChiTietHoaDonNhap> GetByMaHDN(string maHDN)
        {
            string query = "SELECT * FROM ChiTietHoaDonNhap WHERE MaHDN=@MaHDN";
            var dt = ExecuteQuery(query, new SqlParameter("@MaHDN", maHDN));
            List<ChiTietHoaDonNhap> list = new List<ChiTietHoaDonNhap>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietHoaDonNhap
                {
                    MaHDN = row["MaHDN"].ToString(),
                    MaSP = row["MaSP"].ToString(),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"])
                });
            }
            return list;
        }

        public bool Insert(ChiTietHoaDonNhap chiTiet)
        {
            string query = @"INSERT INTO ChiTietHoaDonNhap (MaHDN, MaSP, SoLuong, DonGia)
                             VALUES (@MaHDN, @MaSP, @SoLuong, @DonGia)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDN", chiTiet.MaHDN),
                new SqlParameter("@MaSP", chiTiet.MaSP),
                new SqlParameter("@SoLuong", chiTiet.SoLuong),
                new SqlParameter("@DonGia", chiTiet.DonGia)
            };
            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool InsertMany(List<ChiTietHoaDonNhap> chiTiets)
        {
            foreach (var ct in chiTiets)
            {
                if (!Insert(ct))
                {
                    return false;
                }
            }
            return true;
        }

        public bool DeleteByMaHDN(string maHDN)
        {
            string query = "DELETE FROM ChiTietHoaDonNhap WHERE MaHDN=@MaHDN";
            return ExecuteNonQuery(query, new SqlParameter("@MaHDN", maHDN)) > 0;
        }

        public bool Update(ChiTietHoaDonNhap chiTiet)
        {
            string query = @"UPDATE ChiTietHoaDonNhap
                             SET SoLuong = @SoLuong, DonGia = @DonGia
                             WHERE MaHDN = @MaHDN AND MaSP = @MaSP";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@SoLuong", chiTiet.SoLuong),
                new SqlParameter("@DonGia", chiTiet.DonGia),
                new SqlParameter("@MaHDN", chiTiet.MaHDN),
                new SqlParameter("@MaSP", chiTiet.MaSP)
            };
            return ExecuteNonQuery(query, parameters) > 0;
        }
    }
}