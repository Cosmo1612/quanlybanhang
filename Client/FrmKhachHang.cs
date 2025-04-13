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
using System.Xml.Linq;
using Client.Models;

namespace Client
{
    public partial class FrmKhachHang : Form
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7230/api/khachhang"; // Cập nhật theo URL server
        public FrmKhachHang()
        {
            InitializeComponent();
            // Khởi tạo HttpClient
            _httpClient = new HttpClient();
            // Nếu chạy trên môi trường thử nghiệm, bỏ qua xác thực SSL (không khuyến nghị cho production)
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            LoadKhachHang();
        }
        private async void LoadKhachHang()
        {
            try
            {
                var khachhang = await _httpClient.GetFromJsonAsync<List<KhachHang>>(BaseUrl);
                dgvKH.DataSource = khachhang;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.");
                return;
            }

            try
            {
                var khachhang = new KhachHang
                {
                    TenKH = txtTenKH.Text,
                    SDT = txtSDT.Text,
                    DiaChi = txtDiaChi.Text,
                };

                var response = await _httpClient.PostAsJsonAsync(BaseUrl, khachhang);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm khách hàng thành công!");
                    LoadKhachHang();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Giả sử bạn chọn 1 dòng trong DataGridView để cập nhật
                if (dgvKH.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn khách hàng cần cập nhật.");
                    return;
                }

                var selectedRow = dgvKH.SelectedRows[0];
                var khachhang = (KhachHang)selectedRow.DataBoundItem;
                // Cập nhật thông tin từ các TextBox
                khachhang.TenKH = txtTenKH.Text;
                khachhang.SDT = txtSDT.Text;
                khachhang.DiaChi = txtDiaChi.Text;

                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{khachhang.MaKH}", khachhang);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadKhachHang();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật Khách.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
        private void ClearTextBoxes()
        {
            txtTenKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKH.Rows[e.RowIndex];
                // Cập nhật các TextBox theo dữ liệu của dòng được chọn

                txtTenKH.Text = row.Cells["TenKH"].Value?.ToString() ?? "";
                txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKH.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn khách hàng cần xóa.");
                    return;
                }

                var selectedRow = dgvKH.SelectedRows[0];
                var khachhang = (KhachHang)selectedRow.DataBoundItem;
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{khachhang.MaKH}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa khách hàng thành công!");
                    LoadKhachHang();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa khách hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void FrmKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
    }
}
