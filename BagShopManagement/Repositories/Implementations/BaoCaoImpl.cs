using BagShopManagement.DataAccess;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Implementations
{
    public class BaoCaoImpl : BaseRepository, IBaoCaoRepository
    {
        private readonly string _connectionString;

        // ======================================================
        // 1️⃣ BÁO CÁO DOANH THU
        // ======================================================

        public DataTable GetBaoCaoDoanhThuTheoNgay(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            string sql = @"
                SELECT
                    CONVERT(VARCHAR(10), NgayBan, 103) AS NgayLap,
                    COUNT(MaHDB) AS SoHoaDon,
                    SUM(TongTien) AS TongDoanhThu
                FROM HoaDonBan
                WHERE TrangThaiHD = 1
                  AND (@TuNgay IS NULL OR NgayBan >= @TuNgay)
                  AND (@DenNgay IS NULL OR NgayBan <= @DenNgay)
                GROUP BY CONVERT(VARCHAR(10), NgayBan, 103)
                ORDER BY MIN(NgayBan)";

            var parameters = new[]
            {
                new SqlParameter("@TuNgay", (object?)tuNgay ?? DBNull.Value),
                new SqlParameter("@DenNgay", (object?)denNgay ?? DBNull.Value)
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
                WHERE TrangThaiHD = 1
                  AND (@Nam IS NULL OR YEAR(NgayBan) = @Nam)
                GROUP BY YEAR(NgayBan), MONTH(NgayBan)
                ORDER BY YEAR(NgayBan), MONTH(NgayBan)";

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
                WHERE TrangThaiHD = 1
                GROUP BY YEAR(NgayBan)
                ORDER BY YEAR(NgayBan)";
            return ExecuteQuery(sql);
        }

        // ======================================================
        // 2️⃣ BÁO CÁO NHẬP HÀNG
        // ======================================================

        public DataTable GetBaoCaoNhapHang(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            string sql = @"
                SELECT
                    CONVERT(VARCHAR(10), NgayNhap, 103) AS NgayNhap,
                    COUNT(MaHDN) AS SoPhieuNhap,
                    SUM(TongTien) AS TongTienNhap
                FROM HoaDonNhap
                WHERE (@TuNgay IS NULL OR NgayNhap >= @TuNgay)
                  AND (@DenNgay IS NULL OR NgayNhap <= @DenNgay)
                GROUP BY CONVERT(VARCHAR(10), NgayNhap, 103)
                ORDER BY MIN(NgayNhap)";

            var parameters = new[]
            {
                new SqlParameter("@TuNgay", (object?)tuNgay ?? DBNull.Value),
                new SqlParameter("@DenNgay", (object?)denNgay ?? DBNull.Value)
            };

            return ExecuteQuery(sql, parameters);
        }

        // ======================================================
        // 3️⃣ BÁO CÁO TỒN KHO
        // ======================================================

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
                ORDER BY sp.SoLuongTon DESC";
            return ExecuteQuery(sql);
        }

        // ======================================================
        // 4️⃣ BÁO CÁO DOANH THU THEO NHÂN VIÊN
        // ======================================================

        public DataTable GetBaoCaoDoanhThuTheoNhanVien(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            string sql = @"
                SELECT
                    nv.MaNV,
                    nv.HoTen AS TenNhanVien,
                    COUNT(hdb.MaHDB) AS SoHoaDon,
                    SUM(hdb.TongTien) AS TongDoanhThu
                FROM HoaDonBan hdb
                INNER JOIN NhanVien nv ON hdb.MaNV = nv.MaNV
                WHERE hdb.TrangThaiHD = 1
                  AND (@TuNgay IS NULL OR hdb.NgayBan >= @TuNgay)
                  AND (@DenNgay IS NULL OR hdb.NgayBan <= @DenNgay)
                GROUP BY nv.MaNV, nv.HoTen
                ORDER BY TongDoanhThu DESC";
            var parameters = new[]
            {
                new SqlParameter("@TuNgay", (object?)tuNgay ?? DBNull.Value),
                new SqlParameter("@DenNgay", (object?)denNgay ?? DBNull.Value)
            };
            return ExecuteQuery(sql, parameters);
        }

        // ======================================================
        // 5️⃣ BÁO CÁO KHÁCH HÀNG THÂN THIẾT
        // ======================================================

        public DataTable GetBaoCaoKhachHangThanThiet(int? top = 10)
        {
            string sql = $@"
                SELECT TOP (@Top)
                    kh.MaKH,
                    kh.HoTen AS TenKhachHang,
                    COUNT(hdb.MaHDB) AS SoLanMua,
                    SUM(hdb.TongTien) AS TongChiTieu
                FROM HoaDonBan hdb
                INNER JOIN KhachHang kh ON hdb.MaKH = kh.MaKH
                WHERE hdb.TrangThaiHD = 1
                GROUP BY kh.MaKH, kh.HoTen
                ORDER BY TongChiTieu DESC";
            return ExecuteQuery(sql, new SqlParameter("@Top", (object?)top ?? 10));
        }

        // ======================================================
        // 6️⃣ BÁO CÁO SẢN PHẨM BÁN CHẠY
        // ======================================================

        public DataTable GetSanPhamBanChay(int? top = 10, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
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
                WHERE hdb.TrangThaiHD = 1
                  AND (@TuNgay IS NULL OR hdb.NgayBan >= @TuNgay)
                  AND (@DenNgay IS NULL OR hdb.NgayBan <= @DenNgay)
                GROUP BY sp.MaSP, sp.TenSP, th.TenThuongHieu
                ORDER BY TongSoLuongBan DESC";

            var parameters = new[]
            {
                new SqlParameter("@Top", (object?)top ?? 10),
                new SqlParameter("@TuNgay", (object?)tuNgay ?? DBNull.Value),
                new SqlParameter("@DenNgay", (object?)denNgay ?? DBNull.Value)
            };
            return ExecuteQuery(sql, parameters);
        }

        // ======================================================
        // 7️⃣ BÁO CÁO CHƯƠNG TRÌNH GIẢM GIÁ
        // ======================================================

        public DataTable GetBaoCaoChuongTrinhGiamGia()
        {
            string sql = @"
                SELECT
                    ct.MaCTGG,
                    ct.TenChuongTrinh,
                    CONVERT(VARCHAR(10), ct.NgayBatDau, 103) AS NgayBatDau,
                    CONVERT(VARCHAR(10), ct.NgayKetThuc, 103) AS NgayKetThuc,
                    COUNT(ctg.MaSP) AS SoSanPhamApDung,
                    AVG(ctg.PhanTramGiam) AS MucGiamTrungBinh,
                    CASE
                        WHEN ct.TrangThai = 1 THEN N'Đang áp dụng'
                        ELSE N'Hết hạn'
                    END AS TrangThai
                FROM ChuongTrinhGiamGia ct
                LEFT JOIN ChiTietGiamGia ctg ON ct.MaCTGG = ctg.MaCTGG
                GROUP BY ct.MaCTGG, ct.TenChuongTrinh, ct.NgayBatDau, ct.NgayKetThuc, ct.TrangThai
                ORDER BY ct.NgayBatDau DESC";
            return ExecuteQuery(sql);
        }
    }
}