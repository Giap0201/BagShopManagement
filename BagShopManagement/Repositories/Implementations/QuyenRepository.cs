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
    public class QuyenRepository : BaseRepository, IQuyenRepository
    {
        // Helper map dữ liệu từ DataRow
        private Quyen MapToQuyen(DataRow row)
        {
            return new Quyen
            {
                MaQuyen = row["MaQuyen"].ToString(),
                TenQuyen = row["TenQuyen"].ToString(),
                // Kiểm tra DBNull an toàn
                MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null
            };
        }

        public List<Quyen> GetQuyenByMaVaiTro(string maVaiTro)
        {
            var list = new List<Quyen>();

            // Câu lệnh SQL JOIN bảng Quyen và bảng VaiTro_Quyen
            string sql = @"
                SELECT Q.MaQuyen, Q.TenQuyen, Q.MoTa
                FROM Quyen AS Q
                INNER JOIN VaiTro_Quyen AS VTQ ON Q.MaQuyen = VTQ.MaQuyen
                WHERE VTQ.MaVaiTro = @MaVaiTro";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaVaiTro", maVaiTro)
            };

            // Gọi hàm từ BaseRepository
            DataTable dt = ExecuteQuery(sql, parameters);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapToQuyen(row));
            }

            return list;
        }

        public List<Quyen> GetAll()
        {
            var list = new List<Quyen>();
            string sql = "SELECT * FROM Quyen";

            // Gọi hàm từ BaseRepository
            DataTable dt = ExecuteQuery(sql);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapToQuyen(row));
            }

            return list;
        }
    }
}
