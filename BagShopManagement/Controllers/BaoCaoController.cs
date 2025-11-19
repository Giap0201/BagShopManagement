using System;
using System.Data;
using BagShopManagement.Services.Interfaces;

namespace BagShopManagement.Controllers
{
    public class BaoCaoController
    {
        private readonly IBaoCaoService _baoCaoService;

        public BaoCaoController(IBaoCaoService baoCaoService)
        {
            _baoCaoService = baoCaoService;
        }

        #region === BÁO CÁO DOANH THU ===

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

        // Bao cao nhap hang
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

        // Bao cao ton kho hien tai
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

        // Bao cao doanh thu theo nhan vien
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

        //Bao cao khach hang
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

        //San pham ban chay nhat
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

        // chuong trinh giam gia
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