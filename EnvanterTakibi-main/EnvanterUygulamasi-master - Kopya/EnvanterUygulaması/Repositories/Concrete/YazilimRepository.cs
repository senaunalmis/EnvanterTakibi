using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class YazilimRepository: IYazilimRepository
    {
        private readonly DataContext _context;

        public YazilimRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Yazilimlar>> TumunuGetir()
        {
            var yazilimList = await _context.Yazilimlar
                .Include(y => y.yazilimMarkalari)
                .Include(y => y.kullanicilar)
                .ToListAsync();
            return yazilimList;
        }
    }
}
