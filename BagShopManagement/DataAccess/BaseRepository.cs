using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DataAccess
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;

        protected BaseRepository()
        {
            // Đọc chuỗi kết nối tên "MyConnectionString" từ file App.config
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"]?.ConnectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                // Ném lỗi cấu hình nếu không tìm thấy chuỗi kết nối
                throw new ConfigurationErrorsException("Không tìm thấy chuỗi kết nối 'MyConnectionString' trong file App.config.");
            }
        }

        // 1. Thực thi truy vấn SELECT, trả về DataTable
        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Câu truy vấn không được để trống.", nameof(query));

            try
            {
                DataTable dt = new DataTable();
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    da.Fill(dt);
                }
                return dt;
            }
            catch (SqlException ex)
            {
                // Bắt lỗi SQL và ném ra một lỗi rõ ràng hơn
                throw new ApplicationException($"Lỗi cơ sở dữ liệu: {ex.Message}", ex);
            }
        }

        // 2. Thực thi INSERT, UPDATE, DELETE
        protected int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Câu lệnh không được để trống.", nameof(query));

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Lỗi cơ sở dữ liệu: {ex.Message}", ex);
            }
        }

        // 3. Thực thi truy vấn trả về 1 giá trị (COUNT, SUM, MAX...)
        protected object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Câu truy vấn không được để trống.", nameof(query));

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Lỗi cơ sở dữ liệu: {ex.Message}", ex);
            }
        }

        // 4. Kiểm tra kết nối
        public void TestConnection()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Không thể kết nối CSDL: {ex.Message}", ex);
            }
        }
    }
}