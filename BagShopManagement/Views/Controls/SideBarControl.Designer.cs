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
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            btnSanPham = new Button();
            btnDanhMuc = new Button();
            button2 = new Button();
            button1 = new Button();
            menu = new ImageList(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(button10);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(btnSanPham);
            panel1.Controls.Add(btnDanhMuc);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 788);
            panel1.TabIndex = 0;
            // 
            // button10
            // 
            button10.BackColor = SystemColors.Info;
            button10.Location = new Point(-2, 578);
            button10.Name = "button10";
            button10.Size = new Size(330, 57);
            button10.TabIndex = 9;
            button10.Text = "Hệ thống";
            button10.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.Location = new Point(-2, 521);
            button9.Name = "button9";
            button9.Size = new Size(330, 57);
            button9.TabIndex = 8;
            button9.Text = "Tài khoản";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(-2, 464);
            button8.Name = "button8";
            button8.Size = new Size(330, 57);
            button8.TabIndex = 7;
            button8.Text = "Nhà cung cấp";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(-2, 407);
            button7.Name = "button7";
            button7.Size = new Size(330, 57);
            button7.TabIndex = 6;
            button7.Text = "Nhân viên";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(-2, 350);
            button6.Name = "button6";
            button6.Size = new Size(330, 57);
            button6.TabIndex = 5;
            button6.Text = "Khách hàng";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(-2, 293);
            button5.Name = "button5";
            button5.Size = new Size(330, 57);
            button5.TabIndex = 4;
            button5.Text = "Hoá đơn bán";
            button5.UseVisualStyleBackColor = true;
            // 
            // btnSanPham
            // 
            btnSanPham.Location = new Point(-2, 236);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(330, 57);
            btnSanPham.TabIndex = 3;
            btnSanPham.Text = "Sản phẩm";
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnDanhMuc
            // 
            btnDanhMuc.Location = new Point(-2, 179);
            btnDanhMuc.Name = "btnDanhMuc";
            btnDanhMuc.Size = new Size(330, 57);
            btnDanhMuc.TabIndex = 2;
            btnDanhMuc.Text = "Danh mục";
            btnDanhMuc.UseVisualStyleBackColor = true;
            btnDanhMuc.Click += btnDanhMuc_Click;
            // 
            // button2
            // 
            button2.Location = new Point(-2, 122);
            button2.Name = "button2";
            button2.Size = new Size(330, 57);
            button2.TabIndex = 1;
            button2.Text = "Bán hàng";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Info;
            button1.Dock = DockStyle.Top;
            button1.Font = new Font("Segoe Script", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.ImageIndex = 0;
            button1.ImageList = menu;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(331, 80);
            button1.TabIndex = 0;
            button1.Text = "DashBoard";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            Size = new Size(439, 788);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button btnSanPham;
        private Button btnDanhMuc;
        private Button button2;
        private Button button1;
        private Button button10;
        private Button button9;
        private ImageList menu;
    }
}
