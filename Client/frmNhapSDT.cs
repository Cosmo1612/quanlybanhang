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
    public partial class frmNhapSDT : Form
    {
        public KhachHang SelectedKhachHang { get; private set; }

        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7230") };
        public frmNhapSDT()
        {
            InitializeComponent();
            this.Text = "Thông tin khách hàng";
            this.Width = 400;
            this.Height = 250;

            var txtSDT = new TextBox { Name = "txtSDT", PlaceholderText = "Nhập số điện thoại", Width = 250, Top = 20, Left = 60 };
            var btnCheck = new Button { Text = "Kiểm tra", Width = 100, Top = 60, Left = 60 };
            var lblKetQua = new Label { Name = "lblKetQua", Width = 300, Top = 100, Left = 60 };
            var btnThemMoi = new Button { Text = "Thêm khách hàng mới", Width = 180, Top = 140, Left = 60, Visible = false };

            this.Controls.Add(txtSDT);
            this.Controls.Add(btnCheck);
            this.Controls.Add(lblKetQua);
            this.Controls.Add(btnThemMoi);

            btnCheck.Click += async (s, e) =>
            {
                string sdt = txtSDT.Text.Trim();
                if (string.IsNullOrEmpty(sdt))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.");
                    return;
                }

                try
                {
                    var kh = await _httpClient.GetFromJsonAsync<KhachHang>($"/api/khachhang/sdt/{sdt}");
                    if (kh != null)
                    {
                        lblKetQua.Text = $"Tên: {kh.TenKH} - Địa chỉ: {kh.DiaChi}";
                        SelectedKhachHang = kh;
                        btnThemMoi.Visible = false;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        lblKetQua.Text = "Không tìm thấy khách hàng!";
                        btnThemMoi.Visible = true;
                    }
                }
                catch
                {
                    lblKetQua.Text = "Không tìm thấy khách hàng!";
                    btnThemMoi.Visible = true;
                }
            };

            btnThemMoi.Click += async (s, e) =>
            {
                string sdt = txtSDT.Text.Trim();
                string ten = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên khách hàng:", "Thêm khách", "");
                string diaChi = Microsoft.VisualBasic.Interaction.InputBox("Nhập địa chỉ:", "Thêm khách", "");

                if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(diaChi)) return;

                var newKH = new KhachHang
                {
                    TenKH = ten,
                    SDT = sdt,
                    DiaChi = diaChi
                };

                var res = await _httpClient.PostAsJsonAsync("/api/khachhang", newKH);
                if (res.IsSuccessStatusCode)
                {
                    SelectedKhachHang = await res.Content.ReadFromJsonAsync<KhachHang>();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!");
                }
            };
        }
    }
}
