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
                txtMaNCC.Text = _controller.GenerateNextCode();
            }
        }
        private void ThemNhaCungCapForm_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.KeyDown += MoveNextOnEnter;
                }
            }
        }

        private void MoveNextOnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
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
            string maNCC = txtMaNCC.Text.Trim();
            if (string.IsNullOrWhiteSpace(maNCC))
            {
                MessageBox.Show("Vui lòng nhập Mã nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }
            string tenNCC = txtTenNCC.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenNCC))
            {
                MessageBox.Show("Vui lòng nhập Tên nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email) &&
                !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Định dạng Email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // 2. Kiểm tra Số điện thoại (nếu có nhập thì phải đúng 10 số VN)
            string soDienThoai = txtSoDienThoai.Text.Trim();
            if (!string.IsNullOrWhiteSpace(soDienThoai) &&
                !System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 số bắt đầu bằng 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            var ncc = new NhaCungCap
            {
                MaNCC = maNCC,
                TenNCC = tenNCC,
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = soDienThoai,
                Email = email,
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
