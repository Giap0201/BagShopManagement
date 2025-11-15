using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Responses
{
    public class NhanVienResponse
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string? ChucVu { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }

        // Lấy từ JOIN
        public string TenDangNhap { get; set; }
        public string MaVaiTro { get; set; } // Cần cho việc Edit
        public string TenVaiTro { get; set; }
        public bool TrangThaiTK { get; set; } // Hiển thị trạng thái tài khoản
    }
}
