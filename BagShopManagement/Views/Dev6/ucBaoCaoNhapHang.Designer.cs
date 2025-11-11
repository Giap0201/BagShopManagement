using System;
using System.Drawing;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev6
{
    partial class ucBaoCaoNhapHang
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnXemBaoCao;
        private DataGridView dgvBaoCao;
        private Label lblTongNhapHang;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTuNgay = new Label();
            lblDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            btnXemBaoCao = new Button();
            dgvBaoCao = new DataGridView();
            lblTongNhapHang = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            SuspendLayout();
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Font = new Font("Segoe UI", 9.5F);
            lblTuNgay.Location = new Point(20, 31);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(68, 21);
            lblTuNgay.TabIndex = 0;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Font = new Font("Segoe UI", 9.5F);
            lblDenNgay.Location = new Point(253, 31);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(79, 21);
            lblDenNgay.TabIndex = 2;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(94, 31);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(130, 27);
            dtpTuNgay.TabIndex = 1;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(362, 27);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(130, 27);
            dtpDenNgay.TabIndex = 3;
            // 
            // btnXemBaoCao
            // 
            btnXemBaoCao.BackColor = Color.FromArgb(0, 120, 215);
            btnXemBaoCao.FlatStyle = FlatStyle.Flat;
            btnXemBaoCao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXemBaoCao.ForeColor = Color.White;
            btnXemBaoCao.Location = new Point(517, 23);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(130, 35);
            btnXemBaoCao.TabIndex = 4;
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = false;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBaoCao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBaoCao.ColumnHeadersHeight = 29;
            dgvBaoCao.Location = new Point(3, 72);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.Size = new Size(860, 330);
            dgvBaoCao.TabIndex = 5;
            // 
            // lblTongNhapHang
            // 
            lblTongNhapHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongNhapHang.ForeColor = Color.DarkRed;
            lblTongNhapHang.Location = new Point(20, 405);
            lblTongNhapHang.Name = "lblTongNhapHang";
            lblTongNhapHang.Size = new Size(860, 25);
            lblTongNhapHang.TabIndex = 6;
            lblTongNhapHang.Text = "Tổng tiền nhập: 0 VNĐ";
            lblTongNhapHang.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ucBaoCaoNhapHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblTuNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(lblDenNgay);
            Controls.Add(dtpDenNgay);
            Controls.Add(btnXemBaoCao);
            Controls.Add(dgvBaoCao);
            Controls.Add(lblTongNhapHang);
            Name = "ucBaoCaoNhapHang";
            Size = new Size(1062, 450);
            Load += ucBaoCaoNhapHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
