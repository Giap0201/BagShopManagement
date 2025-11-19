namespace BagShopManagement.Views.Dev2
{
    partial class LoaiTuiEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtMa;
        internal System.Windows.Forms.TextBox txtTen;
        internal System.Windows.Forms.TextBox txtMoTa;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnCancel;
        

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            lblMa = new Label();
            lblTen = new Label();
            lblMoTa = new Label();
            txtMa = new TextBox();
            txtTen = new TextBox();
            txtMoTa = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblMa
            // 
            lblMa.AutoSize = true;
            lblMa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblMa.ForeColor = Color.FromArgb(51, 51, 51);
            lblMa.Location = new Point(86, 88);
            lblMa.Name = "lblMa";
            lblMa.Size = new Size(113, 28);
            lblMa.TabIndex = 0;
            lblMa.Text = "Mã loại túi:";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTen.ForeColor = Color.FromArgb(51, 51, 51);
            lblTen.Location = new Point(86, 192);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(126, 28);
            lblTen.TabIndex = 2;
            lblTen.Text = "Tên loại túi:*";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblMoTa.ForeColor = Color.FromArgb(51, 51, 51);
            lblMoTa.Location = new Point(86, 296);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(70, 28);
            lblMoTa.TabIndex = 4;
            lblMoTa.Text = "Mô tả:";
            // 
            // txtMa
            // 
            txtMa.Location = new Point(86, 119);
            txtMa.Multiline = true;
            txtMa.Name = "txtMa";
            txtMa.ReadOnly = true;
            txtMa.Size = new Size(392, 47);
            txtMa.TabIndex = 1;
            // 
            // txtTen
            // 
            txtTen.BackColor = SystemColors.Control;
            txtTen.Location = new Point(86, 223);
            txtTen.Multiline = true;
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(392, 47);
            txtTen.TabIndex = 3;
            // 
            // txtMoTa
            // 
            txtMoTa.BackColor = SystemColors.Control;
            txtMoTa.Location = new Point(86, 327);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(392, 80);
            txtMoTa.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(25, 118, 210);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(325, 425);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(153, 54);
            btnSave.TabIndex = 7;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(86, 425);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(153, 54);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(209, 29);
            label1.Name = "label1";
            label1.Size = new Size(146, 38);
            label1.TabIndex = 8;
            label1.Text = "TÚI XÁCH";
            // 
            // LoaiTuiEditForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(558, 520);
            Controls.Add(label1);
            Controls.Add(lblMa);
            Controls.Add(txtMa);
            Controls.Add(lblTen);
            Controls.Add(txtTen);
            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ForeColor = Color.FromArgb(51, 51, 51);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoaiTuiEditForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

    }
}
