using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models.Enums; // Cần dùng Enum
using System;
using System.Collections.Generic;

namespace BagShopManagement.Services.Interfaces
{
    public interface IHoaDonNhapService
    {
        /// <summary>
        /// Tạo mới một Hóa đơn Nhập ở trạng thái "Tạm lưu".
        /// BLL sẽ tính toán TongTien và ThanhTien trước khi gọi DAL.
        /// </summary>
        /// <exception cref="ArgumentException">Ném lỗi nếu dữ liệu đầu vào không hợp lệ.</exception>
        /// <exception cref="ApplicationException">Ném lỗi nếu CSDL thất bại.</exception>
        string CreateDraftHoaDonNhap(HoaDonNhapRequest request);

        /// <summary>
        /// Duyệt một Hóa đơn Nhập (Tạm lưu -> Hoạt động).
        /// Nghiệp vụ: Cập nhật trạng thái VÀ cộng hàng vào tồn kho.
        /// </summary>
        /// <param name="maHDN">Mã HĐN cần duyệt.</param>
        /// <exception cref="InvalidOperationException">Ném lỗi nếu HĐN không ở trạng thái "Tạm lưu".</exception>
        void ApproveHoaDonNhap(string maHDN);

        /// <summary>
        /// Hủy một Hóa đơn Nhập.
        /// Nghiệp vụ:
        /// 1. Nếu HĐN ở trạng thái "Tạm lưu" -> Chỉ đổi trạng thái sang "Đã hủy".
        /// 2. Nếu HĐN ở trạng thái "Hoạt động" -> **Phải kiểm tra an toàn tồn kho**.
        ///    - Nếu an toàn (không âm kho) -> Đổi trạng thái VÀ trừ (hoàn) hàng tồn kho.
        ///    - Nếu không an toàn -> Ném lỗi.
        /// </summary>
        /// <param name="maHDN">Mã HĐN cần hủy.</param>
        /// <exception cref="InvalidOperationException">Ném lỗi nếu HĐN đã bị hủy, hoặc hủy HĐ Hoạt động nhưng gây âm kho.</exception>
        void CancelHoaDonNhap(string maHDN);

        #region === NGHIỆP VỤ CẬP NHẬT (KHI TẠM LƯU) ===

        /// <summary>
        /// Cập nhật thông tin Header (NCC, NV, Ghi chú...) của HĐN
        /// CHỈ khi HĐN đang ở trạng thái "Tạm lưu".
        /// </summary>
        /// <exception cref="InvalidOperationException">Ném lỗi nếu HĐN không ở trạng thái "Tạm lưu".</exception>
        void UpdateDraftInfo(string maHDN, HoaDonNhapInfoUpdateRequest request);

        /// <summary>
        /// Thêm một sản phẩm mới vào HĐN đang "Tạm lưu".
        /// </summary>
        /// <exception cref="InvalidOperationException">Ném lỗi nếu HĐN không ở trạng thái "Tạm lưu" hoặc SP đã tồn tại.</exception>
        void AddDetailToDraft(string maHDN, ChiTietHDNRequest detailRequest);

        /// <summary>
        /// Cập nhật (Số lượng/Đơn giá) của một sản phẩm trong HĐN đang "Tạm lưu".
        /// </summary>
        /// <exception cref="InvalidOperationException">Ném lỗi nếu HĐN không ở trạng thái "Tạm lưu" hoặc SP không tồn tại.</exception>
        void UpdateDetailInDraft(string maHDN, string maSP, ChiTietHDNRequest detailRequest);

        /// <summary>
        /// Xóa một sản phẩm khỏi HĐN đang "Tạm lưu".
        /// </summary>
        /// <exception cref="InvalidOperationException">Ném lỗi nếu HĐN không ở trạng thái "Tạm lưu".</exception>
        void DeleteDetailFromDraft(string maHDN, string maSP);

        #endregion === NGHIỆP VỤ CẬP NHẬT (KHI TẠM LƯU) ===

        #region === TRUY VẤN (READ) ===

        /// <summary>
        /// Lấy toàn bộ Hóa đơn (DTO) để hiển thị.
        /// </summary>
        List<HoaDonNhapResponse> GetAllHoaDonNhap();

        /// <summary>
        /// Lấy chi tiết một Hóa đơn (Header và Details).
        /// </summary>
        HoaDonNhapResponse GetHoaDonNhapDetail(string maHDN);

        /// <summary>
        /// Tìm kiếm Hóa đơn theo nhiều tiêu chí.
        /// </summary>
        List<HoaDonNhapResponse> Search(
            string? maHDN,
            DateTime? tuNgay,
            DateTime? denNgay,
            string? maNCC,
            string? maNV,
            TrangThaiHoaDonNhap? trangThai // Thêm trạng thái vào tìm kiếm
        );

        #endregion === TRUY VẤN (READ) ===
    }
}