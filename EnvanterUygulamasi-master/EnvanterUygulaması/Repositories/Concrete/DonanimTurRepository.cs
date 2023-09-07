using EnvanterUygulaması.Context;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class DonanimTurRepository: GenericRepository<DonanimTurleri>, IDonanimTurRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<DonanimTurleri> _donanimTurleriDbset;

        public DonanimTurRepository(DataContext context): base(context)
        {
            _context = context;
            _donanimTurleriDbset = context.DonanimTurleri;
        }
    }
}
