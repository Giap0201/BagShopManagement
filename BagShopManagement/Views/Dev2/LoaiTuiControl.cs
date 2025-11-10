using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class LoaiTuiControl : UserControl
    {
        private readonly LoaiTuiController _controller;
        private readonly ILoaiTuiService _service;

        public LoaiTuiControl()
        {
            InitializeComponent();

            _service = new LoaiTuiService(new LoaiTuiRepository());
            _controller = new LoaiTuiController(_service);

            // wire events (safe even if designer wired them)
            this.Load += LoaiTuiControl_Load;
            txtSearch.TextChanged -= txtSearch_TextChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click -= btnEdit_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click -= btnRefresh_Click;
            btnRefresh.Click += btnRefresh_Click;
            dgvLoaiTui.CellDoubleClick -= dgvLoaiTui_CellDoubleClick;
            dgvLoaiTui.CellDoubleClick += dgvLoaiTui_CellDoubleClick;
        }

        private void LoaiTuiControl_Load(object sender, EventArgs e)
        {
            // ensure columns if not created in designer
            if (dgvLoaiTui.Columns.Count == 0)
            {
                dgvLoaiTui.AutoGenerateColumns = false;
                dgvLoaiTui.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mã",
                    DataPropertyName = "MaLoaiTui",
                    Name = "MaLoaiTui",
                    ReadOnly = true,
                    Width = 120
                });
                dgvLoaiTui.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Tên",
                    DataPropertyName = "TenLoaiTui",
                    Name = "TenLoaiTui",
                    Width = 250
                });
                dgvLoaiTui.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Mô tả",
                    DataPropertyName = "MoTa",
                    Name = "MoTa",
                    Width = 300
                });
            }

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvLoaiTui.DataSource = _controller.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var kw = txtSearch.Text?.Trim();
            if (string.IsNullOrEmpty(kw))
                LoadData();
            else
            {
                try
                {
                    dgvLoaiTui.DataSource = _controller.Search(kw);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // open edit form in Add mode — use controller to get next code
            //var model = new DanhMucLoaiTui
            //{
            //    MaLoaiTui = _controller.GenerateNextCode()
            //};

            using (var f = new LoaiTuiEditForm(_controller))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLoaiTui.CurrentRow == null) return;
            var model = dgvLoaiTui.CurrentRow.DataBoundItem as DanhMucLoaiTui;
            if (model == null) return;

            using (var f = new LoaiTuiEditForm(_controller, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLoaiTui.CurrentRow == null) return;
            var model = dgvLoaiTui.CurrentRow.DataBoundItem as DanhMucLoaiTui;
            if (model == null) return;

            if (MessageBox.Show($"Xóa loại túi '{model.TenLoaiTui}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var ok = _controller.Delete(model.MaLoaiTui);
                    if (ok) LoadData();
                    else MessageBox.Show("Xóa thất bại. Bản ghi có thể đang được tham chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvLoaiTui_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var model = dgvLoaiTui.Rows[e.RowIndex].DataBoundItem as DanhMucLoaiTui;
            if (model == null) return;

            using (var f = new LoaiTuiEditForm(_controller, model))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }
    }
}
