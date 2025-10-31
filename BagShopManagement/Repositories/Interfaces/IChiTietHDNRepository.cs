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
        bool Insert(ChiTietHoaDonNhap chiTiet);

        bool InsertMany(List<ChiTietHoaDonNhap> chiTiets);

        bool Update(ChiTietHoaDonNhap chiTiet);

        bool DeleteByMaHDN(string maHDN);

        List<ChiTietHoaDonNhap> GetByMaHDN(string maHDN);
    }
}