using BagShopManagement.DataAccess;
using BagShopManagement.Repositories.Implementations;
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

namespace BagShopManagement.Views.Dev6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        /* * LƯU Ý QUAN TRỌNG:
 * Code này CHỈ DÙNG ĐỂ TEST BaseRepository.
 * * Trong kiến trúc MVP chuẩn, View (Form) KHÔNG BAO GIỜ
 * được phép "new HoaDonRepository()" hay gọi trực tiếp DataAccess.
 * Sau khi test xong, bạn phải XÓA code này đi
 * và trả "public" về "protected" trong BaseRepository.
 */

        private void LoadHoaDonNhap()
        {
            // Tạo một Repository tạm thời để test
            // (Giả sử bạn đã có lớp HoaDonRepository kế thừa từ BaseRepository)
            HoaDonNhapImpl _tempTestRepo;

            try
            {
                _tempTestRepo = new HoaDonNhapImpl();
            }
            catch (System.Configuration.ConfigurationErrorsException configEx)
            {
                // Bắt lỗi nếu bạn quên thêm App.config
                MessageBox.Show(
                    "Lỗi cấu hình: " + configEx.Message + "\n\nBạn đã tạo file App.config và thêm connection string chưa?",
                    "Lỗi App.config",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo Repository: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- BƯỚC 1: Kiểm tra kết nối ---
            try
            {
                // Gọi hàm TestConnection() (đã sửa thành public)
                _tempTestRepo.TestConnection();

                MessageBox.Show(
                    "Kết nối cơ sở dữ liệu (qua BaseRepository) thành công!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Kiểm tra kết nối thất bại. Lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return; // Dừng nếu kết nối lỗi
            }

            // --- BƯỚC 2: Tải dữ liệu ---
            try
            {
                string query = "SELECT MaHDN, MaNCC, MaNV, NgayNhap, TongTien, GhiChu FROM HoaDonNhap";

                // Gọi hàm ExecuteQuery() (đã sửa thành public)
                DataTable dt = _tempTestRepo.ExecuteQuery(query);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Tải dữ liệu thất bại. Lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadHoaDonNhap();
        }
    }
}