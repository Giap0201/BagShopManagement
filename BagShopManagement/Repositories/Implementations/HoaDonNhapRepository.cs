using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Models.Enums;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace BagShopManagement.Repositories.Implementations
{
    public class HoaDonNhapRepository : BaseRepository, IHoaDonNhapRepository
    {
        private readonly string _connectionString;

        public HoaDonNhapRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        private HoaDonNhap MapToHoaDonNhap(DataRow row)
        {
            return new HoaDonNhap
            {
                MaHDN = row["MaHDN"].ToString(),
                MaNCC = row["MaNCC"].ToString(),
                MaNV = row["MaNV"].ToString(),
                NgayNhap = Convert.ToDateTime(row["NgayNhap"]),
                NgayDuyet = row.IsNull("NgayDuyet") ? null : Convert.ToDateTime(row["NgayDuyet"]),
                TongTien = Convert.ToDecimal(row["TongTien"]),
                GhiChu = row.IsNull("GhiChu") ? null : row["GhiChu"].ToString(),
                TrangThai = Convert.ToByte(row["TrangThai"])
            };
        }

        private HoaDonNhapResponse MapToHoaDonNhapResponse(DataRow row)
        {
            return new HoaDonNhapResponse
            {
                MaHDN = row["MaHDN"]?.ToString() ?? "N/A",
                MaNCC = row["MaNCC"]?.ToString() ?? "N/A",
                TenNCC = row.IsNull("TenNCC") ? "N/A" : row["TenNCC"].ToString(),
                MaNV = row["MaNV"]?.ToString() ?? "N/A",
                TenNV = row.IsNull("TenNV") ? "N/A" : row["TenNV"].ToString(),
                NgayNhap = row.IsNull("NgayNhap") ? (DateTime?)null : Convert.ToDateTime(row["NgayNhap"]),
                NgayDuyet = row.IsNull("NgayDuyet") ? (DateTime?)null : Convert.ToDateTime(row["NgayDuyet"]),
                NgayHuy = row.IsNull("NgayHuy") ? (DateTime?)null : Convert.ToDateTime(row["NgayHuy"]),
                TongTien = row.IsNull("TongTien") ? 0 : Convert.ToDecimal(row["TongTien"]),
                GhiChu = row.IsNull("GhiChu") ? "" : row["GhiChu"].ToString(),
                TrangThai = row.IsNull("TrangThai")
                    ? TrangThaiHoaDonNhap.TamLuu
                    : (TrangThaiHoaDonNhap)Convert.ToByte(row["TrangThai"])
            };
        }

        private HoaDonNhapResponse MapHeader(IDataRecord reader)
        {
            return new HoaDonNhapResponse
            {
                MaHDN = reader["MaHDN"].ToString(),
                MaNCC = reader.IsDBNull(reader.GetOrdinal("MaNCC")) ? "" : reader["MaNCC"].ToString(),
                TenNCC = reader.IsDBNull(reader.GetOrdinal("TenNCC")) ? "" : reader["TenNCC"].ToString(),
                MaNV = reader.IsDBNull(reader.GetOrdinal("MaNV")) ? "" : reader["MaNV"].ToString(),
                TenNV = reader.IsDBNull(reader.GetOrdinal("TenNV")) ? "" : reader["TenNV"].ToString(),
                NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                NgayDuyet = reader.IsDBNull(reader.GetOrdinal("NgayDuyet")) ? null : Convert.ToDateTime(reader["NgayDuyet"]),
                NgayHuy = reader.IsDBNull(reader.GetOrdinal("NgayHuy")) ? null : Convert.ToDateTime(reader["NgayHuy"]),
                TongTien = Convert.ToDecimal(reader["TongTien"]),
                GhiChu = reader.IsDBNull(reader.GetOrdinal("GhiChu")) ? null : reader["GhiChu"].ToString(),
                TrangThai = (TrangThaiHoaDonNhap)Convert.ToByte(reader["TrangThai"])
            };
        }

        private ChiTietHDNResponse MapDetail(IDataRecord reader)
        {
            return new ChiTietHDNResponse
            {
                MaSP = reader["MaSP"].ToString(),
                TenSP = reader.IsDBNull(reader.GetOrdinal("TenSP")) ? "" : reader["TenSP"].ToString(),
                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                DonGia = Convert.ToDecimal(reader["DonGia"]),
                ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
            };
        }

        public bool Exists(string maHDN)
        {
            string sql = "SELECT COUNT(1) FROM HoaDonNhap WHERE MaHDN = @MaHDN";
            return Convert.ToInt32(ExecuteScalar(sql, new SqlParameter("@MaHDN", maHDN))) > 0;
        }

        public HoaDonNhap GetById(string maHDN)
        {
            string query = "SELECT * FROM HoaDonNhap WHERE MaHDN = @MaHDN";
            var dt = ExecuteQuery(query, new SqlParameter("@MaHDN", maHDN));
            return dt.Rows.Count > 0 ? MapToHoaDonNhap(dt.Rows[0]) : null;
        }

        public List<HoaDonNhapResponse> GetAllHoaDonNhap()
        {
            string query = @"
                SELECT hdn.MaHDN, hdn.MaNCC, ncc.TenNCC, hdn.MaNV, nv.HoTen AS TenNV,
                       hdn.NgayNhap, hdn.NgayDuyet, hdn.NgayHuy, hdn.TongTien, hdn.GhiChu, hdn.TrangThai
                FROM HoaDonNhap hdn
                LEFT JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON hdn.MaNV = nv.MaNV
                ORDER BY hdn.NgayNhap DESC";
            DataTable dt = ExecuteQuery(query);

            var list = new List<HoaDonNhapResponse>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToHoaDonNhapResponse(row));
            return list;
        }

        public string InsertDraft(HoaDonNhap hoaDonNhap, List<ChiTietHoaDonNhap> chiTiets)
        {
            if (hoaDonNhap == null) throw new ArgumentNullException(nameof(hoaDonNhap));
            if (chiTiets == null || chiTiets.Count == 0)
                throw new ArgumentException("Danh sách chi tiết không được rỗng.", nameof(chiTiets));

            hoaDonNhap.TrangThai = (byte)TrangThaiHoaDonNhap.TamLuu;
            hoaDonNhap.NgayDuyet = null;

            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                string sqlInsertHDN = @"
                    INSERT INTO HoaDonNhap(MaHDN, MaNCC, MaNV, NgayNhap, NgayDuyet, TongTien, GhiChu, TrangThai)
                    VALUES(@MaHDN, @MaNCC, @MaNV, @NgayNhap, @NgayDuyet, @TongTien, @GhiChu, @TrangThai)";
                using (var cmd = new SqlCommand(sqlInsertHDN, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@MaHDN", hoaDonNhap.MaHDN);
                    cmd.Parameters.AddWithValue("@MaNCC", hoaDonNhap.MaNCC);
                    cmd.Parameters.AddWithValue("@MaNV", hoaDonNhap.MaNV);
                    cmd.Parameters.AddWithValue("@NgayNhap", hoaDonNhap.NgayNhap);
                    cmd.Parameters.AddWithValue("@NgayDuyet", DBNull.Value);
                    cmd.Parameters.AddWithValue("@TongTien", hoaDonNhap.TongTien);
                    cmd.Parameters.AddWithValue("@GhiChu", (object?)hoaDonNhap.GhiChu ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TrangThai", hoaDonNhap.TrangThai);
                    cmd.ExecuteNonQuery();
                }

                string sqlCT = @"
                    INSERT INTO ChiTietHoaDonNhap(MaHDN, MaSP, SoLuong, DonGia, ThanhTien)
                    VALUES(@MaHDN, @MaSP, @SL, @DG, @TT)";

                using var cmdCT = new SqlCommand(sqlCT, conn, tran);
                cmdCT.Parameters.Add("@MaHDN", SqlDbType.VarChar, 20).Value = hoaDonNhap.MaHDN;
                cmdCT.Parameters.Add("@MaSP", SqlDbType.VarChar, 20);
                cmdCT.Parameters.Add("@SL", SqlDbType.Int);
                cmdCT.Parameters.Add("@DG", SqlDbType.Decimal);
                cmdCT.Parameters.Add("@TT", SqlDbType.Decimal);

                foreach (var ct in chiTiets)
                {
                    cmdCT.Parameters["@MaSP"].Value = ct.MaSP;
                    cmdCT.Parameters["@SL"].Value = ct.SoLuong;
                    cmdCT.Parameters["@DG"].Value = ct.DonGia;
                    cmdCT.Parameters["@TT"].Value = ct.ThanhTien;
                    cmdCT.ExecuteNonQuery();
                }

                tran.Commit();
                return hoaDonNhap.MaHDN;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new ApplicationException("Lỗi khi thêm hóa đơn nhập: " + ex.Message, ex);
            }
        }

        public bool UpdateDraftHeader(HoaDonNhap hoaDonNhap)
        {
            string sql = @"
                UPDATE HoaDonNhap
                SET MaNCC = @MaNCC,
                    MaNV = @MaNV,
                    NgayNhap = @NgayNhap,
                    GhiChu = @GhiChu
                WHERE MaHDN = @MaHDN AND TrangThai = @TamLuu";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaNCC", hoaDonNhap.MaNCC);
            cmd.Parameters.AddWithValue("@MaNV", hoaDonNhap.MaNV);
            cmd.Parameters.AddWithValue("@NgayNhap", hoaDonNhap.NgayNhap);
            cmd.Parameters.AddWithValue("@GhiChu", (object?)hoaDonNhap.GhiChu ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@MaHDN", hoaDonNhap.MaHDN);
            cmd.Parameters.AddWithValue("@TamLuu", (byte)TrangThaiHoaDonNhap.TamLuu);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        /// Duyet hoa don, cap nhat trang thai ngay duyet, cap nhat ton kho
        public bool ApproveDraftHoaDonNhap(string maHDN, DateTime ngayDuyet, List<ChiTietHoaDonNhap> chiTiets)
        {
            if (chiTiets == null || chiTiets.Count == 0)
                throw new ArgumentException("Chi tiết không được rỗng để duyệt.", nameof(chiTiets));

            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                string sqlUpdateKho = @"
                    UPDATE SanPham
                    SET SoLuongTon = SoLuongTon + @SL
                    WHERE MaSP = @MaSP";

                using (var cmdKho = new SqlCommand(sqlUpdateKho, conn, tran))
                {
                    cmdKho.Parameters.Add("@SL", SqlDbType.Int);
                    cmdKho.Parameters.Add("@MaSP", SqlDbType.VarChar, 20);

                    foreach (var ct in chiTiets)
                    {
                        cmdKho.Parameters["@SL"].Value = ct.SoLuong;
                        cmdKho.Parameters["@MaSP"].Value = ct.MaSP;
                        cmdKho.ExecuteNonQuery();
                    }
                }

                string sqlHDN = @"
                    UPDATE HoaDonNhap
                    SET TrangThai = @TrangThaiMoi, NgayDuyet = @NgayDuyet
                    WHERE MaHDN = @MaHDN AND TrangThai = @TrangThaiCu";
                using var cmdHDN = new SqlCommand(sqlHDN, conn, tran);
                cmdHDN.Parameters.AddWithValue("@TrangThaiMoi", (byte)TrangThaiHoaDonNhap.HoatDong);
                cmdHDN.Parameters.AddWithValue("@NgayDuyet", ngayDuyet);
                cmdHDN.Parameters.AddWithValue("@MaHDN", maHDN);
                cmdHDN.Parameters.AddWithValue("@TrangThaiCu", (byte)TrangThaiHoaDonNhap.TamLuu);

                int rowsAffected = cmdHDN.ExecuteNonQuery();
                if (rowsAffected == 0)
                    throw new ApplicationException("Hóa đơn không ở trạng thái 'Tạm lưu' hoặc không tồn tại.");

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new ApplicationException("Lỗi khi duyệt hóa đơn nhập: " + ex.Message, ex);
            }
        }

        // huy hoa don nhap khi da la hoat dong
        public bool CancelActiveHoaDonNhap(string maHDN, DateTime ngayHuy, List<ChiTietHoaDonNhap> chiTiets)
        {
            if (chiTiets == null || chiTiets.Count == 0)
                throw new ArgumentException("Chi tiết không được rỗng để hủy.", nameof(chiTiets));

            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                string sqlTruKho = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL WHERE MaSP = @MaSP";
                using (var cmdKho = new SqlCommand(sqlTruKho, conn, tran))
                {
                    cmdKho.Parameters.Add("@SL", SqlDbType.Int);
                    cmdKho.Parameters.Add("@MaSP", SqlDbType.VarChar, 20);

                    foreach (var ct in chiTiets)
                    {
                        cmdKho.Parameters["@SL"].Value = ct.SoLuong;
                        cmdKho.Parameters["@MaSP"].Value = ct.MaSP;
                        cmdKho.ExecuteNonQuery();
                    }
                }

                string sqlUpdate = @"
                    UPDATE HoaDonNhap
                    SET TrangThai = @TrangThaiMoi, NgayHuy = @NgayHuy
                    WHERE MaHDN = @MaHDN AND TrangThai = @TrangThaiCu";
                using var cmdU = new SqlCommand(sqlUpdate, conn, tran);
                cmdU.Parameters.AddWithValue("@TrangThaiMoi", (byte)TrangThaiHoaDonNhap.DaHuy);
                cmdU.Parameters.AddWithValue("@NgayHuy", ngayHuy);
                cmdU.Parameters.AddWithValue("@MaHDN", maHDN);
                cmdU.Parameters.AddWithValue("@TrangThaiCu", (byte)TrangThaiHoaDonNhap.HoatDong);

                if (cmdU.ExecuteNonQuery() == 0)
                    throw new ApplicationException("Hóa đơn không ở trạng thái 'Hoạt động' hoặc không tồn tại.");

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new ApplicationException("Lỗi khi hủy hóa đơn nhập: " + ex.Message, ex);
            }
        }

        public bool UpdateTrangThai(string maHDN, TrangThaiHoaDonNhap trangThai)
        {
            string sql = "UPDATE HoaDonNhap SET TrangThai = @TT WHERE MaHDN = @MaHDN";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TT", (byte)trangThai);
            cmd.Parameters.AddWithValue("@MaHDN", maHDN);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public HoaDonNhapResponse GetHoaDonNhapDetail(string maHDN)
        {
            string sql = @"
                SELECT h.MaHDN, h.MaNCC, ncc.TenNCC, h.MaNV, nv.HoTen AS TenNV,
                       h.NgayNhap, h.NgayDuyet, h.TongTien, h.GhiChu, h.TrangThai, h.NgayHuy
                FROM HoaDonNhap h
                LEFT JOIN NhaCungCap ncc ON h.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON h.MaNV = nv.MaNV
                WHERE h.MaHDN = @MaHDN;

                SELECT c.MaSP, sp.TenSP, c.SoLuong, c.DonGia,c.ThanhTien
                FROM ChiTietHoaDonNhap c
                LEFT JOIN SanPham sp ON c.MaSP = sp.MaSP
                WHERE c.MaHDN = @MaHDN;";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaHDN", maHDN);
            conn.Open();

            HoaDonNhapResponse result = null;
            List<ChiTietHDNResponse> details = new();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                result = MapHeader(reader);

            if (reader.NextResult())
            {
                while (reader.Read())
                    details.Add(MapDetail(reader));
            }

            if (result != null)
                result.ChiTiet = details;

            return result;
        }

        public List<HoaDonNhapResponse> Search(string? maHDN, DateTime? tuNgay, DateTime? denNgay, string? maNCC, string? maNV, byte? trangThai = null)
        {
            var queryBuilder = new StringBuilder(@"
                SELECT hdn.MaHDN, hdn.MaNCC, ncc.TenNCC, hdn.MaNV, nv.HoTen AS TenNV,
                       hdn.NgayNhap, hdn.NgayDuyet,hdn.NgayHuy, hdn.TongTien, hdn.GhiChu, hdn.TrangThai
                FROM HoaDonNhap hdn
                LEFT JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON hdn.MaNV = nv.MaNV
                WHERE 1=1");

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(maHDN))
            {
                queryBuilder.Append(" AND hdn.MaHDN LIKE @MaHDN");
                parameters.Add(new SqlParameter("@MaHDN", $"%{maHDN}%"));
            }
            if (!string.IsNullOrEmpty(maNCC))
            {
                queryBuilder.Append(" AND hdn.MaNCC = @MaNCC");
                parameters.Add(new SqlParameter("@MaNCC", maNCC));
            }
            if (!string.IsNullOrEmpty(maNV))
            {
                queryBuilder.Append(" AND hdn.MaNV = @MaNV");
                parameters.Add(new SqlParameter("@MaNV", maNV));
            }
            if (trangThai.HasValue)
            {
                queryBuilder.Append(" AND hdn.TrangThai = @TrangThai");
                parameters.Add(new SqlParameter("@TrangThai", trangThai.Value));
            }
            if (tuNgay.HasValue)
            {
                queryBuilder.Append(" AND hdn.NgayNhap >= @TuNgay");
                parameters.Add(new SqlParameter("@TuNgay", tuNgay.Value.Date));
            }
            if (denNgay.HasValue)
            {
                queryBuilder.Append(" AND hdn.NgayNhap < @DenNgay");
                parameters.Add(new SqlParameter("@DenNgay", denNgay.Value.Date.AddDays(1)));
            }

            queryBuilder.Append(" ORDER BY hdn.NgayNhap DESC");

            DataTable dt = ExecuteQuery(queryBuilder.ToString(), parameters.ToArray());

            var list = new List<HoaDonNhapResponse>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapToHoaDonNhapResponse(row));
            return list;
        }

        public List<HoaDonNhap> GetAll()
        {
            string query = "select MaHDN from HoaDonNhap order by MaHDN";
            DataTable dt = ExecuteQuery(query);
            var list = new List<HoaDonNhap>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new HoaDonNhap
                {
                    MaHDN = row["MaHDN"].ToString()
                });
            }
            return list;
        }
    }
}