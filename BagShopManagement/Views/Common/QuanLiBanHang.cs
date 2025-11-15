// === Using của nhóm bạn (Dev2, 3, 4, 6) ===
using BagShopManagement.Views.Controls;
using BagShopManagement.Views.Dev2;
using BagShopManagement.Views.Dev3;
using BagShopManagement.Views.Dev4;
using BagShopManagement.Views.Dev4.Dev4_POS;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using BagShopManagement.Views.Dev6;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

// === BỔ SUNG CÁC USING CHO DEV1 ===
using BagShopManagement.Views; // Cần cho LoginForm
using BagShopManagement.Views.Dev1; // Cần cho ucProfile, ucEmployeeManagement
using BagShopManagement.Utils; // Cần cho UserContext
using System.Linq; // Cần cho UserContext.MaQuyenList.Contains()

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

        // Hàm ShowUserControl<T> (Đã hợp nhất logic)
        // (Đảm bảo đóng Form con khi mở UserControl)
        private void ShowUserControl<T>() where T : UserControl
        {
            try
            {
                if (_currentControl != null && _currentControl.GetType() == typeof(T))
                    return;

                // BỔ SUNG: Đóng Form con (nếu đang hiển thị) trước khi mở UC
                if (_currentChildForm != null)
                {
                    mainPanel.Controls.Remove(_currentChildForm);
                    _currentChildForm.Dispose();
                    _currentChildForm = null;
                }

                var newControl = _serviceProvider.GetRequiredService<T>();
                newControl.Dock = DockStyle.Fill;

                if (_currentControl != null)
                {
                    mainPanel.Controls.Remove(_currentControl);
                    _currentControl.Dispose();
                }

                mainPanel.Controls.Add(newControl);
                _currentControl = newControl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải module: {ex.Message}", "Lỗi nghiêm trọng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // (Các hàm comment-out của nhóm bạn, giữ nguyên)
        //private void Sidebar_KhachHangClicked(object sender, EventArgs e)
        //{...}
        //private void Sidebar_NhaCungCapClicked(object sender, EventArgs e)
        //{...}

        // --- (Hàm ShowFormAsControl<T> (nếu bạn cần) ---
        // (Đã bổ sung logic đóng UserControl khi mở Form)
        private void ShowFormAsControl<T>() where T : Form
        {
            try
            {
                if (_currentChildForm != null && _currentChildForm.GetType() == typeof(T))
                    return;

                // BỔ SUNG: Đóng UC (nếu đang hiển thị) trước khi mở Form
                if (_currentControl != null)
                {
                    mainPanel.Controls.Remove(_currentControl);
                    _currentControl.Dispose();
                    _currentControl = null;
                }

                // Đóng form cũ nếu có
                if (_currentChildForm != null)
                {
                    mainPanel.Controls.Remove(_currentChildForm);
                    _currentChildForm.Dispose();
                    _currentChildForm = null;
                }

                var form = _serviceProvider.GetRequiredService<T>();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(form);
                _currentChildForm = form;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị module: {ex.Message}",
                                "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- HÀM LOAD ĐÃ ĐƯỢC HỢP NHẤT ---
        private void QuanLiBanHang_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            // === BƯỚC 1: XỬ LÝ ĐĂNG NHẬP (BỔ SUNG TỪ DEV1) ===
            // (Giữ nguyên logic "Login-First" của bạn:
            // Program.cs chạy LoginForm trước, sau đó MainForm này mới được load)
            if (!UserContext.IsLoggedIn)
            {
                MessageBox.Show("Lỗi nghiêm trọng: Không tìm thấy thông tin đăng nhập.", "Lỗi phiên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // === BƯỚC 2: CẬP NHẬT GIAO DIỆN (BỔ SUNG TỪ DEV1) ===
            // (Giả sử bạn có 1 ToolStripStatusLabel tên là 'tsslUserInfo')
            // tsslUserInfo.Text = $"Người dùng: {UserContext.HoTen} ({UserContext.MaVaiTro})";

            // === BƯỚC 3: GÁN SỰ KIỆN CHO SIDEBAR (HỢP NHẤT) ===

            // (Giả sử instance của SideBarControl tên là 'sideBarControl')

            // Dev6 Events (Đã có)
            sideBarControl.ShowHoaDonNhapClicked += (s, ev) => ShowUserControl<ucHoaDonNhapList>();
            sideBarControl.ShowBaoCaoThongKeClicked += (s, ev) => ShowUserControl<ucBaoCaoThongKe>();

            // Dev4 Events (Đã có)
            sideBarControl.ShowBanHangClicked += (s, ev) => ShowUserControl<UC_POS>();

            // Dev4 - Hóa đơn bán (Quản lý hóa đơn)
            sideBarControl.ShowQuanLyHoaDonClicked += (s, ev) => ShowUserControl<UC_HoaDonBan>();

            // Dev2 Events (Đã có)
            sideBarControl.SanPhamClicked += (s, ev) => ShowUserControl<SanPhamControl>();
            sideBarControl.ShowQuanLyHoaDonClicked += (s, ev) => ShowUserControl<UC_HoaDonBan>();

            // Dev3 Events (Đã có)
            sideBarControl.NhaCungCapClicked += (s, ev) => ShowUserControl<NhaCungCapControl>();
            sideBarControl.KhachHangClicked += (s, ev) => ShowUserControl<KhachHangControl>();

            // Dev2 - Danh mục (Đã có)
            sideBarControl.DanhMucClicked += (s, e) =>
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

            // === Dev1 Events (BỔ SUNG) ===
            // (Bạn cần thêm 2 sự kiện 'ShowProfileClicked' và 'ShowEmployeeManagementClicked'
            // vào file SideBarControl.cs của nhóm bạn)

            // Gắn sự kiện "Tài khoản" (Profile)
            sideBarControl.ShowProfileClicked += (s, ev) => ShowUserControl<ucProfile>();

            // Gắn sự kiện "Nhân viên" (Employee Management)
            sideBarControl.ShowEmployeeManagementClicked += (s, ev) => ShowUserControl<ucEmployeeManagement>();

            // === BƯỚC 4: XỬ LÝ PHÂN QUYỀN (BỔ SUNG TỪ DEV1) ===
            // (Bạn cần đặt các nút trong SideBarControl là 'public'
            // bằng cách chọn nút -> Properties -> Modifiers -> Public)

            if (UserContext.MaQuyenList != null)
            {
                // (Giả sử tên nút là btnNhanVien và btnTaiKhoan)

                // Phân quyền nút "Nhân viên"
                // (Dựa theo image_174f61.png, 'Quản lý nhân viên' là Q005)
                sideBarControl.btnNhanVien.Enabled = UserContext.MaQuyenList.Contains("Q005");

                // Nút "Tài khoản" (Profile) luôn luôn bật
                sideBarControl.btnTaiKhoan.Enabled = true;

                // (Các Dev khác có thể thêm logic phân quyền của họ ở đây)
                // sideBarControl.btnSanPham.Enabled = UserContext.MaQuyenList.Contains("Q001");
                // ...
            }
        }

        // --- (Các hàm load trống của nhóm bạn, giữ nguyên) ---
        private void sideBarControl_Load(object sender, EventArgs e)
        {
        }

        private void hoaDonNhapControl2_Load(object sender, EventArgs e)
        {
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}