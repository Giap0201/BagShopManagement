using BagShopManagement.Utils;
using BagShopManagement.Views.Controls;
using BagShopManagement.Views.Dev1;
using BagShopManagement.Views.Dev2;
using BagShopManagement.Views.Dev3;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using BagShopManagement.Views.Dev4.Dev4_POS;
using BagShopManagement.Views.Dev5;
using BagShopManagement.Views.Dev6;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Common
{
    public partial class QuanLiBanHang : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private UserControl _currentControl = null;
        private Form _currentChildForm = null;

        public QuanLiBanHang(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        // Hàm ShowUserControl<T>: Đóng Form con trước khi mở UC mới
        private void ShowUserControl<T>() where T : UserControl
        {
            try
            {
                if (_currentControl != null && _currentControl.GetType() == typeof(T))
                    return;

                // 1. Đóng Form con (nếu đang hiển thị)
                if (_currentChildForm != null)
                {
                    ucPanel.Controls.Remove(_currentChildForm);
                    _currentChildForm.Dispose();
                    _currentChildForm = null;
                }

                // 2. Xóa UC cũ
                if (_currentControl != null)
                {
                    ucPanel.Controls.Remove(_currentControl);
                    _currentControl.Dispose();
                }

                // 3. Hiển thị UC mới
                var newControl = _serviceProvider.GetRequiredService<T>();
                newControl.Dock = DockStyle.Fill;
                ucPanel.Controls.Add(newControl);
                _currentControl = newControl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải module: {ex.Message}", "Lỗi nghiêm trọng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm ShowFormAsControl<T>: Đóng UC trước khi mở Form con mới
        private void ShowFormAsControl<T>() where T : Form
        {
            try
            {
                if (_currentChildForm != null && _currentChildForm.GetType() == typeof(T))
                    return;

                // 1. Xóa UC cũ (nếu đang hiển thị)
                if (_currentControl != null)
                {
                    ucPanel.Controls.Remove(_currentControl);
                    _currentControl.Dispose();
                    _currentControl = null;
                }

                // 2. Đóng Form cũ
                if (_currentChildForm != null)
                {
                    ucPanel.Controls.Remove(_currentChildForm);
                    _currentChildForm.Dispose();
                    _currentChildForm = null;
                }

                // 3. Hiển thị Form mới
                var form = _serviceProvider.GetRequiredService<T>();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                ucPanel.Controls.Add(form);
                _currentChildForm = form;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị module: {ex.Message}",
                    "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLiBanHang_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            // === BƯỚC 1: KIỂM TRA ĐĂNG NHẬP ===
            if (!UserContext.IsLoggedIn)
            {
                MessageBox.Show("Lỗi nghiêm trọng: Không tìm thấy thông tin đăng nhập.", "Lỗi phiên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // === BƯỚC 2: GÁN SỰ KIỆN CHO SIDEBAR ===

            // Dev5 Events
            sideBarControl.ShowTonKhoClicked += (s, ev) => ShowUserControl<TonKhoControl>();
            sideBarControl.ShowKhuyenMaiClicked += (s, ev) => ShowUserControl<PromotionControl>();

            // Dev6 Events
            sideBarControl.ShowHoaDonNhapClicked += (s, ev) => ShowUserControl<ucHoaDonNhapList>();
            sideBarControl.ShowBaoCaoThongKeClicked += (s, ev) => ShowUserControl<ucBaoCaoThongKe>();

            // Dev4 Events
            sideBarControl.ShowBanHangClicked += (s, ev) => ShowUserControl<UC_POS>();
            sideBarControl.ShowQuanLyHoaDonClicked += (s, ev) => ShowUserControl<UC_HoaDonBan>();

            // Dev3 Events
            sideBarControl.NhaCungCapClicked += (s, ev) => ShowUserControl<NhaCungCapControl>();
            sideBarControl.KhachHangClicked += (s, ev) => ShowUserControl<KhachHangControl>();

            // Dev2 Events
            sideBarControl.SanPhamClicked += (s, ev) => ShowUserControl<SanPhamControl>();
            sideBarControl.DanhMucClicked += (s, ev) =>
            {
                ShowUserControl<DanhMucMenuControl>();
                if (_currentControl is DanhMucMenuControl danhMucCtrl)
                {
                    danhMucCtrl.ShowLoaiTuiClicked += (s2, e2) => ShowUserControl<LoaiTuiControl>();
                    danhMucCtrl.ShowThuongHieuClicked += (s2, e2) => ShowUserControl<ThuongHieuControl>();
                    danhMucCtrl.ShowMauSacClicked += (s2, e2) => ShowUserControl<MauSacControl>();
                    danhMucCtrl.ShowChatLieuClicked += (s2, e2) => ShowUserControl<ChatLieuControl>();
                    danhMucCtrl.ShowKichThuocClicked += (s2, e2) => ShowUserControl<KichThuocControl>();
                }
            };

            // Dev1 Events
            sideBarControl.ShowProfileClicked += (s, ev) => ShowUserControl<ucProfile>();
            sideBarControl.ShowEmployeeManagementClicked += (s, ev) => ShowUserControl<ucEmployeeManagement>();

            // === BƯỚC 3: SỰ KIỆN ĐĂNG XUẤT (QUAN TRỌNG) ===
            // Lưu ý: Nếu bên SideBarControl bạn đặt tên là 'ShowDangXuatClicked' thì sửa lại tên ở đây
            sideBarControl.ShowDangXuatClicked += (s, ev) =>
            {
                UserContext.Logout();

                // Đóng Form chính -> Code sẽ quay về LoginForm (do ShowDialog bên kia kết thúc)
                this.Close();
            };

            // === BƯỚC 4: XỬ LÝ PHÂN QUYỀN ===
            if (UserContext.MaQuyenList != null)
            {
                // Q001: Quản lý sản phẩm
                sideBarControl.btnSanPham.Enabled = UserContext.MaQuyenList.Contains("Q001");
                sideBarControl.btnDanhMuc.Enabled = UserContext.MaQuyenList.Contains("Q001");
                sideBarControl.btnKhuyenMai.Enabled = UserContext.MaQuyenList.Contains("Q001");

                // Q002: Quản lý hóa đơn bán
                sideBarControl.btnBanHang.Enabled = UserContext.MaQuyenList.Contains("Q002");
                sideBarControl.btnHoaDonBan.Enabled = UserContext.MaQuyenList.Contains("Q002");

                // Q003: Quản lý nhập hàng
                sideBarControl.btnNCC.Enabled = UserContext.MaQuyenList.Contains("Q003");
                sideBarControl.btnTonKho.Enabled = UserContext.MaQuyenList.Contains("Q003");
                sideBarControl.btnHoaDonNhap.Enabled = UserContext.MaQuyenList.Contains("Q003");

                // Q004: Quản lý khách hàng
                sideBarControl.btnKhachHang.Enabled = UserContext.MaQuyenList.Contains("Q004");

                // Q005: Quản lý nhân viên
                sideBarControl.btnNhanVien.Enabled = UserContext.MaQuyenList.Contains("Q005");

                // Q006: Xem báo cáo
                sideBarControl.btnBCTK.Enabled = UserContext.MaQuyenList.Contains("Q006");

                // Tài khoản luôn mở
                sideBarControl.btnTaiKhoan.Enabled = true;
            }
        }

        // Các hàm sự kiện trống (nếu có từ Designer cũ)
        private void sideBarControl_Load(object sender, EventArgs e)
        { }

        private void hoaDonNhapControl2_Load(object sender, EventArgs e)
        { }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        { }
    }
}