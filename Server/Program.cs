using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);

// ??ng k� DbContext v?i SQL Server
builder.Services.AddDbContext<QuanLyBanHangDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Th�m c�c d?ch v? MVC/Controllers
builder.Services.AddControllers();

// Th�m d?ch v? ?y quy?n (n?u c?n)
// builder.Services.AddAuthorization(); // N?u c� d�ng ch�nh s�ch x�c th?c/?y quy?n

// Th�m Swagger ?? ki?m tra API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuanLyBanHang API", Version = "v1" });
});

var app = builder.Build();

// C?u h�nh pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuanLyBanHang API v1");
    });
}

app.UseHttpsRedirection();

// N?u d�ng x�c th?c, th�m:
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
