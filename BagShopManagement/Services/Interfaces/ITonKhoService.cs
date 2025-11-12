using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface ITonKhoService
    {
        bool DecreaseStock(string maSP, int soLuong);
        void IncreaseStock(string maSP, int soLuong);
    }
}
