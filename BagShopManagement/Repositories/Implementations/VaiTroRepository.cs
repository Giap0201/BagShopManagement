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
    public class VaiTroRepository : BaseRepository, IVaiTroRepository
    {
        // Không cần Constructor đọc chuỗi kết nối nữa, BaseRepository đã lo.

        /// <summary>
        /// Hàm helper chuyển đổi DataRow thành object VaiTro
        /// </summary>
        private VaiTro MapToVaiTro(DataRow row)
        {
            return new VaiTro
            {
                MaVaiTro = row["MaVaiTro"].ToString(),
                TenVaiTro = row["TenVaiTro"].ToString(),
                // Kiểm tra null an toàn cho cột MoTa
                MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null
            };
        }

        public VaiTro GetById(string maVaiTro)
        {
            string query = "SELECT * FROM VaiTro WHERE MaVaiTro = @MaVaiTro";

            // Sử dụng ExecuteQuery từ BaseRepository
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaVaiTro", SqlDbType.VarChar) { Value = maVaiTro }
            };

            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return MapToVaiTro(dt.Rows[0]);
            }

            return null;
        }

        public List<VaiTro> GetAll()
        {
            var list = new List<VaiTro>();
            string query = "SELECT * FROM VaiTro";

            // Sử dụng ExecuteQuery từ BaseRepository
            DataTable dt = ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapToVaiTro(row));
            }

            return list;
        }

        public bool Add(VaiTro vaiTro)
        {
            string query = @"INSERT INTO VaiTro (MaVaiTro, TenVaiTro, MoTa)
                             VALUES (@MaVaiTro, @TenVaiTro, @MoTa)";

            // Sử dụng ExecuteNonQuery từ BaseRepository
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaVaiTro", SqlDbType.VarChar) { Value = vaiTro.MaVaiTro },
                new SqlParameter("@TenVaiTro", SqlDbType.NVarChar) { Value = vaiTro.TenVaiTro },
                // Xử lý null cho tham số
                new SqlParameter("@MoTa", SqlDbType.NVarChar) { Value = (object)vaiTro.MoTa ?? DBNull.Value }
            };

            int rowsAffected = ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}
