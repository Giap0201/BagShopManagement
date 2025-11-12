using Microsoft.Identity.Client;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Controls
{
    public partial class SideBarControl : UserControl
    {
        public event EventHandler ShowHoaDonNhapClicked;

        public event EventHandler ShowBanHangClicked;

        public event EventHandler ShowBaoCaoThongKeClicked;

        public SideBarControl()
        {
            InitializeComponent();

            // Gắn sự kiện click cho nút Sản phẩm
            btnSanPham.Click += btnSanPham_Click;
            btnDanhMuc.Click += btnDanhMuc_Click;
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            ShowHoaDonNhapClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            ShowBanHangClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            ShowBaoCaoThongKeClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}