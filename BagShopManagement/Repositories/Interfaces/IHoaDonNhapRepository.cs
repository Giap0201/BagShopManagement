using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IHoaDonNhapRepository
    {
        bool Exists(string maHDN);

        HoaDonNhap GetById(string maHDN);

        string Insert(HoaDonNhap hoaDonNhap);

        bool Update(HoaDonNhap hoaDonNhap);

        bool Delete(string maHDN);

        List<HoaDonNhap> GetAll();

        List<HoaDonNhapResponse> Search(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV);

        List<HoaDonNhapResponse> GetAllHoaDonNhap();
    }
}