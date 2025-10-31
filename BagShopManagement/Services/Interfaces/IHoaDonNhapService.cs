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
        List<HoaDonNhapResponse> GetAllHoaDonNhap();

        HoaDonNhapResponse GetHoaDonNhapById(string maHDN);

        List<HoaDonNhapResponse> Search(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV);

        void CreateHoaDonNhap(HoaDonNhapRequest request);

        void UpdateHoaDonNhap(HoaDonNhapRequest request);

        void DeleteHoaDonNhap(string maHDN);
    }
}