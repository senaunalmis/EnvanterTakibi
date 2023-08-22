namespace EnvanterUygulaması.Models
{
    public class YazilimMarkalari
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public string Durumu { get; set; }
        public Yazilimlar Yazilim { get; set; } 
    }
}
