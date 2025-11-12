using BagShopManagement.DataAccess;
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

namespace BagShopManagement.Repositories.Implementations
{
    public class NhanVienImpl : BaseRepository, INhanVienRepository
    {
        private readonly string _connectionString;

        public NhanVienImpl()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"]?.ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ConfigurationErrorsException("Không tìm thấy chuỗi kết nối 'MyConnectionString'.");
            }
        }

        private NhanVien MapToNhanVien(IDataRecord reader)
        {
            return new NhanVien
            {
                MaNV = reader["MaNV"].ToString(),
                HoTen = reader["HoTen"].ToString(),
                ChucVu = reader["ChucVu"] != DBNull.Value ? reader["ChucVu"].ToString() : null,
                SoDienThoai = reader["SoDienThoai"] != DBNull.Value ? reader["SoDienThoai"].ToString() : null,
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                NgayVaoLam = Convert.ToDateTime(reader["NgayVaoLam"]),
                TrangThai = Convert.ToBoolean(reader["TrangThai"])
            };
        }

        // Helper Map cho DTO
        private NhanVienResponse MapToNhanVienResponse(IDataRecord reader)
        {
            return new NhanVienResponse
            {
                MaNV = reader["MaNV"].ToString(),
                HoTen = reader["HoTen"].ToString(),
                ChucVu = reader["ChucVu"] != DBNull.Value ? reader["ChucVu"].ToString() : null,
                SoDienThoai = reader["SoDienThoai"] != DBNull.Value ? reader["SoDienThoai"].ToString() : null,
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,

                // Từ JOIN
                TenDangNhap = reader["TenDangNhap"].ToString(),
                MaVaiTro = reader["MaVaiTro"] != DBNull.Value ? reader["MaVaiTro"].ToString() : null,
                TenVaiTro = reader["TenVaiTro"] != DBNull.Value ? reader["TenVaiTro"].ToString() : null,
                TrangThaiTK = Convert.ToBoolean(reader["TrangThaiTK"])
            };
        }


        public NhanVien GetById(string maNV)
        {
            string sql = "SELECT * FROM NhanVien WHERE MaNV = @MaNV";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapToNhanVien(reader) : null;
        }

        public List<NhanVienResponse> GetAllForDisplay()
        {
            var list = new List<NhanVienResponse>();
            // Câu query JOIN 3 bảng
            string sql = @"
                SELECT 
                    nv.MaNV, nv.HoTen, nv.ChucVu, nv.SoDienThoai, nv.Email,
                    tk.TenDangNhap,
                    tk.TrangThai AS TrangThaiTK,
                    vt.MaVaiTro,
                    vt.TenVaiTro
                FROM NhanVien nv
                JOIN TaiKhoan tk ON nv.MaNV = tk.MaNV
                LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapToNhanVienResponse(reader));
            }
            return list;
        }

        public string GetNextMaNV()
        {
            // Logic sinh mã: Lấy mã lớn nhất hiện tại (ví dụ: NV005) + 1 -> NV006
            string sql = "SELECT MAX(MaNV) FROM NhanVien WHERE MaNV LIKE 'NV%'";

            var maxMaNV = ExecuteScalar(sql)?.ToString();

            if (string.IsNullOrEmpty(maxMaNV))
            {
                return "NV001"; // Bắt đầu
            }

            // Tách phần số (ví dụ: "NV005" -> "005")
            string numPart = maxMaNV.Substring(2);
            if (int.TryParse(numPart, out int num))
            {
                num++; // Tăng lên 1
                return "NV" + num.ToString("D3"); // "D3" = 006
            }

            // Fallback nếu logic lỗi
            throw new Exception("Không thể sinh Mã Nhân Viên mới.");
        }

        // --- Phiên bản không transaction ---
        public void Add(NhanVien nhanVien)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                Add(nhanVien, conn, tran);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public void Update(NhanVien nhanVien)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                Update(nhanVien, conn, tran);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        // --- PHIÊN BẢN TRANSACTION ---
        public void Add(NhanVien nhanVien, SqlConnection conn, SqlTransaction tran)
        {
            string sql = @"
                INSERT INTO NhanVien (MaNV, HoTen, ChucVu, SoDienThoai, Email, NgayVaoLam, TrangThai)
                VALUES (@MaNV, @HoTen, @ChucVu, @SoDienThoai, @Email, @NgayVaoLam, @TrangThai)";

            using var cmd = new SqlCommand(sql, conn, tran);

            cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
            cmd.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
            cmd.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", nhanVien.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NgayVaoLam", nhanVien.NgayVaoLam);
            cmd.Parameters.AddWithValue("@TrangThai", nhanVien.TrangThai);

            cmd.ExecuteNonQuery();
        }

        public void Update(NhanVien nhanVien, SqlConnection conn, SqlTransaction tran)
        {
            string sql = @"
                UPDATE NhanVien 
                SET HoTen = @HoTen, 
                    ChucVu = @ChucVu, 
                    SoDienThoai = @SoDienThoai, 
                    Email = @Email, 
                    TrangThai = @TrangThai
                WHERE MaNV = @MaNV";

            using var cmd = new SqlCommand(sql, conn, tran);

            cmd.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
            cmd.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", nhanVien.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@TrangThai", nhanVien.TrangThai);
            cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);

            cmd.ExecuteNonQuery();
        }
    }
}
