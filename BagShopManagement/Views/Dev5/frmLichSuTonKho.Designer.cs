namespace BagShopManagement.Views.Dev5
{
    partial class frmLichSuTonKho
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
            pnlTop = new Panel();
            lblThongTinSP = new Label();
            pnlBottom = new Panel();
            btnDong = new Button();
            dgvLichSu = new DataGridView();
            pnlTop.SuspendLayout();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSu).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(lblThongTinSP);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(800, 79);
            pnlTop.TabIndex = 0;
            // 
            // lblThongTinSP
            // 
            lblThongTinSP.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblThongTinSP.AutoSize = true;
            lblThongTinSP.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblThongTinSP.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            lblThongTinSP.Location = new Point(229, 25);
            lblThongTinSP.Name = "lblThongTinSP";
            lblThongTinSP.Size = new Size(387, 25);
            lblThongTinSP.TabIndex = 0;
            lblThongTinSP.Text = "📊 Lịch sử cho sản phẩm: [Tên sản phẩm]";
            lblThongTinSP.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.White;
            pnlBottom.Controls.Add(btnDong);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 378);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(800, 72);
            pnlBottom.TabIndex = 1;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDong.BackColor = System.Drawing.ColorTranslator.FromHtml("#718096");
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDong.ForeColor = Color.White;
            btnDong.Cursor = Cursors.Hand;
            btnDong.Location = new Point(638, 16);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(130, 38);
            btnDong.TabIndex = 0;
            btnDong.Text = "✖ Đóng";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // dgvLichSu
            // 
            dgvLichSu.AllowUserToAddRows = false;
            dgvLichSu.AllowUserToDeleteRows = false;
            dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSu.BackgroundColor = SystemColors.Window;
            dgvLichSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSu.Dock = DockStyle.Fill;
            dgvLichSu.Location = new Point(0, 79);
            dgvLichSu.Name = "dgvLichSu";
            dgvLichSu.ReadOnly = true;
            dgvLichSu.RowHeadersWidth = 51;
            dgvLichSu.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dgvLichSu.Size = new Size(800, 299);
            dgvLichSu.TabIndex = 2;
            // 
            // frmLichSuTonKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            ClientSize = new Size(800, 450);
            Controls.Add(dgvLichSu);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Name = "frmLichSuTonKho";
            Text = "frmLichSuTonKho";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLichSu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblThongTinSP;
        private Panel pnlBottom;
        private Button btnDong;
        private DataGridView dgvLichSu;
    }
}