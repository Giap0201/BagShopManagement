using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class NhanVienController // <== Đã đổi tên
    {
        private readonly INhanVienService _nhanVienService;

        /// <summary>
        /// Constructor: Service sẽ được inject (tiêm) vào đây.
        /// </summary>
        public NhanVienController(INhanVienService nhanVienService) // <== Đã đổi tên
        {
            _nhanVienService = nhanVienService;
        }

        /// <summary>
        /// Lấy danh sách nhân viên để hiển thị trên DataGridView.
        /// Được gọi bởi: ucEmployeeManagement.
        /// </summary>
        public IEnumerable<NhanVienResponse> HandleGetAllNhanVien()
        {
            try
            {
                // Gọi thẳng service, không cần logic gì thêm
                return _nhanVienService.GetAllNhanVien();
            }
            catch (Exception ex)
            {
                // Ném lỗi ra cho View (ucEmployeeManagement) xử lý
                throw new Exception("Lỗi khi tải danh sách nhân viên: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Xử lý yêu cầu tạo nhân viên mới (bao gồm cả Tài khoản).
        /// Được gọi bởi: EmployeeEditForm (chế độ Thêm).
        /// </summary>
        public bool HandleCreateNhanVien(CreateNhanVienRequest request)
        {
            try
            {
                // NhanVienService sẽ xử lý toàn bộ logic nghiệp vụ và Transaction
                return _nhanVienService.CreateNhanVien(request);
            }
            catch (Exception ex)
            {
                // Ném lỗi nghiệp vụ (ví dụ: "Tên đăng nhập đã tồn tại")
                // hoặc lỗi transaction ra cho View (EmployeeEditForm) xử lý
                throw; // Re-throw lỗi gốc
            }
        }

        /// <summary>
        /// Xử lý yêu cầu cập nhật nhân viên (bao gồm cả Tài khoản).
        /// Được gọi bởi: EmployeeEditForm (chế độ Sửa).
        /// </summary>
        public bool HandleUpdateNhanVien(UpdateNhanVienRequest request)
        {
            try
            {
                // NhanVienService sẽ xử lý toàn bộ logic nghiệp vụ và Transaction
                return _nhanVienService.UpdateNhanVien(request);
            }
            catch (Exception ex)
            {
                // Ném lỗi ra cho View (EmployeeEditForm) xử lý
                throw; // Re-throw lỗi gốc
            }
        }
    }
}
