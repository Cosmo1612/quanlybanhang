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
using Client.Models;

namespace Client
{
    public partial class frmCTHD : Form
    {
        private int maHoaDon;
        private readonly HttpClient _httpClient;
        public frmCTHD(int maHD)
        {
            InitializeComponent();
            maHoaDon = maHD;
            _httpClient = new HttpClient();
            LoadChiTietHoaDon();
        }
        private async Task LoadChiTietHoaDon()
        {
            try
            {
                string url = $"https://localhost:7230/api/ChiTietHoaDon/hoadon/{maHoaDon}";
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var chiTietHoaDons = await response.Content.ReadFromJsonAsync<List<ChiTietHoaDonDTO>>();
                    dataGridView1.DataSource = chiTietHoaDons;
                }
                else
                {
                    MessageBox.Show("Không thể tải chi tiết hóa đơn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                var selectedRow = dataGridView1.CurrentRow.DataBoundItem as ChiTietHoaDonDTO;
                if (selectedRow == null) return;

                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa sản phẩm '{selectedRow.TenSP}' khỏi hóa đơn?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    await XoaChiTietVaXuLy(selectedRow.MaCTHD);
                }
            }
        }
        private async Task XoaChiTietVaXuLy(int idChiTiet)
        {
            try
            {
                string url = $"https://localhost:7230/api/ChiTietHoaDon/{idChiTiet}";
                var response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Kiểm tra còn chi tiết không
                    string urlCT = $"https://localhost:7230/api/ChiTietHoaDon/hoadon/{maHoaDon}";
                    var chiTietList = await _httpClient.GetFromJsonAsync<List<ChiTietHoaDonDTO>>(urlCT);

                    if (chiTietList == null || chiTietList.Count == 0)
                    {
                        // Xóa luôn hóa đơn
                        var resXoaHD = await _httpClient.DeleteAsync($"https://localhost:7230/api/HoaDon/{maHoaDon}");
                        if (resXoaHD.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Đã xóa hết chi tiết => Xóa luôn hóa đơn.");
                            this.Close(); // Đóng form
                        }
                    }
                    else
                    {
                        // Cập nhật tổng tiền
                        decimal tongTien = chiTietList.Sum(c => c.ThanhTien);
                        var capNhat = new
                        {
                            MaHD = maHoaDon,
                            TongTien = tongTien
                        };

                        var updateResponse = await _httpClient.PutAsJsonAsync("https://localhost:7230/api/HoaDon/capnhattongtien", capNhat);
                        if (updateResponse.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Đã cập nhật tổng tiền hóa đơn.");
                        }

                        await LoadChiTietHoaDon(); // Load lại
                    }
                }
                else
                {
                    MessageBox.Show("Xóa chi tiết hóa đơn thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }
    }
}
