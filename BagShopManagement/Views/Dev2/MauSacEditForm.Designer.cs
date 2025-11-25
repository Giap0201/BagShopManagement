namespace BagShopManagement.Views.Dev2
{
    partial class MauSacEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        internal System.Windows.Forms.TextBox txtMa;
        internal System.Windows.Forms.TextBox txtTen;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMa = new Label();
            lblTen = new Label();
            txtMa = new TextBox();
            txtTen = new TextBox();
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
            lblMa.Location = new Point(84, 87);
            lblMa.Name = "lblMa";
            lblMa.Size = new Size(91, 28);
            lblMa.TabIndex = 0;
            lblMa.Text = "Mã màu:";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTen.ForeColor = Color.FromArgb(51, 51, 51);
            lblTen.Location = new Point(84, 178);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(104, 28);
            lblTen.TabIndex = 2;
            lblTen.Text = "Tên màu:*";
            // 
            // txtMa
            // 
            txtMa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtMa.ForeColor = Color.FromArgb(51, 51, 51);
            txtMa.Location = new Point(84, 118);
            txtMa.Multiline = true;
            txtMa.Name = "txtMa";
            txtMa.ReadOnly = true;
            txtMa.Size = new Size(392, 47);
            txtMa.TabIndex = 1;
            // 
            // txtTen
            // 
            txtTen.BackColor = SystemColors.Control;
            txtTen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtTen.Location = new Point(84, 209);
            txtTen.Multiline = true;
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(392, 47);
            txtTen.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(25, 118, 210);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(323, 292);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(153, 54);
            btnSave.TabIndex = 5;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(84, 292);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(153, 54);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(204, 29);
            label1.Name = "label1";
            label1.Size = new Size(145, 38);
            label1.TabIndex = 6;
            label1.Text = "MÀU SẮC";
            // 
            // MauSacEditForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(560, 376);
            Controls.Add(label1);
            Controls.Add(lblMa);
            Controls.Add(txtMa);
            Controls.Add(lblTen);
            Controls.Add(txtTen);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MauSacEditForm";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
    }
}
