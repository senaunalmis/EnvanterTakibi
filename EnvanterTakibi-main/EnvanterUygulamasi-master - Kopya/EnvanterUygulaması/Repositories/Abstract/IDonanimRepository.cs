using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IDonanimRepository
    {
        Task<List<Donanimlar>> TumunuGetir();
        Task DonanimEkle(Donanimlar donanim);
    }
}
