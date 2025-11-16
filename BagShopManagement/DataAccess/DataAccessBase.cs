using BagShopManagement.Models;
using BagShopManagement.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;
using System.Text.Json;

namespace BagShopManagement.DataAccess
{
    /// <summary>
    /// [DEPRECATED] Sử dụng BaseRepository thay thế
    /// Class này được giữ lại để backward compatibility với code legacy
    /// Các repository mới nên kế thừa BaseRepository
    /// </summary>
    [Obsolete("Use BaseRepository pattern instead. This class is kept for backward compatibility only.")]
    public static class DataAccessBase
    {
        //chuoi ket noi - uu tien doc tu appsettings.json, fallback ve hardcoded
        private static readonly string ConnectionString = LoadConnectionString();

        private static string LoadConnectionString()
        {
            try
            {
                string appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
                if (File.Exists(appSettingsPath))
                {
                    string json = File.ReadAllText(appSettingsPath);
                    using (JsonDocument doc = JsonDocument.Parse(json))
                    {
                        if (doc.RootElement.TryGetProperty("ConnectionStrings", out JsonElement connStrings))
                        {
                            if (connStrings.TryGetProperty("Default", out JsonElement defaultConn))
                            {
                                return defaultConn.GetString() ?? GetFallbackConnectionString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to load connection string from appsettings.json: {ex.Message}. Using fallback.");
            }
            return GetFallbackConnectionString();
        }

        private static string GetFallbackConnectionString()
        {
            return "Server=DESKTOP-862VN9A;Database=BagShopManagementDB;User Id=sa;Password=Ndtrung@3605;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public static string GetConnectionString()
        {
            return ConnectionString;
        }

        //phuong thuc tao va mo ket noi voi database
        public static SqlConnection GetConnection()
        {
            try
            {
                var conn = new SqlConnection(ConnectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                return conn;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex, "Không thể kết nối với DB");
                return null;
            }
        }

        //thuc thi cau truy van select, tra ve datatable co ket qua
        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Câu truy vấn không được để trống.", nameof(query));

            DataTable dt = new DataTable();

            using (var conn = new SqlConnection(ConnectionString))
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

        // 3. Thực thi INSERT, UPDATE, DELETE
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Câu lệnh không được để trống.", nameof(query));

            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 4. Thực thi truy vấn trả về 1 giá trị (COUNT, SUM, MAX...)
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Câu truy vấn không được để trống.", nameof(query));

            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        // 5. Kiểm tra kết nối
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    return conn != null && conn.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
        public static void InsertChuongTrinhGiamGia(ChuongTrinhGiamGia ctgg)
        {
            string query = "INSERT INTO ChuongTrinhGiamGia (MaCTGG, TenChuongTrinh, NgayBatDau, NgayKetThuc, MoTa, TrangThai) VALUES (@MaCTGG, @Ten, @NgayBD, @NgayKT, @MoTa, @TrangThai)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaCTGG", ctgg.MaCTGG),
                new SqlParameter("@Ten", ctgg.TenChuongTrinh),
                new SqlParameter("@NgayBD", ctgg.NgayBatDau),
                new SqlParameter("@NgayKT", ctgg.NgayKetThuc),
                new SqlParameter("@MoTa", ctgg.MoTa),
                new SqlParameter("@TrangThai", ctgg.TrangThai)
            };

            ExecuteNonQuery(query, parameters);
        }
    }
}