// Controllers/HoaDonBanController.cs
using BagShopManagement.Services.Interfaces;
using BagShopManagement.DTOs;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;

namespace BagShopManagement.Controllers
{
    public class HoaDonBanController
    {
        private readonly IHoaDonBanService _service;
        private readonly ITonKhoService _tonKhoService;

        public HoaDonBanController(IHoaDonBanService service, ITonKhoService tonKhoService)
        {
            _service = service;
            _tonKhoService = tonKhoService;
        }

        public void Save(HoaDonBanDTO dto) => _service.SaveHoaDon(dto);
        public List<HoaDonBan> GetAll() => _service.GetAll();
        public void Cancel(string maHDB) => _service.CancelHoaDon(maHDB);

        public List<ChiTietHoaDonBan> GetChiTiet(string maHDB) => _service.GetChiTietByMaHDB(maHDB);

        public List<HoaDonBan> Filter(DateTime? fromDate = null, DateTime? toDate = null, string? maNV = null, byte? trangThai = null)
            => _service.Filter(fromDate, toDate, maNV, trangThai);

        public void Update(HoaDonBanDTO dto) => _service.UpdateHoaDon(dto);

        public void CancelWithRestoreStock(string maHDB) => _service.CancelHoaDonWithRestoreStock(maHDB, _tonKhoService);

        public void Delete(string maHDB) => _service.DeleteHoaDon(maHDB);
    }
}
