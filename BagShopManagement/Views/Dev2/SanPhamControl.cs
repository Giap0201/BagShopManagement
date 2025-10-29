using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
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
        private readonly SanPhamController _controller;
        private BindingSource _bs = new BindingSource();

        public SanPhamControl()
        {
            InitializeComponent();
            _controller = new SanPhamController(new SanPhamService(new SanPhamImpl()));

            LoadData();
            SetupEvents();
        }

        private void SetupEvents()
        {
            btnSearch.Click += (s, e) => Search();
            btnAdd.Click += (s, e) => AddSanPham();
            btnEdit.Click += (s, e) => EditSanPham();
            btnDelete.Click += (s, e) => DeleteSanPham();
        }

        private void LoadData()
        {
            _bs.DataSource = _controller.GetAll();
            dgvSanPham.DataSource = _bs;
            dgvSanPham.AutoGenerateColumns = true; // hiển thị cột tự động
        }

        private void Search()
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
                _bs.DataSource = _controller.GetAll();
            else
                _bs.DataSource = _controller.Search(keyword);
        }

        private void AddSanPham()
        {
            using (var frm = new SanPhamEditForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void EditSanPham()
        {
            if (_bs.Current is SanPham sp)
            {
                using (var frm = new SanPhamEditForm(sp))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                        LoadData();
                }
            }
        }

        private void DeleteSanPham()
        {
            if (_bs.Current is SanPham sp)
            {
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa '{sp.TenSP}'?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    _controller.Delete(sp.MaSP);
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Tạm thời không dùng (sự kiện xử lý trong SetupEvents)
        }
    }
}
