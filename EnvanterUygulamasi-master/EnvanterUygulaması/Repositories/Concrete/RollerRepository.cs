using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class RollerRepository: GenericRepository<Roller> ,IRollerRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Roller> _dbSet;
        public RollerRepository(DataContext Context) :base(Context)
        {
            _dataContext = Context;
            _dbSet = _dataContext.Roller;
        }
    }
}
