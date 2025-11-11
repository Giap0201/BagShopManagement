using BagShopManagement.Controllers;
using BagShopManagement.Models;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev3
{
    public partial class ThemNhaCungCapForm : Form
    {
        private readonly NhaCungCapController _controller;
        private readonly NhaCungCap _ncc;
        private readonly bool _isEdit;

        public ThemNhaCungCapForm(NhaCungCapController controller, NhaCungCap ncc = null)
        {
            InitializeComponent();
            _controller = controller;
            _ncc = ncc;
            _isEdit = ncc != null;

            if (_isEdit)
            {
                this.Text = "Chỉnh sửa thông tin nhà cung cấp";
                LoadNCCToForm(ncc);
            }
            else
            {
                this.Text = "Thêm nhà cung cấp mới";
            }
        }

        private void LoadNCCToForm(NhaCungCap ncc)
        {
            txtMaNCC.Text = ncc.MaNCC;
            txtTenNCC.Text = ncc.TenNCC;
            txtDiaChi.Text = ncc.DiaChi;
            txtSoDienThoai.Text = ncc.SoDienThoai;
            txtEmail.Text = ncc.Email;
            txtNguoiLienHe.Text = ncc.NguoiLienHe;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }

            var ncc = new NhaCungCap
            {
                MaNCC = txtMaNCC.Text.Trim(),
                TenNCC = txtTenNCC.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NguoiLienHe = txtNguoiLienHe.Text.Trim()
            };

            bool success;
            if (_isEdit)
                success = _controller.Update(ncc);
            else
                success = _controller.Add(ncc);

            if (success)
            {
                MessageBox.Show("Lưu thông tin nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể lưu thông tin nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
