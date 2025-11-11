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
        // 1️⃣ Doanh thu
        DataTable LayBaoCaoDoanhThuTheoNgay(DateTime? tuNgay = null, DateTime? denNgay = null);

        DataTable LayBaoCaoDoanhThuTheoThang(int? nam = null);

        DataTable LayBaoCaoDoanhThuTheoNam();

        // 2️⃣ Nhập hàng
        DataTable LayBaoCaoNhapHang(DateTime? tuNgay = null, DateTime? denNgay = null);

        // 3️⃣ Tồn kho
        DataTable LayBaoCaoTonKho();

        // 4️⃣ Nhân viên
        DataTable LayBaoCaoDoanhThuTheoNhanVien(DateTime? tuNgay = null, DateTime? denNgay = null);

        // 5️⃣ Khách hàng thân thiết
        DataTable LayBaoCaoKhachHangThanThiet(int? top = 10);

        // 6️⃣ Sản phẩm bán chạy
        DataTable LayBaoCaoSanPhamBanChay(int? top = 10, DateTime? tuNgay = null, DateTime? denNgay = null);

        // 7️⃣ Chương trình giảm giá
        DataTable LayBaoCaoChuongTrinhGiamGia();
    }
}