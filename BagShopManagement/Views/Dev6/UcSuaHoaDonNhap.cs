using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models.Enums;
using BagShopManagement.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev6
{
    public partial class UcSuaHoaDonNhap : UserControl
    {
        private readonly HoaDonNhapController _controller;
        private readonly INhaCungCapRepository _nccRepo;
        private readonly INhanVienRepository _nvRepo;
        private readonly ISanPhamRepository _spRepo;
        private readonly IServiceProvider _provider;

        private BindingList<ChiTietHDNResponse> _listChiTiet;

        public UcSuaHoaDonNhap(
            HoaDonNhapController controller,
            INhaCungCapRepository nccRepo,
            INhanVienRepository nvRepo,
            ISanPhamRepository spRepo,
            IServiceProvider provider)
        {
            InitializeComponent();
            _controller = controller;
            _nccRepo = nccRepo;
            _nvRepo = nvRepo;
            _spRepo = spRepo;
            _provider = provider;

            dgvChiTiet.DataError += (s, e) => e.ThrowException = false;
        }

        private void UcSuaHoaDonNhap_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadComboBoxes();
            ConfigGrid();
        }

        public void LoadData(HoaDonNhapResponse data)
        {
            txtMaHDN.Text = data.MaHDN;
            txtMaHDN.ReadOnly = true;

            dtpNgayNhap.Value = data.NgayNhap ?? DateTime.Now;
            txtGhiChu.Text = data.GhiChu ?? "";

            cboNhaCungCap.SelectedValue = data.MaNCC;
            cboNhanVien.SelectedValue = data.MaNV;
            cboTrangThai.SelectedValue = (byte)data.TrangThai;

            _listChiTiet = new BindingList<ChiTietHDNResponse>(data.ChiTiet.ToList());
            dgvChiTiet.DataSource = _listChiTiet;
            UpdateTongTien();

            ApplyStatusUI(data.TrangThai);
        }

        private void ConfigGrid()
        {
            dgvChiTiet.AutoGenerateColumns = true;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
        }

        // load du lieu cho cac combobox
        private void LoadComboBoxes()
        {
            LoadTrangThaiComboBox();
            LoadComboBoxNhaCungCap();
            LoadComboBoxNhanVien();
            LoadComboBoxSanPham();
        }

        // load cac trang thai hoa don nhap vao combobox
        private void LoadTrangThaiComboBox()
        {
            var dataSource = new List<object>
            {
                new { Value = (byte?)TrangThaiHoaDonNhap.TamLuu, Display = "Tạm lưu" },
                new { Value = (byte?)TrangThaiHoaDonNhap.HoatDong, Display = "Hoạt động" },
                new { Value = (byte?)TrangThaiHoaDonNhap.DaHuy, Display = "Đã hủy" }
            };

            cboTrangThai.DataSource = dataSource;
            cboTrangThai.DisplayMember = "Display";
            cboTrangThai.ValueMember = "Value";
            cboTrangThai.SelectedIndex = 0;
        }

        // Tim kiem trong combobox
        private void EnableSearchableComboBox(ComboBox comboBox, List<string> items)
        {
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(items.ToArray());
            comboBox.AutoCompleteCustomSource = autoSource;
        }

        // load nha cung cap vao combobox
        private void LoadComboBoxNhaCungCap()
        {
            try
            {
                var list = _nccRepo.GetAll();
                cboNhaCungCap.DataSource = list;
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "MaNCC";
                EnableSearchableComboBox(cboNhaCungCap, list.Select(x => x.TenNCC).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách NCC: {ex.Message}");
            }
        }

        // load nhan vien vao combobox
        private void LoadComboBoxNhanVien()
        {
            try
            {
                var list = _nvRepo.GetAll();
                cboNhanVien.DataSource = list;
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "MaNV";
                EnableSearchableComboBox(cboNhanVien, list.Select(x => x.HoTen).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách NV: {ex.Message}");
            }
        }

        // load san pham vao combobox
        private void LoadComboBoxSanPham()
        {
            try
            {
                var list = _spRepo.GetAll();
                cboSanPham.DataSource = list;
                cboSanPham.DisplayMember = "TenSP";
                cboSanPham.ValueMember = "MaSP";
                EnableSearchableComboBox(cboSanPham, list.Select(x => x.TenSP).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sản phẩm: {ex.Message}");
            }
        }

        private void UpdateTongTien()
        {
            decimal tong = _listChiTiet.Sum(x => x.ThanhTien);
            lblTongTien.Text = tong.ToString("N0");
        }

        private void ApplyStatusUI(TrangThaiHoaDonNhap status)
        {
            if (status == TrangThaiHoaDonNhap.HoatDong)
            {
                // Không cho sửa header + chi tiết
                DisableEditing();
            }
            else if (status == TrangThaiHoaDonNhap.DaHuy)
            {
                DisableAll();
            }
            else
            {
                // Trạng thái Tạm Lưu
                EnableEditing();
            }
        }

        private void DisableEditing()
        {
            btnTamLuuHDN.Enabled = false;
            btnDuyetHDN.Enabled = false;

            btnThemChiTietHDN.Enabled = false;
            btnSuaChiTietHDN.Enabled = false;
            btnXoaChiTietHDN.Enabled = false;
            btnLuuChiTietHDN.Enabled = false;
        }

        private void DisableAll()
        {
            DisableEditing();
            btnInHDN.Enabled = false;
        }

        private void EnableEditing()
        {
            btnTamLuuHDN.Enabled = true;
            btnDuyetHDN.Enabled = true;
            btnThemChiTietHDN.Enabled = true;
            btnSuaChiTietHDN.Enabled = true;
            btnXoaChiTietHDN.Enabled = true;
            btnLuuChiTietHDN.Enabled = true;
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = _listChiTiet[e.RowIndex];

            cboSanPham.SelectedValue = row.MaSP;
            txtSoLuong.Text = row.SoLuong.ToString();
            txtDonGia.Text = row.DonGia.ToString();
            txtThanhTien.Text = row.ThanhTien.ToString("N0");
        }

        private void btnThemChiTietHDN_Click(object sender, EventArgs e)
        {
            cboSanPham.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
        }

        private void btnLuuChiTietHDN_Click(object sender, EventArgs e)
        {
            if (!ValidateChiTiet()) return;

            string maSP = cboSanPham.SelectedValue.ToString();
            string tenSP = cboSanPham.Text;
            int soLuong = int.Parse(txtSoLuong.Text);
            decimal donGia = decimal.Parse(txtDonGia.Text);
            decimal thanhTien = soLuong * donGia;

            if (_listChiTiet.Any(x => x.MaSP == maSP))
            {
                MessageBox.Show("Sản phẩm đã tồn tại trong danh sách.", "Lỗi");
                return;
            }

            _listChiTiet.Add(new ChiTietHDNResponse
            {
                MaSP = maSP,
                TenSP = tenSP,
                SoLuong = soLuong,
                DonGia = donGia,
                ThanhTien = thanhTien
            });

            UpdateTongTien();
        }

        private void btnSuaChiTietHDN_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0) return;
            if (!ValidateChiTiet()) return;

            string maSP = dgvChiTiet.SelectedRows[0].Cells["MaSP"].Value.ToString();
            var item = _listChiTiet.First(x => x.MaSP == maSP);

            item.SoLuong = int.Parse(txtSoLuong.Text);
            item.DonGia = decimal.Parse(txtDonGia.Text);
            item.ThanhTien = item.SoLuong * item.DonGia;

            dgvChiTiet.Refresh();
            UpdateTongTien();
        }

        private void btnXoaChiTietHDN_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0) return;

            string maSP = dgvChiTiet.SelectedRows[0].Cells["MaSP"].Value.ToString();
            var item = _listChiTiet.First(x => x.MaSP == maSP);

            _listChiTiet.Remove(item);
            UpdateTongTien();
        }

        private bool ValidateChiTiet()
        {
            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Chọn sản phẩm.");
                return false;
            }
            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                return false;
            }
            if (!decimal.TryParse(txtDonGia.Text, out decimal dg) || dg <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return false;
            }
            return true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var listUC = _provider.GetRequiredService<ucHoaDonNhapList>();
            var parent = this.Parent;

            parent.Controls.Clear();
            listUC.Dock = DockStyle.Fill;
            parent.Controls.Add(listUC);
        }
    }
}