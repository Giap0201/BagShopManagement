using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BagShopManagement.Controllers;
using BagShopManagement.Views.Controls;

namespace BagShopManagement.Views.Common
{
    public partial class QuanLiBanHang : Form
    {

        public QuanLiBanHang(PromotionControl promotionControl)
        {
            InitializeComponent();
            AddUserControl(promotionControl);
        }

        private void sideBarControl1_Load(object sender, EventArgs e)
        {

        }

        // Fix for CS7036 and IDE0090:
        // - CS7036: The PromotionControl constructor requires a ChuongTrinhGiamGiaController argument.
        // - IDE0090: The 'new' expression can be simplified.

        // You need to provide an instance of ChuongTrinhGiamGiaController when creating PromotionControl.
        // Assuming you have access to a ChuongTrinhGiamGiaController instance (e.g., via a field, property, or by creating a new one).

        // Add this using if needed:
        // using BagShopManagement.Controllers; // or the correct namespace for ChuongTrinhGiamGiaController

        //private void SideBarControl1_NavigationButtonClicked(string viewName)
        //{
        //    pnlMainContent.Controls.Clear();

        //    switch (viewName)
        //    {
        //        case "KhuyenMai":
        //            // Create an instance of ChuongTrinhGiamGiaController
        //            // Pass it to the PromotionControl constructor
        //            var promotionControl = new PromotionControl(_giamGiaController)
        //            {
        //                Dock = DockStyle.Fill
        //            };
        //            pnlMainContent.Controls.Add(promotionControl);
        //            break;

        //            // Bạn có thể thêm các trường hợp khác cho các nút khác ở đây
        //            // case "SanPham":
        //            //     SanPhamControl sanPhamControl = new SanPhamControl();
        //            //     sanPhamControl.Dock = DockStyle.Fill;
        //            //     pnlMainContent.Controls.Add(sanPhamControl);
        //            //     break;

        //            // ... và các chức năng khác
        //    }
        //}

        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            // panelContainer là một Panel trên frmMain để chứa UserControl
            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(userControl);
            userControl.BringToFront();
        }
    }
}
