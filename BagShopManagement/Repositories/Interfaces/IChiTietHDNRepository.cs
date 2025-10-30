using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IChiTietHDNRepository
    {
        List<ChiTietHoaDonNhap> GetByMaHDN(string maHDN);

        void Add(ChiTietHoaDonNhap chiTiet);

        void Update(ChiTietHoaDonNhap chiTiet);

        void Delete(string maHDN, string maSP);

        void DeleteByMaHDN(string maHDN);

        List<ChiTietHDNResponse> GetDetailsByMaHDN(string maHDN);
    }
}