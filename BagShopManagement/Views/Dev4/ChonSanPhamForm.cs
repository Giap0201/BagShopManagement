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
        private List<SanPham> _allProducts;
        public SanPham? SelectedProduct { get; private set; }

        public ChonSanPhamForm()
        {
            InitializeComponent();
            _sanPhamRepo = new SanPhamRepository();
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
                FillWeight = 15F,
                Name = "MaSP"
            });

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 35F,
                Name = "TenSP"
            });

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giá bán",
                DataPropertyName = "GiaBan",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15F,
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
                FillWeight = 12F,
                Name = "SoLuongTon",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Cột ảnh (nếu có)
            var imgColumn = new DataGridViewImageColumn
            {
                HeaderText = "Ảnh",
                Name = "AnhSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 10F,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dgvSanPham.Columns.Add(imgColumn);

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại túi",
                DataPropertyName = "MaLoaiTui",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 13F,
                Name = "MaLoaiTui"
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

                // Chỉ hiển thị sản phẩm còn tồn kho
                var displayList = _allProducts.Where(sp => sp.SoLuongTon > 0).ToList();

                dgvSanPham.DataSource = null;
                dgvSanPham.DataSource = displayList;

                // Xử lý hiển thị ảnh (nếu có trường ảnh)
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    var sp = row.DataBoundItem as SanPham;
                    if (sp != null)
                    {
                        // TODO: Load ảnh từ database hoặc file nếu có
                        // row.Cells["AnhSP"].Value = LoadImage(sp.AnhSP);
                    }
                }
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

            SelectedProduct = dgvSanPham.SelectedRows[0].DataBoundItem as SanPham;

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
