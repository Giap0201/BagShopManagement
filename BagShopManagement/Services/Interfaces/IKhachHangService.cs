using System.Collections.Generic;
using BagShopManagement.Models;

namespace BagShopManagement.Services
{
    public interface IKhachHangService
    {
        List<KhachHang> GetAll();
        KhachHang? GetById(string maKH);
        bool Add(KhachHang kh);
        bool Update(KhachHang kh);
        bool Delete(string maKH);
        List<KhachHang> Search(string ten, string sdt, string email);
    }
}
