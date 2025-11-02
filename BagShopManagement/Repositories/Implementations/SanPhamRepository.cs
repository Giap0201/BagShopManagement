using BagShopManagement.DataAccess;
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
    public class SanPhamRepository : ISanPhamRepository
    {
            public List<SanPham> GetAvailableProducts(string maCTGG)
        {
            var list = new List<SanPham>();
            // Câu lệnh SQL này lấy tất cả sản phẩm CHƯA TỒN TẠI trong bảng ChiTietGiamGia cho MaCTGG hiện tại
            string query = @"SELECT s.MaSP, s.TenSP, s.SoLuongTon 
                             FROM SanPham s
                             WHERE s.MaSP NOT IN (SELECT ct.MaSP FROM ChiTietGiamGia ct WHERE ct.MaCTGG = @MaCTGG)";

            SqlParameter[] parameters = { new SqlParameter("@MaCTGG", maCTGG) };
            DataTable data = DataAccessBase.ExecuteQuery(query, parameters);

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
