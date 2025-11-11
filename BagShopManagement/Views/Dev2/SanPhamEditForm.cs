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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class SanPhamEditForm : Form
    {
        private readonly SanPhamController _controller;
        private readonly SanPham _sanPham;
        private readonly bool _isEdit;
        private readonly IDanhMucService _danhMucService = new DanhMucService(new DanhMucRepository());
        private string _selectedImagePath; // path ảnh gốc

        public SanPhamEditForm(SanPhamController controller, SanPham sp = null)
        {
            InitializeComponent();
            _controller = controller;
            _sanPham = sp;
            _isEdit = sp != null;

            this.Load += SanPhamEditForm_Load;
        }
        private void SanPhamEditForm_Load(object sender, EventArgs e)
        {
            LoadAllDanhMuc();

            if (_isEdit)
                LoadSanPhamToForm(_sanPham);
        }

        private void LoadAllDanhMuc()
        {
            LoadDanhMuc(cboLoaiTui, "DanhMucLoaiTui", "MaLoaiTui", "TenLoaiTui");
            LoadDanhMuc(cboThuongHieu, "ThuongHieu", "MaThuongHieu", "TenThuongHieu");
            LoadDanhMuc(cboChatLieu, "ChatLieu", "MaChatLieu", "TenChatLieu");
            LoadDanhMuc(cboMau, "MauSac", "MaMau", "TenMau");
            LoadDanhMuc(cboKichThuoc, "KichThuoc", "MaKichThuoc", "TenKichThuoc");
            LoadDanhMuc(cboNCC, "NhaCungCap", "MaNCC", "TenNCC");
        }

        private void LoadDanhMuc(ComboBox cbo, string table, string valueField, string displayField)
        {
            try
            {
                var dt = _danhMucService.GetAll(table);
                cbo.DataSource = dt;
                cbo.ValueMember = valueField;
                cbo.DisplayMember = displayField;
                cbo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải {table}: {ex.Message}");
            }
        }


        private void LoadSanPhamToForm(SanPham sp)
        {
            txtMaSP.Text = sp.MaSP;
            txtTenSP.Text = sp.TenSP;
            numGiaNhap.Value = sp.GiaNhap;
            numGiaBan.Value = sp.GiaBan;
            numSoLuong.Value = sp.SoLuongTon;
            txtMoTa.Text = sp.MoTa;
            chkTrangThai.Checked = sp.TrangThai;
            if (!string.IsNullOrEmpty(sp.MaLoaiTui)) cboLoaiTui.SelectedValue = sp.MaLoaiTui;
            if (!string.IsNullOrEmpty(sp.MaThuongHieu)) cboThuongHieu.SelectedValue = sp.MaThuongHieu;
            if (!string.IsNullOrEmpty(sp.MaChatLieu)) cboChatLieu.SelectedValue = sp.MaChatLieu;
            if (!string.IsNullOrEmpty(sp.MaMau)) cboMau.SelectedValue = sp.MaMau;
            if (!string.IsNullOrEmpty(sp.MaKichThuoc)) cboKichThuoc.SelectedValue = sp.MaKichThuoc;
            if (!string.IsNullOrEmpty(sp.MaNCC)) cboNCC.SelectedValue = sp.MaNCC;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sp = new SanPham
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                GiaNhap = numGiaNhap.Value,
                GiaBan = numGiaBan.Value,
                SoLuongTon = (int)numSoLuong.Value,
                MoTa = txtMoTa.Text.Trim(),
                TrangThai = chkTrangThai.Checked,
                NgayTao = _isEdit ? _sanPham.NgayTao : DateTime.Now,
                MaLoaiTui = cboLoaiTui.SelectedValue?.ToString(),
                MaThuongHieu = cboThuongHieu.SelectedValue?.ToString(),
                MaChatLieu = cboChatLieu.SelectedValue?.ToString(),
                MaMau = cboMau.SelectedValue?.ToString(),
                MaKichThuoc = cboKichThuoc.SelectedValue?.ToString(),
                MaNCC = cboNCC.SelectedValue?.ToString()
            };

            // ====== Xử lý ảnh ======
            if (!string.IsNullOrEmpty(_selectedImagePath) && File.Exists(_selectedImagePath))
            {
                string ext = Path.GetExtension(_selectedImagePath);
                string newFileName = sp.MaSP + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;

                string destFolder = Path.Combine(Application.StartupPath, "Resources", "AnhSanPham");
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);

                string destPath = Path.Combine(destFolder, newFileName);
                File.Copy(_selectedImagePath, destPath, true);

                sp.AnhChinh = newFileName; // save DB filename
            }
            else
            {
                sp.AnhChinh = txtAnhChinh.Text.Trim();
            }
            // ========================

            bool success = _isEdit ? _controller.Update(sp) : _controller.Add(sp);

            if (success)
            {
                MessageBox.Show("Lưu sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể lưu sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    txtAnhChinh.Text = Path.GetFileName(ofd.FileName); // tạm placeholder
                    //picAnh.ImageLocation = ofd.FileName;
                }
            }
        }



    }
}
