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
        //tim kiem tat ca hoa don nhap
        List<HoaDonNhapResponse> SearchHoaDonNhap(HoaDonNhapRequest request);

        //lay ra chi tiet hoa don de hien thi (da join)
        List<ChiTietHDNResponse> GetChiTietForDisplay(string maHDN);

        List<HoaDonNhap> GetAllHoaDonNhap();
    }
}