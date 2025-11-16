using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IBaoCaoService
    {
        // Doanh thu
        DataTable LayBaoCaoDoanhThuTheoNgay(DateTime? tuNgay = null, DateTime? denNgay = null);

        DataTable LayBaoCaoDoanhThuTheoThang(int? nam = null);

        DataTable LayBaoCaoDoanhThuTheoNam();

        // Nhap hang
        DataTable LayBaoCaoNhapHang(DateTime? tuNgay = null, DateTime? denNgay = null);

        // Ton Kho
        DataTable LayBaoCaoTonKho();

        // Nhan vien
        DataTable LayBaoCaoDoanhThuTheoNhanVien(DateTime? tuNgay = null, DateTime? denNgay = null);

        // Khach hang
        DataTable LayBaoCaoKhachHangThanThiet(int? top = 10);

        // San pham ban chay
        DataTable LayBaoCaoSanPhamBanChay(int? top = 10, DateTime? tuNgay = null, DateTime? denNgay = null);

        // Chuong trinh giam gia
        DataTable LayBaoCaoChuongTrinhGiamGia();
    }
}