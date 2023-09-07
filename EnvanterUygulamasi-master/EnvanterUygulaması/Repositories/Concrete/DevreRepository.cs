﻿using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class DevreRepository : GenericRepository<Devreler> ,IDevreRepository
    {
        private readonly DataContext _context;

        public DevreRepository(DataContext context): base(context)
        {
            _context = context;
        }
        public async Task<Devreler> GetirInclude(int id)
        {
            return await _context.Devreler
                .Include(y => y.bulutlar).Where(y=>y.id==id).FirstOrDefaultAsync();
        }
        public async Task<List<Devreler>> TumunuGetirInclude()
        {
            var devreList = await _context.Devreler
                .Include(d => d.bulutlar)
                .Include(d => d.kullanicilar)
                .Include(d=>d.bolgeler)
                .ToListAsync();

            return devreList;
        }
    }
}
