using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Models
{
    public class HoaDonNhap
    {
        public string MaHDN { get; set; }
        public string MaNCC { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public string? GhiChu { get; set; }
        public byte TrangThai { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public DateTime? NgayHuy { get; set; }
    }
}