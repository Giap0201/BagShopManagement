using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Implementations
{
    public class BaoCaoService : IBaoCaoService
    {
        private readonly IBaoCaoRepository _baoCaoRepo;

        public BaoCaoService(IBaoCaoRepository baoCaoRepo)
        {
            _baoCaoRepo = baoCaoRepo;
        }

        // ======================================================
        // 1️⃣ BÁO CÁO DOANH THU
        // ======================================================

        public DataTable LayBaoCaoDoanhThuTheoNgay(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                if (tuNgay.HasValue && denNgay.HasValue && tuNgay > denNgay)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc.");

                return _baoCaoRepo.GetBaoCaoDoanhThuTheoNgay(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo doanh thu theo ngày: {ex.Message}", ex);
            }
        }

        public DataTable LayBaoCaoDoanhThuTheoThang(int? nam = null)
        {
            try
            {
                if (nam.HasValue && (nam < 2000 || nam > DateTime.Now.Year + 1))
                    throw new ArgumentException("Năm không hợp lệ.");

                return _baoCaoRepo.GetBaoCaoDoanhThuTheoThang(nam);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo doanh thu theo tháng: {ex.Message}", ex);
            }
        }

        public DataTable LayBaoCaoDoanhThuTheoNam()
        {
            try
            {
                return _baoCaoRepo.GetBaoCaoDoanhThuTheoNam();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo doanh thu theo năm: {ex.Message}", ex);
            }
        }

        // ======================================================
        // 2️⃣ BÁO CÁO NHẬP HÀNG
        // ======================================================

        public DataTable LayBaoCaoNhapHang(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                if (tuNgay.HasValue && denNgay.HasValue && tuNgay > denNgay)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc.");

                return _baoCaoRepo.GetBaoCaoNhapHang(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo nhập hàng: {ex.Message}", ex);
            }
        }

        // ======================================================
        // 3️⃣ BÁO CÁO TỒN KHO
        // ======================================================

        public DataTable LayBaoCaoTonKho()
        {
            try
            {
                return _baoCaoRepo.GetBaoCaoTonKho();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo tồn kho: {ex.Message}", ex);
            }
        }

        // ======================================================
        // 4️⃣ BÁO CÁO DOANH THU THEO NHÂN VIÊN
        // ======================================================

        public DataTable LayBaoCaoDoanhThuTheoNhanVien(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                if (tuNgay.HasValue && denNgay.HasValue && tuNgay > denNgay)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc.");

                return _baoCaoRepo.GetBaoCaoDoanhThuTheoNhanVien(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo doanh thu theo nhân viên: {ex.Message}", ex);
            }
        }

        // ======================================================
        // 5️⃣ BÁO CÁO KHÁCH HÀNG THÂN THIẾT
        // ======================================================

        public DataTable LayBaoCaoKhachHangThanThiet(int? top = 10)
        {
            try
            {
                if (top <= 0)
                    throw new ArgumentException("Số lượng TOP phải lớn hơn 0.");

                return _baoCaoRepo.GetBaoCaoKhachHangThanThiet(top);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo khách hàng thân thiết: {ex.Message}", ex);
            }
        }

        // ======================================================
        // 6️⃣ BÁO CÁO SẢN PHẨM BÁN CHẠY
        // ======================================================

        public DataTable LayBaoCaoSanPhamBanChay(int? top = 10, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                if (top <= 0)
                    throw new ArgumentException("Số lượng TOP phải lớn hơn 0.");
                if (tuNgay.HasValue && denNgay.HasValue && tuNgay > denNgay)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc.");

                return _baoCaoRepo.GetSanPhamBanChay(top, tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo sản phẩm bán chạy: {ex.Message}", ex);
            }
        }

        // ======================================================
        // 7️⃣ BÁO CÁO CHƯƠNG TRÌNH GIẢM GIÁ
        // ======================================================

        public DataTable LayBaoCaoChuongTrinhGiamGia()
        {
            try
            {
                return _baoCaoRepo.GetBaoCaoChuongTrinhGiamGia();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo chương trình giảm giá: {ex.Message}", ex);
            }
        }
    }
}