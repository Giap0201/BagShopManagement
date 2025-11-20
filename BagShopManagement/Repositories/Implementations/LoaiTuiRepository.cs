using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BagShopManagement.Repositories.Implementations
{
    public class LoaiTuiRepository : BaseRepository, ILoaiTuiRepository
    {
        private DanhMucLoaiTui Map(DataRow r) => new DanhMucLoaiTui
        {
            MaLoaiTui = r["MaLoaiTui"].ToString(),
            TenLoaiTui = r["TenLoaiTui"].ToString(),
            MoTa = r.Table.Columns.Contains("MoTa") ? r["MoTa"]?.ToString() : null
        };

        public List<DanhMucLoaiTui> GetAll()
        {
            var dt = ExecuteQuery("SELECT MaLoaiTui, TenLoaiTui, MoTa FROM DanhMucLoaiTui");
            return dt.AsEnumerable().Select(Map).ToList();
        }

        public DanhMucLoaiTui GetById(string ma)
        {
            var dt = ExecuteQuery("SELECT MaLoaiTui, TenLoaiTui, MoTa FROM DanhMucLoaiTui WHERE MaLoaiTui=@ma",
                new SqlParameter("@ma", ma));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public bool Add(DanhMucLoaiTui item)
        {
            string q = @"INSERT INTO DanhMucLoaiTui (MaLoaiTui, TenLoaiTui, MoTa)
                         VALUES (@Ma, @Ten, @MoTa)";
            var p = new[]
            {
                new SqlParameter("@Ma", item.MaLoaiTui),
                new SqlParameter("@Ten", item.TenLoaiTui),
                new SqlParameter("@MoTa", (object?)item.MoTa ?? DBNull.Value)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Update(DanhMucLoaiTui item)
        {
            string q = @"UPDATE DanhMucLoaiTui SET TenLoaiTui=@Ten, MoTa=@MoTa WHERE MaLoaiTui=@Ma";
            var p = new[]
            {
                new SqlParameter("@Ten", item.TenLoaiTui),
                new SqlParameter("@MoTa", (object?)item.MoTa ?? DBNull.Value),
                new SqlParameter("@Ma", item.MaLoaiTui)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Delete(string ma)
        {
            string q = "DELETE FROM DanhMucLoaiTui WHERE MaLoaiTui=@Ma";
            return ExecuteNonQuery(q, new SqlParameter("@Ma", ma)) > 0;
        }

        public List<DanhMucLoaiTui> Search(string keyword)
        {
            string q = "SELECT MaLoaiTui, TenLoaiTui, MoTa FROM DanhMucLoaiTui WHERE TenLoaiTui LIKE @kw OR MaLoaiTui LIKE @kw";
            var dt = ExecuteQuery(q, new SqlParameter("@kw", $"%{keyword}%"));
            return dt.AsEnumerable().Select(Map).ToList();
        }

        // Trả về mã lớn nhất hiện có (vd "LT005"), hoặc null nếu không có bản ghi
        public string GetMaxCode()
        {
            var dt = ExecuteQuery("SELECT MAX(MaLoaiTui) AS MaxCode FROM DanhMucLoaiTui");
            if (dt.Rows.Count == 0) return null;
            var obj = dt.Rows[0]["MaxCode"];
            return obj == DBNull.Value ? null : obj.ToString();
        }
    }
}
