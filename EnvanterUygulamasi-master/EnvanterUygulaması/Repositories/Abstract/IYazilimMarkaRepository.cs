using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IYazilimMarkaRepository : IGenericRepository<YazilimMarkalari>
    {
        Task<List<YazilimMarkalari>> TumunuGetirInclude();
    }
}
