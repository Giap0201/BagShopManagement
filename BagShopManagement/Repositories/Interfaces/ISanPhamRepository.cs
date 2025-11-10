using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
