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
            sideBarControl = new BagShopManagement.Views.Controls.SideBarControl();
            panelContent = new Panel();
            mainPanel = new Panel();
            ucPanel = new Panel();
            panelContent.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sideBarControl
            // 
            sideBarControl.BackColor = Color.FromArgb(30, 41, 59);
            sideBarControl.Dock = DockStyle.Left;
            sideBarControl.Location = new Point(0, 0);
            sideBarControl.Margin = new Padding(6);
            sideBarControl.Name = "sideBarControl";
            sideBarControl.Size = new Size(351, 841);
            sideBarControl.TabIndex = 1;
            sideBarControl.Load += sideBarControl_Load;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(mainPanel);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(351, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(808, 841);
            panelContent.TabIndex = 2;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(ucPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(1);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(808, 841);
            mainPanel.TabIndex = 0;
            // 
            // ucPanel
            // 
            ucPanel.Dock = DockStyle.Fill;
            ucPanel.Location = new Point(0, 0);
            ucPanel.Name = "ucPanel";
            ucPanel.Size = new Size(808, 841);
            ucPanel.TabIndex = 4;
            // 
            // QuanLiBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1159, 841);
            Controls.Add(panelContent);
            Controls.Add(sideBarControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "QuanLiBanHang";
            Text = "Quản lý bán hàng - Bag Shop Management";
            WindowState = FormWindowState.Maximized;
            Load += QuanLiBanHang_Load;
            panelContent.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
        private BagShopManagement.Views.Controls.SideBarControl sideBarControl;
        private System.Windows.Forms.Panel panelContent;
        private Panel mainPanel;
        private Panel ucPanel;
    }
}
