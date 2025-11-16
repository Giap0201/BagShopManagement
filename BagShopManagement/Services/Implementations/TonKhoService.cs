using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Implementations
{
    internal class TonKhoService : ITonKhoService
    {
        private readonly ISanPhamRepository _sanPhamRepo;
        //private readonly ILichSuTonKhoRepository _lichSuRepo;
        public TonKhoService(ISanPhamRepository sanPhamRepo)
        {
            _sanPhamRepo = sanPhamRepo;
        }

        public bool DecreaseStock(string maSP, int soLuong)
        {
            throw new NotImplementedException();
        }

        public void DieuChinhTonKho(string maSP, int soLuongThucTe, string maNV, string ghiChu)
        {
            if (soLuongThucTe < 0)
            {
                throw new ArgumentException("Số lượng thực tế không được là số âm.");
            }

            var sanPhamHienTai = _sanPhamRepo.GetById(maSP);
            if (sanPhamHienTai == null)
        {
                throw new KeyNotFoundException("Không tìm thấy sản phẩm với mã này.");
            }

            int soLuongCu = sanPhamHienTai.SoLuongTon;
            int soLuongThayDoi = soLuongThucTe - soLuongCu;

            // Cảnh báo: Để đảm bảo an toàn, hai hành động này nên được bọc trong một Transaction
            // 1. Cập nhật số lượng tồn
            _sanPhamRepo.UpdateSoLuong(maSP, soLuongThucTe);

            // 2. Ghi log lại hành động
            //var log = new LichSuTonKho
            //{
            //    MaSP = maSP,
            //    MaNV = maNV,
            //    ThoiGian = DateTime.Now,
            //    HanhDong = "Kiểm kê / Điều chỉnh",
            //    SoLuongThayDoi = soLuongThayDoi,
            //    SoLuongSauCung = soLuongThucTe,
            //    GhiChu = ghiChu
            //};
            //_lichSuRepo.Add(log);
        }

        public List<SanPham> GetAllProducts()
        {
            return _sanPhamRepo.GetAll();
        }

        public void IncreaseStock(string maSP, int soLuong)
        {
            throw new NotImplementedException();
        }
    }
}