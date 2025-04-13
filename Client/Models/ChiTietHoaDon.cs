using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaCTHD { get; set; }
        public int MaHD { get; set; }
        public int MaSP {  get; set; }
        public int SoLuong { get; set; }
        public Decimal DonGia { get; set; }

    }
}
