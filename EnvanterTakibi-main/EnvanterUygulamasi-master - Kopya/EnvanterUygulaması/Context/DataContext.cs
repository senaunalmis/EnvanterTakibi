using EnvanterUygulaması.Models;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
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
        public DbSet<DonanimTurleri> DonanimTurleri { get; set; }
        public DbSet<DonanimAltTurleri> DonanimAltTurleri { get; set; }
        public DbSet<loglar> Loglar { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Yazilimlar>()
                .HasOne(y => y.yazilimMarkalari)
                .WithMany(ym => ym.yazilimlar)
                .HasForeignKey(y => y.YazilimMarkaID);

            modelBuilder.Entity<Donanimlar>()
                .HasOne(d => d.donanimMarkalari)
                .WithMany(dm => dm.donanimlar)
                .HasForeignKey(d => d.DonanimMarkaID);

            modelBuilder.Entity<Donanimlar>()
                .HasOne(d => d.ustModeller)
                .WithMany(um => um.donanimlar)
                .HasForeignKey(d => d.UstModelID);

            modelBuilder.Entity<Donanimlar>()
                 .HasOne(d => d.altModeller)
                 .WithMany(am => am.donanimlar)
                 .HasForeignKey(d => d.AltModelID)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UstModeller>()
               .HasMany(um => um.altModeller)
               .WithOne(am => am.ustModeller)
               .HasForeignKey(am => am.UstModelID);

            modelBuilder.Entity<Devreler>()
                .HasOne(de => de.bulutlar)
                .WithMany(b => b.devreler)
                .HasForeignKey(de => de.BulutID);

            modelBuilder.Entity<KullaniciRolleri>()
                .HasKey(kr => new { kr.KullaniciID, kr.RolID });

            modelBuilder.Entity<KullaniciRolleri>()
                .HasOne(kr => kr.kullanicilar)
                .WithMany(k => k.kullaniciRolleri)
                .HasForeignKey(kr => kr.KullaniciID);

            modelBuilder.Entity<KullaniciRolleri>()
                .HasOne(kr => kr.roller)
                .WithMany(r => r.kullaniciRolleri)
                .HasForeignKey(kr => kr.RolID);

            modelBuilder.Entity<Donanimlar>()
                .HasOne(d => d.donanimTurleri)
                .WithMany(dt => dt.donanimlar)
                .HasForeignKey(d => d.DonanimTuruID);

            modelBuilder.Entity<Donanimlar>()
                .HasOne(d => d.donanimAltTurleri)
                .WithMany(dat => dat.donanimlar)
                .HasForeignKey(d => d.DonanimAltTuruID);

            modelBuilder.Entity<Donanimlar>()
                .HasOne(d => d.kullanicilar)
                .WithMany(k => k.donanimlar)
                .HasForeignKey(d => d.EkleyenID);

            modelBuilder.Entity<DonanimAltTurleri>()
                .HasOne(dat => dat.donanimTurleri)
                .WithMany(dt => dt.donanimAltTurleri)
                .HasForeignKey(dat => dat.DonanimTuruID);


            modelBuilder.Entity<Yazilimlar>()
                .HasOne(y => y.kullanicilar)
                .WithMany(k => k.yazilimlar)
                .HasForeignKey(y => y.EkleyenID);

            modelBuilder.Entity<Devreler>()
                .HasOne(de => de.kullanicilar)
                .WithMany(k => k.devreler)
                .HasForeignKey(de => de.EkleyenID);

            base.OnModelCreating(modelBuilder);
        }
    }

}
