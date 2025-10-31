using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using BagShopManagement.Views.Common;
using BagShopManagement.Views.Dev6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Controllers
{
    // Controller cần biết Service và View mà nó điều khiển
    public class HoaDonNhapController
    {
        private readonly HoaDonNhapControl _view;
        private readonly IHoaDonNhapService _service;

        // Controller nhận View và Service
        public HoaDonNhapController(HoaDonNhapControl view, IHoaDonNhapService service)
        {
            _view = view;
            _service = service;

            // Gắn các sự kiện từ View vào các phương thức của Controller
            _view.Load += OnLoad;
            _view.TimKiemClicked += (s, e) => TimKiem();
            _view.XoaClicked += (s, e) => XoaHoaDon();

            // Xử lý các chức năng chưa làm
            _view.ThemMoiClicked += (s, e) =>
                MessageBox.Show("Chức năng 'Thêm mới' yêu cầu tạo một Form giao diện mới.", "Chưa triển khai", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _view.SuaClicked += (s, e) =>
                MessageBox.Show("Chức năng 'Sửa' yêu cầu tạo một Form giao diện mới.", "Chưa triển khai", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xử lý khi View được tải
        private void OnLoad(object sender, EventArgs e)
        {
            try
            {
                // 1. Tải dữ liệu cho các ComboBox
                LoadComboBoxes();
                // 2. Tải danh sách hóa đơn lần đầu
                TimKiem();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Show(ex, "Lỗi khi tải dữ liệu ban đầu.");
            }
        }

        private void LoadComboBoxes()
        {
            // Tải Nhà cung cấp
            var nccList = _service.GetNhaCungCapList();
            // Thêm mục "Tất cả"
            nccList.Insert(0, new Models.NhaCungCap { MaNCC = "", TenNCC = "--- Tất cả Nhà cung cấp ---" });
            _view.SetNhaCungCapDataSource(nccList);

            // Tải Nhân viên
            var nvList = _service.GetNhanVienList();
            // Thêm mục "Tất cả"
            nvList.Insert(0, new Models.NhanVien { MaNV = "", HoTen = "--- Tất cả Nhân viên ---" });
            _view.SetNhanVienDataSource(nvList);
        }

        // Xử lý sự kiện Tìm kiếm
        public void TimKiem()
        {
            try
            {
                // Lấy giá trị từ các filter trên View
                string maHDN = _view.MaHDNFilter;
                DateTime? tuNgay = _view.TuNgayFilter; // Cho phép null
                DateTime? denNgay = _view.DenNgayFilter; // Cho phép null
                string maNCC = _view.MaNCCFilter;
                string maNV = _view.MaNVFilter;

                var dsHoaDon = _service.SearchHoaDonNhap(maHDN, tuNgay, denNgay, maNCC, maNV);

                // Đẩy dữ liệu về View để hiển thị
                _view.SetHoaDonNhapDataSource(dsHoaDon);
                _view.SetTongCong(dsHoaDon.Count);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Show(ex, "Lỗi khi tìm kiếm hoá đơn");
            }
        }

        // Xử lý sự kiện Xóa
        public void XoaHoaDon()
        {
            try
            {
                string maHDN = _view.SelectedMaHDN;
                if (string.IsNullOrEmpty(maHDN))
                {
                    MessageBox.Show("Vui lòng chọn một hoá đơn để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận lại với người dùng
                var confirm = MessageBox.Show($"Bạn có chắc muốn xoá vĩnh viễn hoá đơn '{maHDN}' không? Mọi chi tiết của hoá đơn này cũng sẽ bị xoá.", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    _service.DeleteHoaDonNhap(maHDN);
                    MessageBox.Show("Xoá hoá đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu trên lưới
                    TimKiem();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi từ Service (nếu có)
                ExceptionHandler.Show(ex, "Lỗi khi xoá hoá đơn");
            }
        }
    }
}