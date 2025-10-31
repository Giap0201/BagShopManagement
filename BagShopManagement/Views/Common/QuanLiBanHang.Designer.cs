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
            errorProvider1 = new ErrorProvider(components);
            sideBarControl1 = new BagShopManagement.Views.Controls.SideBarControl();
            headerControl1 = new BagShopManagement.Views.Controls.HeaderControl();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            userControl11 = new BagShopManagement.Views.Dev6.HoaDonNhapControl();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // sideBarControl1
            // 
            sideBarControl1.Dock = DockStyle.Left;
            sideBarControl1.Location = new Point(0, 76);
            sideBarControl1.Name = "sideBarControl1";
            sideBarControl1.Size = new Size(334, 620);
            sideBarControl1.TabIndex = 1;
            sideBarControl1.Load += sideBarControl1_Load;
            // 
            // headerControl1
            // 
            headerControl1.BackColor = SystemColors.ControlLight;
            headerControl1.Dock = DockStyle.Top;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1745, 76);
            headerControl1.TabIndex = 0;
            // 
            // userControl11
            // 
            userControl11.Dock = DockStyle.Fill;
            userControl11.Location = new Point(334, 76);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(1411, 620);
            userControl11.TabIndex = 2;
            // 
            // QuanLiBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1745, 696);
            Controls.Add(userControl11);
            Controls.Add(sideBarControl1);
            Controls.Add(headerControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "QuanLiBanHang";
            Text = "QuanLiBanHang";
            WindowState = FormWindowState.Maximized;
            Load += QuanLiBanHang_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ErrorProvider errorProvider1;
        private Controls.SideBarControl sideBarControl1;
        private Controls.HeaderControl headerControl1;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Dev6.HoaDonNhapControl userControl11;
    }
}