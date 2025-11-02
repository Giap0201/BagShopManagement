using BagShopManagement.DTOs;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class ChuongTrinhGiamGiaController
    {
        private readonly IChuongTrinhGiamGiaService _promotionService;
        public ChuongTrinhGiamGiaController()
        {
            _promotionService = new ChuongTrinhGiamGiaService();
        }

        public List<ChuongTrinhGiamGiaDto> GetPromotions()
        {
            return _promotionService.GetAllPromotions();
        }

        public void SavePromotion(ChuongTrinhGiamGiaDto dto)
        {
            _promotionService.SavePromotion(dto);
        }

        public void DeletePromotion(string maCTGG)
        {
            _promotionService.DeletePromotion(maCTGG);
        }
    }
}
