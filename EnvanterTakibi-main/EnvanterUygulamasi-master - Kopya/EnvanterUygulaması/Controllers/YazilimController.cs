using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using EnvanterUygulaması.Repositories.Concrete;
using EnvanterUygulaması.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Controllers
{
    public class YazilimController : Controller
    {
        public readonly IYazilimRepository _yazilimRepository;

        public YazilimController(IYazilimRepository yazilimRepository)
        {
            _yazilimRepository = yazilimRepository;
        }

        public async Task<IActionResult> YazilimListe() 
        {
            var yazilimlar = await _yazilimRepository.TumunuGetir();
            List<YazilimWM> yazilimListesi = yazilimlar.Select(x=>new YazilimWM()
            {
                Markasi=x.yazilimMarkalari.Adi,
                Aciklama=x.Aciklama,
                Adi=x.Adi,
                AlimTarihi=x.AlimTarihi,
                CihazSayisi=x.CihazSayisi,
                DestekSuresi=x.DestekSuresi,
                EkleyenKullanici=x.kullanicilar.Adi,
                Turu=x.Turu,
                Versiyonu=x.Versiyon
            }).ToList();
            return View(yazilimListesi);
        }
        public IActionResult YazilimEkle()
        {
            return View();
        }
        public IActionResult EkledigimYazilimlar()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
