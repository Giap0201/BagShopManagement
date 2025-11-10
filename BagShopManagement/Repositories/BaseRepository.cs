using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BagShopManagement.DataAccess;
using BagShopManagement.Utils;
using Microsoft.Data.SqlClient;

namespace BagShopManagement.Repositories
{
    /// <summary>
    /// Base repository class cung cấp các phương thức truy cập database chung
    /// Kế thừa class này để sử dụng các phương thức ExecuteQuery, ExecuteScalar, ExecuteNonQuery
    /// </summary>
    public abstract class BaseRepository
    {
        protected readonly string _connectionString;

        protected BaseRepository()
        {
            _connectionString = DatabaseConfig.GetConnectionString();
        }

        #region Query Methods (SELECT)

        /// <summary>
        /// Thực thi câu query SELECT và map kết quả về List<T>
        /// </summary>
        /// <typeparam name="T">Type của đối tượng cần map</typeparam>
        /// <param name="query">Câu SQL query</param>
        /// <param name="parameters">SqlParameter[] - tham số cho query</param>
        /// <param name="mapFunc">Func để map từ SqlDataReader sang đối tượng T</param>
        /// <returns>List<T></returns>
        protected async Task<List<T>> ExecuteQueryAsync<T>(string query, SqlParameter[]? parameters, Func<SqlDataReader, T> mapFunc)
        {
            try
            {
                var results = new List<T>();

                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                results.Add(mapFunc(reader));
                            }
                        }
                    }
                }

                return results;
            }
            catch (Exception ex)
            {
                Logger.Log($"[ERROR] ExecuteQueryAsync: {ex.Message}");
                ExceptionHandler.Handle(ex, "Lỗi truy vấn dữ liệu");
                return new List<T>();
            }
        }

        /// <summary>
        /// Thực thi câu query SELECT đồng bộ
        /// </summary>
        protected List<T> ExecuteQuery<T>(string query, SqlParameter[]? parameters, Func<SqlDataReader, T> mapFunc)
        {
            try
            {
                var results = new List<T>();

                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(mapFunc(reader));
                            }
                        }
                    }
                }

                return results;
            }
            catch (Exception ex)
            {
                Logger.Log($"ExecuteQuery error: {ex.Message}");
                ExceptionHandler.Handle(ex, "Lỗi truy vấn dữ liệu");
                return new List<T>();
            }
        }

        #endregion

        #region Scalar Methods (SELECT Single Value)

        /// <summary>
        /// Thực thi query và trả về giá trị đơn (COUNT, MAX, MIN, SUM...)
        /// </summary>
        protected async Task<object?> ExecuteScalarAsync(string query, SqlParameter[]? parameters = null)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        return await cmd.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"ExecuteScalarAsync error: {ex.Message}");
                ExceptionHandler.Handle(ex, "Lỗi truy vấn dữ liệu");
                return null;
            }
        }

        /// <summary>
        /// Thực thi query và trả về giá trị đơn đồng bộ
        /// </summary>
        protected object? ExecuteScalar(string query, SqlParameter[]? parameters = null)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"ExecuteScalar error: {ex.Message}");
                ExceptionHandler.Handle(ex, "Lỗi truy vấn dữ liệu");
                return null;
            }
        }

        #endregion

        #region NonQuery Methods (INSERT, UPDATE, DELETE)

        /// <summary>
        /// Thực thi câu lệnh INSERT, UPDATE, DELETE (async)
        /// </summary>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        protected async Task<int> ExecuteNonQueryAsync(string query, SqlParameter[]? parameters = null)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        return await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"ExecuteNonQueryAsync error: {ex.Message}");
                ExceptionHandler.Handle(ex, "Lỗi thực thi câu lệnh");
                return 0;
            }
        }

        /// <summary>
        /// Thực thi câu lệnh INSERT, UPDATE, DELETE đồng bộ
        /// </summary>
        protected int ExecuteNonQuery(string query, SqlParameter[]? parameters = null)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"ExecuteNonQuery error: {ex.Message}");
                ExceptionHandler.Handle(ex, "Lỗi thực thi câu lệnh");
                return 0;
            }
        }

        #endregion

        #region Transaction Methods

        /// <summary>
        /// Thực thi nhiều câu lệnh trong một transaction
        /// </summary>
        protected async Task<bool> ExecuteTransactionAsync(Func<SqlConnection, SqlTransaction, Task<bool>> transactionFunc)
        {
            SqlConnection? conn = null;
            SqlTransaction? transaction = null;

            try
            {
                conn = new SqlConnection(_connectionString);
                await conn.OpenAsync();
                transaction = conn.BeginTransaction();

                bool success = await transactionFunc(conn, transaction);

                if (success)
                {
                    await transaction.CommitAsync();
                    return true;
                }
                else
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        await transaction.RollbackAsync();
                    }
                    catch { }
                }

                Logger.Log($"ExecuteTransactionAsync error: {ex.Message}");
                ExceptionHandler.Handle(ex, "Lỗi thực thi transaction");
                return false;
            }
            finally
            {
                transaction?.Dispose();
                conn?.Dispose();
            }
        }

        /// <summary>
        /// Thực thi transaction đồng bộ
        /// </summary>
        protected bool ExecuteTransaction(Func<SqlConnection, SqlTransaction, bool> transactionFunc)
        {
            SqlConnection? conn = null;
            SqlTransaction? transaction = null;

            try
            {
                conn = new SqlConnection(_connectionString);
                conn.Open();
                transaction = conn.BeginTransaction();

                bool success = transactionFunc(conn, transaction);

                if (success)
                {
                    transaction.Commit();
                    return true;
                }
                else
                {
                    transaction.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { }
                }

                Logger.Log($"ExecuteTransaction error: {ex.Message}");
                ExceptionHandler.Handle(ex, "Lỗi thực thi transaction");
                return false;
            }
            finally
            {
                transaction?.Dispose();
                conn?.Dispose();
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Kiểm tra kết nối database
        /// </summary>
        protected bool TestConnection()
        {
            return DatabaseConfig.TestConnection();
        }

        /// <summary>
        /// Tạo SqlParameter
        /// </summary>
        protected SqlParameter CreateParameter(string name, object? value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        /// <summary>
        /// Tạo SqlParameter với SqlDbType cụ thể
        /// </summary>
        protected SqlParameter CreateParameter(string name, SqlDbType type, object? value)
        {
            return new SqlParameter
            {
                ParameterName = name,
                SqlDbType = type,
                Value = value ?? DBNull.Value
            };
        }

        /// <summary>
        /// Helper để đọc giá trị từ SqlDataReader an toàn
        /// </summary>
        protected T? GetValue<T>(SqlDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                if (reader.IsDBNull(ordinal))
                    return default;

                return (T)reader.GetValue(ordinal);
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// Helper để đọc string từ SqlDataReader
        /// </summary>
        protected string GetString(SqlDataReader reader, string columnName)
        {
            return GetValue<string>(reader, columnName) ?? string.Empty;
        }

        /// <summary>
        /// Helper để đọc int từ SqlDataReader
        /// </summary>
        protected int GetInt(SqlDataReader reader, string columnName)
        {
            return GetValue<int>(reader, columnName);
        }

        /// <summary>
        /// Helper để đọc decimal từ SqlDataReader
        /// </summary>
        protected decimal GetDecimal(SqlDataReader reader, string columnName)
        {
            return GetValue<decimal>(reader, columnName);
        }

        /// <summary>
        /// Helper để đọc DateTime từ SqlDataReader
        /// </summary>
        protected DateTime? GetDateTime(SqlDataReader reader, string columnName)
        {
            return GetValue<DateTime?>(reader, columnName);
        }

        /// <summary>
        /// Helper để đọc bool từ SqlDataReader
        /// </summary>
        protected bool GetBool(SqlDataReader reader, string columnName)
        {
            return GetValue<bool>(reader, columnName);
        }

        #endregion
    }
}
