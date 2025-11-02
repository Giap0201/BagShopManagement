using BagShopManagement.DataAccess;
using BagShopManagement.DTOs;
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
    public class ChiTietGiamGiaRepository : IChiTietGiamGiaRepository
    {
        public List<ChiTietGiamGiaDto> GetAppliedProducts(string maCTGG)
        {
            var list = new List<ChiTietGiamGiaDto>();
            // Câu lệnh SQL này JOIN 2 bảng để lấy Tên Sản Phẩm và % giảm giá
            string query = @"SELECT s.MaSP, s.TenSP, ct.PhanTramGiam
                             FROM SanPham s
                             JOIN ChiTietGiamGia ct ON s.MaSP = ct.MaSP
                             WHERE ct.MaCTGG = @MaCTGG";

            SqlParameter[] parameters = { new SqlParameter("@MaCTGG", maCTGG) };
            DataTable data = DataAccessBase.ExecuteQuery(query, parameters);

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
            SqlParameter[] parameters = {
                new SqlParameter("@MaCTGG", chiTiet.MaCTGG),
                new SqlParameter("@MaSP", chiTiet.MaSP),
                new SqlParameter("@PhanTramGiam", chiTiet.PhanTramGiam)
            };
            DataAccessBase.ExecuteNonQuery(query, parameters);
        }

        public void Remove(string maCTGG, string maSP)
        {
            string query = "DELETE FROM ChiTietGiamGia WHERE MaCTGG = @MaCTGG AND MaSP = @MaSP";
            SqlParameter[] parameters = {
                new SqlParameter("@MaCTGG", maCTGG),
                new SqlParameter("@MaSP", maSP)
            };
            DataAccessBase.ExecuteNonQuery(query, parameters);
        }

        public void RemoveByMaCTGG(string maCTGG)
        {
            string query = "DELETE FROM ChiTietGiamGia WHERE MaCTGG = @MaCTGG";
            SqlParameter[] parameters = { new SqlParameter("@MaCTGG", maCTGG) };
            DataAccessBase.ExecuteNonQuery(query, parameters);
        }
    }
}
