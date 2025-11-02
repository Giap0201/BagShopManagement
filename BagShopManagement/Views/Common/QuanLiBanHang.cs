using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BagShopManagement.Views.Controls;

namespace BagShopManagement.Views.Common
{
    public partial class QuanLiBanHang : Form
    {
        public QuanLiBanHang()
        {
            InitializeComponent();
        }

        private void sideBarControl1_Load(object sender, EventArgs e)
        {

        }

        // Phương thức này sẽ được gọi mỗi khi một nút trên SideBar được nhấn
        private void SideBarControl1_NavigationButtonClicked(string viewName)
        {
            // Trước khi hiển thị control mới, hãy xóa tất cả các control cũ trong panel
            pnlMainContent.Controls.Clear();

            // Dựa vào tên view được gửi từ SideBar, quyết định hiển thị UserControl nào
            switch (viewName)
            {
                case "KhuyenMai":
                    // Tạo một instance của PromotionControl
                    PromotionControl promotionControl = new PromotionControl();
                    // Thiết lập Dock = Fill để nó lấp đầy pnlMainContent
                    promotionControl.Dock = DockStyle.Fill;
                    // Thêm control vào panel
                    pnlMainContent.Controls.Add(promotionControl);
                    break;

                    // Bạn có thể thêm các trường hợp khác cho các nút khác ở đây
                    // case "SanPham":
                    //     SanPhamControl sanPhamControl = new SanPhamControl();
                    //     sanPhamControl.Dock = DockStyle.Fill;
                    //     pnlMainContent.Controls.Add(sanPhamControl);
                    //     break;

                    // ... và các chức năng khác
            }
        }
    }
}
