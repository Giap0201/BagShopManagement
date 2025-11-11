namespace BagShopManagement.Views.Dev6
{
    partial class ucBaoCaoDoanhThu
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Label lblTongDoanhThu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            lblTuNgay = new Label();
            lblDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            btnXemBaoCao = new Button();
            dgvBaoCao = new DataGridView();
            lblTongDoanhThu = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(30, 147);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(65, 20);
            lblTuNgay.TabIndex = 0;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(254, 147);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(75, 20);
            lblDenNgay.TabIndex = 2;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(106, 142);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(130, 27);
            dtpTuNgay.TabIndex = 1;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(335, 142);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(130, 27);
            dtpDenNgay.TabIndex = 3;
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.BackColor = Color.FromArgb(0, 120, 215);
            btnXemBaoCao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXemBaoCao.ForeColor = Color.White;
            btnXemBaoCao.Location = new Point(494, 140);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(130, 35);
            btnXemBaoCao.TabIndex = 4;
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = false;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.AllowUserToResizeRows = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.BackgroundColor = Color.White;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Location = new Point(30, 249);
            dgvBaoCao.MultiSelect = false;
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.RowTemplate.Height = 28;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.Size = new Size(986, 300);
            dgvBaoCao.TabIndex = 5;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongDoanhThu.ForeColor = Color.DarkBlue;
            lblTongDoanhThu.Location = new Point(536, 585);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(480, 35);
            lblTongDoanhThu.TabIndex = 6;
            lblTongDoanhThu.Text = "Tổng doanh thu: 0 VNĐ";
            lblTongDoanhThu.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ucBaoCaoDoanhThu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblTuNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(lblDenNgay);
            Controls.Add(dtpDenNgay);
            Controls.Add(btnXemBaoCao);
            Controls.Add(dgvBaoCao);
            Controls.Add(lblTongDoanhThu);
            Name = "ucBaoCaoDoanhThu";
            Size = new Size(1152, 716);
            Load += ucBaoCaoDoanhThu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
