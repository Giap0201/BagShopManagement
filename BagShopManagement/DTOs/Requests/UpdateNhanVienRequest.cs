using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Requests
{
    public class UpdateNhanVienRequest
    {
        // Thông tin NhanVien
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string? ChucVu { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public bool TrangThaiNV { get; set; } // Trạng thái của NhanVien

        // Thông tin TaiKhoan
        public string MaVaiTro { get; set; }
        public bool TrangThaiTK { get; set; } // Trạng thái của TaiKhoan
        // Lưu ý: Không cập nhật Tên đăng nhập
    }
}
