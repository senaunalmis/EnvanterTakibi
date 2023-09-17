using EnvanterUygulaması.Context;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DataContext _context;
        private DbSet<TEntity> _entity;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entity= _context.Set<TEntity>();
        }
        public async Task<List<TEntity>> TumunuGetir()
        {
            return await _entity.ToListAsync();
        }
        public async Task<TEntity> Ekle(TEntity entity)
        {
            try
            {
                _entity.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public async Task Guncelle(TEntity entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
        }
        public  async Task<TEntity?> Getir(int id)
        {
            return await _entity.FindAsync(id);
        }
        public async Task Sil(int id)
        {
            throw new NotImplementedException();
        }
        public async Task TopluEkle(List<TEntity> entities)
        {
            _context.AddRange(entities);
            await _context.SaveChangesAsync();
        }


    }
}
