using BagShopManagement.DataAccess;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;

namespace BagShopManagement.Repositories.Implementations
{
    // Thừa kế từ BaseRepository và triển khai ISanPhamRepository
    public class SanPhamRepository : BaseRepository, ISanPhamRepository
    {
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
    }
}