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
            pnlToolbar = new Panel();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnKhoaMo = new Button();
            btnSua = new Button();
            btnThem = new Button();
            btnLamMoi = new Button();
            dgvNhanVien = new DataGridView();
            lblTitle = new Label();
            pnlContainer = new Panel();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = SystemColors.ButtonFace;
            pnlToolbar.Controls.Add(txtTimKiem);
            pnlToolbar.Controls.Add(btnTimKiem);
            pnlToolbar.Controls.Add(btnKhoaMo);
            pnlToolbar.Controls.Add(btnSua);
            pnlToolbar.Controls.Add(btnThem);
            pnlToolbar.Controls.Add(btnLamMoi);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 101);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(985, 166);
            pnlToolbar.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(172, 102);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(249, 30);
            txtTimKiem.TabIndex = 5;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.Highlight;
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(26, 95);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 37);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnKhoaMo
            // 
            btnKhoaMo.BackColor = Color.FromArgb(231, 76, 60);
            btnKhoaMo.FlatAppearance.BorderSize = 0;
            btnKhoaMo.FlatStyle = FlatStyle.Flat;
            btnKhoaMo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnKhoaMo.ForeColor = Color.White;
            btnKhoaMo.Location = new Point(579, 27);
            btnKhoaMo.Name = "btnKhoaMo";
            btnKhoaMo.Size = new Size(138, 39);
            btnKhoaMo.TabIndex = 3;
            btnKhoaMo.Text = "Khóa / Mở khóa";
            btnKhoaMo.UseVisualStyleBackColor = false;
            btnKhoaMo.Click += btnKhoaMo_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(224, 224, 224);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.FromArgb(51, 51, 51);
            btnSua.Location = new Point(389, 27);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 39);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.Highlight;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(209, 27);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 39);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.White;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.FromArgb(64, 78, 103);
            btnLamMoi.Location = new Point(26, 27);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(116, 39);
            btnLamMoi.TabIndex = 0;
            btnLamMoi.Text = "Làm mới (F5)";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(30, 30);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(925, 293);
            dgvNhanVien.TabIndex = 2;
            dgvNhanVien.CellFormatting += dgvNhanVien_CellFormatting;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(985, 101);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "DANH SÁCH NHÂN VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(dgvNhanVien);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 267);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(30);
            pnlContainer.Size = new Size(985, 353);
            pnlContainer.TabIndex = 7;
            // 
            // ucEmployeeManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContainer);
            Controls.Add(pnlToolbar);
            Controls.Add(lblTitle);
            Name = "ucEmployeeManagement";
            Size = new Size(985, 620);
            Load += ucEmployeeManagement_Load;
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            pnlContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlToolbar;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button btnKhoaMo;
        private Button btnSua;
        private Button btnThem;
        private Button btnLamMoi;
        private DataGridView dgvNhanVien;
        private Label lblTitle;
        private Panel pnlContainer;
    }
}
