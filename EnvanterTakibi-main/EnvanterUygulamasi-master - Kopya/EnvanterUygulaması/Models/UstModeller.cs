using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class UstModeller
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public string Durumu { get; set; }
        public ICollection<Donanimlar> donanimlar { get; } = new List<Donanimlar>();
        public ICollection<AltModeller> altModeller { get; } = new List<AltModeller>();
    }
}
