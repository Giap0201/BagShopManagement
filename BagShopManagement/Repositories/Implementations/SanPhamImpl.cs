using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseRepo = BagShopManagement.Repositories.BaseRepository_2;

namespace BagShopManagement.Repositories.Implementations
{
    public class SanPhamImpl : BaseRepo, ISanPhamRepository
    {
        public List<SanPham> GetAll()
        {
            string query = "SELECT MaSP, TenSP, GiaBan FROM SanPham ORDER BY TenSP";

            return base.ExecuteQuery<SanPham>(query, null, reader => new SanPham
            {
                MaSP = base.GetString(reader, "MaSP"),
                TenSP = base.GetString(reader, "TenSP"),
                GiaBan = base.GetDecimal(reader, "GiaBan")
            });
        }

        public SanPham? GetByMaSP(string maSP)
        {
            string query = "SELECT * FROM SanPham WHERE MaSP = @MaSP";
            var parameters = new[] { base.CreateParameter("@MaSP", maSP) };

            var result = base.ExecuteQuery<SanPham>(query, parameters, reader => new SanPham
            {
                MaSP = base.GetString(reader, "MaSP"),
                TenSP = base.GetString(reader, "TenSP"),
                GiaBan = base.GetDecimal(reader, "GiaBan"),
                GiaNhap = base.GetDecimal(reader, "GiaNhap"),
                MoTa = base.GetString(reader, "MoTa")
            });

            return result.Count > 0 ? result[0] : null;
        }

        public void Update(SanPham sanPham)
        {
            string query = @"UPDATE SanPham 
                            SET TenSP = @TenSP, 
                                GiaBan = @GiaBan, 
                                GiaNhap = @GiaNhap,
                                MoTa = @MoTa
                            WHERE MaSP = @MaSP";

            var parameters = new[]
            {
                base.CreateParameter("@MaSP", sanPham.MaSP),
                base.CreateParameter("@TenSP", sanPham.TenSP),
                base.CreateParameter("@GiaBan", sanPham.GiaBan),
                base.CreateParameter("@GiaNhap", sanPham.GiaNhap),
                base.CreateParameter("@MoTa", sanPham.MoTa)
            };

            base.ExecuteNonQuery(query, parameters);
        }
    }
}