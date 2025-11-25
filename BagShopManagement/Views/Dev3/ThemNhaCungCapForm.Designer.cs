namespace BagShopManagement.Views.Dev3
{
    partial class ThemNhaCungCapForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaNCC = new TextBox();
            txtEmail = new TextBox();
            txtSoDienThoai = new TextBox();
            txtDiaChi = new TextBox();
            txtNguoiLienHe = new TextBox();
            txtTenNCC = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(75, 37);
            label1.Name = "label1";
            label1.Size = new Size(84, 28);
            label1.TabIndex = 0;
            label1.Text = "Mã NCC";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(75, 201);
            label2.Name = "label2";
            label2.Size = new Size(88, 28);
            label2.TabIndex = 1;
            label2.Text = "Tên NCC";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(75, 365);
            label3.Name = "label3";
            label3.Size = new Size(134, 28);
            label3.TabIndex = 2;
            label3.Text = "Tên người LH";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(75, 283);
            label4.Name = "label4";
            label4.Size = new Size(79, 28);
            label4.TabIndex = 3;
            label4.Text = "Địa chỉ ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(75, 119);
            label5.Name = "label5";
            label5.Size = new Size(47, 28);
            label5.TabIndex = 4;
            label5.Text = "SDT";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(75, 447);
            label6.Name = "label6";
            label6.Size = new Size(60, 28);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // txtMaNCC
            // 
            txtMaNCC.Enabled = false;
            txtMaNCC.Location = new Point(232, 28);
            txtMaNCC.Multiline = true;
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.Size = new Size(318, 37);
            txtMaNCC.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(232, 438);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(318, 37);
            txtEmail.TabIndex = 5;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(232, 110);
            txtSoDienThoai.Multiline = true;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(318, 37);
            txtSoDienThoai.TabIndex = 1;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(232, 274);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(318, 37);
            txtDiaChi.TabIndex = 3;
            // 
            // txtNguoiLienHe
            // 
            txtNguoiLienHe.Location = new Point(232, 356);
            txtNguoiLienHe.Multiline = true;
            txtNguoiLienHe.Name = "txtNguoiLienHe";
            txtNguoiLienHe.Size = new Size(318, 37);
            txtNguoiLienHe.TabIndex = 4;
            // 
            // txtTenNCC
            // 
            txtTenNCC.Location = new Point(232, 192);
            txtTenNCC.Multiline = true;
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.Size = new Size(318, 37);
            txtTenNCC.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.Transparent;
            btnSave.Location = new Point(107, 558);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(157, 54);
            btnSave.TabIndex = 6;
            btnSave.Text = "Lưu ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(192, 0, 0);
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(373, 558);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(157, 54);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ThemNhaCungCapForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 657);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtTenNCC);
            Controls.Add(txtNguoiLienHe);
            Controls.Add(txtDiaChi);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtEmail);
            Controls.Add(txtMaNCC);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ThemNhaCungCapForm";
            Text = "ThemNhaCungCapForm";
            Load += ThemNhaCungCapForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMaNCC;
        private TextBox txtEmail;
        private TextBox txtSoDienThoai;
        private TextBox txtDiaChi;
        private TextBox txtNguoiLienHe;
        private TextBox txtTenNCC;
        private Button btnSave;
        private Button btnCancel;
    }
}