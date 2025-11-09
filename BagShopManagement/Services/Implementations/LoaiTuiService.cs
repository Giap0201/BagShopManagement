using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System.Collections.Generic;

namespace BagShopManagement.Services.Implementations
{
    public class LoaiTuiService : ILoaiTuiService
    {
        private readonly ILoaiTuiRepository _repo;
        public LoaiTuiService(ILoaiTuiRepository repo) { _repo = repo; }

        public List<DanhMucLoaiTui> GetAll() => _repo.GetAll();
        public DanhMucLoaiTui GetById(string ma) => _repo.GetById(ma);
        public bool Add(DanhMucLoaiTui item) => _repo.Add(item);
        public bool Update(DanhMucLoaiTui item) => _repo.Update(item);
        public bool Delete(string ma) => _repo.Delete(ma);
        public List<DanhMucLoaiTui> Search(string keyword) => _repo.Search(keyword);
    }
}
