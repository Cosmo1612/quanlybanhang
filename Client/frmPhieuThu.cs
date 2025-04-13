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

namespace Client
{
    public partial class frmPhieuThu : Form
    {
        public frmPhieuThu()
        {
            InitializeComponent();
        }

        private async void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            string mucDich = txtNDT.Text.Trim();
            if (!decimal.TryParse(txtSTT.Text, out decimal soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ");
                return;
            }

            var phieuThu = new PhieuThu
            {
                MucDichThu = mucDich,
                SoTienThu = soTien
            };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7230"); 
                HttpResponseMessage response = await client.PostAsJsonAsync("api/PhieuThu", phieuThu);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tạo phiếu thu thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tạo thất bại: " + response.ReasonPhrase);
                }
            }
        }
    }
}
