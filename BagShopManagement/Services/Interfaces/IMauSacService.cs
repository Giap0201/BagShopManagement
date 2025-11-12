using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IMauSacService
    {
        List<MauSac> GetAll();
        MauSac GetById(string ma);
        bool Add(MauSac item);
        bool Update(MauSac item);
        bool Delete(string ma);
        List<MauSac> Search(string keyword);

        // generate next code e.g. "MS006"
        string GenerateNextCode();
    }
}
