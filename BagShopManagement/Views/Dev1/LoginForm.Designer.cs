namespace BagShopManagement.Views.Dev1
{
    partial class LoginForm
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
            lblTitle = new Label();
            lblUsername = new Label();
            txtTenDangNhap = new TextBox();
            lblPassword = new Label();
            txtMatKhau = new TextBox();
            llblQuenMatKhau = new LinkLabel();
            btnDangNhap = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = BagShopManagement.Utils.ThemeColors.Primary;
            lblTitle.Location = new Point(268, 100);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(234, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🛍️ BagShop Login";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            lblUsername.Location = new Point(195, 181);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(114, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên đăng nhập: ";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtTenDangNhap.Font = new Font("Segoe UI", 10F);
            txtTenDangNhap.Location = new Point(341, 178);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(194, 30);
            txtTenDangNhap.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            lblPassword.Location = new Point(195, 246);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Font = new Font("Segoe UI", 10F);
            txtMatKhau.Location = new Point(341, 243);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '●';
            txtMatKhau.Size = new Size(194, 30);
            txtMatKhau.TabIndex = 4;
            // 
            // llblQuenMatKhau
            // 
            llblQuenMatKhau.ActiveLinkColor = BagShopManagement.Utils.ThemeColors.Primary;
            llblQuenMatKhau.AutoSize = true;
            llblQuenMatKhau.LinkColor = BagShopManagement.Utils.ThemeColors.Secondary;
            llblQuenMatKhau.Location = new Point(559, 300);
            llblQuenMatKhau.Name = "llblQuenMatKhau";
            llblQuenMatKhau.Size = new Size(116, 20);
            llblQuenMatKhau.TabIndex = 5;
            llblQuenMatKhau.TabStop = true;
            llblQuenMatKhau.Text = "Quên mật khẩu?";
            llblQuenMatKhau.VisitedLinkColor = BagShopManagement.Utils.ThemeColors.Secondary;
            llblQuenMatKhau.LinkClicked += llblQuenMatKhau_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = BagShopManagement.Utils.ThemeColors.Primary;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDangNhap.ForeColor = BagShopManagement.Utils.ThemeColors.Card;
            btnDangNhap.Location = new Point(254, 358);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(120, 40);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = BagShopManagement.Utils.ThemeColors.Secondary;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThoat.ForeColor = BagShopManagement.Utils.ThemeColors.Card;
            btnThoat.Location = new Point(400, 358);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 40);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = BagShopManagement.Utils.ThemeColors.Background;
            CancelButton = btnThoat;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(btnDangNhap);
            Controls.Add(llblQuenMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(lblPassword);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - BagShop";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtTenDangNhap;
        private Label lblPassword;
        private TextBox txtMatKhau;
        private LinkLabel llblQuenMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;
    }
}