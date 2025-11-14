using BagShopManagement.Controllers;
using BagShopManagement.DTOs;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BagShopManagement.Views.Controls
{
    public partial class PromotionControl : UserControl
    {
        private readonly ChuongTrinhGiamGiaController _promotionController;
        private readonly ChiTietGiamGiaController _chiTietGiamGiaController;

        public PromotionControl(ChuongTrinhGiamGiaController promotionController, ChiTietGiamGiaController chiTietGiamGiaController)
        {
            InitializeComponent();

            // Chỉ cần gán các controller đã được tiêm vào
            _promotionController = promotionController;
            _chiTietGiamGiaController = chiTietGiamGiaController;

            SetupStatusComboBox();
        }

        private void PromotionControl_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
            // Cải tiến: Gán sự kiện SelectionChanged thay vì CellContentClick
            dgvDanhSachCTGG.SelectionChanged += DgvDanhSachCTGG_SelectionChanged;
        }

        private void LoadDataGrid()
        {
            try
            {
                var promotions = _promotionController.GetPromotions();
                // Tắt sự kiện SelectionChanged tạm thời để tránh lỗi khi nạp lại dữ liệu
                dgvDanhSachCTGG.SelectionChanged -= DgvDanhSachCTGG_SelectionChanged;

                dgvDanhSachCTGG.DataSource = null;
                dgvDanhSachCTGG.DataSource = promotions;

                // Bật lại sự kiện
                dgvDanhSachCTGG.SelectionChanged += DgvDanhSachCTGG_SelectionChanged;

                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvDanhSachCTGG_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachCTGG.CurrentRow != null && dgvDanhSachCTGG.CurrentRow.DataBoundItem is ChuongTrinhGiamGiaDto dto)
            {
                txtMaCTGG.Text = dto.MaCTGG;
                txtTenCT.Text = dto.TenChuongTrinh;
                txtMoTa.Text = dto.MoTa;
                dateTimePicker1.Value = dto.NgayBatDau;
                dateTimePicker2.Value = dto.NgayKetThuc;
                cmbTrangThai.SelectedValue = dto.TrangThai;

                txtMaCTGG.Enabled = false;
            }
        }

        // Các hàm khác không thay đổi nhiều...
        private void btnThemCTGG_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtMaCTGG.Text = "";
            txtTenCT.Text = "";
            txtMoTa.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(7);
            cmbTrangThai.SelectedIndex = 0;
            txtMaCTGG.Enabled = true;
            txtMaCTGG.Focus();
            dgvDanhSachCTGG.ClearSelection();
        }

        private void btnLuuCTGG_Click(object sender, EventArgs e)
        {
            // Các kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtMaCTGG.Text))
            {
                MessageBox.Show("Mã chương trình không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCTGG.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenCT.Text))
            {
                MessageBox.Show("Tên chương trình không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCT.Focus();
                return;
            }
            if (dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var promotionDto = new ChuongTrinhGiamGiaDto
            {
                MaCTGG = txtMaCTGG.Text.Trim().ToUpper(),
                TenChuongTrinh = txtTenCT.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                NgayBatDau = dateTimePicker1.Value,
                NgayKetThuc = dateTimePicker2.Value,
                TrangThai = (bool)cmbTrangThai.SelectedValue
            };

            try
            {
                _promotionController.SavePromotion(promotionDto);
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lưu thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaCTGG_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachCTGG.CurrentRow == null || string.IsNullOrWhiteSpace(txtMaCTGG.Text))
            {
                MessageBox.Show("Vui lòng chọn một chương trình để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           

            string maCanXoa = txtMaCTGG.Text;
            string tenCanXoa = txtTenCT.Text;

            if (MessageBox.Show($"Bạn chắc chắn muốn xóa chương trình '{tenCanXoa}' và tất cả sản phẩm khuyến mãi liên quan?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _promotionController.DeletePromotion(maCanXoa);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xóa thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChonSanPham_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachCTGG.CurrentRow == null || string.IsNullOrWhiteSpace(txtMaCTGG.Text))
            {
                MessageBox.Show("Vui lòng chọn một chương trình để áp dụng sản phẩm.", "Thông báo");
                return;
            }

            // Logic vẫn như cũ, vì _chiTietGiamGiaController đã được khởi tạo bởi DI
            frmApDungChiTiet formApDung = new frmApDungChiTiet(txtMaCTGG.Text, txtTenCT.Text, _chiTietGiamGiaController);
            formApDung.ShowDialog();
        }

        private void SetupStatusComboBox()
        {
            var statusOptions = new List<StatusOption>
            {
                new StatusOption{ Value = true, DisplayText = "Hoạt động" },
                new StatusOption{ Value = false, DisplayText = "Không hoạt động" }
            };
            cmbTrangThai.DataSource = statusOptions;
            cmbTrangThai.DisplayMember = "DisplayText";
            cmbTrangThai.ValueMember = "Value";
        }
    }
}