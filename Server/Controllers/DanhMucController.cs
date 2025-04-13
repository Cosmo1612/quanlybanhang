using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private readonly QuanLyBanHangDbContext _context;
        public DanhMucController(QuanLyBanHangDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DanhMuc>>> GetDanhMucs()
        {
            return await _context.DanhMuc.ToListAsync();
        }

        // GET: api/DanhMuc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DanhMuc>> GetDanhMuc(int id)
        {
            var DanhMuc = await _context.DanhMuc.FindAsync(id);
            if (DanhMuc == null)
            {
                return NotFound();
            }
            return DanhMuc;
        }

        // POST: api/DanhMuc
        [HttpPost]
        public async Task<ActionResult<DanhMuc>> PostDanhMuc(DanhMuc DanhMuc)
        {
            _context.DanhMuc.Add(DanhMuc);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDanhMuc), new { id = DanhMuc.MaDM }, DanhMuc);
        }

        // PUT: api/DanhMuc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDanhMuc(int id, DanhMuc DanhMuc)
        {
            if (id != DanhMuc.MaDM)
            {
                return BadRequest();
            }
            _context.Entry(DanhMuc).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.DanhMuc.Any(sp => sp.MaDM == id)))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/DanhMuc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanhMuc(int id)
        {
            var DanhMuc = await _context.DanhMuc.FindAsync(id);
            if (DanhMuc == null)
            {
                return NotFound();
            }
            _context.DanhMuc.Remove(DanhMuc);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
