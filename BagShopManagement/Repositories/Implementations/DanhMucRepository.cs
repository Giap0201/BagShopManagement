using BagShopManagement.DataAccess;
using BagShopManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BagShopManagement.Repositories.Implementations
{
    public class DanhMucRepository : IDanhMucRepository
    {
        public DataTable GetAll(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            return DataAccessBase.ExecuteQuery(query);
        }

        public int ImportDanhMuc(string tableName, DataTable data)
        {
            int count = 0;
            foreach (DataRow row in data.Rows)
            {
                var columns = string.Join(",", data.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                var values = string.Join(",", data.Columns.Cast<DataColumn>().Select(c => $"'{row[c].ToString().Replace("'", "''")}'"));
                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
                count += DataAccessBase.ExecuteNonQuery(query);
            }
            return count;
        }

    }
}
