using BagShopManagement.Views.Dev6;
using BagShopManagement.Views.Dev4.Dev4_POS;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BagShopManagement.Views.Common
{
    public partial class QuanLiBanHang : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Form? _currentChildForm;
        private UserControl? _currentControl;

        public QuanLiBanHang(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            sideBarControl1.MenuItemClicked += SideBarControl1_MenuItemClicked;
            sideBarControl1.ShowHoaDonNhapClicked += (s, e) => ShowUserControl<ucHoaDonNhapList>();
        }

        private void SideBarControl1_MenuItemClicked(object? sender, string menuKey)
        {
            switch (menuKey)
            {
                case "Dashboard": ShowDashboard(); break;
                case "BanHang": LoadForm<POSForm>(); break;
                case "HoaDonBan": LoadForm<HoaDonBanForm>(); break;
                case "HoaDonNhap": ShowUserControl<ucHoaDonNhapList>(); break;
                default: MessageBox.Show("Chức năng đang phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); break;
            }
        }

        private void ShowDashboard()
        {
            if (_currentChildForm != null) { _currentChildForm.Close(); _currentChildForm.Dispose(); _currentChildForm = null; }
            if (_currentControl != null) { panelContent.Controls.Remove(_currentControl); _currentControl.Dispose(); _currentControl = null; }
            panelContent.Controls.Clear();
            var lblWelcome = new Label
            {
                Text = " BAG SHOP MANAGEMENT\n\n Dashboard\n\nVui lòng chọn chức năng từ menu bên trái",
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
            if (_currentControl != null) { panelContent.Controls.Remove(_currentControl); _currentControl.Dispose(); _currentControl = null; }
            if (_currentChildForm != null) { _currentChildForm.Close(); _currentChildForm.Dispose(); }
            var form = _serviceProvider.GetRequiredService<T>();
            _currentChildForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(form);
            form.Show();
        }

        private void ShowUserControl<T>() where T : UserControl
        {
            try
            {
                if (_currentChildForm != null) { _currentChildForm.Close(); _currentChildForm.Dispose(); _currentChildForm = null; }
                if (_currentControl != null && _currentControl.GetType() == typeof(T)) return;
                var newControl = _serviceProvider.GetRequiredService<T>();
                newControl.Dock = DockStyle.Fill;
                if (_currentControl != null) { panelContent.Controls.Remove(_currentControl); _currentControl.Dispose(); }
                panelContent.Controls.Clear();
                panelContent.Controls.Add(newControl);
                _currentControl = newControl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLiBanHang_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode) ShowDashboard();
        }

        private void sideBarControl1_Load(object sender, EventArgs e) { }
    }
}
