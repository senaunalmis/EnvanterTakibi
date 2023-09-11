using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class YazilimMarkaRepository : GenericRepository<YazilimMarkalari>, IYazilimMarkaRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<YazilimMarkalari> _yazilimMarkalariDbset;
        public YazilimMarkaRepository(DataContext context) : base(context)
        {
            _dataContext = context;
            _yazilimMarkalariDbset = context.YazilimMarkalari;
        }
        public async Task<List<YazilimMarkalari>> TumunuGetirInclude()
        {
            var markaList = await _dataContext.YazilimMarkalari
                .Include(d => d.Adi)

                .ToListAsync();

            return markaList;
        }
    }
}
