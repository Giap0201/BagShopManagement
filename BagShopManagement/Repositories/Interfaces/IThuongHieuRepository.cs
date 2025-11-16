using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IThuongHieuRepository
    {
        List<ThuongHieu> GetAll();
        ThuongHieu GetById(string ma);
        bool Add(ThuongHieu item);
        bool Update(ThuongHieu item);
        bool Delete(string ma);
        List<ThuongHieu> Search(string keyword);

        // trả về mã lớn nhất hiện có (vd "TH005") hoặc null nếu bảng rỗng
        string GetMaxCode();
    }
}
