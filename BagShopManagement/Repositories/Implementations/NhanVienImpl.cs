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
using DataAccessBase = BagShopManagement.DataAccess.BaseRepository;

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

        // --- HÀM GetNextMaNV (GEN MÃ 7 SỐ) ---
        public string GetNextMaNV()
        {
            // Cấu hình: 7 chữ số (0000001 -> 9999999), Tiền tố "NV"
            const int PADDING_LENGTH = 7;
            const string PREFIX = "NV";

            // Logic sinh mã: Lấy mã LỚN NHẤT hiện tại
            // Dùng CAST(SUBSTRING(...) AS INT) để sắp xếp theo SỐ
            string sql = $@"
                SELECT MAX(CAST(SUBSTRING(MaNV, {PREFIX.Length + 1}, {PADDING_LENGTH}) AS INT)) 
                FROM NhanVien 
                WHERE MaNV LIKE '{PREFIX}%' AND ISNUMERIC(SUBSTRING(MaNV, {PREFIX.Length + 1}, {PADDING_LENGTH})) = 1";

            var result = ExecuteScalar(sql); // Trả về số lớn nhất (ví dụ: 9) hoặc NULL

            int nextNum = 1; // Mặc định là 1 (cho trường hợp bảng rỗng)

            if (result != null && result != DBNull.Value)
            {
                nextNum = Convert.ToInt32(result) + 1; // Lấy số lớn nhất + 1
            }

            // Trả về mã mới với padding 7 số
            // ví dụ: "NV" + 1.ToString("D7") -> "NV0000001"
            return PREFIX + nextNum.ToString($"D{PADDING_LENGTH}");
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
                INSERT INTO NhanVien (MaNV, HoTen, ChucVu, SoDienThoai, Email, NgayVaoLam)
                VALUES (@MaNV, @HoTen, @ChucVu, @SoDienThoai, @Email, @NgayVaoLam)";

            using var cmd = new SqlCommand(sql, conn, tran);

            cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
            cmd.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
            cmd.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", nhanVien.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NgayVaoLam", nhanVien.NgayVaoLam);

            cmd.ExecuteNonQuery();
        }

        public void Update(NhanVien nhanVien, SqlConnection conn, SqlTransaction tran)
        {
            string sql = @"
                UPDATE NhanVien 
                SET HoTen = @HoTen, 
                    ChucVu = @ChucVu, 
                    SoDienThoai = @SoDienThoai, 
                    Email = @Email
                WHERE MaNV = @MaNV";

            using var cmd = new SqlCommand(sql, conn, tran);

            cmd.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
            cmd.Parameters.AddWithValue("@ChucVu", nhanVien.ChucVu ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", nhanVien.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);

            cmd.ExecuteNonQuery();
        }

        public List<NhanVien> GetAll()
        {
            string query = "SELECT MaNV, HoTen FROM NhanVien WHERE TrangThai = 1 ORDER BY HoTen";
            DataTable dt = base.ExecuteQuery(query);

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
            // Câu lệnh SQL JOIN và tìm kiếm trên nhiều cột
            string sql = @"
                SELECT 
                    nv.MaNV, nv.HoTen, nv.ChucVu, nv.SoDienThoai, nv.Email,
                    tk.TenDangNhap,
                    tk.TrangThai AS TrangThaiTK,
                    vt.MaVaiTro,
                    vt.TenVaiTro
                FROM NhanVien nv
                JOIN TaiKhoan tk ON nv.MaNV = tk.MaNV
                LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro
                WHERE 
                    nv.MaNV LIKE @keyword OR
                    nv.HoTen LIKE @keyword OR
                    tk.TenDangNhap LIKE @keyword OR
                    nv.SoDienThoai LIKE @keyword OR
                    nv.Email LIKE @keyword OR
                    vt.TenVaiTro LIKE @keyword";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            // Thêm tham số @keyword (ví dụ: "%admin%")
            cmd.Parameters.AddWithValue("@keyword", formattedKeyword);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Tái sử dụng hàm MapToNhanVienResponse
                list.Add(MapToNhanVienResponse(reader));
            }
            return list;
        }
    }
}