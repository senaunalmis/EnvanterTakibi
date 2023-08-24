namespace EnvanterUygulaması.Models
{
    public class DonanimTurleri
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Durumu { get; set; }
        public Donanimlar Donanim { get; set; }
        public ICollection<DonanimAltTurleri> DonanimAltTuru { get; set; }
    }
}
