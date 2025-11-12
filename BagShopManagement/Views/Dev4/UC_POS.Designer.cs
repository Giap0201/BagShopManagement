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
            grpActions = new GroupBox();
            cboPhuongThucTT = new ComboBox();
            lblPhuongThucTT = new Label();
            btnPrint = new Button();
            btnCheckout = new Button();
            btnSaveDraft = new Button();
            lblTotal = new Label();
            btnApplyDiscount = new Button();
            numDiscountPercent = new NumericUpDown();
            lblDiscount = new Label();
            grpAdd = new GroupBox();
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
            pnlTop.SuspendLayout();
            pnlLeft.SuspendLayout();
            grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscountPercent).BeginInit();
            grpAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
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
            pnlTop.Size = new Size(1578, 204);
            pnlTop.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(447, 33);
            label1.Name = "label1";
            label1.Size = new Size(110, 41);
            label1.TabIndex = 8;
            label1.Text = "Tên KH";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(152, 132);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(250, 47);
            txtMaNV.TabIndex = 0;
            txtMaNV.TextChanged += txtMaNV_TextChanged;
            // 
            // lblNv
            // 
            lblNv.AutoSize = true;
            lblNv.Location = new Point(30, 132);
            lblNv.Name = "lblNv";
            lblNv.Size = new Size(109, 41);
            lblNv.TabIndex = 2;
            lblNv.Text = "Mã NV";
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.FromArgb(0, 122, 204);
            btnLoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLoc.ForeColor = Color.White;
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
            txtSDT.Location = new Point(1114, 33);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(250, 47);
            txtSDT.TabIndex = 6;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(944, 36);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(117, 41);
            lblSDT.TabIndex = 5;
            lblSDT.Text = "SĐT KH";
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(580, 33);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.ReadOnly = true;
            txtTenKH.Size = new Size(322, 47);
            txtTenKH.TabIndex = 4;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(152, 30);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(236, 47);
            txtMaKH.TabIndex = 1;
            // 
            // lblKh
            // 
            lblKh.AutoSize = true;
            lblKh.Location = new Point(30, 30);
            lblKh.Name = "lblKh";
            lblKh.Size = new Size(106, 41);
            lblKh.TabIndex = 3;
            lblKh.Text = "Mã KH";
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(grpActions);
            pnlLeft.Controls.Add(grpAdd);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 204);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(595, 775);
            pnlLeft.TabIndex = 1;
            // 
            // grpActions
            // 
            grpActions.Controls.Add(cboPhuongThucTT);
            grpActions.Controls.Add(lblPhuongThucTT);
            grpActions.Controls.Add(btnPrint);
            grpActions.Controls.Add(btnCheckout);
            grpActions.Controls.Add(btnSaveDraft);
            grpActions.Controls.Add(lblTotal);
            grpActions.Controls.Add(btnApplyDiscount);
            grpActions.Controls.Add(numDiscountPercent);
            grpActions.Controls.Add(lblDiscount);
            grpActions.Location = new Point(10, 426);
            grpActions.Name = "grpActions";
            grpActions.Size = new Size(585, 349);
            grpActions.TabIndex = 0;
            grpActions.TabStop = false;
            grpActions.Text = "Thanh toán và khuyến mãi";
            // 
            // cboPhuongThucTT
            // 
            cboPhuongThucTT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongThucTT.Font = new Font("Segoe UI", 10F);
            cboPhuongThucTT.FormattingEnabled = true;
            cboPhuongThucTT.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Card" });
            cboPhuongThucTT.Location = new Point(313, 215);
            cboPhuongThucTT.Name = "cboPhuongThucTT";
            cboPhuongThucTT.Size = new Size(266, 53);
            cboPhuongThucTT.TabIndex = 8;
            // 
            // lblPhuongThucTT
            // 
            lblPhuongThucTT.Font = new Font("Segoe UI", 9.900001F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhuongThucTT.ForeColor = SystemColors.ActiveCaptionText;
            lblPhuongThucTT.Location = new Point(20, 218);
            lblPhuongThucTT.Name = "lblPhuongThucTT";
            lblPhuongThucTT.Size = new Size(304, 50);
            lblPhuongThucTT.TabIndex = 7;
            lblPhuongThucTT.Text = "Phương thức TT:";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(136, 355);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(191, 52);
            btnPrint.TabIndex = 0;
            btnPrint.Text = "In hóa đơn";
            btnPrint.Click += btnPrint_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(297, 281);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(196, 65);
            btnCheckout.TabIndex = 1;
            btnCheckout.Text = "Thanh toán";
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnSaveDraft
            // 
            btnSaveDraft.Location = new Point(91, 281);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(130, 65);
            btnSaveDraft.TabIndex = 2;
            btnSaveDraft.Text = "Lưu tạm";
            btnSaveDraft.Click += btnSaveDraft_Click;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(20, 148);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(420, 45);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Tổng: 0 ₫";
            // 
            // btnApplyDiscount
            // 
            btnApplyDiscount.Location = new Point(382, 63);
            btnApplyDiscount.Name = "btnApplyDiscount";
            btnApplyDiscount.Size = new Size(181, 52);
            btnApplyDiscount.TabIndex = 4;
            btnApplyDiscount.Text = "Áp dụng";
            btnApplyDiscount.Click += btnApplyDiscount_Click;
            // 
            // numDiscountPercent
            // 
            numDiscountPercent.Location = new Point(190, 68);
            numDiscountPercent.Name = "numDiscountPercent";
            numDiscountPercent.Size = new Size(134, 47);
            numDiscountPercent.TabIndex = 5;
            // 
            // lblDiscount
            // 
            lblDiscount.Location = new Point(20, 70);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(165, 45);
            lblDiscount.TabIndex = 6;
            lblDiscount.Text = "Giảm (%):";
            // 
            // grpAdd
            // 
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
            grpAdd.Location = new Point(10, 10);
            grpAdd.Name = "grpAdd";
            grpAdd.Size = new Size(588, 410);
            grpAdd.TabIndex = 1;
            grpAdd.TabStop = false;
            grpAdd.Text = "Thêm sản phẩm";
            // 
            // lblGiaSP
            // 
            lblGiaSP.BackColor = SystemColors.Control;
            lblGiaSP.BorderStyle = BorderStyle.Fixed3D;
            lblGiaSP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGiaSP.ForeColor = Color.Green;
            lblGiaSP.Location = new Point(190, 225);
            lblGiaSP.Name = "lblGiaSP";
            lblGiaSP.Size = new Size(357, 59);
            lblGiaSP.TabIndex = 10;
            lblGiaSP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenSP
            // 
            lblTenSP.BackColor = SystemColors.Control;
            lblTenSP.BorderStyle = BorderStyle.Fixed3D;
            lblTenSP.Font = new Font("Segoe UI", 10F);
            lblTenSP.Location = new Point(190, 160);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(357, 65);
            lblTenSP.TabIndex = 9;
            lblTenSP.TextAlign = ContentAlignment.MiddleLeft;
            lblTenSP.Click += lblTenSP_Click;
            // 
            // lblMaSPValue
            // 
            lblMaSPValue.BackColor = SystemColors.Control;
            lblMaSPValue.BorderStyle = BorderStyle.Fixed3D;
            lblMaSPValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaSPValue.Location = new Point(190, 99);
            lblMaSPValue.Name = "lblMaSPValue";
            lblMaSPValue.Size = new Size(357, 51);
            lblMaSPValue.TabIndex = 8;
            lblMaSPValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaSPLabel
            // 
            lblMaSPLabel.Location = new Point(20, 99);
            lblMaSPLabel.Name = "lblMaSPLabel";
            lblMaSPLabel.Size = new Size(160, 54);
            lblMaSPLabel.TabIndex = 11;
            lblMaSPLabel.Text = "Mã SP:";
            lblMaSPLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTenSPLabel
            // 
            lblTenSPLabel.Location = new Point(20, 160);
            lblTenSPLabel.Name = "lblTenSPLabel";
            lblTenSPLabel.Size = new Size(160, 65);
            lblTenSPLabel.TabIndex = 12;
            lblTenSPLabel.Text = "Tên SP:";
            lblTenSPLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblGiaSPLabel
            // 
            lblGiaSPLabel.Location = new Point(20, 225);
            lblGiaSPLabel.Name = "lblGiaSPLabel";
            lblGiaSPLabel.Size = new Size(160, 59);
            lblGiaSPLabel.TabIndex = 13;
            lblGiaSPLabel.Text = "Giá:";
            lblGiaSPLabel.TextAlign = ContentAlignment.MiddleRight;
            lblGiaSPLabel.Click += lblGiaSPLabel_Click;
            // 
            // btnChonSP
            // 
            btnChonSP.BackColor = Color.Yellow;
            btnChonSP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
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
            btnDelete.Location = new Point(225, 340);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 50);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Xóa";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(397, 340);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 50);
            btnClear.TabIndex = 1;
            btnClear.Text = "Xóa giỏ";
            btnClear.Click += btnClear_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(40, 340);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 50);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm vào giỏ";
            btnAdd.Click += btnAdd_Click;
            // 
            // numQty
            // 
            numQty.Location = new Point(190, 287);
            numQty.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(167, 47);
            numQty.TabIndex = 3;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQty
            // 
            lblQty.Location = new Point(34, 287);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(153, 45);
            lblQty.TabIndex = 4;
            lblQty.Text = "Số lượng:";
            // 
            // lblSanPham
            // 
            lblSanPham.Location = new Point(20, 50);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Size = new Size(160, 43);
            lblSanPham.TabIndex = 6;
            lblSanPham.Text = "Sản phẩm:";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(dgvCart);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(595, 204);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(983, 775);
            pnlRight.TabIndex = 0;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeight = 29;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(0, 0);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(983, 775);
            dgvCart.TabIndex = 0;
            dgvCart.CellContentClick += dgvCart_CellContentClick;
            // 
            // UC_POS
            // 
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlTop);
            Name = "UC_POS";
            Size = new Size(1578, 979);
            Load += UC_POS_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlLeft.ResumeLayout(false);
            grpActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numDiscountPercent).EndInit();
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
        private GroupBox grpActions;
        private ComboBox cboPhuongThucTT;
        private Label lblPhuongThucTT;
        private Button btnApplyDiscount;
        private NumericUpDown numDiscountPercent;
        private Label lblDiscount;
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
    }
}
