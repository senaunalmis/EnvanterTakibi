namespace EnvanterUygulaması.ViewModels
{
    public class DonanimWM
    {
        public int id {  get; set; }
        public string Turu { get; set; }
        public string? AltTuru { get; set; }
        public string Markasi { get; set; }
        public string UstModeli { get; set; }
        public string AltModeli { get; set; }
        public string MacAdresi { get; set; }
        public string SeriNo { get; set; }
        public string Durumu { get; set; }
        public DateTime AlimTarihi{ get; set; }
        public int GarantiSuresi { get; set; }
        public int Adedi { get; set; }
        public bool Poe { get; set; }
        public string Aciklama { get; set; }
        public string Birimi { get; set; }
        public string EkleyenKullanici { get; set; }

    }
}
