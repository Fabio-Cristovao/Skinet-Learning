using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(option =>
{
    option.UseSqlServer("Server=localhost,1433;User=sa;Database=MyDb;Password=YourStrong!Passw0rd;TrustServerCertificate=True;");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.MapControllers();

app.Run();
