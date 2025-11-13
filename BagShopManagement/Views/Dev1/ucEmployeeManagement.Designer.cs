namespace BagShopManagement.Views.Dev1
{
    partial class ucEmployeeManagement
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
            lblTitle = new Label();
            pnlToolbar = new Panel();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnKhoaMo = new Button();
            btnSua = new Button();
            btnThem = new Button();
            btnLamMoi = new Button();
            dgvNhanVien = new DataGridView();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(247, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlToolbar
            // 
            pnlToolbar.Controls.Add(txtTimKiem);
            pnlToolbar.Controls.Add(btnTimKiem);
            pnlToolbar.Controls.Add(btnKhoaMo);
            pnlToolbar.Controls.Add(btnSua);
            pnlToolbar.Controls.Add(btnThem);
            pnlToolbar.Controls.Add(btnLamMoi);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 31);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(985, 111);
            pnlToolbar.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(176, 79);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(249, 27);
            txtTimKiem.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(26, 79);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnKhoaMo
            // 
            btnKhoaMo.Location = new Point(579, 27);
            btnKhoaMo.Name = "btnKhoaMo";
            btnKhoaMo.Size = new Size(138, 29);
            btnKhoaMo.TabIndex = 3;
            btnKhoaMo.Text = "Khóa / Mở khóa";
            btnKhoaMo.UseVisualStyleBackColor = true;
            btnKhoaMo.Click += btnKhoaMo_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(389, 27);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(209, 27);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(26, 27);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 0;
            btnLamMoi.Text = "Làm mới (F5)";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(0, 142);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(985, 478);
            dgvNhanVien.TabIndex = 2;
            dgvNhanVien.CellFormatting += dgvNhanVien_CellFormatting;
            // 
            // ucEmployeeManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvNhanVien);
            Controls.Add(pnlToolbar);
            Controls.Add(lblTitle);
            Name = "ucEmployeeManagement";
            Size = new Size(985, 620);
            Load += ucEmployeeManagement_Load;
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pnlToolbar;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button btnKhoaMo;
        private Button btnSua;
        private Button btnThem;
        private Button btnLamMoi;
        private DataGridView dgvNhanVien;
    }
}
