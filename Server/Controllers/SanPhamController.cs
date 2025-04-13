using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly QuanLyBanHangDbContext _context;

        public SanPhamController(QuanLyBanHangDbContext context)
        {
            _context = context;
        }

        // GET: api/sanpham?MaDM=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSanPhams([FromQuery] int? MaDM)
        {
            var query = _context.SanPham.AsQueryable();

            if (MaDM.HasValue)
            {
                query = query.Where(sp => sp.MaDM == MaDM.Value);
            }

            return await query.ToListAsync();
        }

        // GET: api/sanpham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> GetSanPham(int id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return sanPham;
        }

        // POST: api/sanpham
        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<SanPham>> PostSanPham([FromBody] SanPham sanPham)
        {
            if (sanPham == null)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            _context.SanPham.Add(sanPham);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSanPham), new { id = sanPham.MaSP }, sanPham);
        }


        // PUT: api/sanpham/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPham(int id, SanPham sanPham)
        {
            if (id != sanPham.MaSP)
            {
                return BadRequest();
            }
            _context.Entry(sanPham).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.SanPham.Any(sp => sp.MaSP == id)))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/sanpham/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            _context.SanPham.Remove(sanPham);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/sanpham/capnhattongiao
        [HttpPost("capnhattongiao")]
        public async Task<IActionResult> CapNhatTonGiaoDich([FromBody] List<SanPham> cartProducts)
        {
            if (cartProducts == null || !cartProducts.Any())
            {
                return BadRequest("Giỏ hàng trống.");
            }

            // Gom nhóm theo MaSP để tính tổng số lượng mua
            var grouped = cartProducts
                .GroupBy(sp => sp.MaSP)
                .Select(g => new { MaSP = g.Key, SoLuongMua = g.Count() });

            foreach (var item in grouped)
            {
                var sanPham = await _context.SanPham.FindAsync(item.MaSP);
                if (sanPham == null)
                    return NotFound($"Không tìm thấy sản phẩm có mã {item.MaSP}.");

                // Kiểm tra tồn kho
                if (sanPham.SoLuong < item.SoLuongMua)
                    return BadRequest($"Không đủ số lượng sản phẩm mã {item.MaSP}.");

                // Trừ số lượng tồn
                sanPham.SoLuong -= item.SoLuongMua;
            }

            await _context.SaveChangesAsync();
            return Ok("Cập nhật tồn kho thành công.");
        }

        [HttpGet("tongchi")]
        public async Task<ActionResult<decimal>> GetTongTienNhap()
        {
            var tongNhap = await _context.SanPham.SumAsync(sp => sp.GiaNhap);
            return tongNhap;
        }


    }
}
