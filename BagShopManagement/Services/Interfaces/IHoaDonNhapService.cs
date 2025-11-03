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
        //lay ra toan bo hoa don nhap khong bao gom chi tiet
        List<HoaDonNhapResponse> GetAllHoaDonNhap();

        //lay ra 1 hoa don nhap theo ma hoa don nhap bao gom ca chi tiet hoa don nhap
        HoaDonNhapResponse GetHoaDonNhapById(string maHDN);

        //tim tiem hoa don nhap theo cac tieu chi, tra ve danh sach khong bao gom chi tiet
        List<HoaDonNhapResponse> Search(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV);

        //tao moi hoa don nhap bao gom ca thong tin cua hoa don nhap va chi tiet hoa don nhap
        string CreateHoaDonNhap(HoaDonNhapRequest request);

        bool UpdateHoaDonNhap(HoaDonNhapUpdateRequest request);

        bool DeleteHoaDonNhap(string maHDN);
    }
}