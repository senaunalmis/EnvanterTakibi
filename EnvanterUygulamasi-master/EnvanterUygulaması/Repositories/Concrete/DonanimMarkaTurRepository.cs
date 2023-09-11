using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class DonanimMarkaTurRepository: GenericRepository<DonanimMarkaTurleri>, IDonanimMarkaTurRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<DonanimTurleri> _donanimTurleriDbset;

        public DonanimMarkaTurRepository(DataContext context): base(context)
        {
            _context = context;
            _donanimTurleriDbset = context.DonanimTurleri;
        }

        public async Task<List<DonanimMarkaTurleri>> TumunuGetirInclude()
        {
            var markaTurList = await _context.DonanimMarkaTurleri
                .Include(d => d.donanimMarkalari)
                .Include(d => d.donanimTurleri)
                .ToListAsync();

            return markaTurList;
        }
        public async Task<DonanimMarkaTurleri?> GetirInclude(int markaId,int turId)
        {
            return await _context.DonanimMarkaTurleri.Include(x=>x.donanimMarkalari).Include(x=>x.donanimTurleri).FirstOrDefaultAsync(x=>x.MarkaId==markaId&&x.TurId==turId);
        }

    }
}
