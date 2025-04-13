using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class SanPham
    {
        [Key]
        public int MaSP { get; set; }
        public string? TenSP { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string? MoTa { get; set; }
        public int MaDM { get; set; }
        public byte[]? Anh { get; set; }
        public decimal GiaNhap { get; set; }
    }
}
