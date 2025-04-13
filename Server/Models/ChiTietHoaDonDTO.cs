using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
        public class ChiTietHoaDonDTO
        {
        [Key]    
            public int MaCTHD { get; set; }
            public int MaHD { get; set; }
            public int MaSP { get; set; }
            public string TenSP { get; set; }  // <-- thêm tên sản phẩm
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien => SoLuong * DonGia;
        }
    }
