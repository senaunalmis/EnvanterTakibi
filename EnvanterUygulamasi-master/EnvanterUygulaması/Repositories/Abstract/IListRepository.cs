using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IListRepository
    {
        Task<List<Liste>> YazilimMarkaListesiGetir();
        Task<List<Liste>> BulutListesiGetir();
        Task<List<Liste>> BolgeListesiGetir();
        Task<Bulutlar> BulutOzellikleriGetir(int SecilenBulutId);

        Task<List<Liste>> TurListesiGetir();
        Task<List<Liste>> AltTurListesiGetir(int TurId);
        Task<List<Liste>> DonanimMarkaListesiGetir(int TurId);
        Task<List<Liste>> UstModelListesiGetir(int MarkaId);
        Task<List<Liste>> AltModelListesiGetir(int UstModelId);
    }
}
