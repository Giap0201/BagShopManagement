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
        IEnumerable<NhanVienResponse> GetAllNhanVien();

        /// <summary>
        /// [TRANSACTION] Tạo mới Nhân viên và Tài khoản.
        /// </summary>
        bool CreateNhanVien(CreateNhanVienRequest request);

        /// <summary>
        /// [TRANSACTION] Cập nhật Nhân viên và Tài khoản.
        /// </summary>
        bool UpdateNhanVien(UpdateNhanVienRequest request);
        IEnumerable<NhanVienResponse> SearchNhanVien(string keyword);
    }
}
