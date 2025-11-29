using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BagShopManagement.Controllers
{
    public class NhaCungCapController
    {
        private readonly INhaCungCapService _service;

        public NhaCungCapController()
        {
            _service = new NhaCungCapService();
        }

        // Lấy danh sách tất cả nhà cung cấp
        public List<NhaCungCap> GetAll() => _service.GetAll();

        // Lấy nhà cung cấp theo mã
        public NhaCungCap GetById(string maNCC) => _service.GetById(maNCC);

        // Thêm nhà cung cấp mới
        public bool Add(NhaCungCap ncc) => _service.Add(ncc);

        // Cập nhật thông tin nhà cung cấp
        public bool Update(NhaCungCap ncc) => _service.Update(ncc);

        // Xóa nhà cung cấp theo mã
        public bool Delete(string maNCC) => _service.Delete(maNCC);

        public string GenerateNextCode() => _service.GenerateNextCode();

        
        public List<NhaCungCap> Search(string kw) => _service.Search(kw);
    }
}
