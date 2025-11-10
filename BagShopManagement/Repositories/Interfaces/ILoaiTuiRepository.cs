using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface ILoaiTuiRepository
    {
        List<DanhMucLoaiTui> GetAll();
        DanhMucLoaiTui GetById(string ma);
        bool Add(DanhMucLoaiTui item);
        bool Update(DanhMucLoaiTui item);
        bool Delete(string ma);
        List<DanhMucLoaiTui> Search(string keyword);

        // mới: trả về mã lớn nhất hiện có (vd "LT005") hoặc null nếu bảng rỗng
        string GetMaxCode();
    }
}
