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
            cboTable = new ComboBox();
            label1 = new Label();
            btnBrowse = new Button();
            btnImport = new Button();
            btnCancel = new Button();
            dgvPreview = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
            SuspendLayout();
            // 
            // cboTable
            // 
            cboTable.FormattingEnabled = true;
            cboTable.Location = new Point(224, 33);
            cboTable.Name = "cboTable";
            cboTable.Size = new Size(151, 28);
            cboTable.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 36);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 1;
            label1.Text = "Bảng cần nhập";
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(79, 100);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
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
            dgvPreview.Location = new Point(220, 103);
            dgvPreview.Name = "dgvPreview";
            dgvPreview.RowHeadersWidth = 51;
            dgvPreview.Size = new Size(554, 316);
            dgvPreview.TabIndex = 5;
            // 
            // ImportDanhMucForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvPreview);
            Controls.Add(btnCancel);
            Controls.Add(btnImport);
            Controls.Add(btnBrowse);
            Controls.Add(label1);
            Controls.Add(cboTable);
            Name = "ImportDanhMucForm";
            Text = "ImportDanhMucForm";
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboTable;
        private Label label1;
        private Button btnBrowse;
        private Button btnImport;
        private Button btnCancel;
        private DataGridView dgvPreview;
    }
}