using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class TaiKhoan
    {
        [Key]
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
    }
}
