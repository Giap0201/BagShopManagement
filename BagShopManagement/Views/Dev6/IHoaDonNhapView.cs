using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Views.Dev6
{
    public interface IHoaDonNhapView
    {
        void DisplayHoaDonNhap(List<HoaDonNhap> ds);

        void ShowError(string message);
    }
}