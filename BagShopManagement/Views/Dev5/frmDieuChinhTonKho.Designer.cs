namespace BagShopManagement.Views.Dev5
{
    partial class frmDieuChinhTonKho
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
            grpThongTinSP = new GroupBox();
            lblTonKhoCu = new Label();
            lblTenSP = new Label();
            label3 = new Label();
            label2 = new Label();
            lblMaSP = new Label();
            label1 = new Label();
            grpThongTinMoi = new GroupBox();
            txtGhiChu = new TextBox();
            label5 = new Label();
            nudSoLuongMoi = new NumericUpDown();
            label4 = new Label();
            btnHuy = new Button();
            btnXacNhan = new Button();
            grpThongTinSP.SuspendLayout();
            grpThongTinMoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongMoi).BeginInit();
            SuspendLayout();
            // 
            // grpThongTinSP
            // 
            grpThongTinSP.Controls.Add(lblTonKhoCu);
            grpThongTinSP.Controls.Add(lblTenSP);
            grpThongTinSP.Controls.Add(label3);
            grpThongTinSP.Controls.Add(label2);
            grpThongTinSP.Controls.Add(lblMaSP);
            grpThongTinSP.Controls.Add(label1);
            grpThongTinSP.Location = new Point(8, 4);
            grpThongTinSP.Name = "grpThongTinSP";
            grpThongTinSP.Size = new Size(320, 338);
            grpThongTinSP.TabIndex = 0;
            grpThongTinSP.TabStop = false;
            grpThongTinSP.Text = "Thông tin sản phẩm";
            // 
            // lblTonKhoCu
            // 
            lblTonKhoCu.AutoSize = true;
            lblTonKhoCu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTonKhoCu.ForeColor = Color.Red;
            lblTonKhoCu.Location = new Point(188, 194);
            lblTonKhoCu.Name = "lblTonKhoCu";
            lblTonKhoCu.Size = new Size(58, 20);
            lblTonKhoCu.TabIndex = 5;
            lblTonKhoCu.Text = "(value)";
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenSP.Location = new Point(188, 144);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(58, 20);
            lblTenSP.TabIndex = 4;
            lblTenSP.Text = "(value)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 194);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 3;
            label3.Text = "Tồn kho hiện tại:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 144);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 2;
            label2.Text = "Tên sản phẩm:";
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaSP.Location = new Point(188, 97);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(58, 20);
            lblMaSP.TabIndex = 1;
            lblMaSP.Text = "(value)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 97);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã sản phẩm:";
            // 
            // grpThongTinMoi
            // 
            grpThongTinMoi.Controls.Add(txtGhiChu);
            grpThongTinMoi.Controls.Add(label5);
            grpThongTinMoi.Controls.Add(nudSoLuongMoi);
            grpThongTinMoi.Controls.Add(label4);
            grpThongTinMoi.Location = new Point(349, 2);
            grpThongTinMoi.Name = "grpThongTinMoi";
            grpThongTinMoi.Size = new Size(450, 340);
            grpThongTinMoi.TabIndex = 1;
            grpThongTinMoi.TabStop = false;
            grpThongTinMoi.Text = "Thông tin điều chỉnh";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(201, 95);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.ScrollBars = ScrollBars.Vertical;
            txtGhiChu.Size = new Size(238, 203);
            txtGhiChu.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 94);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 2;
            label5.Text = "Ghi chú/Lý do:";
            // 
            // nudSoLuongMoi
            // 
            nudSoLuongMoi.Location = new Point(205, 40);
            nudSoLuongMoi.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudSoLuongMoi.Name = "nudSoLuongMoi";
            nudSoLuongMoi.Size = new Size(150, 27);
            nudSoLuongMoi.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 47);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 0;
            label4.Text = "Số lượng thực tế:";
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnHuy.Location = new Point(513, 377);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(104, 46);
            btnHuy.TabIndex = 2;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnXacNhan.Location = new Point(643, 377);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(102, 46);
            btnXacNhan.TabIndex = 3;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // frmDieuChinhTonKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnXacNhan);
            Controls.Add(btnHuy);
            Controls.Add(grpThongTinMoi);
            Controls.Add(grpThongTinSP);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ImeMode = ImeMode.AlphaFull;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDieuChinhTonKho";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Điều chỉnh Tồn kho";
            grpThongTinSP.ResumeLayout(false);
            grpThongTinSP.PerformLayout();
            grpThongTinMoi.ResumeLayout(false);
            grpThongTinMoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongMoi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTinSP;
        private Label label1;
        private Label lblTonKhoCu;
        private Label lblTenSP;
        private Label label3;
        private Label label2;
        private Label lblMaSP;
        private GroupBox grpThongTinMoi;
        private TextBox txtGhiChu;
        private Label label5;
        private NumericUpDown nudSoLuongMoi;
        private Label label4;
        private Button btnHuy;
        private Button btnXacNhan;
    }
}