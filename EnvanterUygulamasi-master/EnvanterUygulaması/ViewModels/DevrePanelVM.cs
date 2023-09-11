using EnvanterUygulaması.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EnvanterUygulaması.ViewModels
{
    public class DevrePanelVM
    {
        public DevrePanelVM()
        {
            BulutList = new List<Liste>();
        }
        public int id { get; set; }
        public string BulutAdi { get; set; }
        public int BulutNo { get; set; }
        public string AnaDevreNo { get; set; }
        public Boolean Kontrol { get; set; }
        public string? Mesaj { get; set; }
        public List<Liste> BulutList { get; set; }
    }
}
