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
            sideBarControl = new BagShopManagement.Views.Controls.SideBarControl();
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
            headerControl1.Margin = new Padding(6);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(905, 76);
            headerControl1.TabIndex = 0;
            // 
            // sideBarControl
            // 
            sideBarControl.Dock = DockStyle.Left;
            sideBarControl.Location = new Point(0, 76);
            sideBarControl.Margin = new Padding(6);
            sideBarControl.Name = "sideBarControl";
            sideBarControl.Size = new Size(336, 439);
            sideBarControl.TabIndex = 1;
            sideBarControl.Load += sideBarControl_Load;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(mainPanel);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(336, 76);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(569, 439);
            panelContent.TabIndex = 2;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(1);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(569, 439);
            mainPanel.TabIndex = 0;
            // 
            //pnlMainContent.Dock = DockStyle.Fill;
            //pnlMainContent.Location = new Point(336, 76);
            //pnlMainContent.Name = "pnlMainContent";
            //pnlMainContent.Size = new Size(1024, 773);
            //pnlMainContent.TabIndex = 2;
            // 
            // QuanLiBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 515);
            Controls.Add(panelContent);
            Controls.Add(sideBarControl);
            Controls.Add(headerControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "QuanLiBanHang";
            Text = "Quản lý bán hàng - Bag Shop Management";
            WindowState = FormWindowState.Maximized;
            Load += QuanLiBanHang_Load;
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        private BagShopManagement.Views.Controls.HeaderControl headerControl1;
        private BagShopManagement.Views.Controls.SideBarControl sideBarControl;
        private System.Windows.Forms.Panel panelContent;
        private Panel mainPanel;
    }
}
