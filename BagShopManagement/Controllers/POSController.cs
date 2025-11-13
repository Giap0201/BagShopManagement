using BagShopManagement.Services.Interfaces;
using BagShopManagement.Models;
using System.Collections.Generic;

namespace BagShopManagement.Controllers
{
    public class POSController
    {
        private readonly IPosService _pos;

        public POSController(IPosService posService)
        {
            _pos = posService;
        }

        // ➕ Thêm sản phẩm vào giỏ
        public (bool ok, string msg) AddProduct(string maSP, int qty)
            => _pos.AddProductToCart(maSP, qty);

        // 💸 Áp dụng giảm giá %
        public void ApplyDiscount(decimal percent)
            => _pos.ApplyDiscounts(percent);

        // 💸 Áp dụng giảm giá cho 1 sản phẩm
        public void ApplyDiscountToProduct(string maSP, decimal percent)
            => _pos.ApplyDiscountToProduct(maSP, percent);

        // 🧾 Thanh toán hoặc lưu tạm hóa đơn
        public (bool ok, string res) Checkout(string maKH, string maNV,
            bool saveDraft = false, string? phuongThucTT = null, string? ghiChu = null)
            => _pos.Checkout(maKH, maNV, saveDraft, phuongThucTT, ghiChu);

        // 📋 Lấy danh sách sản phẩm trong giỏ
        public List<CartItem> GetCart()
            => _pos.GetCart();

        // 🗑️ Xóa toàn bộ giỏ
        public void ClearCart()
            => _pos.ClearCart();

        // ❌ Xóa 1 sản phẩm trong giỏ
        public void RemoveProduct(string maSP)
            => _pos.RemoveProductFromCart(maSP);
    }
}
