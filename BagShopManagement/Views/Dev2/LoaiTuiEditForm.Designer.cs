namespace BagShopManagement.Views.Dev2
{
    partial class LoaiTuiEditForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtMa = new TextBox();
            txtTen = new TextBox();
            txtMoTa = new TextBox();
            btnSave = new Button();
            brnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 79);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã loại túi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(123, 128);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên loại túi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 188);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 2;
            label3.Text = "Mô tả";
            // 
            // txtMa
            // 
            txtMa.Location = new Point(234, 84);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(125, 27);
            txtMa.TabIndex = 3;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(232, 127);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(125, 27);
            txtTen.TabIndex = 4;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(233, 189);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(125, 27);
            txtMoTa.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(126, 260);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // brnCancel
            // 
            brnCancel.Location = new Point(280, 264);
            brnCancel.Name = "brnCancel";
            brnCancel.Size = new Size(94, 29);
            brnCancel.TabIndex = 7;
            brnCancel.Text = "Huỷ";
            brnCancel.UseVisualStyleBackColor = true;
            // 
            // LoaiTuiEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(brnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtMoTa);
            Controls.Add(txtTen);
            Controls.Add(txtMa);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoaiTuiEditForm";
            Text = "LoaiTuiEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtMa;
        private TextBox txtTen;
        private TextBox txtMoTa;
        private Button btnSave;
        private Button brnCancel;
    }
}