using BagShopManagement.DTOs;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IChiTietGiamGiaService
    {
        List<SanPham> GetAvailableProducts(string maCTGG);
        List<ChiTietGiamGiaDto> GetAppliedProducts(string maCTGG);
        void AddProductToPromotion(string maCTGG, string maSP, int phanTramGiam);
        void RemoveProductFromPromotion(string maCTGG, string maSP);
    }
}
