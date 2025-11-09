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

        public List<Models.ChiTietHoaDonBan> GetChiTietByMaHDB(string maHDB)
        {
            return _repo.GetChiTietByMaHDB(maHDB);
        }

        public List<Models.HoaDonBan> Filter(DateTime? fromDate = null, DateTime? toDate = null, string? maNV = null, byte? trangThai = null)
        {
            return _repo.Filter(fromDate, toDate, maNV, trangThai);
        }

        public void UpdateHoaDon(HoaDonBanDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.HoaDon.MaHDB))
                throw new ArgumentException("Mã hóa đơn không được để trống", nameof(dto));
            
            foreach (var ct in dto.ChiTiets) ct.MaHDB = dto.HoaDon.MaHDB;

            try
            {
                _repo.Update(dto.HoaDon, dto.ChiTiets);
                Logger.Log($"HoaDon updated: {dto.HoaDon.MaHDB}");
            }
            catch (Exception ex)
            {
                Logger.Log($"UpdateHoaDon error: {ex.Message}");
                throw;
            }
        }

        public void CancelHoaDonWithRestoreStock(string maHDB, ITonKhoService tonKhoService)
        {
            // Lấy chi tiết hóa đơn để hoàn trả tồn kho
            var chiTiets = _repo.GetChiTietByMaHDB(maHDB);
            var hoaDon = _repo.GetByMaHDB(maHDB);
            
            if (hoaDon == null)
                throw new Exception("Không tìm thấy hóa đơn");

            // Chỉ hoàn trả nếu hóa đơn đã thanh toán (TrangThaiHD = 2)
            if (hoaDon.TrangThaiHD == 2)
            {
                foreach (var ct in chiTiets)
                {
                    tonKhoService.IncreaseStock(ct.MaSP, ct.SoLuong);
                }
            }

            // Cập nhật trạng thái thành hủy (3)
            _repo.UpdateTrangThai(maHDB, 3);
            Logger.Log($"HoaDon canceled with stock restored: {maHDB}");
        }

        private string GenerateMaHDB() => "HDB" + DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}
