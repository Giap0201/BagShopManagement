using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Models.Enums;
using BagShopManagement.Repositories.Interfaces;
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
        private readonly HoaDonNhapController _controller;
        private readonly INhaCungCapRepository _nccRepo;
        private readonly INhanVienRepository _nvRepo;
        private readonly IServiceProvider _provider;

        public ucHoaDonNhapList(
            HoaDonNhapController controller,
            INhaCungCapRepository nccRepo,
            INhanVienRepository nvRepo,
            IServiceProvider provider)
        {
            InitializeComponent();
            _controller = controller;
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

        #region === LOAD DATA ===

        private void LoadData()
        {
            try
            {
                dgvDanhSach.DataSource = _controller.LayDanhSachHoaDon();
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvDanhSach.DataSource = null;
            }
        }

        // load du lieu cho cac combobox
        private void LoadComboBoxes()
        {
            LoadTrangThaiComboBox();
            LoadComboBoxNhaCungCap();
            LoadComboBoxNhanVien();
            LoadComboBoxHoaDonNhap();
        }

        // load cac trang thai hoa don nhap vao combobox
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

        // load nhan vien vao combobox
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

        // load toan bo hoa don nhap vao combobox
        private void LoadComboBoxHoaDonNhap()
        {
            try
            {
                var list = _controller.GetAll();
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

            dgvDanhSach.Columns["MaHDN"].HeaderText = "Mã HĐN";
            dgvDanhSach.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";
            dgvDanhSach.Columns["TenNV"].HeaderText = "Nhân Viên";
            dgvDanhSach.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            dgvDanhSach.Columns["NgayDuyet"].HeaderText = "Ngày Duyệt";
            dgvDanhSach.Columns["NgayHuy"].HeaderText = "Ngày Huỷ";
            dgvDanhSach.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dgvDanhSach.Columns["TenTrangThai"].HeaderText = "Trạng Thái";
            dgvDanhSach.Columns["TongTien"].DefaultCellStyle.Format = "N0";

            string[] hideCols = { "MaNCC", "MaNV", "GhiChu", "ChiTiet", "TrangThai" };
            foreach (var col in hideCols)
                if (dgvDanhSach.Columns.Contains(col))
                    dgvDanhSach.Columns[col].Visible = false;
        }

        #endregion === LOAD DATA ===

        #region === UI/SELECTION ===

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow == null)
            {
                UpdateButtonState(null);
                return;
            }

            object dataItem = dgvDanhSach.CurrentRow.DataBoundItem;
            if (dataItem is HoaDonNhapResponse)
            {
                HoaDonNhapResponse item = (HoaDonNhapResponse)dataItem;
                UpdateButtonState(item.TrangThai);
            }
            else
            {
                UpdateButtonState(null);
                return;
            }
        }

        private void UpdateButtonState(TrangThaiHoaDonNhap? t)
        {
            btnThem.Enabled = true;
            if (t != null)
            {
                btnXem.Enabled = true;
                TrangThaiHoaDonNhap trangThai = t.Value;
                if (trangThai == TrangThaiHoaDonNhap.TamLuu)
                {
                    btnDuyet.Enabled = true;
                    btnSua.Enabled = true;
                }
                else
                {
                    btnDuyet.Enabled = false;
                    btnSua.Enabled = false;
                }
                if (trangThai == TrangThaiHoaDonNhap.TamLuu || trangThai == TrangThaiHoaDonNhap.HoatDong)
                {
                    btnHuy.Enabled = true;
                }
                else
                {
                    btnHuy.Enabled = false;
                }
            }
            else
            {
                btnXem.Enabled = false;
                btnDuyet.Enabled = false;
                btnHuy.Enabled = false;
                btnSua.Enabled = false;
            }
        }

        private void SettingUI()
        {
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
        }

        #endregion === UI/SELECTION ===

        #region === BUTTON HANDLER ===

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
            if (dgvDanhSach.CurrentRow?.DataBoundItem is not HoaDonNhapResponse item)
                return;

            try
            {
                var full = _controller.LayChiTietHoaDon(item.MaHDN);
                if (full == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadData();
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
            if (dgvDanhSach.CurrentRow?.DataBoundItem is not HoaDonNhapResponse item)
                return;

            try
            {
                var full = _controller.LayChiTietHoaDon(item.MaHDN);
                if (full == null)
                {
                    MessageBox.Show("Không tìm thấy hoá đơn.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadData();
                    return;
                }

                var uc = _provider.GetRequiredService<UcSuaHoaDonNhap>();
                uc.LoadData(full);
                this.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                this.Controls.Add(uc);
                uc.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow?.DataBoundItem is not HoaDonNhapResponse item)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn hủy hóa đơn [{item.MaHDN}] này không? Thao tác này không thể hoàn tác.",
                "Xác nhận hủy hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _controller.HuyHoaDon(item.MaHDN);
                MessageBox.Show($"Đã hủy hóa đơn {item.MaHDN}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow?.DataBoundItem is not HoaDonNhapResponse item)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn duyệt hóa đơn [{item.MaHDN}]?\nHành động này sẽ cập nhật tồn kho.",
                "Xác nhận duyệt hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;
            try
            {
                _controller.DuyetHoaDon(item.MaHDN);
                MessageBox.Show(
                    $"Đã duyệt hóa đơn {item.MaHDN} thành công và cập nhật tồn kho.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadData();
            }
            catch (InvalidOperationException ioex)
            {
                MessageBox.Show(ioex.Message, "Lỗi Nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống khi duyệt hóa đơn: {ex.Message}", "Lỗi Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = cmbSearchMaHDN.Text.Trim();
                if (ma == "--Tất cả--" || string.IsNullOrEmpty(ma)) ma = string.Empty;
                string maNCC = cmbSearchNCC.SelectedValue?.ToString();
                string maNV = cmbSearchNhanVien.SelectedValue?.ToString();
                DateTime? tuNgay = dtpTuNgay.Checked ? dtpTuNgay.Value.Date : null;
                DateTime? denNgay = dtpDenNgay.Checked ? dtpDenNgay.Value.Date : null;
                byte? tt = cmbSearchTrangThai.SelectedValue as byte?;

                var ds = _controller.TimKiemHoaDon(
                    ma, tuNgay, denNgay, maNCC, maNV,
                    tt.HasValue ? (TrangThaiHoaDonNhap?)tt.Value : null);

                dgvDanhSach.DataSource = ds;
                FormatGrid();

                if (ds.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                cmbSearchMaHDN.Text =
                    dgvDanhSach.Rows[e.RowIndex].Cells["MaHDN"].Value.ToString();
        }

        #endregion === BUTTON HANDLER ===
    }
}