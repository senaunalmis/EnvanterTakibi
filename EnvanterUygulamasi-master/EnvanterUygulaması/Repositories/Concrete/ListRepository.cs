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
        public async Task<List<Liste>>BolgeListesiGetir()
        {
            var bolgeler = await _context.Bolgeler.ToListAsync();
            var bolgeListesi = bolgeler.Select(x => new Liste { Adi = x.Adi, id = x.id }).ToList();
            return bolgeListesi;
        }
        public async Task<List<Liste>> YazilimMarkaListesiGetir()
        {
            var markalar = await _context.YazilimMarkalari.ToListAsync();
            var markaListesi = markalar.Select(x => new Liste { Adi = x.Adi, id = x.id }).ToList();
            return markaListesi;
        }
        public async Task<List<Liste>> BulutListesiGetir()
        {
            var bulutlar = await _context.Bulutlar.ToListAsync();
            var bulutlarListesi = bulutlar.Select(x => new Liste { Adi = x.Adi, id = x.id }).ToList();
            return bulutlarListesi;
        }
        public async Task<Bulutlar> BulutOzellikleriGetir(int SecilenBulutId)
        {
            var bulut= await _context.Bulutlar.FirstOrDefaultAsync(b => b.id == SecilenBulutId);
            return bulut;
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

        public async Task<List<Liste>> DonanimMarkaListesiGetir(int turId)
        {
            var markalar = await _context.DonanimMarkaTurleri.Include(x=>x.donanimMarkalari).Where(x => x.TurId == turId).ToListAsync();
            var markaListesi = markalar.Select(x => new Liste { Adi = x.donanimMarkalari.Adi, id = x.donanimMarkalari.id }).ToList();
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
       
    }
}
