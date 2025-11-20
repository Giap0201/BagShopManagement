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
    public class TaiKhoanImpl : BaseRepository, ITaiKhoanRepository
    {
        private readonly string _connectionString;

        public TaiKhoanImpl()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"]?.ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ConfigurationErrorsException("Không tìm thấy chuỗi kết nối 'MyConnectionString'.");
            }
        }

        private TaiKhoan MapToTaiKhoan(IDataRecord reader)
        {
            return new TaiKhoan
            {
                TenDangNhap = reader["TenDangNhap"].ToString(),
                MatKhau = reader["MatKhau"].ToString(),
                MaNV = reader["MaNV"] != DBNull.Value ? reader["MaNV"].ToString() : null,
                MaVaiTro = reader["MaVaiTro"] != DBNull.Value ? reader["MaVaiTro"].ToString() : null,
                TrangThai = Convert.ToBoolean(reader["TrangThai"])
            };
        }

        public TaiKhoan GetByTenDangNhap(string tenDangNhap)
        {
            string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapToTaiKhoan(reader) : null;
        }

        public TaiKhoan GetByMaNV(string maNV)
        {
            string sql = "SELECT * FROM TaiKhoan WHERE MaNV = @MaNV";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapToTaiKhoan(reader) : null;
        }

        public bool UpdatePassword(string tenDangNhap, string newHashedPassword)
        {
            string sql = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE TenDangNhap = @TenDangNhap";
            int rowsAffected = ExecuteNonQuery(sql,
                new SqlParameter("@MatKhau", newHashedPassword),
                new SqlParameter("@TenDangNhap", tenDangNhap)
            );
            return rowsAffected > 0;
        }

        public bool ExistsByTenDangNhap(string tenDangNhap)
        {
            string sql = "SELECT COUNT(1) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            var result = ExecuteScalar(sql, new SqlParameter("@TenDangNhap", tenDangNhap));
            return Convert.ToInt32(result) > 0;
        }

        // --- Phiên bản không transaction (tự quản lý connection) ---
        public void Add(TaiKhoan taiKhoan)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            // Bắt đầu transaction cục bộ
            using var tran = conn.BeginTransaction();
            try
            {
                Add(taiKhoan, conn, tran);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public void Update(TaiKhoan taiKhoan)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            // Bắt đầu transaction cục bộ
            using var tran = conn.BeginTransaction();
            try
            {
                Update(taiKhoan, conn, tran);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }


        // --- PHIÊN BẢN TRANSACTION (dùng chung connection & transaction) ---

        public void Add(TaiKhoan taiKhoan, SqlConnection conn, SqlTransaction tran)
        {
            string sql = @"
                INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNV, MaVaiTro, TrangThai)
                VALUES (@TenDangNhap, @MatKhau, @MaNV, @MaVaiTro, @TrangThai)";

            // Dùng connection và transaction được truyền vào
            using var cmd = new SqlCommand(sql, conn, tran);

            cmd.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
            cmd.Parameters.AddWithValue("@MaNV", taiKhoan.MaNV ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@MaVaiTro", taiKhoan.MaVaiTro ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@TrangThai", taiKhoan.TrangThai);

            cmd.ExecuteNonQuery();
        }

        public void Update(TaiKhoan taiKhoan, SqlConnection conn, SqlTransaction tran)
        {
            string sql = @"
                UPDATE TaiKhoan 
                SET MaVaiTro = @MaVaiTro, TrangThai = @TrangThai
                WHERE TenDangNhap = @TenDangNhap";

            // Dùng connection và transaction được truyền vào
            using var cmd = new SqlCommand(sql, conn, tran);

            cmd.Parameters.AddWithValue("@MaVaiTro", taiKhoan.MaVaiTro ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@TrangThai", taiKhoan.TrangThai);
            cmd.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);

            cmd.ExecuteNonQuery();
        }
    }
}
