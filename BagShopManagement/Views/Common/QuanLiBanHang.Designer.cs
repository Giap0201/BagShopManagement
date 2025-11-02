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
            headerControl1 = new BagShopManagement.Views.Controls.HeaderControl();
            sideBarControl1 = new BagShopManagement.Views.Controls.SideBarControl();
            pnlMainContent = new Panel();
            
            SuspendLayout();
            // 
            // headerControl1
            // 
            headerControl1.BackColor = SystemColors.ControlLight;
            headerControl1.Dock = DockStyle.Top;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1360, 76);
            headerControl1.TabIndex = 0;
            // 
            // sideBarControl1
            // 
            sideBarControl1.Dock = DockStyle.Left;
            sideBarControl1.Location = new Point(0, 76);
            sideBarControl1.Name = "sideBarControl1";
            sideBarControl1.Size = new Size(336, 773);
            sideBarControl1.TabIndex = 1;
            sideBarControl1.Load += sideBarControl1_Load;
            sideBarControl1.NavigationButtonClicked += SideBarControl1_NavigationButtonClicked;
            // 
            // pnlMainContent
            // 
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(336, 76);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1024, 773);
            pnlMainContent.TabIndex = 2;
            // 
            // QuanLiBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 849);
            Controls.Add(pnlMainContent);
            Controls.Add(sideBarControl1);
            Controls.Add(headerControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "QuanLiBanHang";
            Text = "QuanLiBanHang";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Controls.HeaderControl headerControl1;
        private Controls.SideBarControl sideBarControl1;
        private Panel pnlMainContent;
    }
}