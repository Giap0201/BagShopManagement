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
            dgvNCC = new DataGridView();
            btnTim = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            txtTimKiem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvNCC).BeginInit();
            SuspendLayout();
            // 
            // dgvNCC
            // 
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNCC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNCC.Location = new Point(1, 217);
            dgvNCC.Name = "dgvNCC";
            dgvNCC.ReadOnly = true;
            dgvNCC.RowHeadersWidth = 51;
            dgvNCC.Size = new Size(1319, 455);
            dgvNCC.TabIndex = 0;
            dgvNCC.SelectionChanged += dgvNCC_SelectionChanged;
            // 
            // btnTim
            // 
            btnTim.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD93D");
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTim.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnTim.Cursor = Cursors.Hand;
            btnTim.Location = new Point(236, 51);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(138, 52);
            btnTim.TabIndex = 1;
            btnTim.Text = "🔍 Tìm";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Click += btnTim_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6B9D");
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Cursor = Cursors.Hand;
            btnThem.Location = new Point(452, 51);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(138, 52);
            btnThem.TabIndex = 2;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThemMoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = System.Drawing.ColorTranslator.FromHtml("#6C63FF");
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Cursor = Cursors.Hand;
            btnSua.Location = new Point(670, 51);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(138, 52);
            btnSua.TabIndex = 3;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Visible = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF5757");
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.Location = new Point(919, 51);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(138, 52);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Visible = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(66, 64);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên NCC...";
            txtTimKiem.Size = new Size(164, 30);
            txtTimKiem.TabIndex = 5;
            // 
            // NhaCungCapControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            Controls.Add(txtTimKiem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnTim);
            Controls.Add(dgvNCC);
            Name = "NhaCungCapControl";
            Size = new Size(1348, 687);
            Load += NhaCungCapControl_Load;
            Click += NhaCungCapControl_Click;
            ((System.ComponentModel.ISupportInitialize)dgvNCC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvNCC;
        private Button btnTim;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private TextBox txtTimKiem;
    }
}
