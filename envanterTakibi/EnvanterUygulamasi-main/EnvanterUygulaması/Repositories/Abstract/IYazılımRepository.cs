using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;

namespace EnvanterUygulaması.Repositories
{
    public interface IYazılımRepository : IGenericRepository<Yazilimlar>
    {
        List<Yazilimlar> GetYazilimlars();
    

    }
}
