using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Models
{
    public class HoaDonBan
    {
        public string MaHDB { get; set; }
        public string? MaKH { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayBan { get; set; }
        public decimal TongTien { get; set; }
        public string? PhuongThucTT { get; set; }
        public string? GhiChu { get; set; }
        public byte TrangThaiHD { get; set; } // TINYINT mapped to byte
    }
}