using BagShopManagement.Models;
using System.Collections.Generic;

namespace BagShopManagement.Services.Interfaces
{
    public interface ISanPhamService
    {
        List<SanPham> GetAll();
        SanPham GetById(string maSP);
        bool Add(SanPham sp);
        bool Update(SanPham sp);
        bool Delete(string maSP);
        List<SanPham> Search(string keyword);
        string GenerateNextCode();
    }
}
