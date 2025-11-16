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
        /// Lấy danh sách nhân viên đầy đủ (JOIN 3 bảng) để hiển thị.
        /// </summary>
        List<NhanVienResponse> GetAllForDisplay();

        /// <summary>
        /// Lấy Mã Nhân Viên tiếp theo (ví dụ: NV005 -> NV006).
        /// </summary>
        string GetNextMaNV();

        // --- Phiên bản không transaction ---
        void Add(NhanVien nhanVien);
        void Update(NhanVien nhanVien);

        // --- PHIÊN BẢN TRANSACTION ---
        void Add(NhanVien nhanVien, SqlConnection conn, SqlTransaction tran);
        void Update(NhanVien nhanVien, SqlConnection conn, SqlTransaction tran);

        List<NhanVien> GetAll();
        List<NhanVienResponse> Search(string formattedKeyword);
    }
}