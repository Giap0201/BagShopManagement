namespace BagShopManagement.Views.Commonnamespace BagShopManagement.Views.Common

{{

    partial class QuanLiBanHang    partial class QuanLiBanHang

{    {

        /// <summary>        /// <summary>

        /// Required designer variable.        /// Required designer variable.

        /// </summary>        /// </summary>

        private System.ComponentModel.IContainer components = null; private System.ComponentModel.IContainer components = null;



    /// <summary>        /// <summary>

    /// Clean up any resources being used.        /// Clean up any resources being used.

    /// </summary>        /// </summary>

    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

    protected override void Dispose(bool disposing)        protected override void Dispose(bool disposing)

    {
        {

            if (disposing && (components != null)) if (disposing && (components != null))

                {
                    {

                        components.Dispose(); components.Dispose();

                    }
                }

            base.Dispose(disposing); base.Dispose(disposing);

        }
    }



    #region Windows Form Designer generated code        #region Windows Form Designer generated code



    /// <summary>        /// <summary>

    /// Required method for Designer support - do not modify        /// Required method for Designer support - do not modify

    /// the contents of this method with the code editor.        /// the contents of this method with the code editor.

    /// </summary>        /// </summary>

    private void InitializeComponent()        private void InitializeComponent()

    {
        {

            components = new System.ComponentModel.IContainer(); components = new System.ComponentModel.Container();

            headerControl1 = new BagShopManagement.Views.Controls.HeaderControl(); errorProvider1 = new ErrorProvider(components);

            sideBarControl1 = new BagShopManagement.Views.Controls.SideBarControl(); headerControl1 = new BagShopManagement.Views.Controls.HeaderControl();

            panelContent = new Panel();<<<<<<< HEAD

            SuspendLayout(); sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();

            //             panel1 = new Panel();

            // headerControl1            label1 = new Label();

            //             sideBarControl = new BagShopManagement.Views.Controls.SideBarControl();

            headerControl1.BackColor = SystemColors.ControlLight; pnlMainContent = new Panel();

            headerControl1.Dock = DockStyle.Top; ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();

            headerControl1.Location = new Point(0, 0);=======

            headerControl1.Margin = new Padding(13, 12, 13, 12); sideBarControl1 = new BagShopManagement.Views.Controls.SideBarControl();

            headerControl1.Name = "headerControl1"; panelContent = new Panel();

            headerControl1.Size = new Size(2605, 156);>>>>>>> ndt - dev4

            headerControl1.TabIndex = 0; SuspendLayout();

            //             // 

            // sideBarControl1            // errorProvider1

            //             // 

            sideBarControl1.Dock = DockStyle.Left; errorProvider1.ContainerControl = this;

            sideBarControl1.Location = new Point(0, 156);            // 

            sideBarControl1.Margin = new Padding(13, 12, 13, 12);            // headerControl1

            sideBarControl1.Name = "sideBarControl1";            // 

            sideBarControl1.Size = new Size(714, 1271); headerControl1.BackColor = SystemColors.ControlLight;

            sideBarControl1.TabIndex = 1; headerControl1.Dock = DockStyle.Top;

            sideBarControl1.Load += sideBarControl1_Load; headerControl1.Location = new Point(0, 0);

            //             headerControl1.Margin = new Padding(13, 12, 13, 12);

            // panelContent            headerControl1.Name = "headerControl1";

            // <<<<<<< HEAD

            panelContent.Dock = DockStyle.Fill; headerControl1.Size = new Size(1693, 76);

            panelContent.Location = new Point(714, 156);=======

            panelContent.Margin = new Padding(6, 6, 6, 6); headerControl1.Size = new Size(2605, 156);

            panelContent.Name = "panelContent";>>>>>>> ndt - dev4

            panelContent.Size = new Size(1891, 1271); headerControl1.TabIndex = 0;

            panelContent.TabIndex = 2;            // 

            //             // panel1

            // QuanLiBanHang            // 

            // <<<<<<< HEAD

            AutoScaleDimensions = new SizeF(17F, 41F); panel1.Location = new Point(0, 0);

            AutoScaleMode = AutoScaleMode.Font; panel1.Name = "panel1";

            ClientSize = new Size(2605, 1427); panel1.Size = new Size(200, 100);

            Controls.Add(panelContent); panel1.TabIndex = 0;

            Controls.Add(sideBarControl1);            // 

            Controls.Add(headerControl1);            // label1

            FormBorderStyle = FormBorderStyle.FixedSingle;            // 

            Margin = new Padding(6, 6, 6, 6); label1.AutoSize = true;

            Name = "QuanLiBanHang"; label1.Location = new Point(181, 54);

            Text = "Quản lý bán hàng - Bag Shop Management"; label1.Name = "label1";

            WindowState = FormWindowState.Maximized; label1.Size = new Size(41, 20);

            Load += QuanLiBanHang_Load; label1.TabIndex = 0;

            ResumeLayout(false); label1.Text = "TEST";

        }            // 



        #endregion            // 

        private Controls.HeaderControl headerControl1;            // sideBarControl

    private Controls.SideBarControl sideBarControl1;            // 

    private Panel panelContent; sideBarControl.Dock = DockStyle.Left;

    }
sideBarControl.Location = new Point(0, 76);

}
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
=======
            sideBarControl1.Dock = DockStyle.Left;
            sideBarControl1.Location = new Point(0, 156);
            sideBarControl1.Margin = new Padding(13, 12, 13, 12);
            sideBarControl1.Name = "sideBarControl1";
            sideBarControl1.Size = new Size(714, 1271);
            sideBarControl1.TabIndex = 1;
            sideBarControl1.Load += sideBarControl1_Load;
>>>>>>> ndt-dev4
// 
// panelContent
// 
panelContent.Dock = DockStyle.Fill;
panelContent.Location = new Point(714, 156);
panelContent.Margin = new Padding(6, 6, 6, 6);
panelContent.Name = "panelContent";
panelContent.Size = new Size(1891, 1271);
panelContent.TabIndex = 2;
// 
// QuanLiBanHang
// 
AutoScaleDimensions = new SizeF(17F, 41F);
AutoScaleMode = AutoScaleMode.Font;
<<<<<<< HEAD
ClientSize = new Size(1693, 696);
Controls.Add(pnlMainContent);
Controls.Add(sideBarControl);
=======
            ClientSize = new Size(2605, 1427);
            Controls.Add(panelContent);
            Controls.Add(sideBarControl1);
>>>>>>> ndt-dev4
Controls.Add(headerControl1);
FormBorderStyle = FormBorderStyle.FixedSingle;
Margin = new Padding(6, 6, 6, 6);
Name = "QuanLiBanHang";
Text = "Quản lý bán hàng - Bag Shop Management";
WindowState = FormWindowState.Maximized;
Load += QuanLiBanHang_Load;
<<<<<<< HEAD
((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
=======
>>>>>>> ndt-dev4
ResumeLayout(false);
        }

        #endregion
        private ErrorProvider errorProvider1;
private Controls.HeaderControl headerControl1;
private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
private Dev6.ucHoaDonNhapList ucHoaDonNhapList1;
private Dev6.ucHoaDonNhapList ucHoaDonNhapList2;
private Controls.SideBarControl sideBarControl1;
<<<<<<< HEAD
private Panel panel1;
private Label label1;
private Panel pnlMainContent;
private Controls.SideBarControl sideBarControl;
=======
        private Panel panelContent;
>>>>>>> ndt-dev4
    }
}