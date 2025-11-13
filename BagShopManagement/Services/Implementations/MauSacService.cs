using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BagShopManagement.Services.Implementations
{
    public class MauSacService : IMauSacService
    {
        private readonly IMauSacRepository _repo;
        private const string Prefix = "MS";

        public MauSacService(IMauSacRepository repo)
        {
            _repo = repo;
        }

        public List<MauSac> GetAll() => _repo.GetAll();
        public MauSac GetById(string ma) => _repo.GetById(ma);
        public bool Add(MauSac item) => _repo.Add(item);
        public bool Update(MauSac item) => _repo.Update(item);
        public bool Delete(string ma) => _repo.Delete(ma);
        public List<MauSac> Search(string keyword) => _repo.Search(keyword);

        public string GenerateNextCode()
        {
            var maxCode = _repo.GetMaxCode(); // e.g. "MS005"
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
