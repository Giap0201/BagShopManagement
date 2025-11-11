using BagShopManagement.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;
using System.Text.Json;

namespace BagShopManagement.DataAccess
{
    /// <summary>
    /// Quản lý cấu hình database connection
    /// - Đọc connection string từ appsettings.json
    /// - Cung cấp fallback nếu file không tồn tại
    /// - Thay thế cho DataAccessBase (deprecated)
    /// </summary>
    public static class DatabaseConfig
    {
        private static readonly string ConnectionString = LoadConnectionString();

        /// <summary>
        /// Đọc connection string từ appsettings.json với fallback
        /// </summary>
        /// <returns>Connection string từ config hoặc fallback value</returns>
        /// <remarks>
        /// Thứ tự ưu tiên:
        /// 1. appsettings.json -> ConnectionStrings.Default
        /// 2. Fallback hardcoded connection string
        /// </remarks>
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
                                string? connStr = defaultConn.GetString();
                                if (!string.IsNullOrEmpty(connStr))
                                {
                                    Logger.Log($"[INFO] Loaded connection string from appsettings.json");
                                    return connStr;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"[WARN] Failed to load connection string from appsettings.json: {ex.Message}. Using fallback.");
            }

            return GetFallbackConnectionString();
        }

        /// <summary>
        /// Connection string fallback khi không đọc được từ appsettings.json
        /// </summary>
        /// <returns>Hardcoded connection string để đảm bảo app vẫn chạy được</returns>
        /// <remarks>
        /// ⚠️ Warning: Chứa thông tin nhạy cảm (password hardcoded)
        /// Chỉ dùng cho development, production nên dùng appsettings.json
        /// </remarks>
        private static string GetFallbackConnectionString()
        {
            return "Server=DESKTOP-862VN9A;Database=BagShopManagementDB;User Id=sa;Password=Ndtrung@3605;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        /// <summary>
        /// Lấy connection string hiện tại
        /// </summary>
        /// <returns>Connection string đã được load từ config hoặc fallback</returns>
        public static string GetConnectionString()
        {
            return ConnectionString;
        }

        /// <summary>
        /// Kiểm tra kết nối database có thành công không
        /// </summary>
        /// <returns>True nếu kết nối thành công, False nếu thất bại</returns>
        public static bool TestConnection()
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                conn.Open();
                return conn.State == ConnectionState.Open;
            }
            catch (Exception ex)
            {
                Logger.Log($"[ERROR] TestConnection failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Tạo SqlConnection mới (chưa mở kết nối)
        /// </summary>
        /// <returns>SqlConnection instance mới với connection string đã config</returns>
        /// <remarks>
        /// Caller chịu trách nhiệm:
        /// - Gọi connection.Open() trước khi sử dụng
        /// - Dispose connection sau khi dùng xong (using statement)
        /// </remarks>
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
