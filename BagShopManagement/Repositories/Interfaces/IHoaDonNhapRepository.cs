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

        void Add(HoaDonNhap hoaDonNhap);

        void Update(HoaDonNhap hoaDonNhap);

        void Delete(string maHDN);

        List<HoaDonNhapResponse> Search(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV);
    }
}