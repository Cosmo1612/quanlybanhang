using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoaDonController : ControllerBase
    {
        private readonly QuanLyBanHangDbContext _context;

        public ChiTietHoaDonController(QuanLyBanHangDbContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietHoaDon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietHoaDon>>> GetChiTietHoaDons()
        {
            return await _context.ChiTietHoaDon.ToListAsync();
        }

        // GET: api/ChiTietHoaDon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietHoaDon>> GetChiTietHoaDon(int id)
        {
            var cthd = await _context.ChiTietHoaDon.FindAsync(id);

            if (cthd == null)
                return NotFound();

            return cthd;
        }

        // POST: api/ChiTietHoaDon
        [HttpPost]
        public async Task<ActionResult<ChiTietHoaDon>> PostChiTietHoaDon([FromBody] ChiTietHoaDon cthd)
        {
            if (!_context.HoaDon.Any(h => h.MaHD == cthd.MaHD))
                return BadRequest("Hóa đơn không tồn tại.");

            if (!_context.SanPham.Any(sp => sp.MaSP == cthd.MaSP))
                return BadRequest("Sản phẩm không tồn tại.");

            _context.ChiTietHoaDon.Add(cthd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChiTietHoaDon), new { id = cthd.MaCTHD }, cthd);
        }

        // PUT: api/ChiTietHoaDon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietHoaDon(int id, ChiTietHoaDon cthd)
        {
            if (id != cthd.MaCTHD)
                return BadRequest("Mã chi tiết không trùng khớp.");

            _context.Entry(cthd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietHoaDonExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        private bool ChiTietHoaDonExists(int id)
        {
            return _context.ChiTietHoaDon.Any(e => e.MaCTHD == id);
        }

        [HttpGet("hoadon/{maHD}")]
        public async Task<ActionResult<IEnumerable<ChiTietHoaDonDTO>>> GetChiTietHoaDonTheoHoaDon(int maHD)
        {
            var result = await _context.ChiTietHoaDon
                .Where(ct => ct.MaHD == maHD)
                .Join(
                    _context.SanPham,
                    ct => ct.MaSP,
                    sp => sp.MaSP,
                    (ct, sp) => new ChiTietHoaDonDTO
                    {
                        MaCTHD = ct.MaCTHD,
                        MaHD = ct.MaHD,
                        MaSP = ct.MaSP,
                        TenSP = sp.TenSP,
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia
                    }
                )
                .ToListAsync();

            return Ok(result);
        }

        [HttpDelete("xoatheohd/{maHD}")]
        public async Task<IActionResult> XoaChiTietTheoMaHD(int maHD)
        {
            var chiTietList = await _context.ChiTietHoaDon.Where(c => c.MaHD == maHD).ToListAsync();

            if (chiTietList.Count == 0)
                return NotFound("Không có chi tiết hóa đơn nào.");

            _context.ChiTietHoaDon.RemoveRange(chiTietList);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTiet(int id)
        {
            var ct = await _context.ChiTietHoaDon.FindAsync(id);
            if (ct == null) return NotFound();

            _context.ChiTietHoaDon.Remove(ct);
            await _context.SaveChangesAsync();
            return NoContent();
        }




    }
}
