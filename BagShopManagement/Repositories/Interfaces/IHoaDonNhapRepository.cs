using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IHoaDonNhapRepository
    {
        //kiem tra xem hoa don nhao da ton tai chua
        bool Exists(string maHDN);

        //lay ra hoa don nhap theo ma hoa don nhap
        HoaDonNhap GetById(string maHDN);

        //them hoa don nhap va chi tiet hoa don nhap cung luc
        string InsertWithDetails(HoaDonNhap hoaDonNhap, List<ChiTietHoaDonNhap> chiTiets);

        string Insert(HoaDonNhap hoaDonNhap);

        bool Update(HoaDonNhap hoaDonNhap);

        bool Delete(string maHDN);

        List<HoaDonNhap> GetAll();

        List<HoaDonNhapResponse> Search(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV);

        //lay ra danh sach hoa don nhap cua he thong
        List<HoaDonNhapResponse> GetAllHoaDonNhap();

        //phuong thuc lay ra 1 hoa don nhap va cac chi tiet hoa don nhap cua no dung de xem chi tiet hoa don
        HoaDonNhapResponse HoaDonNhapViewModel(string maHDN);

        //chi cho cap nhat cac thong tin can thiet, khong cap nhat cac thong tin goc
        bool UpdateInfo(string maHDN, DateTime ngayNhap, string ghiChu);
    }
}