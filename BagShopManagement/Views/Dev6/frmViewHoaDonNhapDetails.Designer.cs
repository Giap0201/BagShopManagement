namespace BagShopManagement.Views.Dev6
{
    partial class frmViewHoaDonNhapDetails
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
            lblShopName = new Label();
            lblTieuDe = new Label();
            groupBox1 = new GroupBox();
            lblTrangThai = new Label();
            lblGhiChu = new Label();
            lblNhanVien = new Label();
            lblNhaCungCap = new Label();
            lblNgayNhap = new Label();
            lblMaHDN = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lblTongTien = new Label();
            label8 = new Label();
            dgvChiTiet = new DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            btnIn = new Button();
            btnDong = new Button();
            pnlHeader.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 102, 204);
            pnlHeader.Controls.Add(lblShopName);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 90);
            pnlHeader.TabIndex = 0;
            // 
            // lblShopName
            // 
            lblShopName.AutoSize = true;
            lblShopName.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            lblShopName.ForeColor = Color.Yellow;
            lblShopName.Location = new Point(273, 9);
            lblShopName.Name = "lblShopName";
            lblShopName.Size = new Size(443, 35);
            lblShopName.TabIndex = 0;
            lblShopName.Text = "TÚI XÁCH CAO CẤP LUXURY";
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Times New Roman", 26.2F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(280, 40);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(436, 51);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "PHIẾU NHẬP HÀNG";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTrangThai);
            groupBox1.Controls.Add(lblGhiChu);
            groupBox1.Controls.Add(lblNhanVien);
            groupBox1.Controls.Add(lblNhaCungCap);
            groupBox1.Controls.Add(lblNgayNhap);
            groupBox1.Controls.Add(lblMaHDN);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            groupBox1.Location = new Point(30, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(940, 140);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phiếu nhập hàng";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblTrangThai.ForeColor = Color.Green;
            lblTrangThai.Location = new Point(550, 80);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(0, 23);
            lblTrangThai.TabIndex = 5;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Font = new Font("Times New Roman", 10.2F);
            lblGhiChu.Location = new Point(150, 105);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(0, 19);
            lblGhiChu.TabIndex = 4;
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Font = new Font("Times New Roman", 10.2F);
            lblNhanVien.Location = new Point(550, 30);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(0, 19);
            lblNhanVien.TabIndex = 3;
            // 
            // lblNhaCungCap
            // 
            lblNhaCungCap.AutoSize = true;
            lblNhaCungCap.Font = new Font("Times New Roman", 10.2F);
            lblNhaCungCap.Location = new Point(150, 80);
            lblNhaCungCap.Name = "lblNhaCungCap";
            lblNhaCungCap.Size = new Size(0, 19);
            lblNhaCungCap.TabIndex = 2;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Font = new Font("Times New Roman", 10.2F);
            lblNgayNhap.Location = new Point(150, 55);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(0, 19);
            lblNgayNhap.TabIndex = 1;
            // 
            // lblMaHDN
            // 
            lblMaHDN.AutoSize = true;
            lblMaHDN.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblMaHDN.ForeColor = Color.Navy;
            lblMaHDN.Location = new Point(150, 30);
            lblMaHDN.Name = "lblMaHDN";
            lblMaHDN.Size = new Size(0, 23);
            lblMaHDN.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 130);
            label7.Name = "label7";
            label7.Size = new Size(0, 19);
            label7.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label6.Location = new Point(430, 80);
            label6.Name = "label6";
            label6.Size = new Size(91, 19);
            label6.TabIndex = 11;
            label6.Text = "Trạng thái:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label5.Location = new Point(30, 105);
            label5.Name = "label5";
            label5.Size = new Size(74, 19);
            label5.TabIndex = 10;
            label5.Text = "Ghi chú:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label4.Location = new Point(430, 30);
            label4.Name = "label4";
            label4.Size = new Size(88, 19);
            label4.TabIndex = 9;
            label4.Text = "Nhân viên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label3.Location = new Point(30, 80);
            label3.Name = "label3";
            label3.Size = new Size(112, 19);
            label3.TabIndex = 8;
            label3.Text = "Nhà cung cấp:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label2.Location = new Point(30, 55);
            label2.Name = "label2";
            label2.Size = new Size(91, 19);
            label2.TabIndex = 7;
            label2.Text = "Ngày nhập:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(84, 19);
            label1.TabIndex = 6;
            label1.Text = "Mã phiếu:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblTongTien);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(dgvChiTiet);
            groupBox2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            groupBox2.Location = new Point(30, 250);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(940, 320);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết sản phẩm nhập kho";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Times New Roman", 14.2F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.Red;
            lblTongTien.Location = new Point(770, 265);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(0, 26);
            lblTongTien.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label8.Location = new Point(650, 270);
            label8.Name = "label8";
            label8.Size = new Size(128, 23);
            label8.TabIndex = 1;
            label8.Text = "TỔNG TIỀN:";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.BorderStyle = BorderStyle.None;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Columns.AddRange(new DataGridViewColumn[] { colSTT, colMaSP, colTenSP, colSoLuong, colDonGia, colThanhTien });
            dgvChiTiet.Location = new Point(63, 42);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(813, 220);
            dgvChiTiet.TabIndex = 0;
            // 
            // colSTT
            // 
            colSTT.HeaderText = "STT";
            colSTT.MinimumWidth = 6;
            colSTT.Name = "colSTT";
            colSTT.ReadOnly = true;
            colSTT.Width = 50;
            // 
            // colMaSP
            // 
            colMaSP.HeaderText = "Mã SP";
            colMaSP.MinimumWidth = 6;
            colMaSP.Name = "colMaSP";
            colMaSP.ReadOnly = true;
            colMaSP.Width = 125;
            // 
            // colTenSP
            // 
            colTenSP.HeaderText = "Tên sản phẩm";
            colTenSP.MinimumWidth = 6;
            colTenSP.Name = "colTenSP";
            colTenSP.ReadOnly = true;
            colTenSP.Width = 300;
            // 
            // colSoLuong
            // 
            colSoLuong.HeaderText = "SL";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            colSoLuong.Width = 70;
            // 
            // colDonGia
            // 
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.MinimumWidth = 6;
            colDonGia.Name = "colDonGia";
            colDonGia.ReadOnly = true;
            colDonGia.Width = 120;
            // 
            // colThanhTien
            // 
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.MinimumWidth = 6;
            colThanhTien.Name = "colThanhTien";
            colThanhTien.ReadOnly = true;
            colThanhTien.Width = 140;
            // 
            // btnIn
            // 
            btnIn.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            btnIn.Location = new Point(700, 590);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(120, 40);
            btnIn.TabIndex = 3;
            btnIn.Text = "In phiếu";
            btnIn.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            btnDong.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            btnDong.Location = new Point(840, 590);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(100, 40);
            btnDong.TabIndex = 4;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // frmViewHoaDonNhapDetails
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(btnDong);
            Controls.Add(btnIn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pnlHeader);
            Font = new Font("Times New Roman", 10.2F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmViewHoaDonNhapDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phiếu Nhập Hàng - Xem Chi Tiết";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblShopName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblMaHDN;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
    }
}