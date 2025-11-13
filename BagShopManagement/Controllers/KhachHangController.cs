using BagShopManagement.Models;
using BagShopManagement.Services;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BagShopManagement.Controllers
{
    public class KhachHangController
    {
        private readonly IKhachHangService _service;

        public KhachHangController()
        {
            _service = new KhachHangService();
        }

        // Lấy danh sách tất cả khách hàng
        public List<KhachHang> GetAll() => _service.GetAll();

        // Lấy khách hàng theo mã
        public KhachHang GetById(string maKH) => _service.GetById(maKH);

        // Thêm khách hàng mới
        public bool Add(KhachHang kh) => _service.Add(kh);

        // Cập nhật thông tin khách hàng
        public bool Update(KhachHang kh) => _service.Update(kh);

        // Xóa khách hàng theo mã
        public bool Delete(string maKH) => _service.Delete(maKH);

        // Tìm kiếm khách hàng theo từ khóa (tên, SDT, email, v.v.)
        //public List<KhachHang> Search(string keyword) => _service.Search(keyword);
    }
}
