using BagShopManagement.Controllers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev6
{
    public partial class ucBaoCaoThongKe : UserControl
    {
        private readonly BaoCaoController _baoCaoController;
        private string _loaiBaoCaoHienTai = string.Empty;

        public ucBaoCaoThongKe(BaoCaoController baoCaoController)
        {
            InitializeComponent();
            _baoCaoController = baoCaoController;
        }

        private void ucBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;

            dgvBaoCao.Visible = false;
            chartDoanhThu.Visible = false;
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            try
            {
                _loaiBaoCaoHienTai = "doanhthu";
                DoiMauNutDangChon(btnDoanhThu);

                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                DataTable data = _baoCaoController.LayBaoCaoDoanhThuTheoNgay(tuNgay, denNgay);
                string tieuDe = $"BÁO CÁO DOANH THU ({tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy})";

                HienThiBaoCao(data, tieuDe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo doanh thu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            try
            {
                _loaiBaoCaoHienTai = "nhaphang";
                DoiMauNutDangChon(btnNhapHang);

                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                DataTable data = _baoCaoController.LayBaoCaoNhapHang(tuNgay, denNgay);
                string tieuDe = $"BÁO CÁO NHẬP HÀNG ({tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy})";

                HienThiBaoCao(data, tieuDe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo nhập hàng: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            try
            {
                _loaiBaoCaoHienTai = "tonkho";
                DoiMauNutDangChon(btnTonKho);

                DataTable data = _baoCaoController.LayBaoCaoTonKho();
                string tieuDe = "BÁO CÁO TỒN KHO HIỆN TẠI";

                HienThiBaoCao(data, tieuDe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo tồn kho: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                _loaiBaoCaoHienTai = "nhanvien";
                DoiMauNutDangChon(btnNhanVien);

                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                DataTable data = _baoCaoController.LayBaoCaoDoanhThuTheoNhanVien(tuNgay, denNgay);
                string tieuDe = $"BÁO CÁO DOANH THU THEO NHÂN VIÊN ({tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy})";

                HienThiBaoCao(data, tieuDe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo nhân viên: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                _loaiBaoCaoHienTai = "khachhang";
                DoiMauNutDangChon(btnKhachHang);

                DataTable data = _baoCaoController.LayBaoCaoKhachHangThanThiet(10);
                string tieuDe = "TOP 10 KHÁCH HÀNG THÂN THIẾT";

                HienThiBaoCao(data, tieuDe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo khách hàng thân thiết: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                _loaiBaoCaoHienTai = "sanpham";
                DoiMauNutDangChon(btnSanPham);

                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                DataTable data = _baoCaoController.LayBaoCaoSanPhamBanChay(10, tuNgay, denNgay);
                string tieuDe = $"TOP 10 SẢN PHẨM BÁN CHẠY ({tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy})";

                HienThiBaoCao(data, tieuDe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo sản phẩm bán chạy: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGiamGia_Click(object sender, EventArgs e)
        {
            try
            {
                _loaiBaoCaoHienTai = "giamgia";
                DoiMauNutDangChon(btnGiamGia);
                DataTable data = _baoCaoController.LayBaoCaoChuongTrinhGiamGia();
                string tieuDe = "BÁO CÁO CHƯƠNG TRÌNH GIẢM GIÁ";
                HienThiBaoCao(data, tieuDe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo chương trình giảm giá: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_loaiBaoCaoHienTai))
                {
                    MessageBox.Show("Vui lòng chọn loại báo cáo trước khi xem!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                switch (_loaiBaoCaoHienTai)
                {
                    case "doanhthu":
                        btnDoanhThu_Click(sender, e);
                        break;

                    case "nhaphang":
                        btnNhapHang_Click(sender, e);
                        break;

                    case "tonkho":
                        btnTonKho_Click(sender, e);
                        break;

                    case "nhanvien":
                        btnNhanVien_Click(sender, e);
                        break;

                    case "khachhang":
                        btnKhachHang_Click(sender, e);
                        break;

                    case "sanpham":
                        btnSanPham_Click(sender, e);
                        break;

                    case "giamgia":
                        btnGiamGia_Click(sender, e);
                        break;

                    default:
                        MessageBox.Show("Loại báo cáo không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem báo cáo: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiBaoCao(DataTable data, string tieuDe)
        {
            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong khoảng thời gian được chọn.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvBaoCao.Visible = false;
                chartDoanhThu.Visible = false;
                return;
            }

            dgvBaoCao.Visible = true;
            chartDoanhThu.Visible = false;
            dgvBaoCao.DataSource = data;

            //CaiDatBang(dgvBaoCao);
            lblTieuDe.Text = tieuDe;
        }

        //private void CaiDatBang(DataGridView dgv)
        //{
        //    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        //    dgv.DefaultCellStyle.ForeColor = Color.Black;
        //    dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
        //    dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
        //}

        private void DoiMauNutDangChon(Button nutDangChon)
        {
            // Reset màu tất cả nút liên quan
            btnDoanhThu.BackColor = SystemColors.Control;
            btnNhapHang.BackColor = SystemColors.Control;
            btnTonKho.BackColor = SystemColors.Control;
            btnNhanVien.BackColor = SystemColors.Control;
            btnKhachHang.BackColor = SystemColors.Control;
            btnSanPham.BackColor = SystemColors.Control;
            btnGiamGia.BackColor = SystemColors.Control;

            // Tô màu nút đang chọn
            nutDangChon.BackColor = Color.LightSkyBlue;
        }
    }
}