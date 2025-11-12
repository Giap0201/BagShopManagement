using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IHoaDonBanRepository
    {
        /// <summary>Insert hoa don and its details atomically.</summary>
        void Insert(HoaDonBan hd, List<ChiTietHoaDonBan> chiTiet);

        List<HoaDonBan> GetAll();
        HoaDonBan? GetByMaHDB(string maHDB);
        void UpdateTrangThai(string maHDB, byte trangThai);

        /// <summary>Lấy danh sách chi tiết hóa đơn bán theo mã HDB.</summary>
        List<ChiTietHoaDonBan> GetChiTietByMaHDB(string maHDB);

        /// <summary>Lọc hóa đơn theo ngày, nhân viên, trạng thái.</summary>
        List<HoaDonBan> Filter(DateTime? fromDate = null, DateTime? toDate = null, string? maNV = null, byte? trangThai = null);

        /// <summary>Cập nhật hóa đơn và chi tiết.</summary>
        void Update(HoaDonBan hd, List<ChiTietHoaDonBan> chiTiet);
    }
}
