using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class DonanimAltTurleri
    {
        public int id { get; set; }
        public int DonanimTuruID { get; set; }
        public string Adi { get; set; }
        public string Durumu { get; set; }
        public DonanimTurleri donanimTurleri { get; set; }
        public  ICollection<Donanimlar> donanimlar { get; } = new List<Donanimlar>();
    }
}
