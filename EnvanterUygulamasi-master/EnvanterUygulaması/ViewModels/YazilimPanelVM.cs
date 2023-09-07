using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.ViewModels
{
    public class YazilimPanelVM
    {
        public YazilimPanelVM()
        {
            MarkaList = new List<Liste>();
        }
        public int id { get; set; }
        public string Adi { get; set; }
        public List<Liste> MarkaList { get; set; }
    }
}
