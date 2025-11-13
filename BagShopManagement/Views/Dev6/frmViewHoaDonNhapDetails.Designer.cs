namespace BagShopManagement.Views.Dev6
{
    partial class frmViewHoaDonNhapDetails
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox groupBoxHeader;
        private Label lblMaHDN;
        private Label lblNCC;
        private Label lblNV;
        private Label lblNgayNhap;
        private Label lblGhiChu;
        private Label lblTrangThai;
        private Label lblNgayDuyet;
        private Label lblNgayHuy;

        private Label valMaHDN;
        private Label valNCC;
        private Label valNV;
        private Label valNgayNhap;
        private Label valGhiChu;
        private Label valTrangThai;
        private Label valNgayDuyet;
        private Label valNgayHuy;

        private GroupBox groupBoxDetails;
        private DataGridView dgvChiTiet;
        private Label lblTongTienText;
        private Label valTongTien;

        private Button btnIn;
        private Button btnDong;

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxHeader = new GroupBox();
            lblMaHDN = new Label();
            valMaHDN = new Label();
            lblNCC = new Label();
            valNCC = new Label();
            lblNV = new Label();
            valNV = new Label();
            lblNgayNhap = new Label();
            valNgayNhap = new Label();
            lblGhiChu = new Label();
            valGhiChu = new Label();
            lblTrangThai = new Label();
            valTrangThai = new Label();
            lblNgayDuyet = new Label();
            valNgayDuyet = new Label();
            lblNgayHuy = new Label();
            valNgayHuy = new Label();
            groupBoxDetails = new GroupBox();
            dgvChiTiet = new DataGridView();
            lblTongTienText = new Label();
            valTongTien = new Label();
            btnIn = new Button();
            btnDong = new Button();
            groupBoxHeader.SuspendLayout();
            groupBoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // groupBoxHeader
            // 
            groupBoxHeader.Controls.Add(lblMaHDN);
            groupBoxHeader.Controls.Add(valMaHDN);
            groupBoxHeader.Controls.Add(lblNCC);
            groupBoxHeader.Controls.Add(valNCC);
            groupBoxHeader.Controls.Add(lblNV);
            groupBoxHeader.Controls.Add(valNV);
            groupBoxHeader.Controls.Add(lblNgayNhap);
            groupBoxHeader.Controls.Add(valNgayNhap);
            groupBoxHeader.Controls.Add(lblGhiChu);
            groupBoxHeader.Controls.Add(valGhiChu);
            groupBoxHeader.Controls.Add(lblTrangThai);
            groupBoxHeader.Controls.Add(valTrangThai);
            groupBoxHeader.Controls.Add(lblNgayDuyet);
            groupBoxHeader.Controls.Add(valNgayDuyet);
            groupBoxHeader.Controls.Add(lblNgayHuy);
            groupBoxHeader.Controls.Add(valNgayHuy);
            groupBoxHeader.Location = new Point(30, 20);
            groupBoxHeader.Name = "groupBoxHeader";
            groupBoxHeader.Size = new Size(1400, 230);
            groupBoxHeader.TabIndex = 0;
            groupBoxHeader.TabStop = false;
            groupBoxHeader.Text = "Thông tin hóa đơn nhập";
            // 
            // lblMaHDN
            // 
            lblMaHDN.Location = new Point(40, 40);
            lblMaHDN.Name = "lblMaHDN";
            lblMaHDN.Size = new Size(130, 30);
            lblMaHDN.TabIndex = 0;
            lblMaHDN.Text = "Mã HĐN:";
            // 
            // valMaHDN
            // 
            valMaHDN.Location = new Point(180, 40);
            valMaHDN.Name = "valMaHDN";
            valMaHDN.Size = new Size(320, 30);
            valMaHDN.TabIndex = 1;
            // 
            // lblNCC
            // 
            lblNCC.Location = new Point(40, 90);
            lblNCC.Name = "lblNCC";
            lblNCC.Size = new Size(130, 30);
            lblNCC.TabIndex = 2;
            lblNCC.Text = "Nhà cung cấp:";
            // 
            // valNCC
            // 
            valNCC.Location = new Point(180, 90);
            valNCC.Name = "valNCC";
            valNCC.Size = new Size(320, 30);
            valNCC.TabIndex = 3;
            // 
            // lblNV
            // 
            lblNV.Location = new Point(40, 140);
            lblNV.Name = "lblNV";
            lblNV.Size = new Size(130, 30);
            lblNV.TabIndex = 4;
            lblNV.Text = "Nhân viên lập:";
            // 
            // valNV
            // 
            valNV.Location = new Point(180, 140);
            valNV.Name = "valNV";
            valNV.Size = new Size(320, 30);
            valNV.TabIndex = 5;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.Location = new Point(550, 40);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(120, 30);
            lblNgayNhap.TabIndex = 6;
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // valNgayNhap
            // 
            valNgayNhap.Location = new Point(690, 40);
            valNgayNhap.Name = "valNgayNhap";
            valNgayNhap.Size = new Size(320, 30);
            valNgayNhap.TabIndex = 7;
            // 
            // lblGhiChu
            // 
            lblGhiChu.Location = new Point(550, 90);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(120, 30);
            lblGhiChu.TabIndex = 8;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // valGhiChu
            // 
            valGhiChu.Location = new Point(690, 90);
            valGhiChu.Name = "valGhiChu";
            valGhiChu.Size = new Size(320, 30);
            valGhiChu.TabIndex = 9;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Location = new Point(550, 140);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(120, 30);
            lblTrangThai.TabIndex = 10;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // valTrangThai
            // 
            valTrangThai.Location = new Point(690, 140);
            valTrangThai.Name = "valTrangThai";
            valTrangThai.Size = new Size(320, 30);
            valTrangThai.TabIndex = 11;
            // 
            // lblNgayDuyet
            // 
            lblNgayDuyet.Location = new Point(1100, 40);
            lblNgayDuyet.Name = "lblNgayDuyet";
            lblNgayDuyet.Size = new Size(120, 30);
            lblNgayDuyet.TabIndex = 12;
            lblNgayDuyet.Text = "Ngày duyệt:";
            // 
            // valNgayDuyet
            // 
            valNgayDuyet.Location = new Point(1230, 40);
            valNgayDuyet.Name = "valNgayDuyet";
            valNgayDuyet.Size = new Size(200, 30);
            valNgayDuyet.TabIndex = 13;
            // 
            // lblNgayHuy
            // 
            lblNgayHuy.Location = new Point(1100, 90);
            lblNgayHuy.Name = "lblNgayHuy";
            lblNgayHuy.Size = new Size(120, 30);
            lblNgayHuy.TabIndex = 14;
            lblNgayHuy.Text = "Ngày hủy:";
            // 
            // valNgayHuy
            // 
            valNgayHuy.Location = new Point(1230, 90);
            valNgayHuy.Name = "valNgayHuy";
            valNgayHuy.Size = new Size(200, 30);
            valNgayHuy.TabIndex = 15;
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(dgvChiTiet);
            groupBoxDetails.Controls.Add(lblTongTienText);
            groupBoxDetails.Controls.Add(valTongTien);
            groupBoxDetails.Location = new Point(30, 270);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Size = new Size(1400, 420);
            groupBoxDetails.TabIndex = 1;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Chi tiết sản phẩm";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ColumnHeadersHeight = 29;
            dgvChiTiet.Location = new Point(40, 40);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.Size = new Size(900, 330);
            dgvChiTiet.TabIndex = 0;
            // 
            // lblTongTienText
            // 
            lblTongTienText.Location = new Point(982, 330);
            lblTongTienText.Name = "lblTongTienText";
            lblTongTienText.Size = new Size(140, 30);
            lblTongTienText.TabIndex = 1;
            lblTongTienText.Text = "Tổng tiền:";
            // 
            // valTongTien
            // 
            valTongTien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            valTongTien.Location = new Point(1146, 330);
            valTongTien.Name = "valTongTien";
            valTongTien.Size = new Size(200, 30);
            valTongTien.TabIndex = 2;
            valTongTien.Text = "0";
            // 
            // btnIn
            // 
            btnIn.Location = new Point(530, 720);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(150, 35);
            btnIn.TabIndex = 2;
            btnIn.Text = "IN HÓA ĐƠN";
            // 
            // btnDong
            // 
            btnDong.Location = new Point(720, 720);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(120, 35);
            btnDong.TabIndex = 3;
            btnDong.Text = "ĐÓNG";
            // 
            // frmViewHoaDonNhapDetails
            // 
            ClientSize = new Size(1500, 800);
            Controls.Add(groupBoxHeader);
            Controls.Add(groupBoxDetails);
            Controls.Add(btnIn);
            Controls.Add(btnDong);
            MaximizeBox = false;
            Name = "frmViewHoaDonNhapDetails";
            Text = "Xem chi tiết hóa đơn nhập";
            Load += frmViewHoaDonNhapDetails_Load;
            groupBoxHeader.ResumeLayout(false);
            groupBoxDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
        }
    }
}
