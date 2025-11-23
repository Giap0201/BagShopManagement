using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class ChatLieuEditForm : Form
    {
        private readonly IChatLieuService _service;
        private readonly ChatLieu _model;
        private readonly bool _isEdit;

        public ChatLieuEditForm(IChatLieuService service, ChatLieu model = null)
        {
            InitializeComponent();
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _model = model;
            _isEdit = model != null;

            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click -= btnCancel_Click;
            btnCancel.Click += btnCancel_Click;

            if (_isEdit)
            {
                txtMa.Text = _model.MaChatLieu;
                txtMa.ReadOnly = true;
                txtTen.Text = _model.TenChatLieu;
                txtMoTa.Text = _model.MoTa;
                this.Text = "Chỉnh sửa Chất Liệu";
            }
            else
            {
                try
                {
                    txtMa.Text = _service.GenerateNextCode();
                }
                catch
                {
                    txtMa.Text = "CL001";
                }
                txtMa.ReadOnly = true;
                this.Text = "Thêm Chất Liệu";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var ma = txtMa.Text?.Trim();
            var ten = txtTen.Text?.Trim();
            var mota = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Mã và Tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var obj = new ChatLieu
            {
                MaChatLieu = ma,
                TenChatLieu = ten,
                MoTa = mota
            };

            bool ok;
            try
            {
                ok = _isEdit ? _service.Update(obj) : _service.Add(obj);
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
