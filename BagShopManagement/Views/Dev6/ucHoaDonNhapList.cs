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

            // Gán các dependency
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _nhaCungCapRepo = nhaCungCapRepo ?? throw new ArgumentNullException(nameof(nhaCungCapRepo));
            _nhanVienRepo = nhanVienRepo ?? throw new ArgumentNullException(nameof(nhanVienRepo));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
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
                    Utils.ExceptionHandler.Handle(ex, "Không th? t?i danh sách hóa don.");
                }
            }
        }

        #region === CÁC HÀM T?I D? LI?U (LOAD) ===

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
                Utils.ExceptionHandler.Handle(ex, "L?i t?i d? li?u");
            }
        }

        private void FormatInvoiceGrid()
        {
            if (dgvDanhSach.DataSource == null) return;
            dgvDanhSach.Columns["TenTrangThai"].HeaderText = "Tr?ng Thái";
            dgvDanhSach.Columns["MaHDN"].HeaderText = "Mã HÐN";
            dgvDanhSach.Columns["TenNCC"].HeaderText = "Nhà Cung C?p";
            dgvDanhSach.Columns["TenNV"].HeaderText = "Nhân Viên L?p";
            dgvDanhSach.Columns["NgayNhap"].HeaderText = "Ngày Nh?p";
            dgvDanhSach.Columns["NgayDuyet"].HeaderText = "Ngày Duy?t";
            dgvDanhSach.Columns["TongTien"].HeaderText = "T?ng Ti?n";
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
                new { Value = (byte?)null, Display = "--- T?t c? tr?ng thái ---" },
                new { Value = (byte?)TrangThaiHoaDonNhap.TamLuu, Display = "T?m luu" },
                new { Value = (byte?)TrangThaiHoaDonNhap.HoatDong, Display = "Ho?t d?ng" },
                new { Value = (byte?)TrangThaiHoaDonNhap.DaHuy, Display = "Ðã h?y" }
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
                list.Insert(0, new NhaCungCap { MaNCC = "", TenNCC = "--- T?t c? NCC ---" });
                cmbSearchNCC.DataSource = list;
                cmbSearchNCC.DisplayMember = "TenNCC";
                cmbSearchNCC.ValueMember = "MaNCC";
            }
            catch (Exception ex) { MessageBox.Show($"L?i t?i danh sách NCC: {ex.Message}"); }
        }

        private void LoadComboBoxNhanVien()
        {
            if (_nhanVienRepo == null) return;
            try
            {
                var list = _nhanVienRepo.GetAll();
                list.Insert(0, new NhanVien { MaNV = "", HoTen = "--- T?t c? NV ---" });
                cmbSearchNhanVien.DataSource = list;
                cmbSearchNhanVien.DisplayMember = "HoTen";
                cmbSearchNhanVien.ValueMember = "MaNV";
            }
            catch (Exception ex) { MessageBox.Show($"L?i t?i danh sách NV: {ex.Message}"); }
        }

        #endregion === CÁC HÀM T?I D? LI?U (LOAD) ===

        #region === CÁC HÀM X? LÝ S? KI?N ===

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

        // === LOGIC NÚT THÊM M?I (Quan tr?ng) ===
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Yêu c?u DI Container t?o frmHoaDonNhapDetail
                // 'using' d?m b?o form du?c gi?i phóng (Dispose) sau khi dóng
                using (var frm = _serviceProvider.GetRequiredService<frmHoaDonNhapDetail>())
                {
                    frm.ShowDialog();
                    // Sau khi form chi ti?t dóng, t?i l?i danh sách
                    LoadAllInvoices();
                }
            }
            catch (Exception ex)
            {
                Utils.ExceptionHandler.Handle(ex, "Không th? m? form chi ti?t.");
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

        #endregion === CÁC HÀM X? LÝ S? KI?N ===
    }
}
