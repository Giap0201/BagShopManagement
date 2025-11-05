using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Models.Enums;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel; // Quan trọng để sử dụng DesignMode
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; // Thêm dòng này nếu bạn đọc App.config trực tiếp

namespace BagShopManagement.Views.Dev6
{
    public partial class ucHoaDonNhapList : UserControl
    {
        // === 1. KHAI BÁO CONTROLLER VÀ REPO (KHÔNG KHỞI TẠO TẠI ĐÂY) ===
        private HoaDonNhapController _controller; // Khong dung readonly vi se gan lai trong Load

        private INhaCungCapRepository _nhaCungCapRepo; // Khong dung readonly
        private INhanVienRepository _nhanVienRepo; // Khong dung readonly

        public ucHoaDonNhapList()
        {
            InitializeComponent();

            // Constructor chỉ nên chứa các logic khởi tạo giao diện cơ bản
            // và gán sự kiện nếu cần.
            // KHÔNG KHỞI TẠO CÁC REPOSITORY HOẶC SERVICE Ở ĐÂY!
            // Gán sự kiện cho DataGridView
            this.dgvDanhSach.SelectionChanged += new System.EventHandler(this.dgvDanhSach_SelectionChanged);
        }

        // === 3. SỰ KIỆN LOAD CHÍNH ===
        private void ucHoaDonNhapList_Load(object sender, EventArgs e)
        {
            // --- TOÀN BỘ LOGIC KHỞI TẠO VÀ TẢI DỮ LIỆU ĐƯA VÀO ĐÂY ---
            if (!this.DesignMode) // Chỉ chạy khi ứng dụng chạy, không phải trong Design Mode
            {
                // === 2. KHỞI TẠO (POOR MAN'S DI) ===
                IHoaDonNhapRepository hoaDonNhapRepo = new HoaDonNhapImpl();
                IChiTietHDNRepository chiTietRepo = new ChiTietHDNImpl();
                INhaCungCapRepository nhaCungCapRepo = new NhaCungCapImpl();
                INhanVienRepository nhanVienRepo = new NhanVienImpl();
                ISanPhamRepository sanPhamRepo = new SanPhamImpl();

                // Lưu lại repo để load ComboBox
                _nhaCungCapRepo = nhaCungCapRepo;
                _nhanVienRepo = nhanVienRepo;

                IHoaDonNhapService hoaDonNhapService = new HoaDonNhapService(
                    hoaDonNhapRepo, chiTietRepo, nhaCungCapRepo, nhanVienRepo, sanPhamRepo
                );

                _controller = new HoaDonNhapController(hoaDonNhapService);

                // Tải các ComboBox tìm kiếm
                LoadComboBoxes();

                // Tải danh sách hóa đơn (Chức năng chính bạn yêu cầu)
                LoadAllInvoices();

                // Cập nhật trạng thái nút (lúc đầu chưa chọn gì)
                UpdateUIState(null);
            }
        }

        #region === CÁC HÀM TẢI DỮ LIỆU (LOAD) ===

        /// <summary>
        /// Hàm chính: Tải toàn bộ HĐN lên DataGridView
        /// </summary>
        private void LoadAllInvoices()
        {
            // Kiểm tra _controller đã được khởi tạo chưa (phòng trường hợp DesignMode)
            if (_controller == null) return; // Thêm dòng này để an toàn hơn

            try
            {
                // 1. Gọi Controller
                List<HoaDonNhapResponse> danhSach = _controller.LayDanhSachHoaDon();

                // 2. Gán dữ liệu (Binding)
                dgvDanhSach.DataSource = null;
                dgvDanhSach.DataSource = danhSach;

                // 3. Cấu hình hiển thị cho lưới
                FormatInvoiceGrid();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// Cấu hình cột và tô màu cho DataGridView
        /// </summary>
        private void FormatInvoiceGrid()
        {
            if (dgvDanhSach.DataSource == null) return;

            // 1. Cấu hình Cột
            dgvDanhSach.Columns["TenTrangThai"].HeaderText = "Trạng Thái";
            dgvDanhSach.Columns["MaHDN"].HeaderText = "Mã HĐN";
            dgvDanhSach.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";
            dgvDanhSach.Columns["TenNV"].HeaderText = "Nhân Viên Lập";
            dgvDanhSach.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            dgvDanhSach.Columns["NgayDuyet"].HeaderText = "Ngày Duyệt";
            dgvDanhSach.Columns["TongTien"].HeaderText = "Tổng Tiền";

            // Định dạng tiền tệ
            dgvDanhSach.Columns["TongTien"].DefaultCellStyle.Format = "N0";

            // Ẩn các cột không cần thiết
            dgvDanhSach.Columns["MaNCC"].Visible = false;
            dgvDanhSach.Columns["MaNV"].Visible = false;
            dgvDanhSach.Columns["TrangThai"].Visible = false;
            dgvDanhSach.Columns["GhiChu"].Visible = false;

            if (dgvDanhSach.Columns.Contains("ChiTiet"))
            {
                dgvDanhSach.Columns["ChiTiet"].Visible = false;
            }

            // 2. Tô màu các dòng
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.DataBoundItem == null) continue;

                var trangThai = (TrangThaiHoaDonNhap)row.Cells["TrangThai"].Value;

                row.DefaultCellStyle.BackColor = SystemColors.Window;
                row.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Regular);
                row.DefaultCellStyle.ForeColor = SystemColors.ControlText;

                if (trangThai == TrangThaiHoaDonNhap.DaHuy)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                    row.DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                else if (trangThai == TrangThaiHoaDonNhap.TamLuu)
                {
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                }
            }
        }

        /// <summary>
        /// Tải dữ liệu cho các ComboBox tìm kiếm
        /// </summary>
        private void LoadComboBoxes()
        {
            LoadTrangThaiComboBox();
            LoadComboBoxNhaCungCap();
            LoadComboBoxNhanVien();
        }

        /// <summary>
        /// Tải ComboBox Trạng Thái (Tải thủ công)
        /// </summary>
        private void LoadTrangThaiComboBox()
        {
            var dataSource = new List<object>
            {
                new { Value = (byte?)null, Display = "--- Tất cả trạng thái ---" },
                new { Value = (byte?)TrangThaiHoaDonNhap.TamLuu, Display = "Tạm lưu" },
                new { Value = (byte?)TrangThaiHoaDonNhap.HoatDong, Display = "Hoạt động" },
                new { Value = (byte?)TrangThaiHoaDonNhap.DaHuy, Display = "Đã hủy" }
            };

            cmbSearchTrangThai.DataSource = dataSource;
            cmbSearchTrangThai.DisplayMember = "Display";
            cmbSearchTrangThai.ValueMember = "Value";
            cmbSearchTrangThai.SelectedIndex = 0;
        }

        /// <summary>
        /// Tải ComboBox Nhà cung cấp (Tải từ CSDL)
        /// </summary>
        private void LoadComboBoxNhaCungCap()
        {
            // Kiểm tra _nhaCungCapRepo đã được khởi tạo chưa
            if (_nhaCungCapRepo == null) return;

            try
            {
                var list = _nhaCungCapRepo.GetAll();
                list.Insert(0, new NhaCungCap { MaNCC = "", TenNCC = "--- Tất cả NCC ---" });

                cmbSearchNCC.DataSource = list;
                cmbSearchNCC.DisplayMember = "TenNCC";
                cmbSearchNCC.ValueMember = "MaNCC";
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải danh sách NCC: {ex.Message}"); }
        }

        /// <summary>
        /// Tải ComboBox Nhân viên (Tải từ CSDL)
        /// </summary>
        private void LoadComboBoxNhanVien()
        {
            // Kiểm tra _nhanVienRepo đã được khởi tạo chưa
            if (_nhanVienRepo == null) return;

            try
            {
                var list = _nhanVienRepo.GetAll();
                list.Insert(0, new NhanVien { MaNV = "", HoTen = "--- Tất cả NV ---" });

                cmbSearchNhanVien.DataSource = list;
                cmbSearchNhanVien.DisplayMember = "HoTen";
                cmbSearchNhanVien.ValueMember = "MaNV";
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải danh sách NV: {ex.Message}"); }
        }

        #endregion === CÁC HÀM TẢI DỮ LIỆU (LOAD) ===

        #region === CÁC HÀM XỬ LÝ SỰ KIỆN (CHỜ IMPLEMENT) ===

        /// <summary>
        /// Cập nhật trạng thái các nút Duyệt, Hủy, Sửa
        /// </summary>
        private void UpdateUIState(TrangThaiHoaDonNhap? trangThai)
        {
            if (btnThem == null || btnXemSua == null || btnDuyet == null || btnHuy == null) return; // An toàn trong DesignMode

            if (trangThai == null) // Không chọn dòng nào
            {
                btnThem.Enabled = true;
                btnXemSua.Enabled = false;
                btnDuyet.Enabled = false;
                btnHuy.Enabled = false;
            }
            else if (trangThai == TrangThaiHoaDonNhap.TamLuu)
            {
                btnThem.Enabled = true;
                btnXemSua.Enabled = true; // Cho phép Xem/Sửa
                btnDuyet.Enabled = true; // Cho phép Duyệt
                btnHuy.Enabled = true; // Cho phép Hủy
            }
            else if (trangThai == TrangThaiHoaDonNhap.HoatDong)
            {
                btnThem.Enabled = true;
                btnXemSua.Enabled = true; // Chỉ cho Xem (logic khóa ở Form Detail)
                btnDuyet.Enabled = false; // Đã duyệt rồi
                btnHuy.Enabled = true; // Cho phép Hủy (nếu an toàn)
            }
            else if (trangThai == TrangThaiHoaDonNhap.DaHuy)
            {
                btnThem.Enabled = true;
                btnXemSua.Enabled = true; // Chỉ cho Xem
                btnDuyet.Enabled = false;
                btnHuy.Enabled = false; // Đã hủy rồi
            }
        }

        /// <summary>
        /// Sự kiện khi thay đổi dòng chọn trên lưới
        /// </summary>
        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            // Đảm bảo dgvDanhSach đã được khởi tạo và có dữ liệu
            if (dgvDanhSach == null || dgvDanhSach.CurrentRow == null || dgvDanhSach.CurrentRow.DataBoundItem == null)
            {
                UpdateUIState(null);
                return;
            }

            // Lấy trạng thái của dòng đang chọn
            var trangThai = (TrangThaiHoaDonNhap)dgvDanhSach.CurrentRow.Cells["TrangThai"].Value;
            // Cập nhật các nút
            UpdateUIState(trangThai);
        }

        // (Bạn cần copy các hàm xử lý nút bấm (btnTimKiem_Click, btnThem_Click, v.v.)
        // từ các câu trả lời trước vào đây)

        #endregion === CÁC HÀM XỬ LÝ SỰ KIỆN (CHỜ IMPLEMENT) ===
    }
}