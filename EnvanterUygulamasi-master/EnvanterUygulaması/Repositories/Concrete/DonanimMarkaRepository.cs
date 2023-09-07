using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class DonanimMarkaRepository: GenericRepository<DonanimMarkalari>, IDonanimMarkaRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<DonanimMarkalari> _donanimMarkalariDbSet;

        public DonanimMarkaRepository(DataContext context): base(context) 
        {
            _dataContext = context;
            _donanimMarkalariDbSet = context.DonanimMarkalari;
        }
    }
}
