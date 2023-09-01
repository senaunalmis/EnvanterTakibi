using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class DonanimTurleri
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public string Durumu { get; set; }
        public ICollection<Donanimlar> donanimlar { get; } = new List<Donanimlar>();
        public ICollection<DonanimAltTurleri> donanimAltTurleri { get; set; }
    }
}
