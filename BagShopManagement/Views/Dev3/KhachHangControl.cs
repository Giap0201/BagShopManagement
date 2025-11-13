using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Views.Dev3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev4
{
    public partial class KhachHangControl : UserControl
    {
        private readonly KhachHangController _controller;
        public KhachHangControl()
        {
            _controller = new KhachHangController();
            InitializeComponent();
        }
        private void LoadDanhSachKH()
        {
            try
            {
                var list = _controller.GetAll();
                dgvKhachHang.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}");
            }
        }

        private void KhachHangControl_Load(object sender, EventArgs e)
        {
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.MultiSelect = false;
            LoadDanhSachKH();
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTimKhachHang.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông báo");
                txtTimKhachHang.Focus();
                return;
            }
            var KH = _controller.GetById(txtTimKhachHang.Text.Trim());
            if (KH == null)
            {
                MessageBox.Show("Khách hàng không tồn tại", "Thông báo");
            }
            else
            {
                dgvKhachHang.DataSource = new List<KhachHang> { KH };
            }

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            using (var frm = new ThemKhachHangForm(_controller))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvKhachHang.DataSource = _controller.GetAll();
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {

            var kh = (KhachHang)dgvKhachHang.CurrentRow.DataBoundItem;
            using (var frm = new ThemKhachHangForm(_controller, kh))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvKhachHang.DataSource = _controller.GetAll();
                }
            }
        }
        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.Rows.Count == 0) return;

            bool showButtons = false;

            if (dgvKhachHang.SelectedRows.Count == 1)
            {
                if (!dgvKhachHang.SelectedRows[0].IsNewRow)
                {
                    showButtons = true;
                }
            }

            btnSua.Visible = showButtons;
            btnXoa.Visible = showButtons;
        }

        private void KhachHangControl_Click(object sender, EventArgs e)
        {

            dgvKhachHang.ClearSelection();
            btnSua.Visible = false;
            btnXoa.Visible = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
           
                DataGridViewRow selectedRow = dgvKhachHang.SelectedRows[0];

                string maKH = selectedRow.Cells["MaKH"].Value.ToString();

                string message = $"Bạn có chắc chắn muốn xóa khách hàng có mã '{maKH}' không?";
                string title = "Xác nhận xóa";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

                // 5. Kiểm tra kết quả người dùng bấm
                if (result == DialogResult.Yes)
                {
                   
                   if( _controller.Delete(maKH))
                    {
                    dgvKhachHang.DataSource = _controller.GetAll();
                    MessageBox.Show($"Đã xóa khách hàng '{maKH}' thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Xóa khách hàng '{maKH}' không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

   
                }
               
            }
           
        
    
    }
}
