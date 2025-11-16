using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class KichThuocController
    {
        private readonly IKichThuocService _service;
        public KichThuocController(IKichThuocService service) { _service = service; }

        public List<KichThuoc> GetAll() => _service.GetAll();
        public KichThuoc GetById(string ma) => _service.GetById(ma);
        public bool Add(KichThuoc item) => _service.Add(item);
        public bool Update(KichThuoc item) => _service.Update(item);
        public bool Delete(string ma) => _service.Delete(ma);
        public List<KichThuoc> Search(string kw) => _service.Search(kw);

        public string GenerateNextCode() => _service.GenerateNextCode();
    }
}
