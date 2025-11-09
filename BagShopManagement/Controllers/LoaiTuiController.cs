using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using System.Collections.Generic;

namespace BagShopManagement.Controllers
{
    public class LoaiTuiController
    {
        private readonly ILoaiTuiService _service;
        public LoaiTuiController(ILoaiTuiService service) { _service = service; }

        public List<DanhMucLoaiTui> GetAll() => _service.GetAll();
        public DanhMucLoaiTui GetById(string ma) => _service.GetById(ma);
        public bool Add(DanhMucLoaiTui item) => _service.Add(item);
        public bool Update(DanhMucLoaiTui item) => _service.Update(item);
        public bool Delete(string ma) => _service.Delete(ma);
        public List<DanhMucLoaiTui> Search(string kw) => _service.Search(kw);
    }
}
