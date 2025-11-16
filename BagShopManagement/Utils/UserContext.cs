using BagShopManagement.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Utils
{
    public static class UserContext
    {
        // Thông tin cơ bản
        public static string MaNV { get; private set; }
        public static string HoTen { get; private set; }
        public static string MaVaiTro { get; private set; }

        // Danh sách các Mã Quyền (ví dụ: "Q001", "Q005")
        public static List<string> MaQuyenList { get; private set; } = new List<string>();

        /// <summary>
        /// Kiểm tra nhanh xem người dùng đã đăng nhập hay chưa.
        /// </summary>
        public static bool IsLoggedIn => !string.IsNullOrEmpty(MaNV);

        /// <summary>
        /// Được gọi bởi LoginForm sau khi AuthService.Login() thành công.
        /// Lưu thông tin từ LoginResponse vào các biến tĩnh.
        /// </summary>
        /// <param name="response">DTO chứa thông tin người dùng.</param>
        public static void SetCurrentUser(LoginResponse response)
        {
            if (response == null)
            {
                Logout(); // Nếu response null thì coi như Logout
                return;
            }

            MaNV = response.MaNV;
            HoTen = response.HoTen;
            MaVaiTro = response.MaVaiTro;
            MaQuyenList = response.MaQuyenList ?? new List<string>();
        }

        /// <summary>
        /// Xóa thông tin phiên làm việc khi người dùng Đăng xuất.
        /// </summary>
        public static void Logout()
        {
            MaNV = null;
            HoTen = null;
            MaVaiTro = null;
            MaQuyenList = new List<string>(); // Khởi tạo lại danh sách rỗng
        }

        /// <summary>
        /// Hàm helper tiện ích.
        /// Được dùng bởi SideBarControl hoặc các nút (Thêm/Sửa/Xóa)
        /// để kiểm tra xem người dùng hiện tại CÓ một quyền cụ thể hay không.
        /// </summary>
        /// <param name="maQuyenCanKiemTra">Mã quyền cần kiểm tra (ví dụ: "Q005" - Quản lý nhân viên).</param>
        /// <returns>True nếu có quyền, False nếu không.</returns>
        public static bool HasPermission(string maQuyenCanKiemTra)
        {
            if (!IsLoggedIn || MaQuyenList == null || !MaQuyenList.Any())
            {
                return false;
            }

            // Kiểm tra xem danh sách quyền có chứa mã quyền cần tìm hay không
            return MaQuyenList.Contains(maQuyenCanKiemTra);
        }
    }
}
