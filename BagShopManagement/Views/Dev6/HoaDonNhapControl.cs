using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev6
{
    public partial class HoaDonNhapControl : UserControl
    {
        private HoaDonNhapController _controller;

        public HoaDonNhapControl()
        {
            InitializeComponent();

            // Đăng ký sự kiện Load ở đây thay vì trong Controller
            this.Load += UserControl1_Load;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            // ---- KHỞI TẠO CÁC LỚP (Dependency Injection thủ công) ----
            IHoaDonNhapRepository hdnRepo = new HoaDonNhapImpl();
            IChiTietHDNRepository ctRepo = new ChiTietHDNImpl();
            INhaCungCapRepository nccRepo = new NhaCungCapImpl();
            INhanVienRepository nvRepo = new NhanVienImpl();

            // 2. Service
            IHoaDonNhapService service = new HoaDonNhapService(hdnRepo, ctRepo, nccRepo, nvRepo);

            // 3. Controller
            _controller = new HoaDonNhapController(this, service);
            // --------------------------------------------------------

            // Gắn sự kiện click từ Designer vào các Event Handler
            // (Controller đã tự làm việc này trong constructor của nó)
            this.btnTimKiem.Click += (s, ev) => TimKiemClicked?.Invoke(this, EventArgs.Empty);
            this.btnXoa.Click += (s, ev) => XoaClicked?.Invoke(this, EventArgs.Empty);
            this.btnThemMoi.Click += (s, ev) => ThemMoiClicked?.Invoke(this, EventArgs.Empty);
            this.btnSua.Click += (s, ev) => SuaClicked?.Invoke(this, EventArgs.Empty);

            // Thêm 2 CheckBox để cho phép lọc theo ngày
            AddDateFilterCheckBoxes();
        }

        // Thêm CheckBox để Bật/Tắt bộ lọc ngày
        private void AddDateFilterCheckBoxes()
        {
            CheckBox chkTuNgay = new CheckBox { Text = "", Checked = false, Location = new System.Drawing.Point(150, 63) };
            CheckBox chkDenNgay = new CheckBox { Text = "", Checked = false, Location = new System.Drawing.Point(552, 63) };

            groupBox1.Controls.Add(chkTuNgay);
            groupBox1.Controls.Add(chkDenNgay);

            dtpTuNgay.Enabled = false;
            dtpDenNgay.Enabled = false;

            chkTuNgay.CheckedChanged += (s, e) => dtpTuNgay.Enabled = chkTuNgay.Checked;
            chkDenNgay.CheckedChanged += (s, e) => dtpDenNgay.Enabled = chkDenNgay.Checked;
        }

        #region "Events cho Controller lắng nghe"

        public event EventHandler TimKiemClicked;

        public event EventHandler XoaClicked;

        public event EventHandler ThemMoiClicked;

        public event EventHandler SuaClicked;

        #endregion "Events cho Controller lắng nghe"

        #region "Các thuộc tính (Properties) để Controller lấy dữ liệu từ UI"

        public string MaHDNFilter => textBox1.Text.Trim();

        // Trả về null nếu CheckBox không được chọn
        public DateTime? TuNgayFilter => dtpTuNgay.Enabled ? dtpTuNgay.Value : (DateTime?)null;

        public DateTime? DenNgayFilter => dtpDenNgay.Enabled ? dtpDenNgay.Value : (DateTime?)null;

        public string MaNCCFilter => cboNhaCungCap.SelectedValue?.ToString() ?? "";
        public string MaNVFilter => cboNhanVien.SelectedValue?.ToString() ?? "";

        // Lấy MaHDN của dòng đang được chọn
        public string SelectedMaHDN
        {
            get
            {
                if (dgvHoaDonNhap.SelectedRows.Count > 0)
                {
                    // Lấy giá trị từ ô "MaHDN" của dòng được chọn
                    return dgvHoaDonNhap.SelectedRows[0].Cells["MaHDN"].Value?.ToString();
                }
                return null;
            }
        }

        #endregion "Các thuộc tính (Properties) để Controller lấy dữ liệu từ UI"

        #region "Các phương thức (Methods) để Controller cập nhật UI"

        // Cập nhật lưới
        public void SetHoaDonNhapDataSource(List<HoaDonNhapResponse> data)
        {
            dgvHoaDonNhap.DataSource = null; // Xóa dữ liệu cũ
            dgvHoaDonNhap.DataSource = data;

            // Cấu hình cột (chỉ cần làm 1 lần)
            if (dgvHoaDonNhap.Columns.Count > 0)
            {
                dgvHoaDonNhap.Columns["MaHDN"].HeaderText = "Mã HĐN";
                dgvHoaDonNhap.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";
                dgvHoaDonNhap.Columns["TenNV"].HeaderText = "Nhân Viên Lập";
                dgvHoaDonNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dgvHoaDonNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvHoaDonNhap.Columns["GhiChu"].HeaderText = "Ghi Chú";

                dgvHoaDonNhap.Columns["TongTien"].DefaultCellStyle.Format = "N0"; // Định dạng số
                dgvHoaDonNhap.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvHoaDonNhap.Columns["TenNCC"].FillWeight = 150; // Cho cột NCC rộng hơn
            }
        }

        // Cập nhật thanh trạng thái
        public void SetTongCong(int count)
        {
            tsslTongCong.Text = $"Tổng cộng: {count} hóa đơn nhập";
        }

        // Cập nhật ComboBox Nhà cung cấp
        public void SetNhaCungCapDataSource(List<NhaCungCap> data)
        {
            cboNhaCungCap.DataSource = data;
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
        }

        // Cập nhật ComboBox Nhân viên
        public void SetNhanVienDataSource(List<NhanVien> data)
        {
            cboNhanVien.DataSource = data;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
        }

        #endregion "Các phương thức (Methods) để Controller cập nhật UI"
    }
}