using BagShopManagement.Models;
using BagShopManagement.Repositories;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BagShopManagement.Services
{
    public class NhaCungCapService : INhaCungCapService
    {
        private readonly NhaCungCapRepository _repository;

        public NhaCungCapService()
        {
            _repository = new NhaCungCapRepository();
        }

        public List<NhaCungCap> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi lấy danh sách nhà cung cấp: " + ex.Message, ex);
            }
        }

        public NhaCungCap? GetById(string maNCC)
        {
            try
            {
                return _repository.GetById(maNCC);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi lấy nhà cung cấp theo mã: " + ex.Message, ex);
            }
        }

        public bool Add(NhaCungCap ncc)
        {
            try
            {
                int rows = _repository.Add(ncc);
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi thêm nhà cung cấp: " + ex.Message, ex);
            }
        }

        public bool Update(NhaCungCap ncc)
        {
            try
            {
                int rows = _repository.Update(ncc);
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi cập nhật nhà cung cấp: " + ex.Message, ex);
            }
        }

        public bool Delete(string maNCC)
        {
            try
            {
                int rows = _repository.Delete(maNCC);
                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi xóa nhà cung cấp: " + ex.Message, ex);
            }
        }

        public List<NhaCungCap> Search(string ten, string sdt, string email)
        {
            try
            {
                return _repository.Search(ten, sdt, email);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message, ex);
            }
        }
    }
}
