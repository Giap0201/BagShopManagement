using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models.Enums;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev6
{
    public partial class ucSuaHoaDonNhap : UserControl
    {
        private readonly IHoaDonNhapService _service;
        private readonly INhanVienRepository _nhanVienRepo;
        private readonly INhaCungCapRepository _nhaCungCapRepo;
        private readonly ISanPhamRepository _sanPhamRepo;
        private readonly IServiceProvider _serviceProvider;

        public ucSuaHoaDonNhap(
            IHoaDonNhapService service,
            INhanVienRepository nhanVienRepo,
            INhaCungCapRepository nhaCungCapRepo,
            ISanPhamRepository sanPhamRepo,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _service = service;
            _nhanVienRepo = nhanVienRepo;
            _nhaCungCapRepo = nhaCungCapRepo;
            _sanPhamRepo = sanPhamRepo;
            _serviceProvider = serviceProvider;
        }

        // load du lieu vao view
        public void LoadData(HoaDonNhapResponse response)
        {
            LoadComboBox();
            txtMaHDN.Text = response.MaHDN;
            txtMaHDN.ReadOnly = true;
            cboNhaCungCap.SelectedValue = response.MaNCC;
            cboNhanVien.SelectedValue = response.MaNV;
            dtpNgayNhap.Value = response.NgayNhap ?? DateTime.Now;
            txtGhiChu.Text = response.GhiChu ?? string.Empty;
            cboTrangThai.SelectedValue = (byte)response.TrangThai;
            cboTrangThai.Enabled = false;

            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = response.ChiTiet;
            FormatGrid();
            UpdateTongTien();
            UpdateButtonVisibility((byte)response.TrangThai);
        }

        // load tat ca combobox
        private void LoadComboBox()
        {
            LoadTrangThaiCombobox();
            LoadComboBoxNhaCungCap();
            LoadComboBoxNhanVien();
            LoadComboBoxSanPham();
        }

        // load trang thai
        private void LoadTrangThaiCombobox()
        {
            var data = new[]
            {
                new { Value = (byte?)TrangThaiHoaDonNhap.TamLuu, Display = "Tạm lưu" },
                new { Value = (byte?)TrangThaiHoaDonNhap.HoatDong, Display = "Hoạt động" },
                new { Value = (byte?)TrangThaiHoaDonNhap.DaHuy, Display = "Đã hủy" }
            };

            cboTrangThai.DataSource = data;
            cboTrangThai.DisplayMember = "Display";
            cboTrangThai.ValueMember = "Value";
        }

        // combobox co tim kiem
        private void EnableSearchableComboBox(ComboBox comboBox, IEnumerable<string> items)
        {
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var source = new AutoCompleteStringCollection();
            source.AddRange(items.ToArray());
            comboBox.AutoCompleteCustomSource = source;
        }

        // load nha cung cap
        private void LoadComboBoxNhaCungCap()
        {
            var list = _nhaCungCapRepo.GetAll();
            cboNhaCungCap.DataSource = list;
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
            EnableSearchableComboBox(cboNhaCungCap, list.Select(x => x.TenNCC));
        }

        // load nhan vien
        private void LoadComboBoxNhanVien()
        {
            var list = _nhanVienRepo.GetAll();
            cboNhanVien.DataSource = list;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
            EnableSearchableComboBox(cboNhanVien, list.Select(x => x.HoTen));
        }

        // load san pham
        private void LoadComboBoxSanPham()
        {
            var list = _sanPhamRepo.GetAll();
            cboSanPham.DataSource = list;
            cboSanPham.DisplayMember = "TenSP";
            cboSanPham.ValueMember = "MaSP";
            EnableSearchableComboBox(cboSanPham, list.Select(x => x.TenSP));
        }

        // validate thong tin chung
        private bool ValidateThongTinChung()
        {
            errorProvider1.Clear();

            if (cboNhaCungCap.SelectedValue == null)
            {
                errorProvider1.SetError(cboNhaCungCap, "Vui lòng chọn nhà cung cấp");
                return false;
            }

            if (cboNhanVien.SelectedValue == null)
            {
                errorProvider1.SetError(cboNhanVien, "Vui lòng chọn nhân viên");
                return false;
            }

            return true;
        }

        // validate chi tiet
        private bool ValidateChiTietInput()
        {
            errorProvider1.Clear();

            if (cboSanPham.SelectedValue == null)
            {
                errorProvider1.SetError(cboSanPham, "Vui lòng chọn sản phẩm");
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int sl) || sl <= 0)
            {
                errorProvider1.SetError(txtSoLuong, "Số lượng phải là số nguyên dương");
                return false;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal dg) || dg <= 0)
            {
                errorProvider1.SetError(txtDonGia, "Đơn giá phải là số dương");
                return false;
            }

            return true;
        }

        // dinh dang grid
        private void FormatGrid()
        {
            if (dgvChiTiet.Columns.Count == 0) return;

            dgvChiTiet.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dgvChiTiet.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvChiTiet.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
        }

        // cap nhat thong tin hoa don
        private void btnCapNhatHDN_Click(object sender, EventArgs e)
        {
            if (!ValidateThongTinChung()) return;

            if (MessageBox.Show(
                    $"Bạn có chắc muốn cập nhật hóa đơn nhập [{txtMaHDN.Text}] không?",
                    "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var req = new HoaDonNhapInfoUpdateRequest
                {
                    MaNCC = cboNhaCungCap.SelectedValue.ToString(),
                    MaNV = cboNhanVien.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text.Trim(),
                    NgayNhap = dtpNgayNhap.Value
                };

                _service.UpdateDraftInfo(txtMaHDN.Text, req);
                MessageBox.Show("Cập nhật thông tin hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // thoat ve danh sach
        private void btnThoat_Click(object sender, EventArgs e)
        {
            var parent = this.Parent;
            var listUC = _serviceProvider.GetRequiredService<ucHoaDonNhapList>();
            listUC.LoadData();
            parent.Controls.Clear();
            listUC.Dock = DockStyle.Fill;
            parent.Controls.Add(listUC);
            listUC.BringToFront();
        }

        // chuan bi them moi chi tiet
        private void btnThemChiTietHDN_Click(object sender, EventArgs e)
        {
            cboSanPham.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
            cboSanPham.Focus();
        }

        // luu chi tiet moi
        private void btnLuuChiTietHDN_Click(object sender, EventArgs e)
        {
            if (!ValidateChiTietInput()) return;

            string maHDN = txtMaHDN.Text.Trim();
            string maSP = cboSanPham.SelectedValue.ToString();
            int soLuong = int.Parse(txtSoLuong.Text.Trim());
            decimal donGia = decimal.Parse(txtDonGia.Text.Trim());
            decimal thanhTien = soLuong * donGia;

            var danhSachHienTai = dgvChiTiet.DataSource as List<ChiTietHDNResponse>;
            if (danhSachHienTai != null && danhSachHienTai.Any(x => x.MaSP == maSP))
            {
                MessageBox.Show("Sản phẩm này đã tồn tại trong hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var req = new ChiTietHDNRequest
                {
                    MaSP = maSP,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThanhTien = thanhTien
                };

                _service.AddDetailToDraft(maHDN, req);
                ReloadChiTiet(maHDN);
                MessageBox.Show("Thêm chi tiết hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnThemChiTietHDN.PerformClick(); // Reset form nhập
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // sua chi tiet
        private void btnSuaChiTietHDN_Click(object sender, EventArgs e)
        {
            if (!ValidateChiTietInput()) return;
            if (dgvChiTiet.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maHDN = txtMaHDN.Text.Trim();
            string maSPCu = dgvChiTiet.CurrentRow.Cells["MaSP"].Value.ToString();

            if (MessageBox.Show(
                    $"Bạn có muốn sửa thông tin sản phẩm [{maSPCu}] không?",
                    "Xác nhận sửa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var req = new ChiTietHDNRequest
                {
                    MaSP = maSPCu,
                    SoLuong = int.Parse(txtSoLuong.Text.Trim()),
                    DonGia = decimal.Parse(txtDonGia.Text.Trim()),
                    ThanhTien = decimal.Parse(txtThanhTien.Text.Trim())
                };

                _service.UpdateDetailInDraft(maHDN, maSPCu, req);
                ReloadChiTiet(maHDN);
                MessageBox.Show("Sửa chi tiết thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // xoa chi tiet
        private void btnXoaChiTietHDN_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maHDN = txtMaHDN.Text.Trim();
            string maSP = dgvChiTiet.CurrentRow.Cells["MaSP"].Value.ToString();
            string tenSP = dgvChiTiet.CurrentRow.Cells["TenSP"].Value.ToString();

            if (MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sản phẩm [{tenSP}] khỏi hóa đơn không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _service.DeleteDetailFromDraft(maHDN, maSP);
                ReloadChiTiet(maHDN);
                MessageBox.Show("Xóa chi tiết thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // click vao grid show len form
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvChiTiet.Rows[e.RowIndex];
            cboSanPham.SelectedValue = row.Cells["MaSP"].Value;
            txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
            txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            txtThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
        }

        // tinh thanh tien tu dong
        private void TinhThanhTien()
        {
            if (int.TryParse(txtSoLuong.Text.Trim(), out int sl) &&
                decimal.TryParse(txtDonGia.Text.Trim(), out decimal dg))
            {
                txtThanhTien.Text = (sl * dg).ToString("N0");
            }
            else
            {
                txtThanhTien.Clear();
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e) => TinhThanhTien();

        private void txtDonGia_TextChanged(object sender, EventArgs e) => TinhThanhTien();

        // cap nhat tong tien
        private void UpdateTongTien()
        {
            var list = dgvChiTiet.DataSource as List<ChiTietHDNResponse>;
            lblTongTien.Text = list?.Sum(x => x.ThanhTien).ToString("N0") ?? "0";
        }

        // reload chi tiet hoa don
        private void ReloadChiTiet(string maHDN)
        {
            var res = _service.GetHoaDonNhapDetail(maHDN);
            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = res.ChiTiet;
            FormatGrid();
            UpdateTongTien();
        }

        // an/hien nut theo trang thai
        private void UpdateButtonVisibility(byte trangThai)
        {
            bool isDraft = trangThai == (byte)TrangThaiHoaDonNhap.TamLuu;
            btnLuuChiTietHDN.Enabled = isDraft;
            btnSuaChiTietHDN.Enabled = isDraft;
            btnXoaChiTietHDN.Enabled = isDraft;
            btnThemChiTietHDN.Enabled = isDraft;
        }

        // In hoa don khi sua
        private void btnInHDN_Click(object sender, EventArgs e)
        {
            try
            {
                var hd = _service.GetHoaDonNhapDetail(txtMaHDN.Text);
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
    }
}