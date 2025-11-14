using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Implementations
{
    internal class KhachHangService : IKhachHangService
    {
        private readonly KhachHangRepository _repository;

        public KhachHangService()
        {
            _repository = new KhachHangRepository();
        }

        public List<KhachHang> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi lấy danh sách khách hàng: " + ex.Message, ex);
            }
        }

        public KhachHang? GetById(string maKH)
        {
            try
            {
                return _repository.GetById(maKH);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi lấy khách hàng theo mã: " + ex.Message, ex);
            }
        }

        public bool Add(KhachHang kh)
        {
            try
            {
                int rows = _repository.Add(kh);
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi thêm khách hàng: " + ex.Message, ex);
            }
        }

        public bool Update(KhachHang kh)
        {
            try
            {
                int rows = _repository.Update(kh);
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi cập nhật khách hàng: " + ex.Message, ex);
            }
        }

        public bool Delete(string maKH)
        {
            try
            {
                int rows = _repository.Delete(maKH);
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi xóa khách hàng: " + ex.Message, ex);
            }
        }

        public List<KhachHang> Search(string ten, string sdt, string email)
        {
            try
            {
                return _repository.Search(ten, sdt, email);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi tìm kiếm khách hàng: " + ex.Message, ex);
            }
        }
        public string GenerateNextCustomerCode()
        {
            var maxCode = _repository.GetMaxCode();
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return "KH001";
            }

            string numericPart = maxCode.StartsWith("KH", StringComparison.OrdinalIgnoreCase)
                ? maxCode.Substring(2)
                : maxCode;

            if (!int.TryParse(numericPart, out int current))
                current = 0;

            int next = current + 1;
            return "KH" + next.ToString("000", CultureInfo.InvariantCulture);
        }
    }
}
