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
            pnlMain = new Panel();
            tlpLayout = new TableLayoutPanel();
            pnlSearch = new Panel();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            label1 = new Label();
            dgvTonKho = new DataGridView();
            flpActions = new FlowLayoutPanel();
            btnDieuChinh = new Button();
            btnXemLichSu = new Button();
            btnXuatExcel = new Button();
            pnlMain.SuspendLayout();
            tlpLayout.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTonKho).BeginInit();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(tlpLayout);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1271, 556);
            pnlMain.TabIndex = 0;
            // 
            // tlpLayout
            // 
            tlpLayout.ColumnCount = 2;
            tlpLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.8080254F));
            tlpLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.1919746F));
            tlpLayout.Controls.Add(pnlSearch, 0, 0);
            tlpLayout.Controls.Add(dgvTonKho, 0, 1);
            tlpLayout.Controls.Add(flpActions, 1, 0);
            tlpLayout.Dock = DockStyle.Fill;
            tlpLayout.Location = new Point(0, 0);
            tlpLayout.Name = "tlpLayout";
            tlpLayout.RowCount = 2;
            tlpLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 21.0431652F));
            tlpLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 78.95683F));
            tlpLayout.Size = new Size(1271, 556);
            tlpLayout.TabIndex = 0;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(btnLamMoi);
            pnlSearch.Controls.Add(txtTimKiem);
            pnlSearch.Controls.Add(label1);
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.Location = new Point(3, 3);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(805, 111);
            pnlSearch.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLamMoi.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD93D");
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.Location = new Point(691, 24);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 32);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "↻ Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Location = new Point(140, 21);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên sản phẩm...";
            txtTimKiem.Size = new Size(437, 27);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 28);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm:";
            // 
            // dgvTonKho
            // 
            dgvTonKho.AllowUserToAddRows = false;
            dgvTonKho.AllowUserToDeleteRows = false;
            dgvTonKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTonKho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTonKho.Dock = DockStyle.Fill;
            dgvTonKho.Location = new Point(3, 120);
            dgvTonKho.MultiSelect = false;
            dgvTonKho.Name = "dgvTonKho";
            dgvTonKho.ReadOnly = true;
            dgvTonKho.RowHeadersWidth = 51;
            dgvTonKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTonKho.Size = new Size(805, 433);
            dgvTonKho.TabIndex = 1;
            dgvTonKho.CellFormatting += dgvTonKho_CellFormatting;
            dgvTonKho.SelectionChanged += dgvTonKho_SelectionChanged;
            // 
            // flpActions
            // 
            flpActions.Controls.Add(btnDieuChinh);
            flpActions.Controls.Add(btnXemLichSu);
            flpActions.Controls.Add(btnXuatExcel);
            flpActions.Dock = DockStyle.Fill;
            flpActions.FlowDirection = FlowDirection.TopDown;
            flpActions.Location = new Point(814, 3);
            flpActions.Name = "flpActions";
            flpActions.Padding = new Padding(25);
            tlpLayout.SetRowSpan(flpActions, 2);
            flpActions.Size = new Size(454, 550);
            flpActions.TabIndex = 2;
            flpActions.WrapContents = false;
            // 
            // btnDieuChinh
            // 
            btnDieuChinh.BackColor = System.Drawing.ColorTranslator.FromHtml("#6C63FF");
            btnDieuChinh.FlatStyle = FlatStyle.Flat;
            btnDieuChinh.FlatAppearance.BorderSize = 0;
            btnDieuChinh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDieuChinh.ForeColor = Color.White;
            btnDieuChinh.Cursor = Cursors.Hand;
            btnDieuChinh.Location = new Point(28, 28);
            btnDieuChinh.Name = "btnDieuChinh";
            btnDieuChinh.Size = new Size(200, 45);
            btnDieuChinh.TabIndex = 0;
            btnDieuChinh.Text = "📦 Kiểm kê / Điều chỉnh";
            btnDieuChinh.UseVisualStyleBackColor = false;
            btnDieuChinh.Click += btnDieuChinh_Click;
            // 
            // btnXemLichSu
            // 
            btnXemLichSu.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD93D");
            btnXemLichSu.FlatStyle = FlatStyle.Flat;
            btnXemLichSu.FlatAppearance.BorderSize = 0;
            btnXemLichSu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXemLichSu.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnXemLichSu.Cursor = Cursors.Hand;
            btnXemLichSu.Location = new Point(28, 84);
            btnXemLichSu.Name = "btnXemLichSu";
            btnXemLichSu.Size = new Size(200, 45);
            btnXemLichSu.TabIndex = 1;
            btnXemLichSu.Text = "📜 Xem Lịch sử Thay đổi";
            btnXemLichSu.UseVisualStyleBackColor = false;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = System.Drawing.ColorTranslator.FromHtml("#6BCF7F");
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.FlatAppearance.BorderSize = 0;
            btnXuatExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Cursor = Cursors.Hand;
            btnXuatExcel.Location = new Point(28, 140);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(200, 45);
            btnXuatExcel.TabIndex = 2;
            btnXuatExcel.Text = "📊 Xuất ra Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // TonKhoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            Controls.Add(pnlMain);
            Name = "TonKhoControl";
            Size = new Size(1271, 556);
            Load += TonKhoControl_Load;
            pnlMain.ResumeLayout(false);
            tlpLayout.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTonKho).EndInit();
            flpActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private TableLayoutPanel tlpLayout;
        private Panel pnlSearch;
        private Label label1;
        private TextBox txtTimKiem;
        private Button btnLamMoi;
        private DataGridView dgvTonKho;
        private FlowLayoutPanel flpActions;
        private Button btnDieuChinh;
        private Button btnXemLichSu;
        private Button btnXuatExcel;
    }
}
