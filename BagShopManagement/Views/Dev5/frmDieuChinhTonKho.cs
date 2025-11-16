using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev5
{
    public partial class frmDieuChinhTonKho : Form
    {
        public int SoLuongMoi { get; private set; }
        public string GhiChu { get; private set; }

        public frmDieuChinhTonKho(SanPham sanPham)
        {
            InitializeComponent();

            // Gán dữ liệu của sản phẩm được chọn lên các control
            lblMaSP.Text = sanPham.MaSP;
            lblTenSP.Text = sanPham.TenSP;
            lblTonKhoCu.Text = sanPham.SoLuongTon.ToString();

            // Gợi ý số lượng hiện tại trong ô nhập liệu
            nudSoLuongMoi.Value = sanPham.SoLuongTon;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control
            this.SoLuongMoi = (int)nudSoLuongMoi.Value;
            this.GhiChu = txtGhiChu.Text.Trim();

            // Đặt kết quả là OK để báo hiệu cho form cha rằng người dùng đã xác nhận
            this.DialogResult = DialogResult.OK;

            // Đóng form
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Đặt kết quả là Cancel và đóng form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
