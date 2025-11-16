using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs
{
    public class ChuongTrinhGiamGiaDto
    {
        public string MaCTGG { get; set; }
        public string TenChuongTrinh { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string? MoTa { get; set; }
        public bool TrangThai { get; set; }
    }
}
