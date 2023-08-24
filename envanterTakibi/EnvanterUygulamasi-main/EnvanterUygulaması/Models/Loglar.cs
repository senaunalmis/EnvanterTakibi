using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Models
{
    public class loglar
    {
        public int id { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarihi { get; set; }
    }
}
