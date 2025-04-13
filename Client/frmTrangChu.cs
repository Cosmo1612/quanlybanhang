using Client.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu(LoginRequest user)
        {
            InitializeComponent();
            currentUser = user;
            label1.Text = $"Tài khoản: {currentUser.VaiTro}";
            if (currentUser.VaiTro != "Admin")
            {
                btnSanPham.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;

            }
        }
        private LoginRequest currentUser;
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form1());
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmKhachHang());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTaiKhoan());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmStore());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin lg = new frmLogin();
            lg.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBaoCao());
        }

        private void btnDM_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDanhMuc());
        }
    }
}
