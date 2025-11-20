using BagShopManagement.DTOs;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;

namespace BagShopManagement.Repositories.Implementations
{
    // Thừa kế từ BaseRepository và triển khai IChiTietGiamGiaRepository
    public class ChiTietGiamGiaRepository : BaseRepository, IChiTietGiamGiaRepository
    {
        public List<ChiTietGiamGiaDto> GetAppliedProducts(string maCTGG)
        {
            var list = new List<ChiTietGiamGiaDto>();
            string query = @"SELECT s.MaSP, s.TenSP, ct.PhanTramGiam
                             FROM SanPham s
                             JOIN ChiTietGiamGia ct ON s.MaSP = ct.MaSP
                             WHERE ct.MaCTGG = @MaCTGG";

            var parameter = new SqlParameter("@MaCTGG", maCTGG);

            // Sử dụng phương thức ExecuteQuery từ lớp cha
            DataTable data = ExecuteQuery(query, parameter);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new ChiTietGiamGiaDto
                {
                    MaSP = row["MaSP"].ToString(),
                    TenSP = row["TenSP"].ToString(),
                    PhanTramGiam = Convert.ToInt32(row["PhanTramGiam"])
                });
            }
            return list;
        }

        public void Add(ChiTietGiamGia chiTiet)
        {
            string query = "INSERT INTO ChiTietGiamGia (MaCTGG, MaSP, PhanTramGiam) VALUES (@MaCTGG, @MaSP, @PhanTramGiam)";

            // Sử dụng phương thức ExecuteNonQuery từ lớp cha
            ExecuteNonQuery(query,
                new SqlParameter("@MaCTGG", chiTiet.MaCTGG),
                new SqlParameter("@MaSP", chiTiet.MaSP),
                new SqlParameter("@PhanTramGiam", chiTiet.PhanTramGiam)
            );
        }

        public void Remove(string maCTGG, string maSP)
        {
            string query = "DELETE FROM ChiTietGiamGia WHERE MaCTGG = @MaCTGG AND MaSP = @MaSP";

            // Sử dụng phương thức ExecuteNonQuery từ lớp cha
            ExecuteNonQuery(query,
                new SqlParameter("@MaCTGG", maCTGG),
                new SqlParameter("@MaSP", maSP)
            );
        }

        public void RemoveByMaCTGG(string maCTGG)
        {
            string query = "DELETE FROM ChiTietGiamGia WHERE MaCTGG = @MaCTGG";

            // Sử dụng phương thức ExecuteNonQuery từ lớp cha
            ExecuteNonQuery(query, new SqlParameter("@MaCTGG", maCTGG));
        }
    }
}