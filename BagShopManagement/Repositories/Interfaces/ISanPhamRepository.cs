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
        SanPham? GetByMaSP(string maSP);
        List<SanPham> GetAll();
        void Update(SanPham sp);
    }
}
