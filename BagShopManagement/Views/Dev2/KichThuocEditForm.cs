using BagShopManagement.Controllers;
using BagShopManagement.Models;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class KichThuocEditForm : Form
    {
        private readonly KichThuocController _controller;
        private readonly KichThuoc _model;
        private readonly bool _isEdit;

        public KichThuocEditForm(KichThuocController controller, KichThuoc model = null)
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
                txtMa.Text = _model.MaKichThuoc;
                txtMa.ReadOnly = true;
                txtTen.Text = _model.TenKichThuoc;

                numDai.Value = (decimal)(_model.ChieuDai ?? 0);
                numRong.Value = (decimal)(_model.ChieuRong ?? 0);
                numCao.Value = (decimal)(_model.ChieuCao ?? 0);

                this.Text = "Chỉnh sửa Kích thước";
            }
            else
            {
                try { txtMa.Text = _controller.GenerateNextCode(); }
                catch { txtMa.Text = "KT001"; }

                txtMa.ReadOnly = true;
                this.Text = "Thêm Kích thước";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text?.Trim();
            string ten = txtTen.Text?.Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Mã và Tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var obj = new KichThuoc
            {
                MaKichThuoc = ma,
                TenKichThuoc = ten,
                ChieuDai = numDai.Value == 0 ? null : numDai.Value,
                ChieuRong = numRong.Value == 0 ? null : numRong.Value,
                ChieuCao = numCao.Value == 0 ? null : numCao.Value
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
