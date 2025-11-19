using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Models.Enums; // Thêm
using BagShopManagement.Services.Interfaces;

namespace BagShopManagement.Controllers
{
    public class HoaDonNhapController
    {
        private readonly IHoaDonNhapService _hoaDonNhapService;

        public HoaDonNhapController(IHoaDonNhapService hoaDonNhapService)
        {
            _hoaDonNhapService = hoaDonNhapService;
        }

        #region TRUY VAN

        public List<HoaDonNhapResponse> LayDanhSachHoaDon()
        {
            return _hoaDonNhapService.GetAllHoaDonNhap();
        }

        public HoaDonNhapResponse LayChiTietHoaDon(string maHDN)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hóa đơn không được rỗng.");
            return _hoaDonNhapService.GetHoaDonNhapDetail(maHDN);
        }

        public List<HoaDonNhapResponse> TimKiemHoaDon(string maHDN, DateTime? tuNgay, DateTime? denNgay, string? maNCC, string? maNV, TrangThaiHoaDonNhap? trangThai)
        {
            return _hoaDonNhapService.Search(maHDN, tuNgay, denNgay, maNCC, maNV, trangThai);
        }

        public List<HoaDonNhap> GetAll()
        {
            return _hoaDonNhapService.GetAll();
        }

        #endregion TRUY VAN

        #region === NGHIỆP VỤ CHÍNH  ===

        // Tao hoa don moi o trang thai tam luu
        public string TaoMoiHoaDon(HoaDonNhapRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dữ liệu tạo hóa đơn rỗng.");
            return _hoaDonNhapService.CreateDraftHoaDonNhap(request);
        }

        // duyet hoa don, cap nhat trang thai hoa don, ton kho, gia nhap moi
        public void DuyetHoaDon(string maHDN)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hóa đơn không được rỗng.");

            _hoaDonNhapService.ApproveHoaDonNhap(maHDN);
        }

        // Yeu cau huy hoa don
        public void HuyHoaDon(string maHDN)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hóa đơn không được rỗng.");
            _hoaDonNhapService.CancelHoaDonNhap(maHDN);
        }

        // cap nhap thong tin chung cua hoa don
        public void CapNhatThongTinHoaDon(string maHDN, HoaDonNhapInfoUpdateRequest request)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hóa đơn không được rỗng.");
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dữ liệu cập nhật rỗng.");
            _hoaDonNhapService.UpdateDraftInfo(maHDN, request);
        }

        #endregion === NGHIỆP VỤ CHÍNH  ===

        #region === NGHIỆP VỤ SỬA CHI TIẾT (KHI TẠM LƯU) ===

        public void ThemChiTiet(string maHDN, ChiTietHDNRequest chiTietRequest)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hóa đơn không được rỗng.");
            if (chiTietRequest == null)
                throw new ArgumentNullException(nameof(chiTietRequest));

            _hoaDonNhapService.AddDetailToDraft(maHDN, chiTietRequest);
        }

        // sua so luong, don gia khi tam luu
        public void SuaChiTiet(string maHDN, string maSP, ChiTietHDNRequest chiTietRequest)
        {
            if (string.IsNullOrWhiteSpace(maHDN) || string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Mã hóa đơn hoặc Mã sản phẩm không được rỗng.");
            if (chiTietRequest == null)
                throw new ArgumentNullException(nameof(chiTietRequest));

            _hoaDonNhapService.UpdateDetailInDraft(maHDN, maSP, chiTietRequest);
        }

        // Xoa san pham khoi chi tiet hoa don khi tam luu
        public void XoaChiTiet(string maHDN, string maSP)
        {
            if (string.IsNullOrWhiteSpace(maHDN) || string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Mã hóa đơn hoặc Mã sản phẩm không được rỗng.");

            _hoaDonNhapService.DeleteDetailFromDraft(maHDN, maSP);
        }

        #endregion === NGHIỆP VỤ SỬA CHI TIẾT (KHI TẠM LƯU) ===
    }
}