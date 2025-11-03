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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Implementations
{
    public class HoaDonNhapImpl : BaseRepository, IHoaDonNhapRepository
    {
        // Helper map tu SqlDataReader/DataRow sang Model
        private HoaDonNhap MapToHoaDonNhap(DataRow row)
        {
            return new HoaDonNhap
            {
                MaHDN = row["MaHDN"].ToString(),
                MaNCC = row["MaNCC"].ToString(),
                MaNV = row["MaNV"].ToString(),
                NgayNhap = Convert.ToDateTime(row["NgayNhap"]),
                TongTien = Convert.ToDecimal(row["TongTien"]),
                GhiChu = row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : null
            };
        }

        // Helper map tu SqlDataReader/DataRow sang DTO
        private HoaDonNhapResponse MapToHoaDonNhapResponse(DataRow row)
        {
            return new HoaDonNhapResponse
            {
                MaHDN = row["MaHDN"].ToString(),
                TenNCC = row["TenNCC"] != DBNull.Value ? row["TenNCC"].ToString() : null,
                TenNV = row["TenNV"] != DBNull.Value ? row["TenNV"].ToString() : null,
                NgayNhap = (DateTime)row["NgayNhap"],
                TongTien = (decimal)row["TongTien"],
                GhiChu = row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : null
            };
        }

        //kiem tra da co hoa don nhap ton tai chua
        public bool Exists(string maHDN)
        {
            string query = "SELECT COUNT(1) FROM HoaDonNhap WHERE MaHDN = @MaHDN";
            var param = new SqlParameter("@MaHDN", maHDN);
            Object result = base.ExecuteScalar(query, param);
            return Convert.ToInt32(result) > 0;
        }

        //lay toan bo hoa do nhap chua join thong tin khac
        public List<HoaDonNhap> GetAll()
        {
            string query = "SELECT MaHDN, MaNCC, MaNV, NgayNhap, TongTien, GhiChu FROM HoaDonNhap";
            var dt = ExecuteQuery(query);

            List<HoaDonNhap> list = new List<HoaDonNhap>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapToHoaDonNhap(row));
            }
            return list;
        }

        //lay toan bo hoa don nhap da join thong tin khac de hien thi len giao dien
        public List<HoaDonNhapResponse> GetAllHoaDonNhap()
        {
            string query = @"
                SELECT hdn.MaHDN, ncc.TenNCC, nv.HoTen AS TenNV, hdn.NgayNhap, hdn.TongTien, hdn.GhiChu
                FROM HoaDonNhap hdn
                LEFT JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON hdn.MaNV = nv.MaNV
                ORDER BY hdn.NgayNhap DESC";
            DataTable dt = base.ExecuteQuery(query.ToString());

            var list = new List<HoaDonNhapResponse>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapToHoaDonNhapResponse(row));
            }
            return list;
        }

        //lay ra hoa don nhap theo ma hoa don nhap chua map thong tin khac
        public HoaDonNhap GetById(string maHDN)
        {
            string query = "SELECT * FROM HoaDonNhap WHERE MaHDN = @MaHDN";
            string connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (var conn = new SqlConnection(connString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHDN", maHDN);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new HoaDonNhap
                        {
                            MaHDN = reader["MaHDN"].ToString(),
                            MaNCC = reader["MaNCC"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                            TongTien = Convert.ToDecimal(reader["TongTien"]),
                            GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : null
                        };
                    }
                }
            }
            return null;
        }

        //phuong thuc lay ra 1 hoa don nhap va cac chi tiet hoa don nhap cua no dung de xem chi tiet hoa don
        public HoaDonNhapResponse HoaDonNhapViewModel(string maHDN)
        {
            string query1 = @"
                SELECT h.MaHDN, h.MaNCC, ncc.TenNCC, h.MaNV, nv.HoTen AS TenNV,
                       h.NgayNhap, h.TongTien, h.GhiChu
                FROM HoaDonNhap h
                LEFT JOIN NhaCungCap ncc ON h.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON h.MaNV = nv.MaNV
                WHERE h.MaHDN = @MaHDN;
            ";

            string query2 = @"
                SELECT c.MaSP, sp.TenSP, c.SoLuong, c.DonGia
                FROM ChiTietHoaDonNhap c
                LEFT JOIN SanPham sp ON c.MaSP = sp.MaSP
                WHERE c.MaHDN = @MaHDN;
            ";
            string finalQuery = query1 + query2;
            HoaDonNhapResponse hoaDonNhapResponse = null;
            var chiTiets = new List<ChiTietHDNResponse>();
            string connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (var conn = new SqlConnection(connString))
            {
                using (var cmd = new SqlCommand(finalQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHDN", maHDN);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hoaDonNhapResponse = new HoaDonNhapResponse
                            {
                                MaHDN = reader["MaHDN"].ToString(),
                                MaNCC = reader["MaNCC"] != DBNull.Value ? reader["MaNCC"].ToString() : null,
                                TenNCC = reader["TenNCC"] != DBNull.Value ? reader["TenNCC"].ToString() : null,
                                MaNV = reader["MaNV"] != DBNull.Value ? reader["MaNV"].ToString() : null,
                                TenNV = reader["TenNV"] != DBNull.Value ? reader["TenNV"].ToString() : null,
                                NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                                TongTien = Convert.ToDecimal(reader["TongTien"]),
                                GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : null
                            };
                        }
                        if (hoaDonNhapResponse == null) return null;

                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                var chiTiet = new ChiTietHDNResponse
                                {
                                    MaSP = reader["MaSP"].ToString(),
                                    TenSP = reader["TenSP"] != DBNull.Value ? reader["TenSP"].ToString() : null,
                                    SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                    DonGia = Convert.ToDecimal(reader["DonGia"])
                                };
                                chiTiets.Add(chiTiet);
                            }
                        }
                        hoaDonNhapResponse.ChiTiet = chiTiets;
                    }
                }
            }

            return hoaDonNhapResponse;
        }

        //them hoa don nhap khong co chi tiet hoa don nhap
        public string Insert(HoaDonNhap hoaDonNhap)
        {
            string query = @"INSERT INTO HoaDonNhap(MaHDN, MaNCC, MaNV, NgayNhap, TongTien, GhiChu)
                             VALUES(@MaHDN, @MaNCC, @MaNV, @NgayNhap, @TongTien, @GhiChu)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDN", hoaDonNhap.MaHDN),
                new SqlParameter("@MaNCC", hoaDonNhap.MaNCC),
                new SqlParameter("@MaNV", hoaDonNhap.MaNV),
                new SqlParameter("@NgayNhap", hoaDonNhap.NgayNhap),
                new SqlParameter("@TongTien", hoaDonNhap.TongTien),
                new SqlParameter("@GhiChu", (object?)hoaDonNhap.GhiChu ?? DBNull.Value)
            };
            ExecuteNonQuery(query, parameters);
            return hoaDonNhap.MaHDN;
        }

        // them hoa don nhap va chi tiet hoa don nhap cung luc va cap nhat ton kho
        public string InsertWithDetails(HoaDonNhap hoaDonNhap, List<ChiTietHoaDonNhap> chiTiets)
        {
            if (hoaDonNhap == null) throw new ArgumentNullException(nameof(hoaDonNhap));
            if (chiTiets == null || chiTiets.Count == 0) throw new ArgumentException("Danh sách chi tiết không được rỗng.", nameof(chiTiets));

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Thêm hóa đơn nhập
                        string insertHDNQuery = @"INSERT INTO HoaDonNhap(MaHDN, MaNCC, MaNV, NgayNhap, TongTien, GhiChu)
                                                  VALUES(@MaHDN, @MaNCC, @MaNV, @NgayNhap, @TongTien, @GhiChu)";
                        using (var cmdHDN = new SqlCommand(insertHDNQuery, conn, tran))
                        {
                            cmdHDN.Parameters.AddWithValue("@MaHDN", hoaDonNhap.MaHDN);
                            cmdHDN.Parameters.AddWithValue("@MaNCC", hoaDonNhap.MaNCC);
                            cmdHDN.Parameters.AddWithValue("@MaNV", hoaDonNhap.MaNV);
                            cmdHDN.Parameters.AddWithValue("@NgayNhap", hoaDonNhap.NgayNhap);
                            cmdHDN.Parameters.AddWithValue("@TongTien", hoaDonNhap.TongTien);
                            cmdHDN.Parameters.AddWithValue("@GhiChu", (object?)hoaDonNhap.GhiChu ?? DBNull.Value);
                            cmdHDN.ExecuteNonQuery();
                        }

                        // Thêm chi tiết HĐN (LINES) VÀ CẬP NHẬT KHO
                        foreach (var ct in chiTiets)
                        {
                            //  Thêm chi tiết hóa đơn nhập
                            string insertCTQuery = @"INSERT INTO ChiTietHoaDonNhap (MaHDN, MaSP, SoLuong, DonGia)
                                                     VALUES (@MaHDN, @MaSP, @SoLuong, @DonGia)";
                            using (var cmdCT = new SqlCommand(insertCTQuery, conn, tran))
                            {
                                cmdCT.Parameters.AddWithValue("@MaHDN", ct.MaHDN);
                                cmdCT.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                cmdCT.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                cmdCT.Parameters.AddWithValue("@DonGia", ct.DonGia);
                                cmdCT.ExecuteNonQuery();
                            }

                            // Cập nhật tồn kho
                            // Câu lệnh này cộng dồn số lượng vào tồn kho
                            string updateTonKhoQuery = @"UPDATE SanPham
                                                         SET SoLuongTon = SoLuongTon + @SoLuongNhap
                                                         WHERE MaSP = @MaSP";
                            using (var cmdTonKho = new SqlCommand(updateTonKhoQuery, conn, tran))
                            {
                                cmdTonKho.Parameters.AddWithValue("@SoLuongNhap", ct.SoLuong);
                                cmdTonKho.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                cmdTonKho.ExecuteNonQuery();
                            }
                        }

                        // Nếu tất cả OK -> Commit
                        tran.Commit();
                        return hoaDonNhap.MaHDN;
                    }
                    catch (Exception)
                    {
                        // Nếu có bất kỳ lỗi nào -> Rollback
                        tran.Rollback();
                        // Ném lỗi ra để tầng Service/Controller bắt
                        throw new ApplicationException("Lỗi khi thêm hoá đơn nhập, chi tiết và cập nhật tồn kho. Giao dịch đã được hoàn tác.");
                    }
                }
            }
        }

        public List<HoaDonNhapResponse> Search(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV)
        {
            var queryBuilder = new StringBuilder(@"
                SELECT hdn.MaHDN, ncc.TenNCC, nv.HoTen AS TenNV, hdn.NgayNhap, hdn.TongTien, hdn.GhiChu
                FROM HoaDonNhap hdn
                LEFT JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
                LEFT JOIN NhanVien nv ON hdn.MaNV = nv.MaNV
                WHERE 1=1
            ");
            var parameters = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(maHDN))
            {
                queryBuilder.Append(" AND hdn.MaHDN LIKE @MaHDN");
                parameters.Add(new SqlParameter("@MaHDN", "%" + maHDN + "%"));
            }
            if (tuNgay.HasValue)
            {
                queryBuilder.Append(" AND hdn.NgayNhap >= @TuNgay");
                parameters.Add(new SqlParameter("@TuNgay", tuNgay.Value.Date));
            }
            if (denNgay.HasValue)
            {
                queryBuilder.Append(" AND hdn.NgayNhap <= @DenNgay");
                parameters.Add(new SqlParameter("@DenNgay", denNgay.Value.Date.AddDays(1).AddTicks(-1)));
            }
            if (!string.IsNullOrWhiteSpace(maNCC))
            {
                queryBuilder.Append(" AND hdn.MaNCC = @MaNCC");
                parameters.Add(new SqlParameter("@MaNCC", maNCC));
            }
            if (!string.IsNullOrWhiteSpace(maNV))
            {
                queryBuilder.Append(" AND hdn.MaNV = @MaNV");
                parameters.Add(new SqlParameter("@MaNV", maNV));
            }
            queryBuilder.Append(" ORDER BY hdn.NgayNhap DESC");

            // Thực thi query
            DataTable dt = base.ExecuteQuery(queryBuilder.ToString(), parameters.ToArray());

            // Map kết quả
            var list = new List<HoaDonNhapResponse>();
            foreach (DataRow row in dt.Rows)
            {
                // Dùng helper để map an toàn
                list.Add(MapToHoaDonNhapResponse(row));
            }
            return list;
        }

        //Hàm này chuẩn
        public bool UpdateInfo(string maHDN, DateTime ngayNhap, string ghiChu)
        {
            string query = @"UPDATE HoaDonNhap
                             SET NgayNhap=@NgayNhap, GhiChu=@GhiChu
                             WHERE MaHDN=@MaHDN";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDN", maHDN),
                new SqlParameter("@NgayNhap", ngayNhap),
                new SqlParameter("@GhiChu", (object ?)ghiChu ?? DBNull.Value)
            };
            return ExecuteNonQuery(query, parameters) > 0;
        }

        // Các hàm implement interface rõ ràng
        bool IHoaDonNhapRepository.Delete(string maHDN)
        {
            string query = "DELETE FROM HoaDonNhap WHERE MaHDN=@MaHDN";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDN", maHDN)
            };
            return ExecuteNonQuery(query, parameters) > 0;
        }

        bool IHoaDonNhapRepository.Update(HoaDonNhap hoaDonNhap)
        {
            string query = @"UPDATE HoaDonNhap
                             SET MaNCC=@MaNCC, MaNV=@MaNV, NgayNhap=@NgayNhap, TongTien=@TongTien, GhiChu=@GhiChu
                             WHERE MaHDN=@MaHDN";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHDN", hoaDonNhap.MaHDN),
                new SqlParameter("@MaNCC", hoaDonNhap.MaNCC),
                new SqlParameter("@MaNV", hoaDonNhap.MaNV),
                new SqlParameter("@NgayNhap", hoaDonNhap.NgayNhap),
                new SqlParameter("@TongTien", hoaDonNhap.TongTien),
                new SqlParameter("@GhiChu", (object ?)hoaDonNhap.GhiChu ?? DBNull.Value)
            };
            return ExecuteNonQuery(query, parameters) > 0;
        }
    }
}