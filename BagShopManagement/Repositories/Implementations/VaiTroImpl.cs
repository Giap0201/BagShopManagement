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
    public class VaiTroImpl : BaseRepository, IVaiTroRepository
    {
        private readonly string _connectionString;

        public VaiTroImpl()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ConfigurationErrorsException("Không tìm thấy chuỗi kết nối 'MyConnectionString' trong file App.config.");
            }
        }

        /// <summary>
        /// Hàm helper để chuyển đổi IDataRecord (từ SqlDataReader) thành VaiTro.
        /// </summary>
        private VaiTro MapToVaiTro(IDataRecord reader)
        {
            return new VaiTro
            {
                MaVaiTro = reader["MaVaiTro"].ToString(),
                TenVaiTro = reader["TenVaiTro"].ToString(),
                MoTa = reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : null
            };
        }

        public VaiTro GetById(string maVaiTro)
        {
            string sql = "SELECT * FROM VaiTro WHERE MaVaiTro = @MaVaiTro";
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaVaiTro", maVaiTro);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? MapToVaiTro(reader) : null;
        }

        public List<VaiTro> GetAll()
        {
            var list = new List<VaiTro>();
            string sql = "SELECT * FROM VaiTro";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapToVaiTro(reader));
            }
            return list;
        }

        public bool Add(VaiTro vaiTro)
        {
            string sql = @"
                INSERT INTO VaiTro (MaVaiTro, TenVaiTro, MoTa)
                VALUES (@MaVaiTro, @TenVaiTro, @MoTa)";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaVaiTro", vaiTro.MaVaiTro);
            cmd.Parameters.AddWithValue("@TenVaiTro", vaiTro.TenVaiTro);
            cmd.Parameters.AddWithValue("@MoTa", (object)vaiTro.MoTa ?? DBNull.Value);

            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
