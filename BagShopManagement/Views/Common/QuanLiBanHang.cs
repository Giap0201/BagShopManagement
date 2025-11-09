using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
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
            sideBarControl1.ImportDanhMucClicked += Sidebar_ImportDanhMucClicked;
            sideBarControl1.DanhMucClicked += Sidebar_DanhMucClicked;
        }

        // 🔵 Khi nhấn nút Sản phẩm trong SideBar
        private void Sidebar_SanPhamClicked(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var spControl = new SanPhamControl();
            spControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(spControl);
        }

        private void Sidebar_DanhMucClicked(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            var uc = new DanhMucMenuControl();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void Sidebar_ImportDanhMucClicked(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            var form = new ImportDanhMucForm(new DanhMucService(new DanhMucRepository()));
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void btnImportDanhMuc_Click(object sender, EventArgs e)
        {
            var danhMucService = new DanhMucService(new DanhMucRepository());
            using (var f = new ImportDanhMucForm(danhMucService))
            {
                f.ShowDialog();
            }
        }


        private void hoaDonNhapControl1_Load(object sender, EventArgs e)
        {
        }

        private void hoaDonNhapControl2_Load(object sender, EventArgs e)
        {

        }
    }
}