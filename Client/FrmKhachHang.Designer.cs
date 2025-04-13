namespace Client
{
    partial class FrmKhachHang
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
            txtTenKH = new TextBox();
            txtSDT = new TextBox();
            txtDiaChi = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            dgvKH = new DataGridView();
            button1 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvKH).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 55);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên Khách Hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(483, 59);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 1;
            label2.Text = "Số Điện Thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(135, 99);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 2;
            label3.Text = "Địa Chỉ";
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(224, 56);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(177, 27);
            txtTenKH.TabIndex = 4;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(602, 52);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(194, 27);
            txtSDT.TabIndex = 5;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(224, 96);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(572, 27);
            txtDiaChi.TabIndex = 6;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(125, 152);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
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
            // dgvKH
            // 
            dgvKH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKH.Dock = DockStyle.Fill;
            dgvKH.Location = new Point(0, 0);
            dgvKH.Name = "dgvKH";
            dgvKH.RowHeadersWidth = 51;
            dgvKH.Size = new Size(911, 245);
            dgvKH.TabIndex = 11;
            dgvKH.CellClick += dgvKH_CellClick;
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
            // panel1
            // 
            panel1.Controls.Add(dgvKH);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 205);
            panel1.Name = "panel1";
            panel1.Size = new Size(911, 245);
            panel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Controls.Add(label8);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtSDT);
            panel2.Controls.Add(txtDiaChi);
            panel2.Controls.Add(txtTenKH);
            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(911, 199);
            panel2.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("StarsStripes", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(346, 9);
            label8.Name = "label8";
            label8.Size = new Size(210, 30);
            label8.TabIndex = 21;
            label8.Text = "Quản lý khách hàng";
            // 
            // FrmKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmKhachHang";
            FormClosed += FrmKhachHang_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dgvKH).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTenKH;
        private TextBox txtSDT;
        private TextBox txtDiaChi;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private DataGridView dgvKH;
        private Button button1;
        private Panel panel1;
        private Panel panel2;
        private Label label8;
    }
}