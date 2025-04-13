using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
        public class ChiTietHoaDonDTO
        {
            public int MaCTHD { get; set; }
            public int MaHD { get; set; }
            public int MaSP { get; set; }
            public string TenSP { get; set; }  // <-- thêm tên sản phẩm
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien => SoLuong * DonGia;
        }
    }
