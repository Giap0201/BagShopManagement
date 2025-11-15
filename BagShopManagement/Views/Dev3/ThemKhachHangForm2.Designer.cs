namespace BagShopManagement.Views.Dev3
{
    partial class ThemKhachHangForm2
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
            txtDiemTichLuy = new TextBox();
            txtSoDienThoai = new TextBox();
            txtMaKH = new TextBox();
            txtDiaChi = new TextBox();
            txtHoTen = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            label6 = new Label();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 56);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã KH";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(407, 52);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên khách hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(464, 204);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 132);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 3;
            label4.Text = "Số điện thoại";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(464, 128);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 4;
            label5.Text = "Địa chỉ";
            // 
            // txtDiemTichLuy
            // 
            txtDiemTichLuy.Location = new Point(126, 204);
            txtDiemTichLuy.Name = "txtDiemTichLuy";
            txtDiemTichLuy.Size = new Size(183, 27);
            txtDiemTichLuy.TabIndex = 7;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(129, 128);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(180, 27);
            txtSoDienThoai.TabIndex = 8;
            // 
            // txtMaKH
            // 
            txtMaKH.Enabled = false;
            txtMaKH.Location = new Point(129, 52);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(180, 27);
            txtMaKH.TabIndex = 9;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(533, 125);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(246, 27);
            txtDiaChi.TabIndex = 10;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(533, 49);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(246, 27);
            txtHoTen.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(126, 312);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(111, 48);
            btnSave.TabIndex = 12;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(553, 312);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(111, 48);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 204);
            label6.Name = "label6";
            label6.Size = new Size(96, 20);
            label6.TabIndex = 14;
            label6.Text = "Điểm tích lũy";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(533, 197);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(246, 27);
            txtEmail.TabIndex = 15;
            // 
            // ThemKhachHangForm2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtHoTen);
            Controls.Add(txtDiaChi);
            Controls.Add(txtMaKH);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtDiemTichLuy);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ThemKhachHangForm2";
            Text = "ThemKhachHangForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtDiemTichLuy;
        private TextBox txtSoDienThoai;
        private TextBox txtMaKH;
        private TextBox txtDiaChi;
        private TextBox txtHoTen;
        private Button btnSave;
        private Button btnCancel;
        private Label label6;
        private TextBox txtEmail;
    }
}