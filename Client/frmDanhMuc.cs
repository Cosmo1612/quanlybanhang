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
    public partial class frmDanhMuc : Form
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7230/api/danhmuc";
        public frmDanhMuc()
        {
            _httpClient = new HttpClient();
            // Nếu chạy trên môi trường thử nghiệm, bỏ qua xác thực SSL (không khuyến nghị cho production)
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            LoadDanhMuc();
            InitializeComponent();
        }
        private async void LoadDanhMuc()
        {
            try
            {
                var DanhMuc = await _httpClient.GetFromJsonAsync<List<DanhMuc>>(BaseUrl);
                dataGridView1.DataSource = DanhMuc;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void ClearTextBoxes()
        {
            txtDM.Text = string.Empty;

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private async void btnThem_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDM.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin danh mục.");
                return;
            }

            try
            {
                var DanhMuc = new DanhMuc
                {
                    TenDM = txtDM.Text,
                };

                var response = await _httpClient.PostAsJsonAsync(BaseUrl, DanhMuc);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm danh mục thành công!");
                    LoadDanhMuc();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm danh mục.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private async void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Giả sử bạn chọn 1 dòng trong DataGridView để cập nhật
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn danh mục cần cập nhật.");
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                var DanhMuc = (DanhMuc)selectedRow.DataBoundItem;
                // Cập nhật thông tin từ các TextBox
                DanhMuc.TenDM = txtDM.Text;

                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{DanhMuc.MaDM}", DanhMuc);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadDanhMuc();
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

        private async void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn danh mục cần xóa.");
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                var DanhMuc = (DanhMuc)selectedRow.DataBoundItem;
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{DanhMuc.MaDM}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa danh mục thành công!");
                    LoadDanhMuc();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa danh mục.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Cập nhật các TextBox theo dữ liệu của dòng được chọn

                txtDM.Text = row.Cells["TenDM"].Value?.ToString() ?? "";
            }
        }
    }
}
