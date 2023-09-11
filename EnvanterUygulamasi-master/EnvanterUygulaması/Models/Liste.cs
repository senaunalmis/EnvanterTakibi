namespace EnvanterUygulaması.Models
{
    public class Liste
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public int? TurId { get; set; } // Donanim Marka Ekleme sayfası için kullanılıyor
        public string? TurAdi { get; set; }
    }
}
