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
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // form
            // 
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MauSacEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(18, 20);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(40, 20);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã:";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(18, 44);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(314, 27);
            this.txtMa.TabIndex = 1;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(18, 84);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(90, 20);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên màu:*";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(18, 108);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(314, 27);
            this.txtTen.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(164, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(268, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            // 
            // add controls
            // 
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
