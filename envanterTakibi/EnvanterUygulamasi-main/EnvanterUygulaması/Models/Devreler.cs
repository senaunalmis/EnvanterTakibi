namespace EnvanterUygulaması.Models
{
    public class Devreler
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public int No { get; set; }
        public string Bolge { get; set; }
        //Bulutlar için foreign key
        public int BulutID { get; set; }
        public Bulutlar Bulut { get; set; }
        public string IpBlogu { get; set; }
        public bool Durumu { get; set; }
        public string Koordinat { get; set; }
        public bool Mahsup { get; set; }
        public string Aciklama { get; set; }
        //Kullanicilar icin foreign key
        public int EkleyenID { get; set; }
        public Kullanicilar Kullanici { get; set; }
    }
}
