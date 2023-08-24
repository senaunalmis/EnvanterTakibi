using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Models
{
    public class Bildirimler
    {
        public int id { get; set; }
        public string Aciklama { get; set; }
        public bool OkunduMu { get; set; }
    }
}
