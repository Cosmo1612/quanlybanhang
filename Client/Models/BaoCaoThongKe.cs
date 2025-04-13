using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class BaoCaoThongKe
    {
        [Key]
        public int MaBC { get; set; }
        public DateTime NgayBC { get; set; }
        public Decimal TongChi {  get; set; }
        public Decimal TongThu { get;set; }
        public int TongDon { get; set; }
    }
}
