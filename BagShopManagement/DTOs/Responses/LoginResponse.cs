using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Responses
{
    public class LoginResponse
    {
        public required string MaNV { get; set; }
        public required string HoTen { get; set; }
        public required string MaVaiTro { get; set; }
        public required List<string> MaQuyenList { get; set; } // Danh sách mã quyền
    }
}
