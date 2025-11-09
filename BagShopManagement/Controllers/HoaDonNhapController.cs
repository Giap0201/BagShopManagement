using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Models.Enums; // Thêm
using BagShopManagement.Services.Interfaces;

namespace BagShopManagement.Controllers
{
    /// <summary>
    /// Lớp Controller (trung gian) xử lý các yêu cầu từ Form
    /// và gọi Service tương ứng.
    /// Nó sẽ ném lỗi (Exception) lên Form để Form hiển thị MessageBox.
    /// </summary>
    public class HoaDonNhapController
    {
        private readonly IHoaDonNhapService _hoaDonNhapService;

        public HoaDonNhapController(IHoaDonNhapService hoaDonNhapService)
        {
            _hoaDonNhapService = hoaDonNhapService;
        }

        #region === TRUY VẤN (READ) ===

        public List<HoaDonNhapResponse> LayDanhSachHoaDon()
        {
            // Pass-through call
            return _hoaDonNhapService.GetAllHoaDonNhap();
        }

        public HoaDonNhapResponse LayChiTietHoaDon(string maHDN)
        {
            // Validation cơ bản
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hóa đơn không được rỗng.");

            // Sửa: Gọi đúng tên hàm trong interface BLL mới
            return _hoaDonNhapService.GetHoaDonNhapDetail(maHDN);
        }

        public List<HoaDonNhapResponse> TimKiemHoaDon(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV, TrangThaiHoaDonNhap? trangThai)
        {
            // Sửa: Thêm tham số trangThai
            return _hoaDonNhapService.Search(maHDN, tuNgay, denNgay, maNCC, maNV, trangThai);
        }

        #endregion === TRUY VẤN (READ) ===

        #region === NGHIỆP VỤ CHÍNH (WRITE) ===

        /// Yêu cầu tạo mới HĐN ở trạng thái Tạm lưu
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

        /// <summary>
        /// Yêu cầu Hủy HĐN (Kiểm tra nghiệp vụ an toàn kho)
        /// </summary>
        public void HuyHoaDon(string maHDN) // Sửa: void (BLL ném lỗi, không trả về bool)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hóa đơn không được rỗng.");

            // Sửa: Gọi đúng tên hàm BLL (CancelHoaDonNhap)
            _hoaDonNhapService.CancelHoaDonNhap(maHDN);
        }

        /// <summary>
        /// Yêu cầu cập nhật thông tin Header (NCC, NV, Ghi chú) khi Tạm lưu
        /// </summary>
        // Sửa: Đổi DTO và kiểu trả về void
        public void CapNhatThongTinHoaDon(string maHDN, HoaDonNhapInfoUpdateRequest request)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hóa đơn không được rỗng.");
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dữ liệu cập nhật rỗng.");

            // Sửa: Gọi đúng tên hàm BLL (UpdateDraftInfo)
            _hoaDonNhapService.UpdateDraftInfo(maHDN, request);
        }

        #endregion === NGHIỆP VỤ CHÍNH (WRITE) ===

        #region === NGHIỆP VỤ SỬA CHI TIẾT (KHI TẠM LƯU) ===

        /// <summary>
        /// (MỚI) Yêu cầu thêm SP vào HĐN (khi Tạm lưu)
        /// </summary>
        public void ThemChiTiet(string maHDN, ChiTietHDNRequest chiTietRequest)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hóa đơn không được rỗng.");
            if (chiTietRequest == null)
                throw new ArgumentNullException(nameof(chiTietRequest));

            _hoaDonNhapService.AddDetailToDraft(maHDN, chiTietRequest);
        }

        /// <summary>
        /// (MỚI) Yêu cầu sửa (Số lượng/Đơn giá) SP trong HĐN (khi Tạm lưu)
        /// </summary>
        public void SuaChiTiet(string maHDN, string maSP, ChiTietHDNRequest chiTietRequest)
        {
            if (string.IsNullOrWhiteSpace(maHDN) || string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Mã hóa đơn hoặc Mã sản phẩm không được rỗng.");
            if (chiTietRequest == null)
                throw new ArgumentNullException(nameof(chiTietRequest));

            _hoaDonNhapService.UpdateDetailInDraft(maHDN, maSP, chiTietRequest);
        }

        /// <summary>
        /// (MỚI) Yêu cầu xóa SP khỏi HĐN (khi Tạm lưu)
        /// </summary>
        public void XoaChiTiet(string maHDN, string maSP)
        {
            if (string.IsNullOrWhiteSpace(maHDN) || string.IsNullOrWhiteSpace(maSP))
                throw new ArgumentException("Mã hóa đơn hoặc Mã sản phẩm không được rỗng.");

            _hoaDonNhapService.DeleteDetailFromDraft(maHDN, maSP);
        }

        #endregion === NGHIỆP VỤ SỬA CHI TIẾT (KHI TẠM LƯU) ===
    }
}