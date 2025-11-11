using System;
using System.Data;
using System.Windows.Forms;
using BagShopManagement.Controllers; // cần có
using BagShopManagement.Services.Interfaces;

namespace BagShopManagement.Views.Dev6
{
    public partial class ucBaoCaoNhapHang : UserControl
    {
        private readonly BaoCaoController _baoCaoController;

        public ucBaoCaoNhapHang(BaoCaoController baoCaoController)
        {
            InitializeComponent();
            _baoCaoController = baoCaoController;
        }

        private void ucBaoCaoNhapHang_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị dữ liệu nhập trong 7 ngày gần nhất
            dtpTuNgay.Value = DateTime.Now.AddDays(-7);
            dtpDenNgay.Value = DateTime.Now;
            HienThiBaoCao();
        }

        private void HienThiBaoCao()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi controller để lấy báo cáo nhập hàng
                DataTable dt = _baoCaoController.LayBaoCaoNhapHang(tuNgay, denNgay);

                dgvBaoCao.DataSource = dt;
                dgvBaoCao.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Đặt tiêu đề cột rõ ràng
                if (dgvBaoCao.Columns.Contains("NgayNhap"))
                    dgvBaoCao.Columns["NgayNhap"].HeaderText = "Ngày nhập";

                if (dgvBaoCao.Columns.Contains("SoHoaDon"))
                    dgvBaoCao.Columns["SoHoaDon"].HeaderText = "Số hóa đơn";

                if (dgvBaoCao.Columns.Contains("TongTienNhap"))
                {
                    dgvBaoCao.Columns["TongTienNhap"].HeaderText = "Tổng tiền nhập (VNĐ)";
                    dgvBaoCao.Columns["TongTienNhap"].DefaultCellStyle.Format = "N0";
                    dgvBaoCao.Columns["TongTienNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Tính tổng giá trị nhập
                if (dt != null && dt.Rows.Count > 0)
                {
                    decimal tong = Convert.ToDecimal(dt.Compute("SUM(TongTienNhap)", string.Empty));
                    lblTongNhapHang.Text = $"Tổng tiền nhập: {tong:N0} VNĐ";
                }
                else
                {
                    lblTongNhapHang.Text = "Không có dữ liệu trong khoảng thời gian này.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo nhập hàng: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            HienThiBaoCao();
        }
    }
}