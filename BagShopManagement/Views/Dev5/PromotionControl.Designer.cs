
namespace BagShopManagement.Views.Controls
{
    partial class PromotionControl
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
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            panel4 = new Panel();
            dgvDanhSachCTGG = new DataGridView();
            splitter1 = new Splitter();
            pnlHeader = new Panel();
            label7 = new Label();
            panel2 = new Panel();
            splitter2 = new Splitter();
            txtMaCTGG = new TextBox();
            label8 = new Label();
            btnChonSanPham = new Button();
            btnXoaCTGG = new Button();
            btnLuuCTGG = new Button();
            btnThemCTGG = new Button();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            txtMoTa = new TextBox();
            cmbTrangThai = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtTenCT = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachCTGG).BeginInit();
            pnlHeader.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(313, 16);
            label1.Name = "label1";
            label1.Size = new Size(436, 49);
            label1.TabIndex = 0;
            label1.Text = "Chương trình giảm giá";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new Size(1056, 601);
            splitContainer1.SplitterDistance = 661;
            splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(pnlHeader);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(661, 601);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvDanhSachCTGG);
            panel4.Controls.Add(splitter1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 107);
            panel4.Name = "panel4";
            panel4.Size = new Size(661, 494);
            panel4.TabIndex = 1;
            // 
            // dgvDanhSachCTGG
            // 
            dgvDanhSachCTGG.AllowUserToAddRows = false;
            dgvDanhSachCTGG.AllowUserToDeleteRows = false;
            dgvDanhSachCTGG.AllowUserToResizeColumns = false;
            dgvDanhSachCTGG.AllowUserToResizeRows = false;
            dgvDanhSachCTGG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachCTGG.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDanhSachCTGG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDanhSachCTGG.ColumnHeadersHeight = 29;
            dgvDanhSachCTGG.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(54, 54, 54);
            dataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDanhSachCTGG.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDanhSachCTGG.Dock = DockStyle.Fill;
            dgvDanhSachCTGG.EnableHeadersVisualStyles = false;
            dgvDanhSachCTGG.GridColor = Color.LightGray;
            dgvDanhSachCTGG.Location = new Point(0, 0);
            dgvDanhSachCTGG.MultiSelect = false;
            dgvDanhSachCTGG.Name = "dgvDanhSachCTGG";
            dgvDanhSachCTGG.ReadOnly = true;
            dgvDanhSachCTGG.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvDanhSachCTGG.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDanhSachCTGG.RowHeadersVisible = false;
            dgvDanhSachCTGG.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dgvDanhSachCTGG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachCTGG.Size = new Size(661, 445);
            dgvDanhSachCTGG.TabIndex = 15;
            // 
            // splitter1
            // 
            splitter1.Dock = DockStyle.Bottom;
            splitter1.Location = new Point(0, 445);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(661, 49);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(52, 73, 94);
            pnlHeader.Controls.Add(label7);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(661, 107);
            pnlHeader.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(3, 34);
            label7.Name = "label7";
            label7.Size = new Size(637, 41);
            label7.TabIndex = 0;
            label7.Text = "DANH SÁCH CHƯƠNG TRÌNH KHUYẾN MÃI";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(splitter2);
            panel2.Controls.Add(txtMaCTGG);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(btnChonSanPham);
            panel2.Controls.Add(btnXoaCTGG);
            panel2.Controls.Add(btnLuuCTGG);
            panel2.Controls.Add(btnThemCTGG);
            panel2.Controls.Add(dateTimePicker2);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(txtMoTa);
            panel2.Controls.Add(cmbTrangThai);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtTenCT);
            panel2.Dock = DockStyle.Fill;
            panel2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(391, 601);
            panel2.TabIndex = 0;
            // 
            // splitter2
            // 
            splitter2.BackColor = SystemColors.Control;
            splitter2.Dock = DockStyle.Bottom;
            splitter2.Location = new Point(0, 552);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(391, 49);
            splitter2.TabIndex = 16;
            splitter2.TabStop = false;
            // 
            // txtMaCTGG
            // 
            txtMaCTGG.Location = new Point(182, 65);
            txtMaCTGG.Name = "txtMaCTGG";
            txtMaCTGG.Size = new Size(183, 30);
            txtMaCTGG.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.Control;
            label8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(43, 65);
            label8.Name = "label8";
            label8.Size = new Size(74, 23);
            label8.TabIndex = 14;
            label8.Text = "Mã CT : ";
            // 
            // btnChonSanPham
            // 
            btnChonSanPham.BackColor = Color.FromArgb(51, 51, 51);
            btnChonSanPham.Cursor = Cursors.Hand;
            btnChonSanPham.FlatStyle = FlatStyle.Flat;
            btnChonSanPham.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnChonSanPham.ForeColor = Color.White;
            btnChonSanPham.Location = new Point(197, 464);
            btnChonSanPham.Name = "btnChonSanPham";
            btnChonSanPham.Size = new Size(136, 82);
            btnChonSanPham.TabIndex = 13;
            btnChonSanPham.Text = "\U0001f6d2 Áp dụng Sản phẩm";
            btnChonSanPham.UseVisualStyleBackColor = false;
            btnChonSanPham.Click += btnChonSanPham_Click;
            // 
            // btnXoaCTGG
            // 
            btnXoaCTGG.BackColor = Color.Red;
            btnXoaCTGG.Cursor = Cursors.Hand;
            btnXoaCTGG.FlatStyle = FlatStyle.Flat;
            btnXoaCTGG.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnXoaCTGG.ForeColor = Color.White;
            btnXoaCTGG.Location = new Point(29, 464);
            btnXoaCTGG.Name = "btnXoaCTGG";
            btnXoaCTGG.Size = new Size(148, 82);
            btnXoaCTGG.TabIndex = 12;
            btnXoaCTGG.Text = "Xóa";
            btnXoaCTGG.UseVisualStyleBackColor = false;
            btnXoaCTGG.Click += btnXoaCTGG_Click;
            // 
            // btnLuuCTGG
            // 
            btnLuuCTGG.BackColor = SystemColors.Highlight;
            btnLuuCTGG.Cursor = Cursors.Hand;
            btnLuuCTGG.FlatStyle = FlatStyle.Flat;
            btnLuuCTGG.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLuuCTGG.ForeColor = Color.White;
            btnLuuCTGG.Location = new Point(197, 381);
            btnLuuCTGG.Name = "btnLuuCTGG";
            btnLuuCTGG.Size = new Size(136, 77);
            btnLuuCTGG.TabIndex = 11;
            btnLuuCTGG.Text = "Lưu / Cập nhật";
            btnLuuCTGG.UseVisualStyleBackColor = false;
            btnLuuCTGG.Click += btnLuuCTGG_Click;
            // 
            // btnThemCTGG
            // 
            btnThemCTGG.BackColor = Color.FromArgb(224, 224, 224);
            btnThemCTGG.Cursor = Cursors.Hand;
            btnThemCTGG.FlatStyle = FlatStyle.Flat;
            btnThemCTGG.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThemCTGG.ForeColor = Color.FromArgb(51, 51, 51);
            btnThemCTGG.Location = new Point(29, 381);
            btnThemCTGG.Name = "btnThemCTGG";
            btnThemCTGG.Size = new Size(148, 77);
            btnThemCTGG.TabIndex = 10;
            btnThemCTGG.Text = "Thêm Mới";
            btnThemCTGG.UseVisualStyleBackColor = false;
            btnThemCTGG.Click += btnThemCTGG_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(183, 283);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(150, 30);
            dateTimePicker2.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(183, 236);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(150, 30);
            dateTimePicker1.TabIndex = 8;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(183, 158);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(183, 64);
            txtMoTa.TabIndex = 7;
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrangThai.FormattingEnabled = true;
            cmbTrangThai.Location = new Point(182, 333);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new Size(151, 31);
            cmbTrangThai.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 336);
            label6.Name = "label6";
            label6.Size = new Size(101, 23);
            label6.TabIndex = 5;
            label6.Text = "Trạng thái : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 290);
            label5.Name = "label5";
            label5.Size = new Size(119, 23);
            label5.TabIndex = 4;
            label5.Text = "Thời gian KT : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 243);
            label4.Name = "label4";
            label4.Size = new Size(122, 23);
            label4.TabIndex = 3;
            label4.Text = "Thời gian BD : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 161);
            label3.Name = "label3";
            label3.Size = new Size(70, 23);
            label3.TabIndex = 2;
            label3.Text = "Mô tả : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(43, 107);
            label2.Name = "label2";
            label2.Size = new Size(75, 23);
            label2.TabIndex = 1;
            label2.Text = "Tên CT : ";
            // 
            // txtTenCT
            // 
            txtTenCT.Location = new Point(183, 107);
            txtTenCT.Name = "txtTenCT";
            txtTenCT.Size = new Size(183, 30);
            txtTenCT.TabIndex = 0;
            // 
            // PromotionControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            Name = "PromotionControl";
            Size = new Size(1056, 601);
            Load += PromotionControl_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachCTGG).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label1;
        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panel2;
        private TextBox txtTenCT;
        private Panel panel4;
        private Panel pnlHeader;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cmbTrangThai;
        private Button btnChonSanPham;
        private Button btnXoaCTGG;
        private Button btnLuuCTGG;
        private Button btnThemCTGG;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private TextBox txtMoTa;
        private Label label7;
        private TextBox txtMaCTGG;
        private Label label8;
        private Splitter splitter1;
        private Splitter splitter2;
        private DataGridView dgvDanhSachCTGG;
    }
}
