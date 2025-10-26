using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Models
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string? MoTa { get; set; }
        public string? AnhChinh { get; set; }
        public string? MaLoaiTui { get; set; }
        public string? MaThuongHieu { get; set; }
        public string? MaChatLieu { get; set; }
        public string? MaMau { get; set; }
        public string? MaKichThuoc { get; set; }
        public string? MaNCC { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
    }
}