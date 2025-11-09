using BagShopManagement.Services.Interfaces;
using OfficeOpenXml;
using System.Data;

namespace BagShopManagement.Controllers
{
    public class DanhMucController
    {
        private readonly IDanhMucService _service;

        public DanhMucController(IDanhMucService service)
        {
            _service = service;
        }

        public int ImportFromExcel(ExcelWorksheet ws, string tableName)
        {
            return _service.ImportFromExcel(ws, tableName);
        }

        public DataTable GetAll(string tableName)
        {
            return _service.GetAll(tableName);
        }
    }
}
