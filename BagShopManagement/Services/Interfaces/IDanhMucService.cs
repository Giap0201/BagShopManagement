using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IDanhMucService
    {
        DataTable GetAll(string tableName);
        //int ImportDanhMuc(string tableName, DataTable data);

        int ImportFromExcel(ExcelWorksheet worksheet, string tableName);
    }
}
