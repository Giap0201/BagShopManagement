using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Models
{
    public class CartItem
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }    // 🆕 thêm tên sản phẩm để hiển thị
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGiaSP { get; set; }

        public decimal ThanhTien => (DonGia - GiamGiaSP) * SoLuong;
    }
}
