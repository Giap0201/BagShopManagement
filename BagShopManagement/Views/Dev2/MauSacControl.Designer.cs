namespace BagShopManagement.Views.Dev2
{
    partial class MauSacControl
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
            dgvMauSac = new DataGridView();
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnImport = new Button();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMauSac).BeginInit();
            SuspendLayout();
            // 
            // dgvMauSac
            // 
            dgvMauSac.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMauSac.Location = new Point(27, 126);
            dgvMauSac.Name = "dgvMauSac";
            dgvMauSac.RowHeadersWidth = 51;
            dgvMauSac.Size = new Size(867, 361);
            dgvMauSac.TabIndex = 0;
            dgvMauSac.CellDoubleClick += dgvMauSac_CellDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(27, 57);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm";
            txtSearch.Size = new Size(260, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6B9D");
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font(btnAdd.Font.FontFamily, btnAdd.Font.Size, FontStyle.Bold);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Location = new Point(319, 55);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "➕ Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#6C63FF");
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Font = new Font(btnEdit.Font.FontFamily, btnEdit.Font.Size, FontStyle.Bold);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Location = new Point(447, 55);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "✏️ Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF5757");
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font(btnDelete.Font.FontFamily, btnDelete.Font.Size, FontStyle.Bold);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Location = new Point(570, 55);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "🗑️ Xoá";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnImport
            // 
            btnImport.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD93D");
            btnImport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.Font = new Font(btnImport.Font.FontFamily, btnImport.Font.Size, FontStyle.Bold);
            btnImport.Cursor = Cursors.Hand;
            btnImport.Location = new Point(679, 55);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(94, 29);
            btnImport.TabIndex = 7;
            btnImport.Text = "📂 Nhập file";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += BtnImport_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = System.Drawing.ColorTranslator.FromHtml("#6BCF7F");
            btnExport.ForeColor = Color.White;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.Font = new Font(btnExport.Font.FontFamily, btnExport.Font.Size, FontStyle.Bold);
            btnExport.Cursor = Cursors.Hand;
            btnExport.Location = new Point(800, 55);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 29);
            btnExport.TabIndex = 8;
            btnExport.Text = "📄 Xuất file";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // 
            // MauSacControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            Controls.Add(btnExport);
            Controls.Add(btnImport);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtSearch);
            Controls.Add(dgvMauSac);
            Name = "MauSacControl";
            Size = new Size(926, 512);
            ((System.ComponentModel.ISupportInitialize)dgvMauSac).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMauSac;
        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnImport;
        private Button btnExport;
    }
}
