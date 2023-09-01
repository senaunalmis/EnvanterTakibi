using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class Kullanicilar
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public string Sifresi { get; set; }
        public ICollection<KullaniciRolleri> kullaniciRolleri { get; set; }
        public ICollection<Donanimlar> donanimlar { get; } = new List<Donanimlar>();
        public ICollection<Yazilimlar> yazilimlar { get; } = new List<Yazilimlar>();
        public ICollection<Devreler> devreler { get; } = new List<Devreler>();
    }
}
