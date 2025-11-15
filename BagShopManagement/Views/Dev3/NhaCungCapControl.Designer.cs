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
            btnTim.Location = new Point(236, 51);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(138, 52);
            btnTim.TabIndex = 1;
            btnTim.Text = "Tìm kiếm ";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(452, 51);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(138, 52);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThemMoi_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(670, 51);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(138, 52);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa ";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Visible = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(919, 51);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(138, 52);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Visible = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(66, 64);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(164, 27);
            txtTimKiem.TabIndex = 5;
            // 
            // NhaCungCapControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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
