using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IYazilimRepository
    {
        Task<List<Yazilimlar>> TumunuGetir();
    }
}
