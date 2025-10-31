using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IHoaDonNhapService
    {
        List<HoaDonNhapResponse> SearchHoaDonNhap(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV);

        List<ChiTietHDNResponse> GetChiTietForDisplay(string maHDN);

        void DeleteHoaDonNhap(string maHDN);

        List<NhaCungCap> GetNhaCungCapList();

        List<NhanVien> GetNhanVienList();
    }
}