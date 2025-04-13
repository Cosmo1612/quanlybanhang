using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class QuanLyBanHangDbContext : DbContext
    {
        public QuanLyBanHangDbContext(DbContextOptions<QuanLyBanHangDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>().ToTable("SanPham");
        }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<DanhMuc> DanhMuc { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public DbSet<BaoCaoThongKe> BaoCaoThongKe { get; set; }
        public DbSet<PhieuChi> PhieuChi { get; set; }
        public DbSet<PhieuThu> PhieuThu{ get; set; }
    }
}
