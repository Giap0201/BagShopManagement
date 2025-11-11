using BagShopManagement.Models;

namespace BagShopManagement.Repositories.Interfaces
{
    /// <summary>
    /// Interface cho nghiệp vụ liên quan đến Khách Hàng
    /// </summary>
    public interface IKhachHangRepository
    {
        public List<KhachHang> GetAll();

        public KhachHang? GetById(string maKH);

        public int Add(KhachHang kh);

        public int Update(KhachHang kh);

        public int Delete(string maKH);

        public List<KhachHang> Search(string ten, string sdt, string email);

        bool Exists(string maKH);
    }
}