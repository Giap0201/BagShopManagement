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
            dgvKhachHang = new DataGridView();
            txtTimKhachHang = new TextBox();
            btnTim = new Button();
            btnThemMoi = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnXuatExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            SuspendLayout();
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Location = new Point(45, 156);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(1099, 541);
            dgvKhachHang.TabIndex = 0;
            dgvKhachHang.CellContentClick += dgvKhachHang_CellContentClick;
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            // 
            // txtTimKhachHang
            // 
            txtTimKhachHang.BorderStyle = BorderStyle.FixedSingle;
            txtTimKhachHang.Font = new Font("Segoe UI", 10F);
            txtTimKhachHang.Location = new Point(45, 35);
            txtTimKhachHang.Name = "txtTimKhachHang";
            txtTimKhachHang.PlaceholderText = "Nhập tên hoặc SĐT...";
            txtTimKhachHang.Size = new Size(192, 30);
            txtTimKhachHang.TabIndex = 1;
            // 
            // btnTim
            // 
            btnTim.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD93D");
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTim.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnTim.Location = new Point(243, 29);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(125, 38);
            btnTim.TabIndex = 2;
            btnTim.Text = "🔍 Tìm kiếm";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Cursor = Cursors.Hand;
            btnTim.Click += btnTim_Click;
            // 
            // btnThemMoi
            // 
            btnThemMoi.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6B9D");
            btnThemMoi.FlatStyle = FlatStyle.Flat;
            btnThemMoi.FlatAppearance.BorderSize = 0;
            btnThemMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemMoi.ForeColor = Color.White;
            btnThemMoi.Location = new Point(394, 29);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(125, 38);
            btnThemMoi.TabIndex = 3;
            btnThemMoi.Text = "➕ Thêm Mới";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Cursor = Cursors.Hand;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = System.Drawing.ColorTranslator.FromHtml("#6C63FF");
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(864, 29);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(125, 38);
            btnSua.TabIndex = 4;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Visible = false;
            btnSua.Cursor = Cursors.Hand;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF5757");
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(708, 29);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(125, 38);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Visible = false;
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = System.Drawing.ColorTranslator.FromHtml("#6BCF7F");
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.FlatAppearance.BorderSize = 0;
            btnXuatExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(548, 29);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(125, 38);
            btnXuatExcel.TabIndex = 6;
            btnXuatExcel.Text = "📊 Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Cursor = Cursors.Hand;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // KhachHangControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            Controls.Add(btnXuatExcel);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThemMoi);
            Controls.Add(btnTim);
            Controls.Add(txtTimKhachHang);
            Controls.Add(dgvKhachHang);
            Name = "KhachHangControl";
            Size = new Size(1183, 711);
            Load += KhachHangControl_Load;
            Click += KhachHangControl_Click;
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvKhachHang;
        private TextBox txtTimKhachHang;
        private Button btnTim;
        private Button btnThemMoi;
        private Button btnSua;
        private Button btnXoa;
        private Button btnXuatExcel;
    }
}