using BagShopManagement.Views.Controls;
using BagShopManagement.Views.Dev4.Dev4_POS;
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

        // --- (Hàm ShowUserControl<T> của bạn, giữ nguyên) ---
        private void ShowUserControl<T>() where T : UserControl
        {
            #region Code của nhóm bạn (Giữ nguyên)
            try
            {
                if (_currentControl != null && _currentControl.GetType() == typeof(T))
                    return;

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
            #endregion
        }

        // --- (Hàm ShowFormAsControl<T> của bạn, giữ nguyên) ---
        private void ShowFormAsControl<T>() where T : Form
        {
            #region Code của nhóm bạn (Giữ nguyên)
            try
            {
                if (_currentChildForm != null && _currentChildForm.GetType() == typeof(T))
                    return;

                if (_currentControl != null)
                {
                    mainPanel.Controls.Remove(_currentControl);
                    _currentControl.Dispose();
                    _currentControl = null;
                }

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
            #endregion
        }

        // --- HÀM LOAD ĐÃ SỬA LỖI (BỎ GỌI LOGINFORM) ---
        private void QuanLiBanHang_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            // === BƯỚC 1: XỬ LÝ ĐĂNG NHẬP ===
            // (Giữ nguyên logic "Login-First" của bạn: 
            // chạy LoginForm trước, sau đó MainForm này mới được load)
            if (!UserContext.IsLoggedIn)
            {
                MessageBox.Show("Lỗi nghiêm trọng: Không tìm thấy thông tin đăng nhập.", "Lỗi phiên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // === BƯỚC 2: CẬP NHẬT GIAO DIỆN (Ví dụ: Thanh trạng thái) ===
            // tsslUserInfo.Text = $"Người dùng: {UserContext.HoTen} ({UserContext.MaVaiTro})";


            // === BƯỚC 3: GÁN SỰ KIỆN CHO SIDEBAR (ĐÃ BỔ SUNG DEV1) ===

            // (Giả sử instance của SideBarControl tên là 'sideBarControl')

            // Dev6 Events (Đã có)
            sideBarControl.ShowHoaDonNhapClicked += (s, ev) => ShowUserControl<ucHoaDonNhapList>();
            sideBarControl.ShowTestClicked += (s, ev) => ShowUserControl<TEST>();

            // Dev4 Events (Đã có)
            sideBarControl.ShowBanHangClicked += (s, ev) => ShowUserControl<UC_POS>();

            // === Dev1 Events (Bổ sung tại đây) ===
            // Gắn sự kiện "Tài khoản" (Profile)
            sideBarControl.ShowProfileClicked += (s, ev) => ShowUserControl<ucProfile>();

            // Gắn sự kiện "Nhân viên" (Employee Management)
            sideBarControl.ShowEmployeeManagementClicked += (s, ev) => ShowUserControl<ucEmployeeManagement>();


            // === BƯỚC 4: XỬ LÝ PHÂN QUYỀN (ẨN/HIỆN NÚT) ===
            // (Bạn cần đặt các nút trong SideBarControl là 'public'
            // bằng cách chọn nút -> Properties -> Modifiers -> Public)

            if (UserContext.MaQuyenList != null)
            {
                //     // Lấy các nút public từ sideBarControl
                //     // (Giả sử tên nút là btnNhanVien và btnTaiKhoan)

                //     // Ẩn/hiện nút "Nhân viên"
                //     // (Dựa theo image_174f61.png, 'Quản lý nhân viên' là Q005)
                sideBarControl.btnNhanVien.Enabled = UserContext.MaQuyenList.Contains("Q005");

                //     // Nút "Tài khoản" (Profile) luôn luôn hiển thị cho người đã đăng nhập
                sideBarControl.btnTaiKhoan.Enabled = true;
            }
        }

        // --- (Các hàm load trống, giữ nguyên) ---
        private void sideBarControl_Load(object sender, EventArgs e)
        {
        }

        private void hoaDonNhapControl2_Load(object sender, EventArgs e)
        {
        }
    }
}