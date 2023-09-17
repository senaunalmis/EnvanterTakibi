using EnvanterUygulaması.Models;
using EnvanterUygulaması.Context;
using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Repositories.Abstract;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class KullanicilarRepository :GenericRepository<Kullanicilar> , IKullanicilarRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Kullanicilar> _dbSet;
        
        public KullanicilarRepository(DataContext context) : base(context) { _context=context; _dbSet = _context.Kullanicilar; }

        public async Task<Kullanicilar?> EpostaylaGetirInclude(string eposta)
        {
            return await _dbSet.Include(k => k.kullaniciRolleri).ThenInclude(kr => kr.roller).Where(k => k.Eposta == eposta).FirstOrDefaultAsync();
        }
        public async Task<List<Kullanicilar>> TumunuGetirInclude()
        {
            return await _dbSet.Include(k=>k.kullaniciRolleri).ThenInclude(kr=>kr.roller).ToListAsync();
        }
        public async Task<Kullanicilar?> GetirInclude(int id)
        {
            return await _dbSet.Include(k => k.kullaniciRolleri).ThenInclude(kr => kr.roller).Where(k => k.id == id).FirstOrDefaultAsync();
        }


    }
}
