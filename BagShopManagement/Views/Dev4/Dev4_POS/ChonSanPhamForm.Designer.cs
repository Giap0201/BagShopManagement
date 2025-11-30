namespace BagShopManagement.Views.Dev4
{
    partial class ChonSanPhamForm
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
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            dgvSanPham = new DataGridView();
            pnlBottom = new Panel();
            btnCancel = new Button();
            btnSelect = new Button();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(255, 255, 255);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(lblSearch);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(1, 1, 1, 1);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(675, 49);
            pnlTop.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(248, 248, 248);
            btnSearch.FlatAppearance.BorderColor = Color.FromArgb(187, 187, 187);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.FromArgb(51, 51, 51);
            btnSearch.Location = new Point(581, 12);
            btnSearch.Margin = new Padding(1, 1, 1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(71, 24);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(255, 255, 255);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.ForeColor = Color.FromArgb(51, 51, 51);
            txtSearch.Location = new Point(118, 12);
            txtSearch.Margin = new Padding(1, 1, 1, 1);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã hoặc tên sản phẩm...";
            txtSearch.Size = new Size(441, 27);
            txtSearch.TabIndex = 1;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.ForeColor = Color.FromArgb(51, 51, 51);
            lblSearch.Location = new Point(14, 15);
            lblSearch.Margin = new Padding(1, 0, 1, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(93, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm SP:";
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvSanPham.ColumnHeadersHeight = 50;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.GridColor = Color.FromArgb(204, 204, 204);
            dgvSanPham.Location = new Point(0, 49);
            dgvSanPham.Margin = new Padding(1, 1, 1, 1);
            dgvSanPham.MultiSelect = false;
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(675, 246);
            dgvSanPham.TabIndex = 1;
            dgvSanPham.CellDoubleClick += dgvSanPham_CellDoubleClick;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(255, 255, 255);
            pnlBottom.Controls.Add(btnCancel);
            pnlBottom.Controls.Add(btnSelect);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 295);
            pnlBottom.Margin = new Padding(1, 1, 1, 1);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(675, 49);
            pnlBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(224, 224, 224);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.FromArgb(51, 51, 51);
            btnCancel.Location = new Point(353, 12);
            btnCancel.Margin = new Padding(1, 1, 1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.FromArgb(0, 120, 215);
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.ForeColor = Color.FromArgb(255, 255, 255);
            btnSelect.Location = new Point(212, 12);
            btnSelect.Margin = new Padding(1, 1, 1, 1);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(94, 29);
            btnSelect.TabIndex = 0;
            btnSelect.Text = "✓ Chọn";
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Click += btnSelect_Click;
            // 
            // ChonSanPhamForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(675, 344);
            Controls.Add(dgvSanPham);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Margin = new Padding(1, 1, 1, 1);
            Name = "ChonSanPhamForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chọn sản phẩm";
            Load += ChonSanPhamForm_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvSanPham;
        private Panel pnlBottom;
        private Button btnSelect;
        private Button btnCancel;
    }
}
