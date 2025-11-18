using BagShopManagement.Models;
using BagShopManagement.Repositories.Implementations;
using System;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev4
{
    public partial class ThemKhachHangForm : Form
    {
        private readonly KhachHangRepository _khRepo;
        public KhachHang? KhachHangMoi { get; private set; }

        public ThemKhachHangForm(string sdt)
        {
            InitializeComponent();
            _khRepo = new KhachHangRepository();

            // Pre-fill số điện thoại
            txtSDT.Text = sdt;
            txtSDT.ReadOnly = true; // Không cho sửa SĐT vì đã nhập rồi

            // Generate Mã KH tự động
            txtMaKH.Text = GenerateMaKH();
            txtMaKH.ReadOnly = true;
        }

        private string GenerateMaKH()
        {
            var allKH = _khRepo.GetAll();
            int maxNumber = 0;

            foreach (var kh in allKH)
            {
                if (!string.IsNullOrEmpty(kh.MaKH) && kh.MaKH.StartsWith("KH"))
                {
                    string numberPart = kh.MaKH.Substring(2);
                    if (int.TryParse(numberPart, out int num))
                    {
                        if (num > maxNumber)
                            maxNumber = num;
                    }
                }
            }

            return $"KH{(maxNumber + 1):D3}"; // KH001, KH002, ...
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            // Tạo đối tượng KhachHang mới
            var kh = new KhachHang
            {
                MaKH = txtMaKH.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiemTichLuy = 0
            };

            try
            {
                // Lưu vào database
                int result = _khRepo.Add(kh);
                bool success = result > 0;

                if (success)
                {
                    KhachHangMoi = kh;
                    MessageBox.Show($"Thêm khách hàng '{kh.HoTen}' thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm khách hàng. Vui lòng thử lại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
