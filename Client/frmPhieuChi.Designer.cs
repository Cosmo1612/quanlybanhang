namespace Client
{
    partial class frmPhieuChi
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
            txtSTC = new TextBox();
            txtNDC = new TextBox();
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
            panel1.Controls.Add(txtSTC);
            panel1.Controls.Add(txtNDC);
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
            btnTaoPhieu.Location = new Point(415, 286);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.Size = new Size(94, 29);
            btnTaoPhieu.TabIndex = 9;
            btnTaoPhieu.Text = "Tạo phiếu";
            btnTaoPhieu.UseVisualStyleBackColor = true;
            btnTaoPhieu.Click += btnTaoPhieu_Click;
            // 
            // txtSTC
            // 
            txtSTC.Location = new Point(381, 213);
            txtSTC.Name = "txtSTC";
            txtSTC.Size = new Size(163, 27);
            txtSTC.TabIndex = 8;
            // 
            // txtNDC
            // 
            txtNDC.Location = new Point(381, 135);
            txtNDC.Name = "txtNDC";
            txtNDC.Size = new Size(163, 27);
            txtNDC.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(257, 216);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 6;
            label2.Text = "Số tiền chi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(257, 138);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 5;
            label1.Text = "Nội dung chi";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("StarsStripes", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(340, 9);
            label8.Name = "label8";
            label8.Size = new Size(105, 30);
            label8.TabIndex = 22;
            label8.Text = "Phiếu chi";
            // 
            // frmPhieuChi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "frmPhieuChi";
            Text = "frmPhieuChi";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnTaoPhieu;
        private TextBox txtSTC;
        private TextBox txtNDC;
        private Label label2;
        private Label label1;
        private Label label8;
    }
}