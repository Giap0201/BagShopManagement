namespace BagShopManagement.Views.Dev4.Dev4_HoaDonBan
{
    partial class HoaDonBanForm
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
            pnlFilter = new Panel();
            chkFilterDate = new CheckBox();
            chkFilterNV = new CheckBox();
            chkFilterTrangThai = new CheckBox();
            dtpFromDate = new DateTimePicker();
            dtpToDate = new DateTimePicker();
            lblFromDate = new Label();
            lblToDate = new Label();
            lblMaNV = new Label();
            txtMaNV = new TextBox();
            lblTrangThai = new Label();
            cmbTrangThai = new ComboBox();
            btnFilter = new Button();
            btnRefresh = new Button();
            pnlMain = new Panel();
            dgvHoaDon = new DataGridView();
            pnlBottom = new Panel();
            lblTotal = new Label();
            btnViewDetails = new Button();
            btnEdit = new Button();
            btnCancel = new Button();

            pnlFilter.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();

            // pnlFilter
            pnlFilter.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
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
            pnlFilter.Location = new System.Drawing.Point(0, 0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new System.Drawing.Size(1400, 150);
            pnlFilter.TabIndex = 0;

            // chkFilterDate
            chkFilterDate.AutoSize = true;
            chkFilterDate.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            chkFilterDate.Location = new System.Drawing.Point(20, 20);
            chkFilterDate.Name = "chkFilterDate";
            chkFilterDate.Size = new System.Drawing.Size(108, 24);
            chkFilterDate.TabIndex = 0;
            chkFilterDate.Text = "Lọc theo ngày";

            // chkFilterNV
            chkFilterNV.AutoSize = true;
            chkFilterNV.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            chkFilterNV.Location = new System.Drawing.Point(500, 20);
            chkFilterNV.Name = "chkFilterNV";
            chkFilterNV.Size = new System.Drawing.Size(138, 24);
            chkFilterNV.TabIndex = 1;
            chkFilterNV.Text = "Lọc theo nhân viên";

            // chkFilterTrangThai
            chkFilterTrangThai.AutoSize = true;
            chkFilterTrangThai.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            chkFilterTrangThai.Location = new System.Drawing.Point(800, 20);
            chkFilterTrangThai.Name = "chkFilterTrangThai";
            chkFilterTrangThai.Size = new System.Drawing.Size(144, 24);
            chkFilterTrangThai.TabIndex = 2;
            chkFilterTrangThai.Text = "Lọc theo trạng thái";

            // dtpFromDate
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new System.Drawing.Point(120, 50);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new System.Drawing.Size(200, 27);
            dtpFromDate.TabIndex = 3;

            // dtpToDate
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new System.Drawing.Point(120, 90);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new System.Drawing.Size(200, 27);
            dtpToDate.TabIndex = 4;

            // lblFromDate
            lblFromDate.AutoSize = true;
            lblFromDate.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            lblFromDate.Location = new System.Drawing.Point(20, 55);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new System.Drawing.Size(77, 20);
            lblFromDate.TabIndex = 5;
            lblFromDate.Text = "Từ ngày:";

            // lblToDate
            lblToDate.AutoSize = true;
            lblToDate.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            lblToDate.Location = new System.Drawing.Point(20, 95);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new System.Drawing.Size(67, 20);
            lblToDate.TabIndex = 6;
            lblToDate.Text = "Đến ngày:";

            // lblMaNV
            lblMaNV.AutoSize = true;
            lblMaNV.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            lblMaNV.Location = new System.Drawing.Point(500, 55);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new System.Drawing.Size(98, 20);
            lblMaNV.TabIndex = 7;
            lblMaNV.Text = "Mã nhân viên:";

            // txtMaNV
            txtMaNV.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtMaNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMaNV.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            txtMaNV.Location = new System.Drawing.Point(620, 50);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new System.Drawing.Size(200, 27);
            txtMaNV.TabIndex = 8;

            // lblTrangThai
            lblTrangThai.AutoSize = true;
            lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            lblTrangThai.Location = new System.Drawing.Point(800, 55);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(79, 20);
            lblTrangThai.TabIndex = 9;
            lblTrangThai.Text = "Trạng thái:";

            // cmbTrangThai
            cmbTrangThai.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            cmbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrangThai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbTrangThai.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            cmbTrangThai.Location = new System.Drawing.Point(920, 50);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new System.Drawing.Size(200, 28);
            cmbTrangThai.TabIndex = 10;

            // btnFilter
            btnFilter.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFilter.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            btnFilter.Location = new System.Drawing.Point(1200, 45);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new System.Drawing.Size(120, 40);
            btnFilter.TabIndex = 11;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;

            // btnRefresh
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
            btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(187, 187, 187);
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            btnRefresh.Location = new System.Drawing.Point(1200, 95);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(120, 40);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            // pnlMain
            pnlMain.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            pnlMain.Controls.Add(dgvHoaDon);
            pnlMain.Location = new System.Drawing.Point(0, 150);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new System.Drawing.Size(1400, 600);
            pnlMain.TabIndex = 1;

            // dgvHoaDon
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.GridColor = System.Drawing.Color.FromArgb(204, 204, 204);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // pnlBottom
            pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            pnlBottom.Controls.Add(btnCancel);
            pnlBottom.Controls.Add(btnEdit);
            pnlBottom.Controls.Add(btnViewDetails);
            pnlBottom.Controls.Add(lblTotal);
            pnlBottom.Location = new System.Drawing.Point(0, 750);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new System.Drawing.Size(1400, 60);
            pnlBottom.TabIndex = 2;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.ForeColor = System.Drawing.Color.FromArgb(68, 68, 68);
            lblTotal.Location = new System.Drawing.Point(20, 20);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new System.Drawing.Size(58, 20);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Tổng: 0";

            // btnViewDetails
            btnViewDetails.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
            btnViewDetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(187, 187, 187);
            btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnViewDetails.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            btnViewDetails.Location = new System.Drawing.Point(1000, 15);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new System.Drawing.Size(120, 35);
            btnViewDetails.TabIndex = 1;
            btnViewDetails.Text = "Xem chi tiết";
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += btnViewDetails_Click;

            // btnEdit
            btnEdit.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            btnEdit.Location = new System.Drawing.Point(1130, 15);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(120, 35);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;

            // btnCancel
            btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            btnCancel.Location = new System.Drawing.Point(1260, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(120, 35);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hủy hóa đơn";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;

            // HoaDonBanForm
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            ClientSize = new System.Drawing.Size(1400, 810);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlFilter);
            Name = "HoaDonBanForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý hóa đơn bán";
            Load += HoaDonBanForm_Load;

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
    }
}

