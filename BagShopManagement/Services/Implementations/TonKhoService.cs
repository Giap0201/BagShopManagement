// Services/Implementations/TonKhoService.cs
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;

namespace BagShopManagement.Services.Implementations
{
    public class TonKhoService : ITonKhoService
    {
        private readonly ISanPhamRepository _sanPhamRepo;

        public TonKhoService(ISanPhamRepository sanPhamRepo) => _sanPhamRepo = sanPhamRepo;

        public bool DecreaseStock(string maSP, int soLuong)
        {
            var sp = _sanPhamRepo.GetById(maSP);
            if (sp == null) return false;
            if (sp.SoLuongTon < soLuong) return false;
            sp.SoLuongTon -= soLuong;
            _sanPhamRepo.Update(sp);
            return true;
        }

        public void IncreaseStock(string maSP, int soLuong)
        {
            var sp = _sanPhamRepo.GetById(maSP);
            if (sp == null) throw new System.Exception("Sản phẩm không tồn tại");
            sp.SoLuongTon += soLuong;
            _sanPhamRepo.Update(sp);
        }
    }
}