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
            txtMaNV = new TextBox();
            txtMaKH = new TextBox();
            lblNV = new Label();
            lblKH = new Label();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            lblPhuongThucTT = new Label();
            txtPhuongThucTT = new TextBox();

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

            // pnlTop
            pnlTop.Controls.Add(txtPhuongThucTT);
            pnlTop.Controls.Add(lblPhuongThucTT);
            pnlTop.Controls.Add(txtGhiChu);
            pnlTop.Controls.Add(lblGhiChu);
            pnlTop.Controls.Add(txtMaNV);
            pnlTop.Controls.Add(txtMaKH);
            pnlTop.Controls.Add(lblNV);
            pnlTop.Controls.Add(lblKH);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(1400, 150);
            pnlTop.TabIndex = 0;

            // lblKH
            lblKH.AutoSize = true;
            lblKH.Location = new System.Drawing.Point(20, 20);
            lblKH.Name = "lblKH";
            lblKH.Size = new System.Drawing.Size(110, 20);
            lblKH.TabIndex = 0;
            lblKH.Text = "Mã khách hàng:";

            // txtMaKH
            txtMaKH.Location = new System.Drawing.Point(140, 17);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new System.Drawing.Size(200, 27);
            txtMaKH.TabIndex = 1;

            // lblNV
            lblNV.AutoSize = true;
            lblNV.Location = new System.Drawing.Point(380, 20);
            lblNV.Name = "lblNV";
            lblNV.Size = new System.Drawing.Size(110, 20);
            lblNV.TabIndex = 2;
            lblNV.Text = "Mã nhân viên:";

            // txtMaNV
            txtMaNV.Location = new System.Drawing.Point(500, 17);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new System.Drawing.Size(200, 27);
            txtMaNV.TabIndex = 3;

            // lblGhiChu
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new System.Drawing.Point(20, 60);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new System.Drawing.Size(70, 20);
            lblGhiChu.TabIndex = 4;
            lblGhiChu.Text = "Ghi chú:";

            // txtGhiChu
            txtGhiChu.Location = new System.Drawing.Point(100, 57);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new System.Drawing.Size(400, 27);
            txtGhiChu.TabIndex = 5;

            // lblPhuongThucTT
            lblPhuongThucTT.AutoSize = true;
            lblPhuongThucTT.Location = new System.Drawing.Point(20, 100);
            lblPhuongThucTT.Name = "lblPhuongThucTT";
            lblPhuongThucTT.Size = new System.Drawing.Size(155, 20);
            lblPhuongThucTT.TabIndex = 6;
            lblPhuongThucTT.Text = "Phương thức thanh toán:";

            // txtPhuongThucTT
            txtPhuongThucTT.Location = new System.Drawing.Point(180, 97);
            txtPhuongThucTT.Name = "txtPhuongThucTT";
            txtPhuongThucTT.Size = new System.Drawing.Size(200, 27);
            txtPhuongThucTT.TabIndex = 7;

            // pnlLeft
            pnlLeft.Controls.Add(grpActions);
            pnlLeft.Controls.Add(grpAdd);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new System.Drawing.Point(0, 150);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new System.Drawing.Size(400, 600);
            pnlLeft.TabIndex = 1;

            // grpAdd
            grpAdd.Controls.Add(btnRemove);
            grpAdd.Controls.Add(btnAdd);
            grpAdd.Controls.Add(numQty);
            grpAdd.Controls.Add(lblQty);
            grpAdd.Controls.Add(txtMaSP);
            grpAdd.Controls.Add(lblMaSP);
            grpAdd.Location = new System.Drawing.Point(20, 20);
            grpAdd.Name = "grpAdd";
            grpAdd.Size = new System.Drawing.Size(360, 200);
            grpAdd.TabIndex = 0;
            grpAdd.TabStop = false;
            grpAdd.Text = "Thêm sản phẩm";

            // lblMaSP
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new System.Drawing.Point(20, 40);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new System.Drawing.Size(60, 20);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã SP:";

            // txtMaSP
            txtMaSP.Location = new System.Drawing.Point(100, 37);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new System.Drawing.Size(200, 27);
            txtMaSP.TabIndex = 1;

            // lblQty
            lblQty.AutoSize = true;
            lblQty.Location = new System.Drawing.Point(20, 80);
            lblQty.Name = "lblQty";
            lblQty.Size = new System.Drawing.Size(75, 20);
            lblQty.TabIndex = 2;
            lblQty.Text = "Số lượng:";

            // numQty
            numQty.Location = new System.Drawing.Point(100, 77);
            numQty.Minimum = 1;
            numQty.Name = "numQty";
            numQty.Size = new System.Drawing.Size(100, 27);
            numQty.TabIndex = 3;
            numQty.Value = 1;

            // btnAdd
            btnAdd.Location = new System.Drawing.Point(100, 120);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(100, 35);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // btnRemove
            btnRemove.Location = new System.Drawing.Point(220, 120);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(100, 35);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Xóa";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;

            // grpActions
            grpActions.Controls.Add(btnSave);
            grpActions.Controls.Add(btnCancel);
            grpActions.Controls.Add(lblTotal);
            grpActions.Controls.Add(btnApplyDiscount);
            grpActions.Controls.Add(numDiscountPercent);
            grpActions.Controls.Add(lblDiscount);
            grpActions.Location = new System.Drawing.Point(20, 240);
            grpActions.Name = "grpActions";
            grpActions.Size = new System.Drawing.Size(360, 300);
            grpActions.TabIndex = 1;
            grpActions.TabStop = false;
            grpActions.Text = "Thao tác";

            // lblDiscount
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new System.Drawing.Point(20, 40);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new System.Drawing.Size(130, 20);
            lblDiscount.TabIndex = 0;
            lblDiscount.Text = "Giảm giá (%):";

            // numDiscountPercent
            numDiscountPercent.DecimalPlaces = 2;
            numDiscountPercent.Location = new System.Drawing.Point(160, 37);
            numDiscountPercent.Maximum = 100;
            numDiscountPercent.Name = "numDiscountPercent";
            numDiscountPercent.Size = new System.Drawing.Size(120, 27);
            numDiscountPercent.TabIndex = 1;

            // btnApplyDiscount
            btnApplyDiscount.Location = new System.Drawing.Point(100, 80);
            btnApplyDiscount.Name = "btnApplyDiscount";
            btnApplyDiscount.Size = new System.Drawing.Size(160, 35);
            btnApplyDiscount.TabIndex = 2;
            btnApplyDiscount.Text = "Áp dụng giảm giá";
            btnApplyDiscount.UseVisualStyleBackColor = true;
            btnApplyDiscount.Click += btnApplyDiscount_Click;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            lblTotal.ForeColor = System.Drawing.Color.Red;
            lblTotal.Location = new System.Drawing.Point(20, 140);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new System.Drawing.Size(100, 25);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Tổng: 0 ₫";

            // btnSave
            btnSave.Location = new System.Drawing.Point(50, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(120, 40);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // btnCancel
            btnCancel.Location = new System.Drawing.Point(190, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(120, 40);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // pnlRight
            pnlRight.Controls.Add(dgvCart);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new System.Drawing.Point(400, 150);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new System.Drawing.Size(1000, 600);
            pnlRight.TabIndex = 2;

            // dgvCart
            dgvCart.AllowUserToAddRows = false;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Name = "dgvCart";
            dgvCart.CellEndEdit += dgvCart_CellEndEdit;

            // HoaDonBanEditForm
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1400, 750);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlTop);
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

