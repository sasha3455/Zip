using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebApplication6.Models.ÑContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("con")));

app.UseStaticFiles();

app.MapFallbackToFile("main.html");

app.Run();