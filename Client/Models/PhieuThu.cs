using System.ComponentModel.DataAnnotations;

namespace client.Models
{
    public class PhieuThu
    {
        [Key]
        public int MaThu { get; set; }
        public string? MucDichThu { get; set; }
        public decimal SoTienThu { get; set; }
    }
}
