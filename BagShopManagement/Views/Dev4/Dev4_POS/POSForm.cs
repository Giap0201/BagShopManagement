using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev4.Dev4_POS
{
    public partial class POSForm : Form
    {
        private readonly POSController _controller;
        private string _lastSavedInvoiceId;

        public POSForm()
        {
            InitializeComponent();

            var sanPhamRepo = new SanPhamRepository();
            var hoaDonRepo = new HoaDonBanRepository();

            var hoaDonService = new HoaDonBanService(hoaDonRepo);
            var tonKhoService = new TonKhoService(sanPhamRepo);

            var posService = new PosService(sanPhamRepo, hoaDonService, tonKhoService);

            _controller = new POSController(posService);
        }


        private void POSForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var maSP = txtMaSP.Text.Trim();
            int qty = (int)numQty.Value;

            if (string.IsNullOrWhiteSpace(maSP))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (ok, msg) = _controller.AddProduct(maSP, qty);
            if (!ok)
                MessageBox.Show(msg, "Không thể thêm sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                RefreshCartGrid();

            txtMaSP.Clear();
            numQty.Value = 1;
            txtMaSP.Focus();
        }
        private void RefreshCartGrid()
        {
            try
            {
                dgvCart.AutoGenerateColumns = false; // Tắt auto sinh cột

                var cart = _controller.GetCart();

                if (cart == null || cart.Count == 0)
                {
                    dgvCart.DataSource = null;
                    lblTotal.Text = "Tổng: 0 ₫";
                    return;
                }

                // Chuẩn hóa dữ liệu hiển thị: format giá, tổng tiền,...
                cart.Select(c => new
                {
                    MaSP = c.MaSP,
                    TenSP = c.TenSP ?? "", // Lấy tên sản phẩm
                    SoLuong = c.SoLuong,
                    DonGia = c.DonGia,
                    GiamGiaSP = c.GiamGiaSP,
                    ThanhTien = (c.DonGia - c.GiamGiaSP) * c.SoLuong
                })
                .ToList();

                dgvCart.DataSource = cart;

                // 🧮 Tính tổng tiền
                decimal total = cart.Sum(i => (i.DonGia - i.GiamGiaSP) * i.SoLuong);
                lblTotal.Text = $"Tổng: {total:N0} ₫";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải giỏ hàng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa toàn bộ giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _controller.ClearCart();
                RefreshCartGrid();
            }
        }

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            decimal percent = numDiscountPercent.Value;
            if (percent <= 0)
            {
                MessageBox.Show("Vui lòng nhập phần trăm giảm giá hợp lệ (> 0).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _controller.ApplyDiscount(percent);
            RefreshCartGrid();
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            SaveOrCheckout(saveDraft: true);
        }
        // 🧾 Lưu / Thanh toán hóa đơn (hàm dùng chung)
        private void SaveOrCheckout(bool saveDraft)
        {
            string maKH = txtMaKH.Text.Trim();
            string maNV = txtMaNV.Text.Trim();

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Thiếu mã nhân viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (ok, res) = _controller.Checkout(maKH, maNV, saveDraft);

            if (!ok)
            {
                MessageBox.Show(res, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _lastSavedInvoiceId = res;
            MessageBox.Show(
                saveDraft ? $"Hóa đơn tạm đã lưu (Mã: {res})" : $"Thanh toán thành công! Mã HĐ: {res}",
                "Thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            RefreshCartGrid();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_lastSavedInvoiceId))
            {
                MessageBox.Show("Chưa có hóa đơn nào để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Placeholder – phần này có thể thay bằng ReportViewer hoặc PrintDocument
            MessageBox.Show($"In hóa đơn {_lastSavedInvoiceId} (tính năng đang phát triển).", "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            SaveOrCheckout(saveDraft: false);
        }

        private void lblNv_Click(object sender, EventArgs e)
        {

        }

        private void chkSaveDraft_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 🔹 Lấy mã sản phẩm từ cột "Mã SP"
            string maSP = dgvCart.SelectedRows[0].Cells["MaSP"].Value?.ToString();
            string tenSP = dgvCart.SelectedRows[0].Cells["TenSP"].Value?.ToString();

            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Không thể xác định mã sản phẩm.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🔹 Xác nhận xóa
            if (MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm [{tenSP}] (Mã: {maSP}) khỏi giỏ hàng?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _controller.RemoveProduct(maSP);
                RefreshCartGrid();
            }
        }
    }
}
