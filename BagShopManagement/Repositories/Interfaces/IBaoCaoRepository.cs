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
        // 1️⃣ Báo cáo doanh thu theo ngày / tháng / năm
        DataTable GetBaoCaoDoanhThuTheoNgay(DateTime? tuNgay = null, DateTime? denNgay = null);

        DataTable GetBaoCaoDoanhThuTheoThang(int? nam = null);

        DataTable GetBaoCaoDoanhThuTheoNam();

        // 2️⃣ Báo cáo nhập hàng
        DataTable GetBaoCaoNhapHang(DateTime? tuNgay = null, DateTime? denNgay = null);

        // 3️⃣ Báo cáo tồn kho hiện tại
        DataTable GetBaoCaoTonKho();

        // 4️⃣ Báo cáo doanh thu theo nhân viên
        DataTable GetBaoCaoDoanhThuTheoNhanVien(DateTime? tuNgay = null, DateTime? denNgay = null);

        // 5️⃣ Báo cáo khách hàng thân thiết
        DataTable GetBaoCaoKhachHangThanThiet(int? top = 10);

        // 6️⃣ Báo cáo sản phẩm bán chạy
        DataTable GetSanPhamBanChay(int? top = 10, DateTime? tuNgay = null, DateTime? denNgay = null);

        // 7️⃣ Báo cáo chương trình giảm giá
        DataTable GetBaoCaoChuongTrinhGiamGia();
    }
}