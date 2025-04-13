using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaCTHD { get; set; }

        [Required]
        public int MaHD { get; set; }

        [Required]
        public int MaSP { get; set; }

        [Required]
        public int SoLuong { get; set; }

        [Required]
        public decimal DonGia { get; set; }

    }
}
