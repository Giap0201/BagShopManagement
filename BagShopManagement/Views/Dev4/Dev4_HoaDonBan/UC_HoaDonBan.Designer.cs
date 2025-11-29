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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            pnlBottom = new Panel();
            btnPrint = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            btnEdit = new Button();
            btnViewDetails = new Button();
            lblTotal = new Label();
            dgvHoaDon = new DataGridView();
            label7 = new Label();
            pnlFilter.SuspendLayout();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();
            //
            // pnlFilter
            //
            pnlFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilter.BackColor = Color.FromArgb(255, 255, 255);
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
            pnlFilter.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlFilter.Location = new Point(38, 84);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1492, 207);
            pnlFilter.TabIndex = 0;
            //
            // btnRefresh
            //
            btnRefresh.BackColor = Color.LightGray;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(187, 187, 187);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.FromArgb(51, 51, 51);
            btnRefresh.Location = new Point(1262, 137);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(181, 51);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "LÀM MỚI";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            //
            // btnFilter
            //
            btnFilter.BackColor = Color.FromArgb(37, 99, 235);
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(1011, 137);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(168, 51);
            btnFilter.TabIndex = 11;
            btnFilter.Text = "LỌC";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            //
            // cmbTrangThai
            //
            cmbTrangThai.BackColor = Color.LightGray;
            cmbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrangThai.Font = new Font("Segoe UI", 10.2F);
            cmbTrangThai.ForeColor = Color.FromArgb(51, 51, 51);
            cmbTrangThai.Location = new Point(1243, 72);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new Size(200, 31);
            cmbTrangThai.TabIndex = 10;
            //
            // lblTrangThai
            //
            lblTrangThai.AutoSize = true;
            lblTrangThai.ForeColor = Color.FromArgb(51, 51, 51);
            lblTrangThai.Location = new Point(1088, 75);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(91, 23);
            lblTrangThai.TabIndex = 9;
            lblTrangThai.Text = "Trạng thái:";
            //
            // txtMaNV
            //
            txtMaNV.BackColor = Color.White;
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.Font = new Font("Segoe UI", 10.2F);
            txtMaNV.ForeColor = Color.FromArgb(51, 51, 51);
            txtMaNV.Location = new Point(707, 68);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(200, 30);
            txtMaNV.TabIndex = 8;
            //
            // lblMaNV
            //
            lblMaNV.AutoSize = true;
            lblMaNV.ForeColor = Color.FromArgb(51, 51, 51);
            lblMaNV.Location = new Point(538, 75);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(120, 23);
            lblMaNV.TabIndex = 7;
            lblMaNV.Text = "Mã nhân viên:";
            //
            // lblToDate
            //
            lblToDate.AutoSize = true;
            lblToDate.ForeColor = Color.FromArgb(51, 51, 51);
            lblToDate.Location = new Point(56, 143);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(88, 23);
            lblToDate.TabIndex = 6;
            lblToDate.Text = "Đến ngày:";
            lblToDate.Click += lblToDate_Click;
            //
            // lblFromDate
            //
            lblFromDate.AutoSize = true;
            lblFromDate.ForeColor = Color.FromArgb(51, 51, 51);
            lblFromDate.Location = new Point(56, 75);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(77, 23);
            lblFromDate.TabIndex = 5;
            lblFromDate.Text = "Từ ngày:";
            //
            // dtpToDate
            //
            dtpToDate.Font = new Font("Segoe UI", 10.2F);
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(186, 137);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(200, 30);
            dtpToDate.TabIndex = 4;
            //
            // dtpFromDate
            //
            dtpFromDate.Font = new Font("Segoe UI", 10.2F);
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(186, 72);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(200, 30);
            dtpFromDate.TabIndex = 3;
            //
            // chkFilterTrangThai
            //
            chkFilterTrangThai.AutoSize = true;
            chkFilterTrangThai.ForeColor = Color.FromArgb(51, 51, 51);
            chkFilterTrangThai.Location = new Point(1088, 14);
            chkFilterTrangThai.Name = "chkFilterTrangThai";
            chkFilterTrangThai.Size = new Size(178, 27);
            chkFilterTrangThai.TabIndex = 2;
            chkFilterTrangThai.Text = "Lọc theo trạng thái";
            //
            // chkFilterNV
            //
            chkFilterNV.AutoSize = true;
            chkFilterNV.ForeColor = Color.FromArgb(51, 51, 51);
            chkFilterNV.Location = new Point(538, 14);
            chkFilterNV.Name = "chkFilterNV";
            chkFilterNV.Size = new Size(179, 27);
            chkFilterNV.TabIndex = 1;
            chkFilterNV.Text = "Lọc theo nhân viên";
            //
            // chkFilterDate
            //
            chkFilterDate.AutoSize = true;
            chkFilterDate.ForeColor = Color.FromArgb(51, 51, 51);
            chkFilterDate.Location = new Point(56, 14);
            chkFilterDate.Name = "chkFilterDate";
            chkFilterDate.Size = new Size(141, 27);
            chkFilterDate.TabIndex = 0;
            chkFilterDate.Text = "Lọc theo ngày";
            //
            // pnlBottom
            //
            pnlBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBottom.BackColor = Color.White;
            pnlBottom.Controls.Add(btnPrint);
            pnlBottom.Controls.Add(btnDelete);
            pnlBottom.Controls.Add(btnCancel);
            pnlBottom.Controls.Add(btnEdit);
            pnlBottom.Controls.Add(btnViewDetails);
            pnlBottom.Location = new Point(38, 810);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1492, 119);
            pnlBottom.TabIndex = 2;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(34, 139, 34);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnPrint.ForeColor = Color.FromArgb(255, 255, 255);
            btnPrint.Location = new Point(55, 40);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(180, 50);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "IN HÓA ĐƠN";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(255, 255, 255);
            btnDelete.Location = new Point(1284, 40);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(159, 50);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "XOÁ";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(255, 255, 255);
            btnCancel.Location = new Point(705, 40);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(189, 50);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "HUỶ HOÁ ĐƠN";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.LightGray;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEdit.ForeColor = Color.FromArgb(51, 51, 51);
            btnEdit.Location = new Point(1062, 40);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(153, 50);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "SỬA";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnViewDetails
            // 
            btnViewDetails.BackColor = Color.Gainsboro;
            btnViewDetails.Cursor = Cursors.Hand;
            btnViewDetails.FlatAppearance.BorderColor = Color.FromArgb(187, 187, 187);
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnViewDetails.ForeColor = Color.FromArgb(51, 51, 51);
            btnViewDetails.Location = new Point(280, 40);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(180, 50);
            btnViewDetails.TabIndex = 1;
            btnViewDetails.Text = "CHI TIẾT";
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += btnViewDetails_Click;
            //
            // lblTotal
            //
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(54, 54, 54);
            lblTotal.Location = new Point(38, 763);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(67, 23);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Tổng: 0";
            //
            // dgvHoaDon
            //
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvHoaDon.BackgroundColor = SystemColors.ControlLight;
            dgvHoaDon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.DodgerBlue;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvHoaDon.DefaultCellStyle = dataGridViewCellStyle2;
            dgvHoaDon.EnableHeadersVisualStyles = false;
            dgvHoaDon.GridColor = Color.LightGray;
            dgvHoaDon.Location = new Point(38, 311);
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvHoaDon.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(1492, 427);
            dgvHoaDon.TabIndex = 9;
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(54, 54, 54);
            label7.Location = new Point(592, 14);
            label7.Name = "label7";
            label7.Size = new Size(353, 38);
            label7.TabIndex = 10;
            label7.Text = "QUẢN LÍ HOÁ ĐƠN BÁN";
            //
            // UC_HoaDonBan
            //
            BackColor = SystemColors.Control;
            Controls.Add(label7);
            Controls.Add(dgvHoaDon);
            Controls.Add(pnlBottom);
            Controls.Add(pnlFilter);
            Controls.Add(lblTotal);
            Name = "UC_HoaDonBan";
            Size = new Size(1578, 952);
            Load += UC_HoaDonBan_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion Component Designer generated code

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
        private Panel pnlBottom;
        private Label lblTotal;
        private Button btnViewDetails;
        private Button btnEdit;
        private Button btnCancel;
        private Button btnDelete;
        private Button btnPrint;
        private DataGridView dgvHoaDon;
        private Label label7;
    }
}