using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BagShopManagement.Views.Dev4.Dev4_POS;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using Microsoft.Extensions.DependencyInjection;

namespace BagShopManagement.Views.Common
{
    public partial class QuanLiBanHang : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Form? _currentChildForm;

        public QuanLiBanHang(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            // Đăng ký event handler cho menu click
            sideBarControl1.MenuItemClicked += SideBarControl1_MenuItemClicked;
        }

        private void SideBarControl1_MenuItemClicked(object? sender, string menuKey)
        {
            switch (menuKey)
            {
                case "Dashboard":
                    ShowDashboard();
                    break;

                case "BanHang":
                    LoadForm<POSForm>();
                    break;

                case "DanhMucSanPham":
                    MessageBox.Show("Chức năng Danh mục sản phẩm đang phát triển", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "SanPham":
                    MessageBox.Show("Chức năng Sản phẩm đang phát triển", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "HoaDonBan":
                    LoadForm<HoaDonBanForm>();
                    break;

                case "KhachHang":
                    MessageBox.Show("Chức năng Khách hàng đang phát triển", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "NhanVien":
                    MessageBox.Show("Chức năng Nhân viên đang phát triển", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "NhaCungCap":
                    MessageBox.Show("Chức năng Nhà cung cấp đang phát triển", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "TaiKhoan":
                    MessageBox.Show("Chức năng Tài khoản đang phát triển", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case "HeThong":
                    MessageBox.Show("Chức năng Hệ thống đang phát triển", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void ShowDashboard()
        {
            // Đóng form hiện tại nếu có
            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
                _currentChildForm.Dispose();
                _currentChildForm = null;
            }

            // Hiển thị dashboard/welcome screen
            panelContent.Controls.Clear();
            var lblWelcome = new Label
            {
                Text = "🏪 BAG SHOP MANAGEMENT\n\n" +
                       "📊 Dashboard - Tổng quan hệ thống\n\n" +
                       "Vui lòng chọn chức năng từ menu bên trái để bắt đầu làm việc.\n\n" +
                       "✅ Bán hàng: Tạo hóa đơn bán hàng (POS)\n" +
                       "✅ Hóa đơn bán: Xem và quản lý hóa đơn",
                Font = new Font("Segoe UI", 14F, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            panelContent.Controls.Add(lblWelcome);
        }

        private void LoadForm<T>() where T : Form
        {
            // Đóng form hiện tại nếu có
            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
                _currentChildForm.Dispose();
            }

            // Tạo form mới từ DI container
            var form = _serviceProvider.GetRequiredService<T>();
            _currentChildForm = form;

            // Cấu hình form để hiển thị trong panel
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Thêm form vào panel và hiển thị
            panelContent.Controls.Clear();
            panelContent.Controls.Add(form);
            form.Show();
        }

        private void sideBarControl1_Load(object sender, EventArgs e)
        {
            // Hiển thị Dashboard khi khởi động
            ShowDashboard();
        }

        private void QuanLiBanHang_Load(object sender, EventArgs e)
        {

        }
    }
}
