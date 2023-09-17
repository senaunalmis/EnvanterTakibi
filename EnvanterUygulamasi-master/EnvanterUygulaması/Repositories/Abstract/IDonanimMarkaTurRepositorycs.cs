using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IDonanimMarkaTurRepository : IGenericRepository<DonanimMarkaTurleri>
    {
        Task<List<DonanimMarkaTurleri>> TumunuGetirInclude();
        Task<List<DonanimMarkaTurleri>> GetirInclude(int markaId);
        void TopluSil(List<DonanimMarkaTurleri> entities);
    }
}
