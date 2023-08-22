using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Models
{
    public class Donanimlar
    {
        public int id { get; set; }
        //DonanimTurleri icin foreign key
        public int DonanimTuruID { get; set; }
        public DonanimTurleri DonanimTuru { get; set; }
        public int DonanimAltTuruID { get; set; }
        public DonanimAltTurleri DonanimAltTuru { get; set; }
        //DonanimMarkalari için foreign key
        public int DonanimMarkaID { get; set; }
        public DonanimMarkalari DonanimMarka { get; set; }
        //UstModeller için foreign key
        public int UstModelID { get; set; }
        public UstModeller UstModel { get; set; }
        public int AltModelID { get; set; }
        public AltModeller AltModel { get; set; }
        public string MacAdresi { get; set; }
        public string SeriNo { get; set; }
        public string Durumu { get; set; }
        public DateTime AlimTarihi { get; set; }
        public int GarantiSuresi { get; set; }
        public int Adedi { get; set; }
        public bool Poe { get; set; }
        public int? BaglantiHizi { get; set; }
        public string? Modu { get; set; }
        public string? Tipi { get; set; } 
        public string Birim { get; set; }
        public string Aciklama { get; set; }
        //Kullanicilar icin foreign key
        public int EkleyenID { get; set; }
        public Kullanicilar Kullanici { get; set; }
    }
}
