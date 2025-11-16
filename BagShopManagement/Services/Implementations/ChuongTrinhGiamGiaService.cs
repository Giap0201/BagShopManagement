using BagShopManagement.DTOs;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BagShopManagement.Services.Implementations
{
    public class ChuongTrinhGiamGiaService : IChuongTrinhGiamGiaService
    {
        private readonly IChuongTrinhGiamGiaRepository _ctggRepo;
        private readonly IChiTietGiamGiaRepository _ctggDetailRepo;

        public ChuongTrinhGiamGiaService(IChuongTrinhGiamGiaRepository ctrinhGiamGiaRepository, IChiTietGiamGiaRepository chiTietGiamGiaRepository)
        {
            _ctggRepo = ctrinhGiamGiaRepository;
            _ctggDetailRepo = chiTietGiamGiaRepository;
        }

        public List<ChuongTrinhGiamGiaDto> GetAllPromotions()
        {
            var models = _ctggRepo.GetAll();
            var dtos = models.Select(m => new ChuongTrinhGiamGiaDto
            {
                MaCTGG = m.MaCTGG,
                TenChuongTrinh = m.TenChuongTrinh,
                MoTa = m.MoTa,
                NgayBatDau = m.NgayBatDau,
                NgayKetThuc = m.NgayKetThuc,
                TrangThai = m.TrangThai
            }).ToList();
            return dtos;
        }

        public void SavePromotion(ChuongTrinhGiamGiaDto dto)
        {
            // === LOGIC NGHIỆP VỤ ===
            if (string.IsNullOrWhiteSpace(dto.MaCTGG))
                throw new Exception("Mã chương trình không được để trống.");
            if (string.IsNullOrWhiteSpace(dto.TenChuongTrinh))
                throw new Exception("Tên chương trình không được để trống.");
            if (dto.NgayKetThuc <= dto.NgayBatDau)
                throw new Exception("Ngày kết thúc phải sau ngày bắt đầu.");
            if (_ctggRepo.CheckIfNameExists(dto.TenChuongTrinh, dto.MaCTGG))
                throw new Exception("Tên chương trình này đã tồn tại.");

            var model = new ChuongTrinhGiamGia
            {
                MaCTGG = dto.MaCTGG,
                TenChuongTrinh = dto.TenChuongTrinh,
                MoTa = dto.MoTa,
                NgayBatDau = dto.NgayBatDau,
                NgayKetThuc = dto.NgayKetThuc,
                TrangThai = dto.TrangThai
            };

            if (_ctggRepo.CheckIfIdExists(dto.MaCTGG))
            {
                _ctggRepo.Update(model);
            }
            else
            {
                _ctggRepo.Add(model);
            }
        }

        public void DeletePromotion(string maCTGG)
        {
            _ctggDetailRepo.RemoveByMaCTGG(maCTGG);
            _ctggRepo.Delete(maCTGG);
        }
    }
}