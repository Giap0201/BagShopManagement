using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
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

        //them hoa don nhap cung toan bo chi tiet hoa don nhap
        public string CreateHoaDonNhap(HoaDonNhapRequest request)
        {
            //xu li Exception
            handleExceptionCreate(request);
            var hoaDon = new HoaDonNhap
            {
                MaHDN = request.MaHDN,
                MaNCC = request.MaNCC,
                MaNV = request.MaNV,
                NgayNhap = request.NgayNhap,
                GhiChu = request.GhiChu
            };

            var chiTiets = request.ChiTiet.Select(ct => new ChiTietHoaDonNhap
            {
                MaHDN = hoaDon.MaHDN,
                MaSP = ct.MaSP,
                SoLuong = ct.SoLuong,
                DonGia = ct.DonGia
            }).ToList();

            //tinh tong tien
            var tongTien = chiTiets.Sum(ct => ct.SoLuong * ct.DonGia);
            hoaDon.TongTien = tongTien;

            string result = _hoaDonNhapRepo.InsertWithDetails(hoaDon, chiTiets);
            if (result == null)
            {
                throw new Exception("Thêm hóa đơn nhập thất bại, dữ liệu có thể chưa được lưu.");
            }
            return hoaDon.MaHDN;
        }

        private void handleExceptionCreate(HoaDonNhapRequest request)
        {
            //kiem tra request dau vao
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Dữ liệu hóa đơn không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(request.MaHDN))
            {
                throw new ArgumentException("Mã hóa đơn nhập không được để trống.", nameof(request.MaHDN));
            }

            if (string.IsNullOrWhiteSpace(request.MaNV))
            {
                throw new ArgumentException("Mã nhân viên không được để trống.", nameof(request.MaNV));
            }

            if (string.IsNullOrWhiteSpace(request.MaNCC))
            {
                throw new ArgumentException("Mã nhà cung cấp không được để trống.", nameof(request.MaNCC));
            }
            if (request.NgayNhap > DateTime.Now)
            {
                throw new ArgumentException("Ngày nhập không được lớn hơn ngày hiện tại.", nameof(request.NgayNhap));
            }

            //kiem tra nghiep vu ton tai
            if (_hoaDonNhapRepo.Exists(request.MaHDN))
                throw new ArgumentException($"Hóa đơn nhập với mã {request.MaHDN} đã tồn tại.", nameof(request.MaHDN));

            //if (!_nhaCungCapRepo.Exists(request.MaNCC))
            //    throw new InvalidOperationException("Nhà cung cấp không tồn tại.");

            //if (!_nhanVienRepo.Exists(request.MaNV))
            //    throw new InvalidOperationException("Nhân viên không tồn tại.");

            //kiem tra du lieu chi tiet hoa don
            if (request.ChiTiet == null || !request.ChiTiet.Any())
            {
                throw new ArgumentException("Danh sách chi tiết hóa đơn không được để trống.", nameof(request.ChiTiet));
            }
            var productSet = new HashSet<string>();
            foreach (var ct in request.ChiTiet)
            {
                if (string.IsNullOrWhiteSpace(ct.MaSP))
                    throw new ArgumentException("Mã sản phẩm không được rỗng.");

                if (ct.SoLuong <= 0)
                    throw new ArgumentException($"Số lượng của sản phẩm {ct.MaSP} phải lớn hơn 0.");

                if (ct.DonGia <= 0)
                    throw new ArgumentException($"Đơn giá của sản phẩm {ct.MaSP} phải lớn hơn 0.");

                //if (!_sanPhamRepo.Exists(ct.MaSP))
                //    throw new InvalidOperationException($"Sản phẩm {ct.MaSP} không tồn tại trong hệ thống.");

                if (!productSet.Add(ct.MaSP))
                    throw new ArgumentException($"Sản phẩm {ct.MaSP} bị trùng trong danh sách chi tiết.");
            }
        }

        //lay danh sach hoa don nhap de xem chi tiet 1 hoa don nahp
        public List<HoaDonNhapResponse> GetAllHoaDonNhap()
        {
            return _hoaDonNhapRepo.GetAllHoaDonNhap();
        }

        //lay hoa don nhap va chi tiet hoa don don nhap cua no
        public HoaDonNhapResponse GetHoaDonNhapById(string maHDN)
        {
            if (string.IsNullOrWhiteSpace(maHDN))
            {
                throw new ArgumentException("Mã hoá đơn nhập không được bỏ trống");
            }

            var response = _hoaDonNhapRepo.HoaDonNhapViewModel(maHDN);
            if (response == null)
            {
                throw new InvalidOperationException($"Không tìm thấy hóa đơn nhập với mã {maHDN}.");
            }
            return response;
        }

        public List<HoaDonNhapResponse> Search(string maHDN, DateTime? tuNgay, DateTime? denNgay, string maNCC, string maNV)
        {
            return _hoaDonNhapRepo.Search(maHDN, tuNgay, denNgay, maNCC, maNV);
        }

        public bool UpdateHoaDonNhap(HoaDonNhapUpdateRequest request)
        {
            //xu li loi
            handleUpdateExceptioin(request);
            if (!_hoaDonNhapRepo.Exists(request.MaHDN)) return false;
            return _hoaDonNhapRepo.UpdateInfo(request.MaHDN, request.NgayNhap, request.GhiChu);
        }

        private void handleUpdateExceptioin(HoaDonNhapUpdateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Dữ liệu cập nhập không được bỏ trống");
            if (string.IsNullOrWhiteSpace(request.MaHDN))
                throw new ArgumentException("Mã hoá đơn cập nhật không được bỏ trống", nameof(request.MaHDN));
            if (request.NgayNhap > DateTime.Now)
                throw new ArgumentException("Ngày nhập không được lớn hơn ngày hiện tại.", nameof(request.NgayNhap));
        }

        bool IHoaDonNhapService.DeleteHoaDonNhap(string maHDN)
        {
            throw new NotImplementedException();
        }
    }
}