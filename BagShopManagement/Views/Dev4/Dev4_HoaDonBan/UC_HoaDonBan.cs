using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev4.Dev4_HoaDonBan
{
    public partial class UC_HoaDonBan : UserControl
    {
        private readonly HoaDonBanController _controller;

        public UC_HoaDonBan()
        {
            InitializeComponent();

            var hoaDonRepo = new HoaDonBanRepository();
            var sanPhamRepo = new SanPhamRepository();
            var hoaDonService = new HoaDonBanService(hoaDonRepo);
            var tonKhoService = new TonKhoService(sanPhamRepo);

            _controller = new HoaDonBanController(hoaDonService, tonKhoService);
        }

        private void UC_HoaDonBan_Load(object sender, EventArgs e)
        {
            LoadHoaDonBanList();
            SetupDataGridView();
            SetupComboBoxes();
        }

        private void SetupDataGridView()
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.Columns.Clear();

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã HĐ",
                DataPropertyName = "MaHDB",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 12F,
                Name = "MaHDB"
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã KH",
                DataPropertyName = "MaKH",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "MaKH"
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã NV",
                DataPropertyName = "MaNV",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "MaNV"
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày bán",
                DataPropertyName = "NgayBan",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15F,
                Name = "NgayBan"
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tổng tiền",
                DataPropertyName = "TongTien",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 12F,
                Name = "TongTien",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "PTTT",
                DataPropertyName = "PhuongThucTT",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "PhuongThucTT"
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "TrangThai"
            });

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "TrangThaiHD",
                DataPropertyName = "TrangThaiHD",
                Width = 0,
                Name = "TrangThaiHD",
                Visible = false
            });
        }

        private void SetupComboBoxes()
        {
            // Trạng thái: 2=Hoàn thành, 3=Hủy
            cmbTrangThai.Items.Add("Tất cả");
            cmbTrangThai.Items.Add("Hoàn thành (2)");
            cmbTrangThai.Items.Add("Hủy (3)");
            cmbTrangThai.SelectedIndex = 0;

            dtpFromDate.Value = DateTime.Now.AddDays(-30); // 30 ngày gần nhất
            dtpToDate.Value = DateTime.Now;
        }

        private void LoadHoaDonBanList()
        {
            try
            {
                DateTime? fromDate = chkFilterDate.Checked ? dtpFromDate.Value.Date : null;
                DateTime? toDate = chkFilterDate.Checked ? dtpToDate.Value.Date : null;
                string? maNV = chkFilterNV.Checked && !string.IsNullOrWhiteSpace(txtMaNV.Text) ? txtMaNV.Text.Trim() : null;
                byte? trangThai = null;

                if (chkFilterTrangThai.Checked && cmbTrangThai.SelectedIndex > 0)
                {
                    trangThai = (byte)(cmbTrangThai.SelectedIndex + 1); // 2 hoặc 3 (index 1 = Hoàn thành (2), index 2 = Hủy (3))
                }

                var list = _controller.Filter(fromDate, toDate, maNV, trangThai);

                // Tạo dữ liệu hiển thị với tên trạng thái
                var displayList = list.Select(hd => new
                {
                    hd.MaHDB,
                    hd.MaKH,
                    hd.MaNV,
                    NgayBan = hd.NgayBan.ToString("dd/MM/yyyy HH:mm"),
                    TongTien = hd.TongTien,
                    PhuongThucTT = hd.PhuongThucTT ?? "",
                    TrangThai = GetTrangThaiText(hd.TrangThaiHD),
                    TrangThaiHD = hd.TrangThaiHD
                }).ToList();

                dgvHoaDon.DataSource = displayList;

                lblTotal.Text = $"Tổng: {list.Count} hóa đơn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTrangThaiText(byte trangThai)
        {
            return trangThai switch
            {
                2 => "Hoàn thành",
                3 => "Hủy",
                _ => "Không xác định"
            };
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadHoaDonBanList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            chkFilterDate.Checked = false;
            chkFilterNV.Checked = false;
            chkFilterTrangThai.Checked = false;
            txtMaNV.Clear();
            cmbTrangThai.SelectedIndex = 0;
            dtpFromDate.Value = DateTime.Now.AddDays(-30);
            dtpToDate.Value = DateTime.Now;
            LoadHoaDonBanList();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvHoaDon.SelectedRows[0];
            var maHDB = selectedRow.Cells["MaHDB"].Value?.ToString();

            if (string.IsNullOrEmpty(maHDB))
            {
                MessageBox.Show("Không thể xác định mã hóa đơn.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var detailForm = new ChiTietHoaDonForm(maHDB, _controller);
            detailForm.ShowDialog();
            LoadHoaDonBanList(); // Refresh sau khi đóng form chi tiết
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để hủy.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvHoaDon.SelectedRows[0];
            var maHDB = selectedRow.Cells["MaHDB"].Value?.ToString();
            var trangThai = Convert.ToByte(selectedRow.Cells["TrangThaiHD"].Value);

            if (string.IsNullOrEmpty(maHDB))
            {
                MessageBox.Show("Không thể xác định mã hóa đơn.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (trangThai == 3)
            {
                MessageBox.Show("Hóa đơn này đã bị hủy rồi.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc muốn hủy hóa đơn {maHDB}?\n" +
                (trangThai == 2 ? "Tồn kho sẽ được hoàn trả tự động." : ""),
                "Xác nhận hủy hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.CancelWithRestoreStock(maHDB);
                    MessageBox.Show("Hủy hóa đơn thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoaDonBanList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy hóa đơn: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvHoaDon.SelectedRows[0];
            var maHDB = selectedRow.Cells["MaHDB"].Value?.ToString();
            var trangThai = Convert.ToByte(selectedRow.Cells["TrangThaiHD"].Value);

            if (string.IsNullOrEmpty(maHDB))
            {
                MessageBox.Show("Không thể xác định mã hóa đơn.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Chỉ cho phép xóa hóa đơn đã hủy (TrangThaiHD = 3)
            if (trangThai != 3)
            {
                MessageBox.Show("Chỉ có thể xóa hóa đơn đã hủy.\nVui lòng hủy hóa đơn trước khi xóa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc muốn XÓA VĨNH VIỄN hóa đơn {maHDB}?\n" +
                "Hành động này không thể hoàn tác!",
                "Xác nhận xóa hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.Delete(maHDB);
                    MessageBox.Show("Xóa hóa đơn thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoaDonBanList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblToDate_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để in.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvHoaDon.SelectedRows[0];
            var maHDB = selectedRow.Cells["MaHDB"].Value?.ToString();
            var trangThai = Convert.ToByte(selectedRow.Cells["TrangThaiHD"].Value);

            if (string.IsNullOrEmpty(maHDB))
            {
                MessageBox.Show("Không thể xác định mã hóa đơn.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Chỉ cho phép in hóa đơn đã hoàn thành (TrangThaiHD = 2)
            if (trangThai != 2)
            {
                MessageBox.Show("Chỉ có thể in hóa đơn đã hoàn thành (đã thanh toán).",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var printService = new InvoicePrintService();
                printService.PrintInvoice(maHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
