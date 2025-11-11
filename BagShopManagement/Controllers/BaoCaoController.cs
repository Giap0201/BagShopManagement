using System;
using System.Data;
using BagShopManagement.Services.Interfaces;

namespace BagShopManagement.Controllers
{
    /// <summary>
    /// Controller phụ trách điều phối luồng xử lý cho phần Báo cáo & Thống kê.
    /// </summary>
    public class BaoCaoController
    {
        private readonly IBaoCaoService _baoCaoService;

        public BaoCaoController(IBaoCaoService baoCaoService)
        {
            _baoCaoService = baoCaoService;
        }

        #region === BÁO CÁO DOANH THU ===

        /// <summary>
        /// Báo cáo doanh thu theo ngày, có thể lọc theo khoảng thời gian.
        /// </summary>
        public DataTable LayBaoCaoDoanhThuTheoNgay(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                return _baoCaoService.LayBaoCaoDoanhThuTheoNgay(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo doanh thu theo ngày: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Báo cáo doanh thu theo tháng trong 1 năm cụ thể.
        /// </summary>
        public DataTable LayBaoCaoDoanhThuTheoThang(int? nam = null)
        {
            try
            {
                return _baoCaoService.LayBaoCaoDoanhThuTheoThang(nam);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo doanh thu theo tháng: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Báo cáo doanh thu theo từng năm (tổng hợp).
        /// </summary>
        public DataTable LayBaoCaoDoanhThuTheoNam()
        {
            try
            {
                return _baoCaoService.LayBaoCaoDoanhThuTheoNam();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo doanh thu theo năm: {ex.Message}", ex);
            }
        }

        #endregion === BÁO CÁO DOANH THU ===

        #region === BÁO CÁO NHẬP HÀNG ===

        /// <summary>
        /// Báo cáo tiền nhập hàng trong khoảng thời gian cụ thể.
        /// </summary>
        public DataTable LayBaoCaoNhapHang(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                return _baoCaoService.LayBaoCaoNhapHang(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo nhập hàng: {ex.Message}", ex);
            }
        }

        #endregion === BÁO CÁO NHẬP HÀNG ===

        #region === BÁO CÁO TỒN KHO ===

        /// <summary>
        /// Báo cáo hàng tồn kho hiện tại (dựa trên SoLuongTon trong bảng SanPham).
        /// </summary>
        public DataTable LayBaoCaoTonKho()
        {
            try
            {
                return _baoCaoService.LayBaoCaoTonKho();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo tồn kho: {ex.Message}", ex);
            }
        }

        #endregion === BÁO CÁO TỒN KHO ===

        #region === BÁO CÁO THEO NHÂN VIÊN ===

        /// <summary>
        /// Báo cáo doanh thu theo nhân viên bán hàng (lọc theo thời gian).
        /// </summary>
        public DataTable LayBaoCaoDoanhThuTheoNhanVien(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                return _baoCaoService.LayBaoCaoDoanhThuTheoNhanVien(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo doanh thu theo nhân viên: {ex.Message}", ex);
            }
        }

        #endregion === BÁO CÁO THEO NHÂN VIÊN ===

        #region === BÁO CÁO KHÁCH HÀNG ===

        /// <summary>
        /// Báo cáo top khách hàng thân thiết (TOP N khách chi tiêu cao nhất).
        /// </summary>
        public DataTable LayBaoCaoKhachHangThanThiet(int? top = 10)
        {
            try
            {
                return _baoCaoService.LayBaoCaoKhachHangThanThiet(top);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo khách hàng thân thiết: {ex.Message}", ex);
            }
        }

        #endregion === BÁO CÁO KHÁCH HÀNG ===

        #region === BÁO CÁO SẢN PHẨM ===

        /// <summary>
        /// Báo cáo top sản phẩm bán chạy (TOP N sản phẩm có doanh thu hoặc số lượng cao nhất).
        /// </summary>
        public DataTable LayBaoCaoSanPhamBanChay(int? top = 10, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                return _baoCaoService.LayBaoCaoSanPhamBanChay(top, tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo sản phẩm bán chạy: {ex.Message}", ex);
            }
        }

        #endregion === BÁO CÁO SẢN PHẨM ===

        #region === BÁO CÁO CHƯƠNG TRÌNH GIẢM GIÁ ===

        /// <summary>
        /// Báo cáo các chương trình giảm giá đang và đã áp dụng.
        /// </summary>
        public DataTable LayBaoCaoChuongTrinhGiamGia()
        {
            try
            {
                return _baoCaoService.LayBaoCaoChuongTrinhGiamGia();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi khi lấy báo cáo chương trình giảm giá: {ex.Message}", ex);
            }
        }

        #endregion === BÁO CÁO CHƯƠNG TRÌNH GIẢM GIÁ ===
    }
}