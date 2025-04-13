using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.Models;
using Client.Models;

namespace Client
{
    public partial class frmPhieuChi : Form
    {
        public frmPhieuChi()
        {
            InitializeComponent();
        }

        private async void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            var phieu = new PhieuChi
            {
                MucDichChi = txtNDC.Text,
                SoTienChi = decimal.Parse(txtSTC.Text)
            };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7230");
                var response = await client.PostAsJsonAsync("api/PhieuChi", phieu);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tạo phiếu chi thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi tạo phiếu chi!");
                }
            }
        }
    }
}
