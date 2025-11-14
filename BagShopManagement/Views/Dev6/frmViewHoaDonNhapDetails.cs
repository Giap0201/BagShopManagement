using BagShopManagement.DTOs.Responses;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev6
{
    public partial class frmViewHoaDonNhapDetails : Form
    {
        public frmViewHoaDonNhapDetails()
        {
            InitializeComponent();
        }

        public void LoadData(HoaDonNhapResponse data)
        {
            if (data == null) return;

            lblMaHDN.Text = data.MaHDN ?? "";
            lblNgayNhap.Text = data.NgayNhap?.ToString("dd/MM/yyyy HH:mm") ?? "";
            lblNhaCungCap.Text = data.TenNCC ?? "Không có";
            lblNhanVien.Text = data.TenNV ?? "Không xác định";
            lblGhiChu.Text = string.IsNullOrWhiteSpace(data.GhiChu) ? "Không có ghi chú" : data.GhiChu;
            lblTrangThai.Text = data.TenTrangThai;
            dgvChiTiet.Rows.Clear();
            if (data.ChiTiet != null)
            {
                int stt = 1;
                foreach (var ct in data.ChiTiet)
                {
                    dgvChiTiet.Rows.Add(stt++, ct.MaSP, ct.TenSP, ct.SoLuong,
                        ct.DonGia.ToString("N0"), ct.ThanhTien.ToString("N0"));
                }
            }

            var tong = data.ChiTiet?.Sum(x => x.ThanhTien) ?? 0;
            lblTongTien.Text = tong > 0 ? tong.ToString("N0") + " ₫" : "0 ₫";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}