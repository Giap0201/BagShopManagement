using BagShopManagement.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev6
{
    public partial class frmViewHoaDonNhapDetails : Form
    {
        public frmViewHoaDonNhapDetails()
        {
            InitializeComponent();
        }

        private void frmViewHoaDonNhapDetails_Load(object sender, EventArgs e)
        {
        }

        public void LoadData(HoaDonNhapResponse data)
        {
            if (data == null)
            {
                MessageBox.Show("Dữ liệu hóa đơn trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            valMaHDN.Text = data.MaHDN;
            valNCC.Text = data.TenNCC;
            valNV.Text = data.TenNV;
            valNgayNhap.Text = data.NgayNhap?.ToString("dd/MM/yyyy");
            valGhiChu.Text = data.GhiChu;
            valTrangThai.Text = data.TenTrangThai;
            valNgayDuyet.Text = data.NgayDuyet?.ToString("dd/MM/yyyy") ?? "";
            valNgayHuy.Text = data.NgayHuy?.ToString("dd/MM/yyyy") ?? "";

            dgvChiTiet.DataSource = data.ChiTiet;

            valTongTien.Text = data.TongTien.ToString("N0");
        }
    }
}