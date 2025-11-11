using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IThuongHieuService
    {
        List<ThuongHieu> GetAll();
        ThuongHieu GetById(string ma);
        bool Add(ThuongHieu item);
        bool Update(ThuongHieu item);
        bool Delete(string ma);
        List<ThuongHieu> Search(string keyword);

        // generate next code e.g. "TH006"
        string GenerateNextCode();
    }
}
