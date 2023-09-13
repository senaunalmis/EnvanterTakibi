using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IDonanimAltModelRepository : IGenericRepository<AltModeller>
    {
        Task<List<AltModeller>> TumunuGetirInclude();
        Task<AltModeller?> GetirInclude(int id, int UstModelId);

    }
}
