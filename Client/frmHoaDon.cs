using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Models;
using Newtonsoft.Json;

namespace Client
{
    public partial class frmHoaDon : Form
    {
        private DateTime ngayDuocChon;
        private readonly HttpClient _httpClient;
        public frmHoaDon(DateTime ngay)
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            ngayDuocChon = ngay;
            LoadHoaDonTheoNgay();
        }

        private async void LoadHoaDonTheoNgay()
        {
            try
            {
                string url = $"https://localhost:7230/api/HoaDon/ngay/{ngayDuocChon:yyyy-MM-dd}";
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var hoaDons = await response.Content.ReadFromJsonAsync<List<HoaDon>>();
                    dataGridView1.DataSource = hoaDons;
                }
                else
                {
                    MessageBox.Show("Không thể tải dữ liệu hóa đơn theo ngày.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maHD = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaHD"].Value);
                var cthdForm = new frmCTHD(maHD);
                cthdForm.ShowDialog();

                LoadHoaDonTheoNgay();
            }
        }

        private async void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = dataGridView1.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hitTest.RowIndex].Selected = true;

                    var maHD = (int)dataGridView1.Rows[hitTest.RowIndex].Cells["MaHD"].Value;

                    var result = MessageBox.Show("Bạn có muốn xóa hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        await XoaHoaDonVaChiTiet(maHD);
                    }
                }
            }
        }

        private async Task XoaHoaDonVaChiTiet(int maHD)
        {
            try
            {
                // Xóa Chi Tiết Hóa Đơn trước
                var responseCTHD = await _httpClient.DeleteAsync($"https://localhost:7230/api/ChiTietHoaDon/xoatheohd/{maHD}");

                if (!responseCTHD.IsSuccessStatusCode)
                {
                    MessageBox.Show("Không thể xóa chi tiết hóa đơn.");
                    return;
                }

                // Xóa Hóa Đơn
                var responseHD = await _httpClient.DeleteAsync($"https://localhost:7230/api/HoaDon/{maHD}");

                if (responseHD.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa hóa đơn thành công.");
                    LoadHoaDonTheoNgay(); // Load lại danh sách
                }
                else
                {
                    MessageBox.Show("Không thể xóa hóa đơn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
