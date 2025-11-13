using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IKichThuocService
    {
        List<KichThuoc> GetAll();
        KichThuoc GetById(string ma);
        bool Add(KichThuoc item);
        bool Update(KichThuoc item);
        bool Delete(string ma);
        List<KichThuoc> Search(string keyword);

        // generate next code e.g. "KT006"
        string GenerateNextCode();
    }
}
