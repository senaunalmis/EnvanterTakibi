using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using EnvanterUygulaması.Repositories.Concrete;
using EnvanterUygulaması.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnvanterUygulaması.Controllers
{
    public class DonanimController : Controller
    {
        private readonly IDonanimRepository _donanimRepository;

        public DonanimController(IDonanimRepository donanimRepository)
        {
            _donanimRepository = donanimRepository;
        }
        
        public async Task<IActionResult> DonanimListe()
        {
            var donanimlar = await _donanimRepository.TumunuGetir();
            List<DonanimWM> donanimListesi = donanimlar.Select(x => new DonanimWM()
            {
                Turu = x.donanimTurleri.Adi,
                AltTuru=x.donanimAltTurleri.Adi,
                Markasi=x.donanimMarkalari.Adi,
                UstModeli=x.ustModeller.Adi,
                AltModeli=x.altModeller.Adi,
                MacAdresi=x.MacAdresi,
                SeriNo=x.SeriNo,
                Durumu=x.Durumu,
                Aciklama=x.Aciklama,
                Adedi=x.Adedi,
                AlimTarihi=x.AlimTarihi,
                Birimi=x.Birim,
                EkleyenKullanici=x.kullanicilar.Adi,
                GarantiSuresi=x.GarantiSuresi,
                Poe=x.Poe
            }).ToList();

            return View(donanimListesi);
        }

        public async Task<IActionResult> DonanimEkle()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DonanimEkle(Donanimlar donanim)
        {
            await _donanimRepository.DonanimEkle(donanim);

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult EkledigimDonanimlar()
        {
            return View();
        }
        
    }
}
