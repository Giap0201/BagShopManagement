using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;

namespace BagShopManagement.Repositories.Implementations
{
    // Thừa kế từ BaseRepository và triển khai IChuongTrinhGiamGiaRepository
    public class ChuongTrinhGiamGiaRepository : BaseRepository, IChuongTrinhGiamGiaRepository
    {
        public List<ChuongTrinhGiamGia> GetAll()
        {
            var list = new List<ChuongTrinhGiamGia>();
            string query = "SELECT MaCTGG, TenChuongTrinh, NgayBatDau, NgayKetThuc, MoTa, TrangThai FROM ChuongTrinhGiamGia";

            // Sử dụng phương thức ExecuteQuery từ lớp cha
            DataTable data = ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new ChuongTrinhGiamGia
                {
                    MaCTGG = row["MaCTGG"].ToString(),
                    TenChuongTrinh = row["TenChuongTrinh"].ToString(),
                    NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]),
                    NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]),
                    MoTa = row["MoTa"].ToString(),
                    TrangThai = Convert.ToBoolean(row["TrangThai"])
                });
            }
            return list;
        }

        public void Add(ChuongTrinhGiamGia ctgg)
        {
            string query = "INSERT INTO ChuongTrinhGiamGia (MaCTGG ,TenChuongTrinh, NgayBatDau, NgayKetThuc, MoTa, TrangThai) VALUES (@MaCTGG ,@Ten, @NgayBD, @NgayKT, @MoTa, @TrangThai)";

            // Sử dụng phương thức ExecuteNonQuery từ lớp cha
            ExecuteNonQuery(query,
                new SqlParameter("@MaCTGG", ctgg.MaCTGG),
                new SqlParameter("@Ten", ctgg.TenChuongTrinh),
                new SqlParameter("@NgayBD", ctgg.NgayBatDau),
                new SqlParameter("@NgayKT", ctgg.NgayKetThuc),
                new SqlParameter("@MoTa", ctgg.MoTa ?? (object)DBNull.Value), // Xử lý null
                new SqlParameter("@TrangThai", ctgg.TrangThai)
            );
        }

        public void Update(ChuongTrinhGiamGia ctgg)
        {
            string query = "UPDATE ChuongTrinhGiamGia SET TenChuongTrinh = @Ten, NgayBatDau = @NgayBD, NgayKetThuc = @NgayKT, MoTa = @MoTa, TrangThai = @TrangThai WHERE MaCTGG = @Id";

            // Sử dụng phương thức ExecuteNonQuery từ lớp cha
            ExecuteNonQuery(query,
                new SqlParameter("@Id", ctgg.MaCTGG),
                new SqlParameter("@Ten", ctgg.TenChuongTrinh),
                new SqlParameter("@NgayBD", ctgg.NgayBatDau),
                new SqlParameter("@NgayKT", ctgg.NgayKetThuc),
                new SqlParameter("@MoTa", ctgg.MoTa ?? (object)DBNull.Value), // Xử lý null
                new SqlParameter("@TrangThai", ctgg.TrangThai)
            );
        }

        public void Delete(string maCTGG)
        {
            string query = "DELETE FROM ChuongTrinhGiamGia WHERE MaCTGG = @Id";

            // Sử dụng phương thức ExecuteScalar từ lớp cha
            ExecuteNonQuery(query, new SqlParameter("@Id", maCTGG));
        }

        public bool CheckIfIdExists(string maCTGG)
        {
            string query = "SELECT COUNT(*) FROM ChuongTrinhGiamGia WHERE MaCTGG = @Id";

            // Sử dụng phương thức ExecuteScalar từ lớp cha
            int count = Convert.ToInt32(ExecuteScalar(query, new SqlParameter("@Id", maCTGG)));
            return count > 0;
        }

        public bool CheckIfNameExists(string name, string currentId)
        {
            string query = "SELECT COUNT(*) FROM ChuongTrinhGiamGia WHERE TenChuongTrinh = @Ten AND MaCTGG != @Id";

            // Sử dụng phương thức ExecuteScalar từ lớp cha
            int count = Convert.ToInt32(ExecuteScalar(query,
                new SqlParameter("@Ten", name),
                new SqlParameter("@Id", currentId)
            ));
            return count > 0;
        }
    }
}