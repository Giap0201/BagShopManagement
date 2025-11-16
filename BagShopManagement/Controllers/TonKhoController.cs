using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class TonKhoController
    {
        private readonly ITonKhoService _tonKhoService;

        public TonKhoController(ITonKhoService tonKhoService)
        {
            _tonKhoService = tonKhoService;
        }

        public List<SanPham> GetInventoryProducts()
        {
            return _tonKhoService.GetAllProducts();
        }

        public void AdjustStock(string maSP, int soLuongThucTe, string maNV, string ghiChu)
        {
            _tonKhoService.DieuChinhTonKho(maSP, soLuongThucTe, maNV, ghiChu);
        }

        //public List<LichSuTonKho> GetProductHistory(string maSP)
        //{
        //    return _tonKhoService.GetHistoryByMaSP(maSP);
        //}
    }
}
