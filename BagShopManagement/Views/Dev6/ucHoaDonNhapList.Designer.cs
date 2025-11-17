namespace BagShopManagement.Views.Dev6
{
    partial class ucHoaDonNhapList
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            cmbSearchNhanVien = new ComboBox();
            cmbSearchTrangThai = new ComboBox();
            btnLamMoi = new Button();
            cmbSearchNCC = new ComboBox();
            btnTimKiem = new Button();
            cmbSearchMaHDN = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnSua = new Button();
            btnInHoaDon = new Button();
            btnXuatExel = new Button();
            btnHuy = new Button();
            btnDuyet = new Button();
            btnXem = new Button();
            btnThem = new Button();
            dgvDanhSach = new DataGridView();
            label7 = new Label();
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlLightLight;
            groupBox1.Controls.Add(dtpDenNgay);
            groupBox1.Controls.Add(dtpTuNgay);
            groupBox1.Controls.Add(cmbSearchNhanVien);
            groupBox1.Controls.Add(cmbSearchTrangThai);
            groupBox1.Controls.Add(btnLamMoi);
            groupBox1.Controls.Add(cmbSearchNCC);
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(cmbSearchMaHDN);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(51, 51, 51);
            groupBox1.Location = new Point(53, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1481, 196);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "TÌM KIẾM";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CalendarForeColor = Color.FromArgb(54, 54, 54);
            dtpDenNgay.CalendarMonthBackground = Color.FromArgb(252, 252, 252);
            dtpDenNgay.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(751, 84);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(227, 30);
            dtpDenNgay.TabIndex = 11;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CalendarForeColor = Color.FromArgb(54, 54, 54);
            dtpTuNgay.CalendarMonthBackground = Color.FromArgb(252, 252, 252);
            dtpTuNgay.Cursor = Cursors.Hand;
            dtpTuNgay.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(269, 84);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(227, 30);
            dtpTuNgay.TabIndex = 10;
            // 
            // cmbSearchNhanVien
            // 
            cmbSearchNhanVien.BackColor = Color.FromArgb(252, 252, 252);
            cmbSearchNhanVien.Cursor = Cursors.Hand;
            cmbSearchNhanVien.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSearchNhanVien.ForeColor = Color.FromArgb(51, 51, 51);
            cmbSearchNhanVien.FormattingEnabled = true;
            cmbSearchNhanVien.Location = new Point(751, 30);
            cmbSearchNhanVien.Name = "cmbSearchNhanVien";
            cmbSearchNhanVien.Size = new Size(227, 31);
            cmbSearchNhanVien.TabIndex = 9;
            // 
            // cmbSearchTrangThai
            // 
            cmbSearchTrangThai.BackColor = Color.FromArgb(252, 252, 252);
            cmbSearchTrangThai.Cursor = Cursors.Hand;
            cmbSearchTrangThai.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSearchTrangThai.ForeColor = Color.FromArgb(51, 51, 51);
            cmbSearchTrangThai.FormattingEnabled = true;
            cmbSearchTrangThai.Location = new Point(751, 140);
            cmbSearchTrangThai.Name = "cmbSearchTrangThai";
            cmbSearchTrangThai.Size = new Size(227, 31);
            cmbSearchTrangThai.TabIndex = 8;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(224, 224, 224);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.Location = new Point(1070, 115);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(132, 39);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "&LÀM MỚI";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // cmbSearchNCC
            // 
            cmbSearchNCC.BackColor = Color.FromArgb(252, 252, 252);
            cmbSearchNCC.Cursor = Cursors.Hand;
            cmbSearchNCC.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSearchNCC.ForeColor = Color.FromArgb(51, 51, 51);
            cmbSearchNCC.FormattingEnabled = true;
            cmbSearchNCC.Location = new Point(269, 139);
            cmbSearchNCC.Name = "cmbSearchNCC";
            cmbSearchNCC.Size = new Size(227, 31);
            cmbSearchNCC.TabIndex = 7;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.Highlight;
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(1070, 38);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(132, 39);
            btnTimKiem.TabIndex = 0;
            btnTimKiem.Text = "&TÌM KIẾM";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // cmbSearchMaHDN
            // 
            cmbSearchMaHDN.BackColor = Color.FromArgb(252, 252, 252);
            cmbSearchMaHDN.Cursor = Cursors.Hand;
            cmbSearchMaHDN.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSearchMaHDN.ForeColor = Color.FromArgb(51, 51, 51);
            cmbSearchMaHDN.FormattingEnabled = true;
            cmbSearchMaHDN.Location = new Point(269, 30);
            cmbSearchMaHDN.Name = "cmbSearchMaHDN";
            cmbSearchMaHDN.Size = new Size(227, 31);
            cmbSearchMaHDN.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(611, 38);
            label6.Name = "label6";
            label6.Size = new Size(89, 23);
            label6.TabIndex = 5;
            label6.Text = "Nhân viên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(611, 143);
            label5.Name = "label5";
            label5.Size = new Size(87, 23);
            label5.TabIndex = 4;
            label5.Text = "Trạng thái";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 142);
            label4.Name = "label4";
            label4.Size = new Size(117, 23);
            label4.TabIndex = 3;
            label4.Text = "Nhà cung cấp";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(611, 91);
            label3.Name = "label3";
            label3.Size = new Size(84, 23);
            label3.TabIndex = 2;
            label3.Text = "Đến ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 91);
            label2.Name = "label2";
            label2.Size = new Size(73, 23);
            label2.TabIndex = 1;
            label2.Text = "Từ ngày";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 38);
            label1.Name = "label1";
            label1.Size = new Size(148, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã hoá đơn nhập";
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(224, 224, 224);
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.ForeColor = Color.FromArgb(51, 51, 51);
            btnSua.Location = new Point(658, 13);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(132, 39);
            btnSua.TabIndex = 7;
            btnSua.Text = "&SỬA";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.BackColor = Color.Gainsboro;
            btnInHoaDon.Cursor = Cursors.Hand;
            btnInHoaDon.FlatAppearance.BorderSize = 0;
            btnInHoaDon.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnInHoaDon.FlatStyle = FlatStyle.Flat;
            btnInHoaDon.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInHoaDon.ForeColor = Color.FromArgb(51, 51, 51);
            btnInHoaDon.Location = new Point(1157, 13);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(132, 39);
            btnInHoaDon.TabIndex = 8;
            btnInHoaDon.Text = "&IN";
            btnInHoaDon.UseVisualStyleBackColor = false;
            btnInHoaDon.Click += btnInHoaDon_Click;
            // 
            // btnXuatExel
            // 
            btnXuatExel.BackColor = Color.FromArgb(224, 224, 224);
            btnXuatExel.Cursor = Cursors.Hand;
            btnXuatExel.FlatAppearance.BorderSize = 0;
            btnXuatExel.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnXuatExel.FlatStyle = FlatStyle.Flat;
            btnXuatExel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuatExel.ForeColor = Color.FromArgb(51, 51, 51);
            btnXuatExel.Location = new Point(1402, 846);
            btnXuatExel.Name = "btnXuatExel";
            btnXuatExel.Size = new Size(132, 39);
            btnXuatExel.TabIndex = 6;
            btnXuatExel.Text = "&XUẤT FILE";
            btnXuatExel.UseVisualStyleBackColor = false;
            btnXuatExel.Click += btnXuatExel_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Red;
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(916, 13);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(132, 39);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "&HUỶ";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnDuyet
            // 
            btnDuyet.BackColor = SystemColors.Highlight;
            btnDuyet.Cursor = Cursors.Hand;
            btnDuyet.FlatAppearance.BorderSize = 0;
            btnDuyet.FlatAppearance.MouseOverBackColor = Color.MidnightBlue;
            btnDuyet.FlatStyle = FlatStyle.Flat;
            btnDuyet.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDuyet.ForeColor = Color.White;
            btnDuyet.Location = new Point(389, 13);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(132, 39);
            btnDuyet.TabIndex = 4;
            btnDuyet.Text = "&DUYỆT";
            btnDuyet.UseVisualStyleBackColor = false;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.FromArgb(224, 224, 224);
            btnXem.Cursor = Cursors.Hand;
            btnXem.FlatAppearance.BorderSize = 0;
            btnXem.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXem.ForeColor = Color.FromArgb(54, 54, 54);
            btnXem.Location = new Point(155, 13);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(132, 39);
            btnXem.TabIndex = 3;
            btnXem.Text = "&CHI TIẾT";
            btnXem.UseVisualStyleBackColor = false;
            btnXem.Click += btnXem_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.Highlight;
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(1223, 846);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(132, 39);
            btnThem.TabIndex = 2;
            btnThem.Text = "&THÊM MỚI";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvDanhSach
            // 
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.AllowUserToDeleteRows = false;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDanhSach.BackgroundColor = SystemColors.ControlLight;
            dgvDanhSach.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.DodgerBlue;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDanhSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDanhSach.EnableHeadersVisualStyles = false;
            dgvDanhSach.GridColor = Color.LightGray;
            dgvDanhSach.Location = new Point(53, 381);
            dgvDanhSach.MultiSelect = false;
            dgvDanhSach.Name = "dgvDanhSach";
            dgvDanhSach.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvDanhSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDanhSach.RowHeadersVisible = false;
            dgvDanhSach.RowHeadersWidth = 51;
            dgvDanhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.Size = new Size(1481, 446);
            dgvDanhSach.TabIndex = 8;
            dgvDanhSach.CellClick += dgvDanhSach_CellClick;
            dgvDanhSach.SelectionChanged += dgvDanhSach_SelectionChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(663, 28);
            label7.Name = "label7";
            label7.Size = new Size(374, 38);
            label7.TabIndex = 9;
            label7.Text = "QUẢN LÍ HOÁ ĐƠN NHẬP";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnXem);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnDuyet);
            panel1.Controls.Add(btnInHoaDon);
            panel1.Controls.Add(btnHuy);
            panel1.Location = new Point(53, 293);
            panel1.Name = "panel1";
            panel1.Size = new Size(1481, 67);
            panel1.TabIndex = 10;
            // 
            // ucHoaDonNhapList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(label7);
            Controls.Add(dgvDanhSach);
            Controls.Add(groupBox1);
            Controls.Add(btnXuatExel);
            Controls.Add(btnThem);
            Name = "ucHoaDonNhapList";
            Size = new Size(1598, 936);
            Load += ucHoaDonNhapList_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private ComboBox cmbSearchNhanVien;
        private ComboBox cmbSearchTrangThai;
        private ComboBox cmbSearchNCC;
        private Button btnHuy;
        private Button btnDuyet;
        private Button btnXem;
        private Button btnThem;
        private Button btnLamMoi;
        private Button btnTimKiem;
        private DataGridView dgvDanhSach;
        private Label label7;
        private ComboBox cmbSearchMaHDN;
        private Button btnXuatExel;
        private Button btnSua;
        private Button btnInHoaDon;
        private Panel panel1;
    }
}