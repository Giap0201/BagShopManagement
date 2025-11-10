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
                case "POS":
                    LoadForm<POSForm>();
                    break;
                case "HoaDon":
                    LoadForm<HoaDonBanForm>();
                    break;
                case "SanPham":
                    MessageBox.Show("Chức năng Sản phẩm đang phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
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
            // Tự động load form POS khi khởi động
            LoadForm<POSForm>();
        }
    }
}
