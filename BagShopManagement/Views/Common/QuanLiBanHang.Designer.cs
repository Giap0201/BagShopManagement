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
            headerControl1 = new BagShopManagement.Views.Controls.HeaderControl();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            panel1 = new Panel();
            label1 = new Label();
            sideBarControl = new BagShopManagement.Views.Controls.SideBarControl();
            pnlMainContent = new Panel();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // headerControl1
            // 
            headerControl1.BackColor = SystemColors.ControlLight;
            headerControl1.Dock = DockStyle.Top;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1693, 76);
            headerControl1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 54);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 0;
            label1.Text = "TEST";
            // 
        
            // 
            // sideBarControl
            // 
            sideBarControl.Dock = DockStyle.Left;
            sideBarControl.Location = new Point(0, 76);
            sideBarControl.Name = "sideBarControl";
            sideBarControl.Size = new Size(356, 620);
            sideBarControl.TabIndex = 1;
            // 
            // pnlMainContent
            // 
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(356, 76);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1337, 620);
            pnlMainContent.TabIndex = 2;
            // 
            // QuanLiBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1693, 696);
            Controls.Add(pnlMainContent);
            Controls.Add(sideBarControl);
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
        private Controls.HeaderControl headerControl1;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Dev6.ucHoaDonNhapList ucHoaDonNhapList1;
        private Dev6.ucHoaDonNhapList ucHoaDonNhapList2;
        private Controls.SideBarControl sideBarControl1;
        private Panel panel1;
        private Label label1;
        private Panel pnlMainContent;
        private Controls.SideBarControl sideBarControl;
    }
}