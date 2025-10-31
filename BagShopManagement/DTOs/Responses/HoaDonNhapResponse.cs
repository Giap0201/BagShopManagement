using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Responses
{
    public class HoaDonNhapResponse
    {
        public string MaHDN { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; } // mở rộng
        public string MaNV { get; set; }
        public string TenNV { get; set; } // mở rộng
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public string? GhiChu { get; set; }
        public List<ChiTietHDNResponse> ChiTiet { get; set; }
    }
}