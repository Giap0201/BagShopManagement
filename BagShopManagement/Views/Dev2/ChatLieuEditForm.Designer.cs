namespace BagShopManagement.Views.Dev2
{
    partial class ChatLieuEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMa;
        private Label lblTen;
        private Label lblMoTa;
        private Label lblTitle;
        internal TextBox txtMa;
        internal TextBox txtTen;
        internal TextBox txtMoTa;
        internal Button btnSave;
        internal Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMa = new Label();
            lblTen = new Label();
            lblMoTa = new Label();
            lblTitle = new Label();
            txtMa = new TextBox();
            txtTen = new TextBox();
            txtMoTa = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblMa
            // 
            lblMa.AutoSize = true;
            lblMa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblMa.Location = new Point(76, 107);
            lblMa.Name = "lblMa";
            lblMa.Size = new Size(128, 28);
            lblMa.TabIndex = 1;
            lblMa.Text = "Mã chất liệu:";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTen.Location = new Point(76, 187);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(141, 28);
            lblTen.TabIndex = 3;
            lblTen.Text = "Tên chất liệu:*";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblMoTa.Location = new Point(76, 267);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(70, 28);
            lblMoTa.TabIndex = 5;
            lblMoTa.Text = "Mô tả:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblTitle.Location = new Point(186, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(170, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CHẤT LIỆU";
            // 
            // txtMa
            // 
            txtMa.Location = new Point(76, 137);
            txtMa.Multiline = true;
            txtMa.Name = "txtMa";
            txtMa.ReadOnly = true;
            txtMa.Size = new Size(400, 40);
            txtMa.TabIndex = 2;
            // 
            // txtTen
            // 
            txtTen.BackColor = SystemColors.Control;
            txtTen.Location = new Point(76, 217);
            txtTen.Multiline = true;
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(400, 40);
            txtTen.TabIndex = 4;
            // 
            // txtMoTa
            // 
            txtMoTa.BackColor = SystemColors.Control;
            txtMoTa.Location = new Point(76, 297);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(400, 60);
            txtMoTa.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(25, 118, 210);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(316, 389);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 50);
            btnSave.TabIndex = 8;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(76, 389);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 50);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // ChatLieuEditForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(550, 473);
            Controls.Add(lblTitle);
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
            Name = "ChatLieuEditForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
