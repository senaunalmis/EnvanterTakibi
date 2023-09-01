using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IDonanimRepository: IGenericRepository<Donanimlar>
    {
        Task<List<Donanimlar>> TumunuGetirInclude();
        Task DonanimEkle(Donanimlar donanim);
        Task<Donanimlar?> GetirInclude(int Id);
    }
}
