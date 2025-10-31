namespace BagShopManagement.Views.Dev6
{
    partial class HoaDonNhapControl
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnTimKiem = new Button();
            label6 = new Label();
            textBox1 = new TextBox();
            cboNhanVien = new ComboBox();
            label5 = new Label();
            cboNhaCungCap = new ComboBox();
            label4 = new Label();
            dtpDenNgay = new DateTimePicker();
            label3 = new Label();
            dtpTuNgay = new DateTimePicker();
            label2 = new Label();
            btnThemMoi = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            dgvHoaDonNhap = new DataGridView();
            statusStrip1 = new StatusStrip();
            tsslTongCong = new ToolStripStatusLabel();
            btnChiTiet = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDonNhap).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(559, 11);
            label1.Name = "label1";
            label1.Size = new Size(362, 38);
            label1.TabIndex = 1;
            label1.Text = "QUẢN LÍ HOÁ ĐƠN NHẬP";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(cboNhanVien);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cboNhaCungCap);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtpDenNgay);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpTuNgay);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(52, 77);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1133, 209);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm và lọc";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(579, 16);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(182, 29);
            btnTimKiem.TabIndex = 10;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 25);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 9;
            label6.Text = "Mã HDN";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(177, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 27);
            textBox1.TabIndex = 8;
            // 
            // cboNhanVien
            // 
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(579, 107);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(182, 28);
            cboNhanVien.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(427, 110);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 6;
            label5.Text = "Nhân viên";
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(177, 102);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(182, 28);
            cboNhaCungCap.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 110);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 4;
            label4.Text = "Nhà cung cấp";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(579, 62);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(182, 27);
            dtpDenNgay.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(427, 60);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 2;
            label3.Text = "Đến ngày";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(177, 60);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(182, 27);
            dtpTuNgay.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 67);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 0;
            label2.Text = "Từ ngày";
            // 
            // btnThemMoi
            // 
            btnThemMoi.FlatStyle = FlatStyle.Flat;
            btnThemMoi.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemMoi.Location = new Point(1219, 127);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(132, 46);
            btnThemMoi.TabIndex = 3;
            btnThemMoi.Text = "Thêm mới";
            btnThemMoi.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(1219, 209);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(132, 46);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(1390, 127);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(135, 46);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // dgvHoaDonNhap
            // 
            dgvHoaDonNhap.AllowUserToAddRows = false;
            dgvHoaDonNhap.AllowUserToDeleteRows = false;
            dgvHoaDonNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDonNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDonNhap.Location = new Point(52, 306);
            dgvHoaDonNhap.Name = "dgvHoaDonNhap";
            dgvHoaDonNhap.ReadOnly = true;
            dgvHoaDonNhap.RowHeadersWidth = 51;
            dgvHoaDonNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDonNhap.Size = new Size(1473, 507);
            dgvHoaDonNhap.TabIndex = 6;
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.None;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslTongCong });
            statusStrip1.Location = new Point(52, 853);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(208, 26);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslTongCong
            // 
            tsslTongCong.Name = "tsslTongCong";
            tsslTongCong.Size = new Size(191, 20);
            tsslTongCong.Text = "Tổng cộng: 0 hóa đơn nhập";
            // 
            // btnChiTiet
            // 
            btnChiTiet.FlatStyle = FlatStyle.Flat;
            btnChiTiet.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChiTiet.Location = new Point(1390, 209);
            btnChiTiet.Name = "btnChiTiet";
            btnChiTiet.Size = new Size(135, 46);
            btnChiTiet.TabIndex = 8;
            btnChiTiet.Text = "Chi tiết";
            btnChiTiet.UseVisualStyleBackColor = true;
            btnChiTiet.UseWaitCursor = true;
            // 
            // HoaDonNhapControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnChiTiet);
            Controls.Add(statusStrip1);
            Controls.Add(dgvHoaDonNhap);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThemMoi);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "HoaDonNhapControl";
            Size = new Size(1604, 959);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDonNhap).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button btnTimKiem;
        private Label label6;
        private TextBox textBox1;
        private ComboBox cboNhanVien;
        private Label label5;
        private ComboBox cboNhaCungCap;
        private Label label4;
        private DateTimePicker dtpDenNgay;
        private Label label3;
        private DateTimePicker dtpTuNgay;
        private Label label2;
        private Button btnThemMoi;
        private Button btnSua;
        private Button btnXoa;
        private DataGridView dgvHoaDonNhap;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslTongCong;
        private Button btnChiTiet;
    }
}
