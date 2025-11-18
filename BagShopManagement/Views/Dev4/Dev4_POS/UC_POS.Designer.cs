namespace BagShopManagement.Views.Dev4.Dev4_POS
{
    partial class UC_POS
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            picSanPham = new PictureBox();
            pnlTop = new Panel();
            label1 = new Label();
            txtMaNV = new TextBox();
            lblNv = new Label();
            btnLoc = new Button();
            txtSDT = new TextBox();
            lblSDT = new Label();
            txtTenKH = new TextBox();
            txtMaKH = new TextBox();
            lblKh = new Label();
            pnlLeft = new Panel();
            grpAdd = new GroupBox();
            cboPhuongThucTT = new ComboBox();
            lblPhuongThucTT = new Label();
            btnPrint = new Button();
            btnCheckout = new Button();
            btnSaveDraft = new Button();
            lblTotal = new Label();
            lblKhuyenMaiValue = new Label();
            lblKhuyenMai = new Label();
            lblGiaSP = new Label();
            lblTenSP = new Label();
            lblMaSPValue = new Label();
            lblMaSPLabel = new Label();
            lblTenSPLabel = new Label();
            lblGiaSPLabel = new Label();
            btnChonSP = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnAdd = new Button();
            numQty = new NumericUpDown();
            lblQty = new Label();
            lblSanPham = new Label();
            pnlRight = new Panel();
            dgvCart = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picSanPham).BeginInit();
            pnlTop.SuspendLayout();
            pnlLeft.SuspendLayout();
            grpAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // picSanPham
            // 
            picSanPham.BorderStyle = BorderStyle.FixedSingle;
            picSanPham.Location = new Point(111, 418);
            picSanPham.Name = "picSanPham";
            picSanPham.Size = new Size(366, 256);
            picSanPham.SizeMode = PictureBoxSizeMode.Zoom;
            picSanPham.TabIndex = 14;
            picSanPham.TabStop = false;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(255, 255, 255);
            pnlTop.Controls.Add(label1);
            pnlTop.Controls.Add(txtMaNV);
            pnlTop.Controls.Add(lblNv);
            pnlTop.Controls.Add(btnLoc);
            pnlTop.Controls.Add(txtSDT);
            pnlTop.Controls.Add(lblSDT);
            pnlTop.Controls.Add(txtTenKH);
            pnlTop.Controls.Add(txtMaKH);
            pnlTop.Controls.Add(lblKh);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1571, 204);
            pnlTop.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(447, 33);
            label1.Name = "label1";
            label1.Size = new Size(110, 41);
            label1.TabIndex = 8;
            label1.Text = "Tên KH";
            // 
            // txtMaNV
            // 
            txtMaNV.BackColor = Color.FromArgb(255, 255, 255);
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaNV.Location = new Point(152, 132);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(250, 47);
            txtMaNV.TabIndex = 0;
            txtMaNV.TextChanged += txtMaNV_TextChanged;
            // 
            // lblNv
            // 
            lblNv.AutoSize = true;
            lblNv.ForeColor = Color.FromArgb(51, 51, 51);
            lblNv.Location = new Point(30, 132);
            lblNv.Name = "lblNv";
            lblNv.Size = new Size(109, 41);
            lblNv.TabIndex = 2;
            lblNv.Text = "Mã NV";
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.FromArgb(0, 120, 215);
            btnLoc.FlatStyle = FlatStyle.Flat;
            btnLoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLoc.ForeColor = Color.FromArgb(255, 255, 255);
            btnLoc.Location = new Point(1417, 24);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(147, 62);
            btnLoc.TabIndex = 7;
            btnLoc.Text = "🔍 Lọc";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            // 
            // txtSDT
            // 
            txtSDT.BackColor = Color.FromArgb(255, 255, 255);
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.ForeColor = Color.FromArgb(51, 51, 51);
            txtSDT.Location = new Point(1114, 33);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(250, 47);
            txtSDT.TabIndex = 6;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.ForeColor = Color.FromArgb(51, 51, 51);
            lblSDT.Location = new Point(944, 36);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(117, 41);
            lblSDT.TabIndex = 5;
            lblSDT.Text = "SĐT KH";
            // 
            // txtTenKH
            // 
            txtTenKH.BackColor = Color.FromArgb(255, 255, 255);
            txtTenKH.BorderStyle = BorderStyle.FixedSingle;
            txtTenKH.ForeColor = Color.FromArgb(51, 51, 51);
            txtTenKH.Location = new Point(580, 33);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.ReadOnly = true;
            txtTenKH.Size = new Size(322, 47);
            txtTenKH.TabIndex = 4;
            // 
            // txtMaKH
            // 
            txtMaKH.BackColor = Color.FromArgb(255, 255, 255);
            txtMaKH.BorderStyle = BorderStyle.FixedSingle;
            txtMaKH.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaKH.Location = new Point(152, 30);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(236, 47);
            txtMaKH.TabIndex = 1;
            // 
            // lblKh
            // 
            lblKh.AutoSize = true;
            lblKh.ForeColor = Color.FromArgb(51, 51, 51);
            lblKh.Location = new Point(30, 30);
            lblKh.Name = "lblKh";
            lblKh.Size = new Size(106, 41);
            lblKh.TabIndex = 3;
            lblKh.Text = "Mã KH";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(255, 255, 255);
            pnlLeft.Controls.Add(grpAdd);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 204);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(595, 1072);
            pnlLeft.TabIndex = 1;
            // 
            // grpAdd
            // 
            grpAdd.BackColor = Color.FromArgb(255, 255, 255);
            grpAdd.Controls.Add(cboPhuongThucTT);
            grpAdd.Controls.Add(lblPhuongThucTT);
            grpAdd.Controls.Add(btnPrint);
            grpAdd.Controls.Add(btnCheckout);
            grpAdd.Controls.Add(btnSaveDraft);
            grpAdd.Controls.Add(lblTotal);
            grpAdd.Controls.Add(picSanPham);
            grpAdd.Controls.Add(lblKhuyenMaiValue);
            grpAdd.Controls.Add(lblKhuyenMai);
            grpAdd.Controls.Add(lblGiaSP);
            grpAdd.Controls.Add(lblTenSP);
            grpAdd.Controls.Add(lblMaSPValue);
            grpAdd.Controls.Add(lblMaSPLabel);
            grpAdd.Controls.Add(lblTenSPLabel);
            grpAdd.Controls.Add(lblGiaSPLabel);
            grpAdd.Controls.Add(btnChonSP);
            grpAdd.Controls.Add(btnDelete);
            grpAdd.Controls.Add(btnClear);
            grpAdd.Controls.Add(btnAdd);
            grpAdd.Controls.Add(numQty);
            grpAdd.Controls.Add(lblQty);
            grpAdd.Controls.Add(lblSanPham);
            grpAdd.ForeColor = Color.FromArgb(51, 51, 51);
            grpAdd.Location = new Point(0, 10);
            grpAdd.Name = "grpAdd";
            grpAdd.Size = new Size(595, 1055);
            grpAdd.TabIndex = 1;
            grpAdd.TabStop = false;
            grpAdd.Text = "Bán hàng";
            // 
            // cboPhuongThucTT
            // 
            cboPhuongThucTT.BackColor = Color.FromArgb(255, 255, 255);
            cboPhuongThucTT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongThucTT.FlatStyle = FlatStyle.Flat;
            cboPhuongThucTT.Font = new Font("Segoe UI", 10F);
            cboPhuongThucTT.ForeColor = Color.FromArgb(51, 51, 51);
            cboPhuongThucTT.FormattingEnabled = true;
            cboPhuongThucTT.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Card" });
            cboPhuongThucTT.Location = new Point(20, 852);
            cboPhuongThucTT.Name = "cboPhuongThucTT";
            cboPhuongThucTT.Size = new Size(286, 53);
            cboPhuongThucTT.TabIndex = 8;
            // 
            // lblPhuongThucTT
            // 
            lblPhuongThucTT.Font = new Font("Segoe UI", 9.900001F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhuongThucTT.ForeColor = Color.FromArgb(51, 51, 51);
            lblPhuongThucTT.Location = new Point(30, 780);
            lblPhuongThucTT.Name = "lblPhuongThucTT";
            lblPhuongThucTT.Size = new Size(292, 50);
            lblPhuongThucTT.TabIndex = 7;
            lblPhuongThucTT.Text = "Phương thức TT:";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(248, 248, 248);
            btnPrint.FlatAppearance.BorderColor = Color.FromArgb(187, 187, 187);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.ForeColor = Color.FromArgb(51, 51, 51);
            btnPrint.Location = new Point(333, 994);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(262, 65);
            btnPrint.TabIndex = 0;
            btnPrint.Text = "In hóa đơn";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(0, 120, 215);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.ForeColor = Color.FromArgb(255, 255, 255);
            btnCheckout.Location = new Point(333, 810);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(262, 65);
            btnCheckout.TabIndex = 1;
            btnCheckout.Text = "💳 Thanh toán";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnSaveDraft
            // 
            btnSaveDraft.BackColor = Color.FromArgb(224, 224, 224);
            btnSaveDraft.FlatStyle = FlatStyle.Flat;
            btnSaveDraft.ForeColor = Color.FromArgb(51, 51, 51);
            btnSaveDraft.Location = new Point(333, 907);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(262, 65);
            btnSaveDraft.TabIndex = 2;
            btnSaveDraft.Text = "💾 Lưu tạm";
            btnSaveDraft.UseVisualStyleBackColor = false;
            btnSaveDraft.Click += btnSaveDraft_Click;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(0, 120, 215);
            lblTotal.Location = new Point(0, 987);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(300, 68);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Tổng: 0 ₫";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblKhuyenMaiValue
            // 
            lblKhuyenMaiValue.BackColor = Color.FromArgb(255, 255, 224);
            lblKhuyenMaiValue.BorderStyle = BorderStyle.Fixed3D;
            lblKhuyenMaiValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblKhuyenMaiValue.ForeColor = Color.Gray;
            lblKhuyenMaiValue.Location = new Point(223, 230);
            lblKhuyenMaiValue.Name = "lblKhuyenMaiValue";
            lblKhuyenMaiValue.Size = new Size(324, 47);
            lblKhuyenMaiValue.TabIndex = 16;
            lblKhuyenMaiValue.Text = "0%";
            lblKhuyenMaiValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKhuyenMai
            // 
            lblKhuyenMai.Location = new Point(3, 230);
            lblKhuyenMai.Name = "lblKhuyenMai";
            lblKhuyenMai.Size = new Size(188, 59);
            lblKhuyenMai.TabIndex = 15;
            lblKhuyenMai.Text = "Khuyến mãi:";
            lblKhuyenMai.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGiaSP
            // 
            lblGiaSP.BackColor = SystemColors.Control;
            lblGiaSP.BorderStyle = BorderStyle.Fixed3D;
            lblGiaSP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGiaSP.ForeColor = Color.Green;
            lblGiaSP.Location = new Point(223, 353);
            lblGiaSP.Name = "lblGiaSP";
            lblGiaSP.Size = new Size(322, 47);
            lblGiaSP.TabIndex = 10;
            lblGiaSP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenSP
            // 
            lblTenSP.BackColor = SystemColors.Control;
            lblTenSP.BorderStyle = BorderStyle.Fixed3D;
            lblTenSP.Font = new Font("Segoe UI", 10F);
            lblTenSP.Location = new Point(223, 173);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(322, 44);
            lblTenSP.TabIndex = 9;
            lblTenSP.TextAlign = ContentAlignment.MiddleLeft;
            lblTenSP.Click += lblTenSP_Click;
            // 
            // lblMaSPValue
            // 
            lblMaSPValue.BackColor = SystemColors.Control;
            lblMaSPValue.BorderStyle = BorderStyle.Fixed3D;
            lblMaSPValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaSPValue.Location = new Point(223, 109);
            lblMaSPValue.Name = "lblMaSPValue";
            lblMaSPValue.Size = new Size(238, 54);
            lblMaSPValue.TabIndex = 8;
            lblMaSPValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaSPLabel
            // 
            lblMaSPLabel.Location = new Point(30, 110);
            lblMaSPLabel.Name = "lblMaSPLabel";
            lblMaSPLabel.Size = new Size(160, 54);
            lblMaSPLabel.TabIndex = 11;
            lblMaSPLabel.Text = "Mã SP:";
            lblMaSPLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTenSPLabel
            // 
            lblTenSPLabel.Location = new Point(36, 164);
            lblTenSPLabel.Name = "lblTenSPLabel";
            lblTenSPLabel.Size = new Size(156, 65);
            lblTenSPLabel.TabIndex = 12;
            lblTenSPLabel.Text = "Tên SP:";
            lblTenSPLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGiaSPLabel
            // 
            lblGiaSPLabel.Location = new Point(36, 341);
            lblGiaSPLabel.Name = "lblGiaSPLabel";
            lblGiaSPLabel.Size = new Size(158, 59);
            lblGiaSPLabel.TabIndex = 13;
            lblGiaSPLabel.Text = "Giá SP:";
            lblGiaSPLabel.TextAlign = ContentAlignment.MiddleRight;
            lblGiaSPLabel.Click += lblGiaSPLabel_Click;
            // 
            // btnChonSP
            // 
            btnChonSP.BackColor = Color.FromArgb(0, 120, 215);
            btnChonSP.FlatStyle = FlatStyle.Flat;
            btnChonSP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChonSP.ForeColor = Color.FromArgb(255, 255, 255);
            btnChonSP.Location = new Point(190, 46);
            btnChonSP.Name = "btnChonSP";
            btnChonSP.Size = new Size(357, 50);
            btnChonSP.TabIndex = 7;
            btnChonSP.Text = "*** Chọn sản phẩm";
            btnChonSP.UseVisualStyleBackColor = false;
            btnChonSP.Click += btnChonSP_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.FromArgb(255, 255, 255);
            btnDelete.Location = new Point(223, 690);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 61);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(231, 76, 60);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.FromArgb(255, 255, 255);
            btnClear.Location = new Point(395, 690);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 61);
            btnClear.TabIndex = 1;
            btnClear.Text = "Xóa giỏ";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 120, 215);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.FromArgb(255, 255, 255);
            btnAdd.Location = new Point(38, 690);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(156, 61);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm vào giỏ";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // numQty
            // 
            numQty.BackColor = Color.FromArgb(255, 255, 255);
            numQty.BorderStyle = BorderStyle.FixedSingle;
            numQty.ForeColor = Color.FromArgb(51, 51, 51);
            numQty.Location = new Point(223, 294);
            numQty.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(145, 47);
            numQty.TabIndex = 3;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQty
            // 
            lblQty.ForeColor = Color.FromArgb(51, 51, 51);
            lblQty.Location = new Point(49, 296);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(160, 45);
            lblQty.TabIndex = 4;
            lblQty.Text = "Số lượng:";
            lblQty.Click += lblQty_Click;
            // 
            // lblSanPham
            // 
            lblSanPham.ForeColor = Color.FromArgb(51, 51, 51);
            lblSanPham.Location = new Point(20, 50);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Size = new Size(160, 43);
            lblSanPham.TabIndex = 6;
            lblSanPham.Text = "Sản phẩm:";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(255, 255, 255);
            pnlRight.Controls.Add(dgvCart);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(595, 204);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(976, 1072);
            pnlRight.TabIndex = 0;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvCart.ColumnHeadersHeight = 29;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.GridColor = Color.FromArgb(204, 204, 204);
            dgvCart.Location = new Point(0, 0);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(976, 1072);
            dgvCart.TabIndex = 0;
            dgvCart.CellContentClick += dgvCart_CellContentClick;
            // 
            // UC_POS
            // 
            BackColor = Color.FromArgb(240, 240, 240);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlTop);
            Name = "UC_POS";
            Size = new Size(1571, 1276);
            Load += UC_POS_Load;
            ((System.ComponentModel.ISupportInitialize)picSanPham).EndInit();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlLeft.ResumeLayout(false);
            grpAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblNv;
        private Label lblKh;
        private Label lblSDT;
        private TextBox txtMaNV;
        private TextBox txtMaKH;
        private TextBox txtTenKH;
        private TextBox txtSDT;
        private Button btnLoc;
        private Panel pnlLeft;
        private GroupBox grpAdd;
        private NumericUpDown numQty;
        private Label lblQty;
        private Label lblSanPham;
        private Label lblMaSPLabel;
        private Label lblTenSPLabel;
        private Label lblGiaSPLabel;
        private Button btnChonSP;
        private Label lblMaSPValue;
        private Label lblTenSP;
        private Label lblGiaSP;
        private ComboBox cboPhuongThucTT;
        private Label lblPhuongThucTT;
        private Button btnClear;
        private Button btnAdd;
        private Button btnCheckout;
        private Button btnSaveDraft;
        private Label lblTotal;
        private Button btnPrint;
        private Panel pnlRight;
        private DataGridView dgvCart;
        private Button btnDelete;
        private Label label1;
        private PictureBox picSanPham;
        private Label lblKhuyenMai;
        private Label lblKhuyenMaiValue;
    }
}
