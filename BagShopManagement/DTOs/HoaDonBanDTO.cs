using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs
{
    public class HoaDonBanDTO
    {
        public HoaDonBan HoaDon { get; set; } = new HoaDonBan();
        public List<ChiTietHoaDonBan> ChiTiets { get; set; } = new List<ChiTietHoaDonBan>();
        public KhachHang? KhachHang { get; set; }
    }
}
