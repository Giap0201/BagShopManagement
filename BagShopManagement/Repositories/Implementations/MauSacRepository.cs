using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BagShopManagement.Repositories.Implementations
{
    public class MauSacRepository : BaseRepository, IMauSacRepository
    {
        private MauSac Map(DataRow r) => new MauSac
        {
            MaMau = r["MaMau"]?.ToString(),
            TenMau = r["TenMau"]?.ToString()
        };

        public List<MauSac> GetAll()
        {
            var dt = ExecuteQuery("SELECT MaMau, TenMau FROM MauSac ORDER BY MaMau");
            return dt.AsEnumerable().Select(Map).ToList();
        }

        public MauSac GetById(string ma)
        {
            var dt = ExecuteQuery("SELECT MaMau, TenMau FROM MauSac WHERE MaMau=@ma",
                new SqlParameter("@ma", ma));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public bool Add(MauSac item)
        {
            string q = @"INSERT INTO MauSac (MaMau, TenMau) VALUES (@Ma, @Ten)";
            var p = new[]
            {
                new SqlParameter("@Ma", item.MaMau),
                new SqlParameter("@Ten", item.TenMau)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Update(MauSac item)
        {
            string q = @"UPDATE MauSac SET TenMau=@Ten WHERE MaMau=@Ma";
            var p = new[]
            {
                new SqlParameter("@Ten", item.TenMau),
                new SqlParameter("@Ma", item.MaMau)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Delete(string ma)
        {
            string q = "DELETE FROM MauSac WHERE MaMau=@Ma";
            return ExecuteNonQuery(q, new SqlParameter("@Ma", ma)) > 0;
        }

        public List<MauSac> Search(string keyword)
        {
            string q = "SELECT MaMau, TenMau FROM MauSac WHERE TenMau LIKE @kw OR MaMau LIKE @kw ORDER BY MaMau";
            var dt = ExecuteQuery(q, new SqlParameter("@kw", $"%{keyword}%"));
            return dt.AsEnumerable().Select(Map).ToList();
        }

        public string GetMaxCode()
        {
            var dt = ExecuteQuery("SELECT MAX(MaMau) AS MaxCode FROM MauSac");
            if (dt.Rows.Count == 0) return null;
            var obj = dt.Rows[0]["MaxCode"];
            return obj == DBNull.Value ? null : obj.ToString();
        }
    }
}
