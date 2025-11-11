using BagShopManagement.Controllers;
using BagShopManagement.DTOs;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev4.Dev4_HoaDonBan
{
    public partial class HoaDonBanEditForm : Form
    {
        private readonly string _maHDB;
        private readonly HoaDonBanController _controller;
        private readonly HoaDonBanRepository _hoaDonRepo;
        private readonly SanPhamRepository _sanPhamRepo;
        private readonly List<CartItem> _cart = new List<CartItem>();

        public HoaDonBanEditForm(string maHDB, HoaDonBanController controller)
        {
            InitializeComponent();
            _maHDB = maHDB;
            _controller = controller;
            _hoaDonRepo = new HoaDonBanRepository();
            _sanPhamRepo = new SanPhamRepository();
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

                // Kiểm tra trạng thái - chỉ cho phép sửa hóa đơn tạm
                if (hoaDon.TrangThaiHD != 1)
                {
                    MessageBox.Show("Chỉ có thể sửa hóa đơn tạm (chưa thanh toán).",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // Load thông tin hóa đơn
                txtMaKH.Text = hoaDon.MaKH ?? "";
                txtMaNV.Text = hoaDon.MaNV;
                txtGhiChu.Text = hoaDon.GhiChu ?? "";
                txtPhuongThucTT.Text = hoaDon.PhuongThucTT ?? "";

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var maSP = txtMaSP.Text.Trim();
            int qty = (int)numQty.Value;

            if (string.IsNullOrWhiteSpace(maSP))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm!", "Thiếu thông tin",
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
            txtMaSP.Clear();
            numQty.Value = 1;
            txtMaSP.Focus();
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

            if (string.IsNullOrEmpty(maSP))
                return;

            var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
            if (item != null)
            {
                _cart.Remove(item);
                RefreshCartGrid();
            }
        }

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            decimal percent = numDiscountPercent.Value;
            if (percent <= 0)
            {
                MessageBox.Show("Vui lòng nhập phần trăm giảm giá hợp lệ (> 0).",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var item in _cart)
            {
                item.GiamGiaSP = Math.Round(item.DonGia * (percent / 100m), 2);
            }

            RefreshCartGrid();
        }

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

            try
            {
                var hoaDon = _hoaDonRepo.GetByMaHDB(_maHDB);
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật thông tin hóa đơn - Validate MaKH
                hoaDon.MaKH = ValidateMaKH(txtMaKH.Text.Trim());
                hoaDon.MaNV = txtMaNV.Text.Trim();
                hoaDon.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();
                hoaDon.PhuongThucTT = string.IsNullOrWhiteSpace(txtPhuongThucTT.Text) ? null : txtPhuongThucTT.Text.Trim();
                hoaDon.TongTien = _cart.Sum(i => i.ThanhTien);

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
            // Nếu rỗng hoặc null, trả về null (khách lẻ)
            if (string.IsNullOrWhiteSpace(maKH))
                return null;

            //// Kiểm tra MaKH có tồn tại trong bảng KhachHang không
            //try
            //{
            //    using var conn = DatabaseConfig.CreateConnection();
            //    conn.Open();
            //    using var cmd = new SqlCommand("SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH", conn);
            //    cmd.Parameters.Add(new SqlParameter("@MaKH", maKH.Trim()));

            //    var result = cmd.ExecuteScalar();
            //    if (result != null)
            //    {
            //        int count = Convert.ToInt32(result);
            //        if (count > 0)
            //        {
            //            // MaKH tồn tại, trả về giá trị
            //            return maKH.Trim();
            //        }
            //    }

            //    // MaKH không tồn tại, trả về null (xử lý như khách lẻ)
            //    MessageBox.Show($"Mã khách hàng '{maKH}' không tồn tại. Hệ thống sẽ xử lý như khách lẻ.",
            //        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return null;
            //}
            //catch (Exception ex)
            //{
            //    // Nếu có lỗi khi check, trả về null để tránh lỗi foreign key
            //    MessageBox.Show($"Lỗi khi kiểm tra mã khách hàng: {ex.Message}. Hệ thống sẽ xử lý như khách lẻ.",
            //        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return null;
            //}
            return null;
        }
    }
}