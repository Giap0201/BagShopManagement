namespace BagShopManagement.Views.Dev4.Dev4_HoaDonBan
{
    partial class ChiTietHoaDonForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblMaHDB = new Label();
            lblMaKH = new Label();
            lblMaNV = new Label();
            lblNgayBan = new Label();
            lblTongTien = new Label();
            lblPTTT = new Label();
            lblTrangThai = new Label();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            pnlMain = new Panel();
            dgvChiTiet = new DataGridView();
            pnlBottom = new Panel();
            lblTongTienChiTiet = new Label();
            btnClose = new Button();

            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();

            // pnlHeader
            pnlHeader.Controls.Add(txtGhiChu);
            pnlHeader.Controls.Add(lblGhiChu);
            pnlHeader.Controls.Add(lblTrangThai);
            pnlHeader.Controls.Add(lblPTTT);
            pnlHeader.Controls.Add(lblTongTien);
            pnlHeader.Controls.Add(lblNgayBan);
            pnlHeader.Controls.Add(lblMaNV);
            pnlHeader.Controls.Add(lblMaKH);
            pnlHeader.Controls.Add(lblMaHDB);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1000, 200);
            pnlHeader.TabIndex = 0;

            // lblMaHDB
            lblMaHDB.AutoSize = true;
            lblMaHDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            lblMaHDB.Location = new System.Drawing.Point(20, 20);
            lblMaHDB.Name = "lblMaHDB";
            lblMaHDB.Size = new System.Drawing.Size(100, 20);
            lblMaHDB.TabIndex = 0;
            lblMaHDB.Text = "Mã HĐ:";

            // lblMaKH
            lblMaKH.AutoSize = true;
            lblMaKH.Location = new System.Drawing.Point(20, 50);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Size = new System.Drawing.Size(60, 20);
            lblMaKH.TabIndex = 1;
            lblMaKH.Text = "Mã KH:";

            // lblMaNV
            lblMaNV.AutoSize = true;
            lblMaNV.Location = new System.Drawing.Point(300, 50);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new System.Drawing.Size(60, 20);
            lblMaNV.TabIndex = 2;
            lblMaNV.Text = "Mã NV:";

            // lblNgayBan
            lblNgayBan.AutoSize = true;
            lblNgayBan.Location = new System.Drawing.Point(20, 80);
            lblNgayBan.Name = "lblNgayBan";
            lblNgayBan.Size = new System.Drawing.Size(80, 20);
            lblNgayBan.TabIndex = 3;
            lblNgayBan.Text = "Ngày bán:";

            // lblTongTien
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            lblTongTien.ForeColor = System.Drawing.Color.Red;
            lblTongTien.Location = new System.Drawing.Point(300, 80);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new System.Drawing.Size(100, 20);
            lblTongTien.TabIndex = 4;
            lblTongTien.Text = "Tổng tiền:";

            // lblPTTT
            lblPTTT.AutoSize = true;
            lblPTTT.Location = new System.Drawing.Point(20, 110);
            lblPTTT.Name = "lblPTTT";
            lblPTTT.Size = new System.Drawing.Size(140, 20);
            lblPTTT.TabIndex = 5;
            lblPTTT.Text = "Phương thức TT:";

            // lblTrangThai
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new System.Drawing.Point(300, 110);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(90, 20);
            lblTrangThai.TabIndex = 6;
            lblTrangThai.Text = "Trạng thái:";

            // lblGhiChu
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new System.Drawing.Point(20, 140);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new System.Drawing.Size(70, 20);
            lblGhiChu.TabIndex = 7;
            lblGhiChu.Text = "Ghi chú:";

            // txtGhiChu
            txtGhiChu.Location = new System.Drawing.Point(100, 137);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new System.Drawing.Size(850, 27);
            txtGhiChu.TabIndex = 8;

            // pnlMain
            pnlMain.Controls.Add(dgvChiTiet);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new System.Drawing.Point(0, 200);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new System.Drawing.Size(1000, 400);
            pnlMain.TabIndex = 1;

            // dgvChiTiet
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;

            // pnlBottom
            pnlBottom.Controls.Add(btnClose);
            pnlBottom.Controls.Add(lblTongTienChiTiet);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new System.Drawing.Point(0, 600);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new System.Drawing.Size(1000, 60);
            pnlBottom.TabIndex = 2;

            // lblTongTienChiTiet
            lblTongTienChiTiet.AutoSize = true;
            lblTongTienChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            lblTongTienChiTiet.ForeColor = System.Drawing.Color.Blue;
            lblTongTienChiTiet.Location = new System.Drawing.Point(20, 20);
            lblTongTienChiTiet.Name = "lblTongTienChiTiet";
            lblTongTienChiTiet.Size = new System.Drawing.Size(150, 20);
            lblTongTienChiTiet.TabIndex = 0;
            lblTongTienChiTiet.Text = "Tổng thành tiền:";

            // btnClose
            btnClose.Location = new System.Drawing.Point(850, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(120, 35);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;

            // ChiTietHoaDonForm
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 660);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            Name = "ChiTietHoaDonForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết hóa đơn";
            Load += ChiTietHoaDonForm_Load;

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblMaHDB;
        private Label lblMaKH;
        private Label lblMaNV;
        private Label lblNgayBan;
        private Label lblTongTien;
        private Label lblPTTT;
        private Label lblTrangThai;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Panel pnlMain;
        private DataGridView dgvChiTiet;
        private Panel pnlBottom;
        private Label lblTongTienChiTiet;
        private Button btnClose;
    }
}

