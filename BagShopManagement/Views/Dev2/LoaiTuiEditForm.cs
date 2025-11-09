using BagShopManagement.Controllers;
using BagShopManagement.Models;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class LoaiTuiEditForm : Form
    {
        private readonly LoaiTuiController _controller;
        private readonly DanhMucLoaiTui _model;
        private readonly bool _isEdit;

        public LoaiTuiEditForm(LoaiTuiController controller, DanhMucLoaiTui model = null)
        {
            InitializeComponent();
            _controller = controller;
            _model = model;
            _isEdit = model != null;

            if (_isEdit)
            {
                txtMa.Text = _model.MaLoaiTui;
                txtMa.Enabled = false; // không đổi PK
                txtTen.Text = _model.TenLoaiTui;
                txtMoTa.Text = _model.MoTa;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();
            string mota = txtMoTa.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Mã và tên không được rỗng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var obj = new DanhMucLoaiTui
            {
                MaLoaiTui = ma,
                TenLoaiTui = ten,
                MoTa = string.IsNullOrEmpty(mota) ? null : mota
            };

            bool ok = _isEdit ? _controller.Update(obj) : _controller.Add(obj);
            if (ok)
            {
                MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thao tác thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
