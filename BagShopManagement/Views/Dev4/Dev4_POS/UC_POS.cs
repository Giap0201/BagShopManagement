using BagShopManagement.Controllers;
using BagShopManagement.DataAccess;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Utils;
using BagShopManagement.Views.Dev3; // Thêm để sử dụng ThemKhachHangForm2
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

            // Tự động điền mã nhân viên từ UserContext sau khi đăng nhập
            if (!string.IsNullOrEmpty(UserContext.MaNV))
            {
                txtMaNV.Text = UserContext.MaNV;
                txtMaNV.ReadOnly = true; // Không cho sửa mã NV
            }
        }

        /// <summary>
        /// Thiết lập các cột cho DataGridView giỏ hàng
        /// </summary>
        private void SetupCartColumns()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

            // Cấu hình DataGridView để hiển thị tốt hơn - các cột tự động fill hết không gian
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

                // Tìm khách hàng theo số điện thoại
                var khRepo = new KhachHangRepository();
                var khachHang = khRepo.GetBySDT(sdt);

                if (khachHang != null)
                {
                    // Khách hàng đã tồn tại - hiển thị thông tin
                    txtMaKH.Text = khachHang.MaKH;
                    txtTenKH.Text = khachHang.HoTen;
                    MessageBox.Show($"Đã tìm thấy khách hàng:\n{khachHang.HoTen}",
                        "Thông tin khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Khách hàng chưa tồn tại - hiển thị form thêm mới (Dev3) với SĐT đã nhập
                    var khController = new KhachHangController();
                    var themKHForm = new ThemKhachHangForm2(khController, null, sdt);

                    if (themKHForm.ShowDialog() == DialogResult.OK)
                    {
                        // Sau khi thêm thành công, tìm lại khách hàng theo SĐT
                        var khMoi = khRepo.GetBySDT(sdt);
                        if (khMoi != null)
                        {
                            txtMaKH.Text = khMoi.MaKH;
                            txtTenKH.Text = khMoi.HoTen;
                            MessageBox.Show($"Đã thêm khách hàng mới thành công!\n{khMoi.HoTen}",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    // Tự động lấy % giảm giá từ chương trình khuyến mãi đang active
                    decimal phanTramGiam = GetActiveDiscountForProduct(sp.MaSP);
                    decimal giaSauGiam = sp.GiaBan * (1 - phanTramGiam / 100);

                    // ✅ Hiển thị % khuyến mãi trong label riêng
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

                    // Hiển thị ảnh sản phẩm
                    LoadProductImage(sp.AnhChinh);

                    // Focus vào số lượng
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

                // 🔍 DEBUG: Xem TẤT CẢ khuyến mãi cho sản phẩm (không lọc gì)
                string debugQuery = @"
                    SELECT ctgg.MaSP, ctgg.PhanTramGiam, ctkm.MaCTGG, ctkm.TenChuongTrinh,
                           ctkm.TrangThai, ctkm.NgayBatDau, ctkm.NgayKetThuc, GETDATE() as NgayHienTai
                    FROM ChiTietGiamGia ctgg
                    INNER JOIN ChuongTrinhGiamGia ctkm ON ctgg.MaCTGG = ctkm.MaCTGG
                    WHERE ctgg.MaSP = @MaSP";

                var debugParam = new Microsoft.Data.SqlClient.SqlParameter("@MaSP", maSP);
                var debugDt = ctggRepo.ExecuteQuery(debugQuery, debugParam);

                Logger.Log($"=== DEBUG: Khuyến mãi cho {maSP} ===");
                if (debugDt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow r in debugDt.Rows)
                    {
                        Logger.Log($"  MaCTGG: {r["MaCTGG"]}, Tên: {r["TenChuongTrinh"]}, " +
                            $"TrangThai: {r["TrangThai"]}, % Giảm: {r["PhanTramGiam"]}, " +
                            $"Từ {r["NgayBatDau"]:dd/MM/yyyy} đến {r["NgayKetThuc"]:dd/MM/yyyy}, " +
                            $"Hiện tại: {r["NgayHienTai"]:dd/MM/yyyy HH:mm:ss}");
                    }
                }
                else
                {
                    Logger.Log($"  => KHÔNG có bất kỳ khuyến mãi nào cho {maSP} trong DB!");
                }

                // Query thực tế - lấy % giảm cao nhất
                // ⚠️ TẠM BỎ kiểm tra ngày để test (uncomment dòng dưới khi deploy thật)
                string query = @"
                    SELECT TOP 1 ctgg.PhanTramGiam, ctkm.MaCTGG, ctkm.TenChuongTrinh
                    FROM ChiTietGiamGia ctgg
                    INNER JOIN ChuongTrinhGiamGia ctkm ON ctgg.MaCTGG = ctkm.MaCTGG
                    WHERE ctgg.MaSP = @MaSP
                        AND ctkm.TrangThai = 1
                        -- AND GETDATE() BETWEEN ctkm.NgayBatDau AND ctkm.NgayKetThuc  -- TẠM BỎ để test
                    ORDER BY ctgg.PhanTramGiam DESC";

                var param = new Microsoft.Data.SqlClient.SqlParameter("@MaSP", maSP);
                var dt = ctggRepo.ExecuteQuery(query, param);

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    decimal discount = Convert.ToDecimal(row["PhanTramGiam"]);
                    string? tenCTKM = row["TenChuongTrinh"]?.ToString();

                    Logger.Log($"✓ Áp dụng CTKM '{tenCTKM}': Giảm {discount}% cho {maSP}");
                    return discount;
                }
                else
                {
                    Logger.Log($"=> Không có CTKM ACTIVE (TrangThai=1 + ngày hợp lệ) cho {maSP}");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"GetActiveDiscountForProduct Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
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

            // Kiểm tra tồn kho trước khi thêm
            var sanPhamRepo = new SanPhamRepository();
            var sp = sanPhamRepo.GetById(maSP);

            if (sp != null)
            {
                // Kiểm tra tồn kho hiện tại trong giỏ
                var cart = _controller.GetCart();
                var existingItem = cart?.FirstOrDefault(x => x.MaSP == maSP);
                int currentQtyInCart = existingItem?.SoLuong ?? 0;
                int totalQty = currentQtyInCart + qty;

                // Hiển thị thông tin tồn kho
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
                    // Cảnh báo sắp hết hàng
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
                // Tự động áp dụng giảm giá từ CTKM
                decimal phanTramGiam = GetActiveDiscountForProduct(maSP);
                if (phanTramGiam > 0)
                {
                    _controller.ApplyDiscountToProduct(maSP, phanTramGiam);
                }

                RefreshCartGrid();

                // Hiển thị thông báo thành công với tồn kho còn lại
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
                // Xóa ảnh cũ
                if (picSanPham.Image != null)
                {
                    picSanPham.Image.Dispose();
                    picSanPham.Image = null;
                }

                // Nếu không có URL thì dùng placeholder
                if (string.IsNullOrWhiteSpace(imageUrl))
                {
                    picSanPham.Image = Properties.Resources.image_placeholder;
                    return;
                }

                // Kiểm tra nếu là URL (http/https)
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

            // Validate phương thức thanh toán (bắt buộc)
            if (cboPhuongThucTT.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhuongThucTT.Focus();
                return;
            }

            string phuongThucTT = cboPhuongThucTT.SelectedItem?.ToString() ?? "";

            // Tính tổng tiền
            decimal tongTien = cart.Sum(i => (i.DonGia - i.GiamGiaSP) * i.SoLuong);

            // Xác nhận trước khi lưu/thanh toán
            string confirmMsg = saveDraft
                ? $"Lưu tạm hóa đơn?\n\nTổng tiền: {tongTien:N0} ₫\nSố sản phẩm: {cart.Count}\nNhân viên: {maNV}\nPhương thức: {phuongThucTT}"
                : $"Xác nhận thanh toán?\n\nTổng tiền: {tongTien:N0} ₫\nSố sản phẩm: {cart.Count}\nKhách hàng: {(string.IsNullOrEmpty(maKH) ? "Khách lẻ" : maKH)}\nNhân viên: {maNV}\nPhương thức: {phuongThucTT}";

            var confirm = MessageBox.Show(confirmMsg,
                saveDraft ? "Xác nhận lưu tạm" : "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            // Thực hiện checkout với phương thức thanh toán
            var (ok, res) = _controller.Checkout(maKH, maNV, saveDraft, phuongThucTT);

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
            txtTenKH.Clear();
            txtSDT.Clear();
            ClearProductSelection();
            cboPhuongThucTT.SelectedIndex = -1; // Reset phương thức thanh toán
            btnChonSP.Focus();
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

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblGiaSPLabel_Click(object sender, EventArgs e)
        {

        }

        private void lblTenSP_Click(object sender, EventArgs e)
        {

        }

        private void lblQty_Click(object sender, EventArgs e)
        {

        }
    }
}