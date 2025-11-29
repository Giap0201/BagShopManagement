using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Utils
{
    public class InvoicePrintService
    {
        public void PrintInvoice(string maHDB)
        {
            try
            {
                var hoaDonRepo = new HoaDonBanRepository();
                var sanPhamRepo = new SanPhamRepository();

                var hoaDon = hoaDonRepo.GetByMaHDB(maHDB);
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var chiTiets = hoaDonRepo.GetChiTietByMaHDB(maHDB);
                if (chiTiets == null || chiTiets.Count == 0)
                {
                    MessageBox.Show("Hóa đơn không có chi tiết.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin sản phẩm
                var sanPhams = new List<SanPham>();
                foreach (var ct in chiTiets)
                {
                    var sp = sanPhamRepo.GetById(ct.MaSP);
                    if (sp != null) sanPhams.Add(sp);
                }

                // Tạo file Excel
                ExportToExcel(hoaDon, chiTiets, sanPhams);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log($"PrintInvoice Error: {ex.Message}");
            }
        }

        private void ExportToExcel(HoaDonBan hoaDon, List<ChiTietHoaDonBan> chiTiets, List<SanPham> sanPhams)
        {
            // Set license context cho EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Tạo tên file mặc định
            string defaultFileName = $"HoaDon_{hoaDon.MaHDB}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            string defaultFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HoaDon");

            // Hiển thị SaveFileDialog để người dùng chọn nơi lưu
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Lưu hóa đơn Excel";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.FileName = defaultFileName;
                saveFileDialog.InitialDirectory = defaultFolderPath;
                saveFileDialog.RestoreDirectory = true;

                // Nếu người dùng Cancel, thoát
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string filePath = saveFileDialog.FileName;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Hóa đơn");

                    // ========== TIÊU ĐỀ ==========
                    worksheet.Cells["A1:G1"].Merge = true;
                    worksheet.Cells["A1"].Value = "HÓA ĐƠN BÁN HÀNG";
                    worksheet.Cells["A1"].Style.Font.Size = 18;
                    worksheet.Cells["A1"].Style.Font.Bold = true;
                    worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Row(1).Height = 30;

                    // ========== THÔNG TIN HÓA ĐƠN ==========
                    int row = 3;
                    worksheet.Cells[$"A{row}"].Value = "Mã hóa đơn:";
                    worksheet.Cells[$"B{row}"].Value = hoaDon.MaHDB;
                    worksheet.Cells[$"A{row}"].Style.Font.Bold = true;
                    row++;

                    worksheet.Cells[$"A{row}"].Value = "Ngày bán:";
                    worksheet.Cells[$"B{row}"].Value = hoaDon.NgayBan.ToString("dd/MM/yyyy HH:mm");
                    worksheet.Cells[$"A{row}"].Style.Font.Bold = true;
                    row++;

                    worksheet.Cells[$"A{row}"].Value = "Mã khách hàng:";
                    worksheet.Cells[$"B{row}"].Value = hoaDon.MaKH ?? "Khách lẻ";
                    worksheet.Cells[$"A{row}"].Style.Font.Bold = true;
                    row++;

                    worksheet.Cells[$"A{row}"].Value = "Mã nhân viên:";
                    worksheet.Cells[$"B{row}"].Value = hoaDon.MaNV;
                    worksheet.Cells[$"A{row}"].Style.Font.Bold = true;
                    row++;

                    if (!string.IsNullOrWhiteSpace(hoaDon.PhuongThucTT))
                    {
                        worksheet.Cells[$"A{row}"].Value = "Phương thức thanh toán:";
                        worksheet.Cells[$"B{row}"].Value = hoaDon.PhuongThucTT;
                        worksheet.Cells[$"A{row}"].Style.Font.Bold = true;
                        row++;
                    }

                    string trangThai = hoaDon.TrangThaiHD switch
                    {
                        1 => "Tạm",
                        2 => "Hoàn thành",
                        3 => "Hủy",
                        _ => "Không xác định"
                    };
                    worksheet.Cells[$"A{row}"].Value = "Trạng thái:";
                    worksheet.Cells[$"B{row}"].Value = trangThai;
                    worksheet.Cells[$"A{row}"].Style.Font.Bold = true;
                    row++;

                    // ========== HEADER BẢNG CHI TIẾT ==========
                    row += 2;
                    int headerRow = row;

                    worksheet.Cells[$"A{headerRow}"].Value = "STT";
                    worksheet.Cells[$"B{headerRow}"].Value = "Mã sản phẩm";
                    worksheet.Cells[$"C{headerRow}"].Value = "Tên sản phẩm";
                    worksheet.Cells[$"D{headerRow}"].Value = "Số lượng";
                    worksheet.Cells[$"E{headerRow}"].Value = "Đơn giá";
                    worksheet.Cells[$"F{headerRow}"].Value = "Giảm giá/SP";
                    worksheet.Cells[$"G{headerRow}"].Value = "Thành tiền";

                    // Style header
                    using (var range = worksheet.Cells[$"A{headerRow}:G{headerRow}"])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
                        range.Style.Font.Color.SetColor(Color.White);
                        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }

                    // ========== CHI TIẾT SẢN PHẨM ==========
                    row++;
                    int startDataRow = row;
                    int stt = 1;

                    foreach (var ct in chiTiets)
                    {
                        var sp = sanPhams.FirstOrDefault(s => s.MaSP == ct.MaSP);
                        decimal thanhTien = (ct.DonGia - ct.GiamGiaSP) * ct.SoLuong;

                        worksheet.Cells[$"A{row}"].Value = stt;
                        worksheet.Cells[$"B{row}"].Value = ct.MaSP;
                        worksheet.Cells[$"C{row}"].Value = sp?.TenSP ?? "N/A";
                        worksheet.Cells[$"D{row}"].Value = ct.SoLuong;
                        worksheet.Cells[$"E{row}"].Value = ct.DonGia;
                        worksheet.Cells[$"F{row}"].Value = ct.GiamGiaSP;
                        worksheet.Cells[$"G{row}"].Value = thanhTien;

                        // Format số tiền
                        worksheet.Cells[$"E{row}"].Style.Numberformat.Format = "#,##0";
                        worksheet.Cells[$"F{row}"].Style.Numberformat.Format = "#,##0";
                        worksheet.Cells[$"G{row}"].Style.Numberformat.Format = "#,##0";

                        // Align center cho STT và SL
                        worksheet.Cells[$"A{row}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[$"D{row}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        // Border cho mỗi dòng
                        using (var range = worksheet.Cells[$"A{row}:G{row}"])
                        {
                            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        }

                        row++;
                        stt++;
                    }

                    // ========== TỔNG TIỀN ==========
                    row++;
                    decimal tongTien = chiTiets.Sum(ct => (ct.DonGia - ct.GiamGiaSP) * ct.SoLuong);

                    worksheet.Cells[$"F{row}"].Value = "TỔNG TIỀN:";
                    worksheet.Cells[$"F{row}"].Style.Font.Bold = true;
                    worksheet.Cells[$"F{row}"].Style.Font.Size = 12;
                    worksheet.Cells[$"F{row}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    worksheet.Cells[$"G{row}"].Value = tongTien;
                    worksheet.Cells[$"G{row}"].Style.Font.Bold = true;
                    worksheet.Cells[$"G{row}"].Style.Font.Size = 12;
                    worksheet.Cells[$"G{row}"].Style.Numberformat.Format = "#,##0";
                    worksheet.Cells[$"G{row}"].Style.Font.Color.SetColor(Color.Red);

                    // ========== GHI CHÚ ==========
                    if (!string.IsNullOrWhiteSpace(hoaDon.GhiChu))
                    {
                        row += 2;
                        worksheet.Cells[$"A{row}"].Value = "Ghi chú:";
                        worksheet.Cells[$"A{row}"].Style.Font.Bold = true;
                        row++;
                        worksheet.Cells[$"A{row}:G{row}"].Merge = true;
                        worksheet.Cells[$"A{row}"].Value = hoaDon.GhiChu;
                        worksheet.Cells[$"A{row}"].Style.WrapText = true;
                    }

                    // ========== FOOTER ==========
                    row += 3;
                    worksheet.Cells[$"A{row}:G{row}"].Merge = true;
                    worksheet.Cells[$"A{row}"].Value = "Cảm ơn quý khách!";
                    worksheet.Cells[$"A{row}"].Style.Font.Italic = true;
                    worksheet.Cells[$"A{row}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    // ========== TỰ ĐỘNG ĐIỀU CHỈNH ĐỘ RỘNG CỘT ==========
                    worksheet.Column(1).Width = 30;  // STT / Thông tin HĐ (cột A rộng hơn để hiển thị labels)
                    worksheet.Column(2).Width = 20;  // Mã SP / Giá trị thông tin
                    worksheet.Column(3).Width = 35;  // Tên SP
                    worksheet.Column(4).Width = 12;  // SL
                    worksheet.Column(5).Width = 15;  // Đơn giá
                    worksheet.Column(6).Width = 15;  // Giảm giá
                    worksheet.Column(7).Width = 18;  // Thành tiền

                    // ========== LƯU FILE ==========
                    try
                    {
                        package.SaveAs(new FileInfo(filePath));

                        // ========== MỞ FILE SAU KHI TẠO ==========
                        var result = MessageBox.Show(
                            $"✓ Đã xuất hóa đơn thành công!\n\nĐường dẫn: {filePath}\n\nBạn có muốn mở file ngay không?",
                            "Xuất Excel thành công",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                Process.Start(new ProcessStartInfo
                                {
                                    FileName = filePath,
                                    UseShellExecute = true
                                });
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Không thể mở file: {ex.Message}\n\nVui lòng mở thủ công tại:\n{filePath}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lưu file: {ex.Message}",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Log($"ExportToExcel SaveFile Error: {ex.Message}");
                    }
                }
            }
        }

        public void Dispose()
        {
            // No resources to dispose in Excel export
        }
    }
}