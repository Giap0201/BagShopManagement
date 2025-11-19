namespace BagShopManagement.Views.Dev2
{
    partial class KichThuocEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblDai;
        private System.Windows.Forms.Label lblRong;
        private System.Windows.Forms.Label lblCao;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtMa;
        internal System.Windows.Forms.TextBox txtTen;
        internal System.Windows.Forms.NumericUpDown numDai;
        internal System.Windows.Forms.NumericUpDown numRong;
        internal System.Windows.Forms.NumericUpDown numCao;
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
            lblDai = new Label();
            lblRong = new Label();
            lblCao = new Label();
            txtMa = new TextBox();
            txtTen = new TextBox();
            numDai = new NumericUpDown();
            numRong = new NumericUpDown();
            numCao = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numDai).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCao).BeginInit();
            SuspendLayout();
            // 
            // lblMa
            // 
            lblMa.AutoSize = true;
            lblMa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblMa.ForeColor = Color.FromArgb(51, 51, 51);
            lblMa.Location = new Point(69, 105);
            lblMa.Name = "lblMa";
            lblMa.Size = new Size(146, 28);
            lblMa.TabIndex = 101;
            lblMa.Text = "Mã kích thước:";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTen.ForeColor = Color.FromArgb(51, 51, 51);
            lblTen.Location = new Point(69, 185);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(159, 28);
            lblTen.TabIndex = 103;
            lblTen.Text = "Tên kích thước:*";
            // 
            // lblDai
            // 
            lblDai.AutoSize = true;
            lblDai.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblDai.ForeColor = Color.FromArgb(51, 51, 51);
            lblDai.Location = new Point(69, 265);
            lblDai.Name = "lblDai";
            lblDai.Size = new Size(46, 28);
            lblDai.TabIndex = 105;
            lblDai.Text = "Dài:";
            // 
            // lblRong
            // 
            lblRong.AutoSize = true;
            lblRong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblRong.ForeColor = Color.FromArgb(51, 51, 51);
            lblRong.Location = new Point(219, 265);
            lblRong.Name = "lblRong";
            lblRong.Size = new Size(65, 28);
            lblRong.TabIndex = 107;
            lblRong.Text = "Rộng:";
            // 
            // lblCao
            // 
            lblCao.AutoSize = true;
            lblCao.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCao.ForeColor = Color.FromArgb(51, 51, 51);
            lblCao.Location = new Point(369, 265);
            lblCao.Name = "lblCao";
            lblCao.Size = new Size(51, 28);
            lblCao.TabIndex = 109;
            lblCao.Text = "Cao:";
            // 
            // txtMa
            // 
            txtMa.Location = new Point(69, 135);
            txtMa.Multiline = true;
            txtMa.Name = "txtMa";
            txtMa.ReadOnly = true;
            txtMa.Size = new Size(420, 40);
            txtMa.TabIndex = 102;
            // 
            // txtTen
            // 
            txtTen.BackColor = SystemColors.Control;
            txtTen.Location = new Point(69, 215);
            txtTen.Multiline = true;
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(420, 40);
            txtTen.TabIndex = 104;
            // 
            // numDai
            // 
            numDai.BackColor = SystemColors.Control;
            numDai.DecimalPlaces = 2;
            numDai.Location = new Point(69, 295);
            numDai.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numDai.Name = "numDai";
            numDai.Size = new Size(120, 34);
            numDai.TabIndex = 106;
            // 
            // numRong
            // 
            numRong.BackColor = SystemColors.Control;
            numRong.DecimalPlaces = 2;
            numRong.Location = new Point(219, 295);
            numRong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numRong.Name = "numRong";
            numRong.Size = new Size(120, 34);
            numRong.TabIndex = 108;
            // 
            // numCao
            // 
            numCao.BackColor = SystemColors.Control;
            numCao.DecimalPlaces = 2;
            numCao.Location = new Point(369, 295);
            numCao.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCao.Name = "numCao";
            numCao.Size = new Size(120, 34);
            numCao.TabIndex = 110;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(25, 118, 210);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(329, 355);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 50);
            btnSave.TabIndex = 112;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(69, 355);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 50);
            btnCancel.TabIndex = 111;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(186, 33);
            label1.Name = "label1";
            label1.Size = new Size(188, 38);
            label1.TabIndex = 100;
            label1.Text = "KÍCH THƯỚC";
            // 
            // KichThuocEditForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(546, 462);
            Controls.Add(label1);
            Controls.Add(lblMa);
            Controls.Add(txtMa);
            Controls.Add(lblTen);
            Controls.Add(txtTen);
            Controls.Add(lblDai);
            Controls.Add(numDai);
            Controls.Add(lblRong);
            Controls.Add(numRong);
            Controls.Add(lblCao);
            Controls.Add(numCao);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ForeColor = Color.FromArgb(51, 51, 51);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "KichThuocEditForm";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)numDai).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRong).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
