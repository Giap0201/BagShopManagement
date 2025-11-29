using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Utils;
using BagShopManagement.Views.Dev3;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev4.Dev4_POS
{
    public partial class UC_POS : UserControl
    {
        private readonly POSController _controller;

        public UC_POS()
        {
            InitializeComponent();

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

            if (!string.IsNullOrEmpty(UserContext.MaNV))
            {
                txtMaNV.Text = UserContext.MaNV;
                txtTenNV.Text = UserContext.HoTen ?? "";
                txtMaNV.ReadOnly = true;
                txtTenNV.ReadOnly = true;
            }
        }

        /// <summary>
        /// Thiết lập các cột cho DataGridView giỏ hàng
        /// </summary>
        private void SetupCartColumns()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.AllowUserToResizeColumns = true;
            dgvCart.ColumnHeadersHeight = 45;
            dgvCart.RowTemplate.Height = 40;

            // Tăng font size cho dễ đọc
            dgvCart.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvCart.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã SP",
                DataPropertyName = "MaSP",
                Name = "MaSP",
                FillWeight = 15
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSP",
                Name = "TenSP",
                FillWeight = 30
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                Name = "SoLuong",
                FillWeight = 12,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia",
                Name = "DonGia",
                FillWeight = 15,
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
                FillWeight = 13,
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
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold)
                }
            });
        }

        // ========== Các sự kiện giao diện ==========

        /// <summary>
        /// Xử lý sự kiện click nút "Lọc" để tìm khách hàng theo số điện thoại
        /// </summary>
        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                string sdt = txtSDT.Text.Trim();

                if (string.IsNullOrWhiteSpace(sdt))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại khách hàng!", "Thiếu thông tin",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                if (sdt.Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải có đúng 10 số!\nVui lòng nhập lại.",
                        "Số điện thoại không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    txtSDT.SelectAll();
                    return;
                }

                if (!sdt.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại chỉ được chứa các chữ số (0-9)!\nVui lòng nhập lại.",
                        "Số điện thoại không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    txtSDT.SelectAll();
                    return;
                }

                if (!sdt.StartsWith("0"))
                {
                    MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0!\nVui lòng nhập lại.",
                        "Số điện thoại không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    txtSDT.SelectAll();
                    return;
                }

                var khRepo = new KhachHangRepository();
                var khachHang = khRepo.GetBySDT(sdt);

                if (khachHang != null)
                {
                    MessageBox.Show($"✓ Đã tìm thấy khách hàng có số điện thoại \"{sdt}\"\n\n" +
                                    $"Họ tên: {khachHang.HoTen}\n" +
                                    $"Mã KH: {khachHang.MaKH}",
                        "Tìm thấy khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtMaKH.Text = khachHang.MaKH;
                    txtTenKH.Text = khachHang.HoTen;
                }
                else
                {
                    var result = MessageBox.Show(
                        $"⚠ Không tìm thấy khách hàng có số điện thoại \"{sdt}\"\n\n" +
                        $"Bạn có muốn thêm khách hàng mới không?",
                        "Không tìm thấy khách hàng",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var khController = new KhachHangController();
                        var themKHForm = new ThemKhachHangForm2(khController, kh: null, soDienThoaiMacDinh: sdt);

                        if (themKHForm.ShowDialog() == DialogResult.OK)
                        {
                            var khMoi = khRepo.GetBySDT(sdt);
                            if (khMoi != null)
                            {
                                txtMaKH.Text = khMoi.MaKH;
                                txtTenKH.Text = khMoi.HoTen;
                                MessageBox.Show($"✓ Đã thêm khách hàng mới thành công!\n\n" +
                                                $"Họ tên: {khMoi.HoTen}\n" +
                                                $"Mã KH: {khMoi.MaKH}",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"UC_POS.btnLoc_Click Error: {ex.Message}");
                MessageBox.Show($"Lỗi khi tìm khách hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonSP_Click(object sender, EventArgs e)
        {
            try
            {
                var chonSPForm = new ChonSanPhamForm();
                if (chonSPForm.ShowDialog() == DialogResult.OK && chonSPForm.SelectedProduct != null)
                {
                    var sp = chonSPForm.SelectedProduct;

                    // Hiển thị thông tin sản phẩm đã chọn
                    lblMaSPValue.Text = sp.MaSP;
                    lblTenSP.Text = $"Tên: {sp.TenSP}";

                    decimal phanTramGiam = GetActiveDiscountForProduct(sp.MaSP);
                    decimal giaSauGiam = sp.GiaBan * (1 - phanTramGiam / 100);

                    if (phanTramGiam > 0)
                    {
                        lblKhuyenMaiValue.Text = $"🎉 Giảm {phanTramGiam}%";
                        lblKhuyenMaiValue.ForeColor = Color.FromArgb(220, 53, 69); // Đỏ
                        lblGiaSP.Text = $"{sp.GiaBan:N0} ₫ → {giaSauGiam:N0} ₫";
                        lblGiaSP.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblKhuyenMaiValue.Text = "Không có";
                        lblKhuyenMaiValue.ForeColor = Color.Gray;
                        lblGiaSP.Text = $"{sp.GiaBan:N0} ₫";
                        lblGiaSP.ForeColor = Color.Green;
                    }

                    LoadProductImage(sp.AnhChinh);

                    numQty.Focus();
                    numQty.Select(0, numQty.Text.Length);
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"UC_POS.btnChonSP_Click Error: {ex.Message}");
                MessageBox.Show($"Lỗi khi chọn sản phẩm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lấy % giảm giá từ chương trình khuyến mãi đang hoạt động cho sản phẩm
        /// </summary>
        private decimal GetActiveDiscountForProduct(string maSP)
        {
            try
            {
                var ctggRepo = new ChiTietGiamGiaRepository();

                string query = @"
                    SELECT TOP 1 ctgg.PhanTramGiam
                    FROM ChiTietGiamGia ctgg
                    INNER JOIN ChuongTrinhGiamGia ctkm ON ctgg.MaCTGG = ctkm.MaCTGG
                    WHERE ctgg.MaSP = @MaSP
                        AND ctkm.TrangThai = 1
                        AND GETDATE() BETWEEN ctkm.NgayBatDau AND ctkm.NgayKetThuc
                    ORDER BY ctgg.PhanTramGiam DESC";

                var param = new Microsoft.Data.SqlClient.SqlParameter("@MaSP", maSP);
                var dt = ctggRepo.ExecuteQuery(query, param);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToDecimal(dt.Rows[0]["PhanTramGiam"]);
                }

                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log($"GetActiveDiscountForProduct Error: {ex.Message}");
                return 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var maSP = lblMaSPValue.Text.Trim();
            int qty = (int)numQty.Value;

            if (string.IsNullOrWhiteSpace(maSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnChonSP.Focus();
                return;
            }

            var sanPhamRepo = new SanPhamRepository();
            var sp = sanPhamRepo.GetById(maSP);

            if (sp != null)
            {
                var cart = _controller.GetCart();
                var existingItem = cart?.FirstOrDefault(x => x.MaSP == maSP);
                int currentQtyInCart = existingItem?.SoLuong ?? 0;
                int totalQty = currentQtyInCart + qty;

                if (sp.SoLuongTon < totalQty)
                {
                    MessageBox.Show($"Sản phẩm '{sp.TenSP}' chỉ còn {sp.SoLuongTon} trong kho!\n" +
                        $"Bạn đã có {currentQtyInCart} trong giỏ.\n" +
                        $"Không đủ số lượng để thêm {qty} nữa.",
                        "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (sp.SoLuongTon <= 10)
                {
                    var result = MessageBox.Show($"⚠️ Sản phẩm '{sp.TenSP}' sắp hết hàng!\n" +
                        $"Tồn kho: {sp.SoLuongTon}\n\n" +
                        $"Bạn có muốn tiếp tục thêm vào giỏ không?",
                        "Cảnh báo sắp hết hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        ClearProductSelection();
                        return;
                    }
                }
            }

            var (ok, msg) = _controller.AddProduct(maSP, qty);
            if (!ok)
            {
                MessageBox.Show(msg, "Không thể thêm sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                decimal phanTramGiam = GetActiveDiscountForProduct(maSP);
                if (phanTramGiam > 0)
                {
                    _controller.ApplyDiscountToProduct(maSP, phanTramGiam);
                }

                RefreshCartGrid();

                if (sp != null)
                {
                    string discountMsg = phanTramGiam > 0 ? $" (Giảm {phanTramGiam}%)" : "";
                    MessageBox.Show($"✓ Đã thêm {qty} x '{sp.TenSP}' vào giỏ hàng{discountMsg}\n" +
                        $"Tồn kho hiện tại: {sp.SoLuongTon}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            ClearProductSelection();
        }

        private void ClearProductSelection()
        {
            lblMaSPValue.Text = "";
            lblTenSP.Text = "";
            lblGiaSP.Text = "";
            lblKhuyenMaiValue.Text = "0%";
            lblKhuyenMaiValue.ForeColor = Color.Gray;
            numQty.Value = 1;
            picSanPham.Image = null;
            btnChonSP.Focus();
        }

        /// <summary>
        /// Load và hiển thị ảnh sản phẩm từ URL hoặc đường dẫn
        /// </summary>
        private async void LoadProductImage(string? imageUrl)
        {
            try
            {
                if (picSanPham.Image != null)
                {
                    picSanPham.Image.Dispose();
                    picSanPham.Image = null;
                }

                if (string.IsNullOrWhiteSpace(imageUrl))
                {
                    picSanPham.Image = Properties.Resources.image_placeholder;
                    return;
                }

                if (imageUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    imageUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(10);

                        try
                        {
                            byte[] imageBytes = await httpClient.GetByteArrayAsync(imageUrl);
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                using (var tempImage = Image.FromStream(ms))
                                {
                                    picSanPham.Image = new Bitmap(tempImage);
                                }
                            }
                        }
                        catch
                        {
                            picSanPham.Image = Properties.Resources.image_placeholder;
                        }
                    }
                }
                else
                {
                    string imagePath;

                    if (Path.IsPathRooted(imageUrl))
                    {
                        imagePath = imageUrl;
                    }
                    else
                    {
                        imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "AnhSanPham", imageUrl);
                    }

                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            using (var fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                            using (var tempImage = Image.FromStream(fileStream))
                            {
                                picSanPham.Image = new Bitmap(tempImage);
                            }
                        }
                        catch
                        {
                            picSanPham.Image = Properties.Resources.image_placeholder;
                        }
                    }
                    else
                    {
                        Logger.Log($"UC_POS.LoadProductImage: File not found - {imagePath}");
                        picSanPham.Image = Properties.Resources.image_placeholder;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"UC_POS.LoadProductImage Error: {ex.Message} - URL: {imageUrl}");
                picSanPham.Image = Properties.Resources.image_placeholder;
            }
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

                if (dgvCart.Columns.Count == 0)
                    SetupCartColumns();

                dgvCart.DataSource = null;
                dgvCart.DataSource = cart;

                decimal total = cart.Sum(i => i.ThanhTien);
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

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            SaveOrCheckout();
        }

        private void SaveOrCheckout()
        {
            var cart = _controller.GetCart();
            if (cart == null || cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống! Vui lòng thêm sản phẩm trước khi thanh toán.",
                    "Giỏ hàng trống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = txtMaKH.Text.Trim();
            string maNV = txtMaNV.Text.Trim();

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            if (cboPhuongThucTT.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhuongThucTT.Focus();
                return;
            }

            string phuongThucTT = cboPhuongThucTT.SelectedItem?.ToString() ?? "";

            decimal tongTien = cart.Sum(i => (i.DonGia - i.GiamGiaSP) * i.SoLuong);

            string confirmMsg = $"Xác nhận thanh toán?\n\nTổng tiền: {tongTien:N0} ₫\nSố sản phẩm: {cart.Count}\nKhách hàng: {(string.IsNullOrEmpty(maKH) ? "Khách lẻ" : maKH)}\nNhân viên: {maNV}\nPhương thức: {phuongThucTT}";

            var confirm = MessageBox.Show(confirmMsg, "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            var (ok, res) = _controller.Checkout(maKH, maNV, phuongThucTT);

            if (!ok)
            {
                MessageBox.Show($"❌ {res}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string successMsg = $"✓ Thanh toán thành công!\n\nMã HĐ: {res}\nTổng tiền: {tongTien:N0} ₫";

            MessageBox.Show(successMsg, "Thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            var printResult = MessageBox.Show(
                "Bạn có muốn in hóa đơn không?",
                "In hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (printResult == DialogResult.Yes)
            {
                try
                {
                    var printService = new InvoicePrintService();
                    printService.PrintInvoice(res);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi in hóa đơn: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.Log($"UC_POS PrintInvoice Error: {ex.Message}");
                }
            }

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
            txtTenKH.Clear();
            txtSDT.Clear();
            ClearProductSelection();
            cboPhuongThucTT.SelectedIndex = -1;
            btnChonSP.Focus();
        }

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