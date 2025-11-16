using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class ThuongHieuController
    {
        private readonly IThuongHieuService _service;
        public ThuongHieuController(IThuongHieuService service) { _service = service; }

        public List<ThuongHieu> GetAll() => _service.GetAll();
        public ThuongHieu GetById(string ma) => _service.GetById(ma);
        public bool Add(ThuongHieu item) => _service.Add(item);
        public bool Update(ThuongHieu item) => _service.Update(item);
        public bool Delete(string ma) => _service.Delete(ma);
        public List<ThuongHieu> Search(string kw) => _service.Search(kw);

        public string GenerateNextCode() => _service.GenerateNextCode();
    }
}
