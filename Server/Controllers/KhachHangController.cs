using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{    [Route("api/[controller]")]
    [ApiController]

    public class KhachHangController : ControllerBase
    {
        private readonly QuanLyBanHangDbContext _context;
        public KhachHangController(QuanLyBanHangDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhachHang>>> GetkhachHangs()
        {
            return await _context.KhachHang.ToListAsync();
        }

        // GET: api/khachhang/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhachHang>> GetKhachHang(int id)
        {
            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return khachHang;
        }

        // POST: api/khachHang
        [HttpPost]
        public async Task<ActionResult<KhachHang>> PostkhachHang(KhachHang khachHang)
        {
            _context.KhachHang.Add(khachHang);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetKhachHang), new { id = khachHang.MaKH }, khachHang);
        }

        // PUT: api/khachHang/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutkhachHang(int id, KhachHang khachHang)
        {
            if (id != khachHang.MaKH)
            {
                return BadRequest();
            }
            _context.Entry(khachHang).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.KhachHang.Any(sp => sp.MaKH == id)))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/khachHang/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletekhachHang(int id)
        {
            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            _context.KhachHang.Remove(khachHang);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("sdt/{sdt}")]
        public IActionResult GetByPhone(string sdt)
        {
            var kh = _context.KhachHang.FirstOrDefault(k => k.SDT == sdt);
            if (kh == null) return NotFound();
            return Ok(kh);
        }


    }
}
