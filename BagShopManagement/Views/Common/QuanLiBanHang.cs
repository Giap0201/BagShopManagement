using BagShopManagement.Views.Controls;
using BagShopManagement.Views.Dev2;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using BagShopManagement.Views.Dev4.Dev4_POS;
using BagShopManagement.Views.Dev6;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Common
{
    public partial class QuanLiBanHang : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private UserControl _currentControl = null;
        private Form _currentChildForm = null;

        public QuanLiBanHang(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void ShowUserControl<T>() where T : UserControl
        {
            try
            {
                if (_currentControl != null && _currentControl.GetType() == typeof(T))
                    return;

                var newControl = _serviceProvider.GetRequiredService<T>();
                newControl.Dock = DockStyle.Fill;

                if (_currentControl != null)
                {
                    mainPanel.Controls.Remove(_currentControl);
                    _currentControl.Dispose();
                }

                mainPanel.Controls.Add(newControl);
                _currentControl = newControl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải module: {ex.Message}", "Lỗi nghiêm trọng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void ShowFormAsControl<T>() where T : Form
        //{
        //    //MessageBox.Show("POS clicked!");

        //    try
        //    {
        //        if (_currentChildForm != null && _currentChildForm.GetType() == typeof(T))
        //            return;

        //        // Đóng form cũ nếu có
        //        if (_currentChildForm != null)
        //        {
        //            mainPanel.Controls.Remove(_currentChildForm);
        //            _currentChildForm.Dispose();
        //            _currentChildForm = null;
        //        }

        //        // Lấy form mới từ DI
        //        var form = _serviceProvider.GetRequiredService<T>();

        //        // ⚙️ Cấu hình để "coi như UserControl"
        //        form.TopLevel = false;
        //        form.FormBorderStyle = FormBorderStyle.None;
        //        form.Dock = DockStyle.Fill;

        //        // Thêm vào panel
        //        mainPanel.Controls.Add(form);
        //        _currentChildForm = form;

        //        form.Show(); // 👈 BẮT BUỘC: Form mới vẽ được
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi hiển thị module: {ex.Message}",
        //                        "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void QuanLiBanHang_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            sideBarControl.ShowHoaDonNhapClicked += (s, ev) => ShowUserControl<ucHoaDonNhapList>();
            sideBarControl.ShowBaoCaoThongKeClicked += (s, ev) => ShowUserControl<ucBaoCaoThongKe>();

            sideBarControl.ShowBanHangClicked += (s, ev) => ShowUserControl<UC_POS>();
            sideBarControl.SanPhamClicked += (s, ev) => ShowUserControl<SanPhamControl>();
            sideBarControl.ShowQuanLyHoaDonClicked += (s, ev) => ShowUserControl<UC_HoaDonBan>();

            sideBarControl.DanhMucClicked += (s, e) =>
            {
                // Show danh mục chính
                ShowUserControl<DanhMucMenuControl>();

                // Lấy danh mục vừa show
                if (_currentControl is DanhMucMenuControl danhMucCtrl)
                {
                    // Đăng ký các event để show các control con
                    danhMucCtrl.ShowLoaiTuiClicked += (s2, e2) => ShowUserControl<LoaiTuiControl>();
                    danhMucCtrl.ShowThuongHieuClicked += (s2, e2) => ShowUserControl<ThuongHieuControl>();
                    danhMucCtrl.ShowMauSacClicked += (s2, e2) => ShowUserControl<MauSacControl>();
                    danhMucCtrl.ShowChatLieuClicked += (s2, e2) => ShowUserControl<ChatLieuControl>();
                    danhMucCtrl.ShowKichThuocClicked += (s2, e2) => ShowUserControl<KichThuocControl>();
                }
            };

            // Không hiển thị gì ban đầu
            // ShowUserControl<ucHoaDonNhapList>();
        }

        private void sideBarControl_Load(object sender, EventArgs e)
        {
        }

        private void hoaDonNhapControl2_Load(object sender, EventArgs e)
        {
        }
    }
}