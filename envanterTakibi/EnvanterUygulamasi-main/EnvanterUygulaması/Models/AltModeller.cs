namespace EnvanterUygulaması.Models
{
    public class AltModeller
    {
        public int id { get; set; }
        //UstModeller için foreign key
        public int UstModelID { get; set; }
        public UstModeller UstModel { get; set; }
        public string Adi { get; set; }
        public string Durumu { get; set; }
        public Donanimlar Donanim { get; set; }
    }
}
