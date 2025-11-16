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
            SuspendLayout();

            int w = 200;
            int h = 70;
            int spacingX = 40;
            int spacingY = 40;
            int startX = 80;
            int startY = 40;

            // hàng 1
            btnLoaiTui.SetBounds(startX, startY, w, h);
            btnThuongHieu.SetBounds(startX + w + spacingX, startY, w, h);
            btnChatLieu.SetBounds(startX + (w * 2) + (spacingX * 2), startY, w, h);

            // hàng 2
            btnMauSac.SetBounds(startX, startY + h + spacingY, w, h);
            btnKichThuoc.SetBounds(startX + w + spacingX, startY + h + spacingY, w, h);

            btnLoaiTui.Text = "👜 Loại Túi";
            btnLoaiTui.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6B9D");
            btnLoaiTui.ForeColor = Color.White;
            btnLoaiTui.FlatStyle = FlatStyle.Flat;
            btnLoaiTui.FlatAppearance.BorderSize = 0;
            btnLoaiTui.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLoaiTui.Cursor = Cursors.Hand;

            btnThuongHieu.Text = "⭐ Thương Hiệu";
            btnThuongHieu.BackColor = System.Drawing.ColorTranslator.FromHtml("#6C63FF");
            btnThuongHieu.ForeColor = Color.White;
            btnThuongHieu.FlatStyle = FlatStyle.Flat;
            btnThuongHieu.FlatAppearance.BorderSize = 0;
            btnThuongHieu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThuongHieu.Cursor = Cursors.Hand;

            btnChatLieu.Text = "🧵 Chất Liệu";
            btnChatLieu.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFD93D");
            btnChatLieu.ForeColor = System.Drawing.ColorTranslator.FromHtml("#2D3748");
            btnChatLieu.FlatStyle = FlatStyle.Flat;
            btnChatLieu.FlatAppearance.BorderSize = 0;
            btnChatLieu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnChatLieu.Cursor = Cursors.Hand;

            btnMauSac.Text = "🎨 Màu Sắc";
            btnMauSac.BackColor = System.Drawing.ColorTranslator.FromHtml("#6BCF7F");
            btnMauSac.ForeColor = Color.White;
            btnMauSac.FlatStyle = FlatStyle.Flat;
            btnMauSac.FlatAppearance.BorderSize = 0;
            btnMauSac.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMauSac.Cursor = Cursors.Hand;

            btnKichThuoc.Text = "📏 Kích Thước";
            btnKichThuoc.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF5757");
            btnKichThuoc.ForeColor = Color.White;
            btnKichThuoc.FlatStyle = FlatStyle.Flat;
            btnKichThuoc.FlatAppearance.BorderSize = 0;
            btnKichThuoc.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnKichThuoc.Cursor = Cursors.Hand;

            Controls.Add(btnLoaiTui);
            Controls.Add(btnThuongHieu);
            Controls.Add(btnChatLieu);
            Controls.Add(btnMauSac);
            Controls.Add(btnKichThuoc);

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            Name = "DanhMucMenuControl";
            Size = new Size(800, 380);
            ResumeLayout(false);
        }
    }
}
