using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Models
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string? MaNV { get; set; }
        public string? MaVaiTro { get; set; }
        public bool TrangThai { get; set; }
    }
}