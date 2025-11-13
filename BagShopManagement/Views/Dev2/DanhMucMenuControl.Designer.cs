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
        private Button btnNCC;

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
            btnNCC = new Button();
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
            btnNCC.SetBounds(startX + (w * 2) + (spacingX * 2), startY + h + spacingY, w, h);

            btnLoaiTui.Text = "Loại Túi";
            btnThuongHieu.Text = "Thương Hiệu";
            btnChatLieu.Text = "Chất Liệu";
            btnMauSac.Text = "Màu Sắc";
            btnKichThuoc.Text = "Kích Thước";
            btnNCC.Text = "Nhà Cung Cấp";

            Controls.Add(btnLoaiTui);
            Controls.Add(btnThuongHieu);
            Controls.Add(btnChatLieu);
            Controls.Add(btnMauSac);
            Controls.Add(btnKichThuoc);
            Controls.Add(btnNCC);

            AutoScaleMode = AutoScaleMode.Font;
            Name = "DanhMucMenuControl";
            Size = new Size(800, 380);
            ResumeLayout(false);
        }
    }
}
