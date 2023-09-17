using EnvanterUygulamasý.Context;
using EnvanterUygulamasý.Repositories.Abstract;
using EnvanterUygulamasý.Repositories.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
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
builder.Services.AddTransient<IKullanicilarRepository, KullanicilarRepository>();
builder.Services.AddTransient<IKullaniciRolleriRepository, KullaniciRolleriRepository>();
builder.Services.AddTransient<IRollerRepository, RollerRepository>();




// DbContext yapýlandýrmasýný ekle
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = configuration.GetConnectionString("MyDbContext");
    options.UseSqlServer(connectionString);
});

// Diðer hizmetleri ekle
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Security/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    }
    );

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Security}/{action=Login}/{id?}");

app.Run();
