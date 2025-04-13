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
    public partial class frmLogin : Form
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7230/api/auth/login"; // Đảm bảo khớp với URL server

        public frmLogin()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

            // Vô hiệu hoá xác thực SSL cho môi trường phát triển (không dùng cho production)
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, errors) => true;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào trước khi gửi yêu cầu đăng nhập
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng request đăng nhập
                var loginRequest = new LoginRequest
                {
                    TenDangNhap = txtUsername.Text,
                    MatKhau = txtPassword.Text
                };

                // Gửi request đăng nhập tới API
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, loginRequest);

                // Nếu đăng nhập thành công
                if (response.IsSuccessStatusCode)
                {
                    var userInfo = await response.Content.ReadFromJsonAsync<LoginRequest>(); // Cần kiểm tra model userInfo (có thể là LoginResponse)
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    frmTrangChu tc = new frmTrangChu(userInfo);
                    tc.Show();
                }
                else
                {
                    // Nếu API trả về lỗi (sai tài khoản hoặc mật khẩu)
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
