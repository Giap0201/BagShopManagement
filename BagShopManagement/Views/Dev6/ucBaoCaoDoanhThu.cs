using System;
using System.Data;
using System.Windows.Forms;
using BagShopManagement.Controllers; // cần có namespace này

namespace BagShopManagement.Views.Dev6
{
    public partial class ucBaoCaoDoanhThu : UserControl
    {
        private readonly BaoCaoController _baoCaoController;

        public ucBaoCaoDoanhThu(BaoCaoController baoCaoController)
        {
            InitializeComponent();
            _baoCaoController = baoCaoController;
        }

        private void ucBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị doanh thu tháng hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            HienThiBaoCao();
        }

        private void HienThiBaoCao()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                // Gọi controller để lấy DataTable doanh thu
                DataTable dt = _baoCaoController.LayBaoCaoDoanhThuTheoNgay(tuNgay, denNgay);

                // Gán nguồn dữ liệu cho DataGridView
                dgvBaoCao.DataSource = dt;

                // Căn giữa header
                dgvBaoCao.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Đặt tiêu đề cột đẹp hơn nếu cần
                if (dgvBaoCao.Columns.Contains("NgayLap"))
                    dgvBaoCao.Columns["NgayLap"].HeaderText = "Ngày lập";

                if (dgvBaoCao.Columns.Contains("SoHoaDon"))
                    dgvBaoCao.Columns["SoHoaDon"].HeaderText = "Số hóa đơn";

                if (dgvBaoCao.Columns.Contains("TongDoanhThu"))
                {
                    dgvBaoCao.Columns["TongDoanhThu"].HeaderText = "Tổng doanh thu (VNĐ)";
                    dgvBaoCao.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";
                    dgvBaoCao.Columns["TongDoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Tính tổng doanh thu
                if (dt != null && dt.Rows.Count > 0)
                {
                    decimal tong = Convert.ToDecimal(dt.Compute("SUM(TongDoanhThu)", string.Empty));
                    lblTongDoanhThu.Text = $"Tổng doanh thu: {tong:N0} VNĐ";
                }
                else
                {
                    lblTongDoanhThu.Text = "Không có dữ liệu trong khoảng thời gian này.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            HienThiBaoCao();
        }
    }
}