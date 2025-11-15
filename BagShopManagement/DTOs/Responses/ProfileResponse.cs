using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Responses
{
    public class ProfileResponse
    {
        public required string HoTen { get; set; }
        public string? ChucVu { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public required string TenDangNhap { get; set; }
        public required string TenVaiTro { get; set; }
    }
}
