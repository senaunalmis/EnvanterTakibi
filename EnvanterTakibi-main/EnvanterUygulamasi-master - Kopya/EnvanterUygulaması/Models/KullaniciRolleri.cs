using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class KullaniciRolleri
    {
        public int KullaniciID { get; set; }
        public Kullanicilar kullanicilar { get; set; }
        public int RolID { get; set; }
        public Roller roller { get; set; }
    }
}
