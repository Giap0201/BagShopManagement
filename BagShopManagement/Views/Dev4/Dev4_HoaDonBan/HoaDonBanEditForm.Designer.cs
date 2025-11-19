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
            grpActions = new GroupBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblTotal = new Label();
            btnApplyDiscount = new Button();
            numDiscountPercent = new NumericUpDown();
            lblDiscount = new Label();
            grpAdd = new GroupBox();
            btnRemove = new Button();
            btnAdd = new Button();
            numQty = new NumericUpDown();
            lblQty = new Label();
            txtMaSP = new TextBox();
            lblMaSP = new Label();
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
            pnlTop.BackColor = Color.FromArgb(255, 255, 255);
            pnlTop.Controls.Add(cboTrangThai);
            pnlTop.Controls.Add(lblTrangThai);
            pnlTop.Controls.Add(txtPhuongThucTT);
            pnlTop.Controls.Add(lblPhuongThucTT);
            pnlTop.Controls.Add(txtGhiChu);
            pnlTop.Controls.Add(lblGhiChu);
            pnlTop.Controls.Add(txtMaNV);
            pnlTop.Controls.Add(txtMaKH);
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(5, 6, 5, 6);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(2339, 308);
            pnlTop.TabIndex = 0;
            // 
            // cboTrangThai
            // 
            cboTrangThai.BackColor = Color.FromArgb(255, 255, 255);
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FlatStyle = FlatStyle.Flat;
            cboTrangThai.ForeColor = Color.FromArgb(51, 51, 51);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] {
            "Nháp",
            "Đã thanh toán",
            "Đã hủy"});
            cboTrangThai.Location = new Point(1355, 199);
            cboTrangThai.Margin = new Padding(5, 6, 5, 6);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(337, 49);
            cboTrangThai.TabIndex = 9;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.ForeColor = Color.FromArgb(51, 51, 51);
            lblTrangThai.Location = new Point(1103, 205);
            lblTrangThai.Margin = new Padding(5, 0, 5, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(158, 41);
            lblTrangThai.TabIndex = 8;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // txtPhuongThucTT
            // 
            txtPhuongThucTT.BackColor = Color.FromArgb(255, 255, 255);
            txtPhuongThucTT.BorderStyle = BorderStyle.FixedSingle;
            txtPhuongThucTT.ForeColor = Color.FromArgb(51, 51, 51);
            txtPhuongThucTT.Location = new Point(444, 199);
            txtPhuongThucTT.Margin = new Padding(5, 6, 5, 6);
            txtPhuongThucTT.Name = "txtPhuongThucTT";
            txtPhuongThucTT.ReadOnly = true;
            txtPhuongThucTT.Size = new Size(337, 47);
            txtPhuongThucTT.TabIndex = 7;
            // 
            // lblPhuongThucTT
            // 
            lblPhuongThucTT.AutoSize = true;
            lblPhuongThucTT.ForeColor = Color.FromArgb(51, 51, 51);
            lblPhuongThucTT.Location = new Point(34, 205);
            lblPhuongThucTT.Margin = new Padding(5, 0, 5, 0);
            lblPhuongThucTT.Name = "lblPhuongThucTT";
            lblPhuongThucTT.Size = new Size(349, 41);
            lblPhuongThucTT.TabIndex = 6;
            lblPhuongThucTT.Text = "Phương thức thanh toán:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.BackColor = Color.FromArgb(255, 255, 255);
            txtGhiChu.BorderStyle = BorderStyle.FixedSingle;
            txtGhiChu.ForeColor = Color.FromArgb(51, 51, 51);
            txtGhiChu.Location = new Point(170, 117);
            txtGhiChu.Margin = new Padding(5, 6, 5, 6);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(677, 47);
            txtGhiChu.TabIndex = 5;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.ForeColor = Color.FromArgb(51, 51, 51);
            lblGhiChu.Location = new Point(34, 123);
            lblGhiChu.Margin = new Padding(5, 0, 5, 0);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(126, 41);
            lblGhiChu.TabIndex = 4;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtMaNV
            // 
            txtMaNV.BackColor = Color.FromArgb(255, 255, 255);
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaNV.Location = new Point(1355, 35);
            txtMaNV.Margin = new Padding(5, 6, 5, 6);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(337, 47);
            txtMaNV.TabIndex = 3;
            // 
            // txtMaKH
            // 
            txtMaKH.BackColor = Color.FromArgb(255, 255, 255);
            txtMaKH.BorderStyle = BorderStyle.FixedSingle;
            txtMaKH.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaKH.Location = new Point(357, 41);
            txtMaKH.Margin = new Padding(5, 6, 5, 6);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(337, 47);
            txtMaKH.TabIndex = 1;
            // 
            // lblNV
            // 
            lblNV.AutoSize = true;
            lblNV.ForeColor = Color.FromArgb(51, 51, 51);
            lblNV.Location = new Point(1103, 35);
            lblNV.Margin = new Padding(5, 0, 5, 0);
            lblNV.Name = "lblNV";
            lblNV.Size = new Size(203, 41);
            lblNV.TabIndex = 2;
            lblNV.Text = "Mã nhân viên:";
            // 
            // lblKH
            // 
            lblKH.AutoSize = true;
            lblKH.ForeColor = Color.FromArgb(51, 51, 51);
            lblKH.Location = new Point(34, 41);
            lblKH.Margin = new Padding(5, 0, 5, 0);
            lblKH.Name = "lblKH";
            lblKH.Size = new Size(228, 41);
            lblKH.TabIndex = 0;
            lblKH.Text = "Mã khách hàng:";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(255, 255, 255);
            pnlLeft.Controls.Add(grpActions);
            pnlLeft.Controls.Add(grpAdd);
            pnlLeft.Location = new Point(0, 308);
            pnlLeft.Margin = new Padding(5, 6, 5, 6);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(680, 1079);
            pnlLeft.TabIndex = 1;
            // 
            // grpActions
            // 
            grpActions.BackColor = Color.FromArgb(255, 255, 255);
            grpActions.Controls.Add(btnSave);
            grpActions.Controls.Add(btnCancel);
            grpActions.Controls.Add(lblTotal);
            grpActions.Controls.Add(btnApplyDiscount);
            grpActions.Controls.Add(numDiscountPercent);
            grpActions.Controls.Add(lblDiscount);
            grpActions.ForeColor = Color.FromArgb(51, 51, 51);
            grpActions.Location = new Point(34, 492);
            grpActions.Margin = new Padding(5, 6, 5, 6);
            grpActions.Name = "grpActions";
            grpActions.Padding = new Padding(5, 6, 5, 6);
            grpActions.Size = new Size(612, 615);
            grpActions.TabIndex = 1;
            grpActions.TabStop = false;
            grpActions.Text = "Thao tác";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 120, 215);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.FromArgb(255, 255, 255);
            btnSave.Location = new Point(85, 410);
            btnSave.Margin = new Padding(5, 6, 5, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(204, 82);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(224, 224, 224);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.FromArgb(51, 51, 51);
            btnCancel.Location = new Point(323, 410);
            btnCancel.Margin = new Padding(5, 6, 5, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(204, 82);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Red;
            lblTotal.Location = new Point(34, 287);
            lblTotal.Margin = new Padding(5, 0, 5, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(197, 46);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Tổng: 0 ₫";
            // 
            // btnApplyDiscount
            // 
            btnApplyDiscount.Location = new Point(170, 164);
            btnApplyDiscount.Margin = new Padding(5, 6, 5, 6);
            btnApplyDiscount.Name = "btnApplyDiscount";
            btnApplyDiscount.Size = new Size(272, 72);
            btnApplyDiscount.TabIndex = 2;
            btnApplyDiscount.Text = "Áp dụng giảm giá";
            btnApplyDiscount.UseVisualStyleBackColor = true;
            btnApplyDiscount.Click += btnApplyDiscount_Click;
            // 
            // numDiscountPercent
            // 
            numDiscountPercent.DecimalPlaces = 2;
            numDiscountPercent.Location = new Point(272, 76);
            numDiscountPercent.Margin = new Padding(5, 6, 5, 6);
            numDiscountPercent.Name = "numDiscountPercent";
            numDiscountPercent.Size = new Size(204, 47);
            numDiscountPercent.TabIndex = 1;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(34, 82);
            lblDiscount.Margin = new Padding(5, 0, 5, 0);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(193, 41);
            lblDiscount.TabIndex = 0;
            lblDiscount.Text = "Giảm giá (%):";
            // 
            // grpAdd
            // 
            grpAdd.BackColor = Color.FromArgb(255, 255, 255);
            grpAdd.Controls.Add(btnRemove);
            grpAdd.Controls.Add(btnAdd);
            grpAdd.Controls.Add(numQty);
            grpAdd.Controls.Add(lblQty);
            grpAdd.Controls.Add(txtMaSP);
            grpAdd.Controls.Add(lblMaSP);
            grpAdd.ForeColor = Color.FromArgb(51, 51, 51);
            grpAdd.Location = new Point(34, 41);
            grpAdd.Margin = new Padding(5, 6, 5, 6);
            grpAdd.Name = "grpAdd";
            grpAdd.Padding = new Padding(5, 6, 5, 6);
            grpAdd.Size = new Size(612, 410);
            grpAdd.TabIndex = 0;
            grpAdd.TabStop = false;
            grpAdd.Text = "Thêm sản phẩm";
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(231, 76, 60);
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.ForeColor = Color.FromArgb(255, 255, 255);
            btnRemove.Location = new Point(374, 246);
            btnRemove.Margin = new Padding(5, 6, 5, 6);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(170, 72);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Xóa";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 120, 215);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.FromArgb(255, 255, 255);
            btnAdd.Location = new Point(170, 246);
            btnAdd.Margin = new Padding(5, 6, 5, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(170, 72);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // numQty
            // 
            numQty.BackColor = Color.FromArgb(255, 255, 255);
            numQty.BorderStyle = BorderStyle.FixedSingle;
            numQty.ForeColor = Color.FromArgb(51, 51, 51);
            numQty.Location = new Point(170, 158);
            numQty.Margin = new Padding(5, 6, 5, 6);
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(170, 47);
            numQty.TabIndex = 3;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.ForeColor = Color.FromArgb(51, 51, 51);
            lblQty.Location = new Point(34, 164);
            lblQty.Margin = new Padding(5, 0, 5, 0);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(145, 41);
            lblQty.TabIndex = 2;
            lblQty.Text = "Số lượng:";
            // 
            // txtMaSP
            // 
            txtMaSP.BackColor = Color.FromArgb(255, 255, 255);
            txtMaSP.BorderStyle = BorderStyle.FixedSingle;
            txtMaSP.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaSP.Location = new Point(170, 76);
            txtMaSP.Margin = new Padding(5, 6, 5, 6);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(337, 47);
            txtMaSP.TabIndex = 1;
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.ForeColor = Color.FromArgb(51, 51, 51);
            lblMaSP.Location = new Point(34, 82);
            lblMaSP.Margin = new Padding(5, 0, 5, 0);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(108, 41);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã SP:";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(255, 255, 255);
            pnlRight.Controls.Add(dgvCart);
            pnlRight.Location = new Point(600, 150);
            pnlRight.Margin = new Padding(5, 6, 5, 6);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(1659, 1079);
            pnlRight.TabIndex = 2;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.GridColor = Color.FromArgb(204, 204, 204);
            dgvCart.Location = new Point(0, 0);
            dgvCart.Margin = new Padding(5, 6, 5, 6);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 102;
            dgvCart.Size = new Size(1659, 1079);
            dgvCart.TabIndex = 0;
            dgvCart.CellEndEdit += dgvCart_CellEndEdit;
            // 
            // HoaDonBanEditForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(2339, 1387);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlTop);
            Margin = new Padding(5, 6, 5, 6);
            Name = "HoaDonBanEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa hóa đơn";
            Load += HoaDonBanEditForm_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlLeft.ResumeLayout(false);
            grpActions.ResumeLayout(false);
            grpActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscountPercent).EndInit();
            grpAdd.ResumeLayout(false);
            grpAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

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
        private Label lblMaSP;
        private TextBox txtMaSP;
        private Label lblQty;
        private NumericUpDown numQty;
        private Button btnAdd;
        private Button btnRemove;
        private GroupBox grpActions;
        private Label lblDiscount;
        private NumericUpDown numDiscountPercent;
        private Button btnApplyDiscount;
        private Label lblTotal;
        private Button btnSave;
        private Button btnCancel;
        private Panel pnlRight;
        private DataGridView dgvCart;
    }
}

