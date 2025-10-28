// Services/Implementations/HoaDonBanService.cs
using BagShopManagement.DTOs;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BagShopManagement.Services.Implementations
{
    public class HoaDonBanService : IHoaDonBanService
    {
        private readonly IHoaDonBanRepository _repo;
        public HoaDonBanService(IHoaDonBanRepository repo) => _repo = repo;

        public void SaveHoaDon(HoaDonBanDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.HoaDon.MaHDB)) dto.HoaDon.MaHDB = GenerateMaHDB();
            foreach (var ct in dto.ChiTiets) ct.MaHDB = dto.HoaDon.MaHDB;

            try
            {
                _repo.Insert(dto.HoaDon, dto.ChiTiets);
                Logger.Log($"HoaDon saved: {dto.HoaDon.MaHDB}");
            }
            catch (Exception ex)
            {
                Logger.Log($"SaveHoaDon error: {ex.Message}");
                throw;
            }
        }

        public List<BagShopManagement.Models.HoaDonBan> GetAll() => _repo.GetAll();

        public void CancelHoaDon(string maHDB)
        {
            _repo.UpdateTrangThai(maHDB, 3); // 3 = canceled
            Logger.Log($"HoaDon canceled: {maHDB}");
        }

        private string GenerateMaHDB() => "HDB" + DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}
