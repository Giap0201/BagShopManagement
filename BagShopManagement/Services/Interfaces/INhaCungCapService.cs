using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface INhaCungCapService
    {
        List<NhaCungCap> GetAll();
        NhaCungCap? GetById(string maNCC);
        bool Add(NhaCungCap NCC);
        bool Update(NhaCungCap NCC);
        bool Delete(string maNCC);
        List<NhaCungCap> Search(string kw);
        string GenerateNextCode();
    }
}
