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
            pnlMenu = new Panel();
            btnDoanhThu = new Button();
            btnNhapHang = new Button();
            btnTonKho = new Button();
            btnNhanVien = new Button();
            btnKhachHang = new Button();
            btnSanPham = new Button();
            btnGiamGia = new Button();
            pnlContent = new Panel();
            pnlHeader = new Panel();
            btnInBaoCao = new Button();
            btnXuatExcel = new Button();
            btnXemBang = new Button();
            btnXemBieuDo = new Button();
            btnXemBaoCao = new Button();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            lblTuNgay = new Label();
            lblTieuDe = new Label();
            chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvBaoCao = new DataGridView();
            pnlMenu.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(240, 248, 255);
            pnlMenu.BorderStyle = BorderStyle.FixedSingle;
            pnlMenu.Controls.Add(btnDoanhThu);
            pnlMenu.Controls.Add(btnNhapHang);
            pnlMenu.Controls.Add(btnTonKho);
            pnlMenu.Controls.Add(btnNhanVien);
            pnlMenu.Controls.Add(btnKhachHang);
            pnlMenu.Controls.Add(btnSanPham);
            pnlMenu.Controls.Add(btnGiamGia);
            pnlMenu.Location = new Point(12, 12);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(1560, 90);
            pnlMenu.TabIndex = 0;
            // 
            // btnDoanhThu
            // 
            btnDoanhThu.FlatStyle = FlatStyle.Flat;
            btnDoanhThu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDoanhThu.Location = new Point(20, 20);
            btnDoanhThu.Name = "btnDoanhThu";
            btnDoanhThu.Size = new Size(180, 50);
            btnDoanhThu.TabIndex = 0;
            btnDoanhThu.Text = "Doanh thu";
            btnDoanhThu.UseVisualStyleBackColor = true;
            btnDoanhThu.Click += btnDoanhThu_Click;
            // 
            // btnNhapHang
            // 
            btnNhapHang.FlatStyle = FlatStyle.Flat;
            btnNhapHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNhapHang.Location = new Point(220, 20);
            btnNhapHang.Name = "btnNhapHang";
            btnNhapHang.Size = new Size(180, 50);
            btnNhapHang.TabIndex = 1;
            btnNhapHang.Text = "Nhập hàng";
            btnNhapHang.UseVisualStyleBackColor = true;
            btnNhapHang.Click += btnNhapHang_Click;
            // 
            // btnTonKho
            // 
            btnTonKho.FlatStyle = FlatStyle.Flat;
            btnTonKho.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTonKho.Location = new Point(420, 20);
            btnTonKho.Name = "btnTonKho";
            btnTonKho.Size = new Size(180, 50);
            btnTonKho.TabIndex = 2;
            btnTonKho.Text = "Tồn kho";
            btnTonKho.UseVisualStyleBackColor = true;
            btnTonKho.Click += btnTonKho_Click;
            // 
            // btnNhanVien
            // 
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNhanVien.Location = new Point(620, 20);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(180, 50);
            btnNhanVien.TabIndex = 3;
            btnNhanVien.Text = "Nhân viên";
            btnNhanVien.UseVisualStyleBackColor = true;
            btnNhanVien.Click += btnNhanVien_Click;
            // 
            // btnKhachHang
            // 
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKhachHang.Location = new Point(820, 20);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(180, 50);
            btnKhachHang.TabIndex = 4;
            btnKhachHang.Text = "Khách hàng";
            btnKhachHang.UseVisualStyleBackColor = true;
            btnKhachHang.Click += btnKhachHang_Click;
            // 
            // btnSanPham
            // 
            btnSanPham.FlatStyle = FlatStyle.Flat;
            btnSanPham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSanPham.Location = new Point(1020, 20);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(180, 50);
            btnSanPham.TabIndex = 5;
            btnSanPham.Text = "Sản phẩm";
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnGiamGia
            // 
            btnGiamGia.FlatStyle = FlatStyle.Flat;
            btnGiamGia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGiamGia.Location = new Point(1220, 20);
            btnGiamGia.Name = "btnGiamGia";
            btnGiamGia.Size = new Size(180, 50);
            btnGiamGia.TabIndex = 6;
            btnGiamGia.Text = "Giảm giá";
            btnGiamGia.UseVisualStyleBackColor = true;
            btnGiamGia.Click += btnGiamGia_Click;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(pnlHeader);
            pnlContent.Controls.Add(chartDoanhThu);
            pnlContent.Controls.Add(dgvBaoCao);
            pnlContent.Location = new Point(12, 110);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1560, 670);
            pnlContent.TabIndex = 1;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.WhiteSmoke;
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(btnInBaoCao);
            pnlHeader.Controls.Add(btnXuatExcel);
            pnlHeader.Controls.Add(btnXemBang);
            pnlHeader.Controls.Add(btnXemBieuDo);
            pnlHeader.Controls.Add(btnXemBaoCao);
            pnlHeader.Controls.Add(dtpDenNgay);
            pnlHeader.Controls.Add(dtpTuNgay);
            pnlHeader.Controls.Add(lblDenNgay);
            pnlHeader.Controls.Add(lblTuNgay);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1560, 100);
            pnlHeader.TabIndex = 0;
            // 
            // btnInBaoCao
            // 
            btnInBaoCao.Location = new Point(1320, 20);
            btnInBaoCao.Name = "btnInBaoCao";
            btnInBaoCao.Size = new Size(160, 40);
            btnInBaoCao.TabIndex = 9;
            btnInBaoCao.Text = "In báo cáo";
            btnInBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(1140, 20);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(160, 40);
            btnXuatExcel.TabIndex = 8;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnXemBang
            // 
            btnXemBang.Location = new Point(960, 20);
            btnXemBang.Name = "btnXemBang";
            btnXemBang.Size = new Size(160, 40);
            btnXemBang.TabIndex = 7;
            btnXemBang.Text = "Xem bảng";
            btnXemBang.UseVisualStyleBackColor = true;
            btnXemBang.Click += btnXemBang_Click;
            // 
            // btnXemBieuDo
            // 
            btnXemBieuDo.Location = new Point(780, 20);
            btnXemBieuDo.Name = "btnXemBieuDo";
            btnXemBieuDo.Size = new Size(160, 40);
            btnXemBieuDo.TabIndex = 6;
            btnXemBieuDo.Text = "Xem biểu đồ";
            btnXemBieuDo.UseVisualStyleBackColor = true;
            btnXemBieuDo.Click += btnXemBieuDo_Click;
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.Location = new Point(600, 20);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(160, 40);
            btnXemBaoCao.TabIndex = 5;
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = true;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(390, 62);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(140, 27);
            dtpDenNgay.TabIndex = 4;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(100, 62);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(140, 27);
            dtpTuNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Font = new Font("Segoe UI", 10F);
            lblDenNgay.Location = new Point(300, 65);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(87, 23);
            lblDenNgay.TabIndex = 2;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Font = new Font("Segoe UI", 10F);
            lblTuNgay.Location = new Point(20, 65);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(75, 23);
            lblTuNgay.TabIndex = 1;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(286, 37);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "BÁO CÁO & THỐNG KÊ";
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend1);
            chartDoanhThu.Location = new Point(20, 120);
            chartDoanhThu.Name = "chartDoanhThu";
            chartDoanhThu.Size = new Size(1520, 400);
            chartDoanhThu.TabIndex = 1;
            chartDoanhThu.Visible = false;
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.BackgroundColor = Color.White;
            dgvBaoCao.BorderStyle = BorderStyle.None;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Location = new Point(20, 120);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.Size = new Size(1520, 530);
            dgvBaoCao.TabIndex = 0;
            dgvBaoCao.Visible = false;
            // 
            // ucBaoCaoThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Font = new Font("Segoe UI", 9F);
            Name = "ucBaoCaoThongKe";
            Size = new Size(1584, 800);
            Load += ucBaoCaoThongKe_Load;
            pnlMenu.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnDoanhThu;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnTonKho;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnGiamGia;

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnXemBieuDo;
        private System.Windows.Forms.Button btnXemBang;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnInBaoCao;

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataGridView dgvBaoCao;
    }
}