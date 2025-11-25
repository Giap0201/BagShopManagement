using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface ITonKhoService
    {
        List<SanPham> GetAllProducts();
        void DieuChinhTonKho(string maSP, int soLuongThucTe, string maNV, string ghiChu);
        //List<LichSuTonKho> GetHistoryByMaSP(string maSP);

        bool DecreaseStock(string maSP, int soLuong);
        void IncreaseStock(string maSP, int soLuong);
    }
}
