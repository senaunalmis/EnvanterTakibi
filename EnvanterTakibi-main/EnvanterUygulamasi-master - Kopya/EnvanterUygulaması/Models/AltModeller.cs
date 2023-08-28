using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Context;

namespace EnvanterUygulaması.Models
{
    public class AltModeller
    {
        public int id { get; set; }
        public int UstModelID { get; set; }
        public string Adi { get; set; }
        public string Durumu { get; set; }
        public UstModeller ustModeller { get; set; }
        public ICollection<Donanimlar> donanimlar { get; } = new List<Donanimlar>();
    }
}
