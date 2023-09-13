namespace EnvanterUygulaması.Models
{
    public class Liste
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public int? TurId { get; set; } // Donanim Marka Ekleme sayfası için kullanılıyor
        public string? TurAdi { get; set; }
        public string? MarkaAdi { get; set; }
        public int? MarkaId { get; set; }
        public string? UstModelAdi { get; set; }
        public int? UstModelId { get; set; }
    }
}
