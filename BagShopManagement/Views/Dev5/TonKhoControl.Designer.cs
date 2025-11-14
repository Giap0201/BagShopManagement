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
            btnLamMoi.Location = new Point(691, 24);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
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
            btnDieuChinh.Location = new Point(28, 28);
            btnDieuChinh.Name = "btnDieuChinh";
            btnDieuChinh.Size = new Size(170, 40);
            btnDieuChinh.TabIndex = 0;
            btnDieuChinh.Text = "Kiểm kê / Điều chỉnh";
            btnDieuChinh.UseVisualStyleBackColor = true;
            btnDieuChinh.Click += btnDieuChinh_Click;
            // 
            // btnXemLichSu
            // 
            btnXemLichSu.Location = new Point(28, 74);
            btnXemLichSu.Name = "btnXemLichSu";
            btnXemLichSu.Size = new Size(170, 40);
            btnXemLichSu.TabIndex = 1;
            btnXemLichSu.Text = "Xem Lịch sử Thay đổi";
            btnXemLichSu.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(28, 120);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(170, 40);
            btnXuatExcel.TabIndex = 2;
            btnXuatExcel.Text = "Xuất ra Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // TonKhoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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
