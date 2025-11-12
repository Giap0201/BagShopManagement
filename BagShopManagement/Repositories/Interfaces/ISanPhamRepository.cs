using BagShopManagement.Models;
using System.Collections.Generic;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface ISanPhamRepository
    {
        List<SanPham> GetAll();
        SanPham GetById(string maSP);
        bool Add(SanPham sp);
        bool Update(SanPham sp);
        bool Delete(string maSP);
        List<SanPham> Search(string keyword);
        string GetMaxCode();
    }
}
