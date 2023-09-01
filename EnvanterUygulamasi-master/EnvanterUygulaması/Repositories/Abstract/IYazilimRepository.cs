using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IYazilimRepository: IGenericRepository<Yazilimlar>
    {
        Task<List<Yazilimlar>> TumunuGetirInclude();
        Task<Yazilimlar?> GetirInclude(int id);
    }
}
