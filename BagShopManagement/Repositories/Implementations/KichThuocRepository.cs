using BagShopManagement.DataAccess;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace BagShopManagement.Repositories.Implementations
{
    public class KichThuocRepository : BaseRepository, IKichThuocRepository
    {
        private KichThuoc Map(DataRow r) => new KichThuoc
        {
            MaKichThuoc = r["MaKichThuoc"]?.ToString(),
            TenKichThuoc = r["TenKichThuoc"]?.ToString(),
            ChieuDai = r.Table.Columns.Contains("ChieuDai") && r["ChieuDai"] != DBNull.Value ? Convert.ToDecimal(r["ChieuDai"], CultureInfo.InvariantCulture) : (decimal?)null,
            ChieuRong = r.Table.Columns.Contains("ChieuRong") && r["ChieuRong"] != DBNull.Value ? Convert.ToDecimal(r["ChieuRong"], CultureInfo.InvariantCulture) : (decimal?)null,
            ChieuCao = r.Table.Columns.Contains("ChieuCao") && r["ChieuCao"] != DBNull.Value ? Convert.ToDecimal(r["ChieuCao"], CultureInfo.InvariantCulture) : (decimal?)null
        };

        public List<KichThuoc> GetAll()
        {
            var dt = ExecuteQuery("SELECT MaKichThuoc, TenKichThuoc, ChieuDai, ChieuRong, ChieuCao FROM KichThuoc ORDER BY MaKichThuoc");
            return dt.AsEnumerable().Select(Map).ToList();
        }

        public KichThuoc GetById(string ma)
        {
            var dt = ExecuteQuery("SELECT MaKichThuoc, TenKichThuoc, ChieuDai, ChieuRong, ChieuCao FROM KichThuoc WHERE MaKichThuoc=@ma",
                new SqlParameter("@ma", ma));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public bool Add(KichThuoc item)
        {
            string q = @"INSERT INTO KichThuoc (MaKichThuoc, TenKichThuoc, ChieuDai, ChieuRong, ChieuCao)
                         VALUES (@Ma, @Ten, @Dai, @Rong, @Cao)";
            var p = new[]
            {
                new SqlParameter("@Ma", item.MaKichThuoc),
                new SqlParameter("@Ten", item.TenKichThuoc),
                new SqlParameter("@Dai", (object?)item.ChieuDai ?? DBNull.Value),
                new SqlParameter("@Rong", (object?)item.ChieuRong ?? DBNull.Value),
                new SqlParameter("@Cao", (object?)item.ChieuCao ?? DBNull.Value)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Update(KichThuoc item)
        {
            string q = @"UPDATE KichThuoc 
                         SET TenKichThuoc=@Ten, ChieuDai=@Dai, ChieuRong=@Rong, ChieuCao=@Cao 
                         WHERE MaKichThuoc=@Ma";
            var p = new[]
            {
                new SqlParameter("@Ten", item.TenKichThuoc),
                new SqlParameter("@Dai", (object?)item.ChieuDai ?? DBNull.Value),
                new SqlParameter("@Rong", (object?)item.ChieuRong ?? DBNull.Value),
                new SqlParameter("@Cao", (object?)item.ChieuCao ?? DBNull.Value),
                new SqlParameter("@Ma", item.MaKichThuoc)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Delete(string ma)
        {
            string q = "DELETE FROM KichThuoc WHERE MaKichThuoc=@Ma";
            return ExecuteNonQuery(q, new SqlParameter("@Ma", ma)) > 0;
        }

        public List<KichThuoc> Search(string keyword)
        {
            string q = "SELECT MaKichThuoc, TenKichThuoc, ChieuDai, ChieuRong, ChieuCao " +
                       "FROM KichThuoc WHERE TenKichThuoc LIKE @kw OR MaKichThuoc LIKE @kw ORDER BY MaKichThuoc";
            var dt = ExecuteQuery(q, new SqlParameter("@kw", $"%{keyword}%"));
            return dt.AsEnumerable().Select(Map).ToList();
        }

        public string GetMaxCode()
        {
            var dt = ExecuteQuery("SELECT MAX(MaKichThuoc) AS MaxCode FROM KichThuoc");
            if (dt.Rows.Count == 0) return null;
            var obj = dt.Rows[0]["MaxCode"];
            return obj == DBNull.Value ? null : obj.ToString();
        }
    }
}
