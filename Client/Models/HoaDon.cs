using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class HoaDon
    {

        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaKH { get; set; }
        public decimal TongTien { get; set; }

    }
}
