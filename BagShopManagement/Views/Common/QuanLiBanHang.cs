using BagShopManagement.Views.Controls;
using BagShopManagement.Views.Dev2;
using BagShopManagement.Views.Dev3;
using BagShopManagement.Views.Dev4.Dev4_POS;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using BagShopManagement.Views.Dev6;
using Microsoft.Extensions.DependencyInjection;
using BagShopManagement.Views.Dev5;

// === BỔ SUNG CÁC USING CHO DEV1 ===
using BagShopManagement.Views.Dev1; // Cần cho ucProfile, ucEmployeeManagement
using BagShopManagement.Utils; // Cần cho UserContext

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
            sideBarControl.ShowProfileClicked += (s, ev) => ShowUserControl<ucProfile>();
            sideBarControl.ShowEmployeeManagementClicked += (s, ev) => ShowUserControl<ucEmployeeManagement>();


            // === BƯỚC 4: XỬ LÝ PHÂN QUYỀN (DỰA TRÊN image_e2d1dc.png) ===
            //
            // LƯU Ý: Code này YÊU CẦU các nút trong 'SideBarControl.Designer.cs'
            // phải được đặt là 'public' (chọn nút -> Properties -> Modifiers -> Public)
            //
            if (UserContext.MaQuyenList != null)
            {
                // (Giả sử tên các nút khớp với hình ảnh)

                // Q001: Quản lý sản phẩm (Sản phẩm, Danh mục)
                sideBarControl.btnSanPham.Enabled = UserContext.MaQuyenList.Contains("Q001");
                sideBarControl.btnDanhMuc.Enabled = UserContext.MaQuyenList.Contains("Q001");

                // Q002: Quản lý hóa đơn (Bán hàng, Hóa đơn bán)
                sideBarControl.btnBanHang.Enabled = UserContext.MaQuyenList.Contains("Q002");
                sideBarControl.btnHoaDonBan.Enabled = UserContext.MaQuyenList.Contains("Q002");

                // Q003: Quản lý nhập hàng (Nhà cung cấp, Tồn kho, Hóa đơn nhập)
                sideBarControl.btnNCC.Enabled = UserContext.MaQuyenList.Contains("Q003");
                sideBarControl.btnTonKho.Enabled = UserContext.MaQuyenList.Contains("Q003");
                sideBarControl.btnHoaDonNhap.Enabled = UserContext.MaQuyenList.Contains("Q003");

                // Q004: Quản lý khách hàng
                sideBarControl.btnKhachHang.Enabled = UserContext.MaQuyenList.Contains("Q004");

                // Q005: Quản lý nhân viên (Dev1)
                sideBarControl.btnNhanVien.Enabled = UserContext.MaQuyenList.Contains("Q005");

                // Q006: Xem báo cáo
                sideBarControl.btnBCTK.Enabled = UserContext.MaQuyenList.Contains("Q006");

                // "Tài khoản" (Profile) luôn luôn bật
                sideBarControl.btnTaiKhoan.Enabled = true;

                // (Nút "Khuyến Mãi" không có trong bảng Quyen, tạm thời gán theo Q001)
                sideBarControl.btnKhuyenMai.Enabled = UserContext.MaQuyenList.Contains("Q001");
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