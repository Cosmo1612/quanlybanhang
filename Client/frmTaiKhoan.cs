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

namespace Client
{
    public partial class frmTaiKhoan : Form
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7230/api/TaiKhoan";
        public frmTaiKhoan()
        {
            _httpClient = new HttpClient();
            // Nếu chạy trên môi trường thử nghiệm, bỏ qua xác thực SSL (không khuyến nghị cho production)
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            InitializeComponent();
            LoadTaiKhoan();
            LoadVaiTro();
        }
        private async void LoadTaiKhoan()
        {
            try
            {
                var TaiKhoan = await _httpClient.GetFromJsonAsync<List<LoginRequest>>(BaseUrl);
                dataGridView1.DataSource = TaiKhoan;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        private void LoadVaiTro()
        {
            ccbRole.Items.Add("Admin");
            ccbRole.Items.Add("NhanVien");
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var taikhoan = new LoginRequest
                {
                    TenDangNhap = txtUser.Text,
                    MatKhau = txtPass.Text,
                    VaiTro = ccbRole.SelectedItem?.ToString()
                };

                var response = await _httpClient.PostAsJsonAsync(BaseUrl, taikhoan);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm tài khoản thành công!");
                    LoadTaiKhoan();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm tài khoản.");
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
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn khách hàng cần cập nhật.");
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                var taikhoan = (LoginRequest)selectedRow.DataBoundItem;
                // Cập nhật thông tin từ các TextBox
                taikhoan.TenDangNhap = txtUser.Text;
                taikhoan.MatKhau = txtPass.Text;
                taikhoan.VaiTro = ccbRole.SelectedItem?.ToString();

                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{taikhoan.Id}", taikhoan);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadTaiKhoan();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật tài khoản.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
        private void ClearTextBoxes()
        {
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;
            ccbRole.SelectedIndex = -1;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn tài khoản cần xóa.");
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                var taikhoan = (LoginRequest)selectedRow.DataBoundItem;
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{taikhoan.Id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa tài khoản thành công!");
                    LoadTaiKhoan();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa tài khoản.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Cập nhật các TextBox theo dữ liệu của dòng được chọn

                txtUser.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
                txtPass.Text = row.Cells["MatKhau"].Value?.ToString() ?? "";
                ccbRole.Text = row.Cells["VaiTro"].Value?.ToString() ?? "";
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
    }
}
