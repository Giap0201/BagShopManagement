namespace BagShopManagement.Views.Controls
{
    partial class frmApDungChiTiet
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTopInfo = new Panel();
            lblTenChuongTrinh = new Label();
            panel1 = new Panel();
            btnXacNhanKM = new Button();
            btnHuỵChonKM = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlLeft = new Panel();
            dgvKhoSanPham = new DataGridView();
            groupBox1 = new GroupBox();
            btnTimKiemKho = new Button();
            txtTimKiemKho = new TextBox();
            label4 = new Label();
            label3 = new Label();
            pnlCenter = new Panel();
            btnXoa = new Button();
            btnThem = new Button();
            nudPhanTramGiam = new NumericUpDown();
            label1 = new Label();
            pnlRight = new Panel();
            dgvSanPhamApDung = new DataGridView();
            groupBox2 = new GroupBox();
            btnTimKiemApDung = new Button();
            txtTimKiemApDung = new TextBox();
            label2 = new Label();
            label5 = new Label();
            pnlTopInfo.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoSanPham).BeginInit();
            groupBox1.SuspendLayout();
            pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPhanTramGiam).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPhamApDung).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopInfo
            // 
            pnlTopInfo.Controls.Add(lblTenChuongTrinh);
            pnlTopInfo.Dock = DockStyle.Top;
            pnlTopInfo.Location = new Point(0, 0);
            pnlTopInfo.Name = "pnlTopInfo";
            pnlTopInfo.Size = new Size(1549, 71);
            pnlTopInfo.TabIndex = 0;
            // 
            // lblTenChuongTrinh
            // 
            lblTenChuongTrinh.AutoSize = true;
            lblTenChuongTrinh.Location = new Point(482, 28);
            lblTenChuongTrinh.Name = "lblTenChuongTrinh";
            lblTenChuongTrinh.Size = new Size(120, 20);
            lblTenChuongTrinh.TabIndex = 0;
            lblTenChuongTrinh.Text = "Tên chương trình";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnXacNhanKM);
            panel1.Controls.Add(btnHuỵChonKM);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 624);
            panel1.Name = "panel1";
            panel1.Size = new Size(1549, 87);
            panel1.TabIndex = 1;
            // 
            // btnXacNhanKM
            // 
            btnXacNhanKM.Location = new Point(888, 20);
            btnXacNhanKM.Name = "btnXacNhanKM";
            btnXacNhanKM.Size = new Size(104, 46);
            btnXacNhanKM.TabIndex = 1;
            btnXacNhanKM.Text = "Xác nhận";
            btnXacNhanKM.UseVisualStyleBackColor = true;
            // 
            // btnHuỵChonKM
            // 
            btnHuỵChonKM.Location = new Point(735, 20);
            btnHuỵChonKM.Name = "btnHuỵChonKM";
            btnHuỵChonKM.Size = new Size(114, 46);
            btnHuỵChonKM.TabIndex = 0;
            btnHuỵChonKM.Text = "Hủy";
            btnHuỵChonKM.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pnlLeft, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlCenter, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlRight, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 71);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1549, 553);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(dgvKhoSanPham);
            pnlLeft.Controls.Add(groupBox1);
            pnlLeft.Controls.Add(label3);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(3, 3);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(640, 547);
            pnlLeft.TabIndex = 0;
            // 
            // dgvKhoSanPham
            // 
            dgvKhoSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhoSanPham.Dock = DockStyle.Fill;
            dgvKhoSanPham.Location = new Point(0, 145);
            dgvKhoSanPham.Name = "dgvKhoSanPham";
            dgvKhoSanPham.RowHeadersWidth = 51;
            dgvKhoSanPham.Size = new Size(640, 402);
            dgvKhoSanPham.TabIndex = 2;
            dgvKhoSanPham.CellContentClick += dgvKhoSanPham_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnTimKiemKho);
            groupBox1.Controls.Add(txtTimKiemKho);
            groupBox1.Controls.Add(label4);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(640, 125);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // btnTimKiemKho
            // 
            btnTimKiemKho.Location = new Point(238, 75);
            btnTimKiemKho.Name = "btnTimKiemKho";
            btnTimKiemKho.Size = new Size(94, 29);
            btnTimKiemKho.TabIndex = 3;
            btnTimKiemKho.Text = "Tìm";
            btnTimKiemKho.UseVisualStyleBackColor = true;
            // 
            // txtTimKiemKho
            // 
            txtTimKiemKho.Location = new Point(129, 32);
            txtTimKiemKho.Name = "txtTimKiemKho";
            txtTimKiemKho.Size = new Size(203, 27);
            txtTimKiemKho.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 35);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 1;
            label4.Text = "Tìm kiếm :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(191, 20);
            label3.TabIndex = 0;
            label3.Text = "Danh sách sản phẩm từ kho";
            // 
            // pnlCenter
            // 
            pnlCenter.Controls.Add(btnXoa);
            pnlCenter.Controls.Add(btnThem);
            pnlCenter.Controls.Add(nudPhanTramGiam);
            pnlCenter.Controls.Add(label1);
            pnlCenter.Dock = DockStyle.Fill;
            pnlCenter.Location = new Point(649, 3);
            pnlCenter.Name = "pnlCenter";
            pnlCenter.Size = new Size(250, 547);
            pnlCenter.TabIndex = 1;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Times New Roman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(87, 274);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 46);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "<<";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Times New Roman", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(87, 214);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 40);
            btnThem.TabIndex = 2;
            btnThem.Text = ">>";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // nudPhanTramGiam
            // 
            nudPhanTramGiam.Location = new Point(53, 157);
            nudPhanTramGiam.Name = "nudPhanTramGiam";
            nudPhanTramGiam.Size = new Size(150, 27);
            nudPhanTramGiam.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(63, 84);
            label1.Name = "label1";
            label1.Size = new Size(127, 41);
            label1.TabIndex = 0;
            label1.Text = "% Giảm:";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(dgvSanPhamApDung);
            pnlRight.Controls.Add(groupBox2);
            pnlRight.Controls.Add(label5);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(905, 3);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(641, 547);
            pnlRight.TabIndex = 2;
            // 
            // dgvSanPhamApDung
            // 
            dgvSanPhamApDung.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPhamApDung.Dock = DockStyle.Fill;
            dgvSanPhamApDung.Location = new Point(0, 145);
            dgvSanPhamApDung.Name = "dgvSanPhamApDung";
            dgvSanPhamApDung.RowHeadersWidth = 51;
            dgvSanPhamApDung.Size = new Size(641, 402);
            dgvSanPhamApDung.TabIndex = 5;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnTimKiemApDung);
            groupBox2.Controls.Add(txtTimKiemApDung);
            groupBox2.Controls.Add(label2);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(641, 125);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm kiếm";
            // 
            // btnTimKiemApDung
            // 
            btnTimKiemApDung.Location = new Point(238, 75);
            btnTimKiemApDung.Name = "btnTimKiemApDung";
            btnTimKiemApDung.Size = new Size(94, 29);
            btnTimKiemApDung.TabIndex = 3;
            btnTimKiemApDung.Text = "Tìm";
            btnTimKiemApDung.UseVisualStyleBackColor = true;
            // 
            // txtTimKiemApDung
            // 
            txtTimKiemApDung.Location = new Point(129, 32);
            txtTimKiemApDung.Name = "txtTimKiemApDung";
            txtTimKiemApDung.Size = new Size(203, 27);
            txtTimKiemApDung.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 35);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Tìm kiếm :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(224, 20);
            label5.TabIndex = 3;
            label5.Text = "Danh sách sản phẩm khuyến mãi";
            // 
            // frmApDungChiTiet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1549, 711);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(pnlTopInfo);
            Name = "frmApDungChiTiet";
            Text = "frmApDungChiTiet";
            pnlTopInfo.ResumeLayout(false);
            pnlTopInfo.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoSanPham).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlCenter.ResumeLayout(false);
            pnlCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPhanTramGiam).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPhamApDung).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTopInfo;
        private Label lblTenChuongTrinh;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlLeft;
        private Label label3;
        private Panel pnlCenter;
        private Label label1;
        private Panel pnlRight;
        private Button btnXacNhanKM;
        private Button btnHuỵChonKM;
        private DataGridView dgvKhoSanPham;
        private GroupBox groupBox1;
        private Button btnTimKiemKho;
        private TextBox txtTimKiemKho;
        private Label label4;
        private DataGridView dgvSanPhamApDung;
        private GroupBox groupBox2;
        private Button btnTimKiemApDung;
        private TextBox txtTimKiemApDung;
        private Label label2;
        private Label label5;
        private NumericUpDown nudPhanTramGiam;
        private Button btnXoa;
        private Button btnThem;
        private Button button2;
    }
}