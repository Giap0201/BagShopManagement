using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Views.Dev3;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;


namespace BagShopManagement.Views.Dev3
{
    public partial class NhaCungCapControl : UserControl
    {
        private readonly NhaCungCapController _controller;

        public NhaCungCapControl()
        {
            _controller = new NhaCungCapController();
            InitializeComponent();
        }

        private void NhaCungCapControl_Load(object sender, EventArgs e)
        {
            dgvNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNCC.MultiSelect = false;
            LoadDanhSachNCC();
        }
        private void SetColumnHeadersNCC()
        {
            dgvNCC.Columns["MaNCC"].HeaderText = "Mã NCC";
            dgvNCC.Columns["TenNCC"].HeaderText = "Tên NCC";
            dgvNCC.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvNCC.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvNCC.Columns["Email"].HeaderText = "Email";
            dgvNCC.Columns["NguoiLienHe"].HeaderText = "Người liên hệ";

            // Căn giữa header tất cả cột
            foreach (DataGridViewColumn col in dgvNCC.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Căn giữa dữ liệu cho Mã NCC và SĐT
            dgvNCC.Columns["MaNCC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNCC.Columns["SoDienThoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Auto resize
            //dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvNCC.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        private void LoadDanhSachNCC()
        {
            try
            {
                var list = _controller.GetAll(); // Controller trả về List<NhaCungCap>
                dgvNCC.DataSource = list;
                SetColumnHeadersNCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải nhà cung cấp: {ex.Message}");
            }
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp", "Thông báo");
                txtTimKiem.Focus();
                return;
            }

            var ncc = _controller.GetById(txtTimKiem.Text.Trim());
            if (ncc == null)
            {
                MessageBox.Show("Nhà cung cấp không tồn tại", "Thông báo");
            }
            else
            {
                dgvNCC.DataSource = new List<NhaCungCap> { ncc };
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            using (var frm = new ThemNhaCungCapForm(_controller))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    dgvNCC.DataSource = _controller.GetAll();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var ncc = (NhaCungCap)dgvNCC.CurrentRow.DataBoundItem;
            using (var frm = new ThemNhaCungCapForm(_controller, ncc))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    dgvNCC.DataSource = _controller.GetAll();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNCC.SelectedRows.Count == 0) return;

            string maNCC = dgvNCC.SelectedRows[0].Cells["MaNCC"].Value.ToString();

            string message = $"Bạn có chắc chắn muốn xóa nhà cung cấp có mã '{maNCC}' không?";
            string title = "Xác nhận xóa";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (_controller.Delete(maNCC))
                {
                    MessageBox.Show($"Đã xóa nhà cung cấp '{maNCC}' thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNCC.DataSource = _controller.GetAll();
                }
                else
                {
                    MessageBox.Show($"Xóa nhà cung cấp '{maNCC}' không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvNCC_SelectionChanged(object sender, EventArgs e)
        {
 

            if (dgvNCC.SelectedRows.Count == 1 && !dgvNCC.SelectedRows[0].IsNewRow)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }

        }

        //private void NhaCungCapControl_Click(object sender, EventArgs e)
        //{
        //    dgvNCC.ClearSelection();
        //    btnSua.Visible = false;
        //    btnXoa.Visible = false;
        //}
        private void ExportExcel_EPPlus(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel file|*.xlsx";
            sfd.FileName = "NhaCungCap.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage pkg = new ExcelPackage())
            {
                var ws = pkg.Workbook.Worksheets.Add("NhaCungCap");

                // HEADER
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
                    ws.Cells[1, i + 1].Style.Font.Bold = true;
                    ws.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    ws.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // DATA
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                ws.Cells.AutoFitColumns();

                // Lưu file
                pkg.SaveAs(new FileInfo(sfd.FileName));
            }

            MessageBox.Show("Xuất Excel thành công!", "Thành công");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNCC.MultiSelect = false;
            LoadDanhSachNCC();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportExcel_EPPlus(dgvNCC);
        }
    }
}
