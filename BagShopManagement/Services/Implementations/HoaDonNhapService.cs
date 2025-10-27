using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Implementations
{
    public class HoaDonNhapService : IHoaDonNhapService
    {
        // Service phụ thuộc vào Repository
        private readonly IHoaDonNhapRepository _repo;

        public HoaDonNhapService(IHoaDonNhapRepository repo)
        {
            _repo = repo;
        }

        public List<HoaDonNhap> GetAllHoaDonNhap()
        {
            try
            {
                var entities = _repo.GetAll();

                // Mapping entity → Response DTO
                return entities;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                ExceptionHandler.Handle(ex);
                // Trả về danh sách rỗng nếu có lỗi, client có thể kiểm tra Count==0
                return new List<HoaDonNhap>();
            }
        }
    }
}