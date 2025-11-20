namespace BagShopManagement.Views.Dev3
{
    partial class NhaCungCapControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnTim = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            txtTimKiem = new TextBox();
            groupBox1 = new GroupBox();
            btnXuatExcel = new Button();
            btnReset = new Button();
            groupBox2 = new GroupBox();
            dgvNCC = new DataGridView();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNCC).BeginInit();
            SuspendLayout();
            // 
            // btnTim
            // 
            btnTim.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTim.ForeColor = Color.FromArgb(51, 51, 51);
            btnTim.Location = new Point(67, 165);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(125, 36);
            btnTim.TabIndex = 1;
            btnTim.Text = "Tìm kiếm ";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ActiveCaption;
            btnThem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThem.ForeColor = Color.FromArgb(51, 51, 51);
            btnThem.Location = new Point(107, 32);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(175, 64);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThemMoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(224, 224, 224);
            btnSua.Enabled = false;
            btnSua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.FromArgb(51, 51, 51);
            btnSua.Location = new Point(107, 317);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(175, 64);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa ";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Enabled = false;
            btnXoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(107, 222);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(175, 64);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BackColor = Color.White;
            txtTimKiem.ForeColor = Color.Black;
            txtTimKiem.Location = new Point(188, 165);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã nhà cung cấp ...";
            txtTimKiem.Size = new Size(338, 36);
            txtTimKiem.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXuatExcel);
            groupBox1.Controls.Add(btnReset);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(67, 227);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(482, 494);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "thao tác";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.FromArgb(128, 128, 255);
            btnXuatExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(107, 412);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(175, 64);
            btnXuatExcel.TabIndex = 7;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = SystemColors.InactiveCaption;
            btnReset.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnReset.ForeColor = Color.FromArgb(51, 51, 51);
            btnReset.Location = new Point(107, 127);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(175, 64);
            btnReset.TabIndex = 6;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvNCC);
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(555, 227);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(925, 494);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách nhà cung cấp";
            // 
            // dgvNCC
            // 
            dgvNCC.AllowUserToAddRows = false;
            dgvNCC.AllowUserToDeleteRows = false;
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNCC.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvNCC.BackgroundColor = SystemColors.ControlLight;
            dgvNCC.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.DodgerBlue;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNCC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvNCC.DefaultCellStyle = dataGridViewCellStyle2;
            dgvNCC.EnableHeadersVisualStyles = false;
            dgvNCC.GridColor = Color.LightGray;
            dgvNCC.Location = new Point(6, 26);
            dgvNCC.MultiSelect = false;
            dgvNCC.Name = "dgvNCC";
            dgvNCC.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvNCC.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvNCC.RowHeadersVisible = false;
            dgvNCC.RowHeadersWidth = 51;
            dgvNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNCC.Size = new Size(905, 462);
            dgvNCC.TabIndex = 9;
            dgvNCC.SelectionChanged += dgvNCC_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(527, 27);
            label1.Name = "label1";
            label1.Size = new Size(403, 38);
            label1.TabIndex = 8;
            label1.Text = "DANH SÁCH NHÀ CUNG CẤP";
            // 
            // NhaCungCapControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(txtTimKiem);
            Controls.Add(groupBox1);
            Controls.Add(btnTim);
            Name = "NhaCungCapControl";
            Size = new Size(1509, 846);
            Load += NhaCungCapControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNCC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnTim;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private TextBox txtTimKiem;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnReset;
        private Label label1;
        private DataGridView dgvNCC;
        private Button btnXuatExcel;
    }
}
