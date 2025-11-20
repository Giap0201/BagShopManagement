using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration; // Cần thiết để đọc connection string
using System.Data; // Cần thiết cho DataTable và DataRow

// Đảm bảo namespace này khớp với BaseRepository của bạn

namespace BagShopManagement.Repositories.Implementations
{
    /// <summary>
    /// Repository xử lý dữ liệu cho HoaDonBan, kế thừa từ BaseRepository (dựa trên DataTable)
    /// </summary>
    public class HoaDonBanRepository : BaseRepository, IHoaDonBanRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Khởi tạo repository, gọi hàm base() và đọc lại connection string
        /// để sử dụng cho các nghiệp vụ transaction
        /// </summary>
        public HoaDonBanRepository() : base()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"]?.ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ConfigurationErrorsException("Không tìm thấy chuỗi kết nối 'MyConnectionString' trong file App.config.");
            }
        }

        #region Helpers (Tạo Parameter và Map Data)

        /// <summary>
        /// Helper tạo SqlParameter, xử lý giá trị null
        /// </summary>
        private SqlParameter CreateParameter(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        /// <summary>
        /// Map DataRow -> HoaDonBan entity
        /// </summary>
        private HoaDonBan MapFromDataRow(DataRow row)
        {
            return new HoaDonBan
            {
                MaHDB = row["MaHDB"].ToString(),
                MaKH = row.IsNull("MaKH") ? null : row["MaKH"].ToString(),
                MaNV = row["MaNV"].ToString(),
                NgayBan = Convert.ToDateTime(row["NgayBan"]),
                TongTien = Convert.ToDecimal(row["TongTien"]),
                PhuongThucTT = row.IsNull("PhuongThucTT") ? null : row["PhuongThucTT"].ToString(),
                GhiChu = row.IsNull("GhiChu") ? null : row["GhiChu"].ToString(),
                TrangThaiHD = Convert.ToByte(row["TrangThaiHD"])
            };
        }

        /// <summary>
        /// Map DataRow -> ChiTietHoaDonBan entity
        /// </summary>
        private ChiTietHoaDonBan MapChiTietFromDataRow(DataRow row)
        {
            return new ChiTietHoaDonBan
            {
                MaHDB = row["MaHDB"].ToString(),
                MaSP = row["MaSP"].ToString(),
                SoLuong = Convert.ToInt32(row["SoLuong"]),
                DonGia = Convert.ToDecimal(row["DonGia"]),
                GiamGiaSP = Convert.ToDecimal(row["GiamGiaSP"])
            };
        }

        #endregion Helpers (Tạo Parameter và Map Data)

        #region Transaction Methods (Insert & Update)

        /// <summary>
        /// Insert hóa đơn mới và chi tiết trong một transaction
        /// </summary>
        /// <remarks>
        /// Phải tự triển khai transaction vì BaseRepository không cung cấp.
        /// </remarks>
        public void Insert(HoaDonBan hd, List<ChiTietHoaDonBan> chiTiet)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert hóa đơn
                        string queryHD = @"INSERT INTO HoaDonBan(MaHDB, MaKH, MaNV, NgayBan, TongTien, PhuongThucTT, GhiChu, TrangThaiHD)
                                         VALUES(@MaHDB,@MaKH,@MaNV,@NgayBan,@TongTien,@PhuongThucTT,@GhiChu,@TrangThaiHD)";

                        using (var cmdHd = new SqlCommand(queryHD, conn, tran))
                        {
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
                        }

                        // 2. Insert chi tiết
                        string queryCT = @"INSERT INTO ChiTietHoaDonBan(MaHDB, MaSP, SoLuong, DonGia, GiamGiaSP)
                                         VALUES(@MaHDB,@MaSP,@SoLuong,@DonGia,@GiamGiaSP)";

                        foreach (var ct in chiTiet)
                        {
                            using (var cmdCt = new SqlCommand(queryCT, conn, tran))
                            {
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
                        }

                        // Thành công
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        // Lỗi -> Rollback
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Cập nhật hóa đơn và chi tiết trong một transaction
        /// </summary>
        public void Update(HoaDonBan hd, List<ChiTietHoaDonBan> chiTiet)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Xóa chi tiết cũ
                        string queryDelete = "DELETE FROM ChiTietHoaDonBan WHERE MaHDB=@MaHDB";
                        using (var cmdDelete = new SqlCommand(queryDelete, conn, tran))
                        {
                            cmdDelete.Parameters.Add(CreateParameter("@MaHDB", hd.MaHDB));
                            cmdDelete.ExecuteNonQuery();
                        }

                        // 2. Cập nhật hóa đơn
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

                        // 3. Thêm chi tiết mới
                        string queryInsert = @"INSERT INTO ChiTietHoaDonBan(MaHDB, MaSP, SoLuong, DonGia, GiamGiaSP)
                                             VALUES(@MaHDB,@MaSP,@SoLuong,@DonGia,@GiamGiaSP)";
                        foreach (var ct in chiTiet)
                        {
                            using (var cmdCt = new SqlCommand(queryInsert, conn, tran))
                            {
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
                        }

                        // Thành công
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        // Lỗi -> Rollback
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion Transaction Methods (Insert & Update)

        #region Query & Non-Transaction Methods

        /// <summary>
        /// Lấy tất cả hóa đơn, sắp xếp theo NgayBan giảm dần
        /// </summary>
        public List<HoaDonBan> GetAll()
        {
            string query = "SELECT * FROM HoaDonBan ORDER BY NgayBan DESC";

            // Sử dụng base.ExecuteQuery trả về DataTable
            DataTable dt = base.ExecuteQuery(query, null);

            var list = new List<HoaDonBan>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapFromDataRow(row));
            }
            return list;
        }

        /// <summary>
        /// Lấy hóa đơn theo mã hóa đơn
        /// </summary>
        public HoaDonBan? GetByMaHDB(string maHDB)
        {
            string query = "SELECT * FROM HoaDonBan WHERE MaHDB=@MaHDB";
            var parameters = new[] { CreateParameter("@MaHDB", maHDB) };

            DataTable dt = base.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return MapFromDataRow(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Cập nhật trạng thái hóa đơn
        /// </summary>
        public void UpdateTrangThai(string maHDB, byte trangThai)
        {
            string query = "UPDATE HoaDonBan SET TrangThaiHD=@TrangThai WHERE MaHDB=@MaHDB";
            var parameters = new[]
            {
                CreateParameter("@TrangThai", trangThai),
                CreateParameter("@MaHDB", maHDB)
            };

            // Sử dụng base.ExecuteNonQuery
            base.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Lấy danh sách chi tiết hóa đơn theo mã hóa đơn
        /// </summary>
        public List<ChiTietHoaDonBan> GetChiTietByMaHDB(string maHDB)
        {
            string query = "SELECT * FROM ChiTietHoaDonBan WHERE MaHDB=@MaHDB";
            var parameters = new[] { CreateParameter("@MaHDB", maHDB) };

            DataTable dt = base.ExecuteQuery(query, parameters);

            var list = new List<ChiTietHoaDonBan>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapChiTietFromDataRow(row));
            }
            return list;
        }

        /// <summary>
        /// Lọc hóa đơn theo các tiêu chí
        /// </summary>
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
                // Thêm 1 ngày để bao gồm cả ngày kết thúc (to < date + 1)
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

            DataTable dt = base.ExecuteQuery(query, parameters.ToArray());

            var list = new List<HoaDonBan>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapFromDataRow(row));
            }
            return list;
        }

        /// <summary>
        /// Xóa hóa đơn và chi tiết hoàn toàn khỏi database
        /// </summary>
        public void Delete(string maHDB)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Xóa chi tiết trước (foreign key constraint)
                        string queryDeleteDetails = "DELETE FROM ChiTietHoaDonBan WHERE MaHDB=@MaHDB";
                        using (var cmdDeleteDetails = new SqlCommand(queryDeleteDetails, conn, tran))
                        {
                            cmdDeleteDetails.Parameters.Add(CreateParameter("@MaHDB", maHDB));
                            cmdDeleteDetails.ExecuteNonQuery();
                        }

                        // 2. Xóa hóa đơn
                        string queryDeleteInvoice = "DELETE FROM HoaDonBan WHERE MaHDB=@MaHDB";
                        using (var cmdDeleteInvoice = new SqlCommand(queryDeleteInvoice, conn, tran))
                        {
                            cmdDeleteInvoice.Parameters.Add(CreateParameter("@MaHDB", maHDB));
                            cmdDeleteInvoice.ExecuteNonQuery();
                        }

                        // Thành công
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        // Lỗi -> Rollback
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion Query & Non-Transaction Methods
    }
}