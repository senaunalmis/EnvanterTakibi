using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.ViewModels
{
    public class DonanimEkleDuzenleVM
    {
        public DonanimEkleDuzenleVM()
        {
            TurList=new List<Liste>();
            AltTurList=new List<Liste>();
            MarkaList=new List<Liste>();
            UstModelList=new List<Liste>();
            AltModelList=new List<Liste>();
        }
        public int id { get; set; } 

        public int MarkaId { get; set; }

        public int UstModelId { get; set; }

        public int AltModelId { get; set; }

        public int TurId { get; set; }

        public int? AltTurId { get; set; }

        public string Durum { get; set; }

        public string Birim { get; set; }

        public string? MacAdres { get; set; }

        public string  SeriNo{ get; set; }

        public DateTime AlimTarihi { get; set; }

        public int GarantiSuresi { get; set; }

        public bool? Poe { get; set; }
        public string Aciklama { get; set; } 

        public int? BaglantiHizi { get; set; }

        public string? Mod { get; set; }

        public string? Guc { get; set; }

        public string? Tip { get; set; }

        public List<Liste> TurList { get; set; }
        public List<Liste> AltTurList { get; set; }
        public List<Liste>  MarkaList{ get; set; }
        public List<Liste>  UstModelList{ get; set; }
        public List<Liste>  AltModelList{ get; set; }
    }
}
