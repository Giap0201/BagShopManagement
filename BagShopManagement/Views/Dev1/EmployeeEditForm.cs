using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Requests;
using BagShopManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; // Added for Regex validation

namespace BagShopManagement.Views.Dev1
{
    public partial class EmployeeEditForm : Form
    {
        // Controllers và Repositories được DI tiêm vào
        private readonly NhanVienController _nhanVienController;
        private readonly INhanVienRepository _nhanVienRepo;
        private readonly ITaiKhoanRepository _taiKhoanRepo;
        private readonly IVaiTroRepository _vaiTroRepo;

        // Biến trạng thái
        private bool _isEditMode = false;
        private string _editMaNV = null;
        private ErrorProvider _errorProvider; // Added ErrorProvider

        public EmployeeEditForm(
            NhanVienController nhanVienController,
            INhanVienRepository nhanVienRepo,
            ITaiKhoanRepository taiKhoanRepo,
            IVaiTroRepository vaiTroRepo)
        {
            InitializeComponent();
            _nhanVienController = nhanVienController;
            _nhanVienRepo = nhanVienRepo;
            _taiKhoanRepo = taiKhoanRepo;
            _vaiTroRepo = vaiTroRepo;
            _errorProvider = new ErrorProvider(); // Initialize ErrorProvider
        }

        // Đây là hàm public mà ucEmployeeManagement gọi
        public void LoadNhanVienForEdit(string maNV)
        {
            _isEditMode = true;
            _editMaNV = maNV;
            this.Text = "Sửa Nhân viên"; // Đổi tiêu đề Form
        }

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {
            // Tải danh sách Vai trò lên ComboBox
            LoadVaiTroComboBox();

            if (_isEditMode)
            {
                // Nếu là chế độ Sửa, tải dữ liệu
                PopulateDataForEdit();

                // Vô hiệu hóa việc sửa Mã NV và Tên Đăng Nhập
                txtMaNV.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;

                // Ẩn ô mật khẩu (chỉ reset chứ không sửa)
                lblMatKhau.Visible = false;
                txtMatKhau.Visible = false;
            }
            else
            {
                // Nếu là chế độ Thêm mới
                this.Text = "Thêm Nhân viên";
                chkTrangThai.Checked = true;
                chkTrangThai.Enabled = false; // Mặc định là Hoạt động
                txtMaNV.ReadOnly = true;
                txtMaNV.Text = "[Tự động tạo]";
            }
        }

        private void LoadVaiTroComboBox()
        {
            try
            {
                var vaiTroList = _vaiTroRepo.GetAll().ToList();
                cboVaiTro.DataSource = vaiTroList;
                cboVaiTro.DisplayMember = "TenVaiTro";
                cboVaiTro.ValueMember = "MaVaiTro";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vai trò: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateDataForEdit()
        {
            try
            {
                var nhanVien = _nhanVienRepo.GetById(_editMaNV);
                var taiKhoan = _taiKhoanRepo.GetByMaNV(_editMaNV);

                if (nhanVien == null || taiKhoan == null)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu nhân viên hoặc tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Đổ dữ liệu
                txtMaNV.Text = nhanVien.MaNV;
                txtHoTen.Text = nhanVien.HoTen;
                txtChucVu.Text = nhanVien.ChucVu;
                txtEmail.Text = nhanVien.Email;
                txtSoDienThoai.Text = nhanVien.SoDienThoai;

                cboVaiTro.SelectedValue = taiKhoan.MaVaiTro;
                chkTrangThai.Checked = taiKhoan.TrangThai;

                txtTenDangNhap.Text = taiKhoan.TenDangNhap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hàm kiểm tra tính hợp lệ của dữ liệu đầu vào
        /// </summary>
        private bool ValidateInput()
        {
            bool isValid = true;
            _errorProvider.Clear(); // Xóa các lỗi cũ

            // 1. Kiểm tra Họ tên (Bắt buộc)
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                _errorProvider.SetError(txtHoTen, "Vui lòng nhập họ tên nhân viên.");
                isValid = false;
            }

            // 2. Kiểm tra Email (Định dạng & Bắt buộc nếu cần)
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                // Nếu email là bắt buộc, uncomment dòng dưới:
                _errorProvider.SetError(txtEmail, "Vui lòng nhập email.");
                isValid = false;
            }
            else
            {
                // Regex kiểm tra định dạng email chuẩn
                // Pattern này chấp nhận các email dạng: user@domain.com, user.name@domain.co.uk, v.v.
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(txtEmail.Text, emailPattern))
                {
                    _errorProvider.SetError(txtEmail, "Email không đúng định dạng (ví dụ: abc@domain.com).");
                    isValid = false;
                }
            }

            // 3. Kiểm tra SĐT (Bắt buộc & Định dạng số)
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                _errorProvider.SetError(txtSoDienThoai, "Vui lòng nhập số điện thoại.");
                isValid = false;
            }
            else if (!Regex.IsMatch(txtSoDienThoai.Text, @"^\d{10,11}$")) // Chỉ chấp nhận 10-11 số
            {
                _errorProvider.SetError(txtSoDienThoai, "Số điện thoại phải là số và có 10-11 chữ số.");
                isValid = false;
            }

            // 4. Kiểm tra Tên đăng nhập (Bắt buộc & Ký tự đặc biệt) - Chỉ kiểm tra khi thêm mới vì khi sửa bị disable
            if (!_isEditMode)
            {
                if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                {
                    _errorProvider.SetError(txtTenDangNhap, "Vui lòng nhập tên đăng nhập.");
                    isValid = false;
                }
                else if (txtTenDangNhap.Text.Contains(" "))
                {
                    _errorProvider.SetError(txtTenDangNhap, "Tên đăng nhập không được chứa khoảng trắng.");
                    isValid = false;
                }
            }


            // 5. Kiểm tra Mật khẩu (Chỉ bắt buộc khi THÊM MỚI)
            if (!_isEditMode && string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                _errorProvider.SetError(txtMatKhau, "Vui lòng nhập mật khẩu cho nhân viên mới.");
                isValid = false;
            }
            // Nếu là Sửa mà người dùng có nhập mật khẩu -> Kiểm tra độ dài tối thiểu (Logic này có thể ko cần thiết vì ô mật khẩu ẩn khi sửa nhưng để an toàn)
            if (_isEditMode && txtMatKhau.Visible && !string.IsNullOrEmpty(txtMatKhau.Text) && txtMatKhau.Text.Length < 6)
            {
                _errorProvider.SetError(txtMatKhau, "Mật khẩu mới phải có ít nhất 6 ký tự.");
                isValid = false;
            }

            // 6. Kiểm tra vai trò
            if (cboVaiTro.SelectedValue == null)
            {
                _errorProvider.SetError(cboVaiTro, "Vui lòng chọn vai trò.");
                isValid = false;
            }


            return isValid;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu (Validation)
            if (!ValidateInput()) // Sử dụng hàm ValidateInput thay vì kiểm tra thủ công
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin nhập liệu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_isEditMode)
                {
                    // Chế độ SỬA
                    var request = new UpdateNhanVienRequest
                    {
                        MaNV = _editMaNV,
                        HoTen = txtHoTen.Text.Trim(),
                        ChucVu = txtChucVu.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        SoDienThoai = txtSoDienThoai.Text.Trim(),
                        MaVaiTro = cboVaiTro.SelectedValue.ToString(),
                        TrangThaiTK = chkTrangThai.Checked
                    };

                    bool success = _nhanVienController.HandleUpdateNhanVien(request);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật nhân viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    // Chế độ THÊM MỚI
                    // Logic validate TenDangNhap & MatKhau đã được chuyển vào ValidateInput

                    var request = new CreateNhanVienRequest
                    {
                        HoTen = txtHoTen.Text.Trim(),
                        ChucVu = txtChucVu.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        SoDienThoai = txtSoDienThoai.Text.Trim(),
                        MaVaiTro = cboVaiTro.SelectedValue.ToString(),
                        TenDangNhap = txtTenDangNhap.Text.Trim(),
                        MatKhau = txtMatKhau.Text.Trim() // Service sẽ tự động hash
                    };

                    bool success = _nhanVienController.HandleCreateNhanVien(request);
                    if (success)
                    {
                        MessageBox.Show("Thêm nhân viên mới thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi từ Controller (ví dụ: Tên đăng nhập đã tồn tại)
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}