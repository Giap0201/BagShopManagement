using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface INhanVienRepository
    {
        NhanVien GetById(string maNV);

        /// <summary>
        /// Lấy danh sách nhân viên đầy đủ (JOIN 3 bảng) để hiển thị lên Grid.
        /// </summary>
        List<NhanVienResponse> GetAllForDisplay();

        /// <summary>
        /// Lấy Mã Nhân Viên tiếp theo (tự động tăng dạng chuỗi NV0000001).
        /// </summary>
        string GetNextMaNV();

        void Add(NhanVien nhanVien);
        void Update(NhanVien nhanVien);

        /// <summary>
        /// Lấy danh sách nhân viên (thường dùng cho ComboBox hoặc tra cứu đơn giản).
        /// </summary>
        List<NhanVien> GetAll();

        /// <summary>
        /// Tìm kiếm nhân viên theo từ khóa.
        /// </summary>
        List<NhanVienResponse> Search(string formattedKeyword);
    }
}