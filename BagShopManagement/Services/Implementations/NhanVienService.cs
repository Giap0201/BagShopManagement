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
        // IVaiTroRepository không cần thiết ở đây vì NhanVienImpl đã JOIN sẵn

        private readonly string _connectionString;

        public NhanVienService(
            INhanVienRepository nhanVienRepo,
            ITaiKhoanRepository taiKhoanRepo)
        {
            _nhanVienRepo = nhanVienRepo;
            _taiKhoanRepo = taiKhoanRepo;
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Lấy danh sách nhân viên (đã JOIN) để hiển thị.
        /// </summary>
        public IEnumerable<NhanVienResponse> GetAllNhanVien()
        {
            // Đã tối ưu ở NhanVienImpl, chỉ cần gọi 1 phương thức
            return _nhanVienRepo.GetAllForDisplay();
        }

        /// <summary>
        /// [TRANSACTION] Tạo mới Nhân viên và Tài khoản.
        /// </summary>
        public bool CreateNhanVien(CreateNhanVienRequest request)
        {
            // 1. Kiểm tra nghiệp vụ
            if (_taiKhoanRepo.ExistsByTenDangNhap(request.TenDangNhap))
            {
                throw new Exception($"Tên đăng nhập '{request.TenDangNhap}' đã tồn tại.");
            }

            // 2. Chuẩn bị dữ liệu
            string maNV = _nhanVienRepo.GetNextMaNV(); // Lấy mã NV mới
            string hashedPassword = PasswordHasher.Hash(request.MatKhau); // Băm mật khẩu

            var nhanVien = new NhanVien
            {
                MaNV = maNV,
                HoTen = request.HoTen,
                ChucVu = request.ChucVu,
                SoDienThoai = request.SoDienThoai,
                Email = request.Email,
                NgayVaoLam = DateTime.Now,
                TrangThai = request.TrangThaiNV
            };

            var taiKhoan = new TaiKhoan
            {
                TenDangNhap = request.TenDangNhap,
                MatKhau = hashedPassword,
                MaNV = maNV,
                MaVaiTro = request.MaVaiTro,
                TrangThai = request.TrangThaiTK
            };

            // 3. Quản lý Transaction
            // Service sẽ tự mở connection và tạo transaction
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Truyền conn và tran xuống Repository
                        _nhanVienRepo.Add(nhanVien, conn, tran);
                        _taiKhoanRepo.Add(taiKhoan, conn, tran);

                        // Nếu cả 2 thành công
                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Nếu 1 trong 2 lỗi, hủy bỏ tất cả
                        tran.Rollback();
                        // Ném lỗi ra ngoài để Controller xử lý
                        throw new Exception("Tạo nhân viên thất bại. Dữ liệu đã được hoàn tác. Lỗi: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// [TRANSACTION] Cập nhật Nhân viên và Tài khoản.
        /// </summary>
        public bool UpdateNhanVien(UpdateNhanVienRequest request)
        {
            // 1. Chuẩn bị dữ liệu
            var nhanVien = new NhanVien
            {
                MaNV = request.MaNV,
                HoTen = request.HoTen,
                ChucVu = request.ChucVu,
                SoDienThoai = request.SoDienThoai,
                Email = request.Email,
                TrangThai = request.TrangThaiNV
                // NgayVaoLam không cập nhật
            };

            // Lấy Tên đăng nhập từ MaNV để cập nhật đúng TaiKhoan
            var existingTaiKhoan = _taiKhoanRepo.GetByMaNV(request.MaNV);
            if (existingTaiKhoan == null)
            {
                throw new Exception($"Lỗi dữ liệu: Không tìm thấy tài khoản cho Mã NV {request.MaNV}");
            }

            var taiKhoan = new TaiKhoan
            {
                TenDangNhap = existingTaiKhoan.TenDangNhap, // Key để update
                MaVaiTro = request.MaVaiTro,
                TrangThai = request.TrangThaiTK
                // MatKhau và MaNV không cập nhật ở đây
            };

            // 2. Quản lý Transaction
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Truyền conn và tran xuống Repository
                        _nhanVienRepo.Update(nhanVien, conn, tran);
                        _taiKhoanRepo.Update(taiKhoan, conn, tran); // Update TaiKhoan bằng TenDangNhap

                        // Nếu cả 2 thành công
                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Nếu 1 trong 2 lỗi, hủy bỏ tất cả
                        tran.Rollback();
                        throw new Exception("Cập nhật nhân viên thất bại. Dữ liệu đã được hoàn tác. Lỗi: " + ex.Message);
                    }
                }
            }
        }
        public IEnumerable<NhanVienResponse> SearchNhanVien(string keyword)
        {
            // Nếu người dùng không nhập gì (hoặc xóa hết) và bấm tìm
            // thì trả về toàn bộ danh sách
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllNhanVien();
            }

            // Thêm ký tự '%' để tìm kiếm (LIKE %keyword%)
            string formattedKeyword = $"%{keyword.Trim()}%";

            return _nhanVienRepo.Search(formattedKeyword);
        }
    }
}
