using System.Collections.Generic;
using BagShopManagement.Models;

namespace BagShopManagement.Services.Interfaces
{
    public interface ILoaiTuiService
    {
        List<DanhMucLoaiTui> GetAll();
        DanhMucLoaiTui GetById(string ma);
        bool Add(DanhMucLoaiTui item);
        bool Update(DanhMucLoaiTui item);
        bool Delete(string ma);
        List<DanhMucLoaiTui> Search(string keyword);
    }
}
