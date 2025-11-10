using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Views.Dev6; // Thêm
using Microsoft.Extensions.DependencyInjection; // Thêm
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
        private readonly IServiceProvider _serviceProvider;
        private UserControl _currentControl = null; // Để lưu trữ UC đang hiển thị

        public QuanLiBanHang(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        // === 5. HÀM CHUNG ĐỂ CHUYỂN ĐỔI USER CONTROL ===
        private void ShowUserControl<T>() where T : UserControl
        {
            try
            {
                if (_currentControl != null && _currentControl.GetType() == typeof(T))
                {
                    return;
                }

                // Yêu cầu DI Container cung cấp một UC mới
                // Container sẽ tự động inject các dependency (Controller, Repo...)
                var newControl = _serviceProvider.GetRequiredService<T>();
                newControl.Dock = DockStyle.Fill;

                // Xóa UC cũ khỏi Panel
                if (_currentControl != null)
                {
                    pnlMainContent.Controls.Remove(_currentControl);
                    _currentControl.Dispose(); // Giải phóng UC cũ
                }

                // Thêm UC mới vào Panel và lưu tham chiếu
                pnlMainContent.Controls.Add(newControl);
                _currentControl = newControl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải module: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLiBanHang_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            // Lắng nghe các "tín hiệu" (event) từ sideBarControl1

            // Khi nút button5 (Hóa đơn nhập) được nhấn
            sideBarControl.ShowHoaDonNhapClicked += (s, ev) => ShowUserControl<ucHoaDonNhapList>();

            // Khi nút button4 (Sản phẩm) được nhấn
            //sideBarControl1.ShowSanPhamClicked += (s, ev) => {
            //    // Tương lai: ShowUserControl<ucSanPhamList>();
            //    MessageBox.Show("Chức năng 'Sản Phẩm' đang được phát triển.");
            //};

            // Gán các nút còn lại...
            //sideBarControl1.ShowDashboardClicked += (s, ev) => MessageBox.Show("Chức năng 'Dashboard' đang được phát triển.");
            //sideBarControl1.ShowBanHangClicked += (s, ev) => MessageBox.Show("Chức năng 'Bán Hàng' đang được phát triển.");

            // === 4. KHÔNG HIỂN THỊ GÌ CẢ KHI MỚI MỞ ===
            // ShowUserControl<ucHoaDonNhapList>(); // <--- XOÁ HOẶC COMMENT DÒNG NÀY
        }
    }
}