using BagShopManagement.DTOs;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BagShopManagement.Services.Implementations
{
    public class ChiTietGiamGiaService : IChiTietGiamGiaService
    {
        private readonly ISanPhamRepository _sanPhamRepo;
        private readonly IChiTietGiamGiaRepository _chiTietGiamGiaRepo;

        public ChiTietGiamGiaService()
        {
            _sanPhamRepo = new SanPhamRepository();
            _chiTietGiamGiaRepo = new ChiTietGiamGiaRepository();
        }

        public List<SanPham> GetAvailableProducts(string maCTGG)
        {
            return _sanPhamRepo.GetAvailableProducts(maCTGG);
        }

        public List<ChiTietGiamGiaDto> GetAppliedProducts(string maCTGG)
        {
            return _chiTietGiamGiaRepo.GetAppliedProducts(maCTGG);
        }

        public void AddProductToPromotion(string maCTGG, string maSP, int phanTramGiam)
        {
            // Logic nghiệp vụ
            if (phanTramGiam <= 0 || phanTramGiam > 100)
            {
                throw new Exception("Phần trăm giảm giá phải nằm trong khoảng (0, 100].");
            }

            var chiTiet = new ChiTietGiamGia
            {
                MaCTGG = maCTGG,
                MaSP = maSP,
                PhanTramGiam = phanTramGiam
            };
            _chiTietGiamGiaRepo.Add(chiTiet);
        }

        public void RemoveProductFromPromotion(string maCTGG, string maSP)
        {
            _chiTietGiamGiaRepo.Remove(maCTGG, maSP);
        }
    }
}