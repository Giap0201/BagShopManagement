using BagShopManagement.DataAccess;
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

        public int ImportFromExcel(ExcelWorksheet worksheet, string tableName)
        {
            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

            // Lấy tên cột từ hàng đầu tiên
            var columns = new List<string>();
            for (int col = 1; col <= colCount; col++)
                columns.Add(worksheet.Cells[1, col].Text);

            int inserted = 0;
            for (int row = 2; row <= rowCount; row++)
            {
                var values = new List<string>();
                for (int col = 1; col <= colCount; col++)
                    values.Add($"'{worksheet.Cells[row, col].Text.Replace("'", "''")}'");

                string query = $"INSERT INTO {tableName} ({string.Join(",", columns)}) VALUES ({string.Join(",", values)})";
                inserted += DataAccessBase.ExecuteNonQuery(query);
            }

            return inserted;
        }
    }
}
