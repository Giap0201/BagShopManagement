// Repositories/Implementations/HoaDonBanRepository.cs
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BagShopManagement.Repositories.Implementations
{
    public class HoaDonBanRepository : IHoaDonBanRepository
    {
        // IMPORTANT: Use explicit SqlConnection + SqlTransaction for atomic insert.
        // If DataAccessBase exposes transaction helpers, adapt accordingly.
        public void Insert(HoaDonBan hd, List<ChiTietHoaDonBan> chiTiet)
        {
            // Implement transaction-safe insert using direct SqlConnection/SqlTransaction
            // so we don't depend on DataAccessBase transaction capability.
            // NOTE: adjust connection retrieval if DataAccessBase exposes one.
            var connString = DataAccess.DataAccessBase.GetConnectionString(); // assume exists; else use DataAccessBase internal connection
            using var conn = new Microsoft.Data.SqlClient.SqlConnection(connString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                using var cmdHd = conn.CreateCommand();
                cmdHd.Transaction = tran;
                cmdHd.CommandText = @"INSERT INTO HoaDonBan(MaHDB, MaKH, MaNV, NgayBan, TongTien, PhuongThucTT, GhiChu, TrangThaiHD)
                                      VALUES(@MaHDB,@MaKH,@MaNV,@NgayBan,@TongTien,@PhuongThucTT,@GhiChu,@TrangThaiHD)";
                cmdHd.Parameters.AddWithValue("@MaHDB", hd.MaHDB);
                cmdHd.Parameters.AddWithValue("@MaKH", (object?)hd.MaKH ?? DBNull.Value);
                cmdHd.Parameters.AddWithValue("@MaNV", hd.MaNV);
                cmdHd.Parameters.AddWithValue("@NgayBan", hd.NgayBan);
                cmdHd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                cmdHd.Parameters.AddWithValue("@PhuongThucTT", (object?)hd.PhuongThucTT ?? DBNull.Value);
                cmdHd.Parameters.AddWithValue("@GhiChu", (object?)hd.GhiChu ?? DBNull.Value);
                cmdHd.Parameters.AddWithValue("@TrangThaiHD", hd.TrangThaiHD);
                cmdHd.ExecuteNonQuery();

                foreach (var ct in chiTiet)
                {
                    using var cmdCt = conn.CreateCommand();
                    cmdCt.Transaction = tran;
                    cmdCt.CommandText = @"INSERT INTO ChiTietHoaDonBan(MaHDB, MaSP, SoLuong, DonGia, GiamGiaSP)
                                          VALUES(@MaHDB,@MaSP,@SoLuong,@DonGia,@GiamGiaSP)";
                    cmdCt.Parameters.AddWithValue("@MaHDB", ct.MaHDB);
                    cmdCt.Parameters.AddWithValue("@MaSP", ct.MaSP);
                    cmdCt.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                    cmdCt.Parameters.AddWithValue("@DonGia", ct.DonGia);
                    cmdCt.Parameters.AddWithValue("@GiamGiaSP", ct.GiamGiaSP);
                    cmdCt.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch
            {
                try { tran.Rollback(); } catch { /* ignore */ }
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<HoaDonBan> GetAll()
        {
            var list = new List<HoaDonBan>();
            var dt = DataAccess.DataAccessBase.ExecuteQuery("SELECT * FROM HoaDonBan ORDER BY NgayBan DESC");
            foreach (DataRow r in dt.Rows) list.Add(Map(r));
            return list;
        }

        public HoaDonBan? GetByMaHDB(string maHDB)
        {
            var dt = DataAccess.DataAccessBase.ExecuteQuery(
                "SELECT * FROM HoaDonBan WHERE MaHDB=@MaHDB",
                new SqlParameter("@MaHDB", maHDB));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public void UpdateTrangThai(string maHDB, byte trangThai)
        {
            DataAccess.DataAccessBase.ExecuteNonQuery(
                "UPDATE HoaDonBan SET TrangThaiHD=@TrangThai WHERE MaHDB=@MaHDB",
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@MaHDB", maHDB)
            );
        }

        public List<ChiTietHoaDonBan> GetChiTietByMaHDB(string maHDB)
        {
            var list = new List<ChiTietHoaDonBan>();
            var dt = DataAccess.DataAccessBase.ExecuteQuery(
                "SELECT * FROM ChiTietHoaDonBan WHERE MaHDB=@MaHDB",
                new SqlParameter("@MaHDB", maHDB));
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ChiTietHoaDonBan
                {
                    MaHDB = r["MaHDB"]?.ToString() ?? string.Empty,
                    MaSP = r["MaSP"]?.ToString() ?? string.Empty,
                    SoLuong = r.Field<int?>("SoLuong") ?? 0,
                    DonGia = r.Field<decimal?>("DonGia") ?? 0m,
                    GiamGiaSP = r.Field<decimal?>("GiamGiaSP") ?? 0m
                });
            }
            return list;
        }

        public List<HoaDonBan> Filter(DateTime? fromDate = null, DateTime? toDate = null, string? maNV = null, byte? trangThai = null)
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            if (fromDate.HasValue)
            {
                conditions.Add("NgayBan >= @FromDate");
                parameters.Add(new SqlParameter("@FromDate", fromDate.Value.Date));
            }

            if (toDate.HasValue)
            {
                conditions.Add("NgayBan < @ToDate");
                parameters.Add(new SqlParameter("@ToDate", toDate.Value.Date.AddDays(1)));
            }

            if (!string.IsNullOrWhiteSpace(maNV))
            {
                conditions.Add("MaNV = @MaNV");
                parameters.Add(new SqlParameter("@MaNV", maNV));
            }

            if (trangThai.HasValue)
            {
                conditions.Add("TrangThaiHD = @TrangThai");
                parameters.Add(new SqlParameter("@TrangThai", trangThai.Value));
            }

            var whereClause = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
            var query = $"SELECT * FROM HoaDonBan {whereClause} ORDER BY NgayBan DESC";

            var list = new List<HoaDonBan>();
            var dt = DataAccess.DataAccessBase.ExecuteQuery(query, parameters.ToArray());
            foreach (DataRow r in dt.Rows) list.Add(Map(r));
            return list;
        }

        public void Update(HoaDonBan hd, List<ChiTietHoaDonBan> chiTiet)
        {
            var connString = DataAccess.DataAccessBase.GetConnectionString();
            using var conn = new Microsoft.Data.SqlClient.SqlConnection(connString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                // Xóa chi tiết cũ
                using var cmdDelete = conn.CreateCommand();
                cmdDelete.Transaction = tran;
                cmdDelete.CommandText = "DELETE FROM ChiTietHoaDonBan WHERE MaHDB=@MaHDB";
                cmdDelete.Parameters.AddWithValue("@MaHDB", hd.MaHDB);
                cmdDelete.ExecuteNonQuery();

                // Cập nhật hóa đơn
                using var cmdUpdate = conn.CreateCommand();
                cmdUpdate.Transaction = tran;
                cmdUpdate.CommandText = @"UPDATE HoaDonBan SET MaKH=@MaKH, MaNV=@MaNV, NgayBan=@NgayBan, 
                                         TongTien=@TongTien, PhuongThucTT=@PhuongThucTT, GhiChu=@GhiChu, 
                                         TrangThaiHD=@TrangThaiHD WHERE MaHDB=@MaHDB";
                cmdUpdate.Parameters.AddWithValue("@MaHDB", hd.MaHDB);
                cmdUpdate.Parameters.AddWithValue("@MaKH", (object?)hd.MaKH ?? DBNull.Value);
                cmdUpdate.Parameters.AddWithValue("@MaNV", hd.MaNV);
                cmdUpdate.Parameters.AddWithValue("@NgayBan", hd.NgayBan);
                cmdUpdate.Parameters.AddWithValue("@TongTien", hd.TongTien);
                cmdUpdate.Parameters.AddWithValue("@PhuongThucTT", (object?)hd.PhuongThucTT ?? DBNull.Value);
                cmdUpdate.Parameters.AddWithValue("@GhiChu", (object?)hd.GhiChu ?? DBNull.Value);
                cmdUpdate.Parameters.AddWithValue("@TrangThaiHD", hd.TrangThaiHD);
                cmdUpdate.ExecuteNonQuery();

                // Thêm chi tiết mới
                foreach (var ct in chiTiet)
                {
                    using var cmdCt = conn.CreateCommand();
                    cmdCt.Transaction = tran;
                    cmdCt.CommandText = @"INSERT INTO ChiTietHoaDonBan(MaHDB, MaSP, SoLuong, DonGia, GiamGiaSP)
                                          VALUES(@MaHDB,@MaSP,@SoLuong,@DonGia,@GiamGiaSP)";
                    cmdCt.Parameters.AddWithValue("@MaHDB", ct.MaHDB);
                    cmdCt.Parameters.AddWithValue("@MaSP", ct.MaSP);
                    cmdCt.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                    cmdCt.Parameters.AddWithValue("@DonGia", ct.DonGia);
                    cmdCt.Parameters.AddWithValue("@GiamGiaSP", ct.GiamGiaSP);
                    cmdCt.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch
            {
                try { tran.Rollback(); } catch { /* ignore */ }
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private HoaDonBan Map(DataRow r)
        {
            return new HoaDonBan
            {
                MaHDB = r["MaHDB"]?.ToString() ?? string.Empty,
                MaKH = r["MaKH"]?.ToString(),
                MaNV = r["MaNV"]?.ToString() ?? string.Empty,
                NgayBan = r.Field<DateTime?>("NgayBan") ?? DateTime.Now,
                TongTien = r.Field<decimal?>("TongTien") ?? 0m,
                PhuongThucTT = r["PhuongThucTT"]?.ToString(),
                GhiChu = r["GhiChu"]?.ToString(),
                TrangThaiHD = r.Field<byte?>("TrangThaiHD") ?? 0
            };
        }
    }
}
