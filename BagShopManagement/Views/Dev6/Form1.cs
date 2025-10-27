using BagShopManagement.DataAccess;
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

        private void LoadHoaDonNhap()
        {
            try
            {
                string query = "SELECT MaHDN, MaNCC, MaNV, NgayNhap, TongTien, GhiChu FROM HoaDonNhap";
                DataTable dt = DataAccessBase.ExecuteQuery(query);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadHoaDonNhap();
        }
    }
}