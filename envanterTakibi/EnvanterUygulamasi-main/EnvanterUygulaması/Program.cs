using EnvanterUygulamas�.Models;
using EnvanterUygulamas�.Repositories.Concrete;
using EnvanterUygulamas�.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lant� ayar�n� al
var configuration = builder.Configuration;

// DbContext yap�land�rmas�n� ekle
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = configuration.GetConnectionString("MyDbContext");
    options.UseSqlServer(connectionString);
});


builder.Services.AddScoped<IDonanimRepository, DonanimRepository>();

// Di�er hizmetleri ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
