namespace BagShopManagement.Views.Dev2
{
    partial class SanPhamControl
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
            dgvSanPham = new DataGridView();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // dgvSanPham
            // 
            dgvSanPham.ColumnHeadersHeight = 29;
            dgvSanPham.Location = new Point(20, 60);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(800, 400);
            dgvSanPham.TabIndex = 0;

            this.dgvSanPham.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvSanPham_CellDoubleClick);
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(20, 20);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(200, 27);
            txtTimKiem.TabIndex = 1;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(230, 18);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(75, 29);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm";
            btnTim.Click += btnTim_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(320, 18);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 29);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(410, 18);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 29);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(500, 18);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 29);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xoá";
            btnXoa.Click += btnXoa_Click;
            // 
            // SanPhamControl
            // 
            Controls.Add(dgvSanPham);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTim);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Name = "SanPhamControl";
            Size = new Size(843, 482);
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTimKiem;
        private Button btnTim;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private DataGridView dgvSanPham;
    }
}
