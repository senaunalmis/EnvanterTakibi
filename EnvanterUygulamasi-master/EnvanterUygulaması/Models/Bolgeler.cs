namespace EnvanterUygulaması.Models
{
    public class Bolgeler
    {
        public int id {  get; set; }
        public string Adi { get; set; }

        public ICollection<Donanimlar> donanimlar { get; set; }
        public ICollection<Yazilimlar> yazilimlar { get; set; }
        public ICollection<Devreler> devreler { get; set; }  
    }
}
