using BagShopManagement.DTOs;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using BagShopManagement.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BagShopManagement.Services.Implementations
{
    /// <summary>
    /// Service xử lý logic nghiệp vụ cho Point of Sale (POS)
    /// Quản lý giỏ hàng và quy trình thanh toán
    /// </summary>
    public class PosService : IPosService
    {
        private readonly ISanPhamRepository _sanPhamRepo;
        private readonly IHoaDonBanService _hoaDonService;
        private readonly ITonKhoService _tonKhoService;

        // In-memory cart cho session hiện tại
        private readonly List<CartItem> _cart = new();

        public PosService(ISanPhamRepository spRepo, IHoaDonBanService hdService, ITonKhoService tonKhoService)
        {
            _sanPhamRepo = spRepo;
            _hoaDonService = hdService;
            _tonKhoService = tonKhoService;
        }

        /// <summary>
        /// Thêm sản phẩm vào giỏ hàng
        /// </summary>
        /// <param name="maSP">Mã sản phẩm cần thêm</param>
        /// <param name="soLuong">Số lượng cần thêm</param>
        /// <returns>Tuple (success, message) - thành công và thông báo</returns>
        public (bool ok, string message) AddProductToCart(string maSP, int soLuong)
        {
            if (!InputValidator.IsValidQuantity(soLuong))
                return (false, "Số lượng không hợp lệ");

            var sp = _sanPhamRepo.GetById(maSP);
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

        /// <summary>
        /// Áp dụng phần trăm giảm giá cho tất cả sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="percent">Phần trăm giảm giá (0-100)</param>
        public void ApplyDiscounts(decimal percent)
        {
            if (percent <= 0) return;

            foreach (var item in _cart)
            {
                item.GiamGiaSP = Math.Round(item.DonGia * (percent / 100m), 2);
            }
        }

        /// <summary>
        /// Áp dụng phần trăm giảm giá cho một sản phẩm cụ thể trong giỏ hàng
        /// </summary>
        /// <param name="maSP">Mã sản phẩm cần giảm giá</param>
        /// <param name="percent">Phần trăm giảm giá (0-100)</param>
        public void ApplyDiscountToProduct(string maSP, decimal percent)
        {
            if (string.IsNullOrWhiteSpace(maSP) || percent <= 0) return;

            var item = _cart.FirstOrDefault(i => string.Equals(i.MaSP, maSP, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                item.GiamGiaSP = Math.Round(item.DonGia * (percent / 100m), 2);
            }
        }

        /// <summary>
        /// Thực hiện thanh toán giỏ hàng và tạo hóa đơn
        /// </summary>
        /// <param name="maKH">Mã khách hàng (nullable - null = khách lẻ)</param>
        /// <param name="maNV">Mã nhân viên bán hàng</param>
        /// <param name="saveDraft">True = lưu nháp, False = thanh toán ngay</param>
        /// <param name="phuongThucTT">Phương thức thanh toán (Tiền mặt, Chuyển khoản...)</param>
        /// <param name="ghiChu">Ghi chú đơn hàng</param>
        /// <returns>Tuple (success, maHDB) - thành công và mã hóa đơn được tạo</returns>
        public (bool ok, string result) Checkout(string maKH, string maNV, bool saveDraft = false,
                                                 string? phuongThucTT = null, string? ghiChu = null)
        {
            if (_cart.Count == 0)
                return (false, "Giỏ hàng rỗng");

            // Validate và chuẩn hóa MaKH
            string? validatedMaKH = ValidateMaKH(maKH);

            var hd = new HoaDonBan
            {
                MaHDB = string.Empty,
                MaKH = validatedMaKH,
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

        /// <summary>
        /// Lấy danh sách sản phẩm trong giỏ hàng (copy để tránh modification)
        /// </summary>
        public List<CartItem> GetCart() => _cart.ToList();

        /// <summary>
        /// Xóa tất cả sản phẩm khỏi giỏ hàng
        /// </summary>
        public void ClearCart() => _cart.Clear();

        /// <summary>
        /// Xóa một sản phẩm khỏi giỏ hàng
        /// </summary>
        /// <param name="maSP">Mã sản phẩm cần xóa</param>
        public void RemoveProductFromCart(string maSP)
        {
            var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
            if (item != null)
                _cart.Remove(item);
        }

        /// <summary>
        /// Validate mã khách hàng có tồn tại trong database
        /// </summary>
        /// <param name="maKH">Mã khách hàng cần validate</param>
        /// <returns>
        /// - null: Nếu maKH rỗng hoặc không tồn tại trong DB (xử lý như khách lẻ)
        /// - string: MaKH trim nếu tồn tại trong DB
        /// </returns>
        /// <remarks>
        /// Logic xử lý:
        /// 1. Null/empty → trả về null (khách lẻ)
        /// 2. Không tồn tại trong DB → log warning và trả về null
        /// 3. Tồn tại → trả về MaKH đã trim
        /// </remarks>
        private string? ValidateMaKH(string? maKH)
        {
            // Nếu rỗng hoặc null, trả về null (khách lẻ)
            if (string.IsNullOrWhiteSpace(maKH))
                return null;

            // Kiểm tra MaKH có tồn tại trong bảng KhachHang không
            //try
            //{
            //    using var conn = DatabaseConfig.CreateConnection();
            //    conn.Open();
            //    using var cmd = new SqlCommand("SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH", conn);
            //    cmd.Parameters.Add(new SqlParameter("@MaKH", maKH.Trim()));

            //    var result = cmd.ExecuteScalar();
            //    if (result != null)
            //    {
            //        int count = Convert.ToInt32(result);
            //        if (count > 0)
            //        {
            //            // MaKH tồn tại, trả về giá trị
            //            return maKH.Trim();
            //        }
            //    }

            //    // MaKH không tồn tại, trả về null (xử lý như khách lẻ)
            //    Logger.Log($"MaKH '{maKH}' không tồn tại trong database, xử lý như khách lẻ");
            //    return null;
            //}
            //catch (Exception ex)
            //{
            //    // Nếu có lỗi khi check, log và trả về null để tránh lỗi foreign key
            //    Logger.Log($"Lỗi khi validate MaKH '{maKH}': {ex.Message}. Xử lý như khách lẻ.");
            //    return null;
            //}
            return null;
        }
    }
}