using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Views.Controls;
using BagShopManagement.Views.Dev2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Common
{
    public partial class QuanLiBanHang : Form
    {

        public QuanLiBanHang()
        {
            InitializeComponent();
            // 1. View tự khởi tạo Controller và truyền chính nó (this) vào
            //_controller = new HoaDonNhapController(this);
        }


        private void sideBarControl1_Load(object sender, EventArgs e)
        {
            // 🟢 Gắn sự kiện cho sidebar đã có sẵn trong Designer
            sideBarControl1.SanPhamClicked += Sidebar_SanPhamClicked;
        }

        // 🔵 Khi nhấn nút Sản phẩm trong SideBar
        private void Sidebar_SanPhamClicked(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var spControl = new SanPhamControl();
            spControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(spControl);
        }

        private void hoaDonNhapControl1_Load(object sender, EventArgs e)
        {
        }

        private void hoaDonNhapControl2_Load(object sender, EventArgs e)
        {

        }
    }
}