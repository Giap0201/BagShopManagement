using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IKichThuocRepository
    {
        List<KichThuoc> GetAll();
        KichThuoc GetById(string ma);
        bool Add(KichThuoc item);
        bool Update(KichThuoc item);
        bool Delete(string ma);
        List<KichThuoc> Search(string keyword);

        // trả về mã lớn nhất hiện có (vd "KT005") hoặc null nếu bảng rỗng
        string GetMaxCode();
    }
}
