using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class ListRepository : IListRepository
    {
        private readonly DataContext _context;

        public ListRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Liste>> BulutListesiGetir()
        {
            var bulutlar=await _context.Bulutlar.ToListAsync();
            var bulutlarListesi = bulutlar.Select(x => new Liste { Adi = x.Adi, id = x.id }).ToList();
            return bulutlarListesi;
        }
        public async Task<List<Liste>> YazilimMarkaListesiGetir()
        {
            var markalar = await _context.YazilimMarkalari.ToListAsync();
            var markaListesi = markalar.Select(x => new Liste { Adi = x.Adi, id = x.id }).ToList();
            return markaListesi;
        }
        public async Task<List<Liste>> TurListesiGetir()
        {
            var turler = await _context.DonanimTurleri.ToListAsync();
            var turListesi = turler.Select(x => new Liste { Adi = x.Adi, id = x.id }).ToList();
            return turListesi;
        }
        public async Task<List<Liste>> AltTurListesiGetir(int turId)
        {
            var altTurler = await _context.DonanimAltTurleri.Where(x => x.DonanimTuruID == turId).ToListAsync();
            var altTurListesi = altTurler.Select(x => new Liste { Adi = x.Adi, id = x.id }).ToList();
            return altTurListesi;
        }

        public async Task<List<Liste>> DonanimMarkaListesiGetir()
        {
            var markalar = await _context.DonanimMarkalari.ToListAsync();
            var markaListesi = markalar.Select(x => new Liste { Adi = x.Adi, id = x.id }).ToList();
            return markaListesi;
        }
        public async Task<List<Liste>> UstModelListesiGetir(int markaId)
        {
            var ustModeller = await _context.UstModeller.Where(x=>x.DonanimMarkaId==markaId).ToListAsync();
            var ustModelListesi= ustModeller.Select(x=> new Liste {Adi=x.Adi,id=x.id}).ToList();
            return ustModelListesi;
        }
        public async Task<List<Liste>> AltModelListesiGetir(int ustModelId)
        {
            var altModeller = await _context.AltModeller.Where(x=>x.UstModelID==ustModelId).ToListAsync();
            var altModelListesi = altModeller.Select(x=>new Liste { Adi=x.Adi,id = x.id}).ToList();
            return altModelListesi;
        }

        public List<string> BolgeListe()
        {
            List<string> items = new List<string>
            {
                "1. Bölge Müdürlüğü | İstanbul",
                "2. Bölge Müdürlüğü | İzmir",
                "3. Bölge Müdürlüğü | Konya",
                "4. Bölge Müdürlüğü | Ankara",
                "5. Bölge Müdürlüğü | Mersin",
                "6. Bölge Müdürlüğü | Kayseri",
                "7. Bölge Müdürlüğü | Samsun",
                "8. Bölge Müdürlüğü | Elazığ",
                "9. Bölge Müdürlüğü | Diyarbakır",
                "10. Bölge Müdürlüğü | Trabzon",
                "11. Bölge Müdürlüğü | Van",
                "12. Bölge Müdürlüğü | Erzurum",
                "13. Bölge Müdürlüğü | Antalya",
                "14. Bölge Müdürlüğü | Bursa",
                "15. Bölge Müdürlüğü| Kastamonu",
                "16. Bölge Müdürlüğü | Sivas",
                "18. Bölge Müdürlüğü | Kars"
            };
            return items;
        }
    }
}
