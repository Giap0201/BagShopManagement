namespace BagShopManagement.Views.Dev2
{
    partial class SanPhamEditForm
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
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            numGiaNhap = new NumericUpDown();
            numGiaBan = new NumericUpDown();
            numSoLuong = new NumericUpDown();
            txtMoTa = new TextBox();
            pbAnh = new PictureBox();
            btnChonAnh = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)numGiaNhap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGiaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAnh).BeginInit();
            SuspendLayout();
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(75, 32);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(125, 27);
            txtMaSP.TabIndex = 0;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(75, 76);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(125, 27);
            txtTenSP.TabIndex = 1;
            // 
            // numGiaNhap
            // 
            numGiaNhap.Location = new Point(75, 132);
            numGiaNhap.Name = "numGiaNhap";
            numGiaNhap.Size = new Size(150, 27);
            numGiaNhap.TabIndex = 2;
            // 
            // numGiaBan
            // 
            numGiaBan.Location = new Point(78, 182);
            numGiaBan.Name = "numGiaBan";
            numGiaBan.Size = new Size(150, 27);
            numGiaBan.TabIndex = 3;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(77, 227);
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(150, 27);
            numSoLuong.TabIndex = 4;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(76, 272);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(125, 27);
            txtMoTa.TabIndex = 5;
            // 
            // pbAnh
            // 
            pbAnh.Location = new Point(79, 319);
            pbAnh.Name = "pbAnh";
            pbAnh.Size = new Size(125, 62);
            pbAnh.TabIndex = 6;
            pbAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(77, 405);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(105, 29);
            btnChonAnh.TabIndex = 7;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(233, 405);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(385, 403);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "Huỷ";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // SanPhamEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(btnChonAnh);
            Controls.Add(pbAnh);
            Controls.Add(txtMoTa);
            Controls.Add(numSoLuong);
            Controls.Add(numGiaBan);
            Controls.Add(numGiaNhap);
            Controls.Add(txtTenSP);
            Controls.Add(txtMaSP);
            Name = "SanPhamEditForm";
            Text = "SanPhamEditForm";
            ((System.ComponentModel.ISupportInitialize)numGiaNhap).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private NumericUpDown numGiaNhap;
        private NumericUpDown numGiaBan;
        private NumericUpDown numSoLuong;
        private TextBox txtMoTa;
        private PictureBox pbAnh;
        private Button btnChonAnh;
        private Button btnLuu;
        private Button btnHuy;
    }
}