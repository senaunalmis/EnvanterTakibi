using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IKullanicilarRepository :IGenericRepository<Kullanicilar>
    {
        Task<Kullanicilar?> EpostaylaGetirInclude(string eposta);
        Task<Kullanicilar?> GetirInclude(int Id);
        Task<List<Kullanicilar>> TumunuGetirInclude();
    }
}
