namespace BagShopManagement.Views.Dev6
{
    partial class ucBaoCaoThongKe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            pnlMenu = new Panel();
            btnDoanhThu = new Button();
            btnNhapHang = new Button();
            btnTonKho = new Button();
            btnNhanVien = new Button();
            btnKhachHang = new Button();
            btnSanPham = new Button();
            btnGiamGia = new Button();
            pnlHeader = new Panel();
            lblTieuDe = new Label();
            lblTuNgay = new Label();
            lblDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            btnXemBaoCao = new Button();
            btnXemBieuDo = new Button();
            btnXemBang = new Button();
            btnXuatExcel = new Button();
            btnInBaoCao = new Button();
            pnlContent = new Panel();
            chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvBaoCao = new DataGridView();
            pnlMenu.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.LightGray;
            pnlMenu.BorderStyle = BorderStyle.FixedSingle;
            pnlMenu.Controls.Add(btnDoanhThu);
            pnlMenu.Controls.Add(btnNhapHang);
            pnlMenu.Controls.Add(btnTonKho);
            pnlMenu.Controls.Add(btnNhanVien);
            pnlMenu.Controls.Add(btnKhachHang);
            pnlMenu.Controls.Add(btnSanPham);
            pnlMenu.Controls.Add(btnGiamGia);
            pnlMenu.Location = new Point(21, 10);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(1540, 90);
            pnlMenu.TabIndex = 0;
            // 
            // btnDoanhThu
            // 
            btnDoanhThu.Location = new Point(-1, 29);
            btnDoanhThu.Name = "btnDoanhThu";
            btnDoanhThu.Size = new Size(161, 40);
            btnDoanhThu.TabIndex = 0;
            btnDoanhThu.Text = "📊 Doanh thu";
            btnDoanhThu.UseVisualStyleBackColor = true;
            btnDoanhThu.Click += btnDoanhThu_Click;
            // 
            // btnNhapHang
            // 
            btnNhapHang.Location = new Point(177, 29);
            btnNhapHang.Name = "btnNhapHang";
            btnNhapHang.Size = new Size(180, 40);
            btnNhapHang.TabIndex = 1;
            btnNhapHang.Text = "📦 Nhập hàng";
            btnNhapHang.UseVisualStyleBackColor = true;
            btnNhapHang.Click += btnNhapHang_Click;
            // 
            // btnTonKho
            // 
            btnTonKho.Location = new Point(363, 29);
            btnTonKho.Name = "btnTonKho";
            btnTonKho.Size = new Size(180, 40);
            btnTonKho.TabIndex = 2;
            btnTonKho.Text = "🏬 Tồn kho";
            btnTonKho.UseVisualStyleBackColor = true;
            btnTonKho.Click += btnTonKho_Click;
            // 
            // btnNhanVien
            // 
            btnNhanVien.Location = new Point(558, 29);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(180, 40);
            btnNhanVien.TabIndex = 3;
            btnNhanVien.Text = "👨‍💼 Nhân viên";
            btnNhanVien.UseVisualStyleBackColor = true;
            btnNhanVien.Click += btnNhanVien_Click;
            // 
            // btnKhachHang
            // 
            btnKhachHang.Location = new Point(756, 29);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(180, 40);
            btnKhachHang.TabIndex = 4;
            btnKhachHang.Text = "\U0001f9d1‍\U0001f91d‍\U0001f9d1 Khách hàng";
            btnKhachHang.UseVisualStyleBackColor = true;
            btnKhachHang.Click += btnKhachHang_Click;
            // 
            // btnSanPham
            // 
            btnSanPham.Location = new Point(972, 29);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(180, 40);
            btnSanPham.TabIndex = 5;
            btnSanPham.Text = "👜 Sản phẩm";
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnGiamGia
            // 
            btnGiamGia.Location = new Point(1180, 29);
            btnGiamGia.Name = "btnGiamGia";
            btnGiamGia.Size = new Size(180, 40);
            btnGiamGia.TabIndex = 6;
            btnGiamGia.Text = "🏷️ Giảm giá";
            btnGiamGia.UseVisualStyleBackColor = true;
            btnGiamGia.Click += btnGiamGia_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.WhiteSmoke;
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Controls.Add(lblTuNgay);
            pnlHeader.Controls.Add(lblDenNgay);
            pnlHeader.Controls.Add(dtpTuNgay);
            pnlHeader.Controls.Add(dtpDenNgay);
            pnlHeader.Controls.Add(btnXemBaoCao);
            pnlHeader.Controls.Add(btnXemBieuDo);
            pnlHeader.Controls.Add(btnXemBang);
            pnlHeader.Controls.Add(btnXuatExcel);
            pnlHeader.Controls.Add(btnInBaoCao);
            pnlHeader.Location = new Point(20, 34);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1459, 90);
            pnlHeader.TabIndex = 1;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 10);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(257, 32);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "BÁO CÁO & THỐNG KÊ";
            // 
            // lblTuNgay
            // 
            lblTuNgay.Location = new Point(20, 55);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(100, 23);
            lblTuNgay.TabIndex = 1;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            lblDenNgay.Location = new Point(310, 55);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(100, 23);
            lblDenNgay.TabIndex = 3;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(156, 55);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(120, 30);
            dtpTuNgay.TabIndex = 2;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(578, 50);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(139, 30);
            dtpDenNgay.TabIndex = 4;
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.Location = new Point(811, 13);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(170, 30);
            btnXemBaoCao.TabIndex = 5;
            btnXemBaoCao.Text = "🔍 Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = true;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // btnXemBieuDo
            // 
            btnXemBieuDo.Location = new Point(1072, 10);
            btnXemBieuDo.Name = "btnXemBieuDo";
            btnXemBieuDo.Size = new Size(214, 30);
            btnXemBieuDo.TabIndex = 6;
            btnXemBieuDo.Text = "📈 Xem biểu đồ";
            btnXemBieuDo.UseVisualStyleBackColor = true;
            // 
            // btnXemBang
            // 
            btnXemBang.Location = new Point(857, 49);
            btnXemBang.Name = "btnXemBang";
            btnXemBang.Size = new Size(170, 30);
            btnXemBang.TabIndex = 7;
            btnXemBang.Text = "📋 Xem bảng";
            btnXemBang.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(1072, 49);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(135, 30);
            btnXuatExcel.TabIndex = 8;
            btnXuatExcel.Text = "📤 Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // btnInBaoCao
            // 
            btnInBaoCao.Location = new Point(1229, 48);
            btnInBaoCao.Name = "btnInBaoCao";
            btnInBaoCao.Size = new Size(110, 30);
            btnInBaoCao.TabIndex = 9;
            btnInBaoCao.Text = "🖨️ In báo cáo";
            btnInBaoCao.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.BorderStyle = BorderStyle.FixedSingle;
            pnlContent.Controls.Add(chartDoanhThu);
            pnlContent.Controls.Add(pnlHeader);
            pnlContent.Controls.Add(dgvBaoCao);
            pnlContent.Location = new Point(21, 106);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1540, 722);
            pnlContent.TabIndex = 2;
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend1);
            chartDoanhThu.Location = new Point(77, 267);
            chartDoanhThu.Name = "chartDoanhThu";
            chartDoanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartDoanhThu.Series.Add(series1);
            chartDoanhThu.Size = new Size(1174, 303);
            chartDoanhThu.TabIndex = 1;
            chartDoanhThu.Text = "chart1";
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvBaoCao.BackgroundColor = Color.White;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Location = new Point(20, 130);
            dgvBaoCao.MultiSelect = false;
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.Size = new Size(1459, 564);
            dgvBaoCao.TabIndex = 0;
            dgvBaoCao.Visible = false;
            // 
            // ucBaoCaoThongKe
            // 
            BackColor = Color.White;
            Controls.Add(pnlMenu);
            Controls.Add(pnlContent);
            Font = new Font("Segoe UI", 10F);
            Name = "ucBaoCaoThongKe";
            Size = new Size(1630, 801);
            Load += ucBaoCaoThongKe_Load;
            pnlMenu.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);

        }

        #endregion

        // Khai báo các control ở đây
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;

        private System.Windows.Forms.Button btnDoanhThu;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnTonKho;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnGiamGia;

        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnXemBieuDo;
        private System.Windows.Forms.Button btnXemBang;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnInBaoCao;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;

        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu; // Đã sửa tên biến cho nhất quán
    }
}