using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class Bildirimler
    {
        public int id { get; set; }
        public string Aciklama { get; set; }
        public bool OkunduMu { get; set; }
    }
}
