using BagShopManagement.Controllers;
using BagShopManagement.Models;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class MauSacEditForm : Form
    {
        private readonly MauSacController _controller;
        private readonly MauSac _model;
        private readonly bool _isEdit;

        public MauSacEditForm(MauSacController controller, MauSac model = null)
        {
            InitializeComponent();
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _model = model;
            _isEdit = model != null;

            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click -= btnCancel_Click;
            btnCancel.Click += btnCancel_Click;

            if (_isEdit)
            {
                txtMa.Text = _model.MaMau;
                txtMa.ReadOnly = true;
                txtTen.Text = _model.TenMau;
                this.Text = "Chỉnh sửa Màu sắc";
            }
            else
            {
                try { txtMa.Text = _controller.GenerateNextCode(); }
                catch { txtMa.Text = "MS001"; }
                txtMa.ReadOnly = true;
                this.Text = "Thêm Màu sắc";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var ma = txtMa.Text?.Trim();
            var ten = txtTen.Text?.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Mã và Tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var obj = new MauSac
            {
                MaMau = ma,
                TenMau = ten
            };

            bool ok;
            try
            {
                ok = _isEdit ? _controller.Update(obj) : _controller.Add(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
