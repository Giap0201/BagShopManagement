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
            label1.Location = new Point(49, 37);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã NCC";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 140);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên NCC";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 256);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 2;
            label3.Text = "Tên người LH";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(438, 37);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 3;
            label4.Text = "Địa chỉ ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(462, 140);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 4;
            label5.Text = "SDT";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(451, 249);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // txtMaNCC
            // 
            txtMaNCC.Enabled = false;
            txtMaNCC.Location = new Point(142, 34);
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.Size = new Size(201, 27);
            txtMaNCC.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(507, 249);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(201, 27);
            txtEmail.TabIndex = 7;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(517, 133);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(201, 27);
            txtSoDienThoai.TabIndex = 8;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(517, 34);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(201, 27);
            txtDiaChi.TabIndex = 9;
            // 
            // txtNguoiLienHe
            // 
            txtNguoiLienHe.Location = new Point(142, 252);
            txtNguoiLienHe.Name = "txtNguoiLienHe";
            txtNguoiLienHe.Size = new Size(201, 27);
            txtNguoiLienHe.TabIndex = 10;
            // 
            // txtTenNCC
            // 
            txtTenNCC.Location = new Point(142, 133);
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.Size = new Size(201, 27);
            txtTenNCC.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(158, 344);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 41);
            btnSave.TabIndex = 12;
            btnSave.Text = "Lưu ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(534, 344);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 41);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ThemNhaCungCapForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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