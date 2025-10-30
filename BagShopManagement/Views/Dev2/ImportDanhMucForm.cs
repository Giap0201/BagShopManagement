using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;

namespace BagShopManagement.Views.Dev2
{
    public partial class ImportDanhMucForm : Form
    {
        private readonly IDanhMucService _danhMucService;
        private DataTable _importData;

        public ImportDanhMucForm(IDanhMucService danhMucService)
        {
            InitializeComponent();
            _danhMucService = danhMucService;
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            LoadDanhMucOptions();
        }

        private void LoadDanhMucOptions()
        {
            cboTable.Items.AddRange(new string[]
            {
                "DanhMucLoaiTui",
                "DanhMucThuongHieu",
                "DanhMucChatLieu",
                "DanhMucMauSac",
                "DanhMucKichThuoc",
                "DanhMucNhaCungCap"
            });
            cboTable.SelectedIndex = 0;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Excel Files|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //txtFilePath.Text = ofd.FileName;
                    LoadExcelToGrid(ofd.FileName);
                }
            }
        }

        private void LoadExcelToGrid(string filePath)
        {
            _importData = new DataTable();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                bool hasHeader = true;
                foreach (var headerCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    _importData.Columns.Add(headerCell.Text);

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    var dataRow = _importData.NewRow();
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        dataRow[col - 1] = worksheet.Cells[row, col].Text;
                    _importData.Rows.Add(dataRow);
                }
            }
            dgvPreview.DataSource = _importData;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (_importData == null || _importData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để nhập!");
                return;
            }

            var table = cboTable.SelectedItem.ToString();
            int count = _danhMucService.ImportDanhMuc(table, _importData);

            MessageBox.Show($"Đã nhập thành công {count} dòng vào bảng {table}.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
