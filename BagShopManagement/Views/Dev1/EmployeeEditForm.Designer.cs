namespace BagShopManagement.Views.Dev1
{
    partial class EmployeeEditForm
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
            lblMaNV = new Label();
            lblHoTen = new Label();
            lblChucVu = new Label();
            lblEmail = new Label();
            lblSoDienThoai = new Label();
            lblVaiTro = new Label();
            txtMaNV = new TextBox();
            txtHoTen = new TextBox();
            txtChucVu = new TextBox();
            txtEmail = new TextBox();
            txtSoDienThoai = new TextBox();
            cboVaiTro = new ComboBox();
            chkTrangThai = new CheckBox();
            grpTaiKhoan = new GroupBox();
            txtMatKhau = new TextBox();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            lblTenDangNhap = new Label();
            btnLuu = new Button();
            btnHuy = new Button();
            grpTaiKhoan.SuspendLayout();
            SuspendLayout();
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Location = new Point(40, 34);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(57, 20);
            lblMaNV.TabIndex = 0;
            lblMaNV.Text = "Mã NV:";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(40, 87);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(57, 20);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ tên:";
            // 
            // lblChucVu
            // 
            lblChucVu.AutoSize = true;
            lblChucVu.Location = new Point(40, 136);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Size = new Size(64, 20);
            lblChucVu.TabIndex = 2;
            lblChucVu.Text = "Chức vụ:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(40, 192);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(40, 245);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(39, 20);
            lblSoDienThoai.TabIndex = 4;
            lblSoDienThoai.Text = "SĐT:";
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new Point(40, 303);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(55, 20);
            lblVaiTro.TabIndex = 5;
            lblVaiTro.Text = "Vai trò:";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(145, 31);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(125, 27);
            txtMaNV.TabIndex = 6;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(145, 80);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(151, 27);
            txtHoTen.TabIndex = 7;
            // 
            // txtChucVu
            // 
            txtChucVu.Location = new Point(145, 133);
            txtChucVu.Name = "txtChucVu";
            txtChucVu.Size = new Size(151, 27);
            txtChucVu.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(145, 192);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(151, 27);
            txtEmail.TabIndex = 9;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(145, 245);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(151, 27);
            txtSoDienThoai.TabIndex = 10;
            // 
            // cboVaiTro
            // 
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Location = new Point(145, 303);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(151, 28);
            cboVaiTro.TabIndex = 12;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Location = new Point(40, 364);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(140, 24);
            chkTrangThai.TabIndex = 13;
            chkTrangThai.Text = "Đang hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // grpTaiKhoan
            // 
            grpTaiKhoan.BackColor = Color.White;
            grpTaiKhoan.Controls.Add(txtMatKhau);
            grpTaiKhoan.Controls.Add(txtTenDangNhap);
            grpTaiKhoan.Controls.Add(lblMatKhau);
            grpTaiKhoan.Controls.Add(lblTenDangNhap);
            grpTaiKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpTaiKhoan.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            grpTaiKhoan.Location = new Point(430, 35);
            grpTaiKhoan.Name = "grpTaiKhoan";
            grpTaiKhoan.Size = new Size(358, 163);
            grpTaiKhoan.TabIndex = 14;
            grpTaiKhoan.TabStop = false;
            grpTaiKhoan.Text = "🔐 Thông tin tài khoản";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(160, 101);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(160, 27);
            txtMatKhau.TabIndex = 18;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(160, 42);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(160, 27);
            txtTenDangNhap.TabIndex = 17;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(26, 101);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(73, 20);
            lblMatKhau.TabIndex = 16;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(26, 45);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(110, 20);
            lblTenDangNhap.TabIndex = 15;
            lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6B9D");
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Cursor = Cursors.Hand;
            btnLuu.Location = new Point(269, 395);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 35);
            btnLuu.TabIndex = 15;
            btnLuu.Text = "✔ Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = System.Drawing.ColorTranslator.FromHtml("#E2E8F0");
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.Location = new Point(410, 395);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(120, 35);
            btnHuy.TabIndex = 16;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // EmployeeEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            CancelButton = btnHuy;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(grpTaiKhoan);
            Controls.Add(chkTrangThai);
            Controls.Add(cboVaiTro);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtEmail);
            Controls.Add(txtChucVu);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaNV);
            Controls.Add(lblVaiTro);
            Controls.Add(lblSoDienThoai);
            Controls.Add(lblEmail);
            Controls.Add(lblChucVu);
            Controls.Add(lblHoTen);
            Controls.Add(lblMaNV);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "👥 Thêm / Sửa Nhân viên";
            Load += EmployeeEditForm_Load;
            grpTaiKhoan.ResumeLayout(false);
            grpTaiKhoan.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaNV;
        private Label lblHoTen;
        private Label lblChucVu;
        private Label lblEmail;
        private Label lblSoDienThoai;
        private Label lblVaiTro;
        private TextBox txtMaNV;
        private TextBox txtHoTen;
        private TextBox txtChucVu;
        private TextBox txtEmail;
        private TextBox txtSoDienThoai;
        private ComboBox cboVaiTro;
        private CheckBox chkTrangThai;
        private GroupBox grpTaiKhoan;
        private TextBox txtMatKhau;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private Label lblTenDangNhap;
        private Button btnLuu;
        private Button btnHuy;
    }
}