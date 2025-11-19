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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
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
            bindingSource1 = new BindingSource(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
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
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(54, 54, 54);
            groupBox1.Location = new Point(46, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1472, 189);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "THÔNG TIN CHUNG";
            // 
            // cboTrangThai
            // 
            cboTrangThai.BackColor = SystemColors.Window;
            cboTrangThai.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboTrangThai.ForeColor = Color.FromArgb(54, 54, 54);
            cboTrangThai.Location = new Point(1180, 43);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(200, 31);
            cboTrangThai.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1045, 51);
            label3.Name = "label3";
            label3.Size = new Size(87, 23);
            label3.TabIndex = 5;
            label3.Text = "Trạng thái";
            // 
            // txtGhiChu
            // 
            txtGhiChu.BackColor = SystemColors.Window;
            txtGhiChu.Cursor = Cursors.Hand;
            txtGhiChu.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGhiChu.ForeColor = Color.FromArgb(54, 54, 54);
            txtGhiChu.Location = new Point(685, 109);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(200, 30);
            txtGhiChu.TabIndex = 6;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.CalendarFont = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgayNhap.Cursor = Cursors.Hand;
            dtpNgayNhap.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgayNhap.Format = DateTimePickerFormat.Short;
            dtpNgayNhap.Location = new Point(685, 44);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(200, 30);
            dtpNgayNhap.TabIndex = 7;
            dtpNgayNhap.ValueChanged += dtpNgayNhap_ValueChanged;
            // 
            // cboNhanVien
            // 
            cboNhanVien.BackColor = SystemColors.Window;
            cboNhanVien.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboNhanVien.ForeColor = Color.FromArgb(54, 54, 54);
            cboNhanVien.Location = new Point(1179, 108);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(200, 31);
            cboNhanVien.TabIndex = 8;
            cboNhanVien.SelectedIndexChanged += cboNhanVien_SelectedIndexChanged;
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.BackColor = SystemColors.Window;
            cboNhaCungCap.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboNhaCungCap.ForeColor = Color.FromArgb(54, 54, 54);
            cboNhaCungCap.Location = new Point(243, 108);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(200, 31);
            cboNhaCungCap.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(1045, 116);
            label6.Name = "label6";
            label6.Size = new Size(89, 23);
            label6.TabIndex = 11;
            label6.Text = "Nhân viên";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(533, 51);
            label5.Name = "label5";
            label5.Size = new Size(95, 23);
            label5.TabIndex = 12;
            label5.Text = "Ngày nhập";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(533, 116);
            label4.Name = "label4";
            label4.Size = new Size(69, 23);
            label4.TabIndex = 13;
            label4.Text = "Ghi chú";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(41, 116);
            label2.Name = "label2";
            label2.Size = new Size(117, 23);
            label2.TabIndex = 14;
            label2.Text = "Nhà cung cấp";
            // 
            // txtMaHDN
            // 
            txtMaHDN.BackColor = SystemColors.Control;
            txtMaHDN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaHDN.ForeColor = Color.FromArgb(54, 54, 54);
            txtMaHDN.Location = new Point(243, 44);
            txtMaHDN.Name = "txtMaHDN";
            txtMaHDN.ReadOnly = true;
            txtMaHDN.Size = new Size(200, 30);
            txtMaHDN.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 51);
            label1.Name = "label1";
            label1.Size = new Size(148, 23);
            label1.TabIndex = 16;
            label1.Text = "Mã hoá đơn nhập";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.Window;
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
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.FromArgb(54, 54, 54);
            groupBox2.Location = new Point(46, 276);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1472, 494);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "CHI TIẾT HOÁ ĐƠN";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongTien.ForeColor = Color.Red;
            lblTongTien.Location = new Point(155, 439);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(22, 25);
            lblTongTien.TabIndex = 0;
            lblTongTien.Text = "0";
            // 
            // txtThanhTien
            // 
            txtThanhTien.Font = new Font("Segoe UI", 10.2F);
            txtThanhTien.ForeColor = Color.FromArgb(54, 54, 54);
            txtThanhTien.Location = new Point(1106, 239);
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.ReadOnly = true;
            txtThanhTien.Size = new Size(241, 30);
            txtThanhTien.TabIndex = 1;
            // 
            // txtDonGia
            // 
            txtDonGia.Cursor = Cursors.Hand;
            txtDonGia.Font = new Font("Segoe UI", 10.2F);
            txtDonGia.ForeColor = Color.FromArgb(54, 54, 54);
            txtDonGia.Location = new Point(1106, 177);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(241, 30);
            txtDonGia.TabIndex = 2;
            txtDonGia.TextChanged += txtDonGia_TextChanged;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Cursor = Cursors.Hand;
            txtSoLuong.Font = new Font("Segoe UI", 10.2F);
            txtSoLuong.ForeColor = Color.FromArgb(54, 54, 54);
            txtSoLuong.Location = new Point(1106, 116);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(241, 30);
            txtSoLuong.TabIndex = 3;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            // 
            // cboSanPham
            // 
            cboSanPham.Cursor = Cursors.Hand;
            cboSanPham.Font = new Font("Segoe UI", 10.2F);
            cboSanPham.ForeColor = Color.FromArgb(54, 54, 54);
            cboSanPham.Location = new Point(1106, 47);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(241, 31);
            cboSanPham.TabIndex = 4;
            // 
            // btnLuuChiTietHDN
            // 
            btnLuuChiTietHDN.BackColor = Color.DodgerBlue;
            btnLuuChiTietHDN.Cursor = Cursors.Hand;
            btnLuuChiTietHDN.FlatAppearance.BorderSize = 0;
            btnLuuChiTietHDN.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnLuuChiTietHDN.FlatStyle = FlatStyle.Flat;
            btnLuuChiTietHDN.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLuuChiTietHDN.ForeColor = Color.White;
            btnLuuChiTietHDN.Location = new Point(1272, 340);
            btnLuuChiTietHDN.Name = "btnLuuChiTietHDN";
            btnLuuChiTietHDN.Size = new Size(119, 46);
            btnLuuChiTietHDN.TabIndex = 5;
            btnLuuChiTietHDN.Text = "LƯU";
            btnLuuChiTietHDN.UseVisualStyleBackColor = false;
            btnLuuChiTietHDN.Click += btnLuuChiTietHDN_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(37, 439);
            label14.Name = "label14";
            label14.Size = new Size(99, 25);
            label14.TabIndex = 6;
            label14.Text = "Tổng tiền:";
            // 
            // btnXoaChiTietHDN
            // 
            btnXoaChiTietHDN.BackColor = Color.Red;
            btnXoaChiTietHDN.Cursor = Cursors.Hand;
            btnXoaChiTietHDN.FlatAppearance.BorderSize = 0;
            btnXoaChiTietHDN.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnXoaChiTietHDN.FlatStyle = FlatStyle.Flat;
            btnXoaChiTietHDN.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXoaChiTietHDN.ForeColor = Color.White;
            btnXoaChiTietHDN.Location = new Point(985, 340);
            btnXoaChiTietHDN.Name = "btnXoaChiTietHDN";
            btnXoaChiTietHDN.Size = new Size(119, 46);
            btnXoaChiTietHDN.TabIndex = 7;
            btnXoaChiTietHDN.Text = "XOÁ";
            btnXoaChiTietHDN.UseVisualStyleBackColor = false;
            btnXoaChiTietHDN.Click += btnXoaChiTietHDN_Click;
            // 
            // btnSuaChiTietHDN
            // 
            btnSuaChiTietHDN.BackColor = Color.FromArgb(224, 224, 224);
            btnSuaChiTietHDN.Cursor = Cursors.Hand;
            btnSuaChiTietHDN.FlatAppearance.BorderSize = 0;
            btnSuaChiTietHDN.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnSuaChiTietHDN.FlatStyle = FlatStyle.Flat;
            btnSuaChiTietHDN.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSuaChiTietHDN.Location = new Point(1129, 340);
            btnSuaChiTietHDN.Name = "btnSuaChiTietHDN";
            btnSuaChiTietHDN.Size = new Size(119, 46);
            btnSuaChiTietHDN.TabIndex = 8;
            btnSuaChiTietHDN.Text = "SỬA";
            btnSuaChiTietHDN.UseVisualStyleBackColor = false;
            btnSuaChiTietHDN.Click += btnSuaChiTietHDN_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(925, 184);
            label13.Name = "label13";
            label13.Size = new Size(70, 23);
            label13.TabIndex = 9;
            label13.Text = "Đơn giá";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(925, 246);
            label12.Name = "label12";
            label12.Size = new Size(92, 23);
            label12.TabIndex = 10;
            label12.Text = "Thành tiền";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(925, 123);
            label11.Name = "label11";
            label11.Size = new Size(79, 23);
            label11.TabIndex = 11;
            label11.Text = "Số lượng";
            // 
            // btnThemChiTietHDN
            // 
            btnThemChiTietHDN.BackColor = Color.FromArgb(224, 224, 224);
            btnThemChiTietHDN.Cursor = Cursors.Hand;
            btnThemChiTietHDN.FlatAppearance.BorderSize = 0;
            btnThemChiTietHDN.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            btnThemChiTietHDN.FlatStyle = FlatStyle.Flat;
            btnThemChiTietHDN.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThemChiTietHDN.ForeColor = Color.FromArgb(54, 54, 54);
            btnThemChiTietHDN.Location = new Point(848, 340);
            btnThemChiTietHDN.Name = "btnThemChiTietHDN";
            btnThemChiTietHDN.Size = new Size(119, 46);
            btnThemChiTietHDN.TabIndex = 12;
            btnThemChiTietHDN.Text = "LÀM MỚI";
            btnThemChiTietHDN.UseVisualStyleBackColor = false;
            btnThemChiTietHDN.Click += btnThemChiTietHDN_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.FromArgb(54, 54, 54);
            label10.Location = new Point(925, 55);
            label10.Name = "label10";
            label10.Size = new Size(87, 23);
            label10.TabIndex = 13;
            label10.Text = "Sản phẩm";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.AllowUserToResizeColumns = false;
            dgvChiTiet.AllowUserToResizeRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvChiTiet.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvChiTiet.ColumnHeadersHeight = 29;
            dgvChiTiet.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(54, 54, 54);
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle2;
            dgvChiTiet.EnableHeadersVisualStyles = false;
            dgvChiTiet.GridColor = Color.LightGray;
            dgvChiTiet.Location = new Point(37, 42);
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvChiTiet.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(730, 363);
            dgvChiTiet.TabIndex = 14;
            dgvChiTiet.CellClick += dgvChiTiet_CellClick;
            // 
            // btnTaoMoiHDN
            // 
            btnTaoMoiHDN.BackColor = Color.FromArgb(224, 224, 224);
            btnTaoMoiHDN.Cursor = Cursors.Hand;
            btnTaoMoiHDN.FlatAppearance.BorderSize = 0;
            btnTaoMoiHDN.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnTaoMoiHDN.FlatStyle = FlatStyle.Flat;
            btnTaoMoiHDN.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnTaoMoiHDN.ForeColor = Color.FromArgb(54, 54, 54);
            btnTaoMoiHDN.Location = new Point(135, 35);
            btnTaoMoiHDN.Name = "btnTaoMoiHDN";
            btnTaoMoiHDN.Size = new Size(132, 45);
            btnTaoMoiHDN.TabIndex = 2;
            btnTaoMoiHDN.Text = "TẠO MỚI";
            btnTaoMoiHDN.UseVisualStyleBackColor = false;
            btnTaoMoiHDN.Click += btnTaoMoiHDN_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(224, 224, 224);
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThoat.ForeColor = Color.FromArgb(54, 54, 54);
            btnThoat.Location = new Point(1201, 35);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(132, 45);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "QUAY LẠI";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnInHDN
            // 
            btnInHDN.BackColor = Color.DodgerBlue;
            btnInHDN.Cursor = Cursors.Hand;
            btnInHDN.FlatAppearance.BorderSize = 0;
            btnInHDN.FlatStyle = FlatStyle.Flat;
            btnInHDN.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnInHDN.ForeColor = Color.White;
            btnInHDN.Location = new Point(925, 35);
            btnInHDN.Name = "btnInHDN";
            btnInHDN.Size = new Size(147, 45);
            btnInHDN.TabIndex = 4;
            btnInHDN.Text = "IN HOÁ ĐƠN";
            btnInHDN.UseVisualStyleBackColor = false;
            btnInHDN.Click += btnInHDN_Click;
            // 
            // btnDuyetHDN
            // 
            btnDuyetHDN.BackColor = Color.FromArgb(224, 224, 224);
            btnDuyetHDN.Cursor = Cursors.Hand;
            btnDuyetHDN.FlatAppearance.BorderSize = 0;
            btnDuyetHDN.FlatAppearance.MouseOverBackColor = Color.Cyan;
            btnDuyetHDN.FlatStyle = FlatStyle.Flat;
            btnDuyetHDN.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnDuyetHDN.ForeColor = Color.FromArgb(54, 54, 54);
            btnDuyetHDN.Location = new Point(659, 35);
            btnDuyetHDN.Name = "btnDuyetHDN";
            btnDuyetHDN.Size = new Size(132, 45);
            btnDuyetHDN.TabIndex = 6;
            btnDuyetHDN.Text = "DUYỆT";
            btnDuyetHDN.UseVisualStyleBackColor = false;
            btnDuyetHDN.Click += btnDuyetHDN_Click;
            // 
            // btnTamLuuHDN
            // 
            btnTamLuuHDN.BackColor = Color.DodgerBlue;
            btnTamLuuHDN.Cursor = Cursors.Hand;
            btnTamLuuHDN.FlatAppearance.BorderSize = 0;
            btnTamLuuHDN.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnTamLuuHDN.FlatStyle = FlatStyle.Flat;
            btnTamLuuHDN.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnTamLuuHDN.ForeColor = Color.White;
            btnTamLuuHDN.Location = new Point(389, 35);
            btnTamLuuHDN.Name = "btnTamLuuHDN";
            btnTamLuuHDN.Size = new Size(132, 45);
            btnTamLuuHDN.TabIndex = 5;
            btnTamLuuHDN.Text = "TẠM LƯU";
            btnTamLuuHDN.UseVisualStyleBackColor = false;
            btnTamLuuHDN.Click += btnTamLuuHDN_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(54, 54, 54);
            label7.Location = new Point(683, 13);
            label7.Name = "label7";
            label7.Size = new Size(314, 38);
            label7.TabIndex = 17;
            label7.Text = "THÊM HOÁ ĐƠN MỚI";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnTaoMoiHDN);
            panel1.Controls.Add(btnInHDN);
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnDuyetHDN);
            panel1.Controls.Add(btnTamLuuHDN);
            panel1.Location = new Point(46, 800);
            panel1.Name = "panel1";
            panel1.Size = new Size(1472, 116);
            panel1.TabIndex = 15;
            // 
            // ucThemHDN
            // 
            BackColor = SystemColors.Control;
            Controls.Add(panel1);
            Controls.Add(label7);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "ucThemHDN";
            Size = new Size(1591, 964);
            Load += ucChiTietHDN_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
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

        private GroupBox groupBox2;
        private DataGridView dgvChiTiet;
        private ComboBox cboSanPham;
        private TextBox txtSoLuong;
        private TextBox txtDonGia;
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
        private TextBox txtThanhTien;
        private BindingSource bindingSource1;
    }
}
