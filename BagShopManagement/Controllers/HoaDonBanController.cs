// Controllers/HoaDonBanController.cs
using BagShopManagement.Services.Interfaces;
using BagShopManagement.DTOs;
using BagShopManagement.Models;
using System.Collections.Generic;

namespace BagShopManagement.Controllers
{
    public class HoaDonBanController
    {
        private readonly IHoaDonBanService _service;
        public HoaDonBanController(IHoaDonBanService service) => _service = service;

        public void Save(HoaDonBanDTO dto) => _service.SaveHoaDon(dto);
        public List<HoaDonBan> GetAll() => _service.GetAll();
        public void Cancel(string maHDB) => _service.CancelHoaDon(maHDB);
    }
}
