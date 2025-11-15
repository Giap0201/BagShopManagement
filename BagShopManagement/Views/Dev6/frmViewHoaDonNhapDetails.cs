using BagShopManagement.DTOs.Responses;
using BagShopManagement.Utils;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Excel = Microsoft.Office.Interop.Excel;

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

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_hd == null || _hd.ChiTiet == null || !_hd.ChiTiet.Any())
            {
                MessageBox.Show("Không có dữ liệu để xuất Execl!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // hien thi hop thoai luu file

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

        // Ham xuat file excel
        //private void XuatFileExcel(string duongDanFile, HoaDonNhapResponse hd)
        //{
        //    //tao file excel moi
        //    using (var package = new ExcelPackage())
        //    {
        //        // tao 1 sheet ten la phieu nhap hang
        //        var ws = package.Workbook.Worksheets.Add("Phiếu Nhập Hàng");
        //        int dong = 1; // dong hien tai

        //        // Ten cua hang
        //        ws.Cells[dong, 1, dong, 7].Merge = true;
        //        ws.Cells[dong, 1].Value = "TÚI XÁCH CAO CẤP LUXURY";
        //        ws.Cells[dong, 1].Style.Font.Size = 22;
        //        ws.Cells[dong, 1].Style.Font.Bold = true;
        //        ws.Cells[dong, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //        dong += 2;

        //        //tieu de phieu
        //        ws.Cells[dong, 1, dong, 7].Merge = true;
        //        ws.Cells[dong, 1].Value = "PHIẾU NHẬP HÀNG";
        //        ws.Cells[dong, 1].Style.Font.Size = 28;
        //        ws.Cells[dong, 1].Style.Font.Bold = true;
        //        ws.Cells[dong, 1].Style.Font.Color.SetColor(Color.DarkBlue);
        //        ws.Cells[dong, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //        dong += 3;

        //        // thong tin chung
        //        ws.Cells[dong, 1].Value = "Mã phiếu nhập:";
        //        ws.Cells[dong, 3].Value = hd.MaHDN;
        //        ws.Cells[dong, 5].Value = "Ngày nhập:";
        //        ws.Cells[dong, 6].Value = hd.NgayNhap?.ToString("dd/MM/yyyy HH:mm");
        //        dong++;

        //        ws.Cells[dong, 1].Value = "Nhà cung cấp:";
        //        ws.Cells[dong, 3].Value = hd.TenNCC;
        //        ws.Cells[dong, 5].Value = "Nhân viên nhập:";
        //        ws.Cells[dong, 6].Value = hd.TenNV;
        //        dong++;
        //        ws.Cells[dong, 1].Value = "Trạng thái:";
        //        ws.Cells[dong, 3].Value = hd.TenTrangThai;
        //        dong++;

        //        ws.Cells[dong, 1].Value = "Ghi chú:";
        //        ws.Cells[dong, 3, dong, 7].Merge = true;
        //        ws.Cells[dong, 3].Value = string.IsNullOrWhiteSpace(hd.GhiChu) ? "Không có" : hd.GhiChu;
        //        dong += 2;

        //        //tieu de bang chi tiet
        //        string[] tieuDe = { "STT", "Mã SP", "Tên sản phẩm", "SL", "Đơn giá", "Thành tiền" };
        //        for (int i = 0; i < tieuDe.Length; i++)
        //        {
        //            var cell = ws.Cells[dong, i + 1];
        //            cell.Value = tieuDe[i];
        //            cell.Style.Font.Bold = true;
        //            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            cell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
        //            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
        //        }
        //        dong++;

        //        // noi dung chi tiet
        //        int stt = 1;
        //        foreach (var ct in hd.ChiTiet)
        //        {
        //            ws.Cells[dong, 1].Value = stt++;
        //            ws.Cells[dong, 2].Value = ct.MaSP;
        //            ws.Cells[dong, 3].Value = ct.TenSP;
        //            ws.Cells[dong, 4].Value = ct.SoLuong;
        //            ws.Cells[dong, 5].Value = ct.DonGia;
        //            ws.Cells[dong, 5].Style.Numberformat.Format = "#,##0"; // Định dạng số
        //            ws.Cells[dong, 6].Value = ct.ThanhTien;
        //            ws.Cells[dong, 6].Style.Numberformat.Format = "#,##0";

        //            // Viền cho từng dòng
        //            ws.Cells[dong, 1, dong, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin);
        //            dong++;
        //        }

        //        //tong tien
        //        dong++;
        //        ws.Cells[dong, 1, dong, 4].Merge = true;
        //        ws.Cells[dong, 1].Value = "TỔNG CỘNG:";
        //        ws.Cells[dong, 1].Style.Font.Bold = true;
        //        ws.Cells[dong, 1].Style.Font.Size = 16;

        //        decimal tongCong = hd.ChiTiet.Sum(x => x.ThanhTien);
        //        ws.Cells[dong, 5, dong, 6].Merge = true;
        //        ws.Cells[dong, 5].Value = tongCong;
        //        ws.Cells[dong, 5].Style.Numberformat.Format = "#,##0";
        //        ws.Cells[dong, 5].Style.Font.Bold = true;
        //        ws.Cells[dong, 5].Style.Font.Color.SetColor(Color.Red);
        //        ws.Cells[dong, 5].Style.Font.Size = 16;

        //        dong += 3;
        //        ws.Cells[dong, 2].Value = "Người lập phiếu";
        //        ws.Cells[dong, 5].Value = "Người duyệt";
        //        ws.Cells[dong, 2].Style.Font.Bold = true;
        //        ws.Cells[dong, 5].Style.Font.Bold = true;

        //        dong += 4;
        //        ws.Cells[dong, 2].Value = "(Ký, ghi rõ họ tên)";
        //        ws.Cells[dong, 5].Value = "(Ký, ghi rõ họ tên)";

        //        // tu dong dieu chinh cot
        //        ws.Column(1).Width = 8;
        //        ws.Column(2).Width = 15;
        //        ws.Column(3).Width = 40;
        //        ws.Column(4).Width = 10;
        //        ws.Column(5).Width = 18;
        //        ws.Column(6).Width = 20;

        //        /// luu file
        //        var file = new FileInfo(duongDanFile);
        //        package.SaveAs(file);
        //    }
        //}
    }
}