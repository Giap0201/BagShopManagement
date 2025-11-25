using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BagShopManagement.Repositories.Implementations
{
    public class ThuongHieuRepository : BaseRepository, IThuongHieuRepository
    {
        private ThuongHieu Map(DataRow r) => new ThuongHieu
        {
            MaThuongHieu = r["MaThuongHieu"]?.ToString(),
            TenThuongHieu = r["TenThuongHieu"]?.ToString(),
            QuocGia = r.Table.Columns.Contains("QuocGia") ? r["QuocGia"]?.ToString() : null
        };

        public List<ThuongHieu> GetAll()
        {
            var dt = ExecuteQuery("SELECT MaThuongHieu, TenThuongHieu, QuocGia FROM ThuongHieu ORDER BY MaThuongHieu");
            return dt.AsEnumerable().Select(Map).ToList();
        }

        public ThuongHieu GetById(string ma)
        {
            var dt = ExecuteQuery("SELECT MaThuongHieu, TenThuongHieu, QuocGia FROM ThuongHieu WHERE MaThuongHieu = @ma",
                new SqlParameter("@ma", ma));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public bool Add(ThuongHieu item)
        {
            string q = @"INSERT INTO ThuongHieu (MaThuongHieu, TenThuongHieu, QuocGia)
                         VALUES (@Ma, @Ten, @QuocGia)";
            var p = new[]
            {
                new SqlParameter("@Ma", item.MaThuongHieu),
                new SqlParameter("@Ten", item.TenThuongHieu),
                new SqlParameter("@QuocGia", (object?)item.QuocGia ?? DBNull.Value)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Update(ThuongHieu item)
        {
            string q = @"UPDATE ThuongHieu SET TenThuongHieu=@Ten, QuocGia=@QuocGia WHERE MaThuongHieu=@Ma";
            var p = new[]
            {
                new SqlParameter("@Ten", item.TenThuongHieu),
                new SqlParameter("@QuocGia", (object?)item.QuocGia ?? DBNull.Value),
                new SqlParameter("@Ma", item.MaThuongHieu)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Delete(string ma)
        {
            string q = "DELETE FROM ThuongHieu WHERE MaThuongHieu=@Ma";
            return ExecuteNonQuery(q, new SqlParameter("@Ma", ma)) > 0;
        }

        public List<ThuongHieu> Search(string keyword)
        {
            string q = "SELECT MaThuongHieu, TenThuongHieu, QuocGia FROM ThuongHieu WHERE TenThuongHieu LIKE @kw OR MaThuongHieu LIKE @kw OR QuocGia LIKE @kw ORDER BY MaThuongHieu";
            var dt = ExecuteQuery(q, new SqlParameter("@kw", $"%{keyword}%"));
            return dt.AsEnumerable().Select(Map).ToList();
        }

        public string GetMaxCode()
        {
            var dt = ExecuteQuery("SELECT MAX(MaThuongHieu) AS MaxCode FROM ThuongHieu");
            if (dt.Rows.Count == 0) return null;
            var obj = dt.Rows[0]["MaxCode"];
            return obj == DBNull.Value ? null : obj.ToString();
        }
    }
}
