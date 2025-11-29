using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing; // <-- BỔ SUNG: Cần cho Color

namespace BagShopManagement.Views.Controls
{
    // Thêm 'partial' để sửa lỗi 'InitializeComponent' (từ lỗi cũ)
    public partial class SideBarControl : UserControl
    {
        // === BỔ SUNG: Biến và Hằng số màu (Để sửa lỗi highlight) ===
        private Button _currentButton = null; // Biến lưu nút đang được chọn

        // Màu nền mặc định (Xám xanh)
        private readonly Color _defaultButtonBack = Color.FromArgb(30, 41, 59);

        private readonly Color _defaultButtonText = Color.FromArgb(255, 255, 255); // <-- ĐÃ ĐỔI THÀNH MÀU TRẮNG

        // Màu nút ĐANG CHỌN (Xanh)
        private readonly Color _activeButtonBack = Color.FromArgb(0, 123, 255);

        private readonly Color _activeButtonText = Color.FromArgb(255, 255, 255);

        // === Events của Dev4, Dev6, Dev2, Dev3 (Từ file cơ sở) ===
        public event EventHandler ShowHoaDonNhapClicked;

        public event EventHandler ShowBanHangClicked;

        public event EventHandler ShowBaoCaoThongKeClicked; // (Dùng cho btnBCTK_Click)

        public event EventHandler SanPhamClicked;

        public event EventHandler DanhMucClicked;

        public event EventHandler ShowQuanLyHoaDonClicked;

        public event EventHandler KhachHangClicked;

        public event EventHandler NhaCungCapClicked;

        public event EventHandler ShowTonKhoClicked;

        public event EventHandler ShowKhuyenMaiClicked;

        // === Events của Dev1 (Bổ sung) ===
        public event EventHandler ShowEmployeeManagementClicked;

        public event EventHandler ShowProfileClicked;

        public event EventHandler ShowDangXuatClicked;

        public SideBarControl()
        {
            InitializeComponent();

            // BỔ SUNG: Áp dụng style màu nền ban đầu
            ApplyInitialStyles();
        }

        // BỔ SUNG: Hàm áp dụng style ban đầu
        private void ApplyInitialStyles()
        {
            // 1. Đặt màu nền chính (Designer của bạn dùng 'panel1')

            // 2. Lặp qua các nút trong panel1 (dựa theo Designer.cs của bạn)
            foreach (Control control in this.tableLayoutPanel1.Controls)
            {
                if (control is Button button && button.Name != "button1") // Trừ nút DashBoard
                {
                    // 3. Thiết lập màu mặc định (GHI ĐÈ lên Designer)
                    button.BackColor = _defaultButtonBack;
                    button.ForeColor = _defaultButtonText;

                    // (Các style Flat, MouseOver... giữ nguyên từ Designer của bạn)
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseDownBackColor = _activeButtonBack;
                    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);

                    // === BỔ SUNG MỚI: CĂN LỀ TRÁI ===

                    // === KẾT THÚC BỔ SUNG MỚI ===
                }
            }
        }

        // --- Các hàm _Click của nhóm bạn (ĐÃ THÊM LOGIC ĐỔI MÀU) ---
        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            ShowHoaDonNhapClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            ShowBanHangClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            ShowQuanLyHoaDonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            ShowBaoCaoThongKeClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            SanPhamClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            DanhMucClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            KhachHangClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            NhaCungCapClicked?.Invoke(this, EventArgs.Empty);
        }

        // --- Các hàm _Click của Dev1 (Bổ sung) ---
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            ShowEmployeeManagementClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            ShowProfileClicked?.Invoke(this, EventArgs.Empty);
        }

        // --- Các hàm _Click của Dev5 (Bổ sung từ file cơ sở) ---
        private void btnTonKho_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            ShowTonKhoClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
            SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
            ShowKhuyenMaiClicked?.Invoke(this, EventArgs.Empty);
        }

        // === BỔ SUNG: 2 HÀM HELPER (ĐỔI MÀU) ===

        // Hàm helper đặt màu Active (Xanh)
        private void SetButtonActive(Button button)
        {
            if (button == null) return;
            button.BackColor = _activeButtonBack;
            button.ForeColor = _activeButtonText;
            _currentButton = button; // Lưu lại nút vừa được chọn
        }

        // Hàm helper reset màu Mặc định (Xám) - ĐÃ SỬA LỖI
        private void ResetButtonDefault(Button button)
        {
            if (button == null) return;
            // SỬA LỖI: Lấy màu từ biến hằng
            button.BackColor = _defaultButtonBack;
            button.ForeColor = _defaultButtonText;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Kích hoạt sự kiện để Form cha xử lý
                ResetButtonDefault(_currentButton); // THÊM DÒNG NÀY
                SetButtonActive((Button)sender);      // THÊM DÒNG NÀY
                ShowDangXuatClicked?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}