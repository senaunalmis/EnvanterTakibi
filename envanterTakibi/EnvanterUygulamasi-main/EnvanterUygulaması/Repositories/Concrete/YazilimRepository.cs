using EnvanterUygulaması.Models;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class YazilimRepository : GenericRepository<Yazilimlar>
    {
        private DataContext _context;
        private DbSet<Yazilimlar> _dbSet;
        public YazilimRepository(DataContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Yazilimlar;
        }
        public List<Yazilimlar> GetAll() { return _context.Yazilimlar.ToList(); }

    }
}
