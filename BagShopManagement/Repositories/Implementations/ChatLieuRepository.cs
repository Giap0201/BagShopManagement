using BagShopManagement.DataAccess;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BagShopManagement.Repositories.Implementations
{
    public class ChatLieuRepository : BaseRepository, IChatLieuRepository
    {
        private ChatLieu Map(DataRow r) => new ChatLieu
        {
            MaChatLieu = r["MaChatLieu"]?.ToString(),
            TenChatLieu = r["TenChatLieu"]?.ToString(),
            MoTa = r.Table.Columns.Contains("MoTa") ? r["MoTa"]?.ToString() : null
        };

        public List<ChatLieu> GetAll()
        {
            var dt = ExecuteQuery("SELECT MaChatLieu, TenChatLieu, MoTa FROM ChatLieu ORDER BY MaChatLieu");
            return dt.AsEnumerable().Select(Map).ToList();
        }

        public ChatLieu GetById(string ma)
        {
            var dt = ExecuteQuery("SELECT MaChatLieu, TenChatLieu, MoTa FROM ChatLieu WHERE MaChatLieu = @ma",
                new SqlParameter("@ma", ma));
            if (dt.Rows.Count == 0) return null;
            return Map(dt.Rows[0]);
        }

        public bool Add(ChatLieu item)
        {
            string q = @"INSERT INTO ChatLieu (MaChatLieu, TenChatLieu, MoTa)
                         VALUES (@Ma, @Ten, @MoTa)";
            var p = new[]
            {
                new SqlParameter("@Ma", item.MaChatLieu),
                new SqlParameter("@Ten", item.TenChatLieu),
                new SqlParameter("@MoTa", (object?)item.MoTa ?? DBNull.Value)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Update(ChatLieu item)
        {
            string q = @"UPDATE ChatLieu SET TenChatLieu=@Ten, MoTa=@MoTa WHERE MaChatLieu=@Ma";
            var p = new[]
            {
                new SqlParameter("@Ten", item.TenChatLieu),
                new SqlParameter("@MoTa", (object?)item.MoTa ?? DBNull.Value),
                new SqlParameter("@Ma", item.MaChatLieu)
            };
            return ExecuteNonQuery(q, p) > 0;
        }

        public bool Delete(string ma)
        {
            string q = "DELETE FROM ChatLieu WHERE MaChatLieu=@Ma";
            return ExecuteNonQuery(q, new SqlParameter("@Ma", ma)) > 0;
        }

        public List<ChatLieu> Search(string keyword)
        {
            string q = "SELECT MaChatLieu, TenChatLieu, MoTa FROM ChatLieu WHERE TenChatLieu LIKE @kw OR MaChatLieu LIKE @kw ORDER BY MaChatLieu";
            var dt = ExecuteQuery(q, new SqlParameter("@kw", $"%{keyword}%"));
            return dt.AsEnumerable().Select(Map).ToList();
        }

        // Trả về mã lớn nhất hiện có (vd "CL005"), hoặc null nếu không có bản ghi
        public string GetMaxCode()
        {
            var dt = ExecuteQuery("SELECT MAX(MaChatLieu) AS MaxCode FROM ChatLieu");
            if (dt.Rows.Count == 0) return null;
            var obj = dt.Rows[0]["MaxCode"];
            return obj == DBNull.Value ? null : obj.ToString();
        }
    }
}
