using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class YazilimRepository: GenericRepository<Yazilimlar>,IYazilimRepository
    {
        private readonly DataContext _context;

        public YazilimRepository(DataContext context): base(context) 
        {
            _context = context;
        }
        public async Task<Yazilimlar?> GetirInclude(int id)
        {
            return await _context.Yazilimlar
                .Include(y => y.yazilimMarkalari).Where(y=>y.id==id).FirstOrDefaultAsync();
        }

        public async Task<List<Yazilimlar>> TumunuGetirInclude()
        {
            var yazilimList = await _context.Yazilimlar
                .Include(y => y.yazilimMarkalari)
                .Include(y => y.kullanicilar)
                .Include(y=>y.bolgeler)
                .ToListAsync();
            return yazilimList;
        }
    }
}
