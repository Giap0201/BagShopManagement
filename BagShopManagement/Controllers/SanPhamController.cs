using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Repositories.Interfaces;
using System.Collections.Generic;

namespace BagShopManagement.Controllers
{
    public class SanPhamController
    {
        private readonly ISanPhamService _service;

        public SanPhamController()
        {
            _service = new SanPhamService(new SanPhamRepository());
        }

        public List<SanPham> GetAll() => _service.GetAll();

        public bool Add(SanPham sp) => _service.Add(sp);

        public bool Update(SanPham sp) => _service.Update(sp);

        public bool Delete(string maSP) => _service.Delete(maSP);

        public List<SanPham> Search(string keyword) => _service.Search(keyword);

        public string GenerateNextCode() => _service.GenerateNextCode();
    }
}
