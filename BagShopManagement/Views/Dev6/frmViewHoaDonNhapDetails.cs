using BagShopManagement.DTOs.Responses;
using BagShopManagement.Utils;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BagShopManagement.Views.Dev6
{
    public partial class frmViewHoaDonNhapDetails : Form
    {
        private HoaDonNhapResponse _hd;

        public frmViewHoaDonNhapDetails()
        {
            InitializeComponent();
        }

        public void LoadData(HoaDonNhapResponse data)
        {
            if (data == null) return;

            _hd = data;
            lblMaHDN.Text = data.MaHDN ?? "";
            lblNgayNhap.Text = data.NgayNhap?.ToString("dd/MM/yyyy HH:mm") ?? "N/A";
            lblNhaCungCap.Text = data.TenNCC ?? "Không có";
            lblNhanVien.Text = data.TenNV ?? "Không xác định";
            lblGhiChu.Text = string.IsNullOrWhiteSpace(data.GhiChu) ?
                             "Không có ghi chú" : data.GhiChu;
            lblTrangThai.Text = data.TenTrangThai;
            lblNgayDuyetText.Text = data.NgayDuyet?.ToString("dd/MM/yyyy HH:mm") ?? "N/A";
            lblNgayHuyText.Text = data.NgayHuy?.ToString("dd/MM/yyyy HH:mm") ?? "N/A";
            dgvChiTiet.DataSource = null;
            if (data.ChiTiet != null)
            {
                dgvChiTiet.DataSource = new BindingList<ChiTietHDNResponse>(data.ChiTiet);
            }

            FormatGrid();
            UpdateTongTien();
        }

        private void UpdateTongTien()
        {
            var list = dgvChiTiet.DataSource as IList<ChiTietHDNResponse>;
            lblTongTien.Text = list?.Sum(x => x.ThanhTien).ToString("N0") ?? "0";
        }

        private void FormatGrid()
        {
            if (dgvChiTiet.Columns.Count == 0) return;

            dgvChiTiet.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dgvChiTiet.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvChiTiet.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
            //Format so
            dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_hd == null || _hd.ChiTiet == null || !_hd.ChiTiet.Any())
            {
                MessageBox.Show("Không có dữ liệu để xuất Execl!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SaveFileDialog saveDlg = new SaveFileDialog())
            {
                saveDlg.Filter = "Execl Workbook (*.xlxs)|*.xlxs";
                saveDlg.FileName = $"PhieuNhap_{_hd.MaHDN}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                saveDlg.Title = "Chọn nơi lưu phiếu nhập hàng";
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelHelper.XuatPhieuNhapHang(saveDlg.FileName, _hd);
                        MessageBox.Show($"Xuất phiếu nhập hàng thành công!\n\nĐã lưu tại:\n{saveDlg.FileName}", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Tu dong mo file exel sau khi xuat
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = saveDlg.FileName,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file Excel:\n{ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}