namespace EnvanterUygulaması.Models
{
    public class UstModeller
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public string Durumu { get; set; }
        public Donanimlar Donanim { get; set; }
        public ICollection<AltModeller> AltModel { get; set; }
    }
}
