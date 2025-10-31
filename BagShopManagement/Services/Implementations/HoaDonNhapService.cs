using BagShopManagement.DTOs.Requests;
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
        private readonly IHoaDonNhapRepository _repo;
        private readonly IChiTietHDNRepository _chiTietRepo;
        private readonly INhaCungCapRepository _nccRepo;
        private readonly INhanVienRepository _nvRepo;

        public HoaDonNhapService(
            IHoaDonNhapRepository repo,
            IChiTietHDNRepository chiTietRepo,
            INhaCungCapRepository nccRepo,
            INhanVienRepository nvRepo)
        {
            _repo = repo;
            _chiTietRepo = chiTietRepo;
            _nccRepo = nccRepo;
            _nvRepo = nvRepo;
        }

        public List<ChiTietHDNResponse> GetChiTietForDisplay(string maHDN)
        {
            try
            {
                // Gọi phương thức đã có sẵn của ChiTietHDNImpl
                return _chiTietRepo.GetDetailsByMaHDN(maHDN);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                return new List<ChiTietHDNResponse>();
            }
        }

        // TRIỂN KHAI SearchHoaDonNhap
        public List<HoaDonNhapResponse> SearchHoaDonNhap(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV)
        {
            try
            {
                return _repo.Search(maHDN, tuNgay, denNgay, maNCC, maNV);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                return new List<HoaDonNhapResponse>();
            }
        }

        // TRIỂN KHAI DeleteHoaDonNhap (NGHIỆP VỤ QUAN TRỌNG)
        public void DeleteHoaDonNhap(string maHDN)
        {
            try
            {
                // 1. Phải xoá chi tiết hóa đơn trước (để tránh lỗi khóa ngoại)
                _chiTietRepo.DeleteByMaHDN(maHDN);

                // 2. Sau đó mới xoá hóa đơn chính
                _repo.Delete(maHDN);
            }
            catch (Exception ex)
            {
                // Ném lỗi lên tầng trên (Controller) để hiển thị
                throw new ApplicationException($"Lỗi khi xoá hoá đơn {maHDN}: {ex.Message}", ex);
            }
        }

        // TRIỂN KHAI LẤY DỮ LIỆU COMBOBOX
        public List<NhaCungCap> GetNhaCungCapList()
        {
            return _nccRepo.GetAll();
        }

        public List<NhanVien> GetNhanVienList()
        {
            return _nvRepo.GetAll();
        }
    }
}