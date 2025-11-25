using BagShopManagement.Controllers;
using BagShopManagement.DTOs.Requests;
using BagShopManagement.DTOs.Responses;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class ucEmployeeManagement : UserControl
    {
        private readonly NhanVienController _nhanVienController;
        private readonly IServiceProvider _serviceProvider;
        private List<NhanVienResponse> _danhSachNhanVien; // Biến lưu trữ data

        public ucEmployeeManagement(NhanVienController nhanVienController, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _nhanVienController = nhanVienController;
            _serviceProvider = serviceProvider;
            _danhSachNhanVien = new List<NhanVienResponse>();
        }

        // Tải dữ liệu khi User Control được load
        private void ucEmployeeManagement_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadNhanVienData();
        }

        // Cài đặt các cột cho DataGridView
        private void SetupDataGridView()
        {
            dgvNhanVien.AutoGenerateColumns = false; // Tắt tự động tạo cột
            dgvNhanVien.Columns.Clear();

            // Định nghĩa các cột
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaNV",
                DataPropertyName = "MaNV", // Phải khớp với tên thuộc tính trong DTO
                HeaderText = "Mã NV"
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                DataPropertyName = "HoTen",
                HeaderText = "Họ tên"
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenDangNhap",
                DataPropertyName = "TenDangNhap",
                HeaderText = "Tên đăng nhập"
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenVaiTro",
                DataPropertyName = "TenVaiTro",
                HeaderText = "Vai trò"
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn // Dùng CheckBox cho True/False
            {
                Name = "TrangThai",
                DataPropertyName = "TrangThaiTK",
                HeaderText = "Hoạt động"
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ChucVu",
                DataPropertyName = "ChucVu",
                HeaderText = "Chức vụ"
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoDienThoai",
                DataPropertyName = "SoDienThoai",
                HeaderText = "SĐT"
            });
            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                DataPropertyName = "Email",
                HeaderText = "Email"
            });
        }

        // Hàm tải dữ liệu chính
        private void LoadNhanVienData()
        {
            try
            {
                _danhSachNhanVien = (List<NhanVienResponse>)_nhanVienController.HandleGetAllNhanVien();

                // Gán dữ liệu cho DataGridView
                // Cần gán DataSource = null trước để refresh
                dgvNhanVien.DataSource = null;
                dgvNhanVien.DataSource = _danhSachNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadNhanVienData();
        }

        // Nút Thêm mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Chúng ta dùng IServiceProvider để tạo form EmployeeEditForm
            // (Vì EmployeeEditForm cũng cần DI)
            using (var form = _serviceProvider.GetRequiredService<EmployeeEditForm>())
            {
                // Mở form dưới dạng popup
                form.ShowDialog(this);
            }

            // Sau khi form "Thêm" đóng, tải lại danh sách
            LoadNhanVienData();
        }

        // Nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dòng nào được chọn không
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Chưa chọn nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy MaNV từ dòng được chọn
            string maNV = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();

            // 3. Mở form EmployeeEditForm ở chế độ Sửa
            using (var form = _serviceProvider.GetRequiredService<EmployeeEditForm>())
            {
                // Chúng ta sẽ tạo một hàm public trên EmployeeEditForm
                // để truyền MaNV vào và báo cho nó biết là đang "Sửa"
                form.LoadNhanVienForEdit(maNV);

                form.ShowDialog(this);
            }

            // 4. Tải lại danh sách sau khi sửa
            LoadNhanVienData();
        }

        // Nút Khóa / Mở khóa
        private void btnKhoaMo_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra chọn dòng
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để khóa hoặc mở khóa.", "Chưa chọn nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy thông tin nhân viên từ dòng được chọn
            // (Chúng ta có thể lấy trực tiếp object NhanVienResponse từ data source)
            var selectedNhanVien = (NhanVienResponse)dgvNhanVien.SelectedRows[0].DataBoundItem;

            // 3. Xác nhận
            string actionText = selectedNhanVien.TrangThaiTK ? "KHÓA" : "MỞ KHÓA";
            var confirmResult = MessageBox.Show(
                $"Bạn có chắc muốn {actionText} tài khoản của nhân viên '{selectedNhanVien.HoTen}'?",
                "Xác nhận hành động",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // 4. Tạo UpdateRequest DTO
                    // Chúng ta tái sử dụng logic Sửa, chỉ thay đổi TrangThai
                    var request = new UpdateNhanVienRequest
                    {
                        MaNV = selectedNhanVien.MaNV,
                        HoTen = selectedNhanVien.HoTen,
                        ChucVu = selectedNhanVien.ChucVu,
                        SoDienThoai = selectedNhanVien.SoDienThoai,
                        Email = selectedNhanVien.Email,
                        MaVaiTro = _danhSachNhanVien.Find(nv => nv.MaNV == selectedNhanVien.MaNV)?.MaVaiTro, // Cần lấy MaVaiTro (DTO Response nên có)
                        TrangThaiTK = !selectedNhanVien.TrangThaiTK // <== Đảo ngược trạng thái
                    };

                    // 5. Gọi Controller
                    bool success = _nhanVienController.HandleUpdateNhanVien(request);

                    if (success)
                    {
                        MessageBox.Show($"Đã {actionText} tài khoản thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhanVienData(); // Tải lại lưới
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi {actionText} tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // (Tùy chọn) Định dạng cột Trạng Thái (CheckBox) thành chữ
        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // === THÊM LẠI ĐOẠN CODE NÀY ===

            // 1. Kiểm tra xem có phải cột "TrangThai" không
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                try
                {
                    // 2. Lấy giá trị bool (true/false)
                    bool trangThai = (bool)e.Value;

                    // 3. Đổi nó thành chữ
                    e.Value = trangThai ? "Hoạt động" : "Đã khóa";

                    // 4. Báo cho DataGridView biết là chúng ta đã xử lý xong
                    e.FormattingApplied = true;
                }
                catch (Exception)
                {
                    //throw new Exception();
                }
            }

            // (Bạn có thể thêm các định dạng cho các cột khác ở đây)
        }
        private void PerformSearch()
        {
            // (Giả sử TextBox tên là 'txtTimKiem')
            // string keyword = txtTimKiem.Text.Trim();
            string keyword = txtTimKiem.Text.Trim(); ; // <-- Thay thế bằng control của bạn

            try
            {
                // Gọi Controller để lấy dữ liệu tìm kiếm
                var searchResult = _nhanVienController.HandleSearchNhanVien(keyword);

                // Cập nhật DataGridView
                dgvNhanVien.DataSource = null;
                dgvNhanVien.DataSource = searchResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kích hoạt khi nhấn nút "Tìm"
        /// (Bạn phải kết nối sự kiện Click của nút "Tìm" vào hàm này)
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        /// <summary>
        /// Kích hoạt khi gõ phím trong TextBox (để bắt phím Enter)
        /// (Bạn phải kết nối sự kiện KeyDown của TextBox "Tìm" vào hàm này)
        /// </summary>
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
                // Ngăn tiếng "bíp" của Windows khi nhấn Enter
                e.SuppressKeyPress = true;
            }
        }
    }
}
