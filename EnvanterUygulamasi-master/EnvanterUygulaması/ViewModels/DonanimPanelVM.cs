using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.ViewModels
{
    public class DonanimPanelVM
    {
        public DonanimPanelVM()
        {
            MarkaList = new List<Liste>();
            TurList = new List<Liste>();
            AltTurList= new List<Liste>();
        }
        public int id { get; set; }
        public string Adi { get; set; }
        public int? TurId { get; set; }
        public string? TurAdi { get; set; }


        public string? TurAdlari { get; set; }
        public string? TurIdler { get; set; }

        public int str { get; set; }
        public int? AltTurId { get; set; }
        public int? MarkaId { get; set; }
        public int? UstModelId { get; set; }


        public List<Liste> MarkaList { get; set; }
        public List<Liste> TurList { get; set; }

        public List<Liste> UstModelList { get; set; }
        public List<Liste> AltModelList { get; set; }

        public List<Liste> AltTurList { get; set; }
        public List<int> TurIdler_chk { get; set; }
    }
}
