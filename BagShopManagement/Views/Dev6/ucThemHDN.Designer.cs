namespace BagShopManagement.Views.Dev6
{
    partial class ucThemHDN
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            dtpNgayHuy = new DateTimePicker();
            dtpNgayDuyet = new DateTimePicker();
            lblNgayHuy = new Label();
            lblNgayDuyet = new Label();
            cboTrangThai = new ComboBox();
            label3 = new Label();
            txtGhiChu = new TextBox();
            dtpNgayNhap = new DateTimePicker();
            cboNhanVien = new ComboBox();
            cboNhaCungCap = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtMaHDN = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lblTongTien = new Label();
            txtThanhTien = new TextBox();
            txtDonGia = new TextBox();
            txtSoLuong = new TextBox();
            cboSanPham = new ComboBox();
            btnLuuChiTietHDN = new Button();
            label14 = new Label();
            btnXoaChiTietHDN = new Button();
            btnSuaChiTietHDN = new Button();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            btnThemChiTietHDN = new Button();
            label10 = new Label();
            dgvChiTiet = new DataGridView();
            btnTaoMoiHDN = new Button();
            btnThoat = new Button();
            btnInHDN = new Button();
            btnDuyetHDN = new Button();
            btnTamLuuHDN = new Button();
            errorProvider1 = new ErrorProvider(components);
            label7 = new Label();
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpNgayHuy);
            groupBox1.Controls.Add(dtpNgayDuyet);
            groupBox1.Controls.Add(lblNgayHuy);
            groupBox1.Controls.Add(lblNgayDuyet);
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtGhiChu);
            groupBox1.Controls.Add(dtpNgayNhap);
            groupBox1.Controls.Add(cboNhanVien);
            groupBox1.Controls.Add(cboNhaCungCap);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMaHDN);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(65, 93);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1401, 190);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin chung";
            // 
            // dtpNgayHuy
            // 
            dtpNgayHuy.Format = DateTimePickerFormat.Short;
            dtpNgayHuy.Location = new Point(1039, 76);
            dtpNgayHuy.Name = "dtpNgayHuy";
            dtpNgayHuy.Size = new Size(136, 27);
            dtpNgayHuy.TabIndex = 0;
            // 
            // dtpNgayDuyet
            // 
            dtpNgayDuyet.Format = DateTimePickerFormat.Short;
            dtpNgayDuyet.Location = new Point(1039, 26);
            dtpNgayDuyet.Name = "dtpNgayDuyet";
            dtpNgayDuyet.Size = new Size(136, 27);
            dtpNgayDuyet.TabIndex = 1;
            // 
            // lblNgayHuy
            // 
            lblNgayHuy.AutoSize = true;
            lblNgayHuy.Location = new Point(942, 76);
            lblNgayHuy.Name = "lblNgayHuy";
            lblNgayHuy.Size = new Size(71, 20);
            lblNgayHuy.TabIndex = 2;
            lblNgayHuy.Text = "Ngày huỷ";
            // 
            // lblNgayDuyet
            // 
            lblNgayDuyet.AutoSize = true;
            lblNgayDuyet.Location = new Point(942, 28);
            lblNgayDuyet.Name = "lblNgayDuyet";
            lblNgayDuyet.Size = new Size(85, 20);
            lblNgayDuyet.TabIndex = 3;
            lblNgayDuyet.Text = "Ngày duyệt";
            // 
            // cboTrangThai
            // 
            cboTrangThai.Location = new Point(693, 126);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(151, 28);
            cboTrangThai.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(494, 126);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 5;
            label3.Text = "Trạng thái";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(693, 76);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(152, 27);
            txtGhiChu.TabIndex = 6;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Format = DateTimePickerFormat.Short;
            dtpNgayNhap.Location = new Point(693, 28);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(152, 27);
            dtpNgayNhap.TabIndex = 7;
            dtpNgayNhap.ValueChanged += dtpNgayNhap_ValueChanged;
            // 
            // cboNhanVien
            // 
            cboNhanVien.Location = new Point(184, 142);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(151, 28);
            cboNhanVien.TabIndex = 8;
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.Location = new Point(184, 83);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(151, 28);
            cboNhaCungCap.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 145);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 11;
            label6.Text = "Nhân viên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(494, 27);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 12;
            label5.Text = "Ngày nhập";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(494, 79);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 13;
            label4.Text = "Ghi chú";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 83);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 14;
            label2.Text = "Nhà cung cấp";
            // 
            // txtMaHDN
            // 
            txtMaHDN.Location = new Point(184, 35);
            txtMaHDN.Name = "txtMaHDN";
            txtMaHDN.Size = new Size(152, 27);
            txtMaHDN.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 35);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 16;
            label1.Text = "Mã hoá đơn nhập";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblTongTien);
            groupBox2.Controls.Add(txtThanhTien);
            groupBox2.Controls.Add(txtDonGia);
            groupBox2.Controls.Add(txtSoLuong);
            groupBox2.Controls.Add(cboSanPham);
            groupBox2.Controls.Add(btnLuuChiTietHDN);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(btnXoaChiTietHDN);
            groupBox2.Controls.Add(btnSuaChiTietHDN);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(btnThemChiTietHDN);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(dgvChiTiet);
            groupBox2.Location = new Point(65, 289);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1401, 455);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết hoá đơn";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(140, 370);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(17, 20);
            lblTongTien.TabIndex = 0;
            lblTongTien.Text = "0";
            // 
            // txtThanhTien
            // 
            txtThanhTien.Location = new Point(960, 213);
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.Size = new Size(151, 27);
            txtThanhTien.TabIndex = 1;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(960, 170);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(151, 27);
            txtDonGia.TabIndex = 2;
            txtDonGia.TextChanged += txtDonGia_TextChanged;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(960, 120);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(151, 27);
            txtSoLuong.TabIndex = 3;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            // 
            // cboSanPham
            // 
            cboSanPham.Location = new Point(960, 64);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(151, 28);
            cboSanPham.TabIndex = 4;
            // 
            // btnLuuChiTietHDN
            // 
            btnLuuChiTietHDN.Location = new Point(1174, 308);
            btnLuuChiTietHDN.Name = "btnLuuChiTietHDN";
            btnLuuChiTietHDN.Size = new Size(94, 29);
            btnLuuChiTietHDN.TabIndex = 5;
            btnLuuChiTietHDN.Text = "LƯU";
            btnLuuChiTietHDN.Click += btnLuuChiTietHDN_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(37, 370);
            label14.Name = "label14";
            label14.Size = new Size(75, 20);
            label14.TabIndex = 6;
            label14.Text = "Tổng tiền:";
            // 
            // btnXoaChiTietHDN
            // 
            btnXoaChiTietHDN.Location = new Point(1057, 308);
            btnXoaChiTietHDN.Name = "btnXoaChiTietHDN";
            btnXoaChiTietHDN.Size = new Size(94, 29);
            btnXoaChiTietHDN.TabIndex = 7;
            btnXoaChiTietHDN.Text = "XOÁ";
            btnXoaChiTietHDN.Click += btnXoaChiTietHDN_Click;
            // 
            // btnSuaChiTietHDN
            // 
            btnSuaChiTietHDN.Location = new Point(940, 308);
            btnSuaChiTietHDN.Name = "btnSuaChiTietHDN";
            btnSuaChiTietHDN.Size = new Size(94, 29);
            btnSuaChiTietHDN.TabIndex = 8;
            btnSuaChiTietHDN.Text = "SỬA";
            btnSuaChiTietHDN.Click += btnSuaChiTietHDN_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(820, 170);
            label13.Name = "label13";
            label13.Size = new Size(62, 20);
            label13.TabIndex = 9;
            label13.Text = "Đơn giá";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(820, 213);
            label12.Name = "label12";
            label12.Size = new Size(78, 20);
            label12.TabIndex = 10;
            label12.Text = "Thành tiền";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(820, 127);
            label11.Name = "label11";
            label11.Size = new Size(69, 20);
            label11.TabIndex = 11;
            label11.Text = "Số lượng";
            // 
            // btnThemChiTietHDN
            // 
            btnThemChiTietHDN.Location = new Point(820, 308);
            btnThemChiTietHDN.Name = "btnThemChiTietHDN";
            btnThemChiTietHDN.Size = new Size(109, 29);
            btnThemChiTietHDN.TabIndex = 12;
            btnThemChiTietHDN.Text = "THÊM";
            btnThemChiTietHDN.Click += btnThemChiTietHDN_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(820, 73);
            label10.Name = "label10";
            label10.Size = new Size(75, 20);
            label10.TabIndex = 13;
            label10.Text = "Sản phẩm";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.ColumnHeadersHeight = 29;
            dgvChiTiet.Location = new Point(37, 26);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.Size = new Size(695, 325);
            dgvChiTiet.TabIndex = 14;
            dgvChiTiet.CellClick += dgvChiTiet_CellClick;
            // 
            // btnTaoMoiHDN
            // 
            btnTaoMoiHDN.Location = new Point(65, 13);
            btnTaoMoiHDN.Name = "btnTaoMoiHDN";
            btnTaoMoiHDN.Size = new Size(150, 29);
            btnTaoMoiHDN.TabIndex = 2;
            btnTaoMoiHDN.Text = "TẠO MỚI";
            btnTaoMoiHDN.Click += btnTaoMoiHDN_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(750, 16);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "QUAY LẠI";
            btnThoat.Click += btnThoat_Click;
            // 
            // btnInHDN
            // 
            btnInHDN.Location = new Point(550, 13);
            btnInHDN.Name = "btnInHDN";
            btnInHDN.Size = new Size(131, 29);
            btnInHDN.TabIndex = 4;
            btnInHDN.Text = "IN HOÁ ĐƠN";
            btnInHDN.Click += btnInHDN_Click;
            // 
            // btnDuyetHDN
            // 
            btnDuyetHDN.Location = new Point(383, 13);
            btnDuyetHDN.Name = "btnDuyetHDN";
            btnDuyetHDN.Size = new Size(131, 29);
            btnDuyetHDN.TabIndex = 6;
            btnDuyetHDN.Text = "DUYỆT";
            btnDuyetHDN.Click += btnDuyetHDN_Click;
            // 
            // btnTamLuuHDN
            // 
            btnTamLuuHDN.Location = new Point(251, 13);
            btnTamLuuHDN.Name = "btnTamLuuHDN";
            btnTamLuuHDN.Size = new Size(94, 29);
            btnTamLuuHDN.TabIndex = 5;
            btnTamLuuHDN.Text = "TẠM LƯU";
            btnTamLuuHDN.Click += btnTamLuuHDN_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(680, 46);
            label7.Name = "label7";
            label7.Size = new Size(122, 20);
            label7.TabIndex = 17;
            label7.Text = "THÊM HOÁ ĐƠN";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnTaoMoiHDN);
            panel1.Controls.Add(btnInHDN);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnDuyetHDN);
            panel1.Controls.Add(btnTamLuuHDN);
            panel1.Location = new Point(65, 788);
            panel1.Name = "panel1";
            panel1.Size = new Size(1401, 50);
            panel1.TabIndex = 15;
            // 
            // ucChiTietHDN
            // 
            Controls.Add(panel1);
            Controls.Add(label7);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "ucChiTietHDN";
            Size = new Size(1591, 876);
            Load += ucChiTietHDN_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtMaHDN;
        private Label label1;
        private ComboBox cboNhaCungCap;
        private ComboBox cboNhanVien;
        private DateTimePicker dtpNgayNhap;
        private TextBox txtGhiChu;
        private ComboBox cboTrangThai;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label2;
        private DateTimePicker dtpNgayHuy;
        private DateTimePicker dtpNgayDuyet;
        private Label lblNgayHuy;
        private Label lblNgayDuyet;

        private GroupBox groupBox2;
        private DataGridView dgvChiTiet;
        private ComboBox cboSanPham;
        private TextBox txtSoLuong;
        private TextBox txtDonGia;
        private TextBox txtThanhTien;
        private Button btnThemChiTietHDN;
        private Button btnSuaChiTietHDN;
        private Button btnXoaChiTietHDN;
        private Button btnLuuChiTietHDN;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label lblTongTien;

        private Button btnTaoMoiHDN;
        private Button btnThoat;
        private Button btnInHDN;
        private Button btnDuyetHDN;
        private Button btnTamLuuHDN;

        private ErrorProvider errorProvider1;
        private Panel panel1;
        private Label label7;
    }
}
