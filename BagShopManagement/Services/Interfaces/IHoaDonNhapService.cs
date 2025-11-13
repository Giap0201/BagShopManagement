using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models.Enums; // Cần dùng Enum
using System;
using System.Collections.Generic;

namespace BagShopManagement.Services.Interfaces
{
    public interface IHoaDonNhapService
    {
        /// Tao moi hoa don nhap khi dang o trang thai tam luu
        string CreateDraftHoaDonNhap(HoaDonNhapRequest request);

        // Duyet hoa don tu trang thai tam luu sang hoat dong, cap nhat ton kho, gia nhap moi
        void ApproveHoaDonNhap(string maHDN);

        // huy hoa don nhap
        void CancelHoaDonNhap(string maHDN);

        #region === NGHIỆP VỤ CẬP NHẬT (KHI TẠM LƯU) ===

        //cap nhat thong tin hoa don
        void UpdateDraftInfo(string maHDN, HoaDonNhapInfoUpdateRequest request);

        // them chi tiet san pham khi dang tam luu
        void AddDetailToDraft(string maHDN, ChiTietHDNRequest detailRequest);

        //cap nhat chi tiet san pham khi dang tam luu
        void UpdateDetailInDraft(string maHDN, string maSP, ChiTietHDNRequest detailRequest);

        //xoa san pham khi dang tam luu
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