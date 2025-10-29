using BagShopManagement.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;

namespace BagShopManagement.DataAccess
{
    public static class DataAccessBase
    {
        private static readonly string ConnectionString = "Data Source=LAPTOP-AE7Q4M6M\\SQLEXPRESS; DataBase = BagStoreDb;Integrated Security=True;TrustServerCertificate=True";

        // 2. Thực thi truy vấn SELECT, trả về DataTable
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
        public static void TestConnection()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open(); // ném exception nếu thất bại
            }
        }
    }
}