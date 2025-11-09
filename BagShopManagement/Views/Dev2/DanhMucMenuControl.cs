using BagShopManagement.Views.Dev2;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class DanhMucMenuControl : UserControl
    {
        public DanhMucMenuControl()
        {
            InitializeComponent();

            btnLoaiTui.Click += BtnLoaiTui_Click;
            //btnThuongHieu.Click += BtnThuongHieu_Click;
            //btnChatLieu.Click += BtnChatLieu_Click;
            //btnMauSac.Click += BtnMauSac_Click;
            //btnKichThuoc.Click += BtnKichThuoc_Click;
            //btnNCC.Click += BtnNCC_Click;
        }

        private void LoadControl(UserControl uc)
        {
            var parent = this.Parent as Panel;
            parent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            parent.Controls.Add(uc);
        }

        private void BtnLoaiTui_Click(object sender, EventArgs e)
        {
            LoadControl(new LoaiTuiControl());
        }

        //private void BtnThuongHieu_Click(object sender, EventArgs e)
        //{
        //    LoadControl(new ThuongHieuControl());
        //}

        //private void BtnChatLieu_Click(object sender, EventArgs e)
        //{
        //    LoadControl(new ChatLieuControl());
        //}

        //private void BtnMauSac_Click(object sender, EventArgs e)
        //{
        //    LoadControl(new MauSacControl());
        //}

        //private void BtnKichThuoc_Click(object sender, EventArgs e)
        //{
        //    LoadControl(new KichThuocControl());
        //}

        //private void BtnNCC_Click(object sender, EventArgs e)
        //{
        //    LoadControl(new NhaCungCapControl());
        //}
    }
}
