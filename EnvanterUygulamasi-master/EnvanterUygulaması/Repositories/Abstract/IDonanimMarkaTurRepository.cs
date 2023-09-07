using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IDonanimMarkaTurRepository : IGenericRepository<DonanimMarkaTurleri>
    {
        Task<List<DonanimMarkaTurleri>> TumunuGetirInclude();
    }
}
