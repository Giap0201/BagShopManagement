using System.Collections.Generic;
using BagShopManagement.Models;

namespace BagShopManagement.Services
{
    public interface IKhachHangService
    {
        List<KhachHang> GetAll();
        List<KhachHang>? GetById(string kw);
        bool Add(KhachHang kh);
        bool Update(KhachHang kh);
        bool Delete(string maKH);
        List<KhachHang> Search(string ten, string sdt, string email);
        string GenerateNextCustomerCode();
    }
}
