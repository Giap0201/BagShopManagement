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
    public partial class LoaiTuiControl : UserControl
    {
        private readonly LoaiTuiService _service;

        public LoaiTuiControl()
        {
            InitializeComponent();

            _service = new LoaiTuiService(new LoaiTuiRepository());

            this.Load += LoaiTuiControl_Load;
        }

        private void LoaiTuiControl_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvLoaiTui.DataSource = _service.GetAll();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                LoadData();
            else
                dgvLoaiTui.DataSource = _service.Search(txtSearch.Text.Trim());
        }
    }
}
