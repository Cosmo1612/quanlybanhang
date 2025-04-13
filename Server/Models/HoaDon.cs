using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaKH { get; set; }
        public decimal TongTien { get; set; }

    }
}
