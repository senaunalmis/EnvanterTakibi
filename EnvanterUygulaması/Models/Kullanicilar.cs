namespace EnvanterUygulaması.Models
{
    public class Kullanicilar
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public string Sifresi { get; set; }
        public ICollection<KullaniciRolleri> KullaniciRol { get; set; }
        public Donanimlar Donanim { get; set; }
        public Yazilimlar Yazilim { get; set; }
        public Devreler Devre { get; set; }
    }
}
