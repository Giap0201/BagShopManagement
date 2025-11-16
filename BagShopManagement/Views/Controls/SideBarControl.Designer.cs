namespace BagShopManagement.Views.Controls
{
    partial class SideBarControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SideBarControl));
            panel1 = new Panel();
            btnBCTK = new Button();
            btnKhuyenMai = new Button();
            btnTonKho = new Button();
            btnHoaDonNhap = new Button();
            btnTaiKhoan = new Button();
            btnNCC = new Button();
            btnNhanVien = new Button();
            btnKhachHang = new Button();
            btnHoaDonBan = new Button();
            btnSanPham = new Button();
            btnDanhMuc = new Button();
            btnBanHang = new Button();
            button1 = new Button();
            menu = new ImageList(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = BagShopManagement.Utils.ThemeColors.Secondary;
            panel1.Controls.Add(btnBCTK);
            panel1.Controls.Add(btnKhuyenMai);
            panel1.Controls.Add(btnTonKho);
            panel1.Controls.Add(btnHoaDonNhap);
            panel1.Controls.Add(btnTaiKhoan);
            panel1.Controls.Add(btnNCC);
            panel1.Controls.Add(btnNhanVien);
            panel1.Controls.Add(btnKhachHang);
            panel1.Controls.Add(btnHoaDonBan);
            panel1.Controls.Add(btnSanPham);
            panel1.Controls.Add(btnDanhMuc);
            panel1.Controls.Add(btnBanHang);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(330, 788);
            panel1.TabIndex = 0;
            // 
            // btnBCTK
            // 
            btnBCTK.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnBCTK.FlatAppearance.BorderSize = 0;
            btnBCTK.FlatStyle = FlatStyle.Flat;
            btnBCTK.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBCTK.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnBCTK.Location = new Point(0, 620);
            btnBCTK.Name = "btnBCTK";
            btnBCTK.Size = new Size(330, 57);
            btnBCTK.TabIndex = 12;
            btnBCTK.Text = "Báo cáo thống kê";
            btnBCTK.UseVisualStyleBackColor = false;
            btnBCTK.Click += btnBCTK_Click;
            // 
            // btnKhuyenMai
            // 
            btnKhuyenMai.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnKhuyenMai.FlatAppearance.BorderSize = 0;
            btnKhuyenMai.FlatStyle = FlatStyle.Flat;
            btnKhuyenMai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKhuyenMai.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnKhuyenMai.Location = new Point(0, 676);
            btnKhuyenMai.Name = "btnKhuyenMai";
            btnKhuyenMai.Size = new Size(330, 57);
            btnKhuyenMai.TabIndex = 11;
            btnKhuyenMai.Text = "Khuyến Mãi";
            btnKhuyenMai.UseVisualStyleBackColor = false;
            btnKhuyenMai.Click += btnKhuyenMai_Click;
            // 
            // btnTonKho
            // 
            btnTonKho.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnTonKho.FlatAppearance.BorderSize = 0;
            btnTonKho.FlatStyle = FlatStyle.Flat;
            btnTonKho.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTonKho.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnTonKho.Location = new Point(-3, 508);
            btnTonKho.Name = "btnTonKho";
            btnTonKho.Size = new Size(330, 57);
            btnTonKho.TabIndex = 9;
            btnTonKho.Text = "Tồn Kho";
            btnTonKho.UseVisualStyleBackColor = false;
            btnTonKho.Click += btnTonKho_Click;
            // 
            // btnHoaDonNhap
            // 
            btnHoaDonNhap.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnHoaDonNhap.FlatAppearance.BorderSize = 0;
            btnHoaDonNhap.FlatStyle = FlatStyle.Flat;
            btnHoaDonNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHoaDonNhap.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnHoaDonNhap.Location = new Point(-3, 565);
            btnHoaDonNhap.Name = "btnHoaDonNhap";
            btnHoaDonNhap.Size = new Size(330, 57);
            btnHoaDonNhap.TabIndex = 10;
            btnHoaDonNhap.Text = "Hoá đơn nhập";
            btnHoaDonNhap.UseVisualStyleBackColor = false;
            btnHoaDonNhap.Click += btnHoaDonNhap_Click;
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnTaiKhoan.FlatAppearance.BorderSize = 0;
            btnTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnTaiKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaiKhoan.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnTaiKhoan.Location = new Point(-3, 456);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Size = new Size(330, 57);
            btnTaiKhoan.TabIndex = 8;
            btnTaiKhoan.Text = "Tài khoản";
            btnTaiKhoan.UseVisualStyleBackColor = false;
            btnTaiKhoan.Click += btnTaiKhoan_Click;
            // 
            // btnNCC
            // 
            btnNCC.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnNCC.FlatAppearance.BorderSize = 0;
            btnNCC.FlatStyle = FlatStyle.Flat;
            btnNCC.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNCC.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnNCC.Location = new Point(-2, 408);
            btnNCC.Name = "btnNCC";
            btnNCC.Size = new Size(330, 57);
            btnNCC.TabIndex = 7;
            btnNCC.Text = "Nhà cung cấp";
            btnNCC.UseVisualStyleBackColor = false;
            btnNCC.Click += btnNCC_Click;
            // 
            // btnNhanVien
            // 
            btnNhanVien.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnNhanVien.FlatAppearance.BorderSize = 0;
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNhanVien.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnNhanVien.Location = new Point(0, 357);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(330, 57);
            btnNhanVien.TabIndex = 6;
            btnNhanVien.Text = "Nhân viên";
            btnNhanVien.UseVisualStyleBackColor = false;
            btnNhanVien.Click += btnNhanVien_Click;
            // 
            // btnKhachHang
            // 
            btnKhachHang.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnKhachHang.FlatAppearance.BorderSize = 0;
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKhachHang.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnKhachHang.Location = new Point(-2, 303);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(330, 57);
            btnKhachHang.TabIndex = 5;
            btnKhachHang.Text = "Khách hàng";
            btnKhachHang.UseVisualStyleBackColor = false;
            btnKhachHang.Click += btnKhachHang_Click;
            // 
            // btnHoaDonBan
            // 
            btnHoaDonBan.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnHoaDonBan.FlatAppearance.BorderSize = 0;
            btnHoaDonBan.FlatStyle = FlatStyle.Flat;
            btnHoaDonBan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHoaDonBan.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnHoaDonBan.Location = new Point(-3, 250);
            btnHoaDonBan.Name = "btnHoaDonBan";
            btnHoaDonBan.Size = new Size(330, 57);
            btnHoaDonBan.TabIndex = 4;
            btnHoaDonBan.Text = "Hoá đơn bán";
            btnHoaDonBan.UseVisualStyleBackColor = false;
            btnHoaDonBan.Click += btnHoaDonBan_Click;
            // 
            // btnSanPham
            // 
            btnSanPham.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatStyle = FlatStyle.Flat;
            btnSanPham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSanPham.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnSanPham.Location = new Point(0, 199);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(330, 57);
            btnSanPham.TabIndex = 3;
            btnSanPham.Text = "Sản phẩm";
            btnSanPham.UseVisualStyleBackColor = false;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnDanhMuc
            // 
            btnDanhMuc.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnDanhMuc.FlatAppearance.BorderSize = 0;
            btnDanhMuc.FlatStyle = FlatStyle.Flat;
            btnDanhMuc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDanhMuc.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnDanhMuc.Location = new Point(0, 143);
            btnDanhMuc.Name = "btnDanhMuc";
            btnDanhMuc.Size = new Size(330, 57);
            btnDanhMuc.TabIndex = 2;
            btnDanhMuc.Text = "Danh mục ";
            btnDanhMuc.UseVisualStyleBackColor = false;
            btnDanhMuc.Click += btnDanhMuc_Click;
            // 
            // btnBanHang
            // 
            btnBanHang.BackColor = BagShopManagement.Utils.ThemeColors.Card;
            btnBanHang.FlatAppearance.BorderSize = 0;
            btnBanHang.FlatStyle = FlatStyle.Flat;
            btnBanHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBanHang.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            btnBanHang.Location = new Point(0, 86);
            btnBanHang.Name = "btnBanHang";
            btnBanHang.Size = new Size(330, 57);
            btnBanHang.TabIndex = 1;
            btnBanHang.Text = "Bán hàng";
            btnBanHang.UseVisualStyleBackColor = false;
            btnBanHang.Click += btnBanHang_Click;
            // 
            // button1
            // 
            button1.BackColor = BagShopManagement.Utils.ThemeColors.Accent;
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = BagShopManagement.Utils.ThemeColors.TextPrimary;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.ImageIndex = 0;
            button1.ImageList = menu;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(330, 80);
            button1.TabIndex = 0;
            button1.Text = "BagShop 🛍️";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            // 
            // menu
            // 
            menu.ColorDepth = ColorDepth.Depth32Bit;
            menu.ImageStream = (ImageListStreamer)resources.GetObject("menu.ImageStream");
            menu.TransparentColor = Color.Transparent;
            menu.Images.SetKeyName(0, "menu.png");
            menu.Images.SetKeyName(1, "menu.png");
            // 
            // SideBarControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "SideBarControl";
            Size = new Size(336, 788);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private ImageList menu;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public Button btnNCC;
        public Button btnNhanVien;
        public Button btnKhachHang;
        public Button btnHoaDonBan;
        public Button btnSanPham;
        public Button btnDanhMuc;
        public Button btnBanHang;
        public Button btnTonKho;
        public Button btnTaiKhoan;
        public Button btnHoaDonNhap;
        public Button btnKhuyenMai;
        public Button btnBCTK;
    }
}
