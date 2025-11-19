namespace BagShopManagement.Views.Dev3
{
    partial class KhachHangControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            txtTimKhachHang = new TextBox();
            btnTim = new Button();
            btnThemMoi = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnXuatExcel = new Button();
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            btnReset = new Button();
            groupBox2 = new GroupBox();
            dgvKhachHang = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            SuspendLayout();
            // 
            // txtTimKhachHang
            // 
            txtTimKhachHang.Location = new Point(239, 134);
            txtTimKhachHang.Multiline = true;
            txtTimKhachHang.Name = "txtTimKhachHang";
            txtTimKhachHang.PlaceholderText = "Nhập mã khách hàng";
            txtTimKhachHang.Size = new Size(272, 35);
            txtTimKhachHang.TabIndex = 1;
            // 
            // btnTim
            // 
            btnTim.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTim.ForeColor = Color.FromArgb(51, 51, 51);
            btnTim.Location = new Point(137, 134);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(105, 35);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm kiếm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnThemMoi
            // 
            btnThemMoi.BackColor = SystemColors.Highlight;
            btnThemMoi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThemMoi.ForeColor = Color.FromArgb(51, 51, 51);
            btnThemMoi.Location = new Point(67, 241);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(197, 60);
            btnThemMoi.TabIndex = 3;
            btnThemMoi.Text = "Thêm Mới";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // btnSua
            // 
            btnSua.Enabled = false;
            btnSua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.FromArgb(51, 51, 51);
            btnSua.Location = new Point(67, 345);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(197, 60);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Enabled = false;
            btnXoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(67, 440);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(197, 61);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = SystemColors.ActiveCaption;
            btnXuatExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuatExcel.ForeColor = Color.Black;
            btnXuatExcel.Location = new Point(67, 532);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(197, 60);
            btnXuatExcel.TabIndex = 6;
            btnXuatExcel.Text = "Xuất excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(605, 36);
            label1.Name = "label1";
            label1.Size = new Size(327, 38);
            label1.TabIndex = 7;
            label1.Text = "QUẢN LÍ KHÁCH HÀNG";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnReset);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnXuatExcel);
            groupBox1.Controls.Add(btnThemMoi);
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(110, 196);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(383, 620);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thao tác";
            // 
            // btnReset
            // 
            btnReset.BackColor = SystemColors.InactiveCaption;
            btnReset.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnReset.ForeColor = Color.FromArgb(51, 51, 51);
            btnReset.Location = new Point(67, 144);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(197, 60);
            btnReset.TabIndex = 7;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvKhachHang);
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(532, 196);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(928, 620);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách khách hàng";
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvKhachHang.BackgroundColor = SystemColors.ControlLight;
            dgvKhachHang.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle7.SelectionForeColor = Color.DodgerBlue;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvKhachHang.DefaultCellStyle = dataGridViewCellStyle8;
            dgvKhachHang.EnableHeadersVisualStyles = false;
            dgvKhachHang.GridColor = Color.LightGray;
            dgvKhachHang.Location = new Point(16, 26);
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.DodgerBlue;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvKhachHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.Size = new Size(893, 576);
            dgvKhachHang.TabIndex = 9;
            dgvKhachHang.CellContentClick += dgvKhachHang_CellContentClick;
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            // 
            // KhachHangControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txtTimKhachHang);
            Controls.Add(label1);
            Controls.Add(btnTim);
            Name = "KhachHangControl";
            Size = new Size(1491, 932);
            Load += KhachHangControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTimKhachHang;
        private Button btnTim;
        private Button btnThemMoi;
        private Button btnSua;
        private Button btnXoa;
        private Button btnXuatExcel;
        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnReset;
        private DataGridView dgvKhachHang;
    }
}