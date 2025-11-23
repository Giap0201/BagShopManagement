using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Implementations
{
    public class NhanVienService : INhanVienService
    {
        private readonly INhanVienRepository _nhanVienRepo;
        private readonly ITaiKhoanRepository _taiKhoanRepo;

        public NhanVienService(
            INhanVienRepository nhanVienRepo,
            ITaiKhoanRepository taiKhoanRepo)
        {
            _nhanVienRepo = nhanVienRepo;
            _taiKhoanRepo = taiKhoanRepo;
        }

        public List<NhanVienResponse> GetAllNhanVien()
        {
            // Repository đã trả về List<NhanVienResponse>, không cần cast
            return _nhanVienRepo.GetAllForDisplay();
        }

        public bool CreateNhanVien(CreateNhanVienRequest request)
        {
            // 1. Validate nghiệp vụ
            if (_taiKhoanRepo.ExistsByTenDangNhap(request.TenDangNhap))
            {
                throw new Exception($"Tên đăng nhập '{request.TenDangNhap}' đã tồn tại.");
            }

            // 2. Chuẩn bị dữ liệu
            string maNV = _nhanVienRepo.GetNextMaNV();
            string hashedPassword = PasswordHasher.Hash(request.MatKhau);

            var nhanVien = new NhanVien
            {
                MaNV = maNV,
                HoTen = request.HoTen,
                ChucVu = request.ChucVu,
                SoDienThoai = request.SoDienThoai,
                Email = request.Email,
                NgayVaoLam = DateTime.Now,
            };

            var taiKhoan = new TaiKhoan
            {
                TenDangNhap = request.TenDangNhap,
                MatKhau = hashedPassword,
                MaNV = maNV,
                MaVaiTro = request.MaVaiTro,
                TrangThai = request.TrangThaiTK
            };

            try
            {
                // 3. Gọi Repository (Tuần tự, không Transaction thủ công)
                _nhanVienRepo.Add(nhanVien);
                _taiKhoanRepo.Add(taiKhoan);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Tạo nhân viên thất bại: " + ex.Message);
            }
        }

        public bool UpdateNhanVien(UpdateNhanVienRequest request)
        {
            // 1. Tìm tài khoản cũ để lấy TenDangNhap
            var existingTaiKhoan = _taiKhoanRepo.GetByMaNV(request.MaNV);
            if (existingTaiKhoan == null)
            {
                throw new Exception($"Lỗi dữ liệu: Không tìm thấy tài khoản cho Mã NV {request.MaNV}");
            }

            // 2. Chuẩn bị dữ liệu update
            var nhanVien = new NhanVien
            {
                MaNV = request.MaNV,
                HoTen = request.HoTen,
                ChucVu = request.ChucVu,
                SoDienThoai = request.SoDienThoai,
                Email = request.Email
            };

            var taiKhoan = new TaiKhoan
            {
                TenDangNhap = existingTaiKhoan.TenDangNhap, // Key để update
                MaVaiTro = request.MaVaiTro,
                TrangThai = request.TrangThaiTK,
                MaNV = request.MaNV
            };

            try
            {
                // 3. Gọi Repository cập nhật
                _nhanVienRepo.Update(nhanVien);
                _taiKhoanRepo.Update(taiKhoan);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Cập nhật nhân viên thất bại: " + ex.Message);
            }
        }

        public List<NhanVienResponse> SearchNhanVien(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllNhanVien();
            }

            string formattedKeyword = $"%{keyword.Trim()}%";
            return _nhanVienRepo.Search(formattedKeyword);
        }
    }
}
