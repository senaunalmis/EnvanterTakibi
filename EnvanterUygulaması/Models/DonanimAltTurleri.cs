namespace EnvanterUygulaması.Models
{
    public class DonanimAltTurleri
    {
        public int id { get; set; }
        public int DonanimTuruID { get; set; }
        public DonanimTurleri DonanimTuru { get; set; }
        public string Adi { get; set; }
        public string Durumu { get; set; }
        
    }
}
