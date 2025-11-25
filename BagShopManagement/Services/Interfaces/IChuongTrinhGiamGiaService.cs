using BagShopManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IChuongTrinhGiamGiaService
    {
        List<ChuongTrinhGiamGiaDto> GetAllPromotions();
        void SavePromotion(ChuongTrinhGiamGiaDto dto);
        void DeletePromotion(string maCTGG);
    }
}
