using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IMauSacRepository
    {
        List<MauSac> GetAll();
        MauSac GetById(string ma);
        bool Add(MauSac item);
        bool Update(MauSac item);
        bool Delete(string ma);
        List<MauSac> Search(string keyword);

        // trả về mã lớn nhất hiện có (vd "MS005") hoặc null nếu bảng rỗng
        string GetMaxCode();
    }
}
