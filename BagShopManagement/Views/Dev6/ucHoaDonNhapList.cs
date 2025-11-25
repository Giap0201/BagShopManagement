using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Models.Enums;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev6
{
    public partial class ucHoaDonNhapList : UserControl
    {
        private readonly INhaCungCapRepository _nccRepo;
        private readonly INhanVienRepository _nvRepo;
        private readonly IServiceProvider _provider;
        private readonly IHoaDonNhapService _service;

        public ucHoaDonNhapList(
           IHoaDonNhapService service,
            INhaCungCapRepository nccRepo,
            INhanVienRepository nvRepo,
            IServiceProvider provider)
        {
            InitializeComponent();
            _service = service;
            _nccRepo = nccRepo;
            _nvRepo = nvRepo;
            _provider = provider;
        }

        private void ucHoaDonNhapList_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                LoadComboBoxes();
                LoadData();
                UpdateButtonState(null);
                SettingUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadData()
        {
            try
            {
                var danhSach = _service.GetAllHoaDonNhap();
                foreach (var hd in danhSach)
                {
                    if (!hd.NgayDuyet.HasValue) hd.NgayDuyet = null;
                    if (!hd.NgayHuy.HasValue) hd.NgayHuy = null;
                }

                dgvDanhSach.DataSource = danhSach;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvDanhSach.DataSource = null;
            }
        }

        private void LoadComboBoxes()
        {
            LoadTrangThaiComboBox();
            LoadComboBoxNhaCungCap();
            LoadComboBoxNhanVien();
            LoadComboBoxHoaDonNhap();
        }

        private void LoadTrangThaiComboBox()
        {
            var dataSource = new List<object>
            {
                new { Value = (byte?)null, Display = "-- Tất cả trạng thái --" },
                new { Value = (byte?)TrangThaiHoaDonNhap.TamLuu, Display = "Tạm lưu" },
                new { Value = (byte?)TrangThaiHoaDonNhap.HoatDong, Display = "Hoạt động" },
                new { Value = (byte?)TrangThaiHoaDonNhap.DaHuy, Display = "Đã hủy" }
            };
            cmbSearchTrangThai.DataSource = dataSource;
            cmbSearchTrangThai.DisplayMember = "Display";
            cmbSearchTrangThai.ValueMember = "Value";
            cmbSearchTrangThai.SelectedIndex = 0;
        }

        private void EnableSearchableComboBox(ComboBox comboBox, List<string> items)
        {
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(items.ToArray());
            comboBox.AutoCompleteCustomSource = autoSource;
        }

        private void LoadComboBoxNhaCungCap()
        {
            try
            {
                var list = _nccRepo.GetAll();
                list.Insert(0, new NhaCungCap { MaNCC = "", TenNCC = "--Tất cả NCC--" });
                cmbSearchNCC.DataSource = list;
                cmbSearchNCC.DisplayMember = "TenNCC";
                cmbSearchNCC.ValueMember = "MaNCC";
                EnableSearchableComboBox(cmbSearchNCC, list.Select(x => x.TenNCC).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách NCC: {ex.Message}");
            }
        }

        private void LoadComboBoxNhanVien()
        {
            try
            {
                var list = _nvRepo.GetAll();
                list.Insert(0, new NhanVien { MaNV = "", HoTen = "--Tất cả NV--" });
                cmbSearchNhanVien.DataSource = list;
                cmbSearchNhanVien.DisplayMember = "HoTen";
                cmbSearchNhanVien.ValueMember = "MaNV";
                EnableSearchableComboBox(cmbSearchNhanVien, list.Select(x => x.HoTen).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách NV: {ex.Message}");
            }
        }

        private void LoadComboBoxHoaDonNhap()
        {
            try
            {
                var list = _service.GetAll();
                list.Insert(0, new HoaDonNhap { MaHDN = "--Tất cả--" });
                cmbSearchMaHDN.DataSource = list;
                cmbSearchMaHDN.DisplayMember = "MaHDN";
                cmbSearchMaHDN.ValueMember = "MaHDN";
                EnableSearchableComboBox(cmbSearchMaHDN, list.Select(x => x.MaHDN).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hoá đơn nhập: {ex.Message}");
            }
        }

        private void FormatGrid()
        {
            if (dgvDanhSach.DataSource == null) return;

            dgvDanhSach.Columns["MaHDN"].HeaderText = "MÃ HĐN";
            dgvDanhSach.Columns["TenNCC"].HeaderText = "NHÀ CUNG CẤP";
            dgvDanhSach.Columns["TenNV"].HeaderText = "NHÂN VIÊN";
            dgvDanhSach.Columns["NgayNhap"].HeaderText = "NGÀY NHẬP";
            dgvDanhSach.Columns["NgayDuyet"].HeaderText = "NGÀY DUYỆT";
            dgvDanhSach.Columns["NgayHuy"].HeaderText = "NGÀY HUỶ";
            dgvDanhSach.Columns["TongTien"].HeaderText = "TỔNG TIỀN";
            dgvDanhSach.Columns["TenTrangThai"].HeaderText = "TRẠNG THÁI";

            dgvDanhSach.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvDanhSach.Columns["NgayNhap"].DefaultCellStyle.NullValue = "N/A";
            dgvDanhSach.Columns["NgayDuyet"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvDanhSach.Columns["NgayDuyet"].DefaultCellStyle.NullValue = "N/A";
            dgvDanhSach.Columns["NgayHuy"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvDanhSach.Columns["NgayHuy"].DefaultCellStyle.NullValue = "N/A";
            dgvDanhSach.Columns["TongTien"].DefaultCellStyle.Format = "N0";

            string[] hideCols = { "MaNCC", "MaNV", "GhiChu", "ChiTiet", "TrangThai", "NgayDuyet", "NgayHuy" };
            foreach (var col in hideCols)
                if (dgvDanhSach.Columns.Contains(col) && col != "NgayDuyet" && col != "NgayHuy")
                    dgvDanhSach.Columns[col].Visible = false;

            if (dgvDanhSach.Columns.Contains("NgayDuyet")) dgvDanhSach.Columns["NgayDuyet"].Visible = true;
            if (dgvDanhSach.Columns.Contains("NgayHuy")) dgvDanhSach.Columns["NgayHuy"].Visible = true;

            // Bật tự động sắp xếp cho tất cả các cột
            foreach (DataGridViewColumn col in dgvDanhSach.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow?.DataBoundItem is HoaDonNhapResponse item)
                UpdateButtonState(item.TrangThai);
            else
                UpdateButtonState(null);
        }

        private void UpdateButtonState(TrangThaiHoaDonNhap? t)
        {
            btnThem.Enabled = true;
            btnXem.Enabled = t != null;
            btnInHoaDon.Enabled = t != null;
            btnXuatExel.Enabled = dgvDanhSach.Rows.Count > 0;

            if (t == TrangThaiHoaDonNhap.TamLuu)
            {
                btnDuyet.Enabled = true;
                btnSua.Enabled = true;
                btnHuy.Enabled = true;
            }
            else if (t == TrangThaiHoaDonNhap.HoatDong)
            {
                btnDuyet.Enabled = false;
                btnSua.Enabled = false;
                btnHuy.Enabled = true;
            }
            else
            {
                btnDuyet.Enabled = false;
                btnSua.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void SettingUI()
        {
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var uc = _provider.GetRequiredService<ucThemHDN>();
            this.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cmbSearchMaHDN.SelectedIndex = 0;
            cmbSearchNCC.SelectedIndex = 0;
            cmbSearchNhanVien.SelectedIndex = 0;
            cmbSearchTrangThai.SelectedIndex = 0;
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
            LoadData();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow?.DataBoundItem is not HoaDonNhapResponse item) return;
            try
            {
                var full = _service.GetHoaDonNhapDetail(item.MaHDN);
                if (full == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var frm = _provider.GetRequiredService<frmViewHoaDonNhapDetails>();
                frm.LoadData(full);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow?.DataBoundItem is not HoaDonNhapResponse item) return;
            try
            {
                var full = _service.GetHoaDonNhapDetail(item.MaHDN);
                if (full == null)
                {
                    MessageBox.Show("Không tìm thấy hoá đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var uc = _provider.GetRequiredService<ucSuaHoaDonNhap>();
                uc.LoadData(full);
                this.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                this.Controls.Add(uc);
                uc.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow?.DataBoundItem is not HoaDonNhapResponse item) return;
            if (MessageBox.Show($"Bạn có chắc chắn muốn hủy hóa đơn [{item.MaHDN}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _service.CancelHoaDonNhap(item.MaHDN);
                    MessageBox.Show("Đã hủy thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow?.DataBoundItem is not HoaDonNhapResponse item) return;
            if (MessageBox.Show($"Duyệt hóa đơn [{item.MaHDN}] và cập nhật tồn kho?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _service.ApproveHoaDonNhap(item.MaHDN);
                    MessageBox.Show("Duyệt thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = cmbSearchMaHDN.Text == "--Tất cả--" ? "" : cmbSearchMaHDN.Text.Trim();
                string maNCC = cmbSearchNCC.SelectedValue?.ToString() ?? "";
                string maNV = cmbSearchNhanVien.SelectedValue?.ToString() ?? "";
                byte? tt = cmbSearchTrangThai.SelectedValue as byte?;
                DateTime? tuNgay = dtpTuNgay.Checked ? dtpTuNgay.Value.Date : null;
                DateTime? denNgay = dtpDenNgay.Checked ? dtpDenNgay.Value.Date : null;

                var ds = _service.Search(ma, tuNgay, denNgay, maNCC, maNV,
                    tt.HasValue ? (TrangThaiHoaDonNhap?)tt.Value : null);

                dgvDanhSach.DataSource = ds;
                FormatGrid();

                if (!ds.Any())
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDanhSach.Rows[e.RowIndex].Cells["MaHDN"].Value != null)
                cmbSearchMaHDN.Text = dgvDanhSach.Rows[e.RowIndex].Cells["MaHDN"].Value.ToString();
        }

        // IN 1 PHIẾU NHẬP
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow?.DataBoundItem is not HoaDonNhapResponse item)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var hd = _service.GetHoaDonNhapDetail(item.MaHDN);
                if (hd == null || hd.ChiTiet == null || !hd.ChiTiet.Any())
                {
                    MessageBox.Show("Hóa đơn trống, không thể in!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var sfd = new SaveFileDialog
                {
                    Filter = "File Excel|*.xlsx",
                    FileName = $"PhieuNhap_{hd.MaHDN}.xlsx",
                    Title = "Xuất phiếu nhập hàng"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExcelHelper.XuatPhieuNhapHang(sfd.FileName, hd);
                    MessageBox.Show("Xuất phiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất phiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XUẤT TOÀN BỘ DANH SÁCH RA EXCEL
        private void btnXuatExel_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var danhSach = dgvDanhSach.DataSource as List<HoaDonNhapResponse>;
            if (danhSach == null || !danhSach.Any()) return;

            using var sfd = new SaveFileDialog
            {
                Filter = "File Excel|*.xlsx",
                FileName = $"DanhSach_HoaDonNhap_{DateTime.Now:yyyyMMdd_HHmm}.xlsx",
                Title = "Xuất danh sách hóa đơn nhập"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExcelHelper.XuatDanhSachHoaDonNhap(sfd.FileName, danhSach);
                    MessageBox.Show($"Xuất danh sách thành công!\nTổng: {danhSach.Count} hóa đơn", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}