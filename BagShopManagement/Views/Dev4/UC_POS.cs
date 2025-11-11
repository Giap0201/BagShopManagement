using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev4.Dev4_POS
{
    public partial class UC_POS : UserControl
    {
        private readonly POSController _controller;
        private string? _lastSavedInvoiceId;

        public UC_POS()
        {
            InitializeComponent();

            // Nếu không dùng DI thì khởi tạo thủ công (tạm thời)
            var sanPhamRepo = new SanPhamRepository();
            var hoaDonRepo = new HoaDonBanRepository();

            var hoaDonService = new HoaDonBanService(hoaDonRepo);
            var tonKhoService = new TonKhoService(sanPhamRepo);
            var posService = new PosService(sanPhamRepo, hoaDonService, tonKhoService);

            _controller = new POSController(posService);
        }

        private void UC_POS_Load(object sender, EventArgs e)
        {
            SetupCartColumns();
        }

        /// <summary>
        /// Thiết lập các cột cho DataGridView giỏ hàng
        /// </summary>
        private void SetupCartColumns()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã SP",
                DataPropertyName = "MaSP",
                Name = "MaSP",
                Width = 120
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSP",
                Name = "TenSP",
                Width = 220
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                Name = "SoLuong",
                Width = 100
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia",
                Name = "DonGia",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giảm/SP",
                DataPropertyName = "GiamGiaSP",
                Name = "GiamGiaSP",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                Name = "ThanhTien",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
        }

        // ========== Các sự kiện giao diện ==========
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
                var cart = _controller.GetCart();

                if (cart == null || cart.Count == 0)
                {
                    dgvCart.DataSource = null;
                    lblTotal.Text = "Tổng: 0 ₫";
                    return;
                }

                // Setup columns nếu chưa có
                if (dgvCart.Columns.Count == 0)
                    SetupCartColumns();

                dgvCart.DataSource = null;
                dgvCart.DataSource = cart;

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

            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để áp dụng giảm giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvCart.SelectedRows[0];
            string? maSP = selectedRow.Cells["MaSP"]?.Value?.ToString();

            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Không thể xác định mã sản phẩm được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _controller.ApplyDiscountToProduct(maSP, percent);
            RefreshCartGrid();
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            SaveOrCheckout(saveDraft: true);
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            SaveOrCheckout(saveDraft: false);
        }

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
                MessageBox.Show("Chưa có hóa đơn nào để in.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var printService = new InvoicePrintService();
                printService.PrintInvoice(_lastSavedInvoiceId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa 1 sản phẩm khỏi giỏ
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvCart.SelectedRows[0];
            string? maSP = row.Cells["MaSP"]?.Value?.ToString();
            string? tenSP = row.Cells["TenSP"]?.Value?.ToString();

            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Không thể xác định mã sản phẩm.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show(
                $"Xóa sản phẩm [{tenSP ?? "N/A"}] (Mã: {maSP})?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _controller.RemoveProduct(maSP);
                RefreshCartGrid();
                dgvCart.Focus();
            }
        }
    }
}