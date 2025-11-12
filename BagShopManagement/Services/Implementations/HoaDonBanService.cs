using BagShopManagement.DTOs;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using System;
using System.Collections.Generic;

namespace BagShopManagement.Services.Implementations
{
    /// <summary>
    /// Service xử lý logic nghiệp vụ cho Hóa đơn bán
    /// Quản lý CRUD và các thao tác liên quan đến hóa đơn
    /// </summary>
    public class HoaDonBanService : IHoaDonBanService
    {
        private readonly IHoaDonBanRepository _repo;

        public HoaDonBanService(IHoaDonBanRepository repo) => _repo = repo;

        /// <summary>
        /// Lưu hóa đơn mới vào database (Insert)
        /// </summary>
        /// <param name="dto">DTO chứa thông tin hóa đơn và chi tiết</param>
        /// <exception cref="ArgumentNullException">Nếu dto null</exception>
        public void SaveHoaDon(HoaDonBanDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.HoaDon.MaHDB)) dto.HoaDon.MaHDB = GenerateMaHDB();
            foreach (var ct in dto.ChiTiets) ct.MaHDB = dto.HoaDon.MaHDB;

            try
            {
                _repo.Insert(dto.HoaDon, dto.ChiTiets);
                Logger.Log($"HoaDon saved: {dto.HoaDon.MaHDB}");
            }
            catch (Exception ex)
            {
                Logger.Log($"SaveHoaDon error: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Lấy tất cả hóa đơn trong hệ thống
        /// </summary>
        public List<BagShopManagement.Models.HoaDonBan> GetAll() => _repo.GetAll();

        /// <summary>
        /// Hủy hóa đơn (set trạng thái = 3)
        /// </summary>
        /// <param name="maHDB">Mã hóa đơn cần hủy</param>
        /// <remarks>Không hoàn trả tồn kho, chỉ đơn giản đổi trạng thái</remarks>
        public void CancelHoaDon(string maHDB)
        {
            _repo.UpdateTrangThai(maHDB, 3); // 3 = canceled
            Logger.Log($"HoaDon canceled: {maHDB}");
        }

        /// <summary>
        /// Lấy chi tiết hóa đơn theo mã hóa đơn
        /// </summary>
        /// <param name="maHDB">Mã hóa đơn</param>
        /// <returns>Danh sách ChiTietHoaDonBan</returns>
        public List<Models.ChiTietHoaDonBan> GetChiTietByMaHDB(string maHDB)
        {
            return _repo.GetChiTietByMaHDB(maHDB);
        }

        /// <summary>
        /// Lọc hóa đơn theo các tiêu chí
        /// </summary>
        /// <param name="fromDate">Từ ngày (nullable)</param>
        /// <param name="toDate">Đến ngày (nullable)</param>
        /// <param name="maNV">Mã nhân viên (nullable)</param>
        /// <param name="trangThai">Trạng thái hóa đơn: 1=Nháp, 2=Đã thanh toán, 3=Đã hủy (nullable)</param>
        public List<Models.HoaDonBan> Filter(DateTime? fromDate = null, DateTime? toDate = null, string? maNV = null, byte? trangThai = null)
        {
            return _repo.Filter(fromDate, toDate, maNV, trangThai);
        }

        /// <summary>
        /// Cập nhật hóa đơn đã tồn tại (Update)
        /// </summary>
        /// <param name="dto">DTO chứa thông tin cập nhật</param>
        /// <exception cref="ArgumentNullException">Nếu dto null</exception>
        /// <exception cref="ArgumentException">Nếu MaHDB rỗng</exception>
        public void UpdateHoaDon(HoaDonBanDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.HoaDon.MaHDB))
                throw new ArgumentException("Mã hóa đơn không được để trống", nameof(dto));

            foreach (var ct in dto.ChiTiets) ct.MaHDB = dto.HoaDon.MaHDB;

            try
            {
                _repo.Update(dto.HoaDon, dto.ChiTiets);
                Logger.Log($"HoaDon updated: {dto.HoaDon.MaHDB}");
            }
            catch (Exception ex)
            {
                Logger.Log($"UpdateHoaDon error: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Hủy hóa đơn và hoàn trả tồn kho (nếu hóa đơn đã thanh toán)
        /// </summary>
        /// <param name="maHDB">Mã hóa đơn cần hủy</param>
        /// <param name="tonKhoService">Service quản lý tồn kho</param>
        /// <exception cref="Exception">Nếu không tìm thấy hóa đơn</exception>
        /// <remarks>
        /// Chỉ hoàn trả tồn kho nếu TrangThaiHD = 2 (Đã thanh toán)
        /// Hóa đơn nháp (TrangThaiHD = 1) không cần hoàn trả
        /// </remarks>
        public void CancelHoaDonWithRestoreStock(string maHDB, ITonKhoService tonKhoService)
        {
            // Lấy chi tiết hóa đơn để hoàn trả tồn kho
            var chiTiets = _repo.GetChiTietByMaHDB(maHDB);
            var hoaDon = _repo.GetByMaHDB(maHDB);

            if (hoaDon == null)
                throw new Exception($"Không tìm thấy hóa đơn với mã: {maHDB}");

            // Chỉ hoàn trả nếu hóa đơn đã thanh toán (TrangThaiHD = 2)
            if (hoaDon.TrangThaiHD == 2)
            {
                foreach (var ct in chiTiets)
                {
                    tonKhoService.IncreaseStock(ct.MaSP, ct.SoLuong);
                }
                Logger.Log($"[INFO] Restored stock for {chiTiets.Count} items from invoice {maHDB}");
            }

            // Cập nhật trạng thái thành hủy (3)
            _repo.UpdateTrangThai(maHDB, 3);
            Logger.Log($"HoaDon canceled with stock restored: {maHDB}");
        }

        /// <summary>
        /// Tạo mã hóa đơn tự động theo format: HDB + số thứ tự 6 chữ số (HDB000001, HDB000002...)
        /// </summary>
        /// <returns>Mã hóa đơn unique với độ dài tối đa 9 ký tự</returns>
        private string GenerateMaHDB()
        {
            try
            {
                // Lấy mã hóa đơn lớn nhất hiện tại
                var allInvoices = _repo.GetAll();

                if (allInvoices == null || allInvoices.Count == 0)
                {
                    return "HDB000001";
                }

                // Tìm số thứ tự lớn nhất
                int maxNumber = 0;
                foreach (var invoice in allInvoices)
                {
                    if (!string.IsNullOrEmpty(invoice.MaHDB) && invoice.MaHDB.StartsWith("HDB"))
                    {
                        string numberPart = invoice.MaHDB.Substring(3); // Bỏ "HDB"
                        if (int.TryParse(numberPart, out int num))
                        {
                            if (num > maxNumber)
                                maxNumber = num;
                        }
                    }
                }

                // Tăng số thứ tự và format
                int newNumber = maxNumber + 1;
                return $"HDB{newNumber:D6}"; // D6 = 6 chữ số với leading zeros
            }
            catch (Exception ex)
            {
                Logger.Log($"[ERROR] GenerateMaHDB failed: {ex.Message}");
                // Fallback: dùng timestamp ngắn hơn
                return "HDB" + DateTime.Now.ToString("yyMMdd"); // HDB251111 (9 ký tự)
            }
        }
    }
}
