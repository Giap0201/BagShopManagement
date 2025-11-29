using BagShopManagement.Controllers;
using BagShopManagement.DTOs;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Views.Dev4.Dev4_POS;
using Microsoft.Data.SqlClient;

namespace BagShopManagement.Views.Dev4.Dev4_HoaDonBan
{
    public partial class HoaDonBanEditForm : Form
    {
        private readonly string _maHDB;
        private readonly HoaDonBanController _controller;
        private readonly HoaDonBanRepository _hoaDonRepo;
        private readonly SanPhamRepository _sanPhamRepo;
        private readonly KhachHangRepository _khachHangRepo;
        private readonly TonKhoService _tonKhoService;
        private readonly List<CartItem> _cart = new List<CartItem>();
        private byte _originalTrangThai; // Lưu trạng thái ban đầu

        public HoaDonBanEditForm(string maHDB, HoaDonBanController controller)
        {
            InitializeComponent();
            _maHDB = maHDB;
            _controller = controller;
            _hoaDonRepo = new HoaDonBanRepository();
            _sanPhamRepo = new SanPhamRepository();
            _khachHangRepo = new KhachHangRepository();
            _tonKhoService = new TonKhoService(_sanPhamRepo);
        }

        private void HoaDonBanEditForm_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
            SetupDataGridView();
        }

        private void LoadHoaDon()
        {
            try
            {
                var hoaDon = _hoaDonRepo.GetByMaHDB(_maHDB);
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // Load thông tin hóa đơn
                txtMaKH.Text = hoaDon.MaKH ?? "";
                txtMaNV.Text = hoaDon.MaNV;
                txtGhiChu.Text = hoaDon.GhiChu ?? "";
                txtPhuongThucTT.Text = hoaDon.PhuongThucTT ?? "";

                // Load trạng thái và LƯU TRẠNG THÁI BAN ĐẦU
                _originalTrangThai = hoaDon.TrangThaiHD;

                switch (hoaDon.TrangThaiHD)
                {
                    case 1:
                        cboTrangThai.SelectedIndex = 0; // Nháp
                        break;

                    case 2:
                        cboTrangThai.SelectedIndex = 1; // Đã thanh toán
                        break;

                    case 3:
                        cboTrangThai.SelectedIndex = 2; // Đã hủy
                        break;

                    default:
                        cboTrangThai.SelectedIndex = 0;
                        break;
                }

                // Load chi tiết vào giỏ hàng
                var chiTiets = _controller.GetChiTiet(_maHDB);
                _cart.Clear();

                foreach (var ct in chiTiets)
                {
                    var sp = _sanPhamRepo.GetById(ct.MaSP);
                    _cart.Add(new CartItem
                    {
                        MaSP = ct.MaSP,
                        TenSP = sp?.TenSP ?? "N/A",
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        GiamGiaSP = ct.GiamGiaSP
                    });
                }

                RefreshCartGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.Columns.Clear();

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã SP",
                DataPropertyName = "MaSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "MaSP",
                ReadOnly = true
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30F,
                Name = "TenSP",
                ReadOnly = true
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 8F,
                Name = "SoLuong",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 12F,
                Name = "DonGia",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" },
                ReadOnly = true
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giảm/SP",
                DataPropertyName = "GiamGiaSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "GiamGiaSP",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" },
                ReadOnly = true
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 20F,
                Name = "ThanhTien",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" },
                ReadOnly = true
            });
        }

        private void RefreshCartGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart;

            decimal total = _cart.Sum(i => i.ThanhTien);
            lblTotal.Text = $"Tổng: {total:N0} ₫";
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
                    lblTenSP.Text = sp.TenSP;
                    lblGiaSP.Text = $"{sp.GiaBan:N0} ₫";

                    // Focus vào số lượng
                    numQty.Focus();
                    numQty.Select(0, numQty.Text.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn sản phẩm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var maSP = lblMaSPValue.Text.Trim();
            int qty = (int)numQty.Value;

            if (string.IsNullOrWhiteSpace(maSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sp = _sanPhamRepo.GetById(maSP);
            if (sp == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existing = _cart.FirstOrDefault(x => x.MaSP == maSP);
            var totalQty = (existing?.SoLuong ?? 0) + qty;

            if (sp.SoLuongTon < totalQty)
            {
                MessageBox.Show($"Không đủ tồn kho. Tồn kho hiện tại: {sp.SoLuongTon}",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existing == null)
            {
                _cart.Add(new CartItem
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    SoLuong = qty,
                    DonGia = sp.GiaBan,
                    GiamGiaSP = 0m
                });
            }
            else
            {
                existing.SoLuong += qty;
            }

            RefreshCartGrid();
            ClearProductSelection();
            numQty.Value = 1;
        }

        private void ClearProductSelection()
        {
            lblMaSPValue.Text = "";
            lblTenSP.Text = "";
            lblGiaSP.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvCart.SelectedRows[0];
            var maSP = selectedRow.Cells["MaSP"].Value?.ToString();
            var tenSP = selectedRow.Cells["TenSP"].Value?.ToString();

            if (string.IsNullOrEmpty(maSP))
                return;

            // Xác nhận trước khi xóa
            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm '{tenSP}' khỏi giỏ hàng?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
            if (item != null)
            {
                _cart.Remove(item);
                RefreshCartGrid();
                MessageBox.Show("Đã xóa sản phẩm khỏi giỏ hàng!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //private void btnApplyDiscount_Click(object sender, EventArgs e)
        //{
        //    decimal percent = numDiscountPercent.Value;
        //    if (percent <= 0)
        //    {
        //        MessageBox.Show("Vui lòng nhập phần trăm giảm giá hợp lệ (> 0).",
        //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    foreach (var item in _cart)
        //    {
        //        item.GiamGiaSP = Math.Round(item.DonGia * (percent / 100m), 2);
        //    }

        //    RefreshCartGrid();
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng rỗng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Thiếu mã nhân viên.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi lưu
            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn lưu các thay đổi cho hóa đơn '{_maHDB}'?\n" +
                $"Tổng tiền: {_cart.Sum(i => i.ThanhTien):N0} ₫\n" +
                $"Số sản phẩm: {_cart.Count}",
                "Xác nhận lưu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                var hoaDon = _hoaDonRepo.GetByMaHDB(_maHDB);
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate trạng thái
                if (cboTrangThai.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái hóa đơn!", "Thiếu thông tin",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboTrangThai.Focus();
                    return;
                }

                // Cập nhật thông tin hóa đơn - Validate MaKH
                hoaDon.MaKH = ValidateMaKH(txtMaKH.Text.Trim());
                hoaDon.MaNV = txtMaNV.Text.Trim();
                hoaDon.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();
                hoaDon.PhuongThucTT = string.IsNullOrWhiteSpace(txtPhuongThucTT.Text) ? null : txtPhuongThucTT.Text.Trim();
                hoaDon.TongTien = _cart.Sum(i => i.ThanhTien);

                // Lấy trạng thái mới
                byte newTrangThai = (byte)(cboTrangThai.SelectedIndex + 1); // 1: Nháp, 2: Đã thanh toán, 3: Đã hủy

                // 🔑 LOGIC XỬ LÝ TỒN KHO KHI ĐỔI TRẠNG THÁI
                // Case 1: Nháp (1) → Hoàn thành (2): TRỪ TỒN KHO
                // Case 2: Hoàn thành (2) → Nháp (1): HOÀN TRẢ TỒN KHO (không nên xảy ra, nhưng xử lý để an toàn)
                // Case 3: Hoàn thành (2) → Hủy (3): HOÀN TRẢ TỒN KHO (xử lý ở nút Hủy, không ở đây)

                if (_originalTrangThai == 1 && newTrangThai == 2)
                {
                    // Đổi từ NHÁP → HOÀN THÀNH: Phải TRỪ TỒN KHO
                    foreach (var item in _cart)
                    {
                        bool success = _tonKhoService.DecreaseStock(item.MaSP, item.SoLuong);
                        if (!success)
                        {
                            MessageBox.Show(
                                $"Không đủ tồn kho cho sản phẩm {item.MaSP}!\n" +
                                $"Vui lòng kiểm tra lại số lượng.",
                                "Lỗi tồn kho",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else if (_originalTrangThai == 2 && newTrangThai == 1)
                {
                    // Đổi từ HOÀN THÀNH → NHÁP: Phải HOÀN TRẢ TỒN KHO
                    var confirmRevert = MessageBox.Show(
                        "⚠️ Bạn đang chuyển hóa đơn từ 'Hoàn thành' về 'Nháp'.\n\n" +
                        "Hệ thống sẽ HOÀN TRẢ tồn kho cho các sản phẩm.\n" +
                        "Bạn có chắc chắn muốn tiếp tục?",
                        "Xác nhận hoàn trả tồn kho",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmRevert != DialogResult.Yes)
                        return;

                    foreach (var item in _cart)
                    {
                        _tonKhoService.IncreaseStock(item.MaSP, item.SoLuong);
                    }
                }

                // Cập nhật trạng thái
                hoaDon.TrangThaiHD = newTrangThai;

                // Chuyển đổi CartItem sang ChiTietHoaDonBan
                var chiTiets = _cart.Select(i => new ChiTietHoaDonBan
                {
                    MaHDB = _maHDB,
                    MaSP = i.MaSP,
                    SoLuong = i.SoLuong,
                    DonGia = i.DonGia,
                    GiamGiaSP = i.GiamGiaSP
                }).ToList();

                var dto = new HoaDonBanDTO
                {
                    HoaDon = hoaDon,
                    ChiTiets = chiTiets
                };

                _controller.Update(dto);

                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) // Số lượng
            {
                var row = dgvCart.Rows[e.RowIndex];
                var maSP = row.Cells["MaSP"].Value?.ToString();
                var newQty = Convert.ToInt32(row.Cells["SoLuong"].Value ?? 1);

                if (newQty < 1)
                {
                    MessageBox.Show("Số lượng phải >= 1", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    newQty = 1;
                }

                var sp = _sanPhamRepo.GetById(maSP ?? "");
                if (sp != null && sp.SoLuongTon < newQty)
                {
                    MessageBox.Show($"Không đủ tồn kho. Tồn kho: {sp.SoLuongTon}",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    newQty = Math.Min(newQty, sp.SoLuongTon);
                }

                var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
                if (item != null)
                {
                    item.SoLuong = newQty;
                    RefreshCartGrid();
                }
            }
        }

        /// <summary>
        /// Validate MaKH: nếu không rỗng nhưng không tồn tại trong DB, trả về null (khách lẻ)
        /// </summary>
        private string? ValidateMaKH(string? maKH)
        {
            // 1. Nếu rỗng hoặc null, trả về null (khách lẻ) - Giữ nguyên logic cũ
            if (string.IsNullOrWhiteSpace(maKH))
                return null;

            try
            {
                // 2. Gọi hàm GetKhachHang đã viết ở trên
                // Hàm này sẽ trả về chuỗi mã KH nếu tìm thấy, hoặc null nếu không thấy
                string? result = _khachHangRepo.GetKhachHang(maKH);

                if (result != null)
                {
                    // Tìm thấy -> Trả về mã đã trim
                    return result;
                }
                else
                {
                    // Không tìm thấy (result == null) -> Thông báo UI
                    MessageBox.Show($"Mã khách hàng '{maKH}' không tồn tại. Hệ thống sẽ xử lý như khách lẻ.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }
            catch (Exception ex)
            {
                // 3. Xử lý lỗi ngoại lệ (nếu hàm GetKhachHang ném lỗi)
                MessageBox.Show($"Lỗi khi kiểm tra mã khách hàng: {ex.Message}. Hệ thống sẽ xử lý như khách lẻ.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}