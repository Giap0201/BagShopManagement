using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class SanPhamController
    {
        private readonly ISanPhamService _service;

        public SanPhamController(ISanPhamService service)
        {
            _service = service;
        }

        public List<SanPham> GetAll() => _service.GetAll();
        public SanPham GetById(string maSP) => _service.GetById(maSP);
        public bool Add(SanPham sp) => _service.Add(sp);
        public bool Update(SanPham sp) => _service.Update(sp);
        public bool Delete(string maSP) => _service.Delete(maSP);
        public List<SanPham> Search(string keyword) => _service.Search(keyword);
    }
}
