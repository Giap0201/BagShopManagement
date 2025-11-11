using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Controls
{
    public partial class SideBarControl : UserControl
    {
        // Event để thông báo form cha khi menu được click
        public event EventHandler<string>? MenuItemClicked;

        // Event cho Dev6 compatibility
        public event EventHandler? ShowHoaDonNhapClicked;

        public SideBarControl()
        {
            InitializeComponent();
            SetupMenuEventHandlers();
        }

        private void SetupMenuEventHandlers()
        {
            // Gán event handlers cho các button có sẵn trong Designer
            button1.Click += (s, e) => MenuItemClicked?.Invoke(this, "Dashboard");
            btnBanHang.Click += (s, e) => MenuItemClicked?.Invoke(this, "BanHang");
            btnDanhMuc.Click += (s, e) => MenuItemClicked?.Invoke(this, "DanhMucSanPham");
            btnSanPham.Click += (s, e) => MenuItemClicked?.Invoke(this, "SanPham");
            btnHoaDonBan.Click += (s, e) => MenuItemClicked?.Invoke(this, "HoaDonBan");
            btnKhachHang.Click += (s, e) => MenuItemClicked?.Invoke(this, "KhachHang");
            // button7 is "Nhân viên" in Designer; map accordingly
            btnNhanVien.Click += (s, e) => MenuItemClicked?.Invoke(this, "NhanVien");
            // button11 is the Dev6 "Hoá đơn nhập" button added in Designer
            // wire it to both the MenuItemClicked and the Dev6 compatibility event
            btnHoaDonNhap.Click += (s, e) =>
            {
                MenuItemClicked?.Invoke(this, "HoaDonNhap");
                ShowHoaDonNhapClicked?.Invoke(this, EventArgs.Empty);
            };
            btnNCC.Click += (s, e) => MenuItemClicked?.Invoke(this, "NhaCungCap");
            btnTaiKhoan.Click += (s, e) => MenuItemClicked?.Invoke(this, "TaiKhoan");
            btnKho.Click += (s, e) => MenuItemClicked?.Invoke(this, "HeThong");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuItemClicked?.Invoke(this, "Dashboard");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuItemClicked?.Invoke(this, "BanHang");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuItemClicked?.Invoke(this, "SanPham");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Designer button7 is "Nhân viên" — raise NhanVien menu event
            MenuItemClicked?.Invoke(this, "NhanVien");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Handler for the Dev6 "Hoá đơn nhập" sidebar button
            MenuItemClicked?.Invoke(this, "HoaDonNhap");
            ShowHoaDonNhapClicked?.Invoke(this, EventArgs.Empty);
        }

        private void SideBarControl_Load(object sender, EventArgs e)
        {
            // Event handler for control load
        }
    }
}