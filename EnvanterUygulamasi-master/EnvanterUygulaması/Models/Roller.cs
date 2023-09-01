using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class Roller
    {
        public int id { get; set; }
        public string Yetkisi { get; set; }
        public ICollection<KullaniciRolleri> kullaniciRolleri { get; set; }

    }
}
