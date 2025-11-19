namespace BagShopManagement.Views.Dev2
{
    partial class SanPhamEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblGiaNhap = new Label();
            numGiaNhap = new NumericUpDown();
            lblGiaBan = new Label();
            numGiaBan = new NumericUpDown();
            lblSoLuong = new Label();
            numSoLuong = new NumericUpDown();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            chkTrangThai = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            cboLoaiTui = new ComboBox();
            cboThuongHieu = new ComboBox();
            cboChatLieu = new ComboBox();
            cboMau = new ComboBox();
            cboKichThuoc = new ComboBox();
            cboNCC = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label1 = new Label();
            btnChonAnh = new Button();
            txtAnhChinh = new TextBox();
            picAnhChinh = new PictureBox();
            label7 = new Label();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numGiaNhap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGiaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAnhChinh).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblMaSP.ForeColor = Color.FromArgb(51, 51, 51);
            lblMaSP.Location = new Point(25, 34);
            lblMaSP.Margin = new Padding(4, 0, 4, 0);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(115, 23);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã sản phẩm";
            // 
            // txtMaSP
            // 
            txtMaSP.BackColor = SystemColors.Control;
            txtMaSP.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaSP.Location = new Point(163, 31);
            txtMaSP.Margin = new Padding(4, 3, 4, 3);
            txtMaSP.Multiline = true;
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(341, 31);
            txtMaSP.TabIndex = 1;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblTenSP.ForeColor = Color.FromArgb(51, 51, 51);
            lblTenSP.Location = new Point(25, 80);
            lblTenSP.Margin = new Padding(4, 0, 4, 0);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(116, 23);
            lblTenSP.TabIndex = 2;
            lblTenSP.Text = "Tên sản phẩm";
            // 
            // txtTenSP
            // 
            txtTenSP.BackColor = SystemColors.Control;
            txtTenSP.ForeColor = Color.FromArgb(51, 51, 51);
            txtTenSP.Location = new Point(163, 77);
            txtTenSP.Margin = new Padding(4, 3, 4, 3);
            txtTenSP.Multiline = true;
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(341, 31);
            txtTenSP.TabIndex = 3;
            // 
            // lblGiaNhap
            // 
            lblGiaNhap.AutoSize = true;
            lblGiaNhap.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblGiaNhap.ForeColor = Color.FromArgb(51, 51, 51);
            lblGiaNhap.Location = new Point(25, 126);
            lblGiaNhap.Margin = new Padding(4, 0, 4, 0);
            lblGiaNhap.Name = "lblGiaNhap";
            lblGiaNhap.Size = new Size(79, 23);
            lblGiaNhap.TabIndex = 4;
            lblGiaNhap.Text = "Giá nhập";
            // 
            // numGiaNhap
            // 
            numGiaNhap.BackColor = SystemColors.Control;
            numGiaNhap.Cursor = Cursors.Hand;
            numGiaNhap.DecimalPlaces = 2;
            numGiaNhap.ForeColor = Color.FromArgb(51, 51, 51);
            numGiaNhap.Location = new Point(163, 123);
            numGiaNhap.Margin = new Padding(4, 3, 4, 3);
            numGiaNhap.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numGiaNhap.Name = "numGiaNhap";
            numGiaNhap.Size = new Size(341, 30);
            numGiaNhap.TabIndex = 5;
            // 
            // lblGiaBan
            // 
            lblGiaBan.AutoSize = true;
            lblGiaBan.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblGiaBan.ForeColor = Color.FromArgb(51, 51, 51);
            lblGiaBan.Location = new Point(25, 172);
            lblGiaBan.Margin = new Padding(4, 0, 4, 0);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(69, 23);
            lblGiaBan.TabIndex = 6;
            lblGiaBan.Text = "Giá bán";
            // 
            // numGiaBan
            // 
            numGiaBan.BackColor = SystemColors.Control;
            numGiaBan.Cursor = Cursors.Hand;
            numGiaBan.DecimalPlaces = 2;
            numGiaBan.ForeColor = Color.FromArgb(51, 51, 51);
            numGiaBan.Location = new Point(163, 168);
            numGiaBan.Margin = new Padding(4, 3, 4, 3);
            numGiaBan.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numGiaBan.Name = "numGiaBan";
            numGiaBan.Size = new Size(341, 30);
            numGiaBan.TabIndex = 7;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblSoLuong.ForeColor = Color.FromArgb(51, 51, 51);
            lblSoLuong.Location = new Point(25, 218);
            lblSoLuong.Margin = new Padding(4, 0, 4, 0);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(79, 23);
            lblSoLuong.TabIndex = 8;
            lblSoLuong.Text = "Số lượng";
            // 
            // numSoLuong
            // 
            numSoLuong.BackColor = SystemColors.Control;
            numSoLuong.Cursor = Cursors.Hand;
            numSoLuong.ForeColor = Color.FromArgb(51, 51, 51);
            numSoLuong.Location = new Point(163, 213);
            numSoLuong.Margin = new Padding(4, 3, 4, 3);
            numSoLuong.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(341, 30);
            numSoLuong.TabIndex = 9;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblMoTa.ForeColor = Color.FromArgb(51, 51, 51);
            lblMoTa.Location = new Point(25, 586);
            lblMoTa.Margin = new Padding(4, 0, 4, 0);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(56, 23);
            lblMoTa.TabIndex = 10;
            lblMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            txtMoTa.BackColor = SystemColors.Control;
            txtMoTa.ForeColor = Color.FromArgb(51, 51, 51);
            txtMoTa.Location = new Point(163, 580);
            txtMoTa.Margin = new Padding(4, 3, 4, 3);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(341, 104);
            txtMoTa.TabIndex = 11;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            chkTrangThai.ForeColor = Color.FromArgb(51, 51, 51);
            chkTrangThai.Location = new Point(549, 589);
            chkTrangThai.Margin = new Padding(4, 3, 4, 3);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(115, 27);
            chkTrangThai.TabIndex = 12;
            chkTrangThai.Text = "Hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Highlight;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(549, 629);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 60);
            btnSave.TabIndex = 13;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(781, 629);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 60);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // cboLoaiTui
            // 
            cboLoaiTui.BackColor = SystemColors.Control;
            cboLoaiTui.Cursor = Cursors.Hand;
            cboLoaiTui.FlatStyle = FlatStyle.Popup;
            cboLoaiTui.ForeColor = Color.FromArgb(51, 51, 51);
            cboLoaiTui.Location = new Point(163, 258);
            cboLoaiTui.Margin = new Padding(4, 3, 4, 3);
            cboLoaiTui.Name = "cboLoaiTui";
            cboLoaiTui.Size = new Size(341, 31);
            cboLoaiTui.TabIndex = 15;
            // 
            // cboThuongHieu
            // 
            cboThuongHieu.BackColor = SystemColors.Control;
            cboThuongHieu.Cursor = Cursors.Hand;
            cboThuongHieu.FlatStyle = FlatStyle.Popup;
            cboThuongHieu.ForeColor = Color.FromArgb(51, 51, 51);
            cboThuongHieu.Location = new Point(163, 304);
            cboThuongHieu.Margin = new Padding(4, 3, 4, 3);
            cboThuongHieu.Name = "cboThuongHieu";
            cboThuongHieu.Size = new Size(341, 31);
            cboThuongHieu.TabIndex = 16;
            // 
            // cboChatLieu
            // 
            cboChatLieu.BackColor = SystemColors.Control;
            cboChatLieu.Cursor = Cursors.Hand;
            cboChatLieu.FlatStyle = FlatStyle.Popup;
            cboChatLieu.ForeColor = Color.FromArgb(51, 51, 51);
            cboChatLieu.Location = new Point(163, 350);
            cboChatLieu.Margin = new Padding(4, 3, 4, 3);
            cboChatLieu.Name = "cboChatLieu";
            cboChatLieu.Size = new Size(341, 31);
            cboChatLieu.TabIndex = 17;
            // 
            // cboMau
            // 
            cboMau.BackColor = SystemColors.Control;
            cboMau.Cursor = Cursors.Hand;
            cboMau.FlatStyle = FlatStyle.Popup;
            cboMau.ForeColor = Color.FromArgb(51, 51, 51);
            cboMau.Location = new Point(163, 396);
            cboMau.Margin = new Padding(4, 3, 4, 3);
            cboMau.Name = "cboMau";
            cboMau.Size = new Size(341, 31);
            cboMau.TabIndex = 18;
            // 
            // cboKichThuoc
            // 
            cboKichThuoc.BackColor = SystemColors.Control;
            cboKichThuoc.Cursor = Cursors.Hand;
            cboKichThuoc.FlatStyle = FlatStyle.Popup;
            cboKichThuoc.ForeColor = Color.FromArgb(51, 51, 51);
            cboKichThuoc.Location = new Point(163, 442);
            cboKichThuoc.Margin = new Padding(4, 3, 4, 3);
            cboKichThuoc.Name = "cboKichThuoc";
            cboKichThuoc.Size = new Size(341, 31);
            cboKichThuoc.TabIndex = 19;
            // 
            // cboNCC
            // 
            cboNCC.BackColor = SystemColors.Control;
            cboNCC.Cursor = Cursors.Hand;
            cboNCC.FlatStyle = FlatStyle.Popup;
            cboNCC.ForeColor = Color.FromArgb(51, 51, 51);
            cboNCC.Location = new Point(163, 488);
            cboNCC.Margin = new Padding(4, 3, 4, 3);
            cboNCC.Name = "cboNCC";
            cboNCC.Size = new Size(341, 31);
            cboNCC.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(51, 51, 51);
            label2.Location = new Point(25, 310);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 23);
            label2.TabIndex = 22;
            label2.Text = "Thương hiệu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(51, 51, 51);
            label3.Location = new Point(25, 356);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(78, 23);
            label3.TabIndex = 23;
            label3.Text = "Chất liệu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(51, 51, 51);
            label4.Location = new Point(25, 402);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(45, 23);
            label4.TabIndex = 24;
            label4.Text = "Màu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(51, 51, 51);
            label5.Location = new Point(25, 448);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(92, 23);
            label5.TabIndex = 25;
            label5.Text = "Kích thước";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(51, 51, 51);
            label6.Location = new Point(25, 494);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(117, 23);
            label6.TabIndex = 26;
            label6.Text = "Nhà cung cấp";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(25, 264);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 23);
            label1.TabIndex = 27;
            label1.Text = "Loại túi";
            // 
            // btnChonAnh
            // 
            btnChonAnh.BackColor = Color.FromArgb(64, 78, 103);
            btnChonAnh.FlatStyle = FlatStyle.Flat;
            btnChonAnh.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(1013, 629);
            btnChonAnh.Margin = new Padding(4, 3, 4, 3);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(200, 60);
            btnChonAnh.TabIndex = 28;
            btnChonAnh.Text = "Chọn Ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // txtAnhChinh
            // 
            txtAnhChinh.BackColor = SystemColors.Control;
            txtAnhChinh.ForeColor = Color.FromArgb(51, 51, 51);
            txtAnhChinh.Location = new Point(163, 534);
            txtAnhChinh.Margin = new Padding(4, 3, 4, 3);
            txtAnhChinh.Multiline = true;
            txtAnhChinh.Name = "txtAnhChinh";
            txtAnhChinh.Size = new Size(341, 31);
            txtAnhChinh.TabIndex = 29;
            // 
            // picAnhChinh
            // 
            picAnhChinh.Location = new Point(18, 30);
            picAnhChinh.Margin = new Padding(4, 3, 4, 3);
            picAnhChinh.Name = "picAnhChinh";
            picAnhChinh.Size = new Size(665, 501);
            picAnhChinh.TabIndex = 30;
            picAnhChinh.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(51, 51, 51);
            label7.Location = new Point(25, 540);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(70, 23);
            label7.TabIndex = 31;
            label7.Text = "Tên ảnh";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(picAnhChinh);
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox1.ForeColor = Color.FromArgb(51, 51, 51);
            groupBox1.Location = new Point(531, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(701, 543);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ảnh sản phẩm";
            // 
            // SanPhamEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1244, 704);
            Controls.Add(groupBox1);
            Controls.Add(label7);
            Controls.Add(txtAnhChinh);
            Controls.Add(btnChonAnh);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkTrangThai);
            Controls.Add(txtMoTa);
            Controls.Add(lblMoTa);
            Controls.Add(numSoLuong);
            Controls.Add(lblSoLuong);
            Controls.Add(numGiaBan);
            Controls.Add(lblGiaBan);
            Controls.Add(numGiaNhap);
            Controls.Add(lblGiaNhap);
            Controls.Add(txtTenSP);
            Controls.Add(lblTenSP);
            Controls.Add(txtMaSP);
            Controls.Add(lblMaSP);
            Controls.Add(cboLoaiTui);
            Controls.Add(cboThuongHieu);
            Controls.Add(cboChatLieu);
            Controls.Add(cboMau);
            Controls.Add(cboKichThuoc);
            Controls.Add(cboNCC);
            Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SanPhamEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm / Sửa Sản Phẩm";
            ((System.ComponentModel.ISupportInitialize)numGiaNhap).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAnhChinh).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblGiaNhap;
        private System.Windows.Forms.NumericUpDown numGiaNhap;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.NumericUpDown numGiaBan;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private ComboBox cboLoaiTui;
        private ComboBox cboThuongHieu;
        private ComboBox cboChatLieu;
        private ComboBox cboMau;
        private ComboBox cboKichThuoc;
        private ComboBox cboNCC;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label1;
        private Button btnChonAnh;
        private TextBox txtAnhChinh;
        private PictureBox picAnhChinh;
        private Label label7;
        private GroupBox groupBox1;
    }
}