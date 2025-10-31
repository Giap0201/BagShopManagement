using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Requests
{
    public class HoaDonNhapRequest
    {
        public string MaHDN { get; set; }
        public string MaNCC { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayNhap { get; set; }
        public string? GhiChu { get; set; }
        public List<ChiTietHDNRequest> ChiTiet { get; set; }
    }
}