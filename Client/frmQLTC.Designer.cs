namespace Client
{
    partial class frmQLTC
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
            panel2 = new Panel();
            cbbTC = new ComboBox();
            label8 = new Label();
            btnSua = new Button();
            button1 = new Button();
            txtChiThu = new TextBox();
            txtND = new TextBox();
            btnXoa = new Button();
            label1 = new Label();
            label3 = new Label();
            dgvTC = new DataGridView();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTC).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(cbbTC);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(txtChiThu);
            panel2.Controls.Add(txtND);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(911, 199);
            panel2.TabIndex = 15;
            // 
            // cbbTC
            // 
            cbbTC.FormattingEnabled = true;
            cbbTC.Location = new Point(95, 152);
            cbbTC.Name = "cbbTC";
            cbbTC.Size = new Size(151, 28);
            cbbTC.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("StarsStripes", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(346, 9);
            label8.Name = "label8";
            label8.Size = new Size(166, 30);
            label8.TabIndex = 21;
            label8.Text = "Quản lý thu chi\r\n";
            // 
            // btnSua
            // 
            btnSua.Location = new Point(320, 152);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // button1
            // 
            button1.Location = new Point(511, 152);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 12;
            button1.Text = "Bỏ qua";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtChiThu
            // 
            txtChiThu.Location = new Point(346, 99);
            txtChiThu.Name = "txtChiThu";
            txtChiThu.Size = new Size(177, 27);
            txtChiThu.TabIndex = 6;
            // 
            // txtND
            // 
            txtND.Location = new Point(346, 52);
            txtND.Name = "txtND";
            txtND.Size = new Size(177, 27);
            txtND.TabIndex = 4;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(711, 152);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(208, 59);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 0;
            label1.Text = "Nội dung chi/Thu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(267, 106);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 2;
            label3.Text = "Số tiền";
            // 
            // dgvTC
            // 
            dgvTC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTC.Dock = DockStyle.Fill;
            dgvTC.Location = new Point(0, 199);
            dgvTC.Name = "dgvTC";
            dgvTC.RowHeadersWidth = 51;
            dgvTC.Size = new Size(911, 251);
            dgvTC.TabIndex = 16;
            dgvTC.CellClick += dgvTC_CellClick;
            // 
            // frmQLTC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 450);
            Controls.Add(dgvTC);
            Controls.Add(panel2);
            Name = "frmQLTC";
            Text = "frmQLTC";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTC).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label8;
        private Button btnSua;
        private Button button1;
        private TextBox txtChiThu;
        private Label label2;
        private TextBox txtSDT;
        private TextBox txtDiaChi;
        private TextBox txtND;
        private Button btnXoa;
        private Label label1;
        private Label label3;
        private DataGridView dgvTC;
        private ComboBox cbbTC;
    }
}