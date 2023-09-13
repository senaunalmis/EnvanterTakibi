using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class DonanimAltModelRepository : GenericRepository<AltModeller>, IDonanimAltModelRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<AltModeller> _donanimAltModelDbSet;

        public DonanimAltModelRepository(DataContext context) : base(context)
        {
            _context = context;
            _donanimAltModelDbSet = context.AltModeller;
        }

        public async Task<List<AltModeller>> TumunuGetirInclude()
        {
            var donanimAltModelList = await _context.AltModeller
                .Include(d => d.ustModeller)
                .ToListAsync();

            return donanimAltModelList;
        }
        public async Task<AltModeller?> GetirInclude(int id, int UstModelId)
        {
            return await _context.AltModeller.Include(x => x.ustModeller).FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
