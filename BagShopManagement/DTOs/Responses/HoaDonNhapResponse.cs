using BagShopManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.DTOs.Responses
{
    public class HoaDonNhapResponse
    {
        public string MaHDN { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; } // mở rộng
        public string MaNV { get; set; }
        public string TenNV { get; set; } // mở rộng
        public DateTime NgayNhap { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public decimal TongTien { get; set; }
        public string? GhiChu { get; set; }
        public TrangThaiHoaDonNhap TrangThai { get; set; }

        public string TenTrangThai => TrangThai switch
        {
            TrangThaiHoaDonNhap.TamLuu => "Tạm lưu",
            TrangThaiHoaDonNhap.HoatDong => "Đã duyệt",
            TrangThaiHoaDonNhap.DaHuy => "Đã hủy",
            _ => "Không xác định"
        };

        public List<ChiTietHDNResponse>? ChiTiet { get; set; }
    }
}