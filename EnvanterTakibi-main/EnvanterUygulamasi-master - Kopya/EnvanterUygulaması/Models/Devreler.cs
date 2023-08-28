using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class Devreler
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public int No { get; set; }
        public string Bolge { get; set; }
        public int BulutID { get; set; }
        public string IpBlogu { get; set; }
        public string Durumu { get; set; }
        public string Koordinat { get; set; }
        public bool Mahsup { get; set; }
        public string Aciklama { get; set; }
        public int EkleyenID { get; set; }
        public Bulutlar bulutlar { get; set; }
        public Kullanicilar kullanicilar { get; set; }
    }
}
