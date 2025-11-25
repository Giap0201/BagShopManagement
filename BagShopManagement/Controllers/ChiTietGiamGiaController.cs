using BagShopManagement.DTOs;
using BagShopManagement.Models;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class ChiTietGiamGiaController
    {
        private readonly IChiTietGiamGiaService _chiTietService;

        public ChiTietGiamGiaController(IChiTietGiamGiaService chiTietGiamGiaService)
        {
            _chiTietService = chiTietGiamGiaService;
        }

        public List<SanPham> GetAvailableProductsForPromotion(string maCTGG)
        {
            return _chiTietService.GetAvailableProducts(maCTGG);
        }

        public List<ChiTietGiamGiaDto> GetAppliedProductsForPromotion(string maCTGG)
        {
            return _chiTietService.GetAppliedProducts(maCTGG);
        }

        public void AddProductToPromotion(string maCTGG, string maSP, int phanTramGiam)
        {
            _chiTietService.AddProductToPromotion(maCTGG, maSP, phanTramGiam);
        }

        public void RemoveProductFromPromotion(string maCTGG, string maSP)
        {
            _chiTietService.RemoveProductFromPromotion(maCTGG, maSP);
        }
    }
}
