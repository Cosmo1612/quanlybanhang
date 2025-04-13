﻿using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class PhieuChi
    {
        [Key]
        public int MaChi { get; set; }
        public string? MucDichChi { get; set; }
        public decimal SoTienChi { get; set; }
    }
}
