using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class DevreRepository : IDevreRepository
    {
        private readonly DataContext _context;

        public DevreRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Devreler>> TumunuGetir()
        {
            var devreList = await _context.Devreler
                .Include(d => d.bulutlar)
                .Include(d => d.kullanicilar)
                .ToListAsync();

            return devreList;
        }
    }
}
