using BagShopManagement.DTOs.Requests;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Utils
{
    public class DatabaseSeeder
    {
        private readonly ITaiKhoanRepository _taiKhoanRepo;
        private readonly IVaiTroRepository _vaiTroRepo;
        private readonly INhanVienService _nhanVienService; // Dùng Service để tự động HASH và chạy Transaction

        public DatabaseSeeder(
            ITaiKhoanRepository taiKhoanRepo,
            IVaiTroRepository vaiTroRepo,
            INhanVienService nhanVienService)
        {
            _taiKhoanRepo = taiKhoanRepo;
            _vaiTroRepo = vaiTroRepo;
            _nhanVienService = nhanVienService;
        }

        /// <summary>
        /// Hàm chạy chính, được gọi từ Program.cs
        /// </summary>
        public void SeedInitialData()
        {
            // Bước 1: Tạo vai trò Quản trị viên nếu chưa có
            SeedAdminRole();

            // Bước 2: Tạo tài khoản Admin nếu chưa có
            SeedAdminUser();
        }

        private void SeedAdminRole()
        {
            try
            {
                var adminRole = _vaiTroRepo.GetById("VT001");
                if (adminRole == null)
                {
                    // Nếu vai trò VT001 chưa tồn tại, tạo nó
                    _vaiTroRepo.Add(new VaiTro
                    {
                        MaVaiTro = "VT001",
                        TenVaiTro = "Quản trị viên",
                        MoTa = "Quản lý toàn bộ hệ thống"
                    });
                    Console.WriteLine("Đã tạo vai trò 'Quản trị viên' (VT001).");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi seed VaiTro: {ex.Message}");
            }
        }

        private void SeedAdminUser()
        {
            try
            {
                var adminAccount = _taiKhoanRepo.GetByTenDangNhap("admin");
                if (adminAccount == null)
                {
                    // Nếu tài khoản "admin" chưa tồn tại, tạo nó
                    var request = new CreateNhanVienRequest
                    {
                        // Thông tin NhanVien
                        HoTen = "Admin System",
                        ChucVu = "Quản trị viên",
                        Email = "admin@bagstore.com",
                        SoDienThoai = "0123456789",
                        TrangThaiNV = true, // Trạng thái NhanVien

                        // Thông tin TaiKhoan
                        TenDangNhap = "admin",
                        MatKhau = "123456", // NhanVienService sẽ TỰ ĐỘNG HASH mật khẩu này
                        MaVaiTro = "VT001", // Gán vai trò Quản trị viên
                        TrangThaiTK = true // Trạng thái TaiKhoan
                    };

                    _nhanVienService.CreateNhanVien(request);
                    Console.WriteLine("Đã tạo tài khoản 'admin' (mật khẩu 123456).");
                }
            }
            catch (Exception ex)
            {
                // Có thể lỗi nếu tên đăng nhập "admin" tồn tại
                // nhưng NhanVienService báo lỗi (ví dụ: MaNV đã tồn tại)
                Console.WriteLine($"Lỗi khi seed Admin: {ex.Message}");
            }
        }
    }
}
