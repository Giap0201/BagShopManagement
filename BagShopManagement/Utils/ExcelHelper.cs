using BagShopManagement.DTOs.Responses;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Utils
{
    public static class ExcelHelper
    {
        public static void XuatPhieuNhapHang(string duongDanFile, HoaDonNhapResponse hd)
        {
            //tao file excel moi
            using (var package = new ExcelPackage())
            {
                // tao 1 sheet ten la phieu nhap hang
                var ws = package.Workbook.Worksheets.Add("Phiếu Nhập Hàng");
                int dong = 1; // dong hien tai

                // Ten cua hang
                ws.Cells[dong, 1, dong, 7].Merge = true;
                ws.Cells[dong, 1].Value = "TÚI XÁCH CAO CẤP LUXURY";
                ws.Cells[dong, 1].Style.Font.Size = 22;
                ws.Cells[dong, 1].Style.Font.Bold = true;
                ws.Cells[dong, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                dong += 2;

                //tieu de phieu
                ws.Cells[dong, 1, dong, 7].Merge = true;
                ws.Cells[dong, 1].Value = "PHIẾU NHẬP HÀNG";
                ws.Cells[dong, 1].Style.Font.Size = 28;
                ws.Cells[dong, 1].Style.Font.Bold = true;
                ws.Cells[dong, 1].Style.Font.Color.SetColor(Color.DarkBlue);
                ws.Cells[dong, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                dong += 3;

                // thong tin chung
                ws.Cells[dong, 1].Value = "Mã phiếu nhập:";
                ws.Cells[dong, 3].Value = hd.MaHDN;
                ws.Cells[dong, 5].Value = "Ngày nhập:";
                ws.Cells[dong, 6].Value = hd.NgayNhap?.ToString("dd/MM/yyyy HH:mm");
                dong++;

                ws.Cells[dong, 1].Value = "Nhà cung cấp:";
                ws.Cells[dong, 3].Value = hd.TenNCC;
                ws.Cells[dong, 5].Value = "Nhân viên nhập:";
                ws.Cells[dong, 6].Value = hd.TenNV;
                dong++;
                ws.Cells[dong, 1].Value = "Trạng thái:";
                ws.Cells[dong, 3].Value = hd.TenTrangThai;
                dong++;

                ws.Cells[dong, 1].Value = "Ghi chú:";
                ws.Cells[dong, 3, dong, 7].Merge = true;
                ws.Cells[dong, 3].Value = string.IsNullOrWhiteSpace(hd.GhiChu) ? "Không có" : hd.GhiChu;
                dong += 2;

                //tieu de bang chi tiet
                string[] tieuDe = { "STT", "Mã SP", "Tên sản phẩm", "SL", "Đơn giá", "Thành tiền" };
                for (int i = 0; i < tieuDe.Length; i++)
                {
                    var cell = ws.Cells[dong, i + 1];
                    cell.Value = tieuDe[i];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
                dong++;

                // noi dung chi tiet
                int stt = 1;
                foreach (var ct in hd.ChiTiet)
                {
                    ws.Cells[dong, 1].Value = stt++;
                    ws.Cells[dong, 2].Value = ct.MaSP;
                    ws.Cells[dong, 3].Value = ct.TenSP;
                    ws.Cells[dong, 4].Value = ct.SoLuong;
                    ws.Cells[dong, 5].Value = ct.DonGia;
                    ws.Cells[dong, 5].Style.Numberformat.Format = "#,##0"; // Định dạng số
                    ws.Cells[dong, 6].Value = ct.ThanhTien;
                    ws.Cells[dong, 6].Style.Numberformat.Format = "#,##0";

                    // Viền cho từng dòng
                    ws.Cells[dong, 1, dong, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    dong++;
                }

                //tong tien
                dong++;
                ws.Cells[dong, 1, dong, 4].Merge = true;
                ws.Cells[dong, 1].Value = "TỔNG CỘNG:";
                ws.Cells[dong, 1].Style.Font.Bold = true;
                ws.Cells[dong, 1].Style.Font.Size = 16;

                decimal tongCong = hd.ChiTiet.Sum(x => x.ThanhTien);
                ws.Cells[dong, 5, dong, 6].Merge = true;
                ws.Cells[dong, 5].Value = tongCong;
                ws.Cells[dong, 5].Style.Numberformat.Format = "#,##0";
                ws.Cells[dong, 5].Style.Font.Bold = true;
                ws.Cells[dong, 5].Style.Font.Color.SetColor(Color.Red);
                ws.Cells[dong, 5].Style.Font.Size = 16;

                dong += 3;
                ws.Cells[dong, 2].Value = "Người lập phiếu";
                ws.Cells[dong, 5].Value = "Người duyệt";
                ws.Cells[dong, 2].Style.Font.Bold = true;
                ws.Cells[dong, 5].Style.Font.Bold = true;

                dong += 4;
                ws.Cells[dong, 2].Value = "(Ký, ghi rõ họ tên)";
                ws.Cells[dong, 5].Value = "(Ký, ghi rõ họ tên)";

                // tu dong dieu chinh cot
                ws.Column(1).Width = 8;
                ws.Column(2).Width = 15;
                ws.Column(3).Width = 40;
                ws.Column(4).Width = 10;
                ws.Column(5).Width = 18;
                ws.Column(6).Width = 20;

                /// luu file
                var file = new FileInfo(duongDanFile);
                package.SaveAs(file);
            }
        }

        /// <summary>
        /// Xuất toàn bộ danh sách hóa đơn nhập ra file Excel (báo cáo đẹp)
        /// - Ngày duyệt, ngày hủy nếu null → hiển thị "N/A"
        /// </summary>
        public static void XuatDanhSachHoaDonNhap(string filePath, List<HoaDonNhapResponse> danhSach)
        {
            if (danhSach == null || !danhSach.Any())
                throw new ArgumentException("Danh sách hóa đơn trống!");

            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Danh Sách Hóa Đơn Nhập");

            // === Tiêu đề lớn ===
            ws.Cells[1, 1].Value = "DANH SÁCH HÓA ĐƠN NHẬP HÀNG";
            ws.Cells[1, 1, 1, 10].Merge = true;
            ws.Cells[1, 1].Style.Font.Size = 18;
            ws.Cells[1, 1].Style.Font.Bold = true;
            ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // === Ngày xuất ===
            ws.Cells[2, 1].Value = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}";
            ws.Cells[2, 1, 2, 10].Merge = true;
            ws.Cells[2, 1].Style.Font.Italic = true;

            // === Header bảng (10 cột) ===
            string[] headers = {
        "STT", "Mã HĐN", "Ngày nhập", "Nhà cung cấp", "Nhân viên",
        "Tổng tiền", "Trạng thái", "Ngày duyệt", "Ngày hủy", "Ghi chú"
    };

            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cells[4, i + 1];
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Font.Color.SetColor(Color.White);
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 102, 204)); // Xanh đậm đẹp
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }

            // === Đổ dữ liệu ===
            int row = 5;
            int stt = 1;
            decimal tongCong = 0;

            foreach (var hd in danhSach)
            {
                ws.Cells[row, 1].Value = stt++;
                ws.Cells[row, 2].Value = hd.MaHDN;
                ws.Cells[row, 3].Value = hd.NgayNhap?.ToString("dd/MM/yyyy HH:mm") ?? "N/A";
                ws.Cells[row, 4].Value = hd.TenNCC ?? "N/A";
                ws.Cells[row, 5].Value = hd.TenNV ?? "N/A";

                // Tổng tiền
                ws.Cells[row, 6].Value = hd.TongTien;
                ws.Cells[row, 6].Style.Numberformat.Format = "#,##0";
                tongCong += hd.TongTien;

                ws.Cells[row, 7].Value = hd.TenTrangThai ?? "N/A";

                // Ngày duyệt: nếu null → "N/A"
                ws.Cells[row, 8].Value = hd.NgayDuyet.HasValue
                    ? hd.NgayDuyet.Value.ToString("dd/MM/yyyy")
                    : "N/A";

                // Ngày hủy: nếu null → "N/A"
                ws.Cells[row, 9].Value = hd.NgayHuy.HasValue
                    ? hd.NgayHuy.Value.ToString("dd/MM/yyyy")
                    : "N/A";

                ws.Cells[row, 10].Value = hd.GhiChu ?? "";

                row++;
            }

            // === Dòng tổng cộng ===
            ws.Cells[row, 1].Value = "TỔNG CỘNG:";
            ws.Cells[row, 1, row, 5].Merge = true;
            ws.Cells[row, 1].Style.Font.Bold = true;
            ws.Cells[row, 1].Style.Font.Size = 12;
            ws.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells[row, 6].Value = tongCong;
            ws.Cells[row, 6].Style.Numberformat.Format = "#,##0";
            ws.Cells[row, 6].Style.Font.Bold = true;
            ws.Cells[row, 6].Style.Font.Color.SetColor(Color.Red);
            ws.Cells[row, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[row, 6].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            // === Viền bảng + định dạng ===
            var dataRange = ws.Cells[4, 1, row, 10];
            dataRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            dataRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            dataRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            dataRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

            // Header viền đậm
            ws.Cells[4, 1, 4, 10].Style.Border.BorderAround(ExcelBorderStyle.Medium);

            // Tự động co giãn cột
            ws.Cells[1, 1, row, 10].AutoFitColumns(15);
            ws.Column(1).Width = 8;  // STT
            ws.Column(2).Width = 18; // Mã HĐN
            ws.Column(6).Width = 18; // Tổng tiền

            // Căn giữa cột STT, Tổng tiền
            ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Column(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            // Lưu file
            package.SaveAs(new FileInfo(filePath));
        }

        //public static void XuatBaoCaoChung(string filePath, DataTable data, string tieuDe)
        //{
        //    using var package = new ExcelPackage();
        //    var ws = package.Workbook.Worksheets.Add("Báo cáo");

        //    ws.Cells[1, 1].Value = tieuDe;
        //    ws.Cells[1, 1, 1, data.Columns.Count].Merge = true;
        //    ws.Cells[1, 1].Style.Font.Size = 16;
        //    ws.Cells[1, 1].Style.Font.Bold = true;
        //    ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        //    ws.Cells[2, 1].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
        //    ws.Cells[2, 1, 2, data.Columns.Count].Merge = true;

        //    // Header
        //    for (int i = 0; i < data.Columns.Count; i++)
        //    {
        //        ws.Cells[4, i + 1].Value = data.Columns[i].ColumnName;
        //        ws.Cells[4, i + 1].Style.Font.Bold = true;
        //        ws.Cells[4, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //        ws.Cells[4, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
        //    }

        //    // Data
        //    ws.Cells[5, 1].LoadFromDataTable(data, false);

        //    ws.Cells[1, 1, 4 + data.Rows.Count, data.Columns.Count].AutoFitColumns();
        //    package.SaveAs(new FileInfo(filePath));
        //}
        public static void XuatBaoCaoChung(string filePath, DataTable data, string tieuDe)
        {
            // Convert string date → DateTime
            foreach (DataColumn col in data.Columns)
            {
                if (col.ColumnName.ToLower().Contains("ngay")) // cột NgayBan, NgayNhap, NgayTao...
                {
                    if (col.DataType != typeof(DateTime))
                    {
                        // Tạo cột DateTime tạm
                        DataColumn newCol = new DataColumn(col.ColumnName + "_dt", typeof(DateTime));

                        data.Columns.Add(newCol);

                        foreach (DataRow row in data.Rows)
                        {
                            DateTime dt;
                            if (DateTime.TryParse(row[col.ColumnName]?.ToString(), out dt))
                                row[newCol.ColumnName] = dt;
                        }

                        // Xóa cột cũ & đổi tên cột mới
                        data.Columns.Remove(col);
                        newCol.ColumnName = col.ColumnName;
                    }
                }
            }

            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Báo cáo");

            ws.Cells[1, 1].Value = tieuDe;
            ws.Cells[1, 1, 1, data.Columns.Count].Merge = true;
            ws.Cells[1, 1].Style.Font.Size = 16;
            ws.Cells[1, 1].Style.Font.Bold = true;
            ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 1].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
            ws.Cells[2, 1, 2, data.Columns.Count].Merge = true;

            // Header
            for (int i = 0; i < data.Columns.Count; i++)
            {
                ws.Cells[4, i + 1].Value = data.Columns[i].ColumnName;
                ws.Cells[4, i + 1].Style.Font.Bold = true;
                ws.Cells[4, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[4, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
            }

            // Data
            ws.Cells[5, 1].LoadFromDataTable(data, false);

            // Format lại cột ngày trong Excel
            for (int col = 1; col <= data.Columns.Count; col++)
            {
                if (data.Columns[col - 1].DataType == typeof(DateTime))
                {
                    ws.Column(col).Style.Numberformat.Format = "dd/MM/yyyy";
                }
            }

            ws.Cells[1, 1, 4 + data.Rows.Count, data.Columns.Count].AutoFitColumns();
            package.SaveAs(new FileInfo(filePath));
        }
    }
}