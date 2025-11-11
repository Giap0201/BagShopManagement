using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace BagShopManagement.Views.Common
{
    public partial class DatabaseTestForm : Form
    {
        public DatabaseTestForm()
        {
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void TestConnection()
        {
            // ⚠️ Thay đổi Server & Password cho đúng hệ thống của bạn
            string connectionString =
    "Server=DESKTOP-862VN9A;Database=BagStoreDB;Trusted_Connection=True;TrustServerCertificate=True;";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("✅ Kết nối SQL Server thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Kết nối thất bại:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
