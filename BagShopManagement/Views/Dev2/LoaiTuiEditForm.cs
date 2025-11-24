using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class LoaiTuiEditForm : Form
    {
        private readonly ILoaiTuiService _service;
        private readonly DanhMucLoaiTui _model;
        private readonly bool _isEdit;

        public LoaiTuiEditForm(ILoaiTuiService service, DanhMucLoaiTui model = null)
        {
            InitializeComponent();

            _service = service ?? throw new ArgumentNullException(nameof(service));
            _model = model;
            _isEdit = model != null;

            // attach handlers defensively (designer may also wire)
            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click -= btnCancel_Click;
            btnCancel.Click += btnCancel_Click;

            if (_isEdit)
            {
                LoadForEdit(_model);
            }
            else
            {
                // Add mode: auto-generate mã và disable editing mã
                try
                {
                    txtMa.Text = _service.GenerateNextCode();
                }
                catch
                {
                    // fallback safe
                    txtMa.Text = "LT001";
                }
                txtMa.ReadOnly = true;
                this.Text = "Thêm Loại Túi";
            }
        }

        private void LoadForEdit(DanhMucLoaiTui model)
        {
            if (model == null) return;
            txtMa.Text = model.MaLoaiTui;
            txtMa.ReadOnly = true;
            txtTen.Text = model.TenLoaiTui;
            txtMoTa.Text = model.MoTa;
            this.Text = "Chỉnh sửa Loại Túi";
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

            var obj = new DanhMucLoaiTui
            {
                MaLoaiTui = ma,
                TenLoaiTui = ten,
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
