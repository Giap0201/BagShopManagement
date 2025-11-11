using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class SanPhamControl : UserControl
    {
        private readonly ISanPhamService _sanPhamService;

        public SanPhamControl()
        {
            InitializeComponent();

            // Tạm thời khởi tạo Service trực tiếp (sau này có thể dùng DI)
            _sanPhamService = new SanPhamService(new SanPhamImpl());

            LoadSanPham();
        }

        private void LoadSanPham()
        {
            try
            {
                var list = _sanPhamService.GetAll();
                dgvSanPham.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var editform = new SanPhamEditForm(_sanPhamService);
            if (editform.ShowDialog() == DialogResult.OK)
                LoadSanPham();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;

            var sp = (SanPham)dgvSanPham.CurrentRow.DataBoundItem as SanPham;
            if (sp == null) return;

            var editform = new SanPhamEditForm(_sanPhamService, sp);
            if (editform.ShowDialog() == DialogResult.OK)
                LoadSanPham();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null) return;
            var sp = dgvSanPham.CurrentRow.DataBoundItem as SanPham;
            if (sp == null) return;

            if (MessageBox.Show($"Xoá sản phẩm {sp.TenSP}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _sanPhamService.Delete(sp.MaSP);
                LoadSanPham();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var kw = txtTimKiem.Text.Trim();
            dgvSanPham.DataSource = _sanPhamService.Search(kw);
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}
