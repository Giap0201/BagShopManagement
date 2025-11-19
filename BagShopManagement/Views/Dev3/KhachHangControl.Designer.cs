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
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            btnReset = new Button();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Location = new Point(27, 66);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(794, 529);
            dgvKhachHang.TabIndex = 0;
            dgvKhachHang.CellContentClick += dgvKhachHang_CellContentClick;
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            // 
            // txtTimKhachHang
            // 
            txtTimKhachHang.Location = new Point(67, 55);
            txtTimKhachHang.Name = "txtTimKhachHang";
            txtTimKhachHang.Size = new Size(197, 27);
            txtTimKhachHang.TabIndex = 1;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(67, 112);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(197, 60);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm kiếm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnThemMoi
            // 
            btnThemMoi.Location = new Point(67, 284);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(197, 60);
            btnThemMoi.TabIndex = 3;
            btnThemMoi.Text = "Thêm Mới";
            btnThemMoi.UseVisualStyleBackColor = true;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(67, 462);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(197, 60);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Visible = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(67, 553);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(197, 61);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Visible = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(67, 371);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(197, 60);
            btnXuatExcel.TabIndex = 6;
            btnXuatExcel.Text = "Xuất excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(552, 24);
            label1.Name = "label1";
            label1.Size = new Size(166, 20);
            label1.TabIndex = 7;
            label1.Text = "QUẢN LÍ KHÁCH HÀNG";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnReset);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnXuatExcel);
            groupBox1.Controls.Add(txtTimKhachHang);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnTim);
            groupBox1.Controls.Add(btnThemMoi);
            groupBox1.Location = new Point(163, 117);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(383, 620);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thao tác";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(67, 197);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(197, 60);
            btnReset.TabIndex = 7;
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvKhachHang);
            groupBox2.Location = new Point(552, 117);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(841, 620);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách khách hàng";
            // 
            // KhachHangControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "KhachHangControl";
            Size = new Size(1491, 836);
            Load += KhachHangControl_Load;
            Click += KhachHangControl_Click;
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
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
        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnReset;
    }
}