using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace BagShopManagement.Repositories.Implementations
{
    public class BaoCaoRepository : BaseRepository, IBaoCaoRepository
    {
        public DataTable GetBaoCaoDoanhThuTheoNgay(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            DateTime fromDate = tuNgay?.Date ?? DateTime.Today;
            DateTime toDate = denNgay?.Date ?? DateTime.Today;

            string sql = @"
                SELECT
                    CAST(NgayBan AS date) AS NgayBan,
                    COUNT(MaHDB) AS SoHoaDon,
                    SUM(TongTien) AS TongDoanhThu
                FROM HoaDonBan
                WHERE TrangThaiHD = 2
                  AND NgayBan >= @TuNgay
                  AND NgayBan < DATEADD(DAY, 1, @DenNgay)
                GROUP BY CAST(NgayBan AS date)
                ORDER BY CAST(NgayBan AS date);";

            var parameters = new[]
            {
                new SqlParameter("@TuNgay", fromDate),
                new SqlParameter("@DenNgay", toDate)
            };

            return ExecuteQuery(sql, parameters);
        }

        public DataTable GetBaoCaoDoanhThuTheoThang(int? nam = null)
        {
            string sql = @"
                SELECT
                    YEAR(NgayBan) AS Nam,
                    MONTH(NgayBan) AS Thang,
                    COUNT(MaHDB) AS SoHoaDon,
                    SUM(TongTien) AS TongDoanhThu
                FROM HoaDonBan
                WHERE TrangThaiHD = 2
                  AND (@Nam IS NULL OR YEAR(NgayBan) = @Nam)
                GROUP BY YEAR(NgayBan), MONTH(NgayBan)
                ORDER BY YEAR(NgayBan), MONTH(NgayBan);";

            return ExecuteQuery(sql, new SqlParameter("@Nam", (object?)nam ?? DBNull.Value));
        }

        public DataTable GetBaoCaoDoanhThuTheoNam()
        {
            string sql = @"
                SELECT
                    YEAR(NgayBan) AS Nam,
                    COUNT(MaHDB) AS SoHoaDon,
                    SUM(TongTien) AS TongDoanhThu
                FROM HoaDonBan
                WHERE TrangThaiHD = 2
                GROUP BY YEAR(NgayBan)
                ORDER BY YEAR(NgayBan);";

            return ExecuteQuery(sql);
        }

        public DataTable GetBaoCaoNhapHang(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            DateTime fromDate = tuNgay?.Date ?? DateTime.Today;
            DateTime toDate = denNgay?.Date ?? DateTime.Today;

            string sql = @"
                SELECT
                    CAST(NgayNhap AS date) AS NgayNhap,
                    COUNT(MaHDN) AS SoPhieuNhap,
                    SUM(TongTien) AS TongTienNhap
                FROM HoaDonNhap
                WHERE NgayNhap >= @TuNgay
                  AND NgayNhap < DATEADD(DAY, 1, @DenNgay)
                GROUP BY CAST(NgayNhap AS date)
                ORDER BY CAST(NgayNhap AS date);";

            var parameters = new[]
            {
                new SqlParameter("@TuNgay", fromDate),
                new SqlParameter("@DenNgay", toDate)
            };

            return ExecuteQuery(sql, parameters);
        }

        public DataTable GetBaoCaoTonKho()
        {
            string sql = @"
                SELECT
                    sp.MaSP,
                    sp.TenSP,
                    sp.GiaNhap,
                    sp.GiaBan,
                    sp.SoLuongTon,
                    (sp.SoLuongTon * sp.GiaNhap) AS GiaTriTonKho,
                    th.TenThuongHieu,
                    ncc.TenNCC
                FROM SanPham sp
                LEFT JOIN ThuongHieu th ON sp.MaThuongHieu = th.MaThuongHieu
                LEFT JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC
                WHERE sp.TrangThai = 1
                ORDER BY sp.SoLuongTon DESC;";

            return ExecuteQuery(sql);
        }

        public DataTable GetBaoCaoDoanhThuTheoNhanVien(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            DateTime fromDate = tuNgay?.Date ?? DateTime.Today;
            DateTime toDate = denNgay?.Date ?? DateTime.Today;

            string sql = @"
                SELECT
                    nv.MaNV,
                    nv.HoTen AS TenNhanVien,
                    COUNT(hdb.MaHDB) AS SoHoaDon,
                    SUM(hdb.TongTien) AS TongDoanhThu
                FROM HoaDonBan hdb
                INNER JOIN NhanVien nv ON hdb.MaNV = nv.MaNV
                WHERE hdb.TrangThaiHD = 2
                  AND hdb.NgayBan >= @TuNgay
                  AND hdb.NgayBan < DATEADD(DAY, 1, @DenNgay)
                GROUP BY nv.MaNV, nv.HoTen
                ORDER BY TongDoanhThu DESC;";

            var parameters = new[]
            {
                new SqlParameter("@TuNgay", fromDate),
                new SqlParameter("@DenNgay", toDate)
            };

            return ExecuteQuery(sql, parameters);
        }

        public DataTable GetBaoCaoKhachHangThanThiet(int? top = 10)
        {
            string sql = @"
                SELECT TOP (@Top)
                    kh.MaKH,
                    kh.HoTen AS TenKhachHang,
                    COUNT(hdb.MaHDB) AS SoLanMua,
                    SUM(hdb.TongTien) AS TongChiTieu
                FROM HoaDonBan hdb
                INNER JOIN KhachHang kh ON hdb.MaKH = kh.MaKH
                WHERE hdb.TrangThaiHD = 2
                GROUP BY kh.MaKH, kh.HoTen
                ORDER BY TongChiTieu DESC;";

            return ExecuteQuery(sql, new SqlParameter("@Top", (object?)top ?? 10));
        }

        public DataTable GetSanPhamBanChay(int? top = 10, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            DateTime fromDate = tuNgay?.Date ?? DateTime.Today;
            DateTime toDate = denNgay?.Date ?? DateTime.Today;

            string sql = @"
                SELECT TOP (@Top)
                    sp.MaSP,
                    sp.TenSP,
                    SUM(ct.SoLuong) AS TongSoLuongBan,
                    SUM(ct.SoLuong * ct.DonGia) AS TongDoanhThu,
                    th.TenThuongHieu
                FROM ChiTietHoaDonBan ct
                INNER JOIN HoaDonBan hdb ON ct.MaHDB = hdb.MaHDB
                INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                LEFT JOIN ThuongHieu th ON sp.MaThuongHieu = th.MaThuongHieu
                WHERE hdb.TrangThaiHD = 2
                  AND hdb.NgayBan >= @TuNgay
                  AND hdb.NgayBan < DATEADD(DAY, 1, @DenNgay)
                GROUP BY sp.MaSP, sp.TenSP, th.TenThuongHieu
                ORDER BY TongSoLuongBan DESC;";

            var parameters = new[]
            {
                new SqlParameter("@Top", (object?)top ?? 10),
                new SqlParameter("@TuNgay", fromDate),
                new SqlParameter("@DenNgay", toDate)
            };

            return ExecuteQuery(sql, parameters);
        }

        public DataTable GetBaoCaoChuongTrinhGiamGia()
        {
            string sql = @"
                SELECT
                    ct.MaCTGG,
                    ct.TenChuongTrinh,
                    CAST(ct.NgayBatDau AS date) AS NgayBatDau,
                    CAST(ct.NgayKetThuc AS date) AS NgayKetThuc,
                    COUNT(ctg.MaSP) AS SoSanPhamApDung,
                    AVG(ctg.PhanTramGiam) AS MucGiamTrungBinh,
                    CASE
                        WHEN ct.TrangThai = 1 THEN N'Đang áp dụng'
                        ELSE N'Hết hạn'
                    END AS TrangThai
                FROM ChuongTrinhGiamGia ct
                LEFT JOIN ChiTietGiamGia ctg ON ct.MaCTGG = ctg.MaCTGG
                GROUP BY ct.MaCTGG, ct.TenChuongTrinh, ct.NgayBatDau, ct.NgayKetThuc, ct.TrangThai
                ORDER BY ct.NgayBatDau DESC;";

            return ExecuteQuery(sql);
        }
    }
}