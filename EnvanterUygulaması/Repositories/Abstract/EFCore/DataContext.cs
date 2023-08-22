using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<YazilimMarkalari> YazilimMarkalari { get; set; }
        public DbSet<Yazilimlar> Yazilimlar { get; set; }
        public DbSet<Donanimlar> Donanimlar { get; set; }
        public DbSet<DonanimMarkalari> DonanimMarkalari { get; set; }
        public DbSet<UstModeller> UstModeller { get; set; }
        public DbSet<AltModeller> AltModeller { get; set; }
        public DbSet<Bulutlar> Bulutlar { get; set; }
        public DbSet<Devreler> Devreler { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Roller> Roller { get; set; }
        public DbSet<KullaniciRolleri> KullaniciRolleri { get; set; }
        public DbSet<Bildirimler> Bildirimler { get; set; }
        public DbSet<loglar> Loglar { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Yazilimlar>()
                .HasOne(y => y.YazilimMarka)
                .WithOne(ym => ym.Yazilim)
                .HasForeignKey<Yazilimlar>(y => y.YazilimMarkaID);

            modelBuilder.Entity<Donanimlar>()
                .HasOne(d => d.DonanimMarka)
                .WithOne(dm => dm.Donanim)
                .HasForeignKey<Donanimlar>(d => d.DonanimMarkaID);

            modelBuilder.Entity<Donanimlar>()
                .HasOne(d => d.UstModel)
                .WithOne(um => um.Donanim)
                .HasForeignKey<Donanimlar>(d => d.UstModelID);

            modelBuilder.Entity<Donanimlar>()
                .HasOne(d => d.AltModel)
                .WithOne(am => am.Donanim)
                .HasForeignKey<Donanimlar>(d => d.AltModelID);

            modelBuilder.Entity<UstModeller>()
               .HasMany(um => um.AltModel)
               .WithOne(am => am.UstModel)
               .HasForeignKey(am => am.UstModelID);
            
            modelBuilder.Entity<Devreler>()
                .HasOne(de=>de.Bulut)
                .WithOne(b=>b.Devre)
                .HasForeignKey<Devreler>(de => de.BulutID);
            
            modelBuilder.Entity<KullaniciRolleri>()
                .HasKey(kr => new { kr.KullaniciID, kr.RolID });

            modelBuilder.Entity<KullaniciRolleri>()
                .HasOne(kr => kr.Kullanici)
                .WithMany(k => k.KullaniciRol)
                .HasForeignKey(kr => kr.KullaniciID);

            modelBuilder.Entity<KullaniciRolleri>()
                .HasOne(kr => kr.Rol)
                .WithMany(r => r.KullaniciRol)
                .HasForeignKey(kr => kr.RolID);

            modelBuilder.Entity<Donanimlar>()
                .HasOne(d => d.DonanimTuru)
                .WithOne(dt => dt.Donanim)
                .HasForeignKey<Donanimlar>(d => d.DonanimTuruID);

            modelBuilder.Entity<Donanimlar>()
                .HasOne(d => d.Kullanici)
                .WithOne(k => k.Donanim)
                .HasForeignKey<Donanimlar>(d => d.EkleyenID);

            modelBuilder.Entity<DonanimAltTurleri>()
                .HasOne(dat => dat.DonanimTuru)
                .WithMany(dt => dt.DonanimAltTuru)
                .HasForeignKey(dat => dat.DonanimTuruID);


            modelBuilder.Entity<Yazilimlar>()
                .HasOne(y => y.Kullanici)
                .WithOne(k => k.Yazilim)
                .HasForeignKey<Yazilimlar>(y => y.EkleyenID);

            modelBuilder.Entity<Devreler>()
                .HasOne(de => de.Kullanici)
                .WithOne(k => k.Devre)
                .HasForeignKey<Devreler>(de => de.EkleyenID);

        }
    }

}
