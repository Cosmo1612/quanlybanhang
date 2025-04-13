using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
        [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly QuanLyBanHangDbContext _context;

        public AuthController(QuanLyBanHangDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            if (login == null || string.IsNullOrEmpty(login.TenDangNhap) || string.IsNullOrEmpty(login.MatKhau))
                return BadRequest("Invalid login request");

            var account = await _context.TaiKhoan
                .FirstOrDefaultAsync(a => a.TenDangNhap == login.TenDangNhap && a.MatKhau == login.MatKhau);

            if (account == null)
                return Unauthorized("Invalid username or password");

            // Trả về thông tin cần thiết
            return Ok(new
            {
                Id = account.Id,
                TenDangNhap = account.TenDangNhap,
                VaiTro = account.VaiTro
            });
        }
        public class LoginRequest
        {
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
        }
    }

}
