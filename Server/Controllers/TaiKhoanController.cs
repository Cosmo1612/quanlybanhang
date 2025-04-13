using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TaiKhoanController : ControllerBase
    {
        private readonly QuanLyBanHangDbContext _context;
        public TaiKhoanController(QuanLyBanHangDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiKhoan>>> GetTaiKhoans()
        {
            return await _context.TaiKhoan.ToListAsync();
        }

        // GET: api/TaiKhoan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoan>> GetTaiKhoan(int id)
        {
            var TaiKhoan = await _context.TaiKhoan.FindAsync(id);
            if (TaiKhoan == null)
            {
                return NotFound();
            }
            return TaiKhoan;
        }

        // POST: api/TaiKhoan
        [HttpPost]
        public async Task<ActionResult<TaiKhoan>> PostTaiKhoan(TaiKhoan TaiKhoan)
        {
            _context.TaiKhoan.Add(TaiKhoan);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTaiKhoan), new { id = TaiKhoan.Id }, TaiKhoan);
        }

        // PUT: api/TaiKhoan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiKhoan(int id, TaiKhoan TaiKhoan)
        {
            if (id != TaiKhoan.Id)
            {
                return BadRequest();
            }
            _context.Entry(TaiKhoan).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.TaiKhoan.Any(sp => sp.Id == id)))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/TaiKhoan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiKhoan(int id)
        {
            var TaiKhoan = await _context.TaiKhoan.FindAsync(id);
            if (TaiKhoan == null)
            {
                return NotFound();
            }
            _context.TaiKhoan.Remove(TaiKhoan);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
