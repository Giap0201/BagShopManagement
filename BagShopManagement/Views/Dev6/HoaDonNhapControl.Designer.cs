namespace BagShopManagement.Views.Dev6
{
    partial class HoaDonNhapControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            dgvHoaDonNhap = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDonNhap).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Location = new Point(709, 12);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(295, 31);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÍ HOÁ ĐƠN NHẬP";
            // 
            // dgvHoaDonNhap
            // 
            dgvHoaDonNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDonNhap.Location = new Point(13, 46);
            dgvHoaDonNhap.Name = "dgvHoaDonNhap";
            dgvHoaDonNhap.RowHeadersWidth = 51;
            dgvHoaDonNhap.Size = new Size(1160, 557);
            dgvHoaDonNhap.TabIndex = 1;
            dgvHoaDonNhap.CellContentClick += dgvHoaDonNhap_CellContentClick;
            // 
            // HoaDonNhapControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvHoaDonNhap);
            Controls.Add(lblTieuDe);
            Name = "HoaDonNhapControl";
            Size = new Size(1767, 659);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDonNhap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private DataGridView dgvHoaDonNhap;
    }
}
