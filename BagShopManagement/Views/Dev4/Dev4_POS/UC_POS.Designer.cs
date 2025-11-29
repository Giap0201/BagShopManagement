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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            picSanPham = new PictureBox();
            pnlTop = new Panel();
            label2 = new Label();
            label1 = new Label();
            txtTenNV = new TextBox();
            txtMaNV = new TextBox();
            lblNv = new Label();
            btnLoc = new Button();
            txtSDT = new TextBox();
            lblSDT = new Label();
            txtTenKH = new TextBox();
            txtMaKH = new TextBox();
            lblKh = new Label();
            grpAdd = new GroupBox();
            cboPhuongThucTT = new ComboBox();
            lblPhuongThucTT = new Label();
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
            label7 = new Label();
            dgvCart = new DataGridView();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)picSanPham).BeginInit();
            pnlTop.SuspendLayout();
            grpAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // picSanPham
            // 
            picSanPham.BorderStyle = BorderStyle.FixedSingle;
            picSanPham.Location = new Point(43, 313);
            picSanPham.Name = "picSanPham";
            picSanPham.Size = new Size(512, 159);
            picSanPham.SizeMode = PictureBoxSizeMode.Zoom;
            picSanPham.TabIndex = 14;
            picSanPham.TabStop = false;
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.FromArgb(255, 255, 255);
            pnlTop.Controls.Add(label3);
            pnlTop.Controls.Add(label2);
            pnlTop.Controls.Add(label1);
            pnlTop.Controls.Add(txtTenNV);
            pnlTop.Controls.Add(txtMaNV);
            pnlTop.Controls.Add(lblNv);
            pnlTop.Controls.Add(btnLoc);
            pnlTop.Controls.Add(txtSDT);
            pnlTop.Controls.Add(lblSDT);
            pnlTop.Controls.Add(txtTenKH);
            pnlTop.Controls.Add(txtMaKH);
            pnlTop.Controls.Add(lblKh);
            pnlTop.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlTop.ForeColor = Color.FromArgb(54, 54, 54);
            pnlTop.Location = new Point(43, 50);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1476, 184);
            pnlTop.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(51, 51, 51);
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(159, 23);
            label2.TabIndex = 9;
            label2.Text = "LỌC KHÁCH HÀNG";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(672, 44);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 8;
            label1.Text = "Tên khách hàng:";
            // 
            // txtTenNV
            // 
            txtTenNV.BackColor = Color.FromArgb(240, 240, 240);
            txtTenNV.BorderStyle = BorderStyle.FixedSingle;
            txtTenNV.Font = new Font("Segoe UI", 10.2F);
            txtTenNV.ForeColor = Color.FromArgb(51, 51, 51);
            txtTenNV.Location = new Point(225, 139);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.ReadOnly = true;
            txtTenNV.Size = new Size(236, 30);
            txtTenNV.TabIndex = 11;
            // 
            // txtMaNV
            // 
            txtMaNV.BackColor = Color.FromArgb(240, 240, 240);
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.Font = new Font("Segoe UI", 10.2F);
            txtMaNV.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaNV.Location = new Point(225, 94);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(236, 30);
            txtMaNV.TabIndex = 0;
            // 
            // lblNv
            // 
            lblNv.AutoSize = true;
            lblNv.ForeColor = Color.FromArgb(51, 51, 51);
            lblNv.Location = new Point(46, 94);
            lblNv.Name = "lblNv";
            lblNv.Size = new Size(120, 23);
            lblNv.TabIndex = 2;
            lblNv.Text = "Mã nhân viên:";
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.FromArgb(0, 120, 215);
            btnLoc.FlatStyle = FlatStyle.Flat;
            btnLoc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoc.ForeColor = Color.FromArgb(255, 255, 255);
            btnLoc.Location = new Point(1287, 76);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(147, 55);
            btnLoc.TabIndex = 7;
            btnLoc.Text = "🔍 LỌC";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click;
            // 
            // txtSDT
            // 
            txtSDT.BackColor = Color.FromArgb(255, 255, 255);
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Font = new Font("Segoe UI", 10.2F);
            txtSDT.ForeColor = Color.FromArgb(51, 51, 51);
            txtSDT.Location = new Point(908, 94);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(262, 30);
            txtSDT.TabIndex = 6;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.ForeColor = Color.FromArgb(51, 51, 51);
            lblSDT.Location = new Point(672, 94);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(115, 23);
            lblSDT.TabIndex = 5;
            lblSDT.Text = "Số điện thoại:";
            // 
            // txtTenKH
            // 
            txtTenKH.BackColor = Color.FromArgb(240, 240, 240);
            txtTenKH.BorderStyle = BorderStyle.FixedSingle;
            txtTenKH.Font = new Font("Segoe UI", 10.2F);
            txtTenKH.ForeColor = Color.FromArgb(51, 51, 51);
            txtTenKH.Location = new Point(908, 44);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.ReadOnly = true;
            txtTenKH.Size = new Size(262, 30);
            txtTenKH.TabIndex = 4;
            // 
            // txtMaKH
            // 
            txtMaKH.BackColor = Color.FromArgb(240, 240, 240);
            txtMaKH.BorderStyle = BorderStyle.FixedSingle;
            txtMaKH.Font = new Font("Segoe UI", 10.2F);
            txtMaKH.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaKH.Location = new Point(225, 44);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(236, 30);
            txtMaKH.TabIndex = 1;
            // 
            // lblKh
            // 
            lblKh.AutoSize = true;
            lblKh.ForeColor = Color.FromArgb(51, 51, 51);
            lblKh.Location = new Point(46, 44);
            lblKh.Name = "lblKh";
            lblKh.Size = new Size(134, 23);
            lblKh.TabIndex = 3;
            lblKh.Text = "Mã khách hàng:";
            // 
            // grpAdd
            // 
            grpAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpAdd.BackColor = Color.FromArgb(255, 255, 255);
            grpAdd.Controls.Add(cboPhuongThucTT);
            grpAdd.Controls.Add(lblPhuongThucTT);
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
            grpAdd.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpAdd.ForeColor = Color.FromArgb(51, 51, 51);
            grpAdd.Location = new Point(43, 240);
            grpAdd.Name = "grpAdd";
            grpAdd.Size = new Size(595, 746);
            grpAdd.TabIndex = 1;
            grpAdd.TabStop = false;
            grpAdd.Text = "BÁN HÀNG";
            // 
            // cboPhuongThucTT
            // 
            cboPhuongThucTT.BackColor = SystemColors.Control;
            cboPhuongThucTT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongThucTT.Font = new Font("Segoe UI", 10F);
            cboPhuongThucTT.ForeColor = Color.FromArgb(51, 51, 51);
            cboPhuongThucTT.FormattingEnabled = true;
            cboPhuongThucTT.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Card" });
            cboPhuongThucTT.Location = new Point(43, 602);
            cboPhuongThucTT.Name = "cboPhuongThucTT";
            cboPhuongThucTT.Size = new Size(268, 31);
            cboPhuongThucTT.TabIndex = 8;
            // 
            // lblPhuongThucTT
            // 
            lblPhuongThucTT.Font = new Font("Segoe UI", 9.900001F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhuongThucTT.ForeColor = Color.FromArgb(51, 51, 51);
            lblPhuongThucTT.Location = new Point(39, 568);
            lblPhuongThucTT.Name = "lblPhuongThucTT";
            lblPhuongThucTT.Size = new Size(292, 27);
            lblPhuongThucTT.TabIndex = 7;
            lblPhuongThucTT.Text = "Phương thức TT:";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(0, 120, 215);
            btnCheckout.Cursor = Cursors.Hand;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.FromArgb(255, 255, 255);
            btnCheckout.Location = new Point(352, 568);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(203, 65);
            btnCheckout.TabIndex = 1;
            btnCheckout.Text = "THANH TOÁN";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnSaveDraft
            // 
            btnSaveDraft.BackColor = Color.FromArgb(224, 224, 224);
            btnSaveDraft.Cursor = Cursors.Hand;
            btnSaveDraft.FlatAppearance.BorderSize = 0;
            btnSaveDraft.FlatStyle = FlatStyle.Flat;
            btnSaveDraft.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSaveDraft.ForeColor = Color.FromArgb(51, 51, 51);
            btnSaveDraft.Location = new Point(352, 659);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(203, 47);
            btnSaveDraft.TabIndex = 2;
            btnSaveDraft.Text = "💾 LƯU TẠM";
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
            lblKhuyenMaiValue.Font = new Font("Segoe UI", 10.2F);
            lblKhuyenMaiValue.ForeColor = Color.Gray;
            lblKhuyenMaiValue.Location = new Point(244, 167);
            lblKhuyenMaiValue.Name = "lblKhuyenMaiValue";
            lblKhuyenMaiValue.Size = new Size(311, 36);
            lblKhuyenMaiValue.TabIndex = 16;
            lblKhuyenMaiValue.Text = "0%";
            lblKhuyenMaiValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKhuyenMai
            // 
            lblKhuyenMai.ImageAlign = ContentAlignment.MiddleLeft;
            lblKhuyenMai.Location = new Point(39, 160);
            lblKhuyenMai.Name = "lblKhuyenMai";
            lblKhuyenMai.Size = new Size(188, 43);
            lblKhuyenMai.TabIndex = 15;
            lblKhuyenMai.Text = "Khuyến mãi:";
            lblKhuyenMai.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGiaSP
            // 
            lblGiaSP.BackColor = SystemColors.Control;
            lblGiaSP.BorderStyle = BorderStyle.Fixed3D;
            lblGiaSP.Font = new Font("Segoe UI", 10.2F);
            lblGiaSP.ForeColor = Color.Green;
            lblGiaSP.Location = new Point(244, 265);
            lblGiaSP.Name = "lblGiaSP";
            lblGiaSP.Size = new Size(311, 34);
            lblGiaSP.TabIndex = 10;
            lblGiaSP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenSP
            // 
            lblTenSP.BackColor = SystemColors.Control;
            lblTenSP.BorderStyle = BorderStyle.Fixed3D;
            lblTenSP.Font = new Font("Segoe UI", 10.2F);
            lblTenSP.Location = new Point(244, 118);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(311, 34);
            lblTenSP.TabIndex = 9;
            lblTenSP.TextAlign = ContentAlignment.MiddleLeft;
            lblTenSP.Click += lblTenSP_Click;
            // 
            // lblMaSPValue
            // 
            lblMaSPValue.BackColor = SystemColors.Control;
            lblMaSPValue.BorderStyle = BorderStyle.Fixed3D;
            lblMaSPValue.Font = new Font("Segoe UI", 10.2F);
            lblMaSPValue.Location = new Point(244, 73);
            lblMaSPValue.Name = "lblMaSPValue";
            lblMaSPValue.Size = new Size(311, 34);
            lblMaSPValue.TabIndex = 8;
            lblMaSPValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaSPLabel
            // 
            lblMaSPLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblMaSPLabel.Location = new Point(39, 53);
            lblMaSPLabel.Name = "lblMaSPLabel";
            lblMaSPLabel.Size = new Size(120, 54);
            lblMaSPLabel.TabIndex = 11;
            lblMaSPLabel.Text = "Mã sản phẩm:";
            lblMaSPLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenSPLabel
            // 
            lblTenSPLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblTenSPLabel.Location = new Point(39, 107);
            lblTenSPLabel.Name = "lblTenSPLabel";
            lblTenSPLabel.Size = new Size(156, 50);
            lblTenSPLabel.TabIndex = 12;
            lblTenSPLabel.Text = "Tên sản phẩm:";
            lblTenSPLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGiaSPLabel
            // 
            lblGiaSPLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblGiaSPLabel.Location = new Point(39, 251);
            lblGiaSPLabel.Name = "lblGiaSPLabel";
            lblGiaSPLabel.Size = new Size(158, 59);
            lblGiaSPLabel.TabIndex = 13;
            lblGiaSPLabel.Text = "Giá sản phẩm:";
            lblGiaSPLabel.TextAlign = ContentAlignment.MiddleLeft;
            lblGiaSPLabel.Click += lblGiaSPLabel_Click;
            // 
            // btnChonSP
            // 
            btnChonSP.BackColor = Color.FromArgb(0, 120, 215);
            btnChonSP.Cursor = Cursors.Hand;
            btnChonSP.FlatStyle = FlatStyle.Flat;
            btnChonSP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChonSP.ForeColor = Color.FromArgb(255, 255, 255);
            btnChonSP.Location = new Point(244, 19);
            btnChonSP.Name = "btnChonSP";
            btnChonSP.Size = new Size(311, 42);
            btnChonSP.TabIndex = 7;
            btnChonSP.Text = "Chọn sản phẩm";
            btnChonSP.UseVisualStyleBackColor = false;
            btnChonSP.Click += btnChonSP_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(255, 255, 255);
            btnDelete.Location = new Point(234, 498);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 43);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "XOÁ";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(231, 76, 60);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(255, 255, 255);
            btnClear.Location = new Point(405, 498);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 43);
            btnClear.TabIndex = 1;
            btnClear.Text = "XOÁ GIỎ";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 120, 215);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAdd.ForeColor = Color.FromArgb(255, 255, 255);
            btnAdd.Location = new Point(43, 498);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(156, 43);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "THÊM";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // numQty
            // 
            numQty.BackColor = Color.FromArgb(255, 255, 255);
            numQty.BorderStyle = BorderStyle.FixedSingle;
            numQty.ForeColor = Color.FromArgb(51, 51, 51);
            numQty.Location = new Point(244, 221);
            numQty.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(311, 30);
            numQty.TabIndex = 3;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQty
            // 
            lblQty.ForeColor = Color.FromArgb(51, 51, 51);
            lblQty.ImageAlign = ContentAlignment.MiddleLeft;
            lblQty.Location = new Point(39, 206);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(160, 45);
            lblQty.TabIndex = 4;
            lblQty.Text = "Số lượng:";
            lblQty.TextAlign = ContentAlignment.MiddleLeft;
            lblQty.Click += lblQty_Click;
            // 
            // lblSanPham
            // 
            lblSanPham.ForeColor = Color.FromArgb(51, 51, 51);
            lblSanPham.Location = new Point(39, 29);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Size = new Size(160, 43);
            lblSanPham.TabIndex = 6;
            lblSanPham.Text = "Sản phẩm:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(54, 54, 54);
            label7.Location = new Point(685, 9);
            label7.Name = "label7";
            label7.Size = new Size(174, 38);
            label7.TabIndex = 11;
            label7.Text = "BÁN HÀNG";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCart.BackgroundColor = SystemColors.ControlLight;
            dgvCart.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = Color.DodgerBlue;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvCart.DefaultCellStyle = dataGridViewCellStyle5;
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.GridColor = Color.LightGray;
            dgvCart.Location = new Point(656, 240);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.DodgerBlue;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvCart.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(863, 746);
            dgvCart.TabIndex = 12;
            dgvCart.CellClick += dgvCart_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(51, 51, 51);
            label3.Location = new Point(46, 146);
            label3.Name = "label3";
            label3.Size = new Size(121, 23);
            label3.TabIndex = 12;
            label3.Text = "Tên nhân viên:";
            // 
            // UC_POS
            // 
            BackColor = Color.FromArgb(240, 240, 240);
            Controls.Add(dgvCart);
            Controls.Add(label7);
            Controls.Add(grpAdd);
            Controls.Add(pnlTop);
            Name = "UC_POS";
            Size = new Size(1553, 1008);
            Load += UC_POS_Load;
            ((System.ComponentModel.ISupportInitialize)picSanPham).EndInit();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            grpAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlTop;
        private Label lblNv;
        private Label lblKh;
        private Label lblSDT;
        private TextBox txtTenNV;
        private TextBox txtMaNV;
        private TextBox txtMaKH;
        private TextBox txtTenKH;
        private TextBox txtSDT;
        private Button btnLoc;
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
        private Button btnDelete;
        private Label label1;
        private PictureBox picSanPham;
        private Label lblKhuyenMai;
        private Label lblKhuyenMaiValue;
        private Label label7;
        private Label label2;
        private DataGridView dgvCart;
        private Label label3;
    }
}
