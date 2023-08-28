using EnvanterUygulamas�.Context;
using EnvanterUygulamas�.Repositories.Abstract;
using EnvanterUygulamas�.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lant� ayar�n� al
var configuration = builder.Configuration;


builder.Services.AddTransient<IDonanimRepository, DonanimRepository>();
builder.Services.AddTransient<IYazilimRepository, YazilimRepository>();
builder.Services.AddTransient<IDevreRepository, DevreRepository>();
// DbContext yap�land�rmas�n� ekle
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = configuration.GetConnectionString("MyDbContext");
    options.UseSqlServer(connectionString);
});

// Di�er hizmetleri ekle
builder.Services.AddControllersWithViews();


var app = builder.Build();

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
