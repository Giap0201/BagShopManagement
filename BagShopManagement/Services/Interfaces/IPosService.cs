using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IPosService
    {
        (bool ok, string message) AddProductToCart(string maSP, int soLuong);
        void ApplyDiscounts(decimal percent);
        // Apply discount percent to a single product in the cart
        void ApplyDiscountToProduct(string maSP, decimal percent);
        (bool ok, string result) Checkout(string maKH, string maNV, string? phuongThucTT = null, string? ghiChu = null);
        List<CartItem> GetCart();
        void ClearCart();
        void RemoveProductFromCart(string maSP);
    }
}
