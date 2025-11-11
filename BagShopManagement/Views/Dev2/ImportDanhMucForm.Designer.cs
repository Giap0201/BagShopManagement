namespace BagShopManagement.Views.Dev2
{
    partial class ImportDanhMucForm
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
            cboTableName = new ComboBox();
            label1 = new Label();
            btnChonFile = new Button();
            btnImport = new Button();
            btnCancel = new Button();
            dgvPreview = new DataGridView();
            txtFilePath = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
            SuspendLayout();
            // 
            // cboTableName
            // 
            cboTableName.FormattingEnabled = true;
            cboTableName.Location = new Point(220, 30);
            cboTableName.Name = "cboTableName";
            cboTableName.Size = new Size(151, 28);
            cboTableName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 33);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 1;
            label1.Text = "Bảng cần nhập";
            // 
            // btnChonFile
            // 
            btnChonFile.Location = new Point(71, 72);
            btnChonFile.Name = "btnChonFile";
            btnChonFile.Size = new Size(94, 29);
            btnChonFile.TabIndex = 2;
            btnChonFile.Text = "Browse";
            btnChonFile.UseVisualStyleBackColor = true;
            btnChonFile.Click += btnChonFile_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(80, 157);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(94, 29);
            btnImport.TabIndex = 3;
            btnImport.Text = "Nhập";
            btnImport.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(84, 213);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvPreview
            // 
            dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreview.Location = new Point(220, 122);
            dgvPreview.Name = "dgvPreview";
            dgvPreview.RowHeadersWidth = 51;
            dgvPreview.Size = new Size(554, 316);
            dgvPreview.TabIndex = 5;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(220, 73);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(125, 27);
            txtFilePath.TabIndex = 6;
            // 
            // ImportDanhMucForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtFilePath);
            Controls.Add(dgvPreview);
            Controls.Add(btnCancel);
            Controls.Add(btnImport);
            Controls.Add(btnChonFile);
            Controls.Add(label1);
            Controls.Add(cboTableName);
            Name = "ImportDanhMucForm";
            Text = "ImportDanhMucForm";
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboTableName;
        private Label label1;
        private Button btnChonFile;
        private Button btnImport;
        private Button btnCancel;
        private DataGridView dgvPreview;
        private TextBox txtFilePath;
    }
}