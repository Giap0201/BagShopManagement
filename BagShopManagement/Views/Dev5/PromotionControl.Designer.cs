
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
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            panel4 = new Panel();
            dgvDanhSachCTGG = new DataGridView();
            pnlHeader = new Panel();
            label7 = new Label();
            panel2 = new Panel();
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
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF6B9D");
            label1.Location = new Point(313, 16);
            label1.Name = "label1";
            label1.Size = new Size(480, 46);
            label1.TabIndex = 0;
            label1.Text = "🎁 Chương trình giảm giá";
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
            splitContainer1.Size = new Size(1056, 660);
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
            panel1.Size = new Size(661, 660);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvDanhSachCTGG);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 107);
            panel4.Name = "panel4";
            panel4.Size = new Size(661, 553);
            panel4.TabIndex = 1;
            // 
            // dgvDanhSachCTGG
            // 
            dgvDanhSachCTGG.AllowUserToAddRows = false;
            dgvDanhSachCTGG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachCTGG.Dock = DockStyle.Fill;
            dgvDanhSachCTGG.Location = new Point(0, 0);
            dgvDanhSachCTGG.Name = "dgvDanhSachCTGG";
            dgvDanhSachCTGG.RowHeadersWidth = 51;
            dgvDanhSachCTGG.Size = new Size(661, 553);
            dgvDanhSachCTGG.TabIndex = 0;
            //dgvDanhSachCTGG.CellContentClick += dgvDanhSachCTGG_CellContentClick;
            // 
            // pnlHeader
            // 
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
            label7.Location = new Point(21, 37);
            label7.Name = "label7";
            label7.Size = new Size(637, 41);
            label7.TabIndex = 0;
            label7.Text = "DANH SÁCH CHƯƠNG TRÌNH KHUYẾN MÃI";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
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
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(391, 660);
            panel2.TabIndex = 0;
            // 
            // txtMaCTGG
            // 
            txtMaCTGG.Location = new Point(182, 65);
            txtMaCTGG.Name = "txtMaCTGG";
            txtMaCTGG.Size = new Size(183, 27);
            txtMaCTGG.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(43, 65);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 14;
            label8.Text = "Mã CT : ";
            // 
            // btnChonSanPham
            // 
            btnChonSanPham.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD93D");
            btnChonSanPham.FlatStyle = FlatStyle.Flat;
            btnChonSanPham.FlatAppearance.BorderSize = 0;
            btnChonSanPham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChonSanPham.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnChonSanPham.Cursor = Cursors.Hand;
            btnChonSanPham.Location = new Point(205, 450);
            btnChonSanPham.Name = "btnChonSanPham";
            btnChonSanPham.Size = new Size(150, 82);
            btnChonSanPham.TabIndex = 13;
            btnChonSanPham.Text = "🛒 Áp dụng SP";
            btnChonSanPham.UseVisualStyleBackColor = false;
            btnChonSanPham.Click += btnChonSanPham_Click;
            // 
            // btnXoaCTGG
            // 
            btnXoaCTGG.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF5757");
            btnXoaCTGG.FlatStyle = FlatStyle.Flat;
            btnXoaCTGG.FlatAppearance.BorderSize = 0;
            btnXoaCTGG.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoaCTGG.ForeColor = Color.White;
            btnXoaCTGG.Cursor = Cursors.Hand;
            btnXoaCTGG.Location = new Point(52, 450);
            btnXoaCTGG.Name = "btnXoaCTGG";
            btnXoaCTGG.Size = new Size(130, 82);
            btnXoaCTGG.TabIndex = 12;
            btnXoaCTGG.Text = "🗑️ Xoá";
            btnXoaCTGG.UseVisualStyleBackColor = false;
            btnXoaCTGG.Click += btnXoaCTGG_Click;
            // 
            // btnLuuCTGG
            // 
            btnLuuCTGG.BackColor = System.Drawing.ColorTranslator.FromHtml("#6C63FF");
            btnLuuCTGG.FlatStyle = FlatStyle.Flat;
            btnLuuCTGG.FlatAppearance.BorderSize = 0;
            btnLuuCTGG.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuuCTGG.ForeColor = Color.White;
            btnLuuCTGG.Cursor = Cursors.Hand;
            btnLuuCTGG.Location = new Point(205, 385);
            btnLuuCTGG.Name = "btnLuuCTGG";
            btnLuuCTGG.Size = new Size(150, 46);
            btnLuuCTGG.TabIndex = 11;
            btnLuuCTGG.Text = "✔ Lưu/Cập nhật";
            btnLuuCTGG.UseVisualStyleBackColor = false;
            btnLuuCTGG.Click += btnLuuCTGG_Click;
            // 
            // btnThemCTGG
            // 
            btnThemCTGG.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6B9D");
            btnThemCTGG.FlatStyle = FlatStyle.Flat;
            btnThemCTGG.FlatAppearance.BorderSize = 0;
            btnThemCTGG.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemCTGG.ForeColor = Color.White;
            btnThemCTGG.Cursor = Cursors.Hand;
            btnThemCTGG.Location = new Point(52, 385);
            btnThemCTGG.Name = "btnThemCTGG";
            btnThemCTGG.Size = new Size(130, 46);
            btnThemCTGG.TabIndex = 10;
            btnThemCTGG.Text = "➕ Thêm Mới";
            btnThemCTGG.UseVisualStyleBackColor = false;
            btnThemCTGG.Click += btnThemCTGG_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(183, 267);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(150, 27);
            dateTimePicker2.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(183, 220);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(150, 27);
            dateTimePicker1.TabIndex = 8;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(183, 158);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(183, 27);
            txtMoTa.TabIndex = 7;
            // 
            // cmbTrangThai
            // 
            cmbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrangThai.FormattingEnabled = true;
            cmbTrangThai.Location = new Point(182, 317);
            cmbTrangThai.Name = "cmbTrangThai";
            cmbTrangThai.Size = new Size(151, 28);
            cmbTrangThai.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 320);
            label6.Name = "label6";
            label6.Size = new Size(86, 20);
            label6.TabIndex = 5;
            label6.Text = "Trạng thái : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 274);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 4;
            label5.Text = "Thời gian KT : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 227);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 3;
            label4.Text = "Thời gian BD : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 161);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 2;
            label3.Text = "Mô tả : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 107);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên CT : ";
            // 
            // txtTenCT
            // 
            txtTenCT.Location = new Point(183, 107);
            txtTenCT.Name = "txtTenCT";
            txtTenCT.Size = new Size(183, 27);
            txtTenCT.TabIndex = 0;
            // 
            // PromotionControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            Name = "PromotionControl";
            Size = new Size(1056, 660);
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
        private DataGridView dgvDanhSachCTGG;
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
    }
}
