using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.ViewModels
{
    public class YazilimEkleDuzenleVM
    {
        public YazilimEkleDuzenleVM()
        {
            MarkaList = new List<Liste>();
            BolgeList = new List<Liste>();
        }
        public int id { get; set; }
        public int MarkaId { get; set; }
        public string Adi { get; set; }
        public string Versiyonu { get; set; }
        public string Turu { get; set; }
        public int CihazSayisi { get; set; }
        public DateTime AlimTarihi { get; set; }
        public int DestekSuresi { get; set; }
        public string Aciklama { get; set; }
        public int BolgeId { get; set; }
        public string EkleyenKullanici { get; set; }
        public List<Liste> MarkaList { get; set; }
        public List<Liste> BolgeList { get; set; }
    }
}
