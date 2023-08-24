using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.Data.SqlClient;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class DonanimRepository : GenericRepository<Donanimlar> , IDonanimRepository
    {
       
        private DataContext _context;
        private DbSet<Donanimlar> _dbSet;
        public DonanimRepository(DataContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Donanimlar;
        }

        public List<Donanimlar> AdetSay(int MarkaID, int UstModelID, int AltModelID)
        {
            var donanimListe= new List<Donanimlar>();
            return donanimListe;
        }

        public List<Donanimlar> GetAllDonanimlar()
        {

            return _context.Donanimlar.ToList();

        }
    }

}
