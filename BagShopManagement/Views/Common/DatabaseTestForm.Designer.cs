namespace BagShopManagement.Views.Common
{
    partial class DatabaseTestForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnTestConnection;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnTestConnection = new Button();
            SuspendLayout();
            // 
            // btnTestConnection
            // 
            btnTestConnection.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnTestConnection.Location = new Point(100, 80);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(250, 50);
            btnTestConnection.TabIndex = 0;
            btnTestConnection.Text = "Kiểm tra kết nối DB";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // DatabaseTestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 200);
            Controls.Add(btnTestConnection);
            Name = "DatabaseTestForm";
            Text = "Kiểm tra kết nối CSDL";
            ResumeLayout(false);
        }
    }
}
