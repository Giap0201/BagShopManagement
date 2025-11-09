using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Utils;
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
    public partial class frmHoaDonNhapDetail : Form
    {
        private MaHoaDonGenerator _maHoaDonGenerator;
        private HoaDonNhapController _hoaDonNhapController;

        public frmHoaDonNhapDetail()
        {
            InitializeComponent();
            _maHoaDonGenerator = new MaHoaDonGenerator("HDN", 3); // Khởi tạo bộ sinh mã
            //_hoaDonNhapController = new HoaDonNhapController(new HoaDonNhapService(new HoaDonNhapImpl());
        }

        private void btnTaoMoiHDN_Click(object sender, EventArgs e)
        {
            ClearFieldThongTinChung();
            ClearFieldThongTinSanPham();
            handleNgayDuyet_NgayHuy();
            txtMaHDN.Text = _maHoaDonGenerator.GenerateNewMaHDN(dtpNgayNhap.Value);
            txtMaHDN.ReadOnly = true;
        }

        private void ClearFieldThongTinChung()
        {
            dtpNgayNhap.Value = DateTime.Now;
            cboNhaCungCap.SelectedIndex = -1;
            cboNhanVien.SelectedIndex = -1;
            txtGhiChu.Clear();
            cboTrangThai.SelectedIndex = -1;
            lblTongTien.Text = "0";
        }

        private void ClearFieldThongTinSanPham()
        {
            cboSanPham.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
        }

        private void handleNgayDuyet_NgayHuy()
        {
            lblNgayDuyet.Visible = false;
            dtpNgayDuyet.Visible = false;
            lblNgayHuy.Visible = false;
            dtpNgayHuy.Visible = false;
        }

        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            if (cboTrangThai.Text == "Tạm lưu" || cboTrangThai.SelectedIndex == -1)
            {
                DateTime ngayLapMoi = dtpNgayNhap.Value;
                txtMaHDN.Text = _maHoaDonGenerator.GenerateNewMaHDN(ngayLapMoi);
            }
        }

        private void btnThemChiTietHDN_Click(object sender, EventArgs e)
        {
            ClearFieldThongTinSanPham();
        }
    }
}