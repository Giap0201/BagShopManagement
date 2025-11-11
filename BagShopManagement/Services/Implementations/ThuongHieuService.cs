using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BagShopManagement.Services.Implementations
{
    public class ThuongHieuService : IThuongHieuService
    {
        private readonly IThuongHieuRepository _repo;
        private const string Prefix = "TH";

        public ThuongHieuService(IThuongHieuRepository repo)
        {
            _repo = repo;
        }

        public List<ThuongHieu> GetAll() => _repo.GetAll();
        public ThuongHieu GetById(string ma) => _repo.GetById(ma);
        public bool Add(ThuongHieu item) => _repo.Add(item);
        public bool Update(ThuongHieu item) => _repo.Update(item);
        public bool Delete(string ma) => _repo.Delete(ma);
        public List<ThuongHieu> Search(string keyword) => _repo.Search(keyword);

        public string GenerateNextCode()
        {
            var maxCode = _repo.GetMaxCode(); // e.g. "TH005"
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
