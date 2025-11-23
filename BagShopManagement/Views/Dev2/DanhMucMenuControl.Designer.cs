namespace BagShopManagement.Views.Dev2
{
    partial class DanhMucMenuControl
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnLoaiTui;
        private Button btnThuongHieu;
        private Button btnChatLieu;
        private Button btnMauSac;
        private Button btnKichThuoc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLoaiTui = new Button();
            btnThuongHieu = new Button();
            btnChatLieu = new Button();
            btnMauSac = new Button();
            btnKichThuoc = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnLoaiTui
            // 
            btnLoaiTui.BackColor = SystemColors.Highlight;
            btnLoaiTui.BackgroundImageLayout = ImageLayout.None;
            btnLoaiTui.FlatAppearance.BorderColor = Color.White;
            btnLoaiTui.FlatAppearance.BorderSize = 2;
            btnLoaiTui.FlatStyle = FlatStyle.Flat;
            btnLoaiTui.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLoaiTui.ForeColor = Color.White;
            btnLoaiTui.Location = new Point(13, 133);
            btnLoaiTui.Name = "btnLoaiTui";
            btnLoaiTui.Size = new Size(765, 420);
            btnLoaiTui.TabIndex = 0;
            btnLoaiTui.Text = "Loại Túi";
            btnLoaiTui.UseVisualStyleBackColor = false;
            // 
            // btnThuongHieu
            // 
            btnThuongHieu.BackColor = SystemColors.Highlight;
            btnThuongHieu.FlatAppearance.BorderColor = Color.White;
            btnThuongHieu.FlatAppearance.BorderSize = 2;
            btnThuongHieu.FlatStyle = FlatStyle.Flat;
            btnThuongHieu.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnThuongHieu.ForeColor = Color.White;
            btnThuongHieu.Location = new Point(529, 559);
            btnThuongHieu.Name = "btnThuongHieu";
            btnThuongHieu.Size = new Size(504, 420);
            btnThuongHieu.TabIndex = 1;
            btnThuongHieu.Text = "Thương Hiệu";
            btnThuongHieu.UseVisualStyleBackColor = false;
            // 
            // btnChatLieu
            // 
            btnChatLieu.BackColor = Color.FromArgb(64, 78, 103);
            btnChatLieu.FlatAppearance.BorderColor = Color.White;
            btnChatLieu.FlatAppearance.BorderSize = 2;
            btnChatLieu.FlatStyle = FlatStyle.Flat;
            btnChatLieu.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnChatLieu.ForeColor = Color.White;
            btnChatLieu.Location = new Point(784, 133);
            btnChatLieu.Name = "btnChatLieu";
            btnChatLieu.Size = new Size(765, 420);
            btnChatLieu.TabIndex = 2;
            btnChatLieu.Text = "Chất Liệu";
            btnChatLieu.UseVisualStyleBackColor = false;
            // 
            // btnMauSac
            // 
            btnMauSac.BackColor = Color.FromArgb(64, 78, 103);
            btnMauSac.FlatAppearance.BorderColor = Color.White;
            btnMauSac.FlatAppearance.BorderSize = 2;
            btnMauSac.FlatStyle = FlatStyle.Flat;
            btnMauSac.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnMauSac.ForeColor = Color.White;
            btnMauSac.Location = new Point(13, 559);
            btnMauSac.Name = "btnMauSac";
            btnMauSac.Size = new Size(510, 420);
            btnMauSac.TabIndex = 3;
            btnMauSac.Text = "Màu Sắc";
            btnMauSac.UseVisualStyleBackColor = false;
            // 
            // btnKichThuoc
            // 
            btnKichThuoc.BackColor = SystemColors.Highlight;
            btnKichThuoc.FlatAppearance.BorderColor = Color.White;
            btnKichThuoc.FlatAppearance.BorderSize = 2;
            btnKichThuoc.FlatStyle = FlatStyle.Flat;
            btnKichThuoc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnKichThuoc.ForeColor = Color.White;
            btnKichThuoc.Location = new Point(1039, 559);
            btnKichThuoc.Name = "btnKichThuoc";
            btnKichThuoc.Size = new Size(510, 420);
            btnKichThuoc.TabIndex = 4;
            btnKichThuoc.Text = "Kích Thước";
            btnKichThuoc.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(655, 46);
            label1.Name = "label1";
            label1.Size = new Size(244, 38);
            label1.TabIndex = 5;
            label1.Text = "LOẠI DANH MỤC";
            // 
            // DanhMucMenuControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(btnLoaiTui);
            Controls.Add(btnThuongHieu);
            Controls.Add(btnChatLieu);
            Controls.Add(btnMauSac);
            Controls.Add(btnKichThuoc);
            Name = "DanhMucMenuControl";
            Size = new Size(1565, 991);
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
    }
}
