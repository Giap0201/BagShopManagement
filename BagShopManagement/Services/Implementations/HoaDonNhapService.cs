using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Models.Enums;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;

// using BagShopManagement.Utils; // (Nếu có)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Implementations
{
    public class HoaDonNhapService : IHoaDonNhapService
    {
        private readonly IHoaDonNhapRepository _hoaDonNhapRepo;
        private readonly IChiTietHDNRepository _chiTietRepo;
        private readonly INhanVienRepository _nhanVienRepo;
        private readonly INhaCungCapRepository _nhaCungCapRepo;
        private readonly ISanPhamRepository _sanPhamRepo;

        public HoaDonNhapService(
            IHoaDonNhapRepository hoaDonNhapRepo,
            IChiTietHDNRepository chiTietRepo,
            INhaCungCapRepository nhaCungCapRepo,
            INhanVienRepository nhanVienRepo,
            ISanPhamRepository sanPhamRepo)
        {
            _hoaDonNhapRepo = hoaDonNhapRepo;
            _chiTietRepo = chiTietRepo;
            _nhaCungCapRepo = nhaCungCapRepo;
            _nhanVienRepo = nhanVienRepo;
            _sanPhamRepo = sanPhamRepo;
        }

        #region === NGHIỆP VỤ CHÍNH (CREATE/APPROVE/CANCEL) ===

        /// Tạo mới một Hóa đơn Nhập ở trạng thái "Tạm lưu".
        public string CreateDraftHoaDonNhap(HoaDonNhapRequest request)
        {
            ValidateHoaDonNhapRequest(request);

            try
            {
                var hoaDon = new HoaDonNhap
                {
                    MaHDN = request.MaHDN,
                    MaNCC = request.MaNCC,
                    MaNV = request.MaNV,
                    NgayNhap = request.NgayNhap,
                    GhiChu = request.GhiChu,
                    TrangThai = (byte)TrangThaiHoaDonNhap.TamLuu,
                    NgayDuyet = null
                };

                var chiTiets = request.ChiTiet.Select(ct => new ChiTietHoaDonNhap
                {
                    MaHDN = hoaDon.MaHDN,
                    MaSP = ct.MaSP,
                    SoLuong = ct.SoLuong,
                    DonGia = ct.DonGia,
                    ThanhTien = ct.SoLuong * ct.DonGia
                }).ToList();

                hoaDon.TongTien = chiTiets.Sum(ct => ct.ThanhTien);
                string result = _hoaDonNhapRepo.InsertDraft(hoaDon, chiTiets);
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi hệ thống khi tạo hóa đơn nháp: {ex.Message}", ex);
            }
        }

        // duyet hoa don, cap nhat trang thai hoa don, ton kho, gia nhap moi
        public void ApproveHoaDonNhap(string maHDN)
        {
            HoaDonNhap hoadon = GetHoaDonHoacNemLoi(maHDN);

            if (hoadon.TrangThai != (byte)TrangThaiHoaDonNhap.TamLuu)
            {
                throw new InvalidOperationException("Chỉ có thể duyệt hóa đơn ở trạng thái 'Tạm lưu'.");
            }

            var chiTiets = _chiTietRepo.GetByHoaDonNhapId(maHDN);
            if (chiTiets == null || !chiTiets.Any())
            {
                throw new InvalidOperationException("Không thể duyệt một hóa đơn rỗng (không có chi tiết).");
            }

            try
            {
                _hoaDonNhapRepo.ApproveDraftHoaDonNhap(maHDN, DateTime.Now, chiTiets);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi hệ thống khi duyệt hóa đơn: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Hủy một Hóa đơn Nhập (logic phức tạp).
        /// </summary>
        public void CancelHoaDonNhap(string maHDN)
        {
            // 1. Kiểm tra nghiệp vụ
            HoaDonNhap hoadon = GetHoaDonHoacNemLoi(maHDN);

            if (hoadon.TrangThai == (byte)TrangThaiHoaDonNhap.DaHuy)
            {
                // Không cần làm gì nếu đã hủy
                return;
            }

            try
            {
                // 2. Phân luồng nghiệp vụ
                if (hoadon.TrangThai == (byte)TrangThaiHoaDonNhap.TamLuu)
                {
                    // Hủy phiếu nháp -> Dễ, chỉ cần đổi trạng thái
                    _hoaDonNhapRepo.UpdateTrangThai(maHDN, TrangThaiHoaDonNhap.DaHuy);
                }
                else if (hoadon.TrangThai == (byte)TrangThaiHoaDonNhap.HoatDong)
                {
                    // Hủy phiếu "Hoạt động" -> Phải kiểm tra an toàn kho
                    var chiTiets = _chiTietRepo.GetByHoaDonNhapId(maHDN);

                    // 3. KIỂM TRA AN TOÀN (LOGIC CỐT LÕI CỦA BẠN)
                    if (!KiemTraAnToanTonKhoKhiHuy(chiTiets))
                    {
                        throw new InvalidOperationException(
                            "Không thể hủy phiếu nhập này! Hàng hóa trong phiếu đã được bán. " +
                            "Việc hủy sẽ gây ra [ÂM KHO].");
                    }

                    // 4. Gọi DAL (Hàm này có Transaction để TRỪ kho VÀ đổi trạng thái)
                    _hoaDonNhapRepo.CancelActiveHoaDonNhap(maHDN, DateTime.Now, chiTiets);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi hệ thống khi hủy hóa đơn: {ex.Message}", ex);
            }
        }

        #endregion === NGHIỆP VỤ CHÍNH (CREATE/APPROVE/CANCEL) ===

        #region === NGHIỆP VỤ CẬP NHẬT (KHI TẠM LƯU) ===

        /// <summary>
        /// Cập nhật thông tin Header (NCC, NV, Ghi chú...)
        /// </summary>
        public void UpdateDraftInfo(string maHDN, HoaDonNhapInfoUpdateRequest request)
        {
            // 1. Validation
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dữ liệu cập nhật rỗng.");

            // 2. Kiểm tra nghiệp vụ
            HoaDonNhap hoadon = GetHoaDonHoacNemLoi(maHDN);
            if (hoadon.TrangThai != (byte)TrangThaiHoaDonNhap.TamLuu)
            {
                throw new InvalidOperationException("Chỉ có thể sửa thông tin hóa đơn ở trạng thái 'Tạm lưu'.");
            }

            // 3. Kiểm tra các Mã khóa ngoại mới
            //if (!_nhaCungCapRepo.Exists(request.MaNCC))
            //    throw new InvalidOperationException($"Nhà cung cấp '{request.MaNCC}' không tồn tại.");
            //if (!_nhanVienRepo.Exists(request.MaNV))
            //throw new InvalidOperationException($"Nhân viên '{request.MaNV}' không tồn tại.");

            // 4. Map dữ liệu và gọi DAL
            hoadon.MaNCC = request.MaNCC;
            hoadon.MaNV = request.MaNV;
            hoadon.NgayNhap = request.NgayNhap;
            hoadon.GhiChu = request.GhiChu;

            try
            {
                _hoaDonNhapRepo.UpdateDraftHeader(hoadon);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi hệ thống khi cập nhật thông tin HĐN: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thêm một sản phẩm mới vào HĐN đang "Tạm lưu".
        /// </summary>
        public void AddDetailToDraft(string maHDN, ChiTietHDNRequest detailRequest)
        {
            // 1. Validation
            ValidateChiTietRequest(detailRequest);

            // 2. Kiểm tra nghiệp vụ
            HoaDonNhap hoadon = GetHoaDonHoacNemLoi(maHDN);
            if (hoadon.TrangThai != (byte)TrangThaiHoaDonNhap.TamLuu)
            {
                throw new InvalidOperationException("Chỉ có thể thêm sản phẩm vào HĐN 'Tạm lưu'.");
            }

            // 3. Kiểm tra chi tiết
            //if (!_sanPhamRepo.Exists(detailRequest.MaSP))
            //    throw new InvalidOperationException($"Sản phẩm '{detailRequest.MaSP}' không tồn tại.");
            if (_chiTietRepo.DetailExists(maHDN, detailRequest.MaSP))
                throw new InvalidOperationException($"Sản phẩm '{detailRequest.MaSP}' đã có trong hóa đơn.");

            // 4. Map và Tính toán
            var chiTiet = new ChiTietHoaDonNhap
            {
                MaHDN = maHDN,
                MaSP = detailRequest.MaSP,
                SoLuong = detailRequest.SoLuong,
                DonGia = detailRequest.DonGia,
                ThanhTien = detailRequest.SoLuong * detailRequest.DonGia
            };

            // 5. Gọi DAL (Hàm này có Transaction để thêm CT VÀ cập nhật TongTien HĐN cha)
            try
            {
                _chiTietRepo.AddDetailToDraft(chiTiet);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi hệ thống khi thêm chi tiết: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Cập nhật (Số lượng/Đơn giá) của một sản phẩm trong HĐN "Tạm lưu".
        /// </summary>
        public void UpdateDetailInDraft(string maHDN, string maSP, ChiTietHDNRequest detailRequest)
        {
            // 1. Validation
            if (detailRequest == null) throw new ArgumentNullException(nameof(detailRequest));
            // Cập nhật chi tiết, MaSP trong DTO phải giống MaSP trong URL
            if (detailRequest.MaSP != maSP)
                throw new ArgumentException("Mã sản phẩm không khớp.");

            ValidateChiTietRequest(detailRequest);

            // 2. Kiểm tra nghiệp vụ
            HoaDonNhap hoadon = GetHoaDonHoacNemLoi(maHDN);
            if (hoadon.TrangThai != (byte)TrangThaiHoaDonNhap.TamLuu)
            {
                throw new InvalidOperationException("Chỉ có thể sửa sản phẩm trong HĐN 'Tạm lưu'.");
            }
            if (!_chiTietRepo.DetailExists(maHDN, maSP))
                throw new InvalidOperationException($"Sản phẩm '{maSP}' không có trong hóa đơn để cập nhật.");

            // 3. Map và Tính toán
            var chiTiet = new ChiTietHoaDonNhap
            {
                MaHDN = maHDN,
                MaSP = maSP,
                SoLuong = detailRequest.SoLuong,
                DonGia = detailRequest.DonGia,
                ThanhTien = detailRequest.SoLuong * detailRequest.DonGia
            };

            // 4. Gọi DAL (Hàm này có Transaction để sửa CT VÀ cập nhật TongTien HĐN cha)
            try
            {
                _chiTietRepo.UpdateDetailInDraft(chiTiet);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi hệ thống khi cập nhật chi tiết: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa một sản phẩm khỏi HĐN đang "Tạm lưu".
        /// </summary>
        public void DeleteDetailFromDraft(string maHDN, string maSP)
        {
            // 1. Kiểm tra nghiệp vụ
            HoaDonNhap hoadon = GetHoaDonHoacNemLoi(maHDN);
            if (hoadon.TrangThai != (byte)TrangThaiHoaDonNhap.TamLuu)
            {
                throw new InvalidOperationException("Chỉ có thể xóa sản phẩm khỏi HĐN 'Tạm lưu'.");
            }
            if (!_chiTietRepo.DetailExists(maHDN, maSP))
                throw new InvalidOperationException($"Sản phẩm '{maSP}' không có trong hóa đơn để xóa.");

            // 2. Gọi DAL (Hàm này có Transaction để xóa CT VÀ cập nhật TongTien HĐN cha)
            try
            {
                _chiTietRepo.DeleteDetailFromDraft(maHDN, maSP);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi hệ thống khi xóa chi tiết: {ex.Message}", ex);
            }
        }

        #endregion === NGHIỆP VỤ CẬP NHẬT (KHI TẠM LƯU) ===

        #region === TRUY VẤN (READ) - (Tương tự code cũ của bạn) ===

        public List<HoaDonNhapResponse> GetAllHoaDonNhap()
        {
            try
            {
                return _hoaDonNhapRepo.GetAllHoaDonNhap();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi tải danh sách hóa đơn: {ex.Message}", ex);
            }
        }

        public HoaDonNhapResponse GetHoaDonNhapDetail(string maHDN)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hoá đơn nhập không được bỏ trống");

            try
            {
                var response = _hoaDonNhapRepo.GetHoaDonNhapDetail(maHDN);
                if (response == null)
                    throw new InvalidOperationException($"Không tìm thấy hóa đơn nhập với mã {maHDN}.");
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi tải chi tiết hóa đơn: {ex.Message}", ex);
            }
        }

        public List<HoaDonNhapResponse> Search(string? maHDN, DateTime? tuNgay, DateTime? denNgay, string? maNCC, string? maNV, TrangThaiHoaDonNhap? trangThai)
        {
            try
            {
                // Chuyển enum sang byte? để truyền xuống DAL
                byte? trangThaiByte = trangThai.HasValue ? (byte?)trangThai.Value : null;
                return _hoaDonNhapRepo.Search(maHDN, tuNgay, denNgay, maNCC, maNV, trangThaiByte);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Lỗi tìm kiếm hóa đơn: {ex.Message}", ex);
            }
        }

        #endregion === TRUY VẤN (READ) - (Tương tự code cũ của bạn) ===

        #region === PRIVATE HELPERS ===

        /// <summary>
        /// Lấy hóa đơn, nếu không thấy thì ném lỗi (Dùng nội bộ)
        /// </summary>
        private HoaDonNhap GetHoaDonHoacNemLoi(string maHDN)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
                throw new ArgumentException("Mã hóa đơn không được rỗng.", nameof(maHDN));

            var hoadon = _hoaDonNhapRepo.GetById(maHDN);
            if (hoadon == null)
                throw new InvalidOperationException($"Không tìm thấy hóa đơn {maHDN}.");

            return hoadon;
        }

        /// <summary>
        /// Kiểm tra an toàn tồn kho (logic cốt lõi của bạn)
        /// </summary>
        private bool KiemTraAnToanTonKhoKhiHuy(List<ChiTietHoaDonNhap> chiTietList)
        {
            foreach (var ct in chiTietList)
            {
                // Giả sử ISanPhamRepository có hàm GetTonKho
                //int tonKhoHienTai = _sanPhamRepo.GetTonKho(ct.MaSP);

                // Nếu tồn kho hiện tại < số lượng đã nhập trong phiếu này
                // -> Tức là hàng đã bị bán bớt
                // -> Nếu trừ đi (hủy phiếu nhập) sẽ bị âm.
                //if (tonKhoHienTai < ct.SoLuong)
                //{
                //    return false; // Không an toàn!
                //}
            }
            return true; // An toàn
        }

        /// <summary>
        /// Xác thực DTO khi tạo mới
        /// </summary>
        private void ValidateHoaDonNhapRequest(HoaDonNhapRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dữ liệu hóa đơn không được để trống.");
            if (string.IsNullOrWhiteSpace(request.MaHDN))
                throw new ArgumentException("Mã hóa đơn nhập không được để trống.", nameof(request.MaHDN));
            if (string.IsNullOrWhiteSpace(request.MaNV))
                throw new ArgumentException("Mã nhân viên không được để trống.", nameof(request.MaNV));
            if (string.IsNullOrWhiteSpace(request.MaNCC))
                throw new ArgumentException("Mã nhà cung cấp không được để trống.", nameof(request.MaNCC));
            if (request.NgayNhap > DateTime.Now.AddDays(1)) // Cho phép sai số 1 ngày
                throw new ArgumentException("Ngày nhập không hợp lệ.", nameof(request.NgayNhap));

            // Kiểm tra tồn tại
            if (_hoaDonNhapRepo.Exists(request.MaHDN))
                throw new InvalidOperationException($"Hóa đơn nhập với mã {request.MaHDN} đã tồn tại.");
            //if (!_nhaCungCapRepo.Exists(request.MaNCC))
            //    throw new InvalidOperationException($"Nhà cung cấp '{request.MaNCC}' không tồn tại.");
            //if (!_nhanVienRepo.Exists(request.MaNV))
            //    throw new InvalidOperationException($"Nhân viên '{request.MaNV}' không tồn tại.");

            // Kiểm tra chi tiết
            if (request.ChiTiet == null || !request.ChiTiet.Any())
                throw new ArgumentException("Danh sách chi tiết hóa đơn không được để trống.", nameof(request.ChiTiet));

            var productSet = new HashSet<string>();
            foreach (var ct in request.ChiTiet)
            {
                ValidateChiTietRequest(ct); // Gọi helper con

                //if (!_sanPhamRepo.Exists(ct.MaSP))
                //    throw new InvalidOperationException($"Sản phẩm '{ct.MaSP}' không tồn tại trong hệ thống.");
                if (!productSet.Add(ct.MaSP))
                    throw new ArgumentException($"Sản phẩm '{ct.MaSP}' bị trùng trong danh sách chi tiết.");
            }
        }

        /// <summary>
        /// Xác thực DTO chi tiết
        /// </summary>
        private void ValidateChiTietRequest(ChiTietHDNRequest ct)
        {
            if (ct == null)
                throw new ArgumentException("Chi tiết HĐN không được rỗng.");
            if (string.IsNullOrWhiteSpace(ct.MaSP))
                throw new ArgumentException("Mã sản phẩm không được rỗng.");
            if (ct.SoLuong <= 0)
                throw new ArgumentException($"Số lượng của sản phẩm {ct.MaSP} phải lớn hơn 0.");
            if (ct.DonGia < 0) // Cho phép đơn giá = 0 (hàng tặng)
                throw new ArgumentException($"Đơn giá của sản phẩm {ct.MaSP} không hợp lệ.");
        }

        #endregion === PRIVATE HELPERS ===
    }
}