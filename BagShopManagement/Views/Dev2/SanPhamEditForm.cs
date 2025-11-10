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
        private readonly ISanPhamService _sanPhamService;
        private readonly SanPham _sanPham; // null nếu đang thêm mới
        private readonly bool _isEdit;

        private readonly IDanhMucService _danhMucService = new DanhMucService(new DanhMucRepository());

        public SanPhamEditForm(ISanPhamService sanPhamService, SanPham sp = null)
        {
            InitializeComponent();
            _sanPhamService = sanPhamService;
            _sanPham = sp;
            _isEdit = sp != null;

            if (_isEdit)
            {
                this.Text = "Chỉnh sửa sản phẩm";
                LoadSanPhamToForm(sp);
            }
            else
            {
                this.Text = "Thêm sản phẩm mới";
            }
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
                NgayTao = _isEdit ? _sanPham.NgayTao : DateTime.Now
            };

            sp.MaLoaiTui = cboLoaiTui.SelectedValue?.ToString();
            sp.MaThuongHieu = cboThuongHieu.SelectedValue?.ToString();
            sp.MaChatLieu = cboChatLieu.SelectedValue?.ToString();
            sp.MaMau = cboMau.SelectedValue?.ToString();
            sp.MaKichThuoc = cboKichThuoc.SelectedValue?.ToString();
            sp.MaNCC = cboNCC.SelectedValue?.ToString();

            bool success;
            if (_isEdit)
                success = _sanPhamService.Update(sp);
            else
                success = _sanPhamService.Add(sp);

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

        
    }
}
