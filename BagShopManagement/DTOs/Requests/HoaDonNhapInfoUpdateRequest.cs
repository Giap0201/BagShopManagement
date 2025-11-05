using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Requests
{
    public class HoaDonNhapInfoUpdateRequest
    {
        [Required(ErrorMessage = "Mã nhà cung cấp là bắt buộc.")]
        public string MaNCC { get; set; }

        [Required(ErrorMessage = "Mã nhân viên là bắt buộc.")]
        public string MaNV { get; set; }

        public DateTime NgayNhap { get; set; } = DateTime.Now;

        public string? GhiChu { get; set; }
    }
}