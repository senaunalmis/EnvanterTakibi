using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class loglar
    {
        public int id { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarihi { get; set; }
    }
}
