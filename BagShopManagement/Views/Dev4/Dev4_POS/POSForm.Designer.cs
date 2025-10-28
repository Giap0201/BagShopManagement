namespace BagShopManagement.Views.Dev4.Dev4_POS
{
    partial class POSForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.
        /// </param>
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
            lblNv = new Label();
            lblKh = new Label();

            pnlLeft = new Panel();
            grpActions = new GroupBox();
            btnPrint = new Button();
            btnCheckout = new Button();
            btnSaveDraft = new Button();
            lblTotal = new Label();
            btnApplyDiscount = new Button();
            numDiscountPercent = new NumericUpDown();
            lblDiscount = new Label();

            grpAdd = new GroupBox();
            btn = new Button();
            btnClear = new Button();
            btnAdd = new Button();
            numQty = new NumericUpDown();
            lblQty = new Label();
            txtMaSP = new TextBox();
            lblMaSP = new Label();

            pnlRight = new Panel();
            dgvCart = new DataGridView();
            MaSP = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            GiamGia = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();

            pnlTop.SuspendLayout();
            pnlLeft.SuspendLayout();
            grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiscountPercent).BeginInit();
            grpAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();

            // ================== pnlTop ==================
            pnlTop.Controls.Add(txtMaNV);
            pnlTop.Controls.Add(txtMaKH);
            pnlTop.Controls.Add(lblNv);
            pnlTop.Controls.Add(lblKh);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1578, 101);
            pnlTop.TabIndex = 1;

            // txtMaNV
            txtMaNV.Location = new Point(1041, 17);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(250, 47);
            txtMaNV.TabIndex = 3;

            // txtMaKH
            txtMaKH.Location = new Point(206, 17);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(250, 47);
            txtMaKH.TabIndex = 2;

            // lblNv
            lblNv.AutoSize = true;
            lblNv.Location = new Point(870, 17);
            lblNv.Name = "lblNv";
            lblNv.Size = new Size(109, 41);
            lblNv.TabIndex = 1;
            lblNv.Text = "Mã NV";
            lblNv.Click += lblNv_Click;

            // lblKh
            lblKh.AutoSize = true;
            lblKh.Location = new Point(35, 17);
            lblKh.Name = "lblKh";
            lblKh.Size = new Size(106, 41);
            lblKh.TabIndex = 0;
            lblKh.Text = "Mã KH";

            // ================== pnlLeft ==================
            pnlLeft.Controls.Add(grpActions);
            pnlLeft.Controls.Add(grpAdd);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 101);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(540, 878);
            pnlLeft.TabIndex = 2;

            // ================== grpActions ==================
            grpActions.Controls.Add(btnPrint);
            grpActions.Controls.Add(btnCheckout);
            grpActions.Controls.Add(btnSaveDraft);
            grpActions.Controls.Add(lblTotal);
            grpActions.Controls.Add(btnApplyDiscount);
            grpActions.Controls.Add(numDiscountPercent);
            grpActions.Controls.Add(lblDiscount);
            grpActions.Location = new Point(3, 462);
            grpActions.Name = "grpActions";
            grpActions.Size = new Size(535, 404);
            grpActions.TabIndex = 1;
            grpActions.TabStop = false;
            grpActions.Text = "Thanh toán và Khuyến mãi";

            // btnPrint
            btnPrint.Location = new Point(337, 262);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(107, 58);
            btnPrint.TabIndex = 13;
            btnPrint.Text = "In hóa đơn";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;

            // btnCheckout
            btnCheckout.Location = new Point(181, 262);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(132, 58);
            btnCheckout.TabIndex = 12;
            btnCheckout.Text = "Thanh Toán";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;

            // btnSaveDraft
            btnSaveDraft.Location = new Point(21, 262);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(132, 58);
            btnSaveDraft.TabIndex = 10;
            btnSaveDraft.Text = "Lưu tạm";
            btnSaveDraft.UseVisualStyleBackColor = true;
            btnSaveDraft.Click += btnSaveDraft_Click;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(21, 168);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(151, 41);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "Tổng: 0 ₫";
            lblTotal.Click += lblTotal_Click;

            // btnApplyDiscount
            btnApplyDiscount.Location = new Point(337, 57);
            btnApplyDiscount.Name = "btnApplyDiscount";
            btnApplyDiscount.Size = new Size(156, 58);
            btnApplyDiscount.TabIndex = 7;
            btnApplyDiscount.Text = "Áp dụng";
            btnApplyDiscount.UseVisualStyleBackColor = true;
            btnApplyDiscount.Click += btnApplyDiscount_Click;

            // numDiscountPercent
            numDiscountPercent.Location = new Point(181, 64);
            numDiscountPercent.Name = "numDiscountPercent";
            numDiscountPercent.Size = new Size(132, 47);
            numDiscountPercent.TabIndex = 6;

            // lblDiscount
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(21, 64);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(153, 41);
            lblDiscount.TabIndex = 5;
            lblDiscount.Text = "Giảm (%): ";
            lblDiscount.Click += label1_Click_1;

            // ================== grpAdd ==================
            grpAdd.Controls.Add(btn);
            grpAdd.Controls.Add(btnClear);
            grpAdd.Controls.Add(btnAdd);
            grpAdd.Controls.Add(numQty);
            grpAdd.Controls.Add(lblQty);
            grpAdd.Controls.Add(txtMaSP);
            grpAdd.Controls.Add(lblMaSP);
            grpAdd.Location = new Point(0, 6);
            grpAdd.Name = "grpAdd";
            grpAdd.Size = new Size(535, 415);
            grpAdd.TabIndex = 0;
            grpAdd.TabStop = false;
            grpAdd.Text = "Thêm sản phẩm";

            // btn
            btn.Location = new Point(319, 246);
            btn.Name = "btn";
            btn.Size = new Size(137, 58);
            btn.TabIndex = 8;
            btn.Text = "Xóa";
            btn.UseVisualStyleBackColor = true;
            btn.Click += button1_Click;

            // btnClear
            btnClear.Location = new Point(194, 328);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(158, 58);
            btnClear.TabIndex = 7;
            btnClear.Text = "Xóa giỏ";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            // btnAdd
            btnAdd.Location = new Point(96, 246);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(142, 58);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm vào giỏ";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // numQty
            numQty.Location = new Point(194, 146);
            numQty.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(250, 47);
            numQty.TabIndex = 5;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // lblQty
            lblQty.AutoSize = true;
            lblQty.Location = new Point(21, 146);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(145, 41);
            lblQty.TabIndex = 4;
            lblQty.Text = "Số lượng:";

            // txtMaSP
            txtMaSP.Location = new Point(194, 62);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(250, 47);
            txtMaSP.TabIndex = 3;

            // lblMaSP
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new Point(21, 65);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(101, 41);
            lblMaSP.TabIndex = 1;
            lblMaSP.Text = "Mã SP";

            // ================== pnlRight ==================
            pnlRight.Controls.Add(dgvCart);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(540, 101);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(1038, 878);
            pnlRight.TabIndex = 3;

            // dgvCart
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AutoGenerateColumns = false; // ❌ Tắt tự sinh cột
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.ReadOnly = true;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Xóa tất cả cột cũ nếu có
            dgvCart.Columns.Clear();

            // ✅ Thêm cột thủ công bạn muốn hiển thị
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã SP",
                DataPropertyName = "MaSP",
                Width = 120
            });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSP", // ⚠️ Nếu ChiTietHoaDonBan không có, bạn cần map trong RefreshCartGrid()
                Width = 220
            });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                Width = 100
            });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giảm/SP",
                DataPropertyName = "GiamGiaSP",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // ================== POSForm ==================
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 979);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlTop);
            Name = "POSForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "POSForm - Bán hàng";
            Load += POSForm_Load;

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
        private Label lblNv;
        private Label lblKh;
        private TextBox txtMaNV;
        private TextBox txtMaKH;
        private Panel pnlLeft;
        private GroupBox grpAdd;
        private NumericUpDown numQty;
        private Label lblQty;
        private TextBox txtMaSP;
        private Label lblMaSP;
        private GroupBox grpActions;
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
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn GiamGia;
        private DataGridViewTextBoxColumn ThanhTien;
        private Button btn;
    }
}
