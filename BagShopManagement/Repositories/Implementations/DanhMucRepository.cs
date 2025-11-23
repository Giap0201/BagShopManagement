using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
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
    }
}