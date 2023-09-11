using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class BulutRepository : GenericRepository<Bulutlar> , IBulutRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Bulutlar> _bulutlarDbset;

        public BulutRepository(DataContext context) : base(context)
        {
            _context = context;
            _bulutlarDbset = context.Bulutlar;
        }

        public async Task<string> BulutKontrolMesaji(int bulutNo, string bulutAdi, string anaDevreNo)
        {
            // veritabanında aynı özelliklere sahip başka bir kayıt var mı kontrol et
            string mesaj = "";
            var bulutNoKontrol = await _context.Bulutlar.Where(x => x.BulutNo == bulutNo).FirstOrDefaultAsync();
            mesaj += bulutNoKontrol==null?"":"Bulut ID mevcut <br/>";

            var bulutAdiKontrol = await _context.Bulutlar.Where(x => x.Adi == bulutAdi).FirstOrDefaultAsync();
            mesaj += bulutAdiKontrol == null ? "" : "Bulut Adı mevcut <br/>";

            var anaDevreNoKontrol = await _context.Bulutlar.Where(x => x.AnaDevreNo == anaDevreNo).FirstOrDefaultAsync();
            mesaj += anaDevreNoKontrol == null ? "" : "Ana Devre No mevcut ";

            return mesaj;
        }

        public async Task<string> BulutNoKontrolMesaji(int bulutNo)
        {
            string mesaj="";
            var sonuc = await _context.Bulutlar.Where(x=>x.BulutNo==bulutNo).AnyAsync();
            mesaj = sonuc==false?"":"Bulut ID mevcut <br/>";

            return mesaj;
        }
        public async Task<string> BulutAdiKontrolMesaji(string bulutAdi)
        {
            string mesaj = "";
            var sonuc = await _context.Bulutlar.Where(x => x.Adi == bulutAdi).AnyAsync();
            mesaj = sonuc == false ? "" : "Bulut Adı mevcut <br/>";

            return mesaj;
        }
        public async Task<string> AnaDevreNoKontrolMesaji(string anaDevreNo)
        {
            string mesaj = "";
            var sonuc = await _context.Bulutlar.Where(x => x.AnaDevreNo == anaDevreNo).AnyAsync();
            mesaj = sonuc == false ? "" : "Ana Devre No mevcut";

            return mesaj;
        }
    }
}
