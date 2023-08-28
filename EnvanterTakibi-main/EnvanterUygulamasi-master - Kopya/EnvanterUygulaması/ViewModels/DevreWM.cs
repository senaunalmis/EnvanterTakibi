namespace EnvanterUygulaması.ViewModels
{
    public class DevreWM
    {
        public int id { get; set; }
        public string Adi {get;set;}
        public int Nosu { get;set;}
        public string Bolge { get;set;}
        public int BulutID { get;set;}
        public string BulutAdi { get;set;}
        public string AnaDevreNo { get;set;}
        public string IpBlogu { get; set; }
        public string Durumu { get; set; }
        public string Koordinati { get; set; }
        public string Aciklama { get; set; }
        public bool Mahsup { get; set; }
        public string EkleyenKullanici { get; set; }
    }
}
