namespace EnvanterUygulaması.Models
{
    public class DonanimViewModel
    {


        public List<Donanimlar> Donanimlars { get; set; }

        public int id { get; set; }
        public string Turu { get; set; }
        public string? AltTuru { get; set; }
        public string Marka { get; set; }
        public string UstModel { get; set; }
        public string AltModel { get; set; }
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
        public string EkleyenKullanici { get; set; }
        public string Birim { get; set; }
        public string? Aciklama { get; set; }
        //Kullanicilar icin foreign key

    }
}
