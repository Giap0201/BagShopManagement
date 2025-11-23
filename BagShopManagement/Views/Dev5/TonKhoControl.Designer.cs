namespace BagShopManagement.Views.Dev5
{
    partial class TonKhoControl
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlMain = new Panel();
            tlpLayout = new TableLayoutPanel();
            dgvTonKho = new DataGridView();
            pnlSearch = new Panel();
            txtTimKiem = new TextBox();
            label1 = new Label();
            btnLamMoi = new Button();
            flpActions = new FlowLayoutPanel();
            btnXemLichSu = new Button();
            btnDieuChinh = new Button();
            btnXuatExcel = new Button();
            pnlMain.SuspendLayout();
            tlpLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTonKho).BeginInit();
            pnlSearch.SuspendLayout();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(tlpLayout);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1247, 556);
            pnlMain.TabIndex = 0;
            // 
            // tlpLayout
            // 
            tlpLayout.ColumnCount = 2;
            tlpLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.6736145F));
            tlpLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.3263836F));
            tlpLayout.Controls.Add(dgvTonKho, 0, 1);
            tlpLayout.Controls.Add(pnlSearch, 0, 0);
            tlpLayout.Controls.Add(flpActions, 1, 0);
            tlpLayout.Dock = DockStyle.Fill;
            tlpLayout.Location = new Point(0, 0);
            tlpLayout.Name = "tlpLayout";
            tlpLayout.RowCount = 2;
            tlpLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.230216F));
            tlpLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 87.76978F));
            tlpLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpLayout.Size = new Size(1247, 556);
            tlpLayout.TabIndex = 0;
            // 
            // dgvTonKho
            // 
            dgvTonKho.AllowUserToAddRows = false;
            dgvTonKho.AllowUserToDeleteRows = false;
            dgvTonKho.AllowUserToResizeColumns = false;
            dgvTonKho.AllowUserToResizeRows = false;
            dgvTonKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTonKho.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvTonKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvTonKho.ColumnHeadersHeight = 29;
            dgvTonKho.Cursor = Cursors.Hand;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(54, 54, 54);
            dataGridViewCellStyle5.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvTonKho.DefaultCellStyle = dataGridViewCellStyle5;
            dgvTonKho.Dock = DockStyle.Fill;
            dgvTonKho.EnableHeadersVisualStyles = false;
            dgvTonKho.GridColor = Color.LightGray;
            dgvTonKho.Location = new Point(3, 71);
            dgvTonKho.MultiSelect = false;
            dgvTonKho.Name = "dgvTonKho";
            dgvTonKho.ReadOnly = true;
            dgvTonKho.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.DodgerBlue;
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvTonKho.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvTonKho.RowHeadersVisible = false;
            dgvTonKho.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dgvTonKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTonKho.Size = new Size(1000, 482);
            dgvTonKho.TabIndex = 16;
            dgvTonKho.CellFormatting += dgvTonKho_CellFormatting;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(txtTimKiem);
            pnlSearch.Controls.Add(label1);
            pnlSearch.Controls.Add(btnLamMoi);
            pnlSearch.Cursor = Cursors.Hand;
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.ForeColor = Color.White;
            pnlSearch.Location = new Point(3, 3);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1000, 62);
            pnlSearch.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Cursor = Cursors.IBeam;
            txtTimKiem.Location = new Point(163, 28);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên sản phẩm...";
            txtTimKiem.Size = new Size(473, 27);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(45, 28);
            label1.Name = "label1";
            label1.Size = new Size(84, 23);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm:";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLamMoi.BackColor = SystemColors.HotTrack;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(538, 61);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(98, 45);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // flpActions
            // 
            flpActions.BackColor = SystemColors.Control;
            flpActions.Controls.Add(btnXemLichSu);
            flpActions.Controls.Add(btnDieuChinh);
            flpActions.Controls.Add(btnXuatExcel);
            flpActions.Dock = DockStyle.Fill;
            flpActions.FlowDirection = FlowDirection.BottomUp;
            flpActions.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            flpActions.Location = new Point(1009, 3);
            flpActions.Name = "flpActions";
            flpActions.Padding = new Padding(5, 50, 5, 5);
            tlpLayout.SetRowSpan(flpActions, 2);
            flpActions.Size = new Size(235, 550);
            flpActions.TabIndex = 2;
            flpActions.WrapContents = false;
            // 
            // btnXemLichSu
            // 
            btnXemLichSu.BackColor = Color.Gray;
            btnXemLichSu.Cursor = Cursors.Hand;
            btnXemLichSu.FlatStyle = FlatStyle.Flat;
            btnXemLichSu.ForeColor = Color.White;
            btnXemLichSu.Location = new Point(8, 437);
            btnXemLichSu.Name = "btnXemLichSu";
            btnXemLichSu.Size = new Size(213, 55);
            btnXemLichSu.TabIndex = 1;
            btnXemLichSu.Text = "Xem Lịch sử Thay đổi";
            btnXemLichSu.UseVisualStyleBackColor = false;
            // 
            // btnDieuChinh
            // 
            btnDieuChinh.BackColor = SystemColors.Highlight;
            btnDieuChinh.Cursor = Cursors.Hand;
            btnDieuChinh.FlatStyle = FlatStyle.Flat;
            btnDieuChinh.ForeColor = Color.White;
            btnDieuChinh.Location = new Point(8, 367);
            btnDieuChinh.Name = "btnDieuChinh";
            btnDieuChinh.Size = new Size(213, 64);
            btnDieuChinh.TabIndex = 0;
            btnDieuChinh.Text = "Kiểm kê / Điều chỉnh";
            btnDieuChinh.UseVisualStyleBackColor = false;
            btnDieuChinh.Click += btnDieuChinh_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.FromArgb(51, 51, 51);
            btnXuatExcel.Cursor = Cursors.Hand;
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(8, 307);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(213, 54);
            btnXuatExcel.TabIndex = 2;
            btnXuatExcel.Text = "Xuất ra Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // TonKhoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "TonKhoControl";
            Size = new Size(1247, 556);
            Load += TonKhoControl_Load;
            pnlMain.ResumeLayout(false);
            tlpLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTonKho).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            flpActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private TableLayoutPanel tlpLayout;
        private Panel pnlSearch;
        private TextBox txtTimKiem;
        private Label label1;
        private Button btnLamMoi;
        private FlowLayoutPanel flpActions;
        private Button btnXemLichSu;
        private Button btnDieuChinh;
        private Button btnXuatExcel;
        private DataGridView dgvTonKho;
    }
}
