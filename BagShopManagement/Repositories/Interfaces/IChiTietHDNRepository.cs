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

        /// <summary>
        /// [TRANSACTION] Thêm 1 chi tiết vào hóa đơn (khi đang Tạm lưu).
        /// Phải cập nhật lại TongTien của HoaDonNhap cha.
        /// </summary>
        bool AddDetailToDraft(ChiTietHoaDonNhap chiTiet);

        /// <summary>
        /// [TRANSACTION] Cập nhật 1 chi tiết (Số lượng, Đơn giá) (khi đang Tạm lưu).
        /// Phải cập nhật lại TongTien của HoaDonNhap cha.
        /// </summary>
        bool UpdateDetailInDraft(ChiTietHoaDonNhap chiTiet);

        /// <summary>
        /// [TRANSACTION] Xóa 1 chi tiết khỏi hóa đơn (khi đang Tạm lưu).
        /// Phải cập nhật lại TongTien của HoaDonNhap cha.
        /// </summary>
        bool DeleteDetailFromDraft(string maHDN, string maSP);
    }
}