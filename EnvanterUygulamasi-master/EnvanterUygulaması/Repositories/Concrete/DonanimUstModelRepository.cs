using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class DonanimUstModelRepository : GenericRepository<UstModeller>, IDonanimUstModelRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<UstModeller> _donanimUstModelDbSet;

        public DonanimUstModelRepository(DataContext context) : base(context)
        {
            _context = context;
            _donanimUstModelDbSet = context.UstModeller;
        }

        public async Task<List<UstModeller>> TumunuGetirInclude()
        {
            var donanimUstModelList = await _context.UstModeller
                .Include(d => d.donanimMarkalari)
                .ToListAsync();

            return donanimUstModelList;
        }
        public async Task<UstModeller?> GetirInclude(int id ,int DonanimMarkaId)
        {
            return await _context.UstModeller.Include(x => x.donanimMarkalari).FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
