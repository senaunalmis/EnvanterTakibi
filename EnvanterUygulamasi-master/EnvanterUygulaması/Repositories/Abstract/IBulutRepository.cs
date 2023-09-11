using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IBulutRepository : IGenericRepository<Bulutlar>
    {
        Task<string> BulutKontrolMesaji(int bulutNo, string bulutAdi, string anaDevreNo);
        Task<string> BulutNoKontrolMesaji(int bulutId);
        Task<string> BulutAdiKontrolMesaji(string bulutAdi);
        Task<string> AnaDevreNoKontrolMesaji(string devreNo);
    }
}
