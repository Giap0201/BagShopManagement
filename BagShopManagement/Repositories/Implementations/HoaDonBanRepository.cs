// Repositories/Implementations/HoaDonBanRepository.cs
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Implementations
{
    public class HoaDonBanRepository : BaseRepository, IHoaDonBanRepository
    {
        // Sử dụng BaseRepository ExecuteTransaction
        public void Insert(HoaDonBan hd, List<ChiTietHoaDonBan> chiTiet)
        {
            ExecuteTransaction((conn, tran) =>
            {
                // Insert hóa đơn
                string queryHD = @"INSERT INTO HoaDonBan(MaHDB, MaKH, MaNV, NgayBan, TongTien, PhuongThucTT, GhiChu, TrangThaiHD)
                                   VALUES(@MaHDB,@MaKH,@MaNV,@NgayBan,@TongTien,@PhuongThucTT,@GhiChu,@TrangThaiHD)";

                using var cmdHd = new SqlCommand(queryHD, conn, tran);
                cmdHd.Parameters.AddRange(new[]
                {
                    CreateParameter("@MaHDB", hd.MaHDB),
                    CreateParameter("@MaKH", hd.MaKH),
                    CreateParameter("@MaNV", hd.MaNV),
                    CreateParameter("@NgayBan", hd.NgayBan),
                    CreateParameter("@TongTien", hd.TongTien),
                    CreateParameter("@PhuongThucTT", hd.PhuongThucTT),
                    CreateParameter("@GhiChu", hd.GhiChu),
                    CreateParameter("@TrangThaiHD", hd.TrangThaiHD)
                });
                cmdHd.ExecuteNonQuery();

                // Insert chi tiết
                string queryCT = @"INSERT INTO ChiTietHoaDonBan(MaHDB, MaSP, SoLuong, DonGia, GiamGiaSP)
                                   VALUES(@MaHDB,@MaSP,@SoLuong,@DonGia,@GiamGiaSP)";

                foreach (var ct in chiTiet)
                {
                    using var cmdCt = new SqlCommand(queryCT, conn, tran);
                    cmdCt.Parameters.AddRange(new[]
                    {
                        CreateParameter("@MaHDB", ct.MaHDB),
                        CreateParameter("@MaSP", ct.MaSP),
                        CreateParameter("@SoLuong", ct.SoLuong),
                        CreateParameter("@DonGia", ct.DonGia),
                        CreateParameter("@GiamGiaSP", ct.GiamGiaSP)
                    });
                    cmdCt.ExecuteNonQuery();
                }

                return true;
            });
        }

        // Map từ SqlDataReader - định nghĩa trước để sử dụng
        private HoaDonBan MapFromReader(SqlDataReader reader)
        {
            return new HoaDonBan
            {
                MaHDB = GetString(reader, "MaHDB"),
                MaKH = GetValue<string>(reader, "MaKH"),
                MaNV = GetString(reader, "MaNV"),
                NgayBan = GetDateTime(reader, "NgayBan") ?? DateTime.Now,
                TongTien = GetDecimal(reader, "TongTien"),
                PhuongThucTT = GetValue<string>(reader, "PhuongThucTT"),
                GhiChu = GetValue<string>(reader, "GhiChu"),
                TrangThaiHD = (byte)GetInt(reader, "TrangThaiHD")
            };
        }

        public List<HoaDonBan> GetAll()
        {
            string query = "SELECT * FROM HoaDonBan ORDER BY NgayBan DESC";
            return ExecuteQuery<HoaDonBan>(query, null, MapFromReader);
        }

        public HoaDonBan? GetByMaHDB(string maHDB)
        {
            string query = "SELECT * FROM HoaDonBan WHERE MaHDB=@MaHDB";
            var parameters = new[] { CreateParameter("@MaHDB", maHDB) };
            var results = ExecuteQuery<HoaDonBan>(query, parameters, MapFromReader);
            return results.Count > 0 ? results[0] : null;
        }

        public void UpdateTrangThai(string maHDB, byte trangThai)
        {
            string query = "UPDATE HoaDonBan SET TrangThaiHD=@TrangThai WHERE MaHDB=@MaHDB";
            var parameters = new[]
            {
                CreateParameter("@TrangThai", trangThai),
                CreateParameter("@MaHDB", maHDB)
            };
            ExecuteNonQuery(query, parameters);
        }

        public List<ChiTietHoaDonBan> GetChiTietByMaHDB(string maHDB)
        {
            string query = "SELECT * FROM ChiTietHoaDonBan WHERE MaHDB=@MaHDB";
            var parameters = new[] { CreateParameter("@MaHDB", maHDB) };
            return ExecuteQuery(query, parameters, reader => new ChiTietHoaDonBan
            {
                MaHDB = GetString(reader, "MaHDB"),
                MaSP = GetString(reader, "MaSP"),
                SoLuong = GetInt(reader, "SoLuong"),
                DonGia = GetDecimal(reader, "DonGia"),
                GiamGiaSP = GetDecimal(reader, "GiamGiaSP")
            });
        }

        public List<HoaDonBan> Filter(DateTime? fromDate = null, DateTime? toDate = null, string? maNV = null, byte? trangThai = null)
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            if (fromDate.HasValue)
            {
                conditions.Add("NgayBan >= @FromDate");
                parameters.Add(CreateParameter("@FromDate", fromDate.Value.Date));
            }

            if (toDate.HasValue)
            {
                conditions.Add("NgayBan < @ToDate");
                parameters.Add(CreateParameter("@ToDate", toDate.Value.Date.AddDays(1)));
            }

            if (!string.IsNullOrWhiteSpace(maNV))
            {
                conditions.Add("MaNV = @MaNV");
                parameters.Add(CreateParameter("@MaNV", maNV));
            }

            if (trangThai.HasValue)
            {
                conditions.Add("TrangThaiHD = @TrangThai");
                parameters.Add(CreateParameter("@TrangThai", trangThai.Value));
            }

            var whereClause = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
            var query = $"SELECT * FROM HoaDonBan {whereClause} ORDER BY NgayBan DESC";

            return ExecuteQuery<HoaDonBan>(query, parameters.ToArray(), MapFromReader);
        }

        public void Update(HoaDonBan hd, List<ChiTietHoaDonBan> chiTiet)
        {
            ExecuteTransaction((conn, tran) =>
            {
                // Xóa chi tiết cũ
                string queryDelete = "DELETE FROM ChiTietHoaDonBan WHERE MaHDB=@MaHDB";
                using (var cmdDelete = new SqlCommand(queryDelete, conn, tran))
                {
                    cmdDelete.Parameters.Add(CreateParameter("@MaHDB", hd.MaHDB));
                    cmdDelete.ExecuteNonQuery();
                }

                // Cập nhật hóa đơn
                string queryUpdate = @"UPDATE HoaDonBan SET MaKH=@MaKH, MaNV=@MaNV, NgayBan=@NgayBan, 
                                       TongTien=@TongTien, PhuongThucTT=@PhuongThucTT, GhiChu=@GhiChu, 
                                       TrangThaiHD=@TrangThaiHD WHERE MaHDB=@MaHDB";
                using (var cmdUpdate = new SqlCommand(queryUpdate, conn, tran))
                {
                    cmdUpdate.Parameters.AddRange(new[]
                    {
                        CreateParameter("@MaHDB", hd.MaHDB),
                        CreateParameter("@MaKH", hd.MaKH),
                        CreateParameter("@MaNV", hd.MaNV),
                        CreateParameter("@NgayBan", hd.NgayBan),
                        CreateParameter("@TongTien", hd.TongTien),
                        CreateParameter("@PhuongThucTT", hd.PhuongThucTT),
                        CreateParameter("@GhiChu", hd.GhiChu),
                        CreateParameter("@TrangThaiHD", hd.TrangThaiHD)
                    });
                    cmdUpdate.ExecuteNonQuery();
                }

                // Thêm chi tiết mới
                string queryInsert = @"INSERT INTO ChiTietHoaDonBan(MaHDB, MaSP, SoLuong, DonGia, GiamGiaSP)
                                       VALUES(@MaHDB,@MaSP,@SoLuong,@DonGia,@GiamGiaSP)";
                foreach (var ct in chiTiet)
                {
                    using var cmdCt = new SqlCommand(queryInsert, conn, tran);
                    cmdCt.Parameters.AddRange(new[]
                    {
                        CreateParameter("@MaHDB", ct.MaHDB),
                        CreateParameter("@MaSP", ct.MaSP),
                        CreateParameter("@SoLuong", ct.SoLuong),
                        CreateParameter("@DonGia", ct.DonGia),
                        CreateParameter("@GiamGiaSP", ct.GiamGiaSP)
                    });
                    cmdCt.ExecuteNonQuery();
                }

                return true;
            });
        }

        // Giữ lại Map cũ cho backward compatibility (nếu cần)
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
