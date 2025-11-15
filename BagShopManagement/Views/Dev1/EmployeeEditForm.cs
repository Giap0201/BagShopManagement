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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu (Validation)
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || cboVaiTro.SelectedValue == null)
            {
                MessageBox.Show("Họ tên và Vai trò là bắt buộc.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    {
                        MessageBox.Show("Tên đăng nhập và Mật khẩu là bắt buộc khi thêm mới.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

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
