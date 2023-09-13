using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IDonanimUstModelRepository : IGenericRepository<UstModeller>
    {
        Task<List<UstModeller>> TumunuGetirInclude();
        Task<UstModeller?> GetirInclude(int id, int DonanimMarkaId);

    }
}