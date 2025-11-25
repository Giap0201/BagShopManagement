namespace BagShopManagement.Views.Dev4.Dev4_HoaDonBan
{
    partial class HoaDonBanEditForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblHeader = new Label();
            pnlTop = new Panel();
            cboTrangThai = new ComboBox();
            lblTrangThai = new Label();
            txtPhuongThucTT = new TextBox();
            lblPhuongThucTT = new Label();
            txtGhiChu = new TextBox();
            lblGhiChu = new Label();
            txtMaNV = new TextBox();
            txtMaKH = new TextBox();
            lblNV = new Label();
            lblKH = new Label();
            pnlLeft = new Panel();
            grpAdd = new GroupBox();
            lblTotal = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            lblGiaSP = new Label();
            lblTenSP = new Label();
            lblMaSPValue = new Label();
            lblMaSPLabel = new Label();
            lblTenSPLabel = new Label();
            lblGiaSPLabel = new Label();
            btnChonSP = new Button();
            btnRemove = new Button();
            btnAdd = new Button();
            numQty = new NumericUpDown();
            lblQty = new Label();
            lblSanPham = new Label();
            pnlRight = new Panel();
            dgvCart = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlTop.SuspendLayout();
            pnlLeft.SuspendLayout();
            grpAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1475, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.FromArgb(54, 54, 54);
            lblHeader.Location = new Point(749, 21);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(425, 41);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "CHỈNH SỬA HOÁ ĐƠN BÁN";
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(255, 255, 255);
            pnlTop.Controls.Add(cboTrangThai);
            pnlTop.Controls.Add(lblTrangThai);
            pnlTop.Controls.Add(txtPhuongThucTT);
            pnlTop.Controls.Add(lblPhuongThucTT);
            pnlTop.Controls.Add(txtGhiChu);
            pnlTop.Controls.Add(lblGhiChu);
            pnlTop.Controls.Add(txtMaNV);
            pnlTop.Controls.Add(txtMaKH);
            pnlTop.Controls.Add(lblNV);
            pnlTop.Controls.Add(lblKH);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 80);
            pnlTop.Margin = new Padding(5, 6, 5, 6);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(20);
            pnlTop.Size = new Size(1475, 220);
            pnlTop.TabIndex = 1;
            // 
            // cboTrangThai
            // 
            cboTrangThai.BackColor = Color.LightGray;
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Font = new Font("Segoe UI", 10.2F);
            cboTrangThai.ForeColor = Color.FromArgb(51, 51, 51);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Nháp", "Đã thanh toán", "Đã hủy" });
            cboTrangThai.Location = new Point(1355, 145);
            cboTrangThai.Margin = new Padding(5, 6, 5, 6);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(337, 31);
            cboTrangThai.TabIndex = 9;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblTrangThai.ForeColor = Color.FromArgb(51, 51, 51);
            lblTrangThai.Location = new Point(1103, 150);
            lblTrangThai.Margin = new Padding(5, 0, 5, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(91, 23);
            lblTrangThai.TabIndex = 8;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // txtPhuongThucTT
            // 
            txtPhuongThucTT.BackColor = Color.White;
            txtPhuongThucTT.BorderStyle = BorderStyle.FixedSingle;
            txtPhuongThucTT.Font = new Font("Segoe UI", 10.2F);
            txtPhuongThucTT.ForeColor = Color.FromArgb(51, 51, 51);
            txtPhuongThucTT.Location = new Point(357, 148);
            txtPhuongThucTT.Margin = new Padding(5, 6, 5, 6);
            txtPhuongThucTT.Name = "txtPhuongThucTT";
            txtPhuongThucTT.ReadOnly = true;
            txtPhuongThucTT.Size = new Size(337, 30);
            txtPhuongThucTT.TabIndex = 7;
            // 
            // lblPhuongThucTT
            // 
            lblPhuongThucTT.AutoSize = true;
            lblPhuongThucTT.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblPhuongThucTT.ForeColor = Color.FromArgb(51, 51, 51);
            lblPhuongThucTT.Location = new Point(34, 150);
            lblPhuongThucTT.Margin = new Padding(5, 0, 5, 0);
            lblPhuongThucTT.Name = "lblPhuongThucTT";
            lblPhuongThucTT.Size = new Size(205, 23);
            lblPhuongThucTT.TabIndex = 6;
            lblPhuongThucTT.Text = "Phương thức thanh toán:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.BackColor = Color.White;
            txtGhiChu.BorderStyle = BorderStyle.FixedSingle;
            txtGhiChu.Font = new Font("Segoe UI", 10.2F);
            txtGhiChu.ForeColor = Color.FromArgb(51, 51, 51);
            txtGhiChu.Location = new Point(357, 85);
            txtGhiChu.Margin = new Padding(5, 6, 5, 6);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(337, 30);
            txtGhiChu.TabIndex = 5;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblGhiChu.ForeColor = Color.FromArgb(51, 51, 51);
            lblGhiChu.Location = new Point(34, 90);
            lblGhiChu.Margin = new Padding(5, 0, 5, 0);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(73, 23);
            lblGhiChu.TabIndex = 4;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtMaNV
            // 
            txtMaNV.BackColor = Color.White;
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.Font = new Font("Segoe UI", 10.2F);
            txtMaNV.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaNV.Location = new Point(1355, 25);
            txtMaNV.Margin = new Padding(5, 6, 5, 6);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(337, 30);
            txtMaNV.TabIndex = 3;
            // 
            // txtMaKH
            // 
            txtMaKH.BackColor = Color.White;
            txtMaKH.BorderStyle = BorderStyle.FixedSingle;
            txtMaKH.Font = new Font("Segoe UI", 10.2F);
            txtMaKH.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaKH.Location = new Point(357, 25);
            txtMaKH.Margin = new Padding(5, 6, 5, 6);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(337, 30);
            txtMaKH.TabIndex = 1;
            // 
            // lblNV
            // 
            lblNV.AutoSize = true;
            lblNV.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblNV.ForeColor = Color.FromArgb(51, 51, 51);
            lblNV.Location = new Point(1103, 30);
            lblNV.Margin = new Padding(5, 0, 5, 0);
            lblNV.Name = "lblNV";
            lblNV.Size = new Size(120, 23);
            lblNV.TabIndex = 2;
            lblNV.Text = "Mã nhân viên:";
            // 
            // lblKH
            // 
            lblKH.AutoSize = true;
            lblKH.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblKH.ForeColor = Color.FromArgb(51, 51, 51);
            lblKH.Location = new Point(34, 30);
            lblKH.Margin = new Padding(5, 0, 5, 0);
            lblKH.Name = "lblKH";
            lblKH.Size = new Size(134, 23);
            lblKH.TabIndex = 0;
            lblKH.Text = "Mã khách hàng:";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(240, 240, 240);
            pnlLeft.Controls.Add(grpAdd);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 300);
            pnlLeft.Margin = new Padding(5, 6, 5, 6);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(20);
            pnlLeft.Size = new Size(600, 215);
            pnlLeft.TabIndex = 2;
            // 
            // grpAdd
            // 
            grpAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpAdd.BackColor = Color.FromArgb(255, 255, 255);
            grpAdd.Controls.Add(lblTotal);
            grpAdd.Controls.Add(btnSave);
            grpAdd.Controls.Add(btnCancel);
            grpAdd.Controls.Add(lblGiaSP);
            grpAdd.Controls.Add(lblTenSP);
            grpAdd.Controls.Add(lblMaSPValue);
            grpAdd.Controls.Add(lblMaSPLabel);
            grpAdd.Controls.Add(lblTenSPLabel);
            grpAdd.Controls.Add(lblGiaSPLabel);
            grpAdd.Controls.Add(btnChonSP);
            grpAdd.Controls.Add(btnRemove);
            grpAdd.Controls.Add(btnAdd);
            grpAdd.Controls.Add(numQty);
            grpAdd.Controls.Add(lblQty);
            grpAdd.Controls.Add(lblSanPham);
            grpAdd.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            grpAdd.ForeColor = Color.FromArgb(51, 51, 51);
            grpAdd.Location = new Point(20, 20);
            grpAdd.Margin = new Padding(5, 6, 5, 6);
            grpAdd.Name = "grpAdd";
            grpAdd.Padding = new Padding(15);
            grpAdd.Size = new Size(560, 158);
            grpAdd.TabIndex = 0;
            grpAdd.TabStop = false;
            grpAdd.Text = "THÊM SẢN PHẨM";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(231, 76, 60);
            lblTotal.Location = new Point(25, 380);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(124, 32);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Tổng: 0 ₫";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(25, 78);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(250, 60);
            btnSave.TabIndex = 16;
            btnSave.Text = "LƯU";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(51, 51, 51);
            btnCancel.Location = new Point(290, 78);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(240, 60);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "HUỶ";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblGiaSP
            // 
            lblGiaSP.BackColor = SystemColors.Control;
            lblGiaSP.BorderStyle = BorderStyle.Fixed3D;
            lblGiaSP.Font = new Font("Segoe UI", 10.2F);
            lblGiaSP.ForeColor = Color.Green;
            lblGiaSP.Location = new Point(180, 160);
            lblGiaSP.Name = "lblGiaSP";
            lblGiaSP.Size = new Size(350, 30);
            lblGiaSP.TabIndex = 7;
            lblGiaSP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenSP
            // 
            lblTenSP.BackColor = SystemColors.Control;
            lblTenSP.BorderStyle = BorderStyle.Fixed3D;
            lblTenSP.Font = new Font("Segoe UI", 10.2F);
            lblTenSP.Location = new Point(180, 120);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(350, 30);
            lblTenSP.TabIndex = 5;
            lblTenSP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaSPValue
            // 
            lblMaSPValue.BackColor = SystemColors.Control;
            lblMaSPValue.BorderStyle = BorderStyle.Fixed3D;
            lblMaSPValue.Font = new Font("Segoe UI", 10.2F);
            lblMaSPValue.Location = new Point(180, 80);
            lblMaSPValue.Name = "lblMaSPValue";
            lblMaSPValue.Size = new Size(350, 30);
            lblMaSPValue.TabIndex = 3;
            lblMaSPValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMaSPLabel
            // 
            lblMaSPLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblMaSPLabel.Location = new Point(25, 80);
            lblMaSPLabel.Name = "lblMaSPLabel";
            lblMaSPLabel.Size = new Size(140, 30);
            lblMaSPLabel.TabIndex = 2;
            lblMaSPLabel.Text = "Mã sản phẩm:";
            lblMaSPLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenSPLabel
            // 
            lblTenSPLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblTenSPLabel.Location = new Point(25, 120);
            lblTenSPLabel.Name = "lblTenSPLabel";
            lblTenSPLabel.Size = new Size(140, 30);
            lblTenSPLabel.TabIndex = 4;
            lblTenSPLabel.Text = "Tên sản phẩm:";
            lblTenSPLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGiaSPLabel
            // 
            lblGiaSPLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lblGiaSPLabel.Location = new Point(25, 160);
            lblGiaSPLabel.Name = "lblGiaSPLabel";
            lblGiaSPLabel.Size = new Size(140, 30);
            lblGiaSPLabel.TabIndex = 6;
            lblGiaSPLabel.Text = "Giá sản phẩm:";
            lblGiaSPLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnChonSP
            // 
            btnChonSP.BackColor = Color.FromArgb(37, 99, 235);
            btnChonSP.Cursor = Cursors.Hand;
            btnChonSP.FlatAppearance.BorderSize = 0;
            btnChonSP.FlatStyle = FlatStyle.Flat;
            btnChonSP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChonSP.ForeColor = Color.White;
            btnChonSP.Location = new Point(180, 30);
            btnChonSP.Name = "btnChonSP";
            btnChonSP.Size = new Size(350, 40);
            btnChonSP.TabIndex = 1;
            btnChonSP.Text = "Chọn sản phẩm";
            btnChonSP.UseVisualStyleBackColor = false;
            btnChonSP.Click += btnChonSP_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(231, 76, 60);
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(308, 275);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(156, 50);
            btnRemove.TabIndex = 11;
            btnRemove.Text = "XOÁ";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(37, 99, 235);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(80, 275);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(156, 50);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "THÊM";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // numQty
            // 
            numQty.BackColor = Color.White;
            numQty.BorderStyle = BorderStyle.FixedSingle;
            numQty.Font = new Font("Segoe UI", 10.2F);
            numQty.ForeColor = Color.FromArgb(51, 51, 51);
            numQty.Location = new Point(180, 205);
            numQty.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(350, 30);
            numQty.TabIndex = 9;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQty
            // 
            lblQty.ForeColor = Color.FromArgb(51, 51, 51);
            lblQty.ImageAlign = ContentAlignment.MiddleLeft;
            lblQty.Location = new Point(25, 205);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(140, 30);
            lblQty.TabIndex = 8;
            lblQty.Text = "Số lượng:";
            lblQty.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSanPham
            // 
            lblSanPham.ForeColor = Color.FromArgb(51, 51, 51);
            lblSanPham.Location = new Point(25, 35);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Size = new Size(140, 30);
            lblSanPham.TabIndex = 0;
            lblSanPham.Text = "Sản phẩm:";
            lblSanPham.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(240, 240, 240);
            pnlRight.Controls.Add(dgvCart);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(600, 300);
            pnlRight.Margin = new Padding(5, 6, 5, 6);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(20);
            pnlRight.Size = new Size(875, 215);
            pnlRight.TabIndex = 3;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCart.BackgroundColor = SystemColors.ControlLight;
            dgvCart.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.DodgerBlue;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCart.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.GridColor = Color.LightGray;
            dgvCart.Location = new Point(20, 20);
            dgvCart.Margin = new Padding(5, 6, 5, 6);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCart.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(835, 175);
            dgvCart.TabIndex = 0;
            dgvCart.CellEndEdit += dgvCart_CellEndEdit;
            // 
            // HoaDonBanEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1475, 515);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlTop);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(912, 521);
            Name = "HoaDonBanEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chỉnh sửa hoá đơn bán";
            WindowState = FormWindowState.Maximized;
            Load += HoaDonBanEditForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlLeft.ResumeLayout(false);
            grpAdd.ResumeLayout(false);
            grpAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeader;
        private Panel pnlTop;
        private Label lblKH;
        private TextBox txtMaKH;
        private Label lblNV;
        private TextBox txtMaNV;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Label lblPhuongThucTT;
        private TextBox txtPhuongThucTT;
        private ComboBox cboTrangThai;
        private Label lblTrangThai;
        private Panel pnlLeft;
        private GroupBox grpAdd;
        private Label lblSanPham;
        private Button btnChonSP;
        private Label lblMaSPLabel;
        private Label lblMaSPValue;
        private Label lblTenSPLabel;
        private Label lblTenSP;
        private Label lblGiaSPLabel;
        private Label lblGiaSP;
        private Label lblQty;
        private NumericUpDown numQty;
        private Button btnAdd;
        private Button btnRemove;
        private Label lblTotal;
        private Button btnSave;
        private Button btnCancel;
        private Panel pnlRight;
        private DataGridView dgvCart;
    }
}

