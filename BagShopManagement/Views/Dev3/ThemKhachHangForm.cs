using BagShopManagement.Controllers;
using BagShopManagement.Models;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev3
{
    public partial class ThemKhachHangForm : Form
    {
        private readonly KhachHangController _controller;
        private readonly KhachHang _khachHang;
        private readonly bool _isEdit;

        public ThemKhachHangForm(KhachHangController controller, KhachHang kh = null)
        {
            InitializeComponent();
            _controller = controller;
            _khachHang = kh;
            _isEdit = kh != null;

            if (_isEdit)
            {
                this.Text = "Chỉnh sửa thông tin khách hàng";
                LoadKhachHangToForm(kh);
            }
            else
            {
                this.Text = "Thêm khách hàng mới";
            }
        }

        private void LoadKhachHangToForm(KhachHang kh)
        {
            txtMaKH.Text = kh.MaKH;
            txtHoTen.Text = kh.HoTen;
            txtSoDienThoai.Text = kh.SoDienThoai;
            txtEmail.Text = kh.Email;
            txtDiaChi.Text = kh.DiaChi;
            txtDiemTichLuy.Text = kh.DiemTichLuy.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            var kh = new KhachHang
            {
                MaKH = txtMaKH.Text.Trim(),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                DiemTichLuy = int.Parse(txtDiemTichLuy.Text.Trim())
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
