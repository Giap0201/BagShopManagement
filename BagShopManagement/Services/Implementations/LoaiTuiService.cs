using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System.Collections.Generic;
using System.Globalization;

namespace BagShopManagement.Services.Implementations
{
    public class LoaiTuiService : ILoaiTuiService
    {
        private readonly ILoaiTuiRepository _repo;
        private const string Prefix = "LT"; // confirm prefix

        public LoaiTuiService(ILoaiTuiRepository repo) { _repo = repo; }

        public List<DanhMucLoaiTui> GetAll() => _repo.GetAll();
        public DanhMucLoaiTui GetById(string ma) => _repo.GetById(ma);
        public bool Add(DanhMucLoaiTui item) => _repo.Add(item);
        public bool Update(DanhMucLoaiTui item) => _repo.Update(item);
        public bool Delete(string ma) => _repo.Delete(ma);
        public List<DanhMucLoaiTui> Search(string keyword) => _repo.Search(keyword);

        // --- MỚI ---
        public string GenerateNextCode()
        {
            var maxCode = _repo.GetMaxCode(); // e.g. "LT005"
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return Prefix + "001";
            }

            // lấy phần số phía sau prefix
            string numericPart = maxCode.StartsWith(Prefix)
                ? maxCode.Substring(Prefix.Length)
                : maxCode;

            if (!int.TryParse(numericPart, out int current))
            {
                // nếu bị lỗi parse, fallback
                current = 0;
            }

            int next = current + 1;
            return Prefix + next.ToString("000", CultureInfo.InvariantCulture);
        }
    }
}
