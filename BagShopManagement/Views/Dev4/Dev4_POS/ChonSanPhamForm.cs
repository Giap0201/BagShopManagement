using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev4
{
    public partial class ChonSanPhamForm : Form
    {
        private readonly SanPhamRepository _sanPhamRepo;
        private readonly LoaiTuiRepository _loaiTuiRepo;
        private readonly ThuongHieuRepository _thuongHieuRepo;
        private readonly ChatLieuRepository _chatLieuRepo;
        private readonly KichThuocRepository _kichThuocRepo;
        private List<SanPham> _allProducts;
        public SanPham? SelectedProduct { get; private set; }

        public ChonSanPhamForm()
        {
            InitializeComponent();
            _sanPhamRepo = new SanPhamRepository();
            _loaiTuiRepo = new LoaiTuiRepository();
            _thuongHieuRepo = new ThuongHieuRepository();
            _chatLieuRepo = new ChatLieuRepository();
            _kichThuocRepo = new KichThuocRepository();
            _allProducts = new List<SanPham>();
        }

        private void ChonSanPhamForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadSanPham();
        }

        private void SetupDataGridView()
        {
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.MultiSelect = false;
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowTemplate.Height = 60;
            dgvSanPham.Columns.Clear();

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã SP",
                DataPropertyName = "MaSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "MaSP"
            });

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25F,
                Name = "TenSP"
            });

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại túi",
                DataPropertyName = "TenLoaiTui",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 12F,
                Name = "TenLoaiTui"
            });

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thương hiệu",
                DataPropertyName = "TenThuongHieu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 13F,
                Name = "TenThuongHieu"
            });

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Chất liệu",
                DataPropertyName = "TenChatLieu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 12F,
                Name = "TenChatLieu"
            });

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Kích thước",
                DataPropertyName = "TenKichThuoc",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "TenKichThuoc"
            });

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giá bán",
                DataPropertyName = "GiaBan",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                Name = "GiaBan",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                }
            });

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tồn kho",
                DataPropertyName = "SoLuongTon",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 8F,
                Name = "SoLuongTon",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
        }

        private void LoadSanPham(string searchTerm = "")
        {
            try
            {
                _allProducts = _sanPhamRepo.GetAll();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    var search = searchTerm.Trim().ToLower();
                    _allProducts = _allProducts.Where(sp =>
                        sp.MaSP.ToLower().Contains(search) ||
                        sp.TenSP.ToLower().Contains(search)
                    ).ToList();
                }

                // Chỉ hiển thị sản phẩm còn tồn kho và join với các bảng
                var displayList = _allProducts
                    .Where(sp => sp.SoLuongTon > 0)
                    .Select(sp => new
                    {
                        sp.MaSP,
                        sp.TenSP,
                        TenLoaiTui = !string.IsNullOrEmpty(sp.MaLoaiTui)
                            ? _loaiTuiRepo.GetById(sp.MaLoaiTui)?.TenLoaiTui ?? "N/A"
                            : "N/A",
                        TenThuongHieu = !string.IsNullOrEmpty(sp.MaThuongHieu)
                            ? _thuongHieuRepo.GetById(sp.MaThuongHieu)?.TenThuongHieu ?? "N/A"
                            : "N/A",
                        TenChatLieu = !string.IsNullOrEmpty(sp.MaChatLieu)
                            ? _chatLieuRepo.GetById(sp.MaChatLieu)?.TenChatLieu ?? "N/A"
                            : "N/A",
                        TenKichThuoc = !string.IsNullOrEmpty(sp.MaKichThuoc)
                            ? _kichThuocRepo.GetById(sp.MaKichThuoc)?.TenKichThuoc ?? "N/A"
                            : "N/A",
                        sp.GiaBan,
                        sp.SoLuongTon,
                        SanPham = sp // Giữ lại object gốc để có thể lấy ra khi chọn
                    })
                    .ToList();

                dgvSanPham.DataSource = null;
                dgvSanPham.DataSource = displayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSanPham(txtSearch.Text);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                LoadSanPham(txtSearch.Text);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvSanPham.SelectedRows[0].DataBoundItem;

            // Lấy property SanPham từ anonymous object
            var sanPhamProperty = selectedRow.GetType().GetProperty("SanPham");
            if (sanPhamProperty != null)
            {
                SelectedProduct = sanPhamProperty.GetValue(selectedRow) as SanPham;
            }

            if (SelectedProduct == null)
            {
                MessageBox.Show("Không thể xác định sản phẩm đã chọn.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SelectedProduct.SoLuongTon <= 0)
            {
                MessageBox.Show("Sản phẩm này đã hết hàng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedProduct = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSelect_Click(sender, e);
            }
        }
    }
}
