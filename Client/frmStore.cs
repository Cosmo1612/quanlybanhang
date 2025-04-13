using Client.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Client
{
    public partial class frmStore : Form
    {
        private const string BaseUrlSanPham = "https://localhost:7230/api/sanpham";
        private const string BaseUrlDanhMuc = "https://localhost:7230/api/danhmuc";
        private const string BaseUrlHoaDon = "https://localhost:7230/api/hoadon";
        private const string BaseUrlChiTietHD = "https://localhost:7230/api/ChiTietHoaDon";

        private readonly HttpClient _httpClient = new HttpClient();
        private ListBox listCategories;
        private FlowLayoutPanel flowProducts;
        private FlowLayoutPanel pnlCart;       // Panel chứa các mục giỏ hàng
        private Label lblTotal;                // Hiển thị tổng tiền
        private Button btnClearCart;           // Nút xoá tất cả các mục trong giỏ hàng
        private decimal totalPrice = 0m;
        private List<SanPham> cartProducts = new List<SanPham>();

        public frmStore()
        {
            InitializeComponent();
            SetupUI();
            LoadCategories();
        }

        private void SetupUI()
        {
            // Danh mục sản phẩm (bên trái)
            listCategories = new ListBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10) };
            listCategories.SelectedIndexChanged += ListCategories_SelectedIndexChanged;
            panel1.Controls.Add(listCategories);

            // Flow hiển thị sản phẩm (phần chính)
            flowProducts = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.WhiteSmoke
            };
            panel3.Controls.Add(flowProducts);

            // Phần giỏ hàng (bên phải)
            pnlCart = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 320,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(5)
            };

            lblTotal = new Label
            {
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Text = "Tổng: 0đ",
                ForeColor = Color.DarkBlue
            };

            btnClearCart = new Button
            {
                Text = "Xoá tất cả",
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnClearCart.Click += (s, e) => { ResetCart(); };

            // Nút thanh toán
            var btnCheckout = new Button
            {
                Dock = DockStyle.Top,
                Height = 45,
                Text = "Thanh toán",
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnCheckout.Click += BtnCheckout_Click;

            // Thêm các control vào panel giỏ hàng (panel2)
            panel2.Controls.Add(btnCheckout);
            panel2.Controls.Add(btnClearCart);
            panel2.Controls.Add(lblTotal);
            panel2.Controls.Add(pnlCart);

            // Ẩn nút xoá tất cả nếu giỏ hàng rỗng
            btnClearCart.Visible = false;
        }

        private async void LoadCategories()
        {
            try
            {
                var dms = await _httpClient.GetFromJsonAsync<List<DanhMuc>>(BaseUrlDanhMuc);
                if (dms != null)
                {
                    dms.Insert(0, new DanhMuc { MaDM = 0, TenDM = "Tất cả" });
                    listCategories.DataSource = dms;
                    listCategories.DisplayMember = "TenDM";
                    listCategories.ValueMember = "MaDM";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message);
            }
        }

        private void ListCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCategories.SelectedItem is DanhMuc selectedCategory)
                LoadProducts(selectedCategory.MaDM == 0 ? (int?)null : selectedCategory.MaDM);
        }

        private async void LoadProducts(int? maDM)
        {
            try
            {
                flowProducts.Controls.Clear();
                string url = BaseUrlSanPham + (maDM.HasValue ? $"?MaDM={maDM.Value}" : "");
                var products = await _httpClient.GetFromJsonAsync<List<SanPham>>(url);

                if (products?.Count > 0)
                {
                    flowProducts.SuspendLayout();
                    foreach (var p in products)
                        flowProducts.Controls.Add(CreateProductItem(p));
                    flowProducts.ResumeLayout();
                }
                else
                {
                    MessageBox.Show("API trả về danh sách trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tạo giao diện sản phẩm với thiết kế hiện đại
        private Panel CreateProductItem(SanPham p)
        {
            var panelItem = new Panel
            {
                Width = 200,
                Height = 280,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Padding = new Padding(10),
                Margin = new Padding(10)
            };

            var pictureBox = new PictureBox
            {
                Width = 180,
                Height = 140,
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle
            };

            if (p.Anh != null && p.Anh.Length > 0)
            {
                pictureBox.Image = Image.FromStream(new MemoryStream(p.Anh));
            }

            var lblName = new Label
            {
                Text = p.TenSP,
                Width = 180,
                Height = 40,
                Location = new Point(10, 160),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblPrice = new Label
            {
                Text = $"{p.Gia:N0}đ",
                Width = 180,
                Height = 25,
                Location = new Point(10, 210),
                ForeColor = Color.Red,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var btnAdd = new Button
            {
                Text = "Thêm vào giỏ",
                Location = new Point(35, 245),
                Width = 130,
                Height = 30,
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            btnAdd.Click += (s, e) =>
            {
                AddToCart(p);
            };

            panelItem.Controls.Add(pictureBox);
            panelItem.Controls.Add(lblName);
            panelItem.Controls.Add(lblPrice);
            panelItem.Controls.Add(btnAdd);

            return panelItem;
        }

        // Tạo giao diện cho từng mục trong giỏ hàng với thiết kế "card" hiện đại
        private void AddToCart(SanPham p)
        {
            Panel panelCartItem = new Panel
            {
                Width = pnlCart.Width - 25,
                Height = 70,
                BackColor = Color.White,
                Margin = new Padding(5),
                Padding = new Padding(10)
            };
            // Vẽ đường viền nhẹ cho panel
            panelCartItem.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panelCartItem.Width - 1, panelCartItem.Height - 1);
                }
            };

            Label lblItem = new Label
            {
                Text = $"{p.TenSP} - {p.Gia:N0}đ",
                AutoSize = false,
                Width = panelCartItem.Width - 80,
                Height = 50,
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(5, 10)
            };

            Button btnRemoveItem = new Button
            {
                Text = "X",
                Width = 40,
                Height = 40,
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(panelCartItem.Width - 50, 15)
            };

            btnRemoveItem.Click += (s, e) =>
            {
                pnlCart.Controls.Remove(panelCartItem);
                cartProducts.Remove(p);
                totalPrice -= p.Gia;
                lblTotal.Text = $"Tổng: {totalPrice:N0}đ";
                btnClearCart.Visible = pnlCart.Controls.Count > 0;
            };

            panelCartItem.Controls.Add(lblItem);
            panelCartItem.Controls.Add(btnRemoveItem);

            pnlCart.Controls.Add(panelCartItem);
            cartProducts.Add(p);
            totalPrice += p.Gia;
            lblTotal.Text = $"Tổng: {totalPrice:N0}đ";
            btnClearCart.Visible = true;
        }

        // Sự kiện thanh toán
        private async void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (totalPrice == 0)
            {
                MessageBox.Show("Giỏ hàng trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          

            using(var formKH = new frmNhapSDT())
{
                if (formKH.ShowDialog() == DialogResult.OK)
                {
                    var khachHang = formKH.SelectedKhachHang;
                    if (khachHang == null)
                    {
                        MessageBox.Show("Không tìm thấy hoặc thêm mới khách hàng thất bại.");
                        return;
                    }

                    var result = MessageBox.Show("Chọn phương thức thanh toán:\nYes = Tiền mặt, No = Chuyển khoản.",
                                                 "Thanh toán", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        await SaveInvoiceAsync(khachHang.MaKH);
                        await CapNhatTonKhoSauThanhToanAsync(cartProducts);
                        MessageBox.Show("Thanh toán thành công!", "Thông báo");
                        ResetCart();
                    }
                    else if (result == DialogResult.No)
                    {
                        await ShowQrFromAPI(totalPrice);
                        await SaveInvoiceAsync(khachHang.MaKH);
                        await CapNhatTonKhoSauThanhToanAsync(cartProducts);
                        MessageBox.Show("Thanh toán thành công qua chuyển khoản!", "Thông báo");
                        ResetCart();
                    }
                }
            }
        }

        // Lưu hóa đơn và chi tiết hóa đơn
        public async Task SaveInvoiceAsync(int maKH)
        {
            var chiTietHoaDon = cartProducts
       .GroupBy(p => p.MaSP)
       .Select(g => new ChiTietHoaDon
       {
           MaSP = g.Key,
           SoLuong = g.Count(),
           DonGia = g.First().Gia
       }).ToList();

            var hoaDon = new HoaDon
            {
                NgayLap = DateTime.Now,
                MaKH = maKH,
                TongTien = totalPrice
            };

            try
            {
                // Gửi yêu cầu tạo hóa đơn
                var response = await _httpClient.PostAsJsonAsync(BaseUrlHoaDon, hoaDon);
                if (response.IsSuccessStatusCode)
                {
                    var savedHoaDon = await response.Content.ReadFromJsonAsync<HoaDon>();
                    if (savedHoaDon != null && savedHoaDon.MaHD > 0)
                    {
                        // Gửi từng chi tiết hóa đơn sau khi có mã hóa đơn
                        foreach (var item in chiTietHoaDon)
                        {
                            var chiTietHD = new ChiTietHoaDon
                            {
                                MaHD = savedHoaDon.MaHD,
                                MaSP = item.MaSP,
                                SoLuong = item.SoLuong,
                                DonGia = item.DonGia
                            };

                            var ctResponse = await _httpClient.PostAsJsonAsync(BaseUrlChiTietHD, chiTietHD);
                            if (!ctResponse.IsSuccessStatusCode)
                            {
                                string error = await ctResponse.Content.ReadAsStringAsync();

                                MessageBox.Show($"Lưu chi tiết hóa đơn thất bại cho sản phẩm mã {item.MaSP}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        MessageBox.Show("Hóa đơn và chi tiết hóa đơn đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Lưu hóa đơn thất bại do không nhận được mã hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lưu hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Hiển thị QR thanh toán (nếu chuyển khoản)
        public async Task ShowQrFromAPI(decimal totalPrice)
        {
            string bank = "MB";
            string account = "0000368303660";
            string name = "Do Vu Thanh Loc";
            string amount = totalPrice.ToString("0");
            string note = "Thanh toan don hang";

            string apiUrl = $"https://img.vietqr.io/image/{bank}-{account}-compact2.png?amount={amount}&addInfo={note}&accountName={name}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    Bitmap qrImage = new Bitmap(stream);

                    Form qrForm = new Form
                    {
                        Text = "QR Chuyển khoản",
                        Width = 350,
                        Height = 500,
                        StartPosition = FormStartPosition.CenterScreen
                    };

                    PictureBox pbQr = new PictureBox
                    {
                        Image = qrImage,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Dock = DockStyle.Top,
                        Height = 300
                    };
                    Button btnConfirm = new Button
                    {
                        Text = "Xác nhận đã thanh toán",
                        Dock = DockStyle.Bottom,
                        Height = 40,
                        BackColor = Color.MediumSeaGreen,
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat
                    };

                    qrForm.Controls.Add(pbQr);
                    qrForm.Controls.Add(btnConfirm);

                    qrForm.ShowDialog();
                }
            }
        }

        // Reset giỏ hàng
        private void ResetCart()
        {
            pnlCart.Controls.Clear();
            cartProducts.Clear();
            totalPrice = 0;
            lblTotal.Text = $"Tổng: {totalPrice:N0}đ";
            btnClearCart.Visible = false;
        }
        public async Task CapNhatTonKhoSauThanhToanAsync(List<SanPham> cartProducts)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7230"); // chỉnh port nếu khác

                var tonKhoUpdateList = cartProducts
                    .GroupBy(p => p.MaSP)
                    .Select(g => new
                    {
                        MaSP = g.Key,
                        SoLuong = g.Count()
                    }).ToList();

                var response = await httpClient.PostAsJsonAsync("/api/sanpham/capnhattongiao", tonKhoUpdateList);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Trừ tồn kho thành công!", "Thông báo");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Lỗi khi cập nhật tồn kho: {error}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void frmStore_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
