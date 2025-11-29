using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BagShopManagement.Repositories.Implementations
{
    public class NhaCungCapRepository : BaseRepository, INhaCungCapRepository
    {
        public List<NhaCungCap> GetAll()
        {
            string query = "SELECT * FROM NhaCungCap";
            DataTable dt = ExecuteQuery(query);

            List<NhaCungCap> list = new List<NhaCungCap>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(Map(row));
            }
            return list;
        }

        public NhaCungCap? GetById(string maNCC)
        {
            string query = "SELECT * FROM NhaCungCap WHERE MaNCC = @MaNCC";
            var dt = ExecuteQuery(query, new SqlParameter("@MaNCC", maNCC));

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public int Add(NhaCungCap ncc)
        {
            string query = @"
                INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai, Email, NguoiLienHe)
                VALUES (@MaNCC, @TenNCC, @DiaChi, @SoDienThoai, @Email, @NguoiLienHe)";
            return ExecuteNonQuery(query,
                new SqlParameter("@MaNCC", ncc.MaNCC),
                new SqlParameter("@TenNCC", ncc.TenNCC),
                new SqlParameter("@DiaChi", (object?)ncc.DiaChi ?? DBNull.Value),
                new SqlParameter("@SoDienThoai", (object?)ncc.SoDienThoai ?? DBNull.Value),
                new SqlParameter("@Email", (object?)ncc.Email ?? DBNull.Value),
                new SqlParameter("@NguoiLienHe", (object?)ncc.NguoiLienHe ?? DBNull.Value)
            );
        }

        public int Update(NhaCungCap ncc)
        {
            string query = @"
                UPDATE NhaCungCap
                SET TenNCC = @TenNCC,
                    DiaChi = @DiaChi,
                    SoDienThoai = @SoDienThoai,
                    Email = @Email,
                    NguoiLienHe = @NguoiLienHe
                WHERE MaNCC = @MaNCC";
            return ExecuteNonQuery(query,
                new SqlParameter("@TenNCC", ncc.TenNCC),
                new SqlParameter("@DiaChi", (object?)ncc.DiaChi ?? DBNull.Value),
                new SqlParameter("@SoDienThoai", (object?)ncc.SoDienThoai ?? DBNull.Value),
                new SqlParameter("@Email", (object?)ncc.Email ?? DBNull.Value),
                new SqlParameter("@NguoiLienHe", (object?)ncc.NguoiLienHe ?? DBNull.Value),
                new SqlParameter("@MaNCC", ncc.MaNCC)
            );
        }

        public int Delete(string maNCC)
        {
            string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
            return ExecuteNonQuery(query, new SqlParameter("@MaNCC", maNCC));
        }

        public List<NhaCungCap> Search(string keyword)
        {
            string q = @"SELECT * FROM NhaCungCap
                 WHERE MaNCC LIKE @kw 
                    OR TenNCC LIKE @kw
                    OR SoDienThoai LIKE @kw
                 ORDER BY MaNCC";

            var dt = ExecuteQuery(q, new SqlParameter("@kw", $"%{keyword}%"));
            return dt.AsEnumerable().Select(Map).ToList();
        }


        private NhaCungCap Map(DataRow row)
        {
            return new NhaCungCap
            {
                MaNCC = row["MaNCC"].ToString(),
                TenNCC = row["TenNCC"].ToString(),
                DiaChi = row["DiaChi"]?.ToString(),
                SoDienThoai = row["SoDienThoai"]?.ToString(),
                Email = row["Email"]?.ToString(),
                NguoiLienHe = row["NguoiLienHe"]?.ToString()
            };
        }
        public string GetMaxCode()
        {
            var dt = ExecuteQuery("SELECT MAX(MaNCC) AS MaxCode FROM NhaCungCap");
            if (dt.Rows.Count == 0) return null;

            var obj = dt.Rows[0]["MaxCode"];
            return obj == DBNull.Value ? null : obj.ToString();
        }
    }
}
