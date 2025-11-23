using BagShopManagement.Models;
using BagShopManagement.Models.Enums;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace BagShopManagement.Repositories.Implementations
{
    public class ChiTietHDNRepository : BaseRepository, IChiTietHDNRepository
    {
        private readonly string _connectionString;

        public ChiTietHDNRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        private ChiTietHoaDonNhap MapToChiTiet(IDataRecord reader)
        {
            return new ChiTietHoaDonNhap
            {
                MaHDN = reader["MaHDN"].ToString(),
                MaSP = reader["MaSP"].ToString(),
                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                DonGia = Convert.ToDecimal(reader["DonGia"]),
                ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
            };
        }

        public List<ChiTietHoaDonNhap> GetByHoaDonNhapId(string maHDN)
        {
            var list = new List<ChiTietHoaDonNhap>();
            string sql = "SELECT * FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaHDN", maHDN);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapToChiTiet(reader));
            }
            return list;
        }

        public ChiTietHoaDonNhap GetDetailById(string maHDN, string maSP)
        {
            string sql = "SELECT * FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN AND MaSP = @MaSP";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaHDN", maHDN);
            cmd.Parameters.AddWithValue("@MaSP", maSP);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapToChiTiet(reader) : null;
        }

        public bool DetailExists(string maHDN, string maSP)
        {
            string sql = "SELECT COUNT(1) FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN AND MaSP = @MaSP";
            var result = ExecuteScalar(sql,
                new SqlParameter("@MaHDN", maHDN),
                new SqlParameter("@MaSP", maSP));
            return Convert.ToInt32(result) > 0;
        }

        // Them chi tiet hoa don khi dang tam luu
        public bool AddDetailToDraft(ChiTietHoaDonNhap chiTiet)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                string sqlInsert = @"
                    INSERT INTO ChiTietHoaDonNhap (MaHDN, MaSP, SoLuong, DonGia, ThanhTien)
                    VALUES (@MaHDN, @MaSP, @SoLuong, @DonGia, @ThanhTien)";
                using (var cmd = new SqlCommand(sqlInsert, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@MaHDN", chiTiet.MaHDN);
                    cmd.Parameters.AddWithValue("@MaSP", chiTiet.MaSP);
                    cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                    cmd.Parameters.AddWithValue("@DonGia", chiTiet.DonGia);
                    cmd.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);
                    cmd.ExecuteNonQuery();
                }
                string sqlUpdateHD = @"
                    UPDATE HoaDonNhap
                    SET TongTien = TongTien + @ThanhTien
                    WHERE MaHDN = @MaHDN AND TrangThai = @TamLuu";
                using (var cmdUpdate = new SqlCommand(sqlUpdateHD, conn, tran))
                {
                    cmdUpdate.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);
                    cmdUpdate.Parameters.AddWithValue("@MaHDN", chiTiet.MaHDN);
                    cmdUpdate.Parameters.AddWithValue("@TamLuu", (byte)TrangThaiHoaDonNhap.TamLuu);
                    cmdUpdate.ExecuteNonQuery();
                }

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new ApplicationException("Lỗi khi thêm chi tiết vào phiếu nháp: " + ex.Message, ex);
            }
        }

        /// [TRANSACTION] Cập nhật 1 chi tiết (Số lượng, Đơn giá) (khi đang Tạm lưu).
        public bool UpdateDetailInDraft(ChiTietHoaDonNhap chiTiet)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                // 1. Lấy thành tiền cũ
                string sqlGetOld = "SELECT ThanhTien FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN AND MaSP = @MaSP";
                decimal oldThanhTien = 0;
                using (var cmdGet = new SqlCommand(sqlGetOld, conn, tran))
                {
                    cmdGet.Parameters.AddWithValue("@MaHDN", chiTiet.MaHDN);
                    cmdGet.Parameters.AddWithValue("@MaSP", chiTiet.MaSP);
                    var result = cmdGet.ExecuteScalar();
                    if (result == null) throw new Exception("Chi tiết không tồn tại để cập nhật.");
                    oldThanhTien = Convert.ToDecimal(result);
                }

                decimal delta = chiTiet.ThanhTien - oldThanhTien; // Tính chênh lệch

                // 2. Cập nhật chi tiết
                string sqlUpdateCT = @"
                    UPDATE ChiTietHoaDonNhap
                    SET SoLuong = @SoLuong, DonGia = @DonGia, ThanhTien = @ThanhTien
                    WHERE MaHDN = @MaHDN AND MaSP = @MaSP";
                using (var cmdUpdateCT = new SqlCommand(sqlUpdateCT, conn, tran))
                {
                    cmdUpdateCT.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                    cmdUpdateCT.Parameters.AddWithValue("@DonGia", chiTiet.DonGia);
                    cmdUpdateCT.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);
                    cmdUpdateCT.Parameters.AddWithValue("@MaHDN", chiTiet.MaHDN);
                    cmdUpdateCT.Parameters.AddWithValue("@MaSP", chiTiet.MaSP);
                    cmdUpdateCT.ExecuteNonQuery();
                }

                // 3. Cập nhật Tổng tiền của hóa đơn cha
                string sqlUpdateHD = @"
                    UPDATE HoaDonNhap
                    SET TongTien = TongTien + @Delta
                    WHERE MaHDN = @MaHDN AND TrangThai = @TamLuu";
                using (var cmdUpdateHD = new SqlCommand(sqlUpdateHD, conn, tran))
                {
                    cmdUpdateHD.Parameters.AddWithValue("@Delta", delta);
                    cmdUpdateHD.Parameters.AddWithValue("@MaHDN", chiTiet.MaHDN);
                    cmdUpdateHD.Parameters.AddWithValue("@TamLuu", (byte)TrangThaiHoaDonNhap.TamLuu);
                    cmdUpdateHD.ExecuteNonQuery();
                }

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new ApplicationException("Lỗi khi cập nhật chi tiết trong phiếu nháp: " + ex.Message, ex);
            }
        }

        // Xoa chi tiet, cap nhat lai tong tien cua hoa don cha
        public bool DeleteDetailFromDraft(string maHDN, string maSP)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                // 1. Lấy thành tiền của chi tiết sắp xóa
                string sqlGetOld = "SELECT ThanhTien FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN AND MaSP = @MaSP";
                decimal oldThanhTien = 0;
                using (var cmdGet = new SqlCommand(sqlGetOld, conn, tran))
                {
                    cmdGet.Parameters.AddWithValue("@MaHDN", maHDN);
                    cmdGet.Parameters.AddWithValue("@MaSP", maSP);
                    var result = cmdGet.ExecuteScalar();
                    if (result == null) throw new Exception("Chi tiết không tồn tại để xóa.");
                    oldThanhTien = Convert.ToDecimal(result);
                }

                // 2. Xóa chi tiết
                string sqlDeleteCT = "DELETE FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN AND MaSP = @MaSP";
                using (var cmdDeleteCT = new SqlCommand(sqlDeleteCT, conn, tran))
                {
                    cmdDeleteCT.Parameters.AddWithValue("@MaHDN", maHDN);
                    cmdDeleteCT.Parameters.AddWithValue("@MaSP", maSP);
                    cmdDeleteCT.ExecuteNonQuery();
                }

                // 3. Cập nhật (trừ) Tổng tiền của hóa đơn cha
                string sqlUpdateHD = @"
                    UPDATE HoaDonNhap
                    SET TongTien = TongTien - @ThanhTienBiXoa
                    WHERE MaHDN = @MaHDN AND TrangThai = @TamLuu";
                using (var cmdUpdateHD = new SqlCommand(sqlUpdateHD, conn, tran))
                {
                    cmdUpdateHD.Parameters.AddWithValue("@ThanhTienBiXoa", oldThanhTien);
                    cmdUpdateHD.Parameters.AddWithValue("@MaHDN", maHDN);
                    cmdUpdateHD.Parameters.AddWithValue("@TamLuu", (byte)TrangThaiHoaDonNhap.TamLuu);
                    cmdUpdateHD.ExecuteNonQuery();
                }

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new ApplicationException("Lỗi khi xóa chi tiết khỏi phiếu nháp: " + ex.Message, ex);
            }
        }
    }
}