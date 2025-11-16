using BagShopManagement.DTOs;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IHoaDonBanService
    {
        void SaveHoaDon(HoaDonBanDTO dto);
        List<HoaDonBan> GetAll();
        void CancelHoaDon(string maHDB);

        /// <summary>Lấy chi tiết hóa đơn bán theo mã HDB.</summary>
        List<ChiTietHoaDonBan> GetChiTietByMaHDB(string maHDB);

        /// <summary>Lọc hóa đơn theo ngày, nhân viên, trạng thái.</summary>
        List<HoaDonBan> Filter(DateTime? fromDate = null, DateTime? toDate = null, string? maNV = null, byte? trangThai = null);

        /// <summary>Cập nhật hóa đơn và chi tiết.</summary>
        void UpdateHoaDon(HoaDonBanDTO dto);

        /// <summary>Hủy hóa đơn và hoàn trả tồn kho.</summary>
        void CancelHoaDonWithRestoreStock(string maHDB, ITonKhoService tonKhoService);

        /// <summary>Xóa hóa đơn hoàn toàn khỏi database.</summary>
        void DeleteHoaDon(string maHDB);
    }
}
