using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly QuanLyBanHangDbContext _context;
        public HoaDonController(QuanLyBanHangDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDon>>> GetHoaDons()
        {
            return await _context.HoaDon.ToListAsync();
        }

        // GET: api/HoaDon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDon>> GetHoaDon(int id)
        {
            var HoaDon = await _context.HoaDon.FindAsync(id);
            if (HoaDon == null)
            {
                return NotFound();
            }
            return HoaDon;
        }

        // POST: api/HoaDon
        [HttpPost]
        public async Task<ActionResult<HoaDon>> PostHoaDon(HoaDon HoaDon)
        {
            _context.HoaDon.Add(HoaDon);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHoaDon), new { id = HoaDon.MaHD }, HoaDon);
        }

        // PUT: api/HoaDon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoaDon(int id, HoaDon HoaDon)
        {
            if (id != HoaDon.MaHD)
            {
                return BadRequest();
            }
            _context.Entry(HoaDon).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.HoaDon.Any(sp => sp.MaHD == id)))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoaDon(int id)
        {
            var hoaDon = await _context.HoaDon.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            var ngayHoaDon = hoaDon.NgayLap.Date;

            // Xoá hóa đơn
            _context.HoaDon.Remove(hoaDon);
            await _context.SaveChangesAsync();

            // Kiểm tra lại các hóa đơn còn lại trong ngày
            var hoaDonTrongNgay = await _context.HoaDon
                .Where(h => h.NgayLap.Date == ngayHoaDon)
                .ToListAsync();

            var baoCao = await _context.BaoCaoThongKe
                .FirstOrDefaultAsync(bc => bc.NgayBC.Date == ngayHoaDon);

            if (hoaDonTrongNgay.Any())
            {
                // Nếu còn hóa đơn -> cập nhật báo cáo
                decimal tongThu = hoaDonTrongNgay.Sum(h => h.TongTien);
                int tongDon = hoaDonTrongNgay.Count;

                // Tổng chi có thể là cố định hoặc tính động theo sản phẩm, bạn có thể sửa tùy nhu cầu
                decimal tongChi = await _context.SanPham.SumAsync(sp => sp.GiaNhap);

                if (baoCao != null)
                {
                    baoCao.TongThu = tongThu;
                    baoCao.TongDon = tongDon;
                    baoCao.TongChi = tongChi;
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                // Nếu không còn hóa đơn -> xóa báo cáo
                if (baoCao != null)
                {
                    _context.BaoCaoThongKe.Remove(baoCao);
                    await _context.SaveChangesAsync();
                }
            }

            return NoContent();
        }

        [HttpGet("tongthu")]
        public async Task<ActionResult<decimal>> GetTongThu()
        {
            var tongThu = await _context.HoaDon.SumAsync(h => h.TongTien);
            return Ok(tongThu);
        }

        [HttpGet("tongdon")]
        public async Task<ActionResult<int>> GetTongDon()
        {
            var tongDon = await _context.HoaDon.CountAsync();
            return Ok(tongDon);
        }
        [HttpGet("ngay/{ngay}")]
        public async Task<ActionResult<IEnumerable<HoaDon>>> GetHoaDonTheoNgay(DateTime ngay)
        {
            var ketQua = await _context.HoaDon
                .Where(h => h.NgayLap.Date == ngay.Date)
                .ToListAsync();

            return Ok(ketQua);
        }

        [HttpPut("capnhattongtien")]
        public async Task<IActionResult> CapNhatTongTien([FromBody] HoaDonCapNhatDTO dto)
        {
            var hoaDon = await _context.HoaDon.FindAsync(dto.MaHD);
            if (hoaDon == null) return NotFound();

            hoaDon.TongTien = dto.TongTien;
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
