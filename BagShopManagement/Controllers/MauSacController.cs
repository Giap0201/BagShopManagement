using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class MauSacController
    {
        private readonly IMauSacService _service;
        public MauSacController(IMauSacService service) { _service = service; }

        public List<MauSac> GetAll() => _service.GetAll();
        public MauSac GetById(string ma) => _service.GetById(ma);
        public bool Add(MauSac item) => _service.Add(item);
        public bool Update(MauSac item) => _service.Update(item);
        public bool Delete(string ma) => _service.Delete(ma);
        public List<MauSac> Search(string kw) => _service.Search(kw);

        public string GenerateNextCode() => _service.GenerateNextCode();
    }
}
