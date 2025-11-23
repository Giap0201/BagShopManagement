namespace BagShopManagement.Views.Dev2
{
    partial class LoaiTuiControl
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
            dgvLoaiTui = new DataGridView();
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnImport = new Button();
            btnExport = new Button();
            groupBox1 = new GroupBox();
            groupBox = new GroupBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiTui).BeginInit();
            groupBox1.SuspendLayout();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // dgvLoaiTui
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLoaiTui.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLoaiTui.ColumnHeadersHeight = 40;
            dgvLoaiTui.Location = new Point(16, 29);
            dgvLoaiTui.Name = "dgvLoaiTui";
            dgvLoaiTui.ReadOnly = true;
            dgvLoaiTui.RowHeadersWidth = 51;
            dgvLoaiTui.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvLoaiTui.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvLoaiTui.Size = new Size(956, 431);
            dgvLoaiTui.TabIndex = 0;
            dgvLoaiTui.CellDoubleClick += dgvLoaiTui_CellDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.Control;
            txtSearch.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.FromArgb(51, 51, 51);
            txtSearch.Location = new Point(19, 29);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm";
            txtSearch.Size = new Size(494, 50);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.Highlight;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(19, 88);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(494, 67);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(64, 78, 103);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(19, 164);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(494, 67);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(19, 392);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(494, 67);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.FromArgb(224, 224, 224);
            btnImport.Cursor = Cursors.Hand;
            btnImport.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnImport.Location = new Point(19, 240);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(494, 67);
            btnImport.TabIndex = 7;
            btnImport.Text = "Nhập file";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += BtnImport_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(224, 224, 224);
            btnExport.Cursor = Cursors.Hand;
            btnExport.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnExport.Location = new Point(19, 316);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(494, 67);
            btnExport.TabIndex = 8;
            btnExport.Text = "Xuất file";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnExport);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnImport);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox1.ForeColor = Color.FromArgb(51, 51, 51);
            groupBox1.Location = new Point(27, 142);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(531, 473);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thao tác";
            // 
            // groupBox
            // 
            groupBox.Controls.Add(dgvLoaiTui);
            groupBox.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            groupBox.Location = new Point(564, 142);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(987, 473);
            groupBox.TabIndex = 10;
            groupBox.TabStop = false;
            groupBox.Text = "Chi tiết";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(640, 53);
            label1.Name = "label1";
            label1.Size = new Size(297, 38);
            label1.TabIndex = 11;
            label1.Text = "DANH MỤC LOẠI TÚI";
            // 
            // LoaiTuiControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(groupBox);
            Controls.Add(groupBox1);
            ForeColor = Color.FromArgb(51, 51, 51);
            Name = "LoaiTuiControl";
            Size = new Size(1569, 703);
            ((System.ComponentModel.ISupportInitialize)dgvLoaiTui).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLoaiTui;
        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnImport;
        private Button btnExport;
        private GroupBox groupBox1;
        private GroupBox groupBox;
        private Label label1;
    }
}
