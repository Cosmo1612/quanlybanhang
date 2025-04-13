using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);

// ??ng ký DbContext v?i SQL Server
builder.Services.AddDbContext<QuanLyBanHangDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm các d?ch v? MVC/Controllers
builder.Services.AddControllers();

// Thêm d?ch v? ?y quy?n (n?u c?n)
// builder.Services.AddAuthorization(); // N?u có dùng chính sách xác th?c/?y quy?n

// Thêm Swagger ?? ki?m tra API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuanLyBanHang API", Version = "v1" });
});

var app = builder.Build();

// C?u hình pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuanLyBanHang API v1");
    });
}

app.UseHttpsRedirection();

// N?u dùng xác th?c, thêm:
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
