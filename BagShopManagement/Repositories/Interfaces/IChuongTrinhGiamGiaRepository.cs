using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IChuongTrinhGiamGiaRepository
    {
        List<ChuongTrinhGiamGia> GetAll();
        void Add(ChuongTrinhGiamGia ctgg);
        void Update(ChuongTrinhGiamGia ctgg);
        void Delete(string maCTGG);
        bool CheckIfNameExists(string name, string currentId);
        bool CheckIfIdExists(string maCTGG);
    }
}
