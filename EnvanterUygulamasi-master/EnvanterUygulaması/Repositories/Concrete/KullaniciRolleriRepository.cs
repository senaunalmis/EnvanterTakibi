using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class KullaniciRolleriRepository : GenericRepository<KullaniciRolleri> ,IKullaniciRolleriRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<KullaniciRolleri> _dbSet;
        public KullaniciRolleriRepository(DataContext context):base(context) { _context = context; _dbSet = context.KullaniciRolleri; }
        
    }
}
