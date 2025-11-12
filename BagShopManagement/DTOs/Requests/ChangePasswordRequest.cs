using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Requests
{
    public class ChangePasswordRequest
    {
        public required string TenDangNhap { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}
