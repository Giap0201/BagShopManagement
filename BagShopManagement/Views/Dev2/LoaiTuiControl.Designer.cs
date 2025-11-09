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
            dgvLoaiTui = new DataGridView();
            txtSearch = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnRefresh = new Button();
            btnTim = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiTui).BeginInit();
            SuspendLayout();
            // 
            // dgvLoaiTui
            // 
            dgvLoaiTui.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoaiTui.Location = new Point(27, 126);
            dgvLoaiTui.Name = "dgvLoaiTui";
            dgvLoaiTui.RowHeadersWidth = 51;
            dgvLoaiTui.Size = new Size(867, 362);
            dgvLoaiTui.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(27, 57);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(260, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(432, 55);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(553, 55);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(679, 55);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(800, 55);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(318, 55);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 29);
            btnTim.TabIndex = 6;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            // 
            // LoaiTuiControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnTim);
            Controls.Add(btnRefresh);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtSearch);
            Controls.Add(dgvLoaiTui);
            Name = "LoaiTuiControl";
            Size = new Size(926, 512);
            ((System.ComponentModel.ISupportInitialize)dgvLoaiTui).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLoaiTui;
        private TextBox txtSearch;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnRefresh;
        private Button btnTim;
    }
}
