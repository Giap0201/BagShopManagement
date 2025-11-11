namespace BagShopManagement.Views.Common
{
    partial class QuanLiBanHang
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
            components = new System.ComponentModel.Container();
            headerControl1 = new BagShopManagement.Views.Controls.HeaderControl();
            sideBarControl1 = new BagShopManagement.Views.Controls.SideBarControl();
            errorProvider1 = new ErrorProvider(components);
            hoaDonNhapControl2 = new BagShopManagement.Views.Dev6.HoaDonNhapControl();
            panelMain = new Panel();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // headerControl1
            // 
            headerControl1.BackColor = SystemColors.ControlLight;
            headerControl1.Dock = DockStyle.Top;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1321, 76);
            headerControl1.TabIndex = 0;
            // 
            // sideBarControl1
            // 
            sideBarControl1.Dock = DockStyle.Left;
            sideBarControl1.Location = new Point(0, 76);
            sideBarControl1.Name = "sideBarControl1";
            sideBarControl1.Size = new Size(336, 741);
            sideBarControl1.TabIndex = 1;
            sideBarControl1.Load += sideBarControl1_Load;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // hoaDonNhapControl2
            // 
            hoaDonNhapControl2.Dock = DockStyle.Fill;
            hoaDonNhapControl2.Location = new Point(336, 76);
            hoaDonNhapControl2.Name = "hoaDonNhapControl2";
            hoaDonNhapControl2.Size = new Size(985, 741);
            hoaDonNhapControl2.TabIndex = 2;
            hoaDonNhapControl2.Load += hoaDonNhapControl2_Load;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(336, 76);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(985, 741);
            panelMain.TabIndex = 3;
            panelMain.Paint += panelMain_Paint;
            // 
            // QuanLiBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1321, 817);
            Controls.Add(panelMain);
            Controls.Add(hoaDonNhapControl2);
            Controls.Add(sideBarControl1);
            Controls.Add(headerControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "QuanLiBanHang";
            Text = "QuanLiBanHang";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Controls.HeaderControl headerControl1;
        private Controls.SideBarControl sideBarControl1;
        private Dev6.HoaDonNhapControl hoaDonNhapControl1;
        private ErrorProvider errorProvider1;
        private Panel panelMain;
        private Dev6.HoaDonNhapControl hoaDonNhapControl2;
    }
}