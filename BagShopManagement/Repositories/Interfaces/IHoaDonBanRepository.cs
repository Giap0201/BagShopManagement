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
    }
}
