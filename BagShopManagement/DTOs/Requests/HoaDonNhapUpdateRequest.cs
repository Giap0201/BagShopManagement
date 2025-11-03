using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Requests
{
    public class HoaDonNhapUpdateRequest
    {
        //chi cho cap nhat cac thong tin can thiet, khong cap nhat cac thong tin goc
        public string MaHDN { get; set; }

        public DateTime NgayNhap { get; set; }
        public string? GhiChu { get; set; }
    }
}