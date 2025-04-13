using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PhieuChiController : ControllerBase
    {
        private readonly QuanLyBanHangDbContext _context;
        public PhieuChiController(QuanLyBanHangDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuChi>>> GetPhieuChis()
        {
            return await _context.PhieuChi.ToListAsync();
        }

        // GET: api/PhieuChi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuChi>> GetPhieuChi(int id)
        {
            var PhieuChi = await _context.PhieuChi.FindAsync(id);
            if (PhieuChi == null)
            {
                return NotFound();
            }
            return PhieuChi;
        }

        // POST: api/PhieuChi
        [HttpPost]
        public async Task<ActionResult<PhieuChi>> PostPhieuChi(PhieuChi PhieuChi)
        {
            _context.PhieuChi.Add(PhieuChi);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPhieuChi), new { id = PhieuChi.MaChi }, PhieuChi);
        }

        // PUT: api/PhieuChi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhieuChi(int id, PhieuChi PhieuChi)
        {
            if (id != PhieuChi.MaChi)
            {
                return BadRequest();
            }
            _context.Entry(PhieuChi).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.PhieuChi.Any(sp => sp.MaChi == id)))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/PhieuChi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhieuChi(int id)
        {
            var PhieuChi = await _context.PhieuChi.FindAsync(id);
            if (PhieuChi == null)
            {
                return NotFound();
            }
            _context.PhieuChi.Remove(PhieuChi);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
