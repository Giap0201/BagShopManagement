using BagShopManagement.Controllers;
using BagShopManagement.DTOs;
using BagShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Controls
{
    public partial class PromotionControl : UserControl
    {
        private readonly ChuongTrinhGiamGiaController _promotionController;

        public PromotionControl()
        {
            InitializeComponent();
            _promotionController = new ChuongTrinhGiamGiaController();
            SetupStatusComboBox();

        }

        private void SetupStatusComboBox()
        {
            // 1. Tạo danh sách các lựa chọn trạng thái
            var statusOptions = new List<StatusOption>
        {
            new StatusOption { Value = true, DisplayText = "Hoạt động" },
            new StatusOption { Value = false, DisplayText = "Không hoạt động" }
        };

            // 2. Gán danh sách này làm nguồn dữ liệu cho ComboBox
            cmbTrangThai.DataSource = statusOptions;

            // 3. Chỉ định thuộc tính nào để HIỂN THỊ cho người dùng
            cmbTrangThai.DisplayMember = "DisplayText";

            // 4. Chỉ định thuộc tính nào là GIÁ TRỊ THỰC TẾ ẩn đằng sau
            cmbTrangThai.ValueMember = "Value";
        }

        private void PromotionControl_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var promotions = _promotionController.GetPromotions();
                dgvDanhSachCTGG.DataSource = null; // Xóa datasource cũ
                dgvDanhSachCTGG.DataSource = promotions;
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSachCTGG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSachCTGG.Rows[e.RowIndex];
                txtMaCTGG.Text = row.Cells["MaCTGG"].Value.ToString();
                txtTenCT.Text = row.Cells["TenChuongTrinh"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
                dateTimePicker2.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
                bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                cmbTrangThai.SelectedValue = trangThai;

                txtMaCTGG.Enabled = false;
            }
        }

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
            txtMaCTGG.Enabled = true;
            txtMaCTGG.Focus();
        }

        private void btnLuuCTGG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCTGG.Text))
            {
                MessageBox.Show("Mã chương trình không được để trống.", "Cảnh báo");
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
                MessageBox.Show("Lưu thành công!", "Thông báo");
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lưu thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaCTGG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCTGG.Text) || txtMaCTGG.Enabled)
            {
                MessageBox.Show("Vui lòng chọn một chương trình đã có để xóa.", "Thông báo");
                return;
            }

            string maCanXoa = txtMaCTGG.Text;
            string tenCanXoa = txtTenCT.Text;

            if (MessageBox.Show($"Bạn chắc chắn muốn xóa chương trình '{tenCanXoa}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _promotionController.DeletePromotion(maCanXoa);
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    LoadDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xóa thất bại: {ex.Message}", "Lỗi");
                }
            }
        }

        private void btnChonSanPham_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCTGG.Text) || txtMaCTGG.Enabled)
            {
                MessageBox.Show("Vui lòng chọn một chương trình đã có để áp dụng sản phẩm.", "Thông báo");
                return;
            }
            frmApDungChiTiet formApDung = new frmApDungChiTiet(txtMaCTGG.Text, txtTenCT.Text);
            formApDung.ShowDialog();
        }

    }
}
