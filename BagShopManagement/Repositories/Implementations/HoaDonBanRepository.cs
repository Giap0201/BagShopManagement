using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BagShopManagement.Repositories.Implementations
{
    /// <summary>
    /// Repository xử lý truy cập dữ liệu cho bảng HoaDonBan và ChiTietHoaDonBan
    /// Kế thừa từ BaseRepository để sử dụng ExecuteTransaction cho ACID compliance
    /// </summary>
    public class HoaDonBanRepository : BaseRepository_2, IHoaDonBanRepository
    {
        /// <summary>
        /// Insert hóa đơn mới và chi tiết trong một transaction
        /// </summary>
        /// <param name="hd">Đối tượng HoaDonBan</param>
        /// <param name="chiTiet">Danh sách ChiTietHoaDonBan</param>
        /// <remarks>
        /// Sử dụng transaction để đảm bảo:
        /// - Insert HoaDonBan thành công → Insert tất cả ChiTietHoaDonBan
        /// - Nếu có lỗi → Rollback toàn bộ
        /// </remarks>
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

        /// <summary>
        /// Map SqlDataReader → HoaDonBan entity
        /// Sử dụng helper methods từ BaseRepository
        /// </summary>
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

        /// <summary>
        /// Lấy tất cả hóa đơn, sắp xếp theo NgayBan giảm dần
        /// </summary>
        public List<HoaDonBan> GetAll()
        {
            string query = "SELECT * FROM HoaDonBan ORDER BY NgayBan DESC";
            return ExecuteQuery<HoaDonBan>(query, null, MapFromReader);
        }

        /// <summary>
        /// Lấy hóa đơn theo mã hóa đơn
        /// </summary>
        /// <param name="maHDB">Mã hóa đơn</param>
        /// <returns>HoaDonBan nếu tìm thấy, null nếu không tồn tại</returns>
        public HoaDonBan? GetByMaHDB(string maHDB)
        {
            string query = "SELECT * FROM HoaDonBan WHERE MaHDB=@MaHDB";
            var parameters = new[] { CreateParameter("@MaHDB", maHDB) };
            var results = ExecuteQuery<HoaDonBan>(query, parameters, MapFromReader);
            return results.Count > 0 ? results[0] : null;
        }

        /// <summary>
        /// Cập nhật trạng thái hóa đơn
        /// </summary>
        /// <param name="maHDB">Mã hóa đơn</param>
        /// <param name="trangThai">Trạng thái mới (1=Nháp, 2=Đã thanh toán, 3=Đã hủy)</param>
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

        /// <summary>
        /// Lấy danh sách chi tiết hóa đơn theo mã hóa đơn
        /// </summary>
        /// <param name="maHDB">Mã hóa đơn</param>
        /// <returns>Danh sách ChiTietHoaDonBan</returns>
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

        /// <summary>
        /// Lọc hóa đơn theo các tiêu chí
        /// </summary>
        /// <param name="fromDate">Từ ngày (nullable)</param>
        /// <param name="toDate">Đến ngày (nullable)</param>
        /// <param name="maNV">Mã nhân viên (nullable)</param>
        /// <param name="trangThai">Trạng thái hóa đơn (nullable)</param>
        /// <returns>Danh sách HoaDonBan thỏa điều kiện</returns>
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

        /// <summary>
        /// Cập nhật hóa đơn và chi tiết trong một transaction
        /// </summary>
        /// <param name="hd">Đối tượng HoaDonBan với thông tin mới</param>
        /// <param name="chiTiet">Danh sách ChiTietHoaDonBan mới</param>
        /// <remarks>
        /// Quy trình:
        /// 1. Xóa toàn bộ ChiTietHoaDonBan cũ
        /// 2. Cập nhật HoaDonBan
        /// 3. Insert ChiTietHoaDonBan mới
        /// Tất cả trong một transaction để đảm bảo tính nhất quán
        /// </remarks>
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
    }
}
