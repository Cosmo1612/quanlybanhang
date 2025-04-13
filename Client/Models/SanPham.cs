using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class SanPham
    {
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
