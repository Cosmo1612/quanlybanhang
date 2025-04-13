using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        public string? TenKH { get; set; }
        public string? SDT { get; set; }
        public string? DiaChi { get; set; }
    }
}
