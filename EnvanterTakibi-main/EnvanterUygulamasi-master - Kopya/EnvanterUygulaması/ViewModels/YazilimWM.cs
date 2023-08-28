namespace EnvanterUygulaması.ViewModels
{
    public class YazilimWM
    {
        public int id { get; set; }
        public string Markasi { get; set; }
        public string Adi { get; set; }
        public string Versiyonu { get; set; }
        public string Turu { get; set; }
        public int CihazSayisi { get; set; }
        public DateTime AlimTarihi{ get; set; }
        public int DestekSuresi{ get; set; }
        public string Aciklama{ get; set; }
        public string EkleyenKullanici{ get; set; }
    }
}
