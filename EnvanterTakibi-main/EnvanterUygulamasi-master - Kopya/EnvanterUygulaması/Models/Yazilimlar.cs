using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class Yazilimlar
    {
        public int id { get; set; }
        public int  YazilimMarkaID { get; set; }
        public string Adi { get; set; }
        public string Versiyon { get; set; }
        public string Turu { get; set; }
        public int CihazSayisi { get; set; }
        public DateTime AlimTarihi { get; set; }
        public int DestekSuresi { get; set; }
        public string Aciklama { get; set; }
        public int EkleyenID { get; set; }
        public YazilimMarkalari yazilimMarkalari { get; set; }
        public Kullanicilar kullanicilar { get; set; }
    }
}
