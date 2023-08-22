namespace EnvanterUygulaması.Models
{
    public class KullaniciRolleri
    {
        public int KullaniciID { get; set; }
        public Kullanicilar Kullanici { get; set; }
        public int RolID { get; set; }
        public Roller Rol { get; set; }
    }
}
