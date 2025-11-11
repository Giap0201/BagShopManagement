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

        // 🟢 Khai báo sự kiện để form chính có thể lắng nghe
        public event EventHandler SanPhamClicked;

        public event EventHandler ImportDanhMucClicked;

        public event EventHandler KhachHangClicked;

        public event EventHandler NhaCungCapClicked;




        public SideBarControl()
        {
            InitializeComponent();

            // Gắn sự kiện click cho nút Sản phẩm
            btnSanPham.Click += btnSanPham_Click;
            btnImportDanhMuc.Click += btnImportDanhMuc_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        // 🟢 Gán sự kiện nút trong Designer hoặc bằng tay
        // 🟢 Khi người dùng bấm nút "Sản phẩm"
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            // Phát tín hiệu cho form chính
            SanPhamClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnImportDanhMuc_Click(object sender, EventArgs e)
        {
            // Phát tín hiệu cho form chính
            ImportDanhMucClicked?.Invoke(this, EventArgs.Empty);
        }

        private void SideBarControl_Load(object sender, EventArgs e)
        {

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            KhachHangClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            NhaCungCapClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
