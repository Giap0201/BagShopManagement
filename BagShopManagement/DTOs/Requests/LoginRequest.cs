using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Requests
{
    public class LoginRequest
    {
        public required string TenDangNhap { get; set; }
        public required string MatKhau { get; set; }
    }
}
