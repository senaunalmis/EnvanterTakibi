using EnvanterUygulamasý.Context;
using EnvanterUygulamasý.Repositories.Abstract;
using EnvanterUygulamasý.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantý ayarýný al
var configuration = builder.Configuration;

builder.Services.AddTransient<IDonanimRepository, DonanimRepository>();
builder.Services.AddTransient<IDonanimTurRepository, DonanimTurRepository>();
builder.Services.AddTransient<IDonanimMarkaRepository, DonanimMarkaRepository>();
builder.Services.AddTransient<IDonanimMarkaTurRepository, DonanimMarkaTurRepository>();
builder.Services.AddTransient<IYazilimRepository, YazilimRepository>();
builder.Services.AddTransient<IYazilimMarkaRepository, YazilimMarkaRepository>();
builder.Services.AddTransient<IDevreRepository, DevreRepository>();
builder.Services.AddTransient<IBulutRepository, BulutRepository>();
builder.Services.AddTransient<IListRepository, ListRepository>();
builder.Services.AddTransient<IDonanimAltTurRepository, DonanimAltTurRepository>();
builder.Services.AddTransient<IDonanimUstModelRepository, DonanimUstModelRepository>();
builder.Services.AddTransient<IDonanimAltModelRepository, DonanimAltModelRepository>();



// DbContext yapýlandýrmasýný ekle
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = configuration.GetConnectionString("MyDbContext");
    options.UseSqlServer(connectionString);
});

// Diðer hizmetleri ekle
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
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
