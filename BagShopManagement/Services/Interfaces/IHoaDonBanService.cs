using BagShopManagement.DTOs;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IHoaDonBanService
    {
        void SaveHoaDon(HoaDonBanDTO dto);
        List<HoaDonBan> GetAll();
        void CancelHoaDon(string maHDB);
    }
}
