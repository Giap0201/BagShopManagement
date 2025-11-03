using BagShopManagement.DataAccess;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            string query = "SELECT MaHDN, MaSP, SoLuong, DonGia  FROM ChiTietHoaDonNhap WHERE MaHDN=@MaHDN";
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
            if (chiTiet == null) throw new ArgumentNullException(nameof(chiTiet));
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
            if (chiTiets == null || chiTiets.Count == 0) return false;
            // dung transaction de dam bao tinh toan ven du lieu
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var ct in chiTiets)
                        {
                            string query = @"INSERT INTO ChiTietHoaDonNhap (MaHDN, MaSP, SoLuong, DonGia)
                                             VALUES (@MaHDN, @MaSP, @SoLuong, @DonGia)";
                            using (var cmd = new SqlCommand(query, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaHDN", ct.MaHDN);
                                cmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                cmd.Parameters.AddWithValue("@DonGia", ct.DonGia);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw new ApplicationException("Lỗi khi thêm nhiều chi tiết hóa đơn nhập. Giao dịch đã được hoàn tác.");
                    }
                }
            }
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