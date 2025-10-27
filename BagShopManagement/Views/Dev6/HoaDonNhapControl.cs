using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev6
{
    // UserControl chỉ lo hiển thị dữ liệu, không xử lý logic nghiệp vụ
    public partial class HoaDonNhapControl : UserControl, IHoaDonNhapView
    {
        private readonly HoaDonNhapController _controller;

        #region Constructor

        // Constructor cho Designer
        public HoaDonNhapControl()
        {
            InitializeComponent();
        }

        // Constructor Runtime - gán Controller qua Dependency Injection
        public HoaDonNhapControl(HoaDonNhapController controller) : this()
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        #endregion Constructor

        #region Event Handlers

        private void HoaDonNhapControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && _controller != null)
                _controller.LoadHoaDonNhap();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!this.DesignMode && _controller != null)
                _controller.LoadHoaDonNhap();
        }

        #endregion Event Handlers

        #region IHoaDonNhapView Implementation

        public void ShowError(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion IHoaDonNhapView Implementation

        #region Private Methods

        private void SetupDataGridView()
        {
            dgvHoaDonNhap.AutoGenerateColumns = true;

            if (dgvHoaDonNhap.Columns.Contains("MaHDN"))
                dgvHoaDonNhap.Columns["MaHDN"].HeaderText = "Mã HĐN";

            if (dgvHoaDonNhap.Columns.Contains("TenNCC"))
                dgvHoaDonNhap.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";

            if (dgvHoaDonNhap.Columns.Contains("TenNV"))
                dgvHoaDonNhap.Columns["TenNV"].HeaderText = "Nhân Viên";

            if (dgvHoaDonNhap.Columns.Contains("NgayNhap"))
            {
                dgvHoaDonNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dgvHoaDonNhap.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvHoaDonNhap.Columns.Contains("TongTien"))
            {
                dgvHoaDonNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvHoaDonNhap.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }

            if (dgvHoaDonNhap.Columns.Contains("GhiChu"))
                dgvHoaDonNhap.Columns["GhiChu"].HeaderText = "Ghi Chú";
        }

        #endregion Private Methods

        private void dgvHoaDonNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Giữ lại nếu cần xử lý click vào cell
        }

        public void DisplayHoaDonNhap(List<HoaDonNhap> ds)
        {
            dgvHoaDonNhap.DataSource = ds ?? new List<HoaDonNhap>();
            SetupDataGridView();
        }
    }
}