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
            groupBox2 = new GroupBox();
            btnSua = new Button();
            btnXuatExel = new Button();
            btnHuy = new Button();
            btnDuyet = new Button();
            btnXem = new Button();
            btnThem = new Button();
            dgvDanhSach = new DataGridView();
            label7 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
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
            groupBox1.Location = new Point(106, 105);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(608, 323);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(202, 135);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(195, 27);
            dtpDenNgay.TabIndex = 11;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(202, 83);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(195, 27);
            dtpTuNgay.TabIndex = 10;
            // 
            // cmbSearchNhanVien
            // 
            cmbSearchNhanVien.FormattingEnabled = true;
            cmbSearchNhanVien.Location = new Point(202, 272);
            cmbSearchNhanVien.Name = "cmbSearchNhanVien";
            cmbSearchNhanVien.Size = new Size(195, 28);
            cmbSearchNhanVien.TabIndex = 9;
            // 
            // cmbSearchTrangThai
            // 
            cmbSearchTrangThai.FormattingEnabled = true;
            cmbSearchTrangThai.Location = new Point(202, 216);
            cmbSearchTrangThai.Name = "cmbSearchTrangThai";
            cmbSearchTrangThai.Size = new Size(195, 28);
            cmbSearchTrangThai.TabIndex = 8;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(438, 107);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(164, 29);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // cmbSearchNCC
            // 
            cmbSearchNCC.FormattingEnabled = true;
            cmbSearchNCC.Location = new Point(202, 168);
            cmbSearchNCC.Name = "cmbSearchNCC";
            cmbSearchNCC.Size = new Size(195, 28);
            cmbSearchNCC.TabIndex = 7;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(438, 47);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(164, 29);
            btnTimKiem.TabIndex = 0;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // cmbSearchMaHDN
            // 
            cmbSearchMaHDN.FormattingEnabled = true;
            cmbSearchMaHDN.Location = new Point(202, 36);
            cmbSearchMaHDN.Name = "cmbSearchMaHDN";
            cmbSearchMaHDN.Size = new Size(195, 28);
            cmbSearchMaHDN.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 272);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 5;
            label6.Text = "Nhân viên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 216);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 4;
            label5.Text = "Trạng thái";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 168);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 3;
            label4.Text = "Nhà cung cấp";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 129);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 2;
            label3.Text = "Đến ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 88);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 1;
            label2.Text = "Từ ngày";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 36);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã hoá đơn";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnXuatExel);
            groupBox2.Controls.Add(btnHuy);
            groupBox2.Controls.Add(btnDuyet);
            groupBox2.Controls.Add(btnXem);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Location = new Point(884, 105);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(297, 343);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chức năng";
            // 
            // btnSua
            // 
            btnSua.Location = new Point(34, 272);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(164, 29);
            btnSua.TabIndex = 7;
            btnSua.Text = "SỬA HOÁ ĐƠN";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXuatExel
            // 
            btnXuatExel.Location = new Point(34, 216);
            btnXuatExel.Name = "btnXuatExel";
            btnXuatExel.Size = new Size(164, 29);
            btnXuatExel.TabIndex = 6;
            btnXuatExel.Text = "XUẤT FILE";
            btnXuatExel.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(34, 170);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(164, 29);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Huỷ Hoá Đơn";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnDuyet
            // 
            btnDuyet.Location = new Point(34, 118);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(164, 29);
            btnDuyet.TabIndex = 4;
            btnDuyet.Text = "Duyệt hoá đơn";
            btnDuyet.UseVisualStyleBackColor = true;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // btnXem
            // 
            btnXem.Location = new Point(34, 70);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(164, 29);
            btnXem.TabIndex = 3;
            btnXem.Text = "Xem chi tiết";
            btnXem.UseVisualStyleBackColor = true;
            btnXem.Click += btnXem_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(34, 29);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(164, 29);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvDanhSach
            // 
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.AllowUserToDeleteRows = false;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSach.Location = new Point(106, 486);
            dgvDanhSach.MultiSelect = false;
            dgvDanhSach.Name = "dgvDanhSach";
            dgvDanhSach.ReadOnly = true;
            dgvDanhSach.RowHeadersWidth = 51;
            dgvDanhSach.Size = new Size(1327, 375);
            dgvDanhSach.TabIndex = 8;
            dgvDanhSach.CellClick += dgvDanhSach_CellClick;
            dgvDanhSach.SelectionChanged += dgvDanhSach_SelectionChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(550, 18);
            label7.Name = "label7";
            label7.Size = new Size(362, 38);
            label7.TabIndex = 9;
            label7.Text = "QUẢN LÍ HOÁ ĐƠN NHẬP";
            // 
            // ucHoaDonNhapList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label7);
            Controls.Add(dgvDanhSach);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ucHoaDonNhapList";
            Size = new Size(1672, 864);
            Load += ucHoaDonNhapList_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSach).EndInit();
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
        private GroupBox groupBox2;
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
    }
}