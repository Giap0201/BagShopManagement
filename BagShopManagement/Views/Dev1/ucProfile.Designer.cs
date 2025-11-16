namespace BagShopManagement.Views.Dev1
{
    partial class ucProfile
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
            lblTitle = new Label();
            grpThongTin = new GroupBox();
            txtVaiTro = new TextBox();
            txtTenDangNhap = new TextBox();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtChucVu = new TextBox();
            txtHoTen = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            grpDoiMatKhau = new GroupBox();
            btnDoiMatKhau = new Button();
            txtXacNhanMoi = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtMatKhauCu = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            btnLamMoi = new Button();
            grpThongTin.SuspendLayout();
            grpDoiMatKhau.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(346, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(310, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN CÁ NHÂN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(txtVaiTro);
            grpThongTin.Controls.Add(txtTenDangNhap);
            grpThongTin.Controls.Add(txtSoDienThoai);
            grpThongTin.Controls.Add(txtEmail);
            grpThongTin.Controls.Add(txtChucVu);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(label6);
            grpThongTin.Controls.Add(label5);
            grpThongTin.Controls.Add(label4);
            grpThongTin.Controls.Add(label3);
            grpThongTin.Controls.Add(label2);
            grpThongTin.Controls.Add(label1);
            grpThongTin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpThongTin.Location = new Point(0, 72);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(468, 451);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin chung";
            grpThongTin.Enter += GroupBox1_Enter;
            // 
            // txtVaiTro
            // 
            txtVaiTro.Location = new Point(187, 372);
            txtVaiTro.Name = "txtVaiTro";
            txtVaiTro.ReadOnly = true;
            txtVaiTro.Size = new Size(116, 30);
            txtVaiTro.TabIndex = 11;
            txtVaiTro.TabStop = false;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(187, 308);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.ReadOnly = true;
            txtTenDangNhap.Size = new Size(216, 30);
            txtTenDangNhap.TabIndex = 10;
            txtTenDangNhap.TabStop = false;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(187, 250);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.ReadOnly = true;
            txtSoDienThoai.Size = new Size(176, 30);
            txtSoDienThoai.TabIndex = 9;
            txtSoDienThoai.TabStop = false;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(187, 187);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(116, 30);
            txtEmail.TabIndex = 8;
            txtEmail.TabStop = false;
            // 
            // txtChucVu
            // 
            txtChucVu.Location = new Point(187, 128);
            txtChucVu.Name = "txtChucVu";
            txtChucVu.ReadOnly = true;
            txtChucVu.Size = new Size(116, 30);
            txtChucVu.TabIndex = 7;
            txtChucVu.TabStop = false;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(187, 73);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.ReadOnly = true;
            txtHoTen.Size = new Size(216, 30);
            txtHoTen.TabIndex = 6;
            txtHoTen.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 379);
            label6.Name = "label6";
            label6.Size = new Size(64, 23);
            label6.TabIndex = 5;
            label6.Text = "Vai trò:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 311);
            label5.Name = "label5";
            label5.Size = new Size(128, 23);
            label5.TabIndex = 4;
            label5.Text = "Tên đăng nhập:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 250);
            label4.Name = "label4";
            label4.Size = new Size(44, 23);
            label4.TabIndex = 3;
            label4.Text = "SĐT:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 187);
            label3.Name = "label3";
            label3.Size = new Size(55, 23);
            label3.TabIndex = 2;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 131);
            label2.Name = "label2";
            label2.Size = new Size(76, 23);
            label2.TabIndex = 1;
            label2.Text = "Chức vụ:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 73);
            label1.Name = "label1";
            label1.Size = new Size(71, 23);
            label1.TabIndex = 0;
            label1.Text = "Họ tên: ";
            // 
            // grpDoiMatKhau
            // 
            grpDoiMatKhau.Controls.Add(btnDoiMatKhau);
            grpDoiMatKhau.Controls.Add(txtXacNhanMoi);
            grpDoiMatKhau.Controls.Add(txtMatKhauMoi);
            grpDoiMatKhau.Controls.Add(txtMatKhauCu);
            grpDoiMatKhau.Controls.Add(label9);
            grpDoiMatKhau.Controls.Add(label8);
            grpDoiMatKhau.Controls.Add(label7);
            grpDoiMatKhau.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpDoiMatKhau.Location = new Point(517, 72);
            grpDoiMatKhau.Name = "grpDoiMatKhau";
            grpDoiMatKhau.Size = new Size(468, 451);
            grpDoiMatKhau.TabIndex = 2;
            grpDoiMatKhau.TabStop = false;
            grpDoiMatKhau.Text = "Đổi mật khẩu";
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.BackColor = SystemColors.Highlight;
            btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            btnDoiMatKhau.FlatStyle = FlatStyle.Flat;
            btnDoiMatKhau.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDoiMatKhau.ForeColor = Color.White;
            btnDoiMatKhau.Location = new Point(47, 251);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(148, 37);
            btnDoiMatKhau.TabIndex = 6;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = false;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // txtXacNhanMoi
            // 
            txtXacNhanMoi.Location = new Point(249, 184);
            txtXacNhanMoi.Name = "txtXacNhanMoi";
            txtXacNhanMoi.PasswordChar = '*';
            txtXacNhanMoi.Size = new Size(168, 30);
            txtXacNhanMoi.TabIndex = 5;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(249, 131);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.Size = new Size(168, 30);
            txtMatKhauMoi.TabIndex = 4;
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(249, 73);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauCu.Size = new Size(168, 30);
            txtMatKhauCu.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(47, 187);
            label9.Name = "label9";
            label9.Size = new Size(196, 23);
            label9.TabIndex = 2;
            label9.Text = "Xác nhận mật khẩu mới:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(47, 131);
            label8.Name = "label8";
            label8.Size = new Size(120, 23);
            label8.TabIndex = 1;
            label8.Text = "Mật khẩu mới:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(47, 73);
            label7.Name = "label7";
            label7.Size = new Size(109, 23);
            label7.TabIndex = 0;
            label7.Text = "Mật khẩu cũ:";
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.White;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = Color.FromArgb(64, 78, 103);
            btnLamMoi.Location = new Point(407, 548);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(167, 41);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // ucProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLamMoi);
            Controls.Add(grpDoiMatKhau);
            Controls.Add(grpThongTin);
            Controls.Add(lblTitle);
            Name = "ucProfile";
            Size = new Size(999, 620);
            Load += ucProfile_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDoiMatKhau.ResumeLayout(false);
            grpDoiMatKhau.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpThongTin;
        private TextBox txtVaiTro;
        private TextBox txtTenDangNhap;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private TextBox txtChucVu;
        private TextBox txtHoTen;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox grpDoiMatKhau;
        private Button btnDoiMatKhau;
        private TextBox txtXacNhanMoi;
        private TextBox txtMatKhauMoi;
        private TextBox txtMatKhauCu;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button btnLamMoi;
    }
}
