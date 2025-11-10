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
            ((System.ComponentModel.ISupportInitialize)numGiaNhap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGiaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            SuspendLayout();
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new Point(35, 30);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(98, 20);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã sản phẩm";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(150, 27);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(250, 27);
            txtMaSP.TabIndex = 1;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Location = new Point(35, 70);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(100, 20);
            lblTenSP.TabIndex = 2;
            lblTenSP.Text = "Tên sản phẩm";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(150, 67);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(250, 27);
            txtTenSP.TabIndex = 3;
            // 
            // lblGiaNhap
            // 
            lblGiaNhap.AutoSize = true;
            lblGiaNhap.Location = new Point(35, 110);
            lblGiaNhap.Name = "lblGiaNhap";
            lblGiaNhap.Size = new Size(68, 20);
            lblGiaNhap.TabIndex = 4;
            lblGiaNhap.Text = "Giá nhập";
            // 
            // numGiaNhap
            // 
            numGiaNhap.DecimalPlaces = 2;
            numGiaNhap.Location = new Point(150, 107);
            numGiaNhap.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numGiaNhap.Name = "numGiaNhap";
            numGiaNhap.Size = new Size(250, 27);
            numGiaNhap.TabIndex = 5;
            // 
            // lblGiaBan
            // 
            lblGiaBan.AutoSize = true;
            lblGiaBan.Location = new Point(35, 150);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(60, 20);
            lblGiaBan.TabIndex = 6;
            lblGiaBan.Text = "Giá bán";
            // 
            // numGiaBan
            // 
            numGiaBan.DecimalPlaces = 2;
            numGiaBan.Location = new Point(150, 147);
            numGiaBan.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numGiaBan.Name = "numGiaBan";
            numGiaBan.Size = new Size(250, 27);
            numGiaBan.TabIndex = 7;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(35, 190);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(69, 20);
            lblSoLuong.TabIndex = 8;
            lblSoLuong.Text = "Số lượng";
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(150, 187);
            numSoLuong.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(250, 27);
            numSoLuong.TabIndex = 9;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(35, 230);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(48, 20);
            lblMoTa.TabIndex = 10;
            lblMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(150, 227);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(250, 80);
            txtMoTa.TabIndex = 11;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Location = new Point(150, 320);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(103, 24);
            chkTrangThai.TabIndex = 12;
            chkTrangThai.Text = "Hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(150, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 13;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(300, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cboLoaiTui
            // 
            cboLoaiTui.Location = new Point(624, 27);
            cboLoaiTui.Name = "cboLoaiTui";
            cboLoaiTui.Size = new Size(121, 28);
            cboLoaiTui.TabIndex = 15;
            // 
            // cboThuongHieu
            // 
            cboThuongHieu.Location = new Point(624, 67);
            cboThuongHieu.Name = "cboThuongHieu";
            cboThuongHieu.Size = new Size(121, 28);
            cboThuongHieu.TabIndex = 16;
            // 
            // cboChatLieu
            // 
            cboChatLieu.Location = new Point(624, 106);
            cboChatLieu.Name = "cboChatLieu";
            cboChatLieu.Size = new Size(121, 28);
            cboChatLieu.TabIndex = 17;
            // 
            // cboMau
            // 
            cboMau.Location = new Point(624, 146);
            cboMau.Name = "cboMau";
            cboMau.Size = new Size(121, 28);
            cboMau.TabIndex = 18;
            // 
            // cboKichThuoc
            // 
            cboKichThuoc.Location = new Point(624, 187);
            cboKichThuoc.Name = "cboKichThuoc";
            cboKichThuoc.Size = new Size(121, 28);
            cboKichThuoc.TabIndex = 19;
            // 
            // cboNCC
            // 
            cboNCC.Location = new Point(624, 227);
            cboNCC.Name = "cboNCC";
            cboNCC.Size = new Size(121, 28);
            cboNCC.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(506, 70);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 22;
            label2.Text = "Thương hiệu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(506, 109);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 23;
            label3.Text = "Chất liệu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(506, 150);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 24;
            label4.Text = "Màu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(506, 190);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 25;
            label5.Text = "Kích thước";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(506, 230);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 26;
            label6.Text = "Nhà cung cấp";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(506, 30);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 27;
            label1.Text = "Loại túi";
            // 
            // SanPhamEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 430);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SanPhamEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm / Sửa Sản Phẩm";
            ((System.ComponentModel.ISupportInitialize)numGiaNhap).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
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
    }
}