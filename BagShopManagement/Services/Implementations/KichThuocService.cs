using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BagShopManagement.Services.Implementations
{
    public class KichThuocService : IKichThuocService
    {
        private readonly IKichThuocRepository _repo;
        private const string Prefix = "KT";

        public KichThuocService(IKichThuocRepository repo)
        {
            _repo = repo;
        }

        public List<KichThuoc> GetAll() => _repo.GetAll();
        public KichThuoc GetById(string ma) => _repo.GetById(ma);
        public bool Add(KichThuoc item) => _repo.Add(item);
        public bool Update(KichThuoc item) => _repo.Update(item);
        public bool Delete(string ma) => _repo.Delete(ma);
        public List<KichThuoc> Search(string keyword) => _repo.Search(keyword);

        public string GenerateNextCode()
        {
            var maxCode = _repo.GetMaxCode(); // e.g. "KT005"
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return Prefix + "001";
            }

            string numericPart = maxCode.StartsWith(Prefix, StringComparison.OrdinalIgnoreCase)
                ? maxCode.Substring(Prefix.Length)
                : maxCode;

            if (!int.TryParse(numericPart, out int current))
                current = 0;

            int next = current + 1;
            return Prefix + next.ToString("000", CultureInfo.InvariantCulture);
        }
    }
}
