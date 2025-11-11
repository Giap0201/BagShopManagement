using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BagShopManagement.Services.Implementations
{
    public class ChatLieuService : IChatLieuService
    {
        private readonly IChatLieuRepository _repo;
        private const string Prefix = "CL";

        public ChatLieuService(IChatLieuRepository repo)
        {
            _repo = repo;
        }

        public List<ChatLieu> GetAll() => _repo.GetAll();
        public ChatLieu GetById(string ma) => _repo.GetById(ma);
        public bool Add(ChatLieu item) => _repo.Add(item);
        public bool Update(ChatLieu item) => _repo.Update(item);
        public bool Delete(string ma) => _repo.Delete(ma);
        public List<ChatLieu> Search(string keyword) => _repo.Search(keyword);

        // Generate next code like CL001, CL002 ...
        public string GenerateNextCode()
        {
            var maxCode = _repo.GetMaxCode(); // e.g. "CL005"
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
