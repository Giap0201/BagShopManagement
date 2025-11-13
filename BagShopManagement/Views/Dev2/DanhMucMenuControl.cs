using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class DanhMucMenuControl : UserControl
    {
        private readonly IServiceProvider _serviceProvider;

        public event EventHandler ShowLoaiTuiClicked;
        public event EventHandler ShowThuongHieuClicked;
        public event EventHandler ShowMauSacClicked;
        public event EventHandler ShowChatLieuClicked;
        public event EventHandler ShowKichThuocClicked;

        public DanhMucMenuControl(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            btnLoaiTui.Click += BtnLoaiTui_Click;
            btnThuongHieu.Click += BtnThuongHieu_Click;
            btnChatLieu.Click += BtnChatLieu_Click;
            btnMauSac.Click += BtnMauSac_Click;
            btnKichThuoc.Click += BtnKichThuoc_Click;
        }

        private void BtnLoaiTui_Click(object sender, EventArgs e)
        {
            ShowLoaiTuiClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnThuongHieu_Click(object sender, EventArgs e)
        {
            ShowThuongHieuClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnChatLieu_Click(object sender, EventArgs e)
        {
            ShowChatLieuClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnMauSac_Click(object sender, EventArgs e)
        {
            ShowMauSacClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnKichThuoc_Click(object sender, EventArgs e)
        {
            ShowKichThuocClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
