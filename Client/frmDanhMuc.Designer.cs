namespace Client
{
    partial class frmDanhMuc
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
            btnThem = new Button();
            btnSua = new Button();
            btnBoqua = new Button();
            btnXoa = new Button();
            txtDM = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label8 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 60);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên danh muc";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(70, 109);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click_1;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(277, 109);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click_1;
            // 
            // btnBoqua
            // 
            btnBoqua.Location = new Point(488, 109);
            btnBoqua.Name = "btnBoqua";
            btnBoqua.Size = new Size(94, 29);
            btnBoqua.TabIndex = 3;
            btnBoqua.Text = "Bỏ qua";
            btnBoqua.UseVisualStyleBackColor = true;
            btnBoqua.Click += btnBoqua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(715, 109);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click_1;
            // 
            // txtDM
            // 
            txtDM.Location = new Point(277, 57);
            txtDM.Name = "txtDM";
            txtDM.Size = new Size(432, 27);
            txtDM.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("StarsStripes", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(369, 9);
            label8.Name = "label8";
            label8.Size = new Size(114, 30);
            label8.TabIndex = 22;
            label8.Text = "Danh Mục";
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(txtDM);
            panel1.Controls.Add(btnBoqua);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnThem);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(911, 141);
            panel1.TabIndex = 23;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 147);
            panel2.Name = "panel2";
            panel2.Size = new Size(911, 303);
            panel2.TabIndex = 24;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(911, 303);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick_1;
            // 
            // frmDanhMuc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmDanhMuc";
            Text = "frmDanhMuc";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnThem;
        private Button btnSua;
        private Button btnBoqua;
        private Button btnXoa;
        private TextBox txtDM;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label8;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridView1;
    }
}