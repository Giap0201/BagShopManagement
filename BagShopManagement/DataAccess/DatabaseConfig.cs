using BagShopManagement.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;
using System.Text.Json;

namespace BagShopManagement.DataAccess
{
    /// <summary>
    /// Quản lý cấu hình database - chỉ chứa connection string logic
    /// Thay thế cho DataAccessBase (deprecated)
    /// </summary>
    public static class DatabaseConfig
    {
        private static readonly string ConnectionString = LoadConnectionString();

        /// <summary>
        /// Đọc connection string từ appsettings.json với fallback
        /// </summary>
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
        private static string GetFallbackConnectionString()
        {
            return "Server=DESKTOP-862VN9A;Database=BagShopManagementDB;User Id=sa;Password=Ndtrung@3605;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        /// <summary>
        /// Lấy connection string hiện tại
        /// </summary>
        public static string GetConnectionString()
        {
            return ConnectionString;
        }

        /// <summary>
        /// Kiểm tra kết nối database
        /// </summary>
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
        /// Tạo SqlConnection mới (không tự động mở)
        /// </summary>
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
