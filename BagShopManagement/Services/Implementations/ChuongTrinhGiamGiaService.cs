using BagShopManagement.DTOs;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Implementations
{
    public class ChuongTrinhGiamGiaService : IChuongTrinhGiamGiaService
    {
        private readonly IChuongTrinhGiamGiaRepository _ctggRepo;
        private readonly IChiTietGiamGiaRepository _ctggDetailRepo;

        public ChuongTrinhGiamGiaService()
        {
            // Chỗ này nên dùng Dependency Injection, tạm thời khởi tạo trực tiếp
            _ctggRepo = new ChuongTrinhGiamGiaRepository();
            _ctggDetailRepo = new ChiTietGiamGiaRepository();
        }

        public List<ChuongTrinhGiamGiaDto> GetAllPromotions()
        {
            var models = _ctggRepo.GetAll();
            // Dùng AutoMapper hoặc map thủ công Model -> DTO
            var dtos = models.Select(m => new ChuongTrinhGiamGiaDto {
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
            if (string.IsNullOrWhiteSpace(dto.MaCTGG))
                throw new Exception("Mã chương trình không được để trống.");
            // === LOGIC NGHIỆP VỤ ===
            if (string.IsNullOrWhiteSpace(dto.TenChuongTrinh))
                throw new Exception("Tên chương trình không được để trống.");
            if (dto.NgayKetThuc <= dto.NgayBatDau)
                throw new Exception("Ngày kết thúc phải sau ngày bắt đầu.");
            if (_ctggRepo.CheckIfNameExists(dto.TenChuongTrinh, dto.MaCTGG))
                throw new Exception("Tên chương trình này đã tồn tại.");

            // Map DTO -> Model
            var model = new ChuongTrinhGiamGia { 
                MaCTGG = dto.MaCTGG,
                TenChuongTrinh = dto.TenChuongTrinh,
                MoTa = dto.MoTa,
                NgayBatDau = dto.NgayBatDau,
                NgayKetThuc = dto.NgayKetThuc,
                TrangThai = dto.TrangThai

            };

            if (_ctggRepo.CheckIfIdExists(dto.MaCTGG))
            {
                // ID đã tồn tại -> Cập nhật
                _ctggRepo.Update(model);
            }
            else
            {
                // ID chưa tồn tại -> Thêm mới
                _ctggRepo.Add(model);
            }
        }

        public void DeletePromotion(string maCTGG)
        {
            // Xóa các chi tiết liên quan trước để không vi phạm khóa ngoại
            _ctggDetailRepo.RemoveByMaCTGG(maCTGG);
            // Sau đó xóa chương trình chính
            _ctggRepo.Delete(maCTGG);
        }
    }
}
