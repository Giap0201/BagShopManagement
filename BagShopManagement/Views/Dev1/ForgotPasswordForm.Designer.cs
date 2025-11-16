namespace BagShopManagement.Views.Dev1
{
    partial class ForgotPasswordForm
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
            label1 = new Label();
            txtTenDangNhap = new TextBox();
            txtGuiYeuCau = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            label1.Location = new Point(22, 86);
            label1.Name = "label1";
            label1.Size = new Size(380, 20);
            label1.TabIndex = 0;
            label1.Text = "🔑 Nhập tên đăng nhập của bạn để khôi phục: ";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(345, 83);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(229, 27);
            txtTenDangNhap.TabIndex = 1;
            // 
            // txtGuiYeuCau
            // 
            txtGuiYeuCau.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6B9D");
            txtGuiYeuCau.FlatStyle = FlatStyle.Flat;
            txtGuiYeuCau.FlatAppearance.BorderSize = 0;
            txtGuiYeuCau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtGuiYeuCau.ForeColor = Color.White;
            txtGuiYeuCau.Cursor = Cursors.Hand;
            txtGuiYeuCau.Location = new Point(47, 138);
            txtGuiYeuCau.Name = "txtGuiYeuCau";
            txtGuiYeuCau.Size = new Size(150, 35);
            txtGuiYeuCau.TabIndex = 2;
            txtGuiYeuCau.Text = "📧 Gửi yêu cầu";
            txtGuiYeuCau.UseVisualStyleBackColor = false;
            txtGuiYeuCau.Click += btnGuiYeuCau_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = System.Drawing.ColorTranslator.FromHtml("#E2E8F0");
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.Location = new Point(221, 138);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(133, 35);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            CancelButton = btnHuy;
            ClientSize = new Size(646, 337);
            Controls.Add(btnHuy);
            Controls.Add(txtGuiYeuCau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quên mật khẩu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTenDangNhap;
        private Button txtGuiYeuCau;
        private Button btnHuy;
    }
}