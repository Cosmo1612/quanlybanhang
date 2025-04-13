using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PhieuThuController : ControllerBase
    {
        private readonly QuanLyBanHangDbContext _context;
        public PhieuThuController(QuanLyBanHangDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuThu>>> GetPhieuThus()
        {
            return await _context.PhieuThu.ToListAsync();
        }

        // GET: api/PhieuThu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuThu>> GetPhieuThu(int id)
        {
            var PhieuThu = await _context.PhieuThu.FindAsync(id);
            if (PhieuThu == null)
            {
                return NotFound();
            }
            return PhieuThu;
        }

        // POST: api/PhieuThu
        [HttpPost]
        public async Task<ActionResult<PhieuThu>> PostPhieuThu(PhieuThu PhieuThu)
        {
            _context.PhieuThu.Add(PhieuThu);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPhieuThu), new { id = PhieuThu.MaThu }, PhieuThu);
        }

        // PUT: api/PhieuThu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhieuThu(int id, PhieuThu PhieuThu)
        {
            if (id != PhieuThu.MaThu)
            {
                return BadRequest();
            }
            _context.Entry(PhieuThu).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.PhieuThu.Any(sp => sp.MaThu == id)))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/PhieuThu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhieuThu(int id)
        {
            var PhieuThu = await _context.PhieuThu.FindAsync(id);
            if (PhieuThu == null)
            {
                return NotFound();
            }
            _context.PhieuThu.Remove(PhieuThu);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
