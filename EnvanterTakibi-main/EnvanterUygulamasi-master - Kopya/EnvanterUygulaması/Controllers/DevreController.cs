using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using EnvanterUygulaması.Repositories.Concrete;
using EnvanterUygulaması.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Controllers
{
    public class DevreController : Controller
    {
        private readonly IDevreRepository _devreRepository;

        public DevreController(IDevreRepository devreRepository)
        {
            _devreRepository = devreRepository;
        }

        public async Task<IActionResult> DevreListe() 
        {
            var devreler = await _devreRepository.TumunuGetir();
            List<DevreWM> devreListe = devreler.Select(x=>new DevreWM()
            {
                Aciklama = x.Aciklama,
                Adi=x.Adi,
                AnaDevreNo=x.bulutlar.AnaDevreNo,
                BulutAdi=x.bulutlar.Adi,
                Bolge=x.Bolge,
                BulutID=x.BulutID,
                Durumu=x.Durumu,
                EkleyenKullanici=x.kullanicilar.Adi,
                IpBlogu=x.IpBlogu,
                Koordinati=x.Koordinat,
                Mahsup=x.Mahsup,
                Nosu=x.No
            }).ToList();
           
            return View(devreListe);
        }

        public IActionResult DevreEkle() 
        {
            return View();
        }
        public IActionResult EkledigimDevreler()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
