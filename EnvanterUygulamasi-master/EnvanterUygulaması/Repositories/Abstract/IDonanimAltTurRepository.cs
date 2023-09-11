using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IDonanimAltTurRepository : IGenericRepository<DonanimAltTurleri>
    {
        Task<List<DonanimAltTurleri>> TumunuGetirInclude();
        Task<DonanimAltTurleri?> GetirInclude(int altTurId);
    }
}
