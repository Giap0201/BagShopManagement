using BagShopManagement.Controllers;
using BagShopManagement.Models;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev3
{
    public partial class ThemKhachHangForm2 : Form
    {
        private readonly KhachHangController _controller;
        private readonly KhachHang? _khachHang;
        private readonly bool _isEdit;

        public ThemKhachHangForm2(KhachHangController controller, KhachHang? kh = null, string? soDienThoaiMacDinh = null)
        {
            InitializeComponent();
            _controller = controller;
            _khachHang = kh;
            _isEdit = kh != null;
            this.StartPosition = FormStartPosition.CenterParent;

            if (_isEdit)
            {
                this.Text = "Chỉnh sửa thông tin khách hàng";
                LoadKhachHangToForm(kh);
            }
            else
            {
                this.Text = "Thêm khách hàng mới";
                txtMaKH.Text = _controller.GenerateNextCode();

                // Tự động điền số điện thoại nếu có
                if (!string.IsNullOrWhiteSpace(soDienThoaiMacDinh))
                {
                    txtSoDienThoai.Text = soDienThoaiMacDinh;
                }
            }
        }
        private void ThemKhachHangForm2_load(object sender, EventArgs e)
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

        private void LoadKhachHangToForm(KhachHang kh)
        {
            txtMaKH.Text = kh.MaKH;
            txtHoTen.Text = kh.HoTen;
            txtSoDienThoai.Text = kh.SoDienThoai;
            txtEmail.Text = kh.Email;
            txtDiaChi.Text = kh.DiaChi;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }


            string soDienThoai = txtSoDienThoai.Text.Trim();
            if (string.IsNullOrWhiteSpace(soDienThoai))
            {

                MessageBox.Show("Vui lòng nhập Số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 số bắt đầu bằng 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
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

            int diemTichLuy = 0;

            var kh = new KhachHang
            {
                MaKH = txtMaKH.Text.Trim(),
                SoDienThoai = soDienThoai,
                HoTen = txtHoTen.Text.Trim(),
                Email = email,
                DiaChi = txtDiaChi.Text.Trim(),
                DiemTichLuy = diemTichLuy
            };

            bool success;
            if (_isEdit)
                success = _controller.Update(kh);
            else
                success = _controller.Add(kh);

            if (success)
            {
                MessageBox.Show("Lưu thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể lưu thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
