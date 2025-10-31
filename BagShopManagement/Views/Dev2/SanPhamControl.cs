using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class SanPhamControl : UserControl
    {
        private readonly SanPhamController _controller;

        public SanPhamControl()
        {
            InitializeComponent();

            // Khởi tạo controller đầy đủ qua service & repo
            ISanPhamService sanPhamService = new SanPhamService(new SanPhamRepository());
            _controller = new SanPhamController(sanPhamService);

            LoadSanPham();
        }

        private void LoadSanPham()
        {
            try
            {
                var list = _controller.GetAll();
                dgvSanPham.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var editForm = new SanPhamEditForm(_controller);
            if (editForm.ShowDialog() == DialogResult.OK)
                LoadSanPham();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;

            var sp = dgvSanPham.CurrentRow.DataBoundItem as SanPham;
            if (sp == null) return;

            var editForm = new SanPhamEditForm(_controller, sp);
            if (editForm.ShowDialog() == DialogResult.OK)
                LoadSanPham();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;

            var sp = dgvSanPham.CurrentRow.DataBoundItem as SanPham;
            if (sp == null) return;

            if (MessageBox.Show($"Xoá sản phẩm {sp.TenSP}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _controller.Delete(sp.MaSP);
                LoadSanPham();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var kw = txtTimKiem.Text.Trim();
            dgvSanPham.DataSource = _controller.Search(kw);
        }
    }
}
