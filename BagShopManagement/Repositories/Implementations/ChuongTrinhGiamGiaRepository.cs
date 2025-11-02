using BagShopManagement.DataAccess;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Implementations
{
    public class ChuongTrinhGiamGiaRepository : IChuongTrinhGiamGiaRepository
    {
        public List<ChuongTrinhGiamGia> GetAll()
        {
            var list = new List<ChuongTrinhGiamGia>();
            string query = "SELECT MaCTGG, TenChuongTrinh, NgayBatDau, NgayKetThuc, MoTa, TrangThai FROM ChuongTrinhGiamGia";
            DataTable data = DataAccessBase.ExecuteQuery(query);
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
            string query = "INSERT INTO ChuongTrinhGiamGia (TenChuongTrinh, NgayBatDau, NgayKetThuc, MoTa, TrangThai) VALUES (@Ten, @NgayBD, @NgayKT, @MoTa, @TrangThai)";
            SqlParameter[] parameters = {
                new SqlParameter("@Ten", ctgg.TenChuongTrinh),
                new SqlParameter("@NgayBD", ctgg.NgayBatDau),
                new SqlParameter("@NgayKT", ctgg.NgayKetThuc),
                new SqlParameter("@MoTa", ctgg.MoTa),
                new SqlParameter("@TrangThai", ctgg.TrangThai)
            };
            DataAccessBase.ExecuteNonQuery(query, parameters);
        }

        public void Update(ChuongTrinhGiamGia ctgg)
        {
            string query = "UPDATE ChuongTrinhGiamGia SET TenChuongTrinh = @Ten, NgayBatDau = @NgayBD, NgayKetThuc = @NgayKT, MoTa = @MoTa, TrangThai = @TrangThai WHERE MaCTGG = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", ctgg.MaCTGG),
                new SqlParameter("@Ten", ctgg.TenChuongTrinh),
                new SqlParameter("@NgayBD", ctgg.NgayBatDau),
                new SqlParameter("@NgayKT", ctgg.NgayKetThuc),
                new SqlParameter("@MoTa", ctgg.MoTa),
                new SqlParameter("@TrangThai", ctgg.TrangThai)
            };
            DataAccessBase.ExecuteNonQuery(query, parameters);
        }

        public void Delete(string maCTGG)
        {
            string query = "DELETE FROM ChuongTrinhGiamGia WHERE MaCTGG = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", maCTGG) };
            DataAccessBase.ExecuteNonQuery(query, parameters);
        }

        public bool CheckIfIdExists(string maCTGG)
        {
            string query = "SELECT COUNT(*) FROM ChuongTrinhGiamGia WHERE MaCTGG = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", maCTGG) };
            int count = Convert.ToInt32(DataAccessBase.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool CheckIfNameExists(string name, string currentId)
        {
            string query = "SELECT COUNT(*) FROM ChuongTrinhGiamGia WHERE TenChuongTrinh = @Ten AND MaCTGG != @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Ten", name),
                new SqlParameter("@Id", currentId)
            };
            int count = Convert.ToInt32(DataAccessBase.ExecuteScalar(query, parameters));
            return count > 0;
        }

    }
}

