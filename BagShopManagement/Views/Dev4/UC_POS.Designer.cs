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
            btnDelete = new Button();
            btnClear = new Button();
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
            pnlTop.Controls.Add(txtMaNV);
            pnlTop.Controls.Add(txtMaKH);
            pnlTop.Controls.Add(lblNv);
            pnlTop.Controls.Add(lblKh);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1578, 100);
            pnlTop.TabIndex = 2;
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(1040, 30);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(250, 27);
            txtMaNV.TabIndex = 0;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(200, 30);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(250, 27);
            txtMaKH.TabIndex = 1;
            // 
            // lblNv
            // 
            lblNv.AutoSize = true;
            lblNv.Location = new Point(870, 30);
            lblNv.Name = "lblNv";
            lblNv.Size = new Size(54, 20);
            lblNv.TabIndex = 2;
            lblNv.Text = "Mã NV";
            // 
            // lblKh
            // 
            lblKh.AutoSize = true;
            lblKh.Location = new Point(30, 30);
            lblKh.Name = "lblKh";
            lblKh.Size = new Size(54, 20);
            lblKh.TabIndex = 3;
            lblKh.Text = "Mã KH";
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(grpActions);
            pnlLeft.Controls.Add(grpAdd);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 100);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(540, 879);
            pnlLeft.TabIndex = 1;
            // 
            // grpActions
            // 
            grpActions.Controls.Add(btnPrint);
            grpActions.Controls.Add(btnCheckout);
            grpActions.Controls.Add(btnSaveDraft);
            grpActions.Controls.Add(lblTotal);
            grpActions.Controls.Add(btnApplyDiscount);
            grpActions.Controls.Add(numDiscountPercent);
            grpActions.Controls.Add(lblDiscount);
            grpActions.Location = new Point(10, 450);
            grpActions.Name = "grpActions";
            grpActions.Size = new Size(406, 400);
            grpActions.TabIndex = 0;
            grpActions.TabStop = false;
            grpActions.Text = "Thanh toán và khuyến mãi";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(190, 150);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(150, 50);
            btnPrint.TabIndex = 0;
            btnPrint.Text = "In hóa đơn";
            btnPrint.Click += btnPrint_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(170, 250);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(150, 50);
            btnCheckout.TabIndex = 1;
            btnCheckout.Text = "Thanh toán";
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnSaveDraft
            // 
            btnSaveDraft.Location = new Point(20, 250);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(130, 50);
            btnSaveDraft.TabIndex = 2;
            btnSaveDraft.Text = "Lưu tạm";
            btnSaveDraft.Click += btnSaveDraft_Click;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(20, 150);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 23);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Tổng: 0 ₫";
            // 
            // btnApplyDiscount
            // 
            btnApplyDiscount.Location = new Point(126, 104);
            btnApplyDiscount.Name = "btnApplyDiscount";
            btnApplyDiscount.Size = new Size(140, 40);
            btnApplyDiscount.TabIndex = 4;
            btnApplyDiscount.Text = "Áp dụng";
            btnApplyDiscount.Click += btnApplyDiscount_Click;
            // 
            // numDiscountPercent
            // 
            numDiscountPercent.Location = new Point(180, 65);
            numDiscountPercent.Name = "numDiscountPercent";
            numDiscountPercent.Size = new Size(130, 27);
            numDiscountPercent.TabIndex = 5;
            // 
            // lblDiscount
            // 
            lblDiscount.Location = new Point(20, 70);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(100, 23);
            lblDiscount.TabIndex = 6;
            lblDiscount.Text = "Giảm (%):";
            // 
            // grpAdd
            // 
            grpAdd.Controls.Add(btnDelete);
            grpAdd.Controls.Add(btnClear);
            grpAdd.Controls.Add(btnAdd);
            grpAdd.Controls.Add(numQty);
            grpAdd.Controls.Add(lblQty);
            grpAdd.Controls.Add(txtMaSP);
            grpAdd.Controls.Add(lblMaSP);
            grpAdd.Location = new Point(10, 10);
            grpAdd.Name = "grpAdd";
            grpAdd.Size = new Size(406, 400);
            grpAdd.TabIndex = 1;
            grpAdd.TabStop = false;
            grpAdd.Text = "Thêm sản phẩm";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(210, 219);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 50);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Xóa";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(73, 275);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 50);
            btnClear.TabIndex = 1;
            btnClear.Text = "Xóa giỏ";
            btnClear.Click += btnClear_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(35, 219);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 50);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm vào giỏ";
            btnAdd.Click += btnAdd_Click;
            // 
            // numQty
            // 
            numQty.Location = new Point(126, 138);
            numQty.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(250, 27);
            numQty.TabIndex = 3;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQty
            // 
            lblQty.Location = new Point(20, 140);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(100, 23);
            lblQty.TabIndex = 4;
            lblQty.Text = "Số lượng:";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(126, 56);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(250, 27);
            txtMaSP.TabIndex = 5;
            // 
            // lblMaSP
            // 
            lblMaSP.Location = new Point(20, 60);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(100, 23);
            lblMaSP.TabIndex = 6;
            lblMaSP.Text = "Mã SP:";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(dgvCart);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(540, 100);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(1038, 879);
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
            dgvCart.Size = new Size(1038, 879);
            dgvCart.TabIndex = 0;
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
        private Button btnDelete;
    }
}
