using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Implementations
{
    public class DanhMucService : IDanhMucService
    {
        private readonly IDanhMucRepository _repo;

        public DanhMucService(IDanhMucRepository repo)
        {
            _repo = repo;
        }

        public DataTable GetAll(string tableName) => _repo.GetAll(tableName);

        //public int ImportDanhMuc(string tableName, DataTable data)
        //{
        //    return _repo.ImportDanhMuc(tableName, data);
        //}

        public int ImportFromExcel(ExcelWorksheet ws, string tableName)
        {
            return _repo.ImportFromExcel(ws, tableName);
        }

    }
}
