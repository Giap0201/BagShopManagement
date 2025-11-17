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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvSanPham = new DataGridView();
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnExport = new Button();
            picAnhChinh = new PictureBox();
            btnImport = new Button();
            groupBox1 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnRefresh = new Button();
            btnLoc = new Button();
            cboTrangThai = new ComboBox();
            cboNCC = new ComboBox();
            cboKichThuoc = new ComboBox();
            cboMau = new ComboBox();
            cboChatLieu = new ComboBox();
            cboThuongHieu = new ComboBox();
            cboLoaiTui = new ComboBox();
            cboGiaBan = new ComboBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAnhChinh).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSanPham
            // 
            dgvSanPham.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSanPham.ColumnHeadersHeight = 40;
            dgvSanPham.EnableHeadersVisualStyles = false;
            dgvSanPham.GridColor = SystemColors.Control;
            dgvSanPham.Location = new Point(19, 497);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSanPham.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSanPham.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dgvSanPham.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvSanPham.Size = new Size(1519, 382);
            dgvSanPham.TabIndex = 0;
            dgvSanPham.CellDoubleClick += dgvSanPham_CellDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtSearch.ForeColor = Color.FromArgb(51, 51, 51);
            txtSearch.Location = new Point(17, 38);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm";
            txtSearch.Size = new Size(343, 30);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(224, 224, 224);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAdd.ForeColor = Color.FromArgb(51, 51, 51);
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(17, 82);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(343, 55);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(224, 224, 224);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEdit.ForeColor = Color.FromArgb(51, 51, 51);
            btnEdit.Location = new Point(17, 143);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(343, 55);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 100, 100);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(17, 329);
            btnDelete.Margin = new Padding(0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(343, 55);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(224, 224, 224);
            btnExport.Cursor = Cursors.Hand;
            btnExport.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnExport.ForeColor = Color.FromArgb(51, 51, 51);
            btnExport.Location = new Point(17, 268);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(343, 55);
            btnExport.TabIndex = 6;
            btnExport.Text = "Xuất file";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // 
            // picAnhChinh
            // 
            picAnhChinh.Location = new Point(15, 26);
            picAnhChinh.Name = "picAnhChinh";
            picAnhChinh.Size = new Size(653, 358);
            picAnhChinh.TabIndex = 7;
            picAnhChinh.TabStop = false;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(224, 224, 224);
            btnImport.Cursor = Cursors.Hand;
            btnImport.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnImport.ForeColor = Color.FromArgb(51, 51, 51);
            btnImport.Location = new Point(17, 204);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(343, 55);
            btnImport.TabIndex = 9;
            btnImport.Text = "Nhập file";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += BtnImport_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnLoc);
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(cboNCC);
            groupBox1.Controls.Add(cboKichThuoc);
            groupBox1.Controls.Add(cboMau);
            groupBox1.Controls.Add(cboChatLieu);
            groupBox1.Controls.Add(cboThuongHieu);
            groupBox1.Controls.Add(cboLoaiTui);
            groupBox1.Controls.Add(cboGiaBan);
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox1.ForeColor = Color.FromArgb(51, 51, 51);
            groupBox1.Location = new Point(19, 93);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(444, 398);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bộ lọc";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(51, 51, 51);
            label8.Location = new Point(30, 282);
            label8.Name = "label8";
            label8.Size = new Size(87, 23);
            label8.TabIndex = 17;
            label8.Text = "Trạng thái";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(51, 51, 51);
            label7.Location = new Point(30, 248);
            label7.Name = "label7";
            label7.Size = new Size(117, 23);
            label7.TabIndex = 16;
            label7.Text = "Nhà cung cấp";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(51, 51, 51);
            label6.Location = new Point(30, 214);
            label6.Name = "label6";
            label6.Size = new Size(92, 23);
            label6.TabIndex = 15;
            label6.Text = "Kích thước";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(51, 51, 51);
            label5.Location = new Point(30, 180);
            label5.Name = "label5";
            label5.Size = new Size(74, 23);
            label5.TabIndex = 14;
            label5.Text = "Màu sắc";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(51, 51, 51);
            label4.Location = new Point(30, 146);
            label4.Name = "label4";
            label4.Size = new Size(78, 23);
            label4.TabIndex = 13;
            label4.Text = "Chất liệu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(51, 51, 51);
            label3.Location = new Point(30, 112);
            label3.Name = "label3";
            label3.Size = new Size(108, 23);
            label3.TabIndex = 12;
            label3.Text = "Thương hiệu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(51, 51, 51);
            label2.Location = new Point(30, 79);
            label2.Name = "label2";
            label2.Size = new Size(66, 23);
            label2.TabIndex = 11;
            label2.Text = "Loại túi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(30, 44);
            label1.Name = "label1";
            label1.Size = new Size(69, 23);
            label1.TabIndex = 10;
            label1.Text = "Giá bán";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(64, 78, 103);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(230, 322);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(176, 62);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = SystemColors.Highlight;
            btnLoc.Cursor = Cursors.Hand;
            btnLoc.FlatStyle = FlatStyle.Flat;
            btnLoc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnLoc.ForeColor = Color.White;
            btnLoc.Location = new Point(30, 322);
            btnLoc.Margin = new Padding(0);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(175, 62);
            btnLoc.TabIndex = 8;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = false;
            // 
            // cboTrangThai
            // 
            cboTrangThai.Cursor = Cursors.Hand;
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FlatStyle = FlatStyle.Popup;
            cboTrangThai.Font = new Font("Segoe UI", 10.2F);
            cboTrangThai.ForeColor = Color.FromArgb(51, 51, 51);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(158, 279);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(248, 31);
            cboTrangThai.TabIndex = 7;
            // 
            // cboNCC
            // 
            cboNCC.Cursor = Cursors.Hand;
            cboNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNCC.FlatStyle = FlatStyle.Popup;
            cboNCC.Font = new Font("Segoe UI", 10.2F);
            cboNCC.ForeColor = Color.FromArgb(51, 51, 51);
            cboNCC.FormattingEnabled = true;
            cboNCC.Location = new Point(158, 245);
            cboNCC.Name = "cboNCC";
            cboNCC.Size = new Size(248, 31);
            cboNCC.TabIndex = 6;
            // 
            // cboKichThuoc
            // 
            cboKichThuoc.Cursor = Cursors.Hand;
            cboKichThuoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKichThuoc.FlatStyle = FlatStyle.Popup;
            cboKichThuoc.Font = new Font("Segoe UI", 10.2F);
            cboKichThuoc.ForeColor = Color.FromArgb(51, 51, 51);
            cboKichThuoc.FormattingEnabled = true;
            cboKichThuoc.Location = new Point(158, 211);
            cboKichThuoc.Name = "cboKichThuoc";
            cboKichThuoc.Size = new Size(248, 31);
            cboKichThuoc.TabIndex = 5;
            // 
            // cboMau
            // 
            cboMau.Cursor = Cursors.Hand;
            cboMau.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMau.FlatStyle = FlatStyle.Popup;
            cboMau.Font = new Font("Segoe UI", 10.2F);
            cboMau.ForeColor = Color.FromArgb(51, 51, 51);
            cboMau.FormattingEnabled = true;
            cboMau.Location = new Point(158, 177);
            cboMau.Name = "cboMau";
            cboMau.Size = new Size(248, 31);
            cboMau.TabIndex = 4;
            // 
            // cboChatLieu
            // 
            cboChatLieu.Cursor = Cursors.Hand;
            cboChatLieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChatLieu.FlatStyle = FlatStyle.Popup;
            cboChatLieu.Font = new Font("Segoe UI", 10.2F);
            cboChatLieu.ForeColor = Color.FromArgb(51, 51, 51);
            cboChatLieu.FormattingEnabled = true;
            cboChatLieu.Location = new Point(158, 143);
            cboChatLieu.Name = "cboChatLieu";
            cboChatLieu.Size = new Size(248, 31);
            cboChatLieu.TabIndex = 3;
            // 
            // cboThuongHieu
            // 
            cboThuongHieu.Cursor = Cursors.Hand;
            cboThuongHieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThuongHieu.FlatStyle = FlatStyle.Popup;
            cboThuongHieu.Font = new Font("Segoe UI", 10.2F);
            cboThuongHieu.ForeColor = Color.FromArgb(51, 51, 51);
            cboThuongHieu.FormattingEnabled = true;
            cboThuongHieu.Location = new Point(158, 109);
            cboThuongHieu.Name = "cboThuongHieu";
            cboThuongHieu.Size = new Size(248, 31);
            cboThuongHieu.TabIndex = 2;
            // 
            // cboLoaiTui
            // 
            cboLoaiTui.Cursor = Cursors.Hand;
            cboLoaiTui.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiTui.FlatStyle = FlatStyle.Popup;
            cboLoaiTui.Font = new Font("Segoe UI", 10.2F);
            cboLoaiTui.ForeColor = Color.FromArgb(51, 51, 51);
            cboLoaiTui.FormattingEnabled = true;
            cboLoaiTui.Location = new Point(158, 75);
            cboLoaiTui.Name = "cboLoaiTui";
            cboLoaiTui.Size = new Size(248, 31);
            cboLoaiTui.TabIndex = 1;
            // 
            // cboGiaBan
            // 
            cboGiaBan.Cursor = Cursors.Hand;
            cboGiaBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGiaBan.FlatStyle = FlatStyle.Popup;
            cboGiaBan.Font = new Font("Segoe UI", 10.2F);
            cboGiaBan.ForeColor = Color.FromArgb(51, 51, 51);
            cboGiaBan.FormattingEnabled = true;
            cboGiaBan.Location = new Point(158, 41);
            cboGiaBan.Name = "cboGiaBan";
            cboGiaBan.Size = new Size(248, 31);
            cboGiaBan.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSearch);
            groupBox2.Controls.Add(btnAdd);
            groupBox2.Controls.Add(btnImport);
            groupBox2.Controls.Add(btnExport);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(btnEdit);
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox2.ForeColor = Color.FromArgb(51, 51, 51);
            groupBox2.Location = new Point(469, 93);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(377, 398);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hành động";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(picAnhChinh);
            groupBox3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox3.ForeColor = Color.FromArgb(51, 51, 51);
            groupBox3.Location = new Point(852, 93);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(686, 398);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ảnh";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label9.ForeColor = Color.FromArgb(51, 51, 51);
            label9.Location = new Point(624, 34);
            label9.Name = "label9";
            label9.Size = new Size(342, 38);
            label9.TabIndex = 13;
            label9.Text = "DANH SÁCH SẢN PHẨM";
            // 
            // SanPhamControl
            // 
            BackColor = SystemColors.Control;
            Controls.Add(label9);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvSanPham);
            Margin = new Padding(0);
            Name = "SanPhamControl";
            Size = new Size(1555, 894);
            Load += SanPhamControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAnhChinh).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvSanPham;
        private Button btnExport;
        private PictureBox picAnhChinh;
        private Button btnImport;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnRefresh;
        private Button btnLoc;
        private ComboBox cboTrangThai;
        private ComboBox cboNCC;
        private ComboBox cboKichThuoc;
        private ComboBox cboMau;
        private ComboBox cboChatLieu;
        private ComboBox cboThuongHieu;
        private ComboBox cboLoaiTui;
        private ComboBox cboGiaBan;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox3;
        private Label label9;
    }
}
