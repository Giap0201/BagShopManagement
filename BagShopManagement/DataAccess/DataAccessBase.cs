using BagShopManagement.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BagShopManagement.DataAccess
{
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
            if (string.IsNullOrEmpty(query))
            {
                ExceptionHandler.Handle(new ArgumentException("Câu truy vấn không được để trống."), "Lỗi truy vấn.");
                return null;
            }
            using (var conn = GetConnection())
            {
                if (conn == null) return null;
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex, $"Lỗi khi thực thi truy vấn: {query}");
                    return null;
                }
            }
        }

        //thuc thi cau lenh select, update, delete, tra ve so dong bi anh huong
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                ExceptionHandler.Handle(new ArgumentException("Câu lệnh không được để trống."), "Lỗi câu lệnh.");
                return -1;
            }

            using (SqlConnection conn = GetConnection())
            {
                if (conn == null)
                    return -1;

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex, $"Lỗi khi thực thi câu lệnh: {query}");
                    return -1;
                }
            }
        }

        //thuc thi cau truy van tra ve gia tri don count,sum
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                ExceptionHandler.Handle(new ArgumentException("Câu truy vấn không được để trống."), "Lỗi truy vấn.");
                return null;
            }

            using (SqlConnection conn = GetConnection())
            {
                if (conn == null)
                    return null;

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);

                        return cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex, $"Lỗi khi thực thi truy vấn scalar: {query}");
                    return null;
                }
            }
        }

        //kiem tra ket noi co so du lieu
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
    }
}