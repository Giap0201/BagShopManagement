
using System;
using System.Windows.Forms;
using BagShopManagement.Views.Controls;
using BagShopManagement.Views.Dev5;

namespace BagShopManagement.Views.Common
{
    public partial class QuanLiBanHang : Form
    {
        // Lưu trữ các UserControl đã được DI "tiêm" vào
        private readonly PromotionControl _promotionControl;
        private readonly TonKhoControl _tonKhoControl;

        // Constructor mới: Nhận TẤT CẢ các control cần thiết từ DI Container
        public QuanLiBanHang(PromotionControl promotionControl, TonKhoControl tonKhoControl)
        {
            InitializeComponent();

            // Gán các control được tiêm vào các biến private để sử dụng lại
            _promotionControl = promotionControl;
            _tonKhoControl = tonKhoControl;

            // Gán sự kiện cho SideBar (Giả sử SideBar của bạn có sự kiện tên là NavigationButtonClicked)
            // sideBarControl1.NavigationButtonClicked += SideBarControl1_NavigationButtonClicked;

            // Hiển thị giao diện Tồn kho làm mặc định khi khởi động
            AddUserControl(_tonKhoControl);
        }

        // Phương thức xử lý sự kiện khi một nút trên SideBar được nhấn
        private void SideBarControl1_NavigationButtonClicked(string viewName)
        {
            // Dựa vào tên (viewName) được gửi từ SideBar, chúng ta sẽ hiển thị control tương ứng
            switch (viewName)
            {
                case "TonKho":
                    AddUserControl(_tonKhoControl);
                    break;

                case "KhuyenMai":
                    AddUserControl(_promotionControl);
                    break;

                    // Thêm các case khác cho các chức năng khác ở đây
                    // case "SanPham":
                    //     AddUserControl(_sanPhamControl); // (Nếu bạn có SanPhamControl)
                    //     break;
            }
        }

        // Phương thức chung để thêm một UserControl vào Panel chính
        private void AddUserControl(UserControl userControl)
        {
            // Đảm bảo control được kéo dãn lấp đầy panel
            userControl.Dock = DockStyle.Fill;

            // Xóa control cũ trước khi thêm control mới
            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(userControl);

            // Đưa control mới lên lớp trên cùng để hiển thị
            userControl.BringToFront();
        }

        // Bạn có thể xóa phương thức Load mặc định nếu không dùng đến
        private void sideBarControl1_Load(object sender, EventArgs e)
        {
            // Có thể để trống
        }
    }
}