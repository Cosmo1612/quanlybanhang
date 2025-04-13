namespace Client
{
    partial class frmPhieuThu
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
            panel1 = new Panel();
            btnTaoPhieu = new Button();
            txtSTT = new TextBox();
            txtNDT = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label8 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnTaoPhieu);
            panel1.Controls.Add(txtSTT);
            panel1.Controls.Add(txtNDT);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // btnTaoPhieu
            // 
            btnTaoPhieu.Location = new Point(400, 239);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.Size = new Size(94, 29);
            btnTaoPhieu.TabIndex = 4;
            btnTaoPhieu.Text = "Tạo phiếu";
            btnTaoPhieu.UseVisualStyleBackColor = true;
            btnTaoPhieu.Click += btnTaoPhieu_Click;
            // 
            // txtSTT
            // 
            txtSTT.Location = new Point(366, 166);
            txtSTT.Name = "txtSTT";
            txtSTT.Size = new Size(163, 27);
            txtSTT.TabIndex = 3;
            // 
            // txtNDT
            // 
            txtNDT.Location = new Point(366, 88);
            txtNDT.Name = "txtNDT";
            txtNDT.Size = new Size(163, 27);
            txtNDT.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(242, 169);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 1;
            label2.Text = "Số tiền thu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(242, 91);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 0;
            label1.Text = "Nội dung thu";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("StarsStripes", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(366, 9);
            label8.Name = "label8";
            label8.Size = new Size(108, 30);
            label8.TabIndex = 22;
            label8.Text = "Phiếu thu";
            // 
            // frmPhieuThu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "frmPhieuThu";
            Text = "frmPhieuThu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnTaoPhieu;
        private TextBox txtSTT;
        private TextBox txtNDT;
        private Label label2;
        private Label label1;
        private Label label8;
    }
}