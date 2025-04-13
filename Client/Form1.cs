using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using Client.Models;

namespace Client
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7230/api/sanpham";  // URL API sản phẩm
        private const string BaseUrl1 = "https://localhost:7230/api/danhmuc"; // URL API danh mục sản phẩm

        public Form1()
        {
            InitializeComponent();
            // Khởi tạo HttpClient
            _httpClient = new HttpClient();
            // Nếu chạy trên môi trường thử nghiệm, bỏ qua xác thực SSL (không khuyến nghị cho production)
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            LoadSanPhams();
            LoadDanhMuc();
        }

        private async void LoadSanPhams()
        {
            try
            {
                var sanPhams = await _httpClient.GetFromJsonAsync<List<SanPham>>(BaseUrl);
                dataGridView1.DataSource = sanPhams;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async void LoadDanhMuc()
        {
            try
            {
                var danhmuc = await _httpClient.GetFromJsonAsync<List<DanhMuc>>(BaseUrl1);
                cbbDM.DataSource = danhmuc;
                cbbDM.DisplayMember = "TenDM"; // Tên thuộc tính hiển thị trên combobox
                cbbDM.ValueMember = "MaDM";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng sanPham từ dữ liệu trên form
                var sanPham = new SanPham
                {
                    TenSP = txtName.Text,
                    SoLuong = int.Parse(txtQuantity.Text),
                    Gia = decimal.Parse(txtPrice.Text),
                    MaDM = Convert.ToInt32(cbbDM.SelectedValue),
                    Anh = PictureToByteArray(pictureBox1.Image),
                    GiaNhap = decimal.Parse(txtGiaNhap.Text),
                    MoTa = txtMoTa.Text// Lưu trữ ảnh dưới dạng byte array
                };

                var response = await _httpClient.PostAsJsonAsync(BaseUrl, sanPham);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    LoadSanPhams();  // Tải lại danh sách sản phẩm
                    ClearTextBoxes(); // Xóa các trường nhập liệu
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private byte[] PictureToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bitmap = new Bitmap(image)) // clone ảnh
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // lưu định dạng PNG
                }
                return ms.ToArray();
            }
        }



        private async void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu không có dòng nào được chọn
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn sản phẩm cần cập nhật.");
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                var sanPham = (SanPham)selectedRow.DataBoundItem;

                // Cập nhật thông tin sản phẩm từ các TextBox
                sanPham.TenSP = txtName.Text;
                sanPham.MoTa = txtMoTa.Text;
                sanPham.SoLuong = int.Parse(txtQuantity.Text);
                sanPham.Gia = decimal.Parse(txtPrice.Text);
                sanPham.MaDM = Convert.ToInt32(cbbDM.SelectedValue);
                sanPham.Anh = PictureToByteArray(pictureBox1.Image);

                // Gửi yêu cầu PUT để cập nhật sản phẩm
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{sanPham.MaSP}", sanPham);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadSanPhams();  // Tải lại danh sách sản phẩm
                    ClearTextBoxes(); // Xóa các trường nhập liệu
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật sản phẩm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ClearTextBoxes()
        {
            txtName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            cbbDM.Text = string.Empty;
            pictureBox1.Image = null;
            txtMoTa.Text = string.Empty;
            txtGiaNhap.Text = string.Empty;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu không có dòng nào được chọn
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn sản phẩm cần xóa.");
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                var sanPham = (SanPham)selectedRow.DataBoundItem;

                // Gửi yêu cầu DELETE để xóa sản phẩm
                var response = await _httpClient.DeleteAsync($"{BaseUrl}/{sanPham.MaSP}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    LoadSanPhams();  // Tải lại danh sách sản phẩm
                    ClearTextBoxes(); // Xóa các trường nhập liệu
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm.");
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
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Cập nhật các TextBox theo dữ liệu của dòng được chọn
                txtName.Text = row.Cells["TenSP"].Value?.ToString() ?? "";
                txtQuantity.Text = row.Cells["SoLuong"].Value?.ToString() ?? "";
                txtPrice.Text = row.Cells["Gia"].Value?.ToString() ?? "";
                txtGiaNhap.Text = row.Cells["GiaNhap"].Value?.ToString() ?? "";
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";

                // Hiển thị ảnh từ byte[] lên PictureBox
                var imageData = row.Cells["Anh"].Value as byte[];
                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }

                // Set combobox danh mục
                if (row.Cells["MaDM"].Value != null)
                {
                    if (int.TryParse(row.Cells["MaDM"].Value.ToString(), out int maDM))
                    {
                        cbbDM.SelectedValue = maDM;
                    }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (var tempImage = Image.FromFile(filePath))
                {
                    pictureBox1.Image = new Bitmap(tempImage); // clone ảnh, tránh lỗi GDI+
                }
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
    }
}
