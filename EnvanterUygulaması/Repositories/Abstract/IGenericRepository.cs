using System.Linq.Expressions;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Getir(int id);
        IEnumerable<TEntity> TumunuGetir(params Expression<Func<TEntity, object>>[] includeProperties);
        void Sil(int id);
        void Guncelle(TEntity entity);
        void Ekle(TEntity entity);
    }
}
