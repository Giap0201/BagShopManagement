namespace BagShopManagement.Views.Common
{
    partial class QuanLiBanHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerControl1 = new BagShopManagement.Views.Controls.HeaderControl();
            sideBarControl1 = new BagShopManagement.Views.Controls.SideBarControl();
            panelContent = new Panel();
            mainPanel = new Panel();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl1
            // 
            headerControl1.BackColor = SystemColors.ControlLight;
            headerControl1.Dock = DockStyle.Top;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Margin = new Padding(13, 12, 13, 12);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(2605, 156);
            headerControl1.TabIndex = 0;
            // 
            // sideBarControl1
            // 
            sideBarControl1.Dock = DockStyle.Left;
            sideBarControl1.Location = new Point(0, 156);
            sideBarControl1.Margin = new Padding(13, 12, 13, 12);
            sideBarControl1.Name = "sideBarControl1";
            sideBarControl1.Size = new Size(714, 1271);
            sideBarControl1.TabIndex = 1;
            sideBarControl1.Load += sideBarControl1_Load;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(mainPanel);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(714, 156);
            panelContent.Margin = new Padding(6);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1891, 1271);
            panelContent.TabIndex = 2;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1891, 1271);
            mainPanel.TabIndex = 0;
            // 
            // QuanLiBanHang
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2605, 1427);
            Controls.Add(panelContent);
            Controls.Add(sideBarControl1);
            Controls.Add(headerControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6);
            Name = "QuanLiBanHang";
            Text = "Quản lý bán hàng - Bag Shop Management";
            WindowState = FormWindowState.Maximized;
            Load += QuanLiBanHang_Load;
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        private BagShopManagement.Views.Controls.HeaderControl headerControl1;
        private BagShopManagement.Views.Controls.SideBarControl sideBarControl1;
        private System.Windows.Forms.Panel panelContent;
        private Panel mainPanel;
    }
}
