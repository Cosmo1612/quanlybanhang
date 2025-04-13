namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            btnThem = new Button();
            dataGridView1 = new DataGridView();
            btnSua = new Button();
            btnXoa = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cbbDM = new ComboBox();
            label4 = new Label();
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            btnChonAnh = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            label8 = new Label();
            label7 = new Label();
            txtGiaNhap = new TextBox();
            label6 = new Label();
            btnBoqua = new Button();
            label9 = new Label();
            txtMoTa = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(138, 56);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(510, 91);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(151, 27);
            txtPrice.TabIndex = 2;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(510, 54);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(151, 27);
            txtQuantity.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(141, 204);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(911, 208);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(328, 204);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(690, 204);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 57);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 8;
            label1.Text = "Tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(417, 57);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 9;
            label2.Text = "Số lượng ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(430, 101);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 10;
            label3.Text = "Giá bán";
            // 
            // cbbDM
            // 
            cbbDM.FormattingEnabled = true;
            cbbDM.Location = new Point(510, 147);
            cbbDM.Name = "cbbDM";
            cbbDM.Size = new Size(151, 28);
            cbbDM.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(414, 147);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 12;
            label4.Text = "Danh mục";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(138, 136);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(87, 152);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 14;
            label5.Text = "Ảnh";
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(280, 148);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(94, 29);
            btnChonAnh.TabIndex = 15;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 242);
            panel1.Name = "panel1";
            panel1.Size = new Size(911, 208);
            panel1.TabIndex = 16;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtMoTa);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtGiaNhap);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(btnBoqua);
            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(cbbDM);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btnChonAnh);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(txtName);
            panel2.Controls.Add(txtPrice);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtQuantity);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(911, 236);
            panel2.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("StarsStripes", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(349, 9);
            label8.Name = "label8";
            label8.Size = new Size(191, 30);
            label8.TabIndex = 20;
            label8.Text = "Quản lý sản phẩm";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(328, 9);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 19;
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Location = new Point(141, 94);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(125, 27);
            txtGiaNhap.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(54, 94);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 17;
            label6.Text = "Giá nhập";
            // 
            // btnBoqua
            // 
            btnBoqua.Location = new Point(510, 204);
            btnBoqua.Name = "btnBoqua";
            btnBoqua.Size = new Size(94, 29);
            btnBoqua.TabIndex = 16;
            btnBoqua.Text = "Bỏ Qua";
            btnBoqua.UseVisualStyleBackColor = true;
            btnBoqua.Click += btnBoqua_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(690, 63);
            label9.Name = "label9";
            label9.Size = new Size(48, 20);
            label9.TabIndex = 21;
            label9.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(744, 55);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(134, 117);
            txtMoTa.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private Button btnThem;
        private DataGridView dataGridView1;
        private Button btnSua;
        private Button btnXoa;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbbDM;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private Label label5;
        private Button btnChonAnh;
        private Panel panel1;
        private Panel panel2;
        private Button btnBoqua;
        private TextBox txtGiaNhap;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtMoTa;
        private Label label9;
    }
}
