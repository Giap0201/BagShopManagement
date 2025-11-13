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
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblDai = new System.Windows.Forms.Label();
            this.lblRong = new System.Windows.Forms.Label();
            this.lblCao = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.numDai = new System.Windows.Forms.NumericUpDown();
            this.numRong = new System.Windows.Forms.NumericUpDown();
            this.numCao = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCao)).BeginInit();
            this.SuspendLayout();
            // 
            // form props
            // 
            this.ClientSize = new System.Drawing.Size(380, 300);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KichThuocEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            // 
            // lblMa
            //
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(18, 16);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(100, 20);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã kích thước:";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(18, 40);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(344, 27);
            this.txtMa.TabIndex = 1;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(18, 76);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(107, 20);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên kích thước:*";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(18, 100);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(344, 27);
            this.txtTen.TabIndex = 3;
            // 
            // lblDai
            // 
            this.lblDai.AutoSize = true;
            this.lblDai.Location = new System.Drawing.Point(18, 136);
            this.lblDai.Name = "lblDai";
            this.lblDai.Size = new System.Drawing.Size(37, 20);
            this.lblDai.TabIndex = 4;
            this.lblDai.Text = "Dài:";
            // 
            // numDai
            // 
            this.numDai.DecimalPlaces = 2;
            this.numDai.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numDai.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numDai.Location = new System.Drawing.Point(18, 160);
            this.numDai.Name = "numDai";
            this.numDai.Size = new System.Drawing.Size(104, 27);
            this.numDai.TabIndex = 5;
            this.numDai.ThousandsSeparator = false;
            // 
            // lblRong
            // 
            this.lblRong.AutoSize = true;
            this.lblRong.Location = new System.Drawing.Point(140, 136);
            this.lblRong.Name = "lblRong";
            this.lblRong.Size = new System.Drawing.Size(50, 20);
            this.lblRong.TabIndex = 6;
            this.lblRong.Text = "Rộng:";
            // 
            // numRong
            // 
            this.numRong.DecimalPlaces = 2;
            this.numRong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numRong.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numRong.Location = new System.Drawing.Point(140, 160);
            this.numRong.Name = "numRong";
            this.numRong.Size = new System.Drawing.Size(104, 27);
            this.numRong.TabIndex = 7;
            this.numRong.ThousandsSeparator = false;
            // 
            // lblCao
            // 
            this.lblCao.AutoSize = true;
            this.lblCao.Location = new System.Drawing.Point(262, 136);
            this.lblCao.Name = "lblCao";
            this.lblCao.Size = new System.Drawing.Size(40, 20);
            this.lblCao.TabIndex = 8;
            this.lblCao.Text = "Cao:";
            // 
            // numCao
            // 
            this.numCao.DecimalPlaces = 2;
            this.numCao.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numCao.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numCao.Location = new System.Drawing.Point(262, 160);
            this.numCao.Name = "numCao";
            this.numCao.Size = new System.Drawing.Size(100, 27);
            this.numCao.TabIndex = 9;
            this.numCao.ThousandsSeparator = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(170, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(282, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            // 
            // add controls
            // 
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblDai);
            this.Controls.Add(this.numDai);
            this.Controls.Add(this.lblRong);
            this.Controls.Add(this.numRong);
            this.Controls.Add(this.lblCao);
            this.Controls.Add(this.numCao);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);

            ((System.ComponentModel.ISupportInitialize)(this.numDai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
