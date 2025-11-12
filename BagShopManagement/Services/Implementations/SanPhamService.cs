using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BagShopManagement.Services.Implementations
{
    public class SanPhamService : ISanPhamService
    {
        private readonly ISanPhamRepository _repo;

        public SanPhamService(ISanPhamRepository repo)
        {
            _repo = repo;
        }

        public List<SanPham> GetAll() => _repo.GetAll();

        public SanPham GetById(string maSP) => _repo.GetById(maSP);

        public bool Add(SanPham sp) => _repo.Add(sp);

        public bool Update(SanPham sp) => _repo.Update(sp);

        public bool Delete(string maSP) => _repo.Delete(maSP);

        public List<SanPham> Search(string keyword) => _repo.Search(keyword);

        public string GenerateNextCode()
        {
            string max = _repo.GetMaxCode();
            if (string.IsNullOrEmpty(max))
                return "SP001";
            int num = int.Parse(max.Substring(2));
            num++;
            return $"SP{num:D3}";
        }
    }
}
