using Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using client.Models;

namespace Client
{
    public partial class frmBaoCao : Form
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7230/api/hoadon";
        public frmBaoCao()
        {
            _httpClient = new HttpClient();
            // Nếu chạy trên môi trường thử nghiệm, bỏ qua xác thực SSL (không khuyến nghị cho production)
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            InitializeComponent();
            //LoadHoaDon();
            LoadThuChi();
        }
        private async Task LoadTongThu()
        {
            decimal tongThuPhieu = 0;
            decimal tongThuHoaDon = 0;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7230"); // Đổi lại port đúng

                // 1. Lấy tổng tiền từ phiếu thu
                HttpResponseMessage responsePhieu = await client.GetAsync("api/PhieuThu");
                if (responsePhieu.IsSuccessStatusCode)
                {
                    var phieuThus = await responsePhieu.Content.ReadFromJsonAsync<List<PhieuThu>>();
                    tongThuPhieu = phieuThus.Sum(p => p.SoTienThu);
                }

                // 2. Lấy tổng tiền từ hóa đơn
                HttpResponseMessage responseHD = await client.GetAsync("api/HoaDon");
                if (responseHD.IsSuccessStatusCode)
                {
                    var hoaDons = await responseHD.Content.ReadFromJsonAsync<List<HoaDon>>();
                    tongThuHoaDon = hoaDons.Sum(h => h.TongTien);
                }
            }

            decimal tongThu = tongThuPhieu + tongThuHoaDon;
            txtTThu.Text = tongThu.ToString("N0");
        }


        private async Task LoadTongChi()
        {
            decimal tongGiaNhap = 0;
            decimal tongPhieuChi = 0;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7230/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Tổng giá nhập sản phẩm
                HttpResponseMessage responseNhap = await client.GetAsync("api/sanpham/tongchi");
                if (responseNhap.IsSuccessStatusCode)
                {
                    string json = await responseNhap.Content.ReadAsStringAsync();
                    tongGiaNhap = decimal.Parse(json);
                }

                // Tổng phiếu chi
                HttpResponseMessage responsePhieu = await client.GetAsync("api/PhieuChi");
                if (responsePhieu.IsSuccessStatusCode)
                {
                    var danhSachPhieu = await responsePhieu.Content.ReadFromJsonAsync<List<PhieuChi>>();
                    tongPhieuChi = danhSachPhieu.Sum(p => p.SoTienChi);
                }
            }

            decimal tongChi = tongGiaNhap + tongPhieuChi;
            txtTChi.Text = tongChi.ToString("N0") + " VNĐ";
        }




        private async Task KhoiTaoBaoCaoTuDong()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7230"); // thay bằng API của bạn
                HttpResponseMessage response = await client.PostAsync("/api/BaoCaoThongKe/khoitao-bao-cao", null);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Khởi tạo báo cáo thành công.");
                }
                else
                {
                    MessageBox.Show("Lỗi khi tạo báo cáo.");
                }
            }
        }

        private async Task LoadBaoCaoThongKe()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7230"); // thay bằng API của bạn
                HttpResponseMessage response = await client.GetAsync("/api/BaoCaoThongKe");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var baoCaoList = JsonConvert.DeserializeObject<List<BaoCaoThongKe>>(json);

                    dataGridView1.DataSource = baoCaoList;

                }
            }
        }



        private async void frmBaoCao_Load(object sender, EventArgs e)
        {
            await LoadTongThu();
            await LoadTongChi();
            await KhoiTaoBaoCaoTuDong();
            await LoadBaoCaoThongKe();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLTC tc = new frmQLTC();
            tc.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTaoPhieu();
        }
        private void LoadThuChi()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Chọn phiếu muốn tạo");
            comboBox1.Items.Add("Tạo phiếu thu");
            comboBox1.Items.Add("Tạo phiếu chi");

            comboBox1.SelectedIndex = 0;
        }
        private async void LoadTaoPhieu()
        {
            try
            {
                if (comboBox1.SelectedIndex <= 0) return;

                if (comboBox1.SelectedItem?.ToString() == "Tạo phiếu thu")
                {
                    frmPhieuThu form = new frmPhieuThu();
                    form.ShowDialog();
                    await LoadTongThu();
                }
                else if (comboBox1.SelectedItem?.ToString() == "Tạo phiếu chi")
                {
                    frmPhieuChi f = new frmPhieuChi();
                    f.ShowDialog();
                    await LoadTongChi();
                }

                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var cellValue = row.Cells["NgayBC"].Value; // Cột chứa ngày lập trong báo cáo

                if (cellValue != null && DateTime.TryParse(cellValue.ToString(), out DateTime ngayDuocChon))
                {
                    frmHoaDon frm = new frmHoaDon(ngayDuocChon);
                    frm.ShowDialog();

                    await LoadBaoCaoThongKe();
                    await LoadTongThu();
                    await LoadTongChi();
                }
            }
        }
    }

}
