using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IChiTietHDNRepository
    {
        //lay tat ca chi tiet cua 1 hoa don nhap
        List<ChiTietHoaDonNhap> GetByHoaDonNhapId(string maHDN);

        //lay 1 chi tiet cu the cua hoa don nhap
        ChiTietHoaDonNhap GetDetailById(string maHDN, string maSP);

        // kiem tra xem chi tiet da ton tai trong hoa don nhap chua
        bool DetailExists(string maHDN, string maSP);

        // them mot chi tiet vao hoa don, dung khi tam luu
        bool AddDetailToDraft(ChiTietHoaDonNhap chiTiet);

        // cap nhat chi tiet khi dang o trang thai tam luu (da co trong db roi)
        bool UpdateDetailInDraft(ChiTietHoaDonNhap chiTiet);

        // xoa chi tiet khi dang o trang thai tam luu
        bool DeleteDetailFromDraft(string maHDN, string maSP);
    }
}