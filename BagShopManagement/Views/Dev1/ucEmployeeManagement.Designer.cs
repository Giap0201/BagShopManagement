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
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(255, 107, 157);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(10);
            lblTitle.Size = new Size(293, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👥 QUẢN LÝ NHÂN VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.White;
            pnlToolbar.Controls.Add(txtTimKiem);
            pnlToolbar.Controls.Add(btnTimKiem);
            pnlToolbar.Controls.Add(btnKhoaMo);
            pnlToolbar.Controls.Add(btnSua);
            pnlToolbar.Controls.Add(btnThem);
            pnlToolbar.Controls.Add(btnLamMoi);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 50);
            pnlToolbar.Margin = new Padding(3, 2, 3, 2);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(862, 83);
            pnlToolbar.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(154, 59);
            txtTimKiem.Margin = new Padding(3, 2, 3, 2);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(218, 23);
            txtTimKiem.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(255, 217, 61);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.FromArgb(45, 55, 72);
            btnTimKiem.Location = new Point(23, 56);
            btnTimKiem.Margin = new Padding(3, 2, 3, 2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 28);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnKhoaMo
            // 
            btnKhoaMo.BackColor = Color.FromArgb(255, 87, 87);
            btnKhoaMo.Cursor = Cursors.Hand;
            btnKhoaMo.FlatAppearance.BorderSize = 0;
            btnKhoaMo.FlatStyle = FlatStyle.Flat;
            btnKhoaMo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnKhoaMo.ForeColor = Color.White;
            btnKhoaMo.Location = new Point(386, 20);
            btnKhoaMo.Margin = new Padding(3, 2, 3, 2);
            btnKhoaMo.Name = "btnKhoaMo";
            btnKhoaMo.Size = new Size(130, 28);
            btnKhoaMo.TabIndex = 3;
            btnKhoaMo.Text = "🔒 Khóa / Mở khóa";
            btnKhoaMo.UseVisualStyleBackColor = false;
            btnKhoaMo.Click += btnKhoaMo_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(108, 99, 255);
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(278, 20);
            btnSua.Margin = new Padding(3, 2, 3, 2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 28);
            btnSua.TabIndex = 2;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(255, 107, 157);
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(160, 20);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 28);
            btnThem.TabIndex = 1;
            btnThem.Text = "➕ Thêm mới";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(255, 217, 61);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.FromArgb(45, 55, 72);
            btnLamMoi.Location = new Point(23, 20);
            btnLamMoi.Margin = new Padding(3, 2, 3, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 28);
            btnLamMoi.TabIndex = 0;
            btnLamMoi.Text = "↻ Làm mới (F5)";
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
            dgvNhanVien.Location = new Point(0, 133);
            dgvNhanVien.Margin = new Padding(3, 2, 3, 2);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(862, 332);
            dgvNhanVien.TabIndex = 2;
            dgvNhanVien.CellFormatting += dgvNhanVien_CellFormatting;
            // 
            // ucEmployeeManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(dgvNhanVien);
            Controls.Add(pnlToolbar);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucEmployeeManagement";
            Size = new Size(862, 465);
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
