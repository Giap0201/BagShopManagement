//using BagShopManagement.Services.Interfaces;
//using OfficeOpenXml;
//using System;
//using System.Data;
//using System.IO;
//using System.Linq;
//using System.Windows.Forms;

//namespace BagShopManagement.Views.Dev2
//{
//    public partial class ImportDanhMucForm : Form
//    {
//        private readonly IDanhMucService _danhMucService;
//        private DataTable _dataPreview;

//        public ImportDanhMucForm(IDanhMucService danhMucService)
//        {
//            InitializeComponent();
//            _danhMucService = danhMucService;

//            // Cấu hình bản quyền EPPlus
//            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//            // Gắn sự kiện cho nút
//            btnChonFile.Click += btnChonFile_Click;
//            btnImport.Click += btnImport_Click;
//            btnCancel.Click += btnCancel_Click;

//            // Load danh sách bảng danh mục
//            LoadDanhMucTables();
//        }

//        // Load tên bảng vào ComboBox
//        private void LoadDanhMucTables()
//        {
//            cboTableName.Items.Clear();
//            cboTableName.Items.AddRange(new string[]
//            {
//                "DanhMucLoaiTui",
//                "DanhMucThuongHieu",
//                "DanhMucChatLieu",
//                "DanhMucMauSac",
//                "DanhMucKichThuoc",
//                "DanhMucNhaCungCap"
//            });
//            cboTableName.SelectedIndex = 0;
//        }

//        // Bấm "Chọn file" → mở cửa sổ chọn Excel
//        private void btnChonFile_Click(object sender, EventArgs e)
//        {
//            using (var ofd = new OpenFileDialog())
//            {
//                ofd.Filter = "Excel Files|*.xlsx;*.xls";
//                ofd.Title = "Chọn tệp Excel chứa dữ liệu danh mục";

//                if (ofd.ShowDialog() == DialogResult.OK)
//                {
//                    txtFilePath.Text = ofd.FileName;
//                    LoadExcelToGrid(ofd.FileName);
//                }
//            }
//        }

//        // Đọc dữ liệu Excel đưa lên DataGridView
//        private void LoadExcelToGrid(string filePath)
//        {
//            try
//            {
//                using (var package = new ExcelPackage(new FileInfo(filePath)))
//                {
//                    var ws = package.Workbook.Worksheets.FirstOrDefault();
//                    if (ws == null)
//                    {
//                        MessageBox.Show("Không tìm thấy sheet nào trong file Excel!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        return;
//                    }

//                    var dt = new DataTable();

//                    // Lấy tên cột ở hàng đầu tiên
//                    foreach (var cell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
//                        dt.Columns.Add(cell.Text);

//                    // Đọc từng dòng dữ liệu
//                    for (int row = 2; row <= ws.Dimension.End.Row; row++)
//                    {
//                        var dr = dt.NewRow();
//                        for (int col = 1; col <= ws.Dimension.End.Column; col++)
//                            dr[col - 1] = ws.Cells[row, col].Text;
//                        dt.Rows.Add(dr);
//                    }

//                    _dataPreview = dt;
//                    dgvPreview.DataSource = dt;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // Nhập dữ liệu vào SQL
//        private void btnImport_Click(object sender, EventArgs e)
//        {
//            if (_dataPreview == null || _dataPreview.Rows.Count == 0)
//            {
//                MessageBox.Show("Chưa có dữ liệu để nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (cboTableName.SelectedItem == null)
//            {
//                MessageBox.Show("Vui lòng chọn bảng danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            string tableName = cboTableName.SelectedItem.ToString();

//            try
//            {
//                int count = _danhMucService.ImportDanhMuc(tableName, _dataPreview);
//                MessageBox.Show($"Đã nhập thành công {count} dòng vào bảng {tableName}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                this.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi nhập dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // Huỷ (đóng form)
//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//    }
//}

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using BagShopManagement.Controllers;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Interfaces;

namespace BagShopManagement.Views.Dev2
{
    public partial class ImportDanhMucForm : Form
    {
        private readonly DanhMucController _controller;

        public ImportDanhMucForm()
        {
            InitializeComponent();

            // Thiết lập LicenseContext cho EPPlus
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Khởi tạo controller (gắn kết Service & Repository)
            _controller = new DanhMucController(new DanhMucService(new DanhMucRepository()));

            LoadDanhMucTables();
        }

        public ImportDanhMucForm(IDanhMucService danhMucService)
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            _controller = new DanhMucController(danhMucService);
            LoadDanhMucTables();
        }

        private void LoadDanhMucTables()
        {
            cboTableName.Items.Clear();
            cboTableName.Items.AddRange(new string[]
            {
                "DanhMucLoaiTui",
                "ThuongHieu",
                "ChatLieu",
                "MauSac",
                "KichThuoc",
                "NhaCungCap"
            });
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName;
                    PreviewExcel(ofd.FileName);
                }
            }
        }

        private void PreviewExcel(string filePath)
        {
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var ws = package.Workbook.Worksheets[0];
                    var dt = new DataTable();

                    // Đọc header
                    for (int col = 1; col <= ws.Dimension.End.Column; col++)
                    {
                        dt.Columns.Add(ws.Cells[1, col].Text);
                    }

                    // Đọc nội dung
                    for (int row = 2; row <= ws.Dimension.End.Row; row++)
                    {
                        var dr = dt.NewRow();
                        for (int col = 1; col <= ws.Dimension.End.Column; col++)
                            dr[col - 1] = ws.Cells[row, col].Text;
                        dt.Rows.Add(dr);
                    }

                    dgvPreview.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể đọc file Excel: {ex.Message}");
            }
        }

        //private void btnImport_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtFilePath.Text) || cboTableName.SelectedIndex < 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn file và bảng đích!");
        //        return;
        //    }

        //    try
        //    {
        //        using (var package = new ExcelPackage(new FileInfo(txtFilePath.Text)))
        //        {
        //            var ws = package.Workbook.Worksheets[0];
        //            var tableName = cboTableName.SelectedItem.ToString();

        //            int imported = _controller.ImportFromExcel(ws, tableName);

        //            MessageBox.Show($"Import thành công {imported} dòng vào {tableName}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi import: {ex.Message}");
        //    }
        //}

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFilePath.Text))
                {
                    MessageBox.Show("Vui lòng chọn file Excel trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboTableName.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn bảng cần nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tableName = cboTableName.SelectedItem.ToString();
                int count = 0;

                using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(txtFilePath.Text)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    count = _controller.ImportFromExcel(worksheet, tableName);
                }

                MessageBox.Show($"Nhập thành công {count} dòng vào bảng {tableName}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
