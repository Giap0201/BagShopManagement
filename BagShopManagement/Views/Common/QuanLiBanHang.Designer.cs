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
            components = new System.ComponentModel.Container();
            headerControl1 = new BagShopManagement.Views.Controls.HeaderControl();
            sideBarControl1 = new BagShopManagement.Views.Controls.SideBarControl();
            panelContent = new System.Windows.Forms.Panel();
            SuspendLayout();
            // headerControl1
            headerControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            headerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            headerControl1.Location = new System.Drawing.Point(0, 0);
            headerControl1.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new System.Drawing.Size(2605, 156);
            headerControl1.TabIndex = 0;
            // sideBarControl1
            sideBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            sideBarControl1.Location = new System.Drawing.Point(0, 156);
            sideBarControl1.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            sideBarControl1.Name = "sideBarControl1";
            sideBarControl1.Size = new System.Drawing.Size(714, 1271);
            sideBarControl1.TabIndex = 1;
            sideBarControl1.Load += sideBarControl1_Load;
            // panelContent
            panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContent.Location = new System.Drawing.Point(714, 156);
            panelContent.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            panelContent.Name = "panelContent";
            panelContent.Size = new System.Drawing.Size(1891, 1271);
            panelContent.TabIndex = 2;
            // QuanLiBanHang
            AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2605, 1427);
            Controls.Add(panelContent);
            Controls.Add(sideBarControl1);
            Controls.Add(headerControl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            Name = "QuanLiBanHang";
            Text = "Quản lý bán hàng - Bag Shop Management";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += QuanLiBanHang_Load;
            ResumeLayout(false);
        }

        private BagShopManagement.Views.Controls.HeaderControl headerControl1;
        private BagShopManagement.Views.Controls.SideBarControl sideBarControl1;
        private System.Windows.Forms.Panel panelContent;
    }
}
