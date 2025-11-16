namespace BagShopManagement.Views.Dev4.Dev4_HoaDonBan
{
    partial class UC_HoaDonBan
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
            pnlFilter = new Panel();
            btnRefresh = new Button();
            btnFilter = new Button();
            cmbTrangThai = new ComboBox();
            lblTrangThai = new Label();
            txtMaNV = new TextBox();
            lblMaNV = new Label();
            lblToDate = new Label();
            lblFromDate = new Label();
            dtpToDate = new DateTimePicker();
            dtpFromDate = new DateTimePicker();
            chkFilterTrangThai = new CheckBox();
            chkFilterNV = new CheckBox();
            chkFilterDate = new CheckBox();
            pnlMain = new Panel();
            dgvHoaDon = new DataGridView();
            pnlBottom = new Panel();
            btnDelete = new Button();
            btnCancel = new Button();
            btnEdit = new Button();
            btnViewDetails = new Button();
            lblTotal = new Label();
            pnlFilter.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.White;
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Controls.Add(btnFilter);
            pnlFilter.Controls.Add(cmbTrangThai);
            pnlFilter.Controls.Add(lblTrangThai);
            pnlFilter.Controls.Add(txtMaNV);
            pnlFilter.Controls.Add(lblMaNV);
            pnlFilter.Controls.Add(lblToDate);
            pnlFilter.Controls.Add(lblFromDate);
            pnlFilter.Controls.Add(dtpToDate);
            pnlFilter.Controls.Add(dtpFromDate);
            pnlFilter.Controls.Add(chkFilterTrangThai);
            pnlFilter.Controls.Add(chkFilterNV);
            pnlFilter.Controls.Add(chkFilterDate);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(20);
            pnlFilter.Size = new Size(2090, 207);
            pnlFilter.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD93D");
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnRefresh.Location = new Point(1812, 117);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(181, 78);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "↻ Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD93D");
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilter.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnFilter.Location = new Point(1812, 14);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(181, 76);
            btnFilter.TabIndex = 11;
            btnFilter.Text = "🔍 Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.Click += btnFilter_Click;
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrangThai.Location = new Point(1467, 75);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new Size(200, 49);
            cmbTrangThai.TabIndex = 10;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(1273, 83);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(155, 41);
            lblTrangThai.TabIndex = 9;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(908, 75);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(200, 47);
            txtMaNV.TabIndex = 8;
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Location = new Point(686, 81);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(203, 41);
            lblMaNV.TabIndex = 7;
            lblMaNV.Text = "Mã nhân viên:";
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(25, 136);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(152, 41);
            lblToDate.TabIndex = 6;
            lblToDate.Text = "Đến ngày:";
            lblToDate.Click += lblToDate_Click;
            // 
            // lblFromDate
            // 
            lblFromDate.AutoSize = true;
            lblFromDate.Location = new Point(25, 65);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(132, 41);
            lblFromDate.TabIndex = 5;
            lblFromDate.Text = "Từ ngày:";
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(196, 136);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(200, 47);
            dtpToDate.TabIndex = 4;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(196, 65);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(200, 47);
            dtpFromDate.TabIndex = 3;
            // 
            // chkFilterTrangThai
            // 
            chkFilterTrangThai.AutoSize = true;
            chkFilterTrangThai.Location = new Point(1295, 25);
            chkFilterTrangThai.Name = "chkFilterTrangThai";
            chkFilterTrangThai.Size = new Size(306, 45);
            chkFilterTrangThai.TabIndex = 2;
            chkFilterTrangThai.Text = "Lọc theo trạng thái";
            // 
            // chkFilterNV
            // 
            chkFilterNV.AutoSize = true;
            chkFilterNV.Location = new Point(686, 14);
            chkFilterNV.Name = "chkFilterNV";
            chkFilterNV.Size = new Size(307, 45);
            chkFilterNV.TabIndex = 1;
            chkFilterNV.Text = "Lọc theo nhân viên";
            // 
            // chkFilterDate
            // 
            chkFilterDate.AutoSize = true;
            chkFilterDate.Location = new Point(38, 14);
            chkFilterDate.Name = "chkFilterDate";
            chkFilterDate.Size = new Size(244, 45);
            chkFilterDate.TabIndex = 0;
            chkFilterDate.Text = "Lọc theo ngày";
            // 
            // pnlMain
            // 
            pnlMain.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            pnlMain.Controls.Add(dgvHoaDon);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 207);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.Size = new Size(2090, 1012);
            pnlMain.TabIndex = 1;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(0, 0);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(2090, 1012);
            dgvHoaDon.TabIndex = 0;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.White;
            pnlBottom.Controls.Add(btnDelete);
            pnlBottom.Controls.Add(btnCancel);
            pnlBottom.Controls.Add(btnEdit);
            pnlBottom.Controls.Add(btnViewDetails);
            pnlBottom.Controls.Add(lblTotal);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 1219);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(10);
            pnlBottom.Size = new Size(2090, 79);
            pnlBottom.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF5757");
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(1993, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(200, 79);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "🗑️ Xóa hóa đơn";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF5757");
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(1762, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(231, 79);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "❌ Hủy hóa đơn";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#6C63FF");
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(1599, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(157, 76);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏️ Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnViewDetails
            // 
            btnViewDetails.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6B9D");
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewDetails.ForeColor = Color.White;
            btnViewDetails.Location = new Point(1372, 0);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(221, 76);
            btnViewDetails.TabIndex = 1;
            btnViewDetails.Text = "👁️ Xem chi tiết";
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Cursor = Cursors.Hand;
            btnViewDetails.Click += btnViewDetails_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6B9D");
            lblTotal.Location = new Point(3, 8);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(118, 41);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "📄 Tổng: 0";
            // 
            // UC_HoaDonBan
            // 
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlFilter);
            Name = "UC_HoaDonBan";
            Size = new Size(2090, 1298);
            Load += UC_HoaDonBan_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilter;
        private CheckBox chkFilterDate;
        private CheckBox chkFilterNV;
        private CheckBox chkFilterTrangThai;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private Label lblFromDate;
        private Label lblToDate;
        private Label lblMaNV;
        private TextBox txtMaNV;
        private Label lblTrangThai;
        private ComboBox cmbTrangThai;
        private Button btnFilter;
        private Button btnRefresh;
        private Panel pnlMain;
        private DataGridView dgvHoaDon;
        private Panel pnlBottom;
        private Label lblTotal;
        private Button btnViewDetails;
        private Button btnEdit;
        private Button btnCancel;
        private Button btnDelete;
    }
}
