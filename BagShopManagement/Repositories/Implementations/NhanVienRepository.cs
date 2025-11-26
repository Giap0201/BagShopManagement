using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessBase = BagShopManagement.Repositories.BaseRepository;

namespace BagShopManagement.Repositories.Implementations
{
    public class NhanVienRepository : BaseRepository, INhanVienRepository
    {
        // --- MAPPERS ---
        private NhanVien MapToNhanVien(DataRow row)
        {
            return new NhanVien
            {
                MaNV = row["MaNV"].ToString(),
                HoTen = row["HoTen"].ToString(),
                ChucVu = row["ChucVu"] != DBNull.Value ? row["ChucVu"].ToString() : null,
                SoDienThoai = row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : null,
                Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : null,
                NgayVaoLam = Convert.ToDateTime(row["NgayVaoLam"]),
            };
        }

        private NhanVienResponse MapToNhanVienResponse(DataRow row)
        {
            return new NhanVienResponse
            {
                MaNV = row["MaNV"].ToString(),
                HoTen = row["HoTen"].ToString(),
                ChucVu = row["ChucVu"] != DBNull.Value ? row["ChucVu"].ToString() : null,
                SoDienThoai = row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : null,
                Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : null,

                // Từ JOIN TaiKhoan & VaiTro
                TenDangNhap = row["TenDangNhap"] != DBNull.Value ? row["TenDangNhap"].ToString() : "",
                MaVaiTro = row["MaVaiTro"] != DBNull.Value ? row["MaVaiTro"].ToString() : null,
                TenVaiTro = row["TenVaiTro"] != DBNull.Value ? row["TenVaiTro"].ToString() : null,
                TrangThaiTK = row["TrangThaiTK"] != DBNull.Value && Convert.ToBoolean(row["TrangThaiTK"])
            };
        }

        // --- CRUD METHODS ---

        public NhanVien GetById(string maNV)
        {
            string query = "SELECT * FROM NhanVien WHERE MaNV = @MaNV";
            SqlParameter[] p = { new SqlParameter("@MaNV", maNV) };

            DataTable dt = ExecuteQuery(query, p);
            return dt.Rows.Count > 0 ? MapToNhanVien(dt.Rows[0]) : null;
        }

        public List<NhanVienResponse> GetAllForDisplay()
        {
            var list = new List<NhanVienResponse>();
            // Sử dụng LEFT JOIN để vẫn hiện nhân viên dù chưa có tài khoản
            string query = @"
                SELECT
                    nv.MaNV, nv.HoTen, nv.ChucVu, nv.SoDienThoai, nv.Email,
                    tk.TenDangNhap,
                    tk.TrangThai AS TrangThaiTK,
                    vt.MaVaiTro,
                    vt.TenVaiTro
                FROM NhanVien nv
                LEFT JOIN TaiKhoan tk ON nv.MaNV = tk.MaNV
                LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro";

            DataTable dt = ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapToNhanVienResponse(row));
            }
            return list;
        }

        public string GetNextMaNV()
        {
            const int PADDING_LENGTH = 7;
            const string PREFIX = "NV";

            // Lấy phần số của mã nhân viên lớn nhất hiện tại
            string query = $@"
                SELECT MAX(CAST(SUBSTRING(MaNV, {PREFIX.Length + 1}, {PADDING_LENGTH}) AS INT))
                FROM NhanVien
                WHERE MaNV LIKE '{PREFIX}%' AND ISNUMERIC(SUBSTRING(MaNV, {PREFIX.Length + 1}, {PADDING_LENGTH})) = 1";

            object result = ExecuteScalar(query);

            int nextNum = 1;
            if (result != null && result != DBNull.Value)
            {
                nextNum = Convert.ToInt32(result) + 1;
            }

            // Format thành chuỗi (ví dụ: NV0000005)
            return PREFIX + nextNum.ToString($"D{PADDING_LENGTH}");
        }

        public void Add(NhanVien nhanVien)
        {
            string query = @"INSERT INTO NhanVien (MaNV, HoTen, ChucVu, SoDienThoai, Email, NgayVaoLam) 
                             VALUES (@MaNV, @HoTen, @ChucVu, @SoDienThoai, @Email, @NgayVaoLam)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaNV", nhanVien.MaNV),
                new SqlParameter("@HoTen", nhanVien.HoTen),
                new SqlParameter("@ChucVu", (object)nhanVien.ChucVu ?? DBNull.Value),
                new SqlParameter("@SoDienThoai", (object)nhanVien.SoDienThoai ?? DBNull.Value),
                new SqlParameter("@Email", (object)nhanVien.Email ?? DBNull.Value),
                new SqlParameter("@NgayVaoLam", nhanVien.NgayVaoLam)
            };

            ExecuteNonQuery(query, parameters);
        }

        public void Update(NhanVien nhanVien)
        {
            string query = @"UPDATE NhanVien 
                             SET HoTen = @HoTen, 
                                 ChucVu = @ChucVu, 
                                 SoDienThoai = @SoDienThoai, 
                                 Email = @Email
                             WHERE MaNV = @MaNV";

            SqlParameter[] parameters =
            {
                new SqlParameter("@HoTen", nhanVien.HoTen),
                new SqlParameter("@ChucVu", (object)nhanVien.ChucVu ?? DBNull.Value),
                new SqlParameter("@SoDienThoai", (object)nhanVien.SoDienThoai ?? DBNull.Value),
                new SqlParameter("@Email", (object)nhanVien.Email ?? DBNull.Value),
                new SqlParameter("@MaNV", nhanVien.MaNV)
            };

            ExecuteNonQuery(query, parameters);
        }

        public List<NhanVien> GetAll()
        {
            // Giữ nguyên logic cũ của bạn: Chỉ lấy nhân viên có tài khoản Active (cho dropdown)
            string query = @"SELECT NhanVien.MaNV, HoTen 
                             FROM NhanVien 
                             JOIN TaiKhoan tk on tk.MaNV = NhanVien.MaNV 
                             WHERE tk.TrangThai = 1 
                             ORDER BY HoTen";

            DataTable dt = ExecuteQuery(query);
            var list = new List<NhanVien>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhanVien
                {
                    MaNV = row["MaNV"].ToString(),
                    HoTen = row["HoTen"].ToString()
                });
            }
            return list;
        }

        public List<NhanVienResponse> Search(string formattedKeyword)
        {
            var list = new List<NhanVienResponse>();
            string query = @"
                SELECT
                    nv.MaNV, nv.HoTen, nv.ChucVu, nv.SoDienThoai, nv.Email,
                    tk.TenDangNhap,
                    tk.TrangThai AS TrangThaiTK,
                    vt.MaVaiTro,
                    vt.TenVaiTro
                FROM NhanVien nv
                LEFT JOIN TaiKhoan tk ON nv.MaNV = tk.MaNV
                LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro
                WHERE
                    nv.MaNV LIKE @keyword OR
                    nv.HoTen LIKE @keyword OR
                    tk.TenDangNhap LIKE @keyword OR
                    nv.SoDienThoai LIKE @keyword OR
                    nv.Email LIKE @keyword OR
                    vt.TenVaiTro LIKE @keyword";

            SqlParameter[] p = { new SqlParameter("@keyword", formattedKeyword) };

            DataTable dt = ExecuteQuery(query, p);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapToNhanVienResponse(row));
            }
            return list;
        }
    }
}