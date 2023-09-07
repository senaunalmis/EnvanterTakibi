namespace EnvanterUygulaması.Models
{
    public class DonanimMarkaTurleri
    {
        public int TurId { get; set; }
        public int MarkaId { get; set; }
        public DonanimMarkalari donanimMarkalari { get; set; }
        public DonanimTurleri donanimTurleri  { get; set; }
    }
}
