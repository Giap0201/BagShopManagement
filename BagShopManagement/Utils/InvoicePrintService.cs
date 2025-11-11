using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Utils
{
    public class InvoicePrintService
    {
        private HoaDonBan? _hoaDon;
        private List<ChiTietHoaDonBan>? _chiTiets;
        private List<SanPham>? _sanPhams;
        private PrintDocument? _printDocument;
        private Font? _titleFont;
        private Font? _headerFont;
        private Font? _normalFont;
        private int _yPos;
        private int _leftMargin;
        private int _rightMargin;

        public void PrintInvoice(string maHDB)
        {
            try
            {
                var hoaDonRepo = new HoaDonBanRepository();
                var sanPhamRepo = new SanPhamRepository();

                _hoaDon = hoaDonRepo.GetByMaHDB(maHDB);
                if (_hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _chiTiets = hoaDonRepo.GetChiTietByMaHDB(maHDB);
                if (_chiTiets == null || _chiTiets.Count == 0)
                {
                    MessageBox.Show("Hóa đơn không có chi tiết.", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin sản phẩm
                _sanPhams = new List<SanPham>();
                foreach (var ct in _chiTiets)
                {
                    var sp = sanPhamRepo.GetByMaSP(ct.MaSP);
                    if (sp != null) _sanPhams.Add(sp);
                }

                // Setup fonts
                _titleFont = new Font("Arial", 16, FontStyle.Bold);
                _headerFont = new Font("Arial", 10, FontStyle.Bold);
                _normalFont = new Font("Arial", 9, FontStyle.Regular);

                // Setup print document
                _printDocument = new PrintDocument();
                _printDocument.PrintPage += PrintDocument_PrintPage;

                // Show print dialog
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = _printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_hoaDon == null || _chiTiets == null) return;

            Graphics g = e.Graphics!;
            _leftMargin = 50;
            _rightMargin = (int)e.MarginBounds.Right - 50;
            _yPos = 50;

            // Title
            string title = "HÓA ĐƠN BÁN HÀNG";
            SizeF titleSize = g.MeasureString(title, _titleFont!);
            g.DrawString(title, _titleFont!, Brushes.Black, 
                new PointF((e.PageBounds.Width - titleSize.Width) / 2, _yPos));
            _yPos += (int)titleSize.Height + 20;

            // Line
            g.DrawLine(Pens.Black, _leftMargin, _yPos, _rightMargin, _yPos);
            _yPos += 15;

            // Thông tin hóa đơn
            g.DrawString($"Mã HĐ: {_hoaDon.MaHDB}", _normalFont!, Brushes.Black, 
                new PointF(_leftMargin, _yPos));
            _yPos += 20;

            g.DrawString($"Ngày bán: {_hoaDon.NgayBan:dd/MM/yyyy HH:mm}", _normalFont!, 
                Brushes.Black, new PointF(_leftMargin, _yPos));
            _yPos += 20;

            g.DrawString($"Mã KH: {(_hoaDon.MaKH ?? "Khách lẻ")}", _normalFont!, 
                Brushes.Black, new PointF(_leftMargin, _yPos));
            _yPos += 20;

            g.DrawString($"Mã NV: {_hoaDon.MaNV}", _normalFont!, Brushes.Black, 
                new PointF(_leftMargin, _yPos));
            _yPos += 20;

            if (!string.IsNullOrWhiteSpace(_hoaDon.PhuongThucTT))
            {
                g.DrawString($"Phương thức TT: {_hoaDon.PhuongThucTT}", _normalFont!, 
                    Brushes.Black, new PointF(_leftMargin, _yPos));
                _yPos += 20;
            }

            _yPos += 10;
            g.DrawLine(Pens.Black, _leftMargin, _yPos, _rightMargin, _yPos);
            _yPos += 15;

            // Header bảng
            int col1 = _leftMargin;                    // STT
            int col2 = col1 + 40;                      // Mã SP
            int col3 = col2 + 100;                     // Tên SP
            int col4 = col3 + 200;                     // SL
            int col5 = col4 + 80;                      // Đơn giá
            int col6 = col5 + 100;                     // Giảm giá
            int col7 = col6 + 100;                     // Thành tiền

            g.DrawString("STT", _headerFont!, Brushes.Black, new PointF(col1, _yPos));
            g.DrawString("Mã SP", _headerFont!, Brushes.Black, new PointF(col2, _yPos));
            g.DrawString("Tên sản phẩm", _headerFont!, Brushes.Black, new PointF(col3, _yPos));
            g.DrawString("SL", _headerFont!, Brushes.Black, new PointF(col4, _yPos));
            g.DrawString("Đơn giá", _headerFont!, Brushes.Black, new PointF(col5, _yPos));
            g.DrawString("Giảm giá", _headerFont!, Brushes.Black, new PointF(col6, _yPos));
            g.DrawString("Thành tiền", _headerFont!, Brushes.Black, new PointF(col7, _yPos));
            _yPos += 25;

            g.DrawLine(Pens.Black, _leftMargin, _yPos, _rightMargin, _yPos);
            _yPos += 10;

            // Chi tiết
            int stt = 1;
            foreach (var ct in _chiTiets)
            {
                if (_yPos > e.PageBounds.Height - 100) // Kiểm tra hết trang
                {
                    e.HasMorePages = true;
                    return;
                }

                var sp = _sanPhams?.FirstOrDefault(s => s.MaSP == ct.MaSP);
                string tenSP = sp?.TenSP ?? "N/A";
                decimal thanhTien = (ct.DonGia - ct.GiamGiaSP) * ct.SoLuong;

                g.DrawString(stt.ToString(), _normalFont!, Brushes.Black, new PointF(col1, _yPos));
                g.DrawString(ct.MaSP, _normalFont!, Brushes.Black, new PointF(col2, _yPos));
                
                // Tên SP có thể dài, cắt nếu quá dài
                if (tenSP.Length > 25) tenSP = tenSP.Substring(0, 22) + "...";
                g.DrawString(tenSP, _normalFont!, Brushes.Black, new PointF(col3, _yPos));
                
                g.DrawString(ct.SoLuong.ToString(), _normalFont!, Brushes.Black, new PointF(col4, _yPos));
                g.DrawString(ct.DonGia.ToString("N0"), _normalFont!, Brushes.Black, new PointF(col5, _yPos));
                g.DrawString(ct.GiamGiaSP.ToString("N0"), _normalFont!, Brushes.Black, new PointF(col6, _yPos));
                g.DrawString(thanhTien.ToString("N0"), _normalFont!, Brushes.Black, new PointF(col7, _yPos));

                _yPos += 20;
                stt++;
            }

            _yPos += 10;
            g.DrawLine(Pens.Black, _leftMargin, _yPos, _rightMargin, _yPos);
            _yPos += 15;

            // Tổng tiền
            decimal tongTien = _chiTiets.Sum(ct => (ct.DonGia - ct.GiamGiaSP) * ct.SoLuong);
            string tongTienText = $"TỔNG TIỀN: {tongTien:N0} ₫";
            SizeF tongTienSize = g.MeasureString(tongTienText, _headerFont!);
            g.DrawString(tongTienText, _headerFont!, Brushes.Black, 
                new PointF(_rightMargin - tongTienSize.Width, _yPos));
            _yPos += 30;

            // Ghi chú
            if (!string.IsNullOrWhiteSpace(_hoaDon.GhiChu))
            {
                g.DrawString("Ghi chú:", _normalFont!, Brushes.Black, new PointF(_leftMargin, _yPos));
                _yPos += 20;
                g.DrawString(_hoaDon.GhiChu, _normalFont!, Brushes.Black, new PointF(_leftMargin, _yPos));
                _yPos += 20;
            }

            // Footer
            _yPos += 20;
            g.DrawLine(Pens.Black, _leftMargin, _yPos, _rightMargin, _yPos);
            _yPos += 15;
            g.DrawString("Cảm ơn quý khách!", _normalFont!, Brushes.Black, 
                new PointF((e.PageBounds.Width - g.MeasureString("Cảm ơn quý khách!", _normalFont!).Width) / 2, _yPos));

            e.HasMorePages = false;
        }

        public void Dispose()
        {
            _titleFont?.Dispose();
            _headerFont?.Dispose();
            _normalFont?.Dispose();
            _printDocument?.Dispose();
        }
    }
}

