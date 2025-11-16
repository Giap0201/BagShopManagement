using BagShopManagement.Controllers;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev4.Dev4_HoaDonBan
{
    public partial class ChiTietHoaDonForm : Form
    {
        private readonly string _maHDB;
        private readonly HoaDonBanController _controller;
        private readonly HoaDonBanRepository _hoaDonRepo;
        private readonly SanPhamRepository _sanPhamRepo;

        public ChiTietHoaDonForm(string maHDB, HoaDonBanController controller)
        {
            InitializeComponent();
            _maHDB = maHDB;
            _controller = controller;
            _hoaDonRepo = new HoaDonBanRepository();
            _sanPhamRepo = new SanPhamRepository();
        }

        private void ChiTietHoaDonForm_Load(object sender, EventArgs e)
        {
            LoadHoaDonInfo();
            LoadChiTiet();
            SetupDataGridView();
        }

        private void LoadHoaDonInfo()
        {
            try
            {
                var hoaDon = _hoaDonRepo.GetByMaHDB(_maHDB);
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblMaHDB.Text = $"Mã HĐ: {hoaDon.MaHDB}";
                lblMaKH.Text = $"Mã KH: {hoaDon.MaKH ?? "Khách lẻ"}";
                lblMaNV.Text = $"Mã NV: {hoaDon.MaNV}";
                lblNgayBan.Text = $"Ngày bán: {hoaDon.NgayBan:dd/MM/yyyy HH:mm}";
                lblTongTien.Text = $"Tổng tiền: {hoaDon.TongTien:N0} ₫";
                lblPTTT.Text = $"Phương thức TT: {hoaDon.PhuongThucTT ?? "N/A"}";

                string trangThai = hoaDon.TrangThaiHD switch
                {
                    1 => "Tạm",
                    2 => "Hoàn thành",
                    3 => "Hủy",
                    _ => "Không xác định"
                };
                lblTrangThai.Text = $"Trạng thái: {trangThai}";

                if (!string.IsNullOrWhiteSpace(hoaDon.GhiChu))
                {
                    txtGhiChu.Text = hoaDon.GhiChu;
                    txtGhiChu.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin hóa đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTiet()
        {
            try
            {
                var chiTiets = _controller.GetChiTiet(_maHDB);

                // Lấy thông tin sản phẩm để hiển thị tên
                var displayList = chiTiets.Select(ct =>
                {
                    var sp = _sanPhamRepo.GetById(ct.MaSP);
                    return new
                    {
                        ct.MaSP,
                        TenSP = sp?.TenSP ?? "N/A",
                        ct.SoLuong,
                        ct.DonGia,
                        ct.GiamGiaSP,
                        ThanhTien = (ct.DonGia - ct.GiamGiaSP) * ct.SoLuong
                    };
                }).ToList();

                dgvChiTiet.DataSource = displayList;

                decimal total = displayList.Sum(x => x.ThanhTien);
                lblTongTienChiTiet.Text = $"Tổng thành tiền: {total:N0} ₫";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.Columns.Clear();

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã SP",
                DataPropertyName = "MaSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "MaSP"
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30F,
                Name = "TenSP"
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 8F,
                Name = "SoLuong",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 12F,
                Name = "DonGia",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giảm giá/SP",
                DataPropertyName = "GiamGiaSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "GiamGiaSP",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 20F,
                Name = "ThanhTien",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}