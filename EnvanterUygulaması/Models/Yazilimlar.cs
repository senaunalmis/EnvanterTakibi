namespace EnvanterUygulaması.Models
{
    public class Yazilimlar
    {
        public int id { get; set; }

        //YazilimMarkalari için foreign key
        public int  YazilimMarkaID { get; set; }
        public YazilimMarkalari YazilimMarka { get; set; }
        public string Adi { get; set; }
        public string Versiyon { get; set; }
        public string Turu { get; set; }
        public int? CihazSayisi { get; set; }
        public DateTime AlimTarihi { get; set; }
        public int DestekSuresi { get; set; }
        public string Aciklama { get; set; }
        //Kullanicilar icin foreign key
        public int EkleyenID { get; set; }
        public Kullanicilar Kullanici { get; set; }
    }
}
