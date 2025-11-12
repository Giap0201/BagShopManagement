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

            // Cấu hình DataGridView để hiển thị tốt hơn
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCart.AllowUserToResizeColumns = true;
            dgvCart.ColumnHeadersHeight = 45;
            dgvCart.RowTemplate.Height = 40;

            // Tăng font size cho dễ đọc
            dgvCart.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvCart.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Tất cả cột có width bằng nhau (150px)
            int columnWidth = 150;

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã SP",
                DataPropertyName = "MaSP",
                Name = "MaSP",
                Width = columnWidth,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSP",
                Name = "TenSP",
                Width = columnWidth,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                Name = "SoLuong",
                Width = columnWidth,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia",
                Name = "DonGia",
                Width = columnWidth,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giảm giá",
                DataPropertyName = "GiamGiaSP",
                Name = "GiamGiaSP",
                Width = columnWidth,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                Name = "ThanhTien",
                Width = columnWidth,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold)
                }
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

            // Kiểm tra tồn kho trước khi thêm
            var sanPhamRepo = new SanPhamRepository();
            var sp = sanPhamRepo.GetById(maSP);

            if (sp != null)
            {
                // Hiển thị thông tin tồn kho
                if (sp.SoLuongTon < qty)
                {
                    MessageBox.Show($"Sản phẩm '{sp.TenSP}' chỉ còn {sp.SoLuongTon} trong kho!\nKhông đủ số lượng để thêm vào giỏ.",
                        "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (sp.SoLuongTon <= 10)
                {
                    // Cảnh báo sắp hết hàng
                    var result = MessageBox.Show($"⚠️ Sản phẩm '{sp.TenSP}' sắp hết hàng!\nTồn kho: {sp.SoLuongTon}\n\nBạn có muốn tiếp tục thêm vào giỏ không?",
                        "Cảnh báo sắp hết hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        txtMaSP.Clear();
                        txtMaSP.Focus();
                        return;
                    }
                }
            }

            var (ok, msg) = _controller.AddProduct(maSP, qty);
            if (!ok)
                MessageBox.Show(msg, "Không thể thêm sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                RefreshCartGrid();
                // Hiển thị thông báo thành công với tồn kho còn lại
                if (sp != null)
                {
                    int tonKhoConLai = sp.SoLuongTon - qty;
                    MessageBox.Show($"✓ Đã thêm {qty} x '{sp.TenSP}' vào giỏ hàng\nTồn kho còn lại: {tonKhoConLai}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

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
            if (percent <= 0 || percent > 100)
            {
                MessageBox.Show("Vui lòng nhập phần trăm giảm giá hợp lệ (0 < % ≤ 100).",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cart = _controller.GetCart();
            if (cart == null || cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống! Vui lòng thêm sản phẩm trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Hỏi người dùng muốn áp dụng cho 1 sản phẩm hay tất cả
            var result = MessageBox.Show(
                $"Áp dụng giảm giá {percent}% cho:\n\n" +
                $"YES = Tất cả sản phẩm trong giỏ\n" +
                $"NO = Chỉ sản phẩm đang chọn\n" +
                $"CANCEL = Hủy bỏ",
                "Chọn phạm vi áp dụng",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            if (result == DialogResult.Yes)
            {
                // Áp dụng cho tất cả
                _controller.ApplyDiscount(percent);
                MessageBox.Show($"✓ Đã áp dụng giảm giá {percent}% cho {cart.Count} sản phẩm",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.No)
            {
                // Áp dụng cho sản phẩm được chọn
                if (dgvCart.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm trong giỏ hàng.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var selectedRow = dgvCart.SelectedRows[0];
                string? maSP = selectedRow.Cells["MaSP"]?.Value?.ToString();
                string? tenSP = selectedRow.Cells["TenSP"]?.Value?.ToString();

                if (string.IsNullOrEmpty(maSP))
                {
                    MessageBox.Show("Không thể xác định mã sản phẩm được chọn.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _controller.ApplyDiscountToProduct(maSP, percent);
                MessageBox.Show($"✓ Đã áp dụng giảm giá {percent}% cho '{tenSP}'",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RefreshCartGrid();
            numDiscountPercent.Value = 0; // Reset sau khi áp dụng
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
            // Kiểm tra giỏ hàng
            var cart = _controller.GetCart();
            if (cart == null || cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống! Vui lòng thêm sản phẩm trước khi thanh toán.",
                    "Giỏ hàng trống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate thông tin
            string maKH = txtMaKH.Text.Trim();
            string maNV = txtMaNV.Text.Trim();

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            // Tính tổng tiền
            decimal tongTien = cart.Sum(i => (i.DonGia - i.GiamGiaSP) * i.SoLuong);

            // Xác nhận trước khi lưu/thanh toán
            string confirmMsg = saveDraft
                ? $"Lưu tạm hóa đơn?\n\nTổng tiền: {tongTien:N0} ₫\nSố sản phẩm: {cart.Count}\nNhân viên: {maNV}"
                : $"Xác nhận thanh toán?\n\nTổng tiền: {tongTien:N0} ₫\nSố sản phẩm: {cart.Count}\nKhách hàng: {(string.IsNullOrEmpty(maKH) ? "Khách lẻ" : maKH)}\nNhân viên: {maNV}";

            var confirm = MessageBox.Show(confirmMsg,
                saveDraft ? "Xác nhận lưu tạm" : "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            // Thực hiện checkout
            var (ok, res) = _controller.Checkout(maKH, maNV, saveDraft);

            if (!ok)
            {
                MessageBox.Show($"❌ {res}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lưu mã hóa đơn để in sau
            _lastSavedInvoiceId = res;

            // Thông báo thành công với chi tiết
            string successMsg = saveDraft
                ? $"✓ Hóa đơn tạm đã lưu!\n\nMã HĐ: {res}\nTổng tiền: {tongTien:N0} ₫\n\nBạn có thể chỉnh sửa hóa đơn này sau."
                : $"✓ Thanh toán thành công!\n\nMã HĐ: {res}\nTổng tiền: {tongTien:N0} ₫\n\nBạn có muốn in hóa đơn ngay không?";

            var result = MessageBox.Show(successMsg, "Thành công",
                saveDraft ? MessageBoxButtons.OK : MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            // Nếu thanh toán thành công và muốn in ngay
            if (!saveDraft && result == DialogResult.Yes)
            {
                btnPrint_Click(this, EventArgs.Empty);
            }

            // Reset form sau khi hoàn tất
            ResetForm();
        }

        /// <summary>
        /// Reset form về trạng thái ban đầu
        /// </summary>
        private void ResetForm()
        {
            _controller.ClearCart();
            RefreshCartGrid();
            txtMaKH.Clear();
            txtMaSP.Clear();
            numQty.Value = 1;
            numDiscountPercent.Value = 0;
            txtMaSP.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_lastSavedInvoiceId))
            {
                MessageBox.Show("Chưa có hóa đơn nào để in.\n\nVui lòng thanh toán hoặc lưu tạm hóa đơn trước.",
                    "Không có hóa đơn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Xác nhận trước khi in
                var confirm = MessageBox.Show(
                    $"In hóa đơn {_lastSavedInvoiceId}?",
                    "Xác nhận in",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                var printService = new InvoicePrintService();
                printService.PrintInvoice(_lastSavedInvoiceId);

                // Thông báo sau khi in xong (nếu không có lỗi)
                MessageBox.Show(
                    $"✓ Đã gửi hóa đơn {_lastSavedInvoiceId} đến máy in!",
                    "In thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Dispose printService
                printService.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Lỗi khi in hóa đơn:\n\n{ex.Message}\n\nVui lòng kiểm tra:\n" +
                    $"- Máy in đã được kết nối?\n" +
                    $"- Driver máy in đã được cài đặt?\n" +
                    $"- Có giấy trong máy in?",
                    "Lỗi in hóa đơn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}