using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.ViewModels
{
    public class DonanimPanelVM
    {
        public DonanimPanelVM()
        {
            MarkaList = new List<Liste>();
            TurList = new List<Liste>();
        }
        public int id { get; set; }
        public string Adi { get; set; }
        public int TurId { get; set; }
        public string? TurAdi { get; set; }
        public List<Liste> MarkaList { get; set; }
        public List<Liste> TurList { get; set; }
        public List<int> TurIdler_chk { get; set; }
    }
}
