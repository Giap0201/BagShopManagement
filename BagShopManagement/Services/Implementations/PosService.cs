using BagShopManagement.DTOs;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BagShopManagement.Services.Implementations
{
    public class PosService : IPosService
    {
        private readonly ISanPhamRepository _sanPhamRepo;
        private readonly IHoaDonBanService _hoaDonService;
        private readonly ITonKhoService _tonKhoService;
        private readonly List<CartItem> _cart = new(); // ✅ dùng CartItem thay vì ChiTietHoaDonBan

        public PosService(ISanPhamRepository spRepo, IHoaDonBanService hdService, ITonKhoService tonKhoService)
        {
            _sanPhamRepo = spRepo;
            _hoaDonService = hdService;
            _tonKhoService = tonKhoService;
        }

        public (bool ok, string message) AddProductToCart(string maSP, int soLuong)
        {
            if (!InputValidator.IsValidQuantity(soLuong))
                return (false, "Số lượng không hợp lệ");

            var sp = _sanPhamRepo.GetByMaSP(maSP);
            if (sp == null)
                return (false, "Sản phẩm không tồn tại");

            var existing = _cart.FirstOrDefault(x => x.MaSP == maSP);
            var total = (existing?.SoLuong ?? 0) + soLuong;

            if (sp.SoLuongTon < total)
                return (false, "Không đủ tồn kho");

            if (existing == null)
            {
                _cart.Add(new CartItem
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    SoLuong = soLuong,
                    DonGia = sp.GiaBan,
                    GiamGiaSP = 0m
                });
            }
            else
            {
                existing.SoLuong += soLuong;
            }

            return (true, "Đã thêm vào giỏ hàng");
        }

        public void ApplyDiscounts(decimal percent)
        {
            if (percent <= 0) return;

            foreach (var item in _cart)
            {
                item.GiamGiaSP = Math.Round(item.DonGia * (percent / 100m), 2);
            }
        }

        public (bool ok, string result) Checkout(string maKH, string maNV, bool saveDraft = false,
                                                 string phuongThucTT = null, string ghiChu = null)
        {
            if (_cart.Count == 0)
                return (false, "Giỏ hàng rỗng");

            var hd = new HoaDonBan
            {
                MaHDB = string.Empty,
                MaKH = maKH,
                MaNV = maNV,
                NgayBan = DateTime.Now,
                TongTien = _cart.Sum(i => i.ThanhTien),
                PhuongThucTT = phuongThucTT,
                GhiChu = ghiChu,
                TrangThaiHD = saveDraft ? (byte)1 : (byte)2
            };

            var dto = new HoaDonBanDTO
            {
                HoaDon = hd,
                ChiTiets = _cart.Select(i => new ChiTietHoaDonBan
                {
                    MaSP = i.MaSP,
                    SoLuong = i.SoLuong,
                    DonGia = i.DonGia,
                    GiamGiaSP = i.GiamGiaSP
                }).ToList()
            };

            try
            {
                TransactionHelper.RunInTransaction(() =>
                {
                    _hoaDonService.SaveHoaDon(dto);

                    if (!saveDraft)
                    {
                        foreach (var item in _cart)
                        {
                            var ok = _tonKhoService.DecreaseStock(item.MaSP, item.SoLuong);
                            if (!ok)
                                throw new Exception($"Không đủ tồn kho cho sản phẩm: {item.MaSP}");
                        }
                    }
                });

                _cart.Clear();
                return (true, dto.HoaDon.MaHDB);
            }
            catch (Exception ex)
            {
                Logger.Log($"Checkout failed (rollback): {ex.Message}");
                return (false, $"Thanh toán thất bại: {ex.Message}");
            }
        }

        public List<CartItem> GetCart() => _cart.ToList();

        public void ClearCart() => _cart.Clear();

        public void RemoveProductFromCart(string maSP)
        {
            var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
            if (item != null)
                _cart.Remove(item);
        }
    }
}
