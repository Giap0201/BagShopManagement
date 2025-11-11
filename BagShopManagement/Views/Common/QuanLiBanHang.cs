using BagShopManagement.Controllers;
using BagShopManagement.Controllers;

using BagShopManagement.Models;
using BagShopManagement.Models;

using BagShopManagement.Views.Dev6;
using BagShopManagement.Views.Dev6; // Thêm

using BagShopManagement.Views.Dev4.Dev4_POS;
using Microsoft.Extensions.DependencyInjection; // Thêm

using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using System;

using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

using System;
using System.ComponentModel;

using System.Collections.Generic;
using System.Data;

using System.ComponentModel;
using System.Drawing;

using System.Data;
using System.Linq;

using System.Drawing;
using System.Text;

using System.Linq;
using System.Threading.Tasks;

using System.Text;
using System.Windows.Forms;

using System.Threading.Tasks;
using BagShopManagement.Views.Dev4.Dev4_POS;

using System.Windows.Forms;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;

using Microsoft.Extensions.DependencyInjection;

namespace BagShopManagement.Views.Common

{
    namespace BagShopManagement.Views.Common

    public partial class QuanLiBanHang : Form
    {

    {    public partial class QuanLiBanHang : Form

        private readonly IServiceProvider _serviceProvider;    {

        private Form? _currentChildForm; private readonly IServiceProvider _serviceProvider;

        private UserControl? _currentControl;<<<<<<< HEAD

        private UserControl _currentControl = null; // Để lưu trữ UC đang hiển thị

        public QuanLiBanHang(IServiceProvider serviceProvider)=======

        {        private Form? _currentChildForm;

        InitializeComponent();>>>>>>> ndt-dev4

        _serviceProvider = serviceProvider;

        public QuanLiBanHang(IServiceProvider serviceProvider)

            // Đăng ký event handler cho menu click (Dev4)        {

            sideBarControl1.MenuItemClicked += SideBarControl1_MenuItemClicked;            InitializeComponent();

        _serviceProvider = serviceProvider;

            // Đăng ký event handler cho Dev6<<<<<<< HEAD

            sideBarControl1.ShowHoaDonNhapClicked += (s, e) => ShowUserControl<ucHoaDonNhapList>();=======

        }

            // Đăng ký event handler cho menu click

        private void SideBarControl1_MenuItemClicked(object? sender, string menuKey)            sideBarControl1.MenuItemClicked += SideBarControl1_MenuItemClicked;

        {        }

            switch (menuKey)

            {        private void SideBarControl1_MenuItemClicked(object? sender, string menuKey)

                case "Dashboard":        {

                    ShowDashboard();            switch (menuKey)

                    break;            {

                case "Dashboard":

                case "BanHang":                    ShowDashboard();

    LoadForm<POSForm>();                    break;

                    break;

                case "BanHang":

                case "DanhMucSanPham":                    LoadForm<POSForm>();

                    MessageBox.Show("Chức năng Danh mục sản phẩm đang phát triển", "Thông báo",                    break;

                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;                case "DanhMucSanPham":

                    MessageBox.Show("Chức năng Danh mục sản phẩm đang phát triển", "Thông báo",

                case "SanPham":                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MessageBox.Show("Chức năng Sản phẩm đang phát triển", "Thông báo",                    break;

                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;                case "SanPham":

                    MessageBox.Show("Chức năng Sản phẩm đang phát triển", "Thông báo",

                case "HoaDonBan":                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadForm<HoaDonBanForm>();                    break;

                    break;

                case "HoaDonBan":

                case "HoaDonNhap":                    LoadForm<HoaDonBanForm>();

                    ShowUserControl<ucHoaDonNhapList>();                    break;

                    break;

                case "KhachHang":

                case "KhachHang":                    MessageBox.Show("Chức năng Khách hàng đang phát triển", "Thông báo",

                    MessageBox.Show("Chức năng Khách hàng đang phát triển", "Thông báo",                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBoxButtons.OK, MessageBoxIcon.Information);                    break;

                    break;

                case "NhanVien":

                case "NhanVien":                    MessageBox.Show("Chức năng Nhân viên đang phát triển", "Thông báo",

                    MessageBox.Show("Chức năng Nhân viên đang phát triển", "Thông báo",                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBoxButtons.OK, MessageBoxIcon.Information);                    break;

                    break;

                case "NhaCungCap":

                case "NhaCungCap":                    MessageBox.Show("Chức năng Nhà cung cấp đang phát triển", "Thông báo",

                    MessageBox.Show("Chức năng Nhà cung cấp đang phát triển", "Thông báo",                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBoxButtons.OK, MessageBoxIcon.Information);                    break;

                    break;

                case "TaiKhoan":

                case "TaiKhoan":                    MessageBox.Show("Chức năng Tài khoản đang phát triển", "Thông báo",

                    MessageBox.Show("Chức năng Tài khoản đang phát triển", "Thông báo",                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBoxButtons.OK, MessageBoxIcon.Information);                    break;

                    break;

                case "HeThong":

                case "HeThong":                    MessageBox.Show("Chức năng Hệ thống đang phát triển", "Thông báo",

                    MessageBox.Show("Chức năng Hệ thống đang phát triển", "Thông báo",                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBoxButtons.OK, MessageBoxIcon.Information);                    break;

                    break;            }

            }        }

        }

        private void ShowDashboard()

        private void ShowDashboard()
{

    {            // Đóng form hiện tại nếu có

        // Đóng form/control hiện tại nếu có            if (_currentChildForm != null)

        if (_currentChildForm != null)
        {

            {
                _currentChildForm.Close();

                _currentChildForm.Close(); _currentChildForm.Dispose();

                _currentChildForm.Dispose(); _currentChildForm = null;

                _currentChildForm = null;
            }

        }

        // Hiển thị dashboard/welcome screen

        if (_currentControl != null) panelContent.Controls.Clear();

        {
            var lblWelcome = new Label

                panelContent.Controls.Remove(_currentControl);
            {

                _currentControl.Dispose(); Text = "🏪 BAG SHOP MANAGEMENT\n\n" +

                _currentControl = null; "📊 Dashboard - Tổng quan hệ thống\n\n" +

            }
            "Vui lòng chọn chức năng từ menu bên trái để bắt đầu làm việc.\n\n" +

                       "✅ Bán hàng: Tạo hóa đơn bán hàng (POS)\n" +

            // Hiển thị dashboard/welcome screen                       "✅ Hóa đơn bán: Xem và quản lý hóa đơn",

            panelContent.Controls.Clear(); Font = new Font("Segoe UI", 14F, FontStyle.Regular),

            var lblWelcome = new Label                ForeColor = Color.FromArgb(52, 73, 94),

            {
                TextAlign = ContentAlignment.MiddleCenter,

                Text = "🏪 BAG SHOP MANAGEMENT\n\n" + Dock = DockStyle.Fill,

                       "📊 Dashboard - Tổng quan hệ thống\n\n" + BackColor = Color.White

                       "Vui lòng chọn chức năng từ menu bên trái để bắt đầu làm việc.\n\n" +            }
            ;

            "✅ Bán hàng: Tạo hóa đơn bán hàng (POS)\n" + panelContent.Controls.Add(lblWelcome);

            "✅ Hóa đơn bán: Xem và quản lý hóa đơn\n" +        }

        "✅ Hóa đơn nhập: Quản lý hóa đơn nhập hàng",

                Font = new Font("Segoe UI", 14F, FontStyle.Regular),        private void LoadForm<T>() where T : Form

                ForeColor = Color.FromArgb(52, 73, 94),        {

    TextAlign = ContentAlignment.MiddleCenter,            // Đóng form hiện tại nếu có

                Dock = DockStyle.Fill,            if (_currentChildForm != null)

        BackColor = Color.White            {

    }
    ; _currentChildForm.Close();

    panelContent.Controls.Add(lblWelcome); _currentChildForm.Dispose();

}            }



        private void LoadForm<T>() where T : Form            // Tạo form mới từ DI container

{
    var form = _serviceProvider.GetRequiredService<T>();

    // Clear UserControl if any            _currentChildForm = form;

    if (_currentControl != null)

    {            // Cấu hình form để hiển thị trong panel

        panelContent.Controls.Remove(_currentControl); form.TopLevel = false;

        _currentControl.Dispose(); form.FormBorderStyle = FormBorderStyle.None;

        _currentControl = null; form.Dock = DockStyle.Fill;

    }

    // Thêm form vào panel và hiển thị

    // Đóng form hiện tại nếu có            panelContent.Controls.Clear();

    if (_currentChildForm != null) panelContent.Controls.Add(form);

    {
        form.Show();

        _currentChildForm.Close();>>>>>>> ndt - dev4

                _currentChildForm.Dispose();
    }

}

// === 5. HÀM CHUNG ĐỂ CHUYỂN ĐỔI USER CONTROL ===

// Tạo form mới từ DI container        private void ShowUserControl<T>() where T : UserControl

var form = _serviceProvider.GetRequiredService<T>();
{

    _currentChildForm = form;<<<<<<< HEAD

            try

            // Cấu hình form để hiển thị trong panel            {

            form.TopLevel = false; if (_currentControl != null && _currentControl.GetType() == typeof(T))

        form.FormBorderStyle = FormBorderStyle.None;
    {

        form.Dock = DockStyle.Fill; return;

    }

    // Thêm form vào panel và hiển thị=======

    panelContent.Controls.Clear();            // Hiển thị Dashboard khi khởi động

    panelContent.Controls.Add(form); ShowDashboard();

    form.Show();
    }

        }

private void QuanLiBanHang_Load(object sender, EventArgs e)

        private void ShowUserControl<T>() where T : UserControl
{

    {>>>>>>> ndt - dev4

            try

        {                // Yêu cầu DI Container cung cấp một UC mới

            // Clear Form if any                // Container sẽ tự động inject các dependency (Controller, Repo...)

            if (_currentChildForm != null) var newControl = _serviceProvider.GetRequiredService<T>();

            {
                newControl.Dock = DockStyle.Fill;

                _currentChildForm.Close();

                _currentChildForm.Dispose();                // Xóa UC cũ khỏi Panel

                _currentChildForm = null; if (_currentControl != null)

                }
            {

                pnlMainContent.Controls.Remove(_currentControl);

                if (_currentControl != null && _currentControl.GetType() == typeof(T)) _currentControl.Dispose(); // Giải phóng UC cũ

                { }

                return;

            }                // Thêm UC mới vào Panel và lưu tham chiếu

            pnlMainContent.Controls.Add(newControl);

            // Yêu cầu DI Container cung cấp một UC mới                _currentControl = newControl;

            var newControl = _serviceProvider.GetRequiredService<T>();
        }

                newControl.Dock = DockStyle.Fill;            catch (Exception ex)

            {

            // Xóa UC cũ khỏi Panel                MessageBox.Show($"Lỗi khi tải module: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (_currentControl != null)            }

        { }

        panelContent.Controls.Remove(_currentControl);

        _currentControl.Dispose();        private void QuanLiBanHang_Load(object sender, EventArgs e)

                }        {

    if (this.DesignMode) return;

    // Thêm UC mới vào Panel và lưu tham chiếu

    panelContent.Controls.Clear();            // Lắng nghe các "tín hiệu" (event) từ sideBarControl1

    panelContent.Controls.Add(newControl);

    _currentControl = newControl;            // Khi nút button5 (Hóa đơn nhập) được nhấn

}
sideBarControl.ShowHoaDonNhapClicked += (s, ev) => ShowUserControl<ucHoaDonNhapList>();

            catch (Exception ex)

            {            // Khi nút button4 (Sản phẩm) được nhấn

                MessageBox.Show($"Lỗi khi tải module: {ex.Message}", "Lỗi nghiêm trọng",             //sideBarControl1.ShowSanPhamClicked += (s, ev) => {

                    MessageBoxButtons.OK, MessageBoxIcon.Error);            //    // Tương lai: ShowUserControl<ucSanPhamList>();

            }            //    MessageBox.Show("Chức năng 'Sản Phẩm' đang được phát triển.");

        }            //};



        private void sideBarControl1_Load(object sender, EventArgs e)            // Gán các nút còn lại...

{            //sideBarControl1.ShowDashboardClicked += (s, ev) => MessageBox.Show("Chức năng 'Dashboard' đang được phát triển.");

    // Hiển thị Dashboard khi khởi động            //sideBarControl1.ShowBanHangClicked += (s, ev) => MessageBox.Show("Chức năng 'Bán Hàng' đang được phát triển.");

    ShowDashboard();

}            // === 4. KHÔNG HIỂN THỊ GÌ CẢ KHI MỚI MỞ ===

// ShowUserControl<ucHoaDonNhapList>(); // <--- XOÁ HOẶC COMMENT DÒNG NÀY

private void QuanLiBanHang_Load(object sender, EventArgs e)        }

        { }

if (this.DesignMode) return;}
            
            // Hiển thị Dashboard khi form load
            ShowDashboard();
        }
    }
}
