using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class DanhMuc
    {
        [Key]
        public int MaDM { get; set; }
        public string TenDM { get; set; }
    }
}
