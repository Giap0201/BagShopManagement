using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IBaoCaoRepository
    {
        // Bao cao doanh thu
        DataTable GetBaoCaoDoanhThuTheoNgay(DateTime? tuNgay = null, DateTime? denNgay = null);

        DataTable GetBaoCaoDoanhThuTheoThang(int? nam = null);

        DataTable GetBaoCaoDoanhThuTheoNam();

        // Bao cao nhap hang
        DataTable GetBaoCaoNhapHang(DateTime? tuNgay = null, DateTime? denNgay = null);

        // Bao cao ton kho
        DataTable GetBaoCaoTonKho();

        // Bao cao doanh thu theo nhan vien
        DataTable GetBaoCaoDoanhThuTheoNhanVien(DateTime? tuNgay = null, DateTime? denNgay = null);

        // Bao cao khach hang than thiet
        DataTable GetBaoCaoKhachHangThanThiet(int? top = 10);

        // Bao cao san pham ban chay
        DataTable GetSanPhamBanChay(int? top = 10, DateTime? tuNgay = null, DateTime? denNgay = null);

        // Bao cao chuong trinh giam gia
        DataTable GetBaoCaoChuongTrinhGiamGia();
    }
}