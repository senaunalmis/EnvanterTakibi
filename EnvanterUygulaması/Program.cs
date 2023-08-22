using EnvanterUygulamasý.Models;
using EnvanterUygulamasý.Repositories.Concrete;
using EnvanterUygulamasý.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantý ayarýný al
var configuration = builder.Configuration;

// DbContext yapýlandýrmasýný ekle
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = configuration.GetConnectionString("MyDbContext");
    options.UseSqlServer(connectionString);
});


builder.Services.AddScoped<IDonanimRepository, DonanimRepository>();

// Diðer hizmetleri ekle
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
