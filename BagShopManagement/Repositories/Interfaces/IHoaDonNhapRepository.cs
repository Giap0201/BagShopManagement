using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Models.Enums; // Cần thêm Enum
using System;
using System.Collections.Generic;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IHoaDonNhapRepository
    {
        //Kiem tra hoa don nhap da ton tai trong he thong chua
        bool Exists(string maHDN);

        //Lay thuc the hoa don nhap theo ma hoa don nhap
        HoaDonNhap GetById(string maHDN);

        //Lay danh sach tat ca hoa don nhap de hien thi ra UI
        List<HoaDonNhapResponse> GetAllHoaDonNhap();

        //Tim kiem hoa don nhap theo cac tieu chi
        List<HoaDonNhapResponse> Search(
            string? maHDN,
            DateTime? tuNgay,
            DateTime? denNgay,
            string? maNCC,
            string? maNV,
            byte? trangThai = null
        );

        // lay chi tiet 1 hoa don nhap dung cho phan xem chi tiet
        HoaDonNhapResponse GetHoaDonNhapDetail(string maHDN);

        //Tao moi hoa don nhap o trang thai tam luu
        string InsertDraft(HoaDonNhap hoaDonNhap, List<ChiTietHoaDonNhap> chiTiets);

        ///Cap nhat thong tin hoa don nhap o trang thai tam luu
        bool UpdateDraftHeader(HoaDonNhap hoaDonNhap);

        // cap nhap trang thai hoa don nhap va cong ton kho khi duyet hoa don
        bool ApproveDraftHoaDonNhap(string maHDN, DateTime ngayDuyet, List<ChiTietHoaDonNhap> chiTiets);

        //huy hoa don khi hoa don dang o trang thai hoat dong, phai kiem tra xem ton kho truoc khi huy
        bool CancelActiveHoaDonNhap(string maHDN, DateTime ngayHuy, List<ChiTietHoaDonNhap> chiTiets);

        // cap nhat trang thai don gian khong anh huong den ton kho
        bool UpdateTrangThai(string maHDN, TrangThaiHoaDonNhap trangThai);

        List<HoaDonNhap> GetAll();
    }
}