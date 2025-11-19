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
            groupBox1 = new GroupBox();
            btnReset = new Button();
            groupBox2 = new GroupBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvNCC).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvNCC
            // 
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNCC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNCC.Location = new Point(6, 34);
            dgvNCC.Name = "dgvNCC";
            dgvNCC.ReadOnly = true;
            dgvNCC.RowHeadersWidth = 51;
            dgvNCC.Size = new Size(913, 454);
            dgvNCC.TabIndex = 0;
            dgvNCC.SelectionChanged += dgvNCC_SelectionChanged;
            // 
            // btnTim
            // 
            btnTim.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTim.ForeColor = Color.FromArgb(51, 51, 51);
            btnTim.Location = new Point(64, 41);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(125, 36);
            btnTim.TabIndex = 1;
            btnTim.Text = "Tìm kiếm ";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThem.ForeColor = Color.FromArgb(51, 51, 51);
            btnThem.Location = new Point(136, 112);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(175, 64);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThemMoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(224, 224, 224);
            btnSua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.FromArgb(51, 51, 51);
            btnSua.Location = new Point(136, 413);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(175, 64);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa ";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Visible = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(136, 317);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(175, 64);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Visible = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BackColor = Color.White;
            txtTimKiem.ForeColor = Color.Black;
            txtTimKiem.Location = new Point(186, 41);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(239, 36);
            txtTimKiem.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnReset);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(txtTimKiem);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(btnTim);
            groupBox1.Location = new Point(67, 227);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(482, 494);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "thao tác";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnReset.ForeColor = Color.FromArgb(51, 51, 51);
            btnReset.Location = new Point(136, 216);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(175, 64);
            btnReset.TabIndex = 6;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvNCC);
            groupBox2.Location = new Point(555, 227);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(925, 494);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách nhà cung cấp";
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
            Controls.Add(groupBox1);
            Name = "NhaCungCapControl";
            Size = new Size(1509, 846);
            Load += NhaCungCapControl_Load;
            Click += NhaCungCapControl_Click;
            ((System.ComponentModel.ISupportInitialize)dgvNCC).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
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
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnReset;
        private Label label1;
    }
}
