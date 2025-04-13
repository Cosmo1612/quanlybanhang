namespace Client
{
    partial class frmBaoCao
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
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            comboBox1 = new ComboBox();
            button1 = new Button();
            label8 = new Label();
            txtTThu = new TextBox();
            txtTChi = new TextBox();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 84);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 1;
            label2.Text = "Tổng chi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 124);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 2;
            label3.Text = "Tổng thu";
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtTThu);
            panel1.Controls.Add(txtTChi);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(911, 149);
            panel1.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(477, 98);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 23;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(661, 98);
            button1.Name = "button1";
            button1.Size = new Size(160, 29);
            button1.TabIndex = 22;
            button1.Text = "Quản lý phiếu thu chi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("StarsStripes", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(444, 9);
            label8.Name = "label8";
            label8.Size = new Size(93, 30);
            label8.TabIndex = 21;
            label8.Text = "Báo cáo";
            // 
            // txtTThu
            // 
            txtTThu.Location = new Point(166, 117);
            txtTThu.Name = "txtTThu";
            txtTThu.ReadOnly = true;
            txtTThu.Size = new Size(125, 27);
            txtTThu.TabIndex = 7;
            // 
            // txtTChi
            // 
            txtTChi.Location = new Point(166, 77);
            txtTChi.Name = "txtTChi";
            txtTChi.ReadOnly = true;
            txtTChi.Size = new Size(125, 27);
            txtTChi.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 155);
            panel2.Name = "panel2";
            panel2.Size = new Size(911, 295);
            panel2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(911, 295);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // frmBaoCao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmBaoCao";
            Text = "frmBaoCao";
            Load += frmBaoCao_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Label label3;
        private Panel panel1;
        private TextBox txtTThu;
        private TextBox txtTChi;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Label label8;
        private Button button1;
        private ComboBox comboBox1;
    }
}