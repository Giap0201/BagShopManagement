using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BagShopManagement.Utils;

namespace BagShopManagement.DataAccess
{
    public class SqlDataAccess : IDataAccess
    {
        private readonly string _connectionString;

        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            if (parameters != null && parameters.Length > 0)
                command.Parameters.AddRange(parameters);

            var dt = new DataTable();
            using var adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }

        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            if (parameters != null && parameters.Length > 0)
                command.Parameters.AddRange(parameters);

            connection.Open();
            return command.ExecuteNonQuery();
        }

        public object? ExecuteScalar(string query, List<SqlParameter>? parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection);
                if (parameters != null)
                    command.Parameters.AddRange(parameters.ToArray());

                connection.Open();
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Logger.Log($"[ExecuteScalar] {ex.Message}");
                throw;
            }
        }
    }
}
