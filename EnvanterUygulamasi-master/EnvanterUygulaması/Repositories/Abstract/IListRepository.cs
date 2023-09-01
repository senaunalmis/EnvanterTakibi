using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IListRepository
    {
        Task<List<Liste>> YazilimMarkaListesiGetir();
        Task<List<Liste>> TurListesiGetir();
        Task<List<Liste>> AltTurListesiGetir(int id);
        Task<List<Liste>> DonanimMarkaListesiGetir();
        Task<List<Liste>> UstModelListesiGetir(int id);
        Task<List<Liste>> AltModelListesiGetir(int id);
        Task<List<Liste>> BulutListesiGetir();
        List<string> BolgeListe();
    }
}
