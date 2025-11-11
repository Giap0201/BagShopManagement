using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Models.Enums;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Views.Dev6; // Thêm
using Microsoft.Extensions.DependencyInjection; // Thêm
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev6
{
    public partial class ucHoaDonNhapList : UserControl
    {
        private readonly HoaDonNhapController _controller;
        private readonly INhaCungCapRepository _nhaCungCapRepo;
        private readonly INhanVienRepository _nhanVienRepo;
        private readonly IServiceProvider _serviceProvider;

        public ucHoaDonNhapList(
            HoaDonNhapController controller,
            INhaCungCapRepository nhaCungCapRepo,
            INhanVienRepository nhanVienRepo,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _controller = controller;
            _nhaCungCapRepo = nhaCungCapRepo;
            _nhanVienRepo = nhanVienRepo;
            _serviceProvider = serviceProvider;
        }

        private void ucHoaDonNhapList_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                try
                {
                    LoadComboBoxes();
                    LoadAllInvoices();
                    UpdateUIState(null);
                }
                catch (Exception ex)
                {
                    Utils.ExceptionHandler.Show(ex, "Không thể tải danh sách hóa đơn.");
                }
            }
        }

        #region === CÁC HÀM TẢI DỮ LIỆU (LOAD) ===

        private void LoadAllInvoices()
        {
            if (_controller == null) return;
            try
            {
                List<HoaDonNhapResponse> danhSach = _controller.LayDanhSachHoaDon();
                dgvDanhSach.DataSource = null;
                dgvDanhSach.DataSource = danhSach;
                FormatInvoiceGrid();
            }
            catch (Exception ex)
            {
                Utils.ExceptionHandler.Show(ex, "Lỗi tải dữ liệu");
            }
        }

        private void FormatInvoiceGrid()
        {
            if (dgvDanhSach.DataSource == null) return;
            dgvDanhSach.Columns["TenTrangThai"].HeaderText = "Trạng Thái";
            dgvDanhSach.Columns["MaHDN"].HeaderText = "Mã HĐN";
            dgvDanhSach.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";
            dgvDanhSach.Columns["TenNV"].HeaderText = "Nhân Viên Lập";
            dgvDanhSach.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            dgvDanhSach.Columns["NgayDuyet"].HeaderText = "Ngày Duyệt";
            dgvDanhSach.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dgvDanhSach.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvDanhSach.Columns["MaNCC"].Visible = false;
            dgvDanhSach.Columns["MaNV"].Visible = false;
            dgvDanhSach.Columns["TrangThai"].Visible = false;
            dgvDanhSach.Columns["GhiChu"].Visible = false;
            if (dgvDanhSach.Columns.Contains("ChiTiet"))
            {
                dgvDanhSach.Columns["ChiTiet"].Visible = false;
            }
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (row.DataBoundItem == null) continue;
                var trangThai = (TrangThaiHoaDonNhap)row.Cells["TrangThai"].Value;
                row.DefaultCellStyle.BackColor = SystemColors.Window;
                row.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Regular);
                row.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                if (trangThai == TrangThaiHoaDonNhap.DaHuy)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.Font = new Font(this.Font, FontStyle.Strikeout);
                    row.DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                else if (trangThai == TrangThaiHoaDonNhap.TamLuu)
                {
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                }
            }
        }

        private void LoadComboBoxes()
        {
            LoadTrangThaiComboBox();
            LoadComboBoxNhaCungCap();
            LoadComboBoxNhanVien();
        }

        private void LoadTrangThaiComboBox()
        {
            var dataSource = new List<object>
            {
                new { Value = (byte?)null, Display = "--- Tất cả trạng thái ---" },
                new { Value = (byte?)TrangThaiHoaDonNhap.TamLuu, Display = "Tạm lưu" },
                new { Value = (byte?)TrangThaiHoaDonNhap.HoatDong, Display = "Hoạt động" },
                new { Value = (byte?)TrangThaiHoaDonNhap.DaHuy, Display = "Đã hủy" }
            };
            cmbSearchTrangThai.DataSource = dataSource;
            cmbSearchTrangThai.DisplayMember = "Display";
            cmbSearchTrangThai.ValueMember = "Value";
            cmbSearchTrangThai.SelectedIndex = 0;
        }

        private void LoadComboBoxNhaCungCap()
        {
            if (_nhaCungCapRepo == null) return;
            try
            {
                var list = _nhaCungCapRepo.GetAll();
                list.Insert(0, new NhaCungCap { MaNCC = "", TenNCC = "--- Tất cả NCC ---" });
                cmbSearchNCC.DataSource = list;
                cmbSearchNCC.DisplayMember = "TenNCC";
                cmbSearchNCC.ValueMember = "MaNCC";
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải danh sách NCC: {ex.Message}"); }
        }

        private void LoadComboBoxNhanVien()
        {
            if (_nhanVienRepo == null) return;
            try
            {
                var list = _nhanVienRepo.GetAll();
                list.Insert(0, new NhanVien { MaNV = "", HoTen = "--- Tất cả NV ---" });
                cmbSearchNhanVien.DataSource = list;
                cmbSearchNhanVien.DisplayMember = "HoTen";
                cmbSearchNhanVien.ValueMember = "MaNV";
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải danh sách NV: {ex.Message}"); }
        }

        #endregion === CÁC HÀM TẢI DỮ LIỆU (LOAD) ===

        #region === CÁC HÀM XỬ LÝ SỰ KIỆN ===

        private void UpdateUIState(TrangThaiHoaDonNhap? trangThai)
        {
            if (btnThem == null) return;
            if (trangThai == null)
            {
                btnThem.Enabled = true;
                btnXemSua.Enabled = false;
                btnDuyet.Enabled = false;
                btnHuy.Enabled = false;
            }
            else if (trangThai == TrangThaiHoaDonNhap.TamLuu)
            {
                btnThem.Enabled = true;
                btnXemSua.Enabled = true;
                btnDuyet.Enabled = true;
                btnHuy.Enabled = true;
            }
            else if (trangThai == TrangThaiHoaDonNhap.HoatDong)
            {
                btnThem.Enabled = true;
                btnXemSua.Enabled = true;
                btnDuyet.Enabled = false;
                btnHuy.Enabled = true;
            }
            else if (trangThai == TrangThaiHoaDonNhap.DaHuy)
            {
                btnThem.Enabled = true;
                btnXemSua.Enabled = true;
                btnDuyet.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSach == null || dgvDanhSach.CurrentRow == null || dgvDanhSach.CurrentRow.DataBoundItem == null)
            {
                UpdateUIState(null);
                return;
            }
            var trangThai = (TrangThaiHoaDonNhap)dgvDanhSach.CurrentRow.Cells["TrangThai"].Value;
            UpdateUIState(trangThai);
        }

        // === LOGIC NÚT THÊM MỚI (Quan trọng) ===
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = _serviceProvider.GetRequiredService<frmHoaDonNhapDetail>())
                {
                    frm.ShowDialog();
                    LoadAllInvoices();
                }
            }
            catch (Exception ex)
            {
                Utils.ExceptionHandler.Show(ex, "Không thể mở form chi tiết.");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cmbSearchMaHDN.Text = "";
            cmbSearchNCC.SelectedIndex = 0;
            cmbSearchNhanVien.SelectedIndex = 0;
            cmbSearchTrangThai.SelectedIndex = 0;
            LoadAllInvoices();
        }

        #endregion === CÁC HÀM XỬ LÝ SỰ KIỆN ===
    }
}