using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IDevreRepository
    {
        Task<List<Devreler>> TumunuGetir();
    }
}
