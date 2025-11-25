using BagShopManagement.Controllers;
using BagShopManagement.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using LicenseContext = OfficeOpenXml.LicenseContext;

namespace BagShopManagement.Views.Dev5
{
    public partial class TonKhoControl : UserControl
    {
        private readonly TonKhoController _controller;
        private List<SanPham> _danhSachSanPhamGoc; // Dùng để lưu danh sách gốc cho việc tìm kiếm
        private const int NGUONG_CANH_BAO = 10; // Ngưỡng tồn kho được coi là thấp

        public TonKhoControl(TonKhoController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        #region Form Events

        private void TonKhoControl_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            try
            {
                // Gọi controller để lấy danh sách sản phẩm
                _danhSachSanPhamGoc = _controller.GetInventoryProducts();

                // Gán dữ liệu vào DataGridView
                dgvTonKho.DataSource = null;
                dgvTonKho.DataSource = _danhSachSanPhamGoc;

                // Tùy chỉnh hiển thị cho GridView
                CustomizeGridView();

                // Cập nhật trạng thái của các nút hành động
                UpdateActionButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu tồn kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeGridView()
        {
            dgvTonKho.Columns.Clear();

            dgvTonKho.AutoGenerateColumns = false;

            // Cột Mã SP
            dgvTonKho.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSP",
                HeaderText = "Mã Sản Phẩm",
                Name = "MaSP"
            });

            // Cột Tên SP
            dgvTonKho.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSP",
                HeaderText = "Tên Sản Phẩm",
                Name = "TenSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Cột Tồn Kho
            dgvTonKho.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongTon",
                HeaderText = "Tồn Kho",
                Name = "SoLuongTon"
            });
        }


        private void btnDieuChinh_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có sản phẩm nào được chọn không
            if (dgvTonKho.CurrentRow?.DataBoundItem is SanPham selectedProduct)
            {
                // Mở form điều chỉnh và truyền sản phẩm đã chọn vào
                using (var formDieuChinh = new frmDieuChinhTonKho(selectedProduct))
                {
                    // Chỉ xử lý khi người dùng nhấn "Xác nhận"
                    if (formDieuChinh.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // TODO: Lấy mã nhân viên đang đăng nhập thực tế
                            string maNhanVien = "NV001";

                            // Gọi controller để thực hiện nghiệp vụ
                            _controller.AdjustStock(selectedProduct.MaSP, formDieuChinh.SoLuongMoi, maNhanVien, formDieuChinh.GhiChu);

                            MessageBox.Show("Điều chỉnh tồn kho thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Tải lại dữ liệu để cập nhật giao diện
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Điều chỉnh thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để điều chỉnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //private void btnXemLichSu_Click(object sender, EventArgs e)
        //{
        //    if (dgvTonKho.CurrentRow?.DataBoundItem is SanPham selectedProduct)
        //    {
        //        // Mở form lịch sử, truyền mã sản phẩm và controller vào
        //        var formLichSu = new frmLichSuTonKho(selectedProduct.MaSP, _controller);
        //        formLichSu.ShowDialog();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng chọn một sản phẩm để xem lịch sử.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            // Nếu không có từ khóa, hiển thị lại toàn bộ danh sách gốc
            if (string.IsNullOrEmpty(keyword))
            {
                dgvTonKho.DataSource = _danhSachSanPhamGoc;
            }
            else
            {
                // Dùng LINQ để lọc danh sách gốc dựa trên từ khóa
                var filteredList = _danhSachSanPhamGoc
                    .Where(sp => sp.MaSP.ToLower().Contains(keyword) || sp.TenSP.ToLower().Contains(keyword))
                    .ToList();
                dgvTonKho.DataSource = filteredList;
            }
        }

        // Sự kiện để tô màu cảnh báo tồn kho thấp
        private void dgvTonKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTonKho.Columns[e.ColumnIndex].Name == "SoLuongTon" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int soLuong))
                {
                    if (soLuong <= 0)
                    {
                        e.CellStyle.BackColor = Color.Salmon; // Màu đỏ cho hết hàng
                    }
                    else if (soLuong <= NGUONG_CANH_BAO)
                    {
                        e.CellStyle.BackColor = Color.LightYellow; // Màu vàng cho sắp hết
                    }
                    else
                    {
                        e.CellStyle.BackColor = dgvTonKho.DefaultCellStyle.BackColor; // Reset về màu mặc định
                    }
                }
            }
        }

        // Sự kiện để bật/tắt các nút hành động
        private void dgvTonKho_SelectionChanged(object sender, EventArgs e)
        {
            UpdateActionButtonsState();
        }

        private void UpdateActionButtonsState()
        {
            bool isRowSelected = (dgvTonKho.CurrentRow != null);
            btnDieuChinh.Enabled = isRowSelected;
            //btnXemLichSu.Enabled = isRowSelected;
        }

        #endregion

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Bước 1: Lấy danh sách dữ liệu hiện đang hiển thị trên DataGridView
            var listToExport = dgvTonKho.DataSource as List<SanPham>;

            // Kiểm tra xem có dữ liệu để xuất không
            if (listToExport == null || listToExport.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 2: Mở hộp thoại để người dùng chọn nơi lưu file
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Lưu báo cáo tồn kho";
                saveFileDialog.FileName = $"BaoCaoTonKho_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                // Chỉ tiếp tục nếu người dùng nhấn "Save"
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var fileInfo = new FileInfo(saveFileDialog.FileName);

                        // Ghi chú: Dòng khai báo LicenseContext nên được đặt ở Program.cs
                        // ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        // Bước 3: Tạo và ghi dữ liệu vào file Excel
                        using (var package = new ExcelPackage(fileInfo))
                        {
                            // Thêm một worksheet mới
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("BaoCaoTonKho");

                            // Định dạng và ghi Header
                            string[] headers = { "Mã Sản Phẩm", "Tên Sản Phẩm", "Số Lượng Tồn" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                worksheet.Cells[1, i + 1].Value = headers[i];
                            }

                            // Áp dụng style cho hàng header để trông chuyên nghiệp hơn
                            using (var range = worksheet.Cells[1, 1, 1, headers.Length])
                            {
                                range.Style.Font.Bold = true;
                                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 225, 242)); // Màu xanh nhạt
                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            // Ghi dữ liệu từ danh sách vào các dòng tiếp theo
                            int currentRow = 2;
                            foreach (var product in listToExport)
                            {
                                worksheet.Cells[currentRow, 1].Value = product.MaSP;
                                worksheet.Cells[currentRow, 2].Value = product.TenSP;
                                worksheet.Cells[currentRow, 3].Value = product.SoLuongTon;
                                currentRow++;
                            }

                            // Tự động căn chỉnh độ rộng của các cột
                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                            // Lưu file
                            package.Save();
                        }

                        // Bước 4: Thông báo thành công và hỏi người dùng có muốn mở file không
                        var result = MessageBox.Show(
                            $"Xuất file Excel thành công!\nBạn có muốn mở file vừa tạo không?",
                            "Thành công",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            // Mở file bằng ứng dụng mặc định của hệ điều hành
                            var processStartInfo = new ProcessStartInfo(saveFileDialog.FileName)
                            {
                                UseShellExecute = true
                            };
                            Process.Start(processStartInfo);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
