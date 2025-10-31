using BagShopManagement.DataAccess;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;

namespace BagShopManagement.Repositories.Implementations
{
    public class DanhMucRepository : BaseRepository, IDanhMucRepository
    {
        public DataTable GetAll(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            return ExecuteQuery(query);
        }

        public int ImportDanhMuc(string tableName, DataTable data)
        {
            int count = 0;
            foreach (DataRow row in data.Rows)
            {
                var columns = string.Join(",", data.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                var values = string.Join(",", data.Columns.Cast<DataColumn>().Select(c => $"'{row[c].ToString().Replace("'", "''")}'"));
                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
                count += ExecuteNonQuery(query);
            }
            return count;
        }
    }
}
