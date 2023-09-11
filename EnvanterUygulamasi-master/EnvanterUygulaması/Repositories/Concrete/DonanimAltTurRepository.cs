using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class DonanimAltTurRepository : GenericRepository<DonanimAltTurleri>, IDonanimAltTurRepository 

    {
        private readonly DataContext _context;
        private readonly DbSet<DonanimAltTurleri> _donanimAltTurleriDbset;

        public DonanimAltTurRepository(DataContext context) : base(context)
        {
            _context = context;
            _donanimAltTurleriDbset = context.DonanimAltTurleri;
        }
        public async Task<List<DonanimAltTurleri>> TumunuGetirInclude()
        {
            var donanimAltTurList = await _context.DonanimAltTurleri
                .Include(d => d.donanimTurleri)
                .ToListAsync();

            return donanimAltTurList;
        }
        public async Task<DonanimAltTurleri?> GetirInclude(int altTurId)
        {
            return await _context.DonanimAltTurleri.Include(x => x.donanimTurleri).FirstOrDefaultAsync(x => x.id == altTurId);
        }
    }
}
