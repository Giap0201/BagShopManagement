namespace BagShopManagement.Views.Dev2
{
    partial class LoaiTuiEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblMoTa;
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
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Form size and basic props
            // 
            this.ClientSize = new System.Drawing.Size(360, 260);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoaiTuiEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(18, 20);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(90, 20);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã loại túi:";
            // 
            // txtMa (full width)
            // 
            this.txtMa.Location = new System.Drawing.Point(18, 44);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(324, 27);
            this.txtMa.TabIndex = 1;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(18, 80);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(99, 20);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên loại túi:*";
            // 
            // txtTen (full width)
            // 
            this.txtTen.Location = new System.Drawing.Point(18, 104);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(324, 27);
            this.txtTen.TabIndex = 3;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(18, 140);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(55, 20);
            this.lblMoTa.TabIndex = 4;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa (full width multiline)
            // 
            this.txtMoTa.Location = new System.Drawing.Point(18, 164);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(324, 52);
            this.txtMoTa.TabIndex = 5;
            // 
            // btnCancel (left, grey)
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            // 
            // btnSave (right, Material Blue 700)
            // 
            this.btnSave.Location = new System.Drawing.Point(264, 222);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(25, 118, 210); // Material Blue 700
            this.btnSave.ForeColor = System.Drawing.Color.White;
            // 
            // add controls to form
            // 
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
