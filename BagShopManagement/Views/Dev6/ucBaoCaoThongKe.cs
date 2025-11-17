using BagShopManagement.Controllers;
using BagShopManagement.Utils;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BagShopManagement.Views.Dev6
{
    public partial class ucBaoCaoThongKe : UserControl
    {
        private readonly BaoCaoController _controller;
        private DataTable _currentData;
        private string _currentReportType = "doanhthu";

        public ucBaoCaoThongKe(BaoCaoController controller)
        {
            InitializeComponent();
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        private void ucBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;

            //HideAllViews();
            SelectMenuButton(btnDoanhThu);
            LoadCurrentReport();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e) => SelectReport("doanhthu", btnDoanhThu);

        private void btnNhapHang_Click(object sender, EventArgs e) => SelectReport("nhaphang", btnNhapHang);

        private void btnTonKho_Click(object sender, EventArgs e) => SelectReport("tonkho", btnTonKho);

        private void btnNhanVien_Click(object sender, EventArgs e) => SelectReport("nhanvien", btnNhanVien);

        private void btnKhachHang_Click(object sender, EventArgs e) => SelectReport("khachhang", btnKhachHang);

        private void btnSanPham_Click(object sender, EventArgs e) => SelectReport("sanpham", btnSanPham);

        private void btnGiamGia_Click(object sender, EventArgs e) => SelectReport("giamgia", btnGiamGia);

        private void SelectReport(string reportType, Button selectedButton)
        {
            _currentReportType = reportType;
            SelectMenuButton(selectedButton);
            LoadCurrentReport();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e) => LoadCurrentReport();

        private void LoadCurrentReport()
        {
            try
            {
                DateTime fromDate = dtpTuNgay.Value.Date;
                DateTime toDate = dtpDenNgay.Value.Date;

                _currentData = _currentReportType switch
                {
                    "doanhthu" => _controller.LayBaoCaoDoanhThuTheoNgay(fromDate, toDate),
                    "nhaphang" => _controller.LayBaoCaoNhapHang(fromDate, toDate),
                    "tonkho" => _controller.LayBaoCaoTonKho(),
                    "nhanvien" => _controller.LayBaoCaoDoanhThuTheoNhanVien(fromDate, toDate),
                    "khachhang" => _controller.LayBaoCaoKhachHangThanThiet(10),
                    "sanpham" => _controller.LayBaoCaoSanPhamBanChay(10, fromDate, toDate),
                    "giamgia" => _controller.LayBaoCaoChuongTrinhGiamGia(),
                    _ => null
                };

                DisplayReport(_currentData);
            }
            catch (Exception ex)
            {
                ShowError($"Không thể tải báo cáo:\n{ex.Message}");
            }
        }

        private void DisplayReport(DataTable data)
        {
            if (data == null || data.Rows.Count == 0)
            {
                ShowInfo("Không có dữ liệu trong khoảng thời gian này.");
                //HideAllViews();
                return;
            }

            _currentData = data;
            UpdateTitle();
            ShowGrid(data);
            //HideChart();
        }

        private void UpdateTitle()
        {
            lblTieuDe.Text = _currentReportType switch
            {
                "doanhthu" => $"DOANH THU TỪ {dtpTuNgay.Value:dd/MM/yyyy} → {dtpDenNgay.Value:dd/MM/yyyy}",
                "nhaphang" => $"NHẬP HÀNG TỪ {dtpTuNgay.Value:dd/MM/yyyy} → {dtpDenNgay.Value:dd/MM/yyyy}",
                "tonkho" => "TỒN KHO HIỆN TẠI",
                "nhanvien" => $"DOANH THU THEO NHÂN VIÊN ({dtpTuNgay.Value:dd/MM/yyyy} - {dtpDenNgay.Value:dd/MM/yyyy})",
                "khachhang" => "TOP 10 KHÁCH HÀNG THÂN THIẾT",
                "sanpham" => $"TOP 10 SẢN PHẨM BÁN CHẠY ({dtpTuNgay.Value:dd/MM/yyyy} - {dtpDenNgay.Value:dd/MM/yyyy})",
                "giamgia" => "CHƯƠNG TRÌNH GIẢM GIÁ",
                _ => "BÁO CÁO THỐNG KÊ"
            };
        }

        private void ShowGrid(DataTable data)
        {
            dgvBaoCao.DataSource = null;
            dgvBaoCao.DataSource = data;

            foreach (DataGridViewColumn col in dgvBaoCao.Columns)
            {
                col.HeaderText = FormatColumnHeader(col.Name);

                if (col.ValueType == typeof(decimal) || col.ValueType == typeof(double) || col.ValueType == typeof(int))
                {
                    if (col.Name.Contains("Tien") || col.Name.Contains("Thu") ||
                        col.Name.Contains("GiaTri") || col.Name.Contains("ChiTieu") ||
                        col.Name.Contains("SoLuong"))
                    {
                        col.DefaultCellStyle.Format = "N0";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }

            dgvBaoCao.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 252, 255);
            dgvBaoCao.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgvBaoCao.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvBaoCao.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 144, 255);
            dgvBaoCao.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBaoCao.EnableHeadersVisualStyles = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.Visible = true;
        }

        private string FormatColumnHeader(string columnName) => columnName switch
        {
            "NgayBan" => "Ngày bán",
            "SoHoaDon" => "Số hóa đơn",
            "TongDoanhThu" => "Tổng doanh thu",
            "NgayNhap" => "Ngày nhập",
            "SoPhieuNhap" => "Số phiếu nhập",
            "TongTienNhap" => "Tổng tiền nhập",
            "MaSP" => "Mã SP",
            "TenSP" => "Tên sản phẩm",
            "SoLuongTon" => "Tồn kho",
            "GiaTriTonKho" => "Giá trị tồn kho",
            "TenThuongHieu" => "Thương hiệu",
            "TenNCC" => "Nhà cung cấp",
            "MaNV" => "Mã NV",
            "TenNhanVien" => "Nhân viên",
            "MaKH" => "Mã KH",
            "TenKhachHang" => "Khách hàng",
            "SoLanMua" => "Số lần mua",
            "TongChiTieu" => "Tổng chi tiêu",
            "TongSoLuongBan" => "Số lượng bán",
            "TenChuongTrinh" => "Chương trình",
            "NgayBatDau" => "Ngày bắt đầu",
            "NgayKetThuc" => "Ngày kết thúc",
            "SoSanPhamApDung" => "Số SP áp dụng",
            "MucGiamTrungBinh" => "Mức giảm TB (%)",
            "TrangThai" => "Trạng thái",
            _ => columnName
        };

        //private void btnXemBieuDo_Click(object sender, EventArgs e)
        //{
        //    if (_currentData == null || _currentData.Rows.Count == 0)
        //    {
        //        ShowWarning("Không có dữ liệu để vẽ biểu đồ!");
        //        return;
        //    }

        //    chartDoanhThu.Series.Clear();
        //    chartDoanhThu.Titles.Clear();
        //    chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        //    chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;

        //    // Chọn biểu đồ phù hợp theo từng báo cáo
        //    switch (_currentReportType)
        //    {
        //        case "doanhthu":
        //            DrawChart("Doanh thu theo ngày", "NgayBan", "TongDoanhThu", SeriesChartType.Column, "Doanh thu (đ)");
        //            break;

        //        case "nhaphang":
        //            DrawChart("Chi phí nhập hàng", "NgayNhap", "TongTienNhap", SeriesChartType.Area, "Tiền nhập (đ)");
        //            break;

        //        case "tonkho":
        //            // Lỗi biểu đồ tồn kho thường do dữ liệu không phù hợp với biểu đồ cột
        //            // Thường tồn kho không nhiều nhóm, dùng Pie chart sẽ trực quan hơn
        //            DrawChart("Tồn kho theo sản phẩm", "TenSP", "SoLuongTon", SeriesChartType.Pie, "Số lượng tồn");
        //            break;

        //        case "nhanvien":
        //            // Doanh thu nhân viên nên dùng Bar chart hoặc Column chart, nếu tên dài thì Bar chart
        //            // Sửa lỗi bằng cách đổi thành Bar chart, tránh tràn nhãn tên nhân viên
        //            DrawChart("Doanh thu theo nhân viên", "TenNhanVien", "TongDoanhThu", SeriesChartType.Bar, "Doanh thu (đ)");
        //            break;

        //        case "sanpham":
        //            DrawChart("Top sản phẩm bán chạy", "TenSP", "TongSoLuongBan", SeriesChartType.Bar, "Số lượng bán");
        //            break;

        //        case "khachhang":
        //            DrawChart("Top khách hàng thân thiết", "TenKhachHang", "TongChiTieu", SeriesChartType.Pie, "Tổng chi tiêu");
        //            break;

        //        case "giamgia":
        //            ShowInfo("Biểu đồ giảm giá sẽ được bổ sung trong bản cập nhật tiếp theo.");
        //            break;

        //        default:
        //            ShowInfo("Chưa hỗ trợ biểu đồ cho loại báo cáo này.");
        //            break;
        //    }
        //}

        //private void DrawChart(string title, string xCol, string yCol, SeriesChartType chartType, string yTitle)
        //{
        //    var series = new Series("Data")
        //    {
        //        ChartType = chartType,
        //        XValueMember = xCol,
        //        YValueMembers = yCol,
        //        IsValueShownAsLabel = true,
        //        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
        //    };

        //    if (chartType == SeriesChartType.Pie || chartType == SeriesChartType.Doughnut)
        //    {
        //        series["PieLabelStyle"] = "Outside";
        //        series["PieLineColor"] = "Black";
        //    }

        //    chartDoanhThu.Series.Add(series);
        //    chartDoanhThu.DataSource = _currentData;
        //    chartDoanhThu.DataBind();

        //    chartDoanhThu.Titles.Add(title).Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        //    chartDoanhThu.ChartAreas[0].AxisY.Title = yTitle;
        //    chartDoanhThu.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 10F, FontStyle.Bold);

        //    chartDoanhThu.Visible = true;
        //    dgvBaoCao.Visible = false;
        //}

        //private void btnXemBang_Click(object sender, EventArgs e)
        //{
        //    dgvBaoCao.Visible = true;
        //    chartDoanhThu.Visible = false;
        //}

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (_currentData == null || _currentData.Rows.Count == 0)
            {
                ShowWarning("Không có dữ liệu để xuất Excel!");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = $"BaoCao_{_currentReportType}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var exportTable = _currentData.Copy();
                foreach (DataColumn col in exportTable.Columns)
                {
                    col.ColumnName = dgvBaoCao.Columns[col.ColumnName].HeaderText;
                }

                ExcelHelper.XuatBaoCaoChung(sfd.FileName, exportTable, lblTieuDe.Text);
                ShowSuccess("Xuất Excel thành công!");
                Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi xuất file Excel:\n" + ex.Message);
            }
        }

        private void SelectMenuButton(Button selected)
        {
            var buttons = new[] { btnDoanhThu, btnNhapHang, btnTonKho, btnNhanVien, btnKhachHang, btnSanPham, btnGiamGia };
            foreach (var btn in buttons)
            {
                btn.BackColor = SystemColors.Control;
                btn.ForeColor = SystemColors.ControlText;
            }
            selected.BackColor = Color.FromArgb(30, 144, 255);
            selected.ForeColor = Color.White;
        }

        private void ShowInfo(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void ShowWarning(string msg) => MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void ShowError(string msg) => MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ShowSuccess(string msg) => MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}