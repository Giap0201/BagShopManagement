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
using System.IO;

namespace BagShopManagement.Views.Dev2
{
    public partial class SanPhamEditForm : Form
    {
        private readonly SanPhamController _controller;
        private readonly SanPham _spEditing;

        public SanPhamEditForm(SanPham sp = null)
        {
            InitializeComponent();
            _controller = new SanPhamController(new SanPhamService(new SanPhamImpl()));
            _spEditing = sp;

            if (_spEditing != null)
                LoadData();
        }

        private void LoadData()
        {
            txtMaSP.Text = _spEditing.MaSP;
            txtTenSP.Text = _spEditing.TenSP;
            numGiaNhap.Value = _spEditing.GiaNhap;
            numGiaBan.Value = _spEditing.GiaBan;
            numSoLuong.Value = _spEditing.SoLuongTon;
            txtMoTa.Text = _spEditing.MoTa;

            if (!string.IsNullOrEmpty(_spEditing.AnhChinh) && File.Exists(_spEditing.AnhChinh))
                pbAnh.ImageLocation = _spEditing.AnhChinh;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Filter = "Ảnh (*.jpg;*.png)|*.jpg;*.png" };
            if (ofd.ShowDialog() == DialogResult.OK)
                pbAnh.ImageLocation = ofd.FileName;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                return;
            }

            var sp = new SanPham
            {
                MaSP = string.IsNullOrEmpty(txtMaSP.Text) ? Guid.NewGuid().ToString().Substring(0, 8) : txtMaSP.Text,
                TenSP = txtTenSP.Text,
                GiaNhap = numGiaNhap.Value,
                GiaBan = numGiaBan.Value,
                SoLuongTon = (int)numSoLuong.Value,
                MoTa = txtMoTa.Text,
                AnhChinh = pbAnh.ImageLocation,
                TrangThai = true,
                NgayTao = DateTime.Now
            };

            bool success;
            if (_spEditing == null)
                success = _controller.Add(sp);
            else
                success = _controller.Update(sp);

            if (success)
            {
                MessageBox.Show("Lưu thành công!");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Lưu thất bại!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
