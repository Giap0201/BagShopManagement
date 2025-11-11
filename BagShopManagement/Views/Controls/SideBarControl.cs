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
            button2.Click += (s, e) => MenuItemClicked?.Invoke(this, "BanHang");
            button3.Click += (s, e) => MenuItemClicked?.Invoke(this, "DanhMucSanPham");
            button4.Click += (s, e) => MenuItemClicked?.Invoke(this, "SanPham");
            button5.Click += (s, e) => MenuItemClicked?.Invoke(this, "HoaDonBan");
            button6.Click += (s, e) => MenuItemClicked?.Invoke(this, "KhachHang");
            button7.Click += (s, e) =>
            {
                MenuItemClicked?.Invoke(this, "HoaDonNhap");
                ShowHoaDonNhapClicked?.Invoke(this, EventArgs.Empty); // Dev6 compatibility
            };
            button8.Click += (s, e) => MenuItemClicked?.Invoke(this, "NhaCungCap");
            button9.Click += (s, e) => MenuItemClicked?.Invoke(this, "TaiKhoan");
            button10.Click += (s, e) => MenuItemClicked?.Invoke(this, "HeThong");
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
            MenuItemClicked?.Invoke(this, "HoaDonNhap");
            ShowHoaDonNhapClicked?.Invoke(this, EventArgs.Empty);
        }

        private void SideBarControl_Load(object sender, EventArgs e)
        {
            // Event handler for control load
        }
    }
}