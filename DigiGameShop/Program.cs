using DigiGameShop.Database;
using DigiGameShop.Interfaces;
using DigiGameShop.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IUserServices, UserServices>();
builder.Services.AddSingleton<IProductServices, ProductServices>();
builder.Services.AddControllers();
builder.Services.AddDbContext<DigiGameShopDbContext>(db => db.UseSqlite(builder.Configuration.GetConnectionString("DigiGameShopDBConnectionString")), ServiceLifetime.Singleton);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
