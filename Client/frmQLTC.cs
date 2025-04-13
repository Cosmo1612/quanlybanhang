using client.Models;
using Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class frmQLTC : Form
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7230/api/PhieuThu";
        private const string BaseUrl1 = "https://localhost:7230/api/PhieuChi";
        public frmQLTC()
        {
            _httpClient = new HttpClient();
            // Nếu chạy trên môi trường thử nghiệm, bỏ qua xác thực SSL (không khuyến nghị cho production)
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            InitializeComponent();
            LoadThuChi();
            cbbTC.SelectedIndexChanged += cbbTC_SelectedIndexChanged;
        }
        private void LoadThuChi()
        {
            cbbTC.Items.Add("Chọn danh sách hiển thị");
            cbbTC.Items.Add("Danh Sách Thu");
            cbbTC.Items.Add("Danh Sách Chi");

            cbbTC.SelectedIndex = 0;
        }

        private async void LoadDSTC()
        {
            try
            {
                if (cbbTC.SelectedItem?.ToString() == "Danh Sách Thu")
                {
                    var DSThu = await _httpClient.GetFromJsonAsync<List<PhieuThu>>(BaseUrl);
                    dgvTC.DataSource = DSThu;
                }
                else if (cbbTC.SelectedItem?.ToString() == "Danh Sách Chi")
                {
                    var DSChi = await _httpClient.GetFromJsonAsync<List<PhieuChi>>(BaseUrl1);
                    dgvTC.DataSource = DSChi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void cbbTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDSTC();
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTC.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn phiếu cần cập nhật.");
                    return;
                }

                var selectedRow = dgvTC.SelectedRows[0];
                if (cbbTC.SelectedItem?.ToString() == "Danh Sách Thu")
                {
                    var DST = (PhieuThu)selectedRow.DataBoundItem;
                    DST.MucDichThu = txtND.Text;
                    DST.SoTienThu = decimal.Parse(txtChiThu.Text);
                    var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{DST.MaThu}", DST);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        cbbTC.SelectedIndexChanged += cbbTC_SelectedIndexChanged;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi cập nhật phiếu thu.");
                    }
                }
                else if (cbbTC.SelectedItem?.ToString() == "Danh Sách Chi")
                {
                    var DSC = (PhieuChi)selectedRow.DataBoundItem;
                    DSC.MucDichChi = txtND.Text;
                    DSC.SoTienChi = decimal.Parse(txtChiThu.Text);
                    var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{DSC.MaChi}", DSC);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        LoadDSTC();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi cập nhật phiếu chi.");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            txtND.Text = string.Empty;
            txtChiThu.Text = string.Empty;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTC.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chọn phiếu cần xoá.");
                    return;
                }

                var selectedRow = dgvTC.SelectedRows[0];
                if (cbbTC.SelectedItem?.ToString() == "Danh Sách Thu")
                {
                    var DST = (PhieuThu)selectedRow.DataBoundItem;
                    DST.MucDichThu = txtND.Text;
                    DST.SoTienThu = decimal.Parse(txtChiThu.Text);
                    var response = await _httpClient.DeleteAsync($"{BaseUrl}/{DST.MaThu}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xoá phiếu thu thành công!");
                        cbbTC.SelectedIndexChanged += cbbTC_SelectedIndexChanged;
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xoá phiếu thu.");
                    }
                }
                else if (cbbTC.SelectedItem?.ToString() == "Danh Sách Chi")
                {
                    var DSC = (PhieuChi)selectedRow.DataBoundItem;
                    DSC.MucDichChi = txtND.Text;
                    DSC.SoTienChi = decimal.Parse(txtChiThu.Text);
                    var response = await _httpClient.DeleteAsync($"{BaseUrl1}/{DSC.MaChi}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xoá thành công phiếu chi!");
                        LoadDSTC();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xoá phiếu chi.");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void dgvTC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTC.Rows[e.RowIndex];
                // Cập nhật các TextBox theo dữ liệu của dòng được chọn

                txtND.Text = row.Cells[1].Value?.ToString() ?? "";
                txtChiThu.Text = row.Cells[2].Value?.ToString() ?? "";
            }
        }
    }
}
