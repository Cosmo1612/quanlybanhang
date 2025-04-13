using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaoCaoThongKeController : ControllerBase
    {
        private readonly QuanLyBanHangDbContext _context;

        public BaoCaoThongKeController(QuanLyBanHangDbContext context)
        {
            _context = context;
        }

        // POST: api/BaoCaoThongKe/khoitao-bao-cao
        [HttpPost("khoitao-bao-cao")]
        public async Task<IActionResult> KhoiTaoBaoCaoThongKe()
        {
            var ngayLapList = await _context.HoaDon
                .Select(h => h.NgayLap.Date)
                .Distinct()
                .ToListAsync();

            // Tổng chi là tổng giá nhập sản phẩm (giả định không thay đổi theo ngày)
            var tongChi = await _context.SanPham.SumAsync(sp => sp.GiaNhap);

            foreach (var ngay in ngayLapList)
            {
                var tongThu = await _context.HoaDon
                    .Where(h => h.NgayLap.Date == ngay)
                    .SumAsync(h => h.TongTien);

                var tongDon = await _context.HoaDon
                    .CountAsync(h => h.NgayLap.Date == ngay);

                // Nếu báo cáo cho ngày đó chưa tồn tại, thì mới thêm
                var baoCaoTonTai = await _context.BaoCaoThongKe
                    .AnyAsync(bc => bc.NgayBC == ngay);

                if (!baoCaoTonTai)
                {
                    var bc = new BaoCaoThongKe
                    {
                        NgayBC = ngay,
                        TongThu = tongThu,
                        TongChi = tongChi,
                        TongDon = tongDon
                    };

                    _context.BaoCaoThongKe.Add(bc);
                }
            }

            await _context.SaveChangesAsync();
            return Ok("Đã tạo báo cáo cho các ngày có hóa đơn.");
        }

        // GET: api/BaoCaoThongKe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaoCaoThongKe>>> GetBaoCaoThongKe()
        {
            return await _context.BaoCaoThongKe.OrderByDescending(b => b.NgayBC).ToListAsync();
        }
    }

}
