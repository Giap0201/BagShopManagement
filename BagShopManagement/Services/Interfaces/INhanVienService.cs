using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface INhanVienService
    {
        /// <summary>
        /// Lấy danh sách nhân viên (đã JOIN) để hiển thị.
        /// </summary>
        List<NhanVienResponse> GetAllNhanVien();

        /// <summary>
        /// Tạo mới Nhân viên và Tài khoản.
        /// </summary>
        bool CreateNhanVien(CreateNhanVienRequest request);

        /// <summary>
        /// Cập nhật Nhân viên và Tài khoản.
        /// </summary>
        bool UpdateNhanVien(UpdateNhanVienRequest request);

        /// <summary>
        /// Tìm kiếm nhân viên.
        /// </summary>
        List<NhanVienResponse> SearchNhanVien(string keyword);
    }
}
