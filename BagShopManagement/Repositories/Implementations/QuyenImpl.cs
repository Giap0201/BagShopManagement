using BagShopManagement.DataAccess;
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
    public class QuyenImpl : BaseRepository, IQuyenRepository
    {
        private readonly string _connectionString;

        public QuyenImpl()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ConfigurationErrorsException("Không tìm thấy chuỗi kết nối 'MyConnectionString' trong file App.config.");
            }
        }

        /// <summary>
        /// Hàm helper để chuyển đổi IDataRecord (từ SqlDataReader) thành Quyen.
        /// </summary>
        private Quyen MapToQuyen(IDataRecord reader)
        {
            return new Quyen
            {
                MaQuyen = reader["MaQuyen"].ToString(),
                TenQuyen = reader["TenQuyen"].ToString(),
                MoTa = reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : null
            };
        }

        /// <summary>
        /// Lấy danh sách quyền dựa trên MaVaiTro, yêu cầu JOIN 2 bảng.
        /// </summary>
        public List<Quyen> GetQuyenByMaVaiTro(string maVaiTro)
        {
            var list = new List<Quyen>();
            // Câu lệnh SQL JOIN bảng Quyen và bảng VaiTro_Quyen
            string sql = @"
                SELECT Q.MaQuyen, Q.TenQuyen, Q.MoTa
                FROM Quyen AS Q
                INNER JOIN VaiTro_Quyen AS VTQ ON Q.MaQuyen = VTQ.MaQuyen
                WHERE VTQ.MaVaiTro = @MaVaiTro";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaVaiTro", maVaiTro);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapToQuyen(reader));
            }
            return list;
        }

        public List<Quyen> GetAll()
        {
            var list = new List<Quyen>();
            string sql = "SELECT * FROM Quyen";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(sql, conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(MapToQuyen(reader));
            }
            return list;
        }
    }
}
