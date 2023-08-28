using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class Donanimlar
    {
        public int id { get; set; }
        public int DonanimTuruID { get; set; }       
        public int DonanimAltTuruID { get; set; }
        public int DonanimMarkaID { get; set; }
        public int UstModelID { get; set; }       
        public int AltModelID { get; set; }  
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
        public int EkleyenID { get; set; }
        public DonanimTurleri donanimTurleri { get; set; }
        public DonanimAltTurleri donanimAltTurleri { get; set; }
        public DonanimMarkalari donanimMarkalari { get; set; }
        public UstModeller ustModeller { get; set; }
        public AltModeller altModeller { get; set; }
        public Kullanicilar kullanicilar { get; set; }
    }
}
