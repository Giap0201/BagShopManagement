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

        public SideBarControl()
        {
            InitializeComponent();
            SetupMenuButtons();
        }

        private void SetupMenuButtons()
        {
            // Thêm các nút menu vào SideBarControl
            Button btnBanHang = new Button
            {
                Text = "🛒 Bán hàng (POS)",
                Width = 280,
                Height = 60,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(20, 20),
                Tag = "POS"
            };
            btnBanHang.Click += MenuItem_Click;

            Button btnHoaDon = new Button
            {
                Text = "📄 Quản lý hóa đơn",
                Width = 280,
                Height = 60,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(20, 100),
                Tag = "HoaDon"
            };
            btnHoaDon.Click += MenuItem_Click;

            Button btnSanPham = new Button
            {
                Text = "📦 Sản phẩm",
                Width = 280,
                Height = 60,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = Color.FromArgb(155, 89, 182),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(20, 180),
                Tag = "SanPham"
            };
            btnSanPham.Click += MenuItem_Click;

            this.Controls.Add(btnBanHang);
            this.Controls.Add(btnHoaDon);
            this.Controls.Add(btnSanPham);
        }

        private void MenuItem_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is string menuKey)
            {
                MenuItemClicked?.Invoke(this, menuKey);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Giữ lại cho tương thích, nhưng không dùng nữa
        }
    }
}
